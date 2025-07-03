using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DepoTakip.Forms
{
    public partial class ProjeDetayForm : Form
    {
        private int projeId;

        public ProjeDetayForm(int projeId)
        {
            InitializeComponent();
            this.projeId = projeId;
            this.Text = $"Proje Detayları (ID: {projeId})";
            ProjeDetaylariniYukle();
        }

        private void ProjeDetaylariniYukle()
        {
            string connectionString = "Server=localhost;Database=depo_takip;Uid=root;Pwd=;";
            string query = @"SELECT 
                            pu.id, 
                            u.urun_numarasi, 
                            u.tip_numarasi,
                            u.aciklama,
                            u.uretici,
                            pu.miktar AS projedeki_miktar,
                            u.miktar AS stoktaki_miktar,
                            CASE 
                                WHEN u.miktar >= pu.miktar THEN 'Stokta Var'
                                ELSE 'Stokta Yok'
                            END AS durum
                        FROM proje_urunleri pu
                        JOIN urunler u ON pu.urun_id = u.id
                        WHERE pu.proje_id = @projeId";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@projeId", projeId);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridViewDetay.DataSource = dataTable;

                    // Hücre biçimlendirme olayını ekleyin
                    dataGridViewDetay.CellFormatting += DataGridViewDetay_CellFormatting;
                }
            }
        }

        private void DataGridViewDetay_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Sadece satır hücrelerini işle (başlık satırlarını değil)
            if (e.RowIndex >= 0 && dataGridViewDetay.Columns[e.ColumnIndex].Name == "durum")
            {
                // Durum sütunundaki değeri al
                string durum = dataGridViewDetay.Rows[e.RowIndex].Cells["durum"].Value.ToString();

                if (durum == "Stokta Yok")
                {
                    // Arka plan rengini kırmızı yap
                    e.CellStyle.BackColor = Color.LightCoral;
                    e.CellStyle.ForeColor = Color.DarkRed;
                }
                else
                {
                    // Arka plan rengini yeşil yap
                    e.CellStyle.BackColor = Color.LightGreen;
                    e.CellStyle.ForeColor = Color.DarkGreen;
                }
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}