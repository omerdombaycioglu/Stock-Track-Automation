using System;
using System.Drawing;
using System.Windows.Forms;

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

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e) => Application.Exit();
    }
}