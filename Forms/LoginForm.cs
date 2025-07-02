using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;
using DepoTakip.Helpers;

namespace DepoTakip.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            LoadLogo();
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
                else
                {
                    MessageBox.Show("Logo dosyası bulunamadı: " + logoPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Logo yüklenirken hata oluştu: " + ex.Message);
            }
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string username = txtKullaniciAdi.Text;
            string password = txtSifre.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Kullanıcı adı ve şifre boş olamaz!");
                return;
            }

            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT id, ad_soyad, yetki_seviyesi FROM kullanicilar WHERE kullanici_adi=@username AND sifre=SHA2(@password, 256)";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int userId = reader.GetInt32("id");
                                string fullName = reader.GetString("ad_soyad");
                                int yetkiSeviyesi = reader.GetInt32("yetki_seviyesi");

                                this.Hide();
                                var mainForm = new MainForm(userId, fullName, yetkiSeviyesi);
                                mainForm.Show();
                            }
                            else
                            {
                                MessageBox.Show("Geçersiz kullanıcı adı veya şifre!");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bağlantı hatası: " + ex.Message);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Form yüklendiğinde yapılacak işlemler
        }

        private void pictureBoxLogo_Click(object sender, EventArgs e)
        {
            // Logo tıklama işlemleri
        }

        private void txtSifre_TextChanged(object sender, EventArgs e)
        {
            // Şifre değiştiğinde yapılacak işlemler
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}