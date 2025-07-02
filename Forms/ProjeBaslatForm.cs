using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;

namespace DepoTakip.Forms
{
    public partial class ProjeBaslatForm : Form
    {
        private int currentUserId;
        private string currentUserFullName;

        public ProjeBaslatForm(int userId, string fullName)
        {
            InitializeComponent();
            currentUserId = userId;
            currentUserFullName = fullName;
            txtProjeYetkilisi.Text = fullName;
            txtProjeYetkilisi.ReadOnly = true;
        }

        private void btnExcelYukle_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Dosyaları (*.xlsx)|*.xlsx|Tüm Dosyalar (*.*)|*.*",
                Title = "Excel Dosyası Seçin"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtExcelDosyaYolu.Text = openFileDialog.FileName;
            }
        }

        private void btnOlustur_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProjeAdi.Text) ||
                string.IsNullOrWhiteSpace(txtProjeKodu.Text) ||
                string.IsNullOrWhiteSpace(txtExcelDosyaYolu.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Projeyi veritabanına kaydet
                int projeId = ProjeKaydet();

                // Excel'den ürünleri oku ve veritabanına kaydet
                ExcelOkuVeKaydet(projeId);

                MessageBox.Show("Proje başarıyla oluşturuldu!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int ProjeKaydet()
        {
            string connectionString = "Server=localhost;Database=depo_takip;Uid=root;Pwd=;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO projeler (proje_adi, proje_kodu, proje_yetkilisi_id) VALUES (@proje_adi, @proje_kodu, @yetkili_id); SELECT LAST_INSERT_ID();";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@proje_adi", txtProjeAdi.Text);
                    command.Parameters.AddWithValue("@proje_kodu", txtProjeKodu.Text);
                    command.Parameters.AddWithValue("@yetkili_id", currentUserId);

                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        private void ExcelOkuVeKaydet(int projeId)
        {
            using (FileStream file = new FileStream(txtExcelDosyaYolu.Text, FileMode.Open, FileAccess.Read))
            {
                IWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);

                for (int row = 1; row <= sheet.LastRowNum; row++) // İlk satır başlık olduğu için 1'den başlıyoruz
                {
                    IRow currentRow = sheet.GetRow(row);
                    if (currentRow == null) continue;

                    string urunNumarasi = currentRow.GetCell(0)?.ToString();
                    int miktar = Convert.ToInt32(currentRow.GetCell(1)?.ToString());

                    if (!string.IsNullOrEmpty(urunNumarasi))
                    {
                        // Ürün ID'sini bul
                        int urunId = UrunIdBul(urunNumarasi);
                        if (urunId > 0)
                        {
                            ProjeUrunuKaydet(projeId, urunId, miktar);
                        }
                    }
                }
            }
        }

        private int UrunIdBul(string urunNumarasi)
        {
            string connectionString = "Server=localhost;Database=depo_takip;Uid=root;Pwd=;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT id FROM urunler WHERE urun_numarasi = @urun_numarasi";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@urun_numarasi", urunNumarasi);
                    object result = command.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
            }
        }

        private void ProjeUrunuKaydet(int projeId, int urunId, int miktar)
        {
            string connectionString = "Server=localhost;Database=depo_takip;Uid=root;Pwd=;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO proje_urunleri (proje_id, urun_id, miktar) VALUES (@proje_id, @urun_id, @miktar)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@proje_id", projeId);
                    command.Parameters.AddWithValue("@urun_id", urunId);
                    command.Parameters.AddWithValue("@miktar", miktar);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}