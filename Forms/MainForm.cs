using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;

namespace DepoTakip.Forms
{
    public partial class MainForm : Form
    {
        private readonly int _userId;
        private readonly string _fullName;
        private readonly int _yetkiSeviyesi;

        public MainForm(int userId, string fullName, int yetkiSeviyesi)
        {
            InitializeComponent();
            _userId = userId;
            _fullName = fullName;
            _yetkiSeviyesi = yetkiSeviyesi;

            InitializeUI();
            LoadLogo();
            SetPermissions();
        }

        private void InitializeUI()
        {
            lblKullanici.Text = $"Hoşgeldiniz, {_fullName}";
            this.Text = $"Depo Takip Sistemi - {_fullName}";
        }

        private void LoadLogo()
        {
            try
            {
                string logoPath = @"C:\Users\omerd\OneDrive\Masaüstü\isp_logo.png";
                if (System.IO.File.Exists(logoPath))
                {
                    pictureBoxLogo.Image = Image.FromFile(logoPath);
                    pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Logo yüklenirken hata oluştu: {ex.Message}");
            }
        }

        private void SetPermissions()
        {
            btnYeniProje.Enabled = _yetkiSeviyesi >= 2;
            btnProjelerim.Enabled = _yetkiSeviyesi >= 2;
        }

        private void OpenForm(Form form) => form.ShowDialog();

        // Button click events
        private void btnUrunEkle_Click(object sender, EventArgs e) => OpenForm(new UrunEkleForm(_userId));
        private void btnUrunSil_Click(object sender, EventArgs e) => OpenForm(new UrunSilForm(_userId));
        private void btnUrunListele_Click(object sender, EventArgs e) => OpenForm(new UrunListeleForm());
        private void btnUrunAra_Click(object sender, EventArgs e) => OpenForm(new UrunAraForm());
        private void btnExcelYukle_Click(object sender, EventArgs e) => OpenForm(new ExcelYukleForm(_userId));
        private void btnEnvanterKiyas_Click(object sender, EventArgs e) => OpenForm(new EnvanterKiyasForm());
        private void btnYeniProje_Click(object sender, EventArgs e) => OpenForm(new ProjeBaslatForm(_userId, _fullName));
        private void btnProjelerim_Click(object sender, EventArgs e) => OpenForm(new ProjelerimForm(_userId));
        private void btnSonIslemler_Click(object sender, EventArgs e) => OpenForm(new SonIslemlerForm());

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string helpMessage = @"Excel ile Ürün Ekle/Sil özelliği kullanılırken:
    
- Excel dosyasında ürünler 7.satırdan itibaren başlamalıdır
- Sütunlar sırasıyla şu şekilde olmalıdır:
  1. Tip numarası
  2. Sipariş numarası
  3. Açıklama
  4. Ürün numarası
  5. Üretici
  6. Miktar

Örnek bir Excel şablonu için yöneticinize başvurun.";

            MessageBox.Show(helpMessage, "Excel İçin Yardım", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e) => Application.Exit();
    }

    public class SonIslemlerForm : Form
    {
        private DataGridView dataGridView;

        public SonIslemlerForm()
        {
            InitializeComponent();
            LoadSonIslemler();
        }

        private void InitializeComponent()
        {
            this.Text = "Son İşlemler";
            this.Size = new Size(800, 500);
            this.StartPosition = FormStartPosition.CenterParent;

            dataGridView = new DataGridView
            {
                Dock = DockStyle.Fill,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowHeadersVisible = false
            };
            this.Controls.Add(dataGridView);

            var btnKapat = new Button
            {
                Text = "Kapat",
                Dock = DockStyle.Bottom,
                Height = 40
            };
            btnKapat.Click += (s, e) => this.Close();
            this.Controls.Add(btnKapat);
        }

        private void LoadSonIslemler()
        {
            string connectionString = "Server=localhost;Database=depo_takip;Uid=root;Pwd=;";
            string query = @"SELECT 
                        u.urun_numarasi AS 'Ürün No',
                        u.aciklama AS 'Ürün Açıklama',
                        CASE 
                            WHEN ig.islem_tipi = 'ekleme' THEN 'Ekleme'
                            WHEN ig.islem_tipi = 'silme' THEN 'Silme'
                            ELSE ig.islem_tipi
                        END AS 'İşlem Tipi',
                        ig.miktar AS 'Miktar',
                        ig.aciklama AS 'Açıklama',
                        DATE_FORMAT(ig.islem_tarihi, '%d.%m.%Y %H:%i') AS 'Tarih',
                        k.ad_soyad AS 'Kullanıcı'
                    FROM islem_gecmisi ig
                    JOIN urunler u ON ig.urun_id = u.id
                    JOIN kullanicilar k ON ig.kullanici_id = k.id
                    ORDER BY ig.islem_tarihi DESC
                    LIMIT 100";

            using (var connection = new MySqlConnection(connectionString))
            {
                var adapter = new MySqlDataAdapter(query, connection);
                var table = new DataTable();
                adapter.Fill(table);
                dataGridView.DataSource = table;

                // Sütun başlıklarını Türkçe yapalım
                if (dataGridView.Columns.Contains("islem_tipi"))
                {
                    dataGridView.Columns["islem_tipi"].HeaderText = "İşlem Tipi";
                }
            }
        }
    }
}