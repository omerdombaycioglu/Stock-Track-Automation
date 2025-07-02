using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DepoTakip.Helpers;

namespace DepoTakip.Forms
{
    public partial class UrunSilForm : Form
    {
        private int currentUserId;

        public UrunSilForm(int userId)
        {
            InitializeComponent();
            currentUserId = userId;
            LoadUrunNumaralari();
        }

        private void LoadUrunNumaralari()
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT urun_numarasi FROM urunler WHERE miktar > 0"; // Sadece miktarı >0 olan ürünleri getir

                    var urunNumaralari = new List<string>();
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                urunNumaralari.Add(reader.GetString("urun_numarasi"));
                            }
                        }
                    }

                    comboUrunNo.DataSource = urunNumaralari;
                    comboUrunNo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    comboUrunNo.AutoCompleteSource = AutoCompleteSource.ListItems;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürün numaraları yüklenirken hata oluştu: " + ex.Message);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            string urunNo = comboUrunNo.Text;
            string miktarText = txtMiktar.Text;
            string aciklama = txtAciklama.Text;

            // Validasyonlar
            if (string.IsNullOrEmpty(urunNo))
            {
                MessageBox.Show("Ürün numarası seçmelisiniz!");
                return;
            }

            if (string.IsNullOrEmpty(miktarText) || !int.TryParse(miktarText, out int silinecekMiktar) || silinecekMiktar <= 0)
            {
                MessageBox.Show("Geçerli bir miktar giriniz!");
                return;
            }

            if (string.IsNullOrWhiteSpace(aciklama))
            {
                MessageBox.Show("Silme nedeni belirtmelisiniz!");
                return;
            }

            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();

                    // Ürün bilgilerini kontrol et
                    string checkQuery = "SELECT id, miktar FROM urunler WHERE urun_numarasi = @urunNo";
                    int urunId = 0;
                    int mevcutMiktar = 0;

                    using (var checkCmd = new MySqlCommand(checkQuery, connection))
                    {
                        checkCmd.Parameters.AddWithValue("@urunNo", urunNo);
                        using (var reader = checkCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                urunId = reader.GetInt32("id");
                                mevcutMiktar = reader.GetInt32("miktar");
                            }
                            else
                            {
                                MessageBox.Show("Ürün bulunamadı!");
                                return;
                            }
                        }
                    }

                    if (silinecekMiktar > mevcutMiktar)
                    {
                        MessageBox.Show($"Silinmek istenen miktar ({silinecekMiktar}) mevcut miktardan ({mevcutMiktar}) fazla olamaz!");
                        return;
                    }

                    // Ürün miktarını güncelle (artık hiçbir durumda silme yapmıyoruz)
                    string updateQuery = "UPDATE urunler SET miktar = GREATEST(0, miktar - @miktar) WHERE id = @urunId";
                    using (var updateCmd = new MySqlCommand(updateQuery, connection))
                    {
                        updateCmd.Parameters.AddWithValue("@miktar", silinecekMiktar);
                        updateCmd.Parameters.AddWithValue("@urunId", urunId);
                        updateCmd.ExecuteNonQuery();
                    }

                    // İşlem geçmişine ekle
                    string historyQuery = @"INSERT INTO islem_gecmisi 
                                        (urun_id, islem_tipi, miktar, aciklama, kullanici_id)
                                        VALUES (@urunId, 'silme', @miktar, @aciklama, @userId)";

                    using (var historyCmd = new MySqlCommand(historyQuery, connection))
                    {
                        historyCmd.Parameters.AddWithValue("@urunId", urunId);
                        historyCmd.Parameters.AddWithValue("@miktar", silinecekMiktar);
                        historyCmd.Parameters.AddWithValue("@aciklama", aciklama);
                        historyCmd.Parameters.AddWithValue("@userId", currentUserId);
                        historyCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Ürün miktarı başarıyla güncellendi!");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }
    }
}