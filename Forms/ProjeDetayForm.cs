using System;
using System.Data;
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
                }
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}