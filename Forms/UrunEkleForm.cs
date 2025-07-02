using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DepoTakip.Helpers;

namespace DepoTakip.Forms
{
    public partial class UrunEkleForm : Form
    {
        private int currentUserId;

        public UrunEkleForm(int userId)
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
                    string query = "SELECT urun_numarasi FROM urunler";

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

                    // ComboBox'a veri kaynağını bağla
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

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string urunNo = comboUrunNo.Text;
            string miktarText = txtMiktar.Text;

            if (string.IsNullOrEmpty(urunNo) || string.IsNullOrEmpty(miktarText))
            {
                MessageBox.Show("Ürün numarası ve miktar boş olamaz!");
                return;
            }

            if (!int.TryParse(miktarText, out int miktar) || miktar <= 0)
            {
                MessageBox.Show("Geçerli bir miktar giriniz!");
                return;
            }

            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();

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
                        }
                    }

                    if (urunId == 0)
                    {
                        string insertQuery = @"INSERT INTO urunler (urun_numarasi, miktar) 
                                            VALUES (@urunNo, @miktar);
                                            SELECT LAST_INSERT_ID();";

                        using (var insertCmd = new MySqlCommand(insertQuery, connection))
                        {
                            insertCmd.Parameters.AddWithValue("@urunNo", urunNo);
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

                    string historyQuery = @"INSERT INTO islem_gecmisi (urun_id, islem_tipi, miktar, kullanici_id)
                                         VALUES (@urunId, 'ekleme', @miktar, @userId)";

                    using (var historyCmd = new MySqlCommand(historyQuery, connection))
                    {
                        historyCmd.Parameters.AddWithValue("@urunId", urunId);
                        historyCmd.Parameters.AddWithValue("@miktar", miktar);
                        historyCmd.Parameters.AddWithValue("@userId", currentUserId);
                        historyCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Ürün başarıyla eklendi!");
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