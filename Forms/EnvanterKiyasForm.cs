using DepoTakip.Helpers;
using MySql.Data.MySqlClient;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Drawing;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace DepoTakip.Forms
{
    public partial class EnvanterKiyasForm : Form
    {
        public EnvanterKiyasForm()
        {
            InitializeComponent();
        }

        private void btnExcelYukle_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
                openFileDialog.Title = "Excel Dosyası Seçin";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ProcessExcelFileWithNPOI(openFileDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Excel dosyası işlenirken hata oluştu: " + ex.Message);
                    }
                }
            }
        }

        private void ProcessExcelFileWithNPOI(string filePath)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Tip Numarası");
            dt.Columns.Add("Sipariş Numarası");
            dt.Columns.Add("Açıklama");
            dt.Columns.Add("Ürün Numarası");
            dt.Columns.Add("Üretici");
            dt.Columns.Add("İstenen Miktar");
            dt.Columns.Add("Stoktaki Miktar");
            dt.Columns.Add("Durum");

            IWorkbook workbook;
            using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                if (Path.GetExtension(filePath).ToLower() == ".xlsx")
                    workbook = new XSSFWorkbook(stream);
                else
                    workbook = new HSSFWorkbook(stream);

                ISheet sheet = workbook.GetSheetAt(0);

                for (int row = 6; row <= sheet.LastRowNum; row++) // 7. satırdan başla (0-based index)
                {
                    IRow currentRow = sheet.GetRow(row);
                    if (currentRow == null) continue;

                    string tipNo = GetCellValue(currentRow.GetCell(0));
                    if (string.IsNullOrEmpty(tipNo)) break;

                    string siparisNo = GetCellValue(currentRow.GetCell(1));
                    string aciklama = GetCellValue(currentRow.GetCell(2));
                    string urunNo = GetCellValue(currentRow.GetCell(3));
                    string uretici = GetCellValue(currentRow.GetCell(4));
                    int istenenMiktar = int.TryParse(GetCellValue(currentRow.GetCell(5)), out int miktar) ? miktar : 0;

                    int stokMiktar = GetStockQuantity(urunNo);
                    string durum = stokMiktar >= istenenMiktar ? "Yeterli" : "Yetersiz";

                    dt.Rows.Add(tipNo, siparisNo, aciklama, urunNo, uretici, istenenMiktar, stokMiktar, durum);
                }
            }

            dataGridView1.DataSource = dt;
            ColorRowsBasedOnStatus();
        }

        private string GetCellValue(ICell cell)
        {
            if (cell == null) return string.Empty;

            switch (cell.CellType)
            {
                case CellType.String:
                    return cell.StringCellValue;
                case CellType.Numeric:
                    return cell.NumericCellValue.ToString();
                case CellType.Boolean:
                    return cell.BooleanCellValue.ToString();
                case CellType.Formula:
                    return cell.StringCellValue;
                default:
                    return string.Empty;
            }
        }

        private int GetStockQuantity(string urunNo)
        {
            int quantity = 0;
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = "SELECT miktar FROM urunler WHERE urun_numarasi = @urunNo";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@urunNo", urunNo);
                    var result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        quantity = Convert.ToInt32(result);
                    }
                }
            }
            return quantity;
        }

        private void ColorRowsBasedOnStatus()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Durum"].Value?.ToString() == "Yetersiz")
                {
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }
        }
    }
}