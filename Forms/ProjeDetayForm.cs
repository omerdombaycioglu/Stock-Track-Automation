using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DepoTakip.Forms
{
    public partial class ProjeDetayForm : Form
    {
        private int projeId;

        public ProjeDetayForm(int id)
        {
            InitializeComponent();
            projeId = id;
            ProjeDetaylariniYukle();
            ProjeUrunleriniYukle();
        }

        private void ProjeDetaylariniYukle()
        {
            string connectionString = "Server=localhost;Database=depo_takip;Uid=root;Pwd=;";
            string query = @"SELECT p.proje_adi, p.proje_kodu, p.olusturma_tarihi, k.ad_soyad 
                            FROM projeler p 
                            JOIN kullanicilar k ON p.proje_yetkilisi_id = k.id 
                            WHERE p.id = @proje_id";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@proje_id", projeId);
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblProjeAdi.Text = reader["proje_adi"].ToString();
                            lblProjeKodu.Text = reader["proje_kodu"].ToString();
                            lblYetkili.Text = reader["ad_soyad"].ToString();
                            lblTarih.Text = Convert.ToDateTime(reader["olusturma_tarihi"]).ToString("dd.MM.yyyy HH:mm");
                        }
                    }
                }
            }
        }

        private void ProjeUrunleriniYukle()
        {
            string connectionString = "Server=localhost;Database=depo_takip;Uid=root;Pwd=;";
            string query = @"SELECT u.urun_numarasi, u.aciklama, pu.miktar 
                            FROM proje_urunleri pu 
                            JOIN urunler u ON pu.urun_id = u.id 
                            WHERE pu.proje_id = @proje_id";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@proje_id", projeId);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridViewUrunler.DataSource = dataTable;
                }
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}