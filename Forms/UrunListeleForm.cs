using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using DepoTakip.Helpers;

namespace DepoTakip.Forms
{
    public partial class UrunListeleForm : Form
    {
        public UrunListeleForm()
        {
            InitializeComponent();
            UrunleriYukle();
        }

        private void UrunleriYukle()
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT id, urun_numarasi, tip_numarasi, siparis_numarasi, aciklama, uretici, miktar FROM urunler";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        var adapter = new MySqlDataAdapter(cmd);
                        var table = new DataTable();
                        adapter.Fill(table);

                        dataGridViewUrunler.DataSource = table;
                        dataGridViewUrunler.Columns["id"].Visible = false;

                        // İşlem geçmişi butonunu ekle
                        if (!dataGridViewUrunler.Columns.Contains("btnIslemGecmisi"))
                        {
                            DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
                            btnColumn.Name = "btnIslemGecmisi";
                            btnColumn.HeaderText = "İşlemler";
                            btnColumn.Text = "Geçmiş";
                            btnColumn.UseColumnTextForButtonValue = true;
                            dataGridViewUrunler.Columns.Add(btnColumn);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }

        private void dataGridViewUrunler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridViewUrunler.Columns["btnIslemGecmisi"].Index)
            {
                int urunId = Convert.ToInt32(dataGridViewUrunler.Rows[e.RowIndex].Cells["id"].Value);
                string urunNo = dataGridViewUrunler.Rows[e.RowIndex].Cells["urun_numarasi"].Value.ToString();

                var gecmisForm = new IslemGecmisiForm(urunId, urunNo);
                gecmisForm.ShowDialog();
            }
        }
    }
}