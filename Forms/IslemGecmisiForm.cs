using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using DepoTakip.Helpers;

namespace DepoTakip.Forms
{
    public partial class IslemGecmisiForm : Form
    {
        private int urunId;
        private string urunNo;

        public IslemGecmisiForm(int id, string no)
        {
            InitializeComponent();
            urunId = id;
            urunNo = no;
            this.Text = $"{urunNo} - İşlem Geçmişi";
            InitializeDataGridView();
            GecmisiYukle();
        }

        private void InitializeDataGridView()
        {
            // DataGridView temel ayarları
            dataGridViewGecmis.AutoGenerateColumns = false;
            dataGridViewGecmis.AllowUserToAddRows = false;
            dataGridViewGecmis.AllowUserToDeleteRows = false;
            dataGridViewGecmis.ReadOnly = true;
            dataGridViewGecmis.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewGecmis.MultiSelect = false;
            dataGridViewGecmis.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewGecmis.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridViewGecmis.RowTemplate.Height = 24;

            // Sütunları elle oluştur
            CreateColumns();
        }

        private void CreateColumns()
        {
            dataGridViewGecmis.Columns.Clear();

            // İşlem Tipi Sütunu
            DataGridViewTextBoxColumn colIslemTipi = new DataGridViewTextBoxColumn();
            colIslemTipi.Name = "colIslemTipi";
            colIslemTipi.HeaderText = "İşlem Tipi";
            colIslemTipi.DataPropertyName = "IslemTipi";
            colIslemTipi.Width = 80;
            dataGridViewGecmis.Columns.Add(colIslemTipi);

            // Miktar Sütunu
            DataGridViewTextBoxColumn colMiktar = new DataGridViewTextBoxColumn();
            colMiktar.Name = "colMiktar";
            colMiktar.HeaderText = "Miktar";
            colMiktar.DataPropertyName = "Miktar";
            colMiktar.Width = 60;
            dataGridViewGecmis.Columns.Add(colMiktar);

            // Açıklama Sütunu
            DataGridViewTextBoxColumn colAciklama = new DataGridViewTextBoxColumn();
            colAciklama.Name = "colAciklama";
            colAciklama.HeaderText = "Açıklama";
            colAciklama.DataPropertyName = "Aciklama";
            colAciklama.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewGecmis.Columns.Add(colAciklama);

            // Tarih Sütunu
            DataGridViewTextBoxColumn colTarih = new DataGridViewTextBoxColumn();
            colTarih.Name = "colTarih";
            colTarih.HeaderText = "Tarih";
            colTarih.DataPropertyName = "Tarih";
            colTarih.Width = 120;
            dataGridViewGecmis.Columns.Add(colTarih);

            // Kullanıcı Sütunu
            DataGridViewTextBoxColumn colKullanici = new DataGridViewTextBoxColumn();
            colKullanici.Name = "colKullanici";
            colKullanici.HeaderText = "Kullanıcı";
            colKullanici.DataPropertyName = "Kullanici";
            colKullanici.Width = 150;
            dataGridViewGecmis.Columns.Add(colKullanici);
        }

        private void GecmisiYukle()
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT 
                                    CASE ig.islem_tipi 
                                        WHEN 'ekleme' THEN 'Ekleme' 
                                        WHEN 'silme' THEN 'Silme' 
                                    END AS IslemTipi,
                                    ig.miktar AS Miktar,
                                    ig.aciklama AS Aciklama,
                                    DATE_FORMAT(ig.islem_tarihi, '%d.%m.%Y %H:%i') AS Tarih,
                                    k.ad_soyad AS Kullanici
                                  FROM islem_gecmisi ig
                                  LEFT JOIN kullanicilar k ON ig.kullanici_id = k.id
                                  WHERE ig.urun_id = @urunId
                                  ORDER BY ig.islem_tarihi DESC";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@urunId", urunId);
                        var adapter = new MySqlDataAdapter(cmd);
                        var table = new DataTable();
                        adapter.Fill(table);

                        dataGridViewGecmis.DataSource = table;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message,
                                "Hata",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void dataGridViewGecmis_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dataGridViewGecmis.Columns["colIslemTipi"].Index)
                return;

            if (e.Value != null)
            {
                string islemTipi = e.Value.ToString();
                if (islemTipi == "Ekleme")
                {
                    e.CellStyle.BackColor = Color.LightGreen;
                    e.CellStyle.ForeColor = Color.DarkGreen;
                }
                else if (islemTipi == "Silme")
                {
                    e.CellStyle.BackColor = Color.LightCoral;
                    e.CellStyle.ForeColor = Color.DarkRed;
                }
            }
        }

        private void IslemGecmisiForm_Load(object sender, EventArgs e)
        {
            // Form yüklendiğinde ek ayarlar
            this.WindowState = FormWindowState.Maximized;
        }
    }
}