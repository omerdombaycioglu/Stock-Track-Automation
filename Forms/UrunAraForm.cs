using DepoTakip.Helpers;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace DepoTakip.Forms
{
    public partial class UrunAraForm : Form
    {
        public UrunAraForm()
        {
            InitializeComponent();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            string aramaKelimesi = txtAramaKelimesi.Text.Trim();

            if (string.IsNullOrEmpty(aramaKelimesi))
            {
                MessageBox.Show("Lütfen arama kriteri giriniz!");
                return;
            }

            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT id, urun_numarasi, tip_numarasi, siparis_numarasi, 
                                   aciklama, uretici, miktar 
                                   FROM urunler 
                                   WHERE urun_numarasi LIKE @aranan OR
                                         tip_numarasi LIKE @aranan OR
                                         siparis_numarasi LIKE @aranan OR
                                         aciklama LIKE @aranan OR
                                         uretici LIKE @aranan";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@aranan", $"%{aramaKelimesi}%");

                        var adapter = new MySqlDataAdapter(cmd);
                        var table = new DataTable();
                        adapter.Fill(table);

                        dataGridViewSonuclar.DataSource = table;
                        dataGridViewSonuclar.Columns["id"].Visible = false;

                        // İşlem geçmişi butonunu ekle
                        if (!dataGridViewSonuclar.Columns.Contains("btnIslemGecmisi"))
                        {
                            DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
                            btnColumn.Name = "btnIslemGecmisi";
                            btnColumn.HeaderText = "İşlemler";
                            btnColumn.Text = "Geçmiş";
                            btnColumn.UseColumnTextForButtonValue = true;
                            dataGridViewSonuclar.Columns.Add(btnColumn);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Arama sırasında hata oluştu: " + ex.Message);
            }
        }

        private void dataGridViewSonuclar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // İşlem geçmişi butonuna tıklanıp tıklanmadığını kontrol et
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridViewSonuclar.Columns["btnIslemGecmisi"].Index)
            {
                int urunId = Convert.ToInt32(dataGridViewSonuclar.Rows[e.RowIndex].Cells["id"].Value);
                string urunNo = dataGridViewSonuclar.Rows[e.RowIndex].Cells["urun_numarasi"].Value.ToString();

                var gecmisForm = new IslemGecmisiForm(urunId, urunNo);
                gecmisForm.ShowDialog();
            }
        }
    }
}