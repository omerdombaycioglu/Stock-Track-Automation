using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DepoTakip.Forms
{
    public partial class ProjelerimForm : Form
    {
        private int currentUserId;

        public ProjelerimForm(int userId)
        {
            InitializeComponent();
            currentUserId = userId;
            ProjeleriYukle();
        }

        private void ProjeleriYukle()
        {
            string connectionString = "Server=localhost;Database=depo_takip;Uid=root;Pwd=;";
            string query = @"SELECT p.id, p.proje_adi, p.proje_kodu, p.olusturma_tarihi, 
                           (SELECT COUNT(*) FROM proje_urunleri pu WHERE pu.proje_id = p.id) AS urun_sayisi
                           FROM projeler p 
                           WHERE p.proje_yetkilisi_id = @yetkili_id 
                           ORDER BY p.olusturma_tarihi DESC";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@yetkili_id", currentUserId);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridViewProjeler.DataSource = dataTable;
                }
            }
        }

        private void btnDetay_Click(object sender, EventArgs e)
        {
            if (dataGridViewProjeler.SelectedRows.Count > 0)
            {
                int projeId = Convert.ToInt32(dataGridViewProjeler.SelectedRows[0].Cells["id"].Value);
                var projeDetayForm = new ProjeDetayForm(projeId);
                projeDetayForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Lütfen bir proje seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}