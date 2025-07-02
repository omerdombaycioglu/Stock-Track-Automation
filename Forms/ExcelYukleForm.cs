using DepoTakip.Helpers;
using MySql.Data.MySqlClient;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DepoTakip.Forms
{
    public partial class ExcelYukleForm : Form
    {
        private int currentUserId;
        private DataTable excelData;
        private bool islemTipi; // true: ekleme, false: silme
        private List<string> basarisizIslemler = new List<string>();

        public ExcelYukleForm(int userId)
        {
            InitializeComponent();
            currentUserId = userId;
            radioSil.CheckedChanged += RadioSil_CheckedChanged;
            txtAciklama.Enabled = false;
        }

        private void RadioSil_CheckedChanged(object sender, EventArgs e)
        {
            txtAciklama.Enabled = radioSil.Checked;
            if (!radioSil.Checked) txtAciklama.Clear();
        }

        private void btnDosyaSec_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Dosyaları|*.xls;*.xlsx",
                Title = "Excel Dosyası Seçin"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtDosyaYolu.Text = openFileDialog.FileName;
                ExcelOku(openFileDialog.FileName);
            }
        }

        private void ExcelOku(string filePath)
        {
            try
            {
                IWorkbook workbook;
                using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    if (Path.GetExtension(filePath).ToLower() == ".xlsx")
                        workbook = new XSSFWorkbook(file);
                    else
                        workbook = new HSSFWorkbook(file);
                }

                ISheet sheet = workbook.GetSheetAt(0);
                excelData = new DataTable();

                excelData.Columns.Add("Tip Numarası");
                excelData.Columns.Add("Sipariş Numarası");
                excelData.Columns.Add("Açıklama");
                excelData.Columns.Add("Ürün Numarası");
                excelData.Columns.Add("Üretici");
                excelData.Columns.Add("Miktar");

                for (int rowIndex = 6; rowIndex <= sheet.LastRowNum; rowIndex++)
                {
                    IRow row = sheet.GetRow(rowIndex);
                    if (row == null) break;

                    ICell firstCell = row.GetCell(0);
                    if (firstCell == null || string.IsNullOrWhiteSpace(firstCell.ToString()))
                        break;

                    DataRow dataRow = excelData.NewRow();
                    bool rowEmpty = true;

                    for (int colIndex = 0; colIndex < 6; colIndex++)
                    {
                        ICell cell = row.GetCell(colIndex);
                        string cellValue = "";

                        if (cell != null)
                        {
                            cellValue = GetCellValue(cell);
                        }

                        dataRow[colIndex] = cellValue;
                        if (!string.IsNullOrWhiteSpace(cellValue))
                            rowEmpty = false;
                    }

                    if (!rowEmpty)
                        excelData.Rows.Add(dataRow);
                    else
                        break;
                }

                dataGridViewExcel.DataSource = excelData;
                lblKayitSayisi.Text = $"Toplam {excelData.Rows.Count} ürün bulundu";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Excel okunurken hata oluştu: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetCellValue(ICell cell)
        {
            switch (cell.CellType)
            {
                case CellType.String: return cell.StringCellValue.Trim();
                case CellType.Numeric:
                    return DateUtil.IsCellDateFormatted(cell) ?
                    cell.DateCellValue.ToString() : cell.NumericCellValue.ToString();
                case CellType.Boolean: return cell.BooleanCellValue.ToString();
                case CellType.Formula: return GetFormulaCellValue(cell);
                default: return cell.ToString().Trim();
            }
        }

        private string GetFormulaCellValue(ICell cell)
        {
            switch (cell.CachedFormulaResultType)
            {
                case CellType.String: return cell.StringCellValue.Trim();
                case CellType.Numeric: return cell.NumericCellValue.ToString();
                case CellType.Boolean: return cell.BooleanCellValue.ToString();
                default: return cell.ToString().Trim();
            }
        }

        private void btnIslemYap_Click(object sender, EventArgs e)
        {
            if (excelData == null || excelData.Rows.Count == 0)
            {
                MessageBox.Show("Önce Excel dosyası seçmelisiniz!",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            islemTipi = radioEkle.Checked;

            if (!islemTipi && string.IsNullOrWhiteSpace(txtAciklama.Text))
            {
                MessageBox.Show("Silme işlemi için açıklama girmelisiniz!",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                $"Toplam {excelData.Rows.Count} kayıt ile {(islemTipi ? "ekleme" : "silme")} işlemi yapılacak. Devam etmek istiyor musunuz?",
                "Onay",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                basarisizIslemler.Clear();
                int basariliIslem = 0;
                int basarisizIslem = 0;

                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();

                    foreach (DataRow row in excelData.Rows)
                    {
                        try
                        {
                            string urunNumarasi = row["ürün numarası"].ToString().Trim();

                            if (!int.TryParse(row["miktar"].ToString(), out int miktar) || miktar <= 0)
                            {
                                basarisizIslem++;
                                basarisizIslemler.Add($"Geçersiz miktar: {urunNumarasi}");
                                continue;
                            }

                            if (islemTipi)
                            {
                                UrunEkle(connection, row, ref basariliIslem, ref basarisizIslem);
                            }
                            else
                            {
                                UrunSil(connection, row, ref basariliIslem, ref basarisizIslem);
                            }
                        }
                        catch (Exception ex)
                        {
                            basarisizIslem++;
                            basarisizIslemler.Add($"Hata: {ex.Message}");
                        }
                    }
                }

                ShowResult(basariliIslem, basarisizIslem);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Toplu işlem sırasında hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UrunEkle(MySqlConnection connection, DataRow row, ref int basariliIslem, ref int basarisizIslem)
        {
            string tipNumarasi = row["tip numarası"].ToString().Trim();
            string siparisNumarasi = row["sipariş numarası"].ToString().Trim();
            string aciklama = row["açıklama"].ToString().Trim();
            string urunNumarasi = row["ürün numarası"].ToString().Trim();
            string uretici = row["üretici"].ToString().Trim();
            int miktar = Convert.ToInt32(row["miktar"]);

            string checkQuery = "SELECT id, miktar FROM urunler WHERE urun_numarasi = @urunNo";
            int urunId = 0;
            int mevcutMiktar = 0;

            using (var checkCmd = new MySqlCommand(checkQuery, connection))
            {
                checkCmd.Parameters.AddWithValue("@urunNo", urunNumarasi);
                using (var reader = checkCmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        urunId = reader.GetInt32("id");
                        mevcutMiktar = reader.GetInt32("miktar");
                    }
                }
            }

            if (urunId == 0)
            {
                string insertQuery = @"INSERT INTO urunler 
                    (tip_numarasi, siparis_numarasi, aciklama, urun_numarasi, uretici, miktar) 
                    VALUES (@tipNo, @siparisNo, @aciklama, @urunNo, @uretici, @miktar);
                    SELECT LAST_INSERT_ID();";

                using (var insertCmd = new MySqlCommand(insertQuery, connection))
                {
                    insertCmd.Parameters.AddWithValue("@tipNo", tipNumarasi);
                    insertCmd.Parameters.AddWithValue("@siparisNo", siparisNumarasi);
                    insertCmd.Parameters.AddWithValue("@aciklama", aciklama);
                    insertCmd.Parameters.AddWithValue("@urunNo", urunNumarasi);
                    insertCmd.Parameters.AddWithValue("@uretici", uretici);
                    insertCmd.Parameters.AddWithValue("@miktar", miktar);
                    urunId = Convert.ToInt32(insertCmd.ExecuteScalar());
                }
            }
            else
            {
                string updateQuery = "UPDATE urunler SET miktar = miktar + @miktar WHERE id = @urunId";
                using (var updateCmd = new MySqlCommand(updateQuery, connection))
                {
                    updateCmd.Parameters.AddWithValue("@miktar", miktar);
                    updateCmd.Parameters.AddWithValue("@urunId", urunId);
                    updateCmd.ExecuteNonQuery();
                }
            }

            SaveHistory(connection, urunId, "ekleme", miktar, "");
            basariliIslem++;
        }

        private void UrunSil(MySqlConnection connection, DataRow row, ref int basariliIslem, ref int basarisizIslem)
        {
            string urunNumarasi = row["ürün numarası"].ToString().Trim();
            int miktar = Convert.ToInt32(row["miktar"]);
            string aciklama = txtAciklama.Text.Trim();

            string checkQuery = "SELECT id, miktar FROM urunler WHERE urun_numarasi = @urunNo";
            int urunId = 0;
            int mevcutMiktar = 0;

            using (var checkCmd = new MySqlCommand(checkQuery, connection))
            {
                checkCmd.Parameters.AddWithValue("@urunNo", urunNumarasi);
                using (var reader = checkCmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        urunId = reader.GetInt32("id");
                        mevcutMiktar = reader.GetInt32("miktar");
                    }
                    else
                    {
                        basarisizIslem++;
                        basarisizIslemler.Add($"Ürün bulunamadı: {urunNumarasi}");
                        return;
                    }
                }
            }

            if (miktar > mevcutMiktar)
            {
                basarisizIslem++;
                basarisizIslemler.Add($"Yetersiz stok: {urunNumarasi} (Stok: {mevcutMiktar}, İstenen: {miktar})");
                return;
            }

            // Güncelleme işlemi (artık hiçbir durumda silme yapmıyoruz)
            string updateQuery = "UPDATE urunler SET miktar = GREATEST(0, miktar - @miktar) WHERE id = @urunId";
            using (var updateCmd = new MySqlCommand(updateQuery, connection))
            {
                updateCmd.Parameters.AddWithValue("@miktar", miktar);
                updateCmd.Parameters.AddWithValue("@urunId", urunId);
                updateCmd.ExecuteNonQuery();
            }

            SaveHistory(connection, urunId, "silme", miktar, aciklama);
            basariliIslem++;
        }

        private void SaveHistory(MySqlConnection connection, int urunId, string islemTipi, int miktar, string aciklama)
        {
            string historyQuery = @"INSERT INTO islem_gecmisi 
                (urun_id, islem_tipi, miktar, aciklama, kullanici_id)
                VALUES (@urunId, @islemTipi, @miktar, @aciklama, @userId)";

            using (var historyCmd = new MySqlCommand(historyQuery, connection))
            {
                historyCmd.Parameters.AddWithValue("@urunId", urunId);
                historyCmd.Parameters.AddWithValue("@islemTipi", islemTipi);
                historyCmd.Parameters.AddWithValue("@miktar", miktar);
                historyCmd.Parameters.AddWithValue("@aciklama", aciklama);
                historyCmd.Parameters.AddWithValue("@userId", currentUserId);
                historyCmd.ExecuteNonQuery();
            }
        }

        private void ShowResult(int basariliIslem, int basarisizIslem)
        {
            string sonucMesaji = $"İşlem tamamlandı!\nBaşarılı: {basariliIslem}\nBaşarısız: {basarisizIslem}";

            if (basarisizIslem > 0)
            {
                var resultForm = new BasarisizIslemlerForm(basarisizIslemler);
                resultForm.ShowDialog();
            }

            MessageBox.Show(sonucMesaji, "Sonuç",
                MessageBoxButtons.OK,
                basarisizIslem > 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Information);

            this.Close();
        }
    }
}