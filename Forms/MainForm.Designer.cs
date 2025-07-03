namespace DepoTakip.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnHelp = new System.Windows.Forms.Button();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.lblKullanici = new System.Windows.Forms.Label();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnProjelerim = new System.Windows.Forms.Button();
            this.btnYeniProje = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnSonIslemler = new System.Windows.Forms.Button();
            this.btnEnvanterKiyas = new System.Windows.Forms.Button();
            this.btnExcelYukle = new System.Windows.Forms.Button();
            this.btnUrunAra = new System.Windows.Forms.Button();
            this.btnUrunListele = new System.Windows.Forms.Button();
            this.btnUrunSil = new System.Windows.Forms.Button();
            this.btnUrunEkle = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.pnlSidebar.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(47, 47, 47); // koyu gri ama siyah değil
            this.pnlHeader.Controls.Add(this.btnHelp);
            this.pnlHeader.Controls.Add(this.pictureBoxLogo);
            this.pnlHeader.Controls.Add(this.lblKullanici);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(900, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.BackColor = System.Drawing.Color.Transparent;
            this.btnHelp.FlatAppearance.BorderSize = 0;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnHelp.ForeColor = System.Drawing.Color.LightGray;
            this.btnHelp.Location = new System.Drawing.Point(860, 12);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(30, 35);
            this.btnHelp.TabIndex = 2;
            this.btnHelp.Text = "?";
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            this.btnHelp.MouseEnter += (s, e) => { btnHelp.ForeColor = System.Drawing.Color.White; };
            this.btnHelp.MouseLeave += (s, e) => { btnHelp.ForeColor = System.Drawing.Color.LightGray; };
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Location = new System.Drawing.Point(15, 10);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(130, 40);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 1;
            this.pictureBoxLogo.TabStop = false;
            // 
            // lblKullanici
            // 
            this.lblKullanici.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKullanici.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblKullanici.ForeColor = System.Drawing.Color.LightGray;
            this.lblKullanici.Location = new System.Drawing.Point(600, 20);
            this.lblKullanici.Name = "lblKullanici";
            this.lblKullanici.Size = new System.Drawing.Size(250, 23);
            this.lblKullanici.TabIndex = 0;
            this.lblKullanici.Text = "Hoşgeldiniz, Kullanıcı";
            this.lblKullanici.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(70, 70, 70); // orta koyu gri
            this.pnlSidebar.Controls.Add(this.btnProjelerim);
            this.pnlSidebar.Controls.Add(this.btnYeniProje);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 60);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(180, 490);
            this.pnlSidebar.TabIndex = 1;
            // 
            // btnProjelerim
            // 
            this.btnProjelerim.BackColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.btnProjelerim.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(140, 140, 140);
            this.btnProjelerim.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(160, 160, 160);
            this.btnProjelerim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProjelerim.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnProjelerim.ForeColor = System.Drawing.Color.White;
            this.btnProjelerim.Location = new System.Drawing.Point(20, 75);
            this.btnProjelerim.Name = "btnProjelerim";
            this.btnProjelerim.Size = new System.Drawing.Size(140, 45);
            this.btnProjelerim.TabIndex = 1;
            this.btnProjelerim.Text = "Projelerim";
            this.btnProjelerim.UseVisualStyleBackColor = false;
            this.btnProjelerim.Click += new System.EventHandler(this.btnProjelerim_Click);
            // 
            // btnYeniProje
            // 
            this.btnYeniProje.BackColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.btnYeniProje.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(140, 140, 140);
            this.btnYeniProje.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(160, 160, 160);
            this.btnYeniProje.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYeniProje.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnYeniProje.ForeColor = System.Drawing.Color.White;
            this.btnYeniProje.Location = new System.Drawing.Point(20, 15);
            this.btnYeniProje.Name = "btnYeniProje";
            this.btnYeniProje.Size = new System.Drawing.Size(140, 45);
            this.btnYeniProje.TabIndex = 0;
            this.btnYeniProje.Text = "Yeni Proje Başlat";
            this.btnYeniProje.UseVisualStyleBackColor = false;
            this.btnYeniProje.Click += new System.EventHandler(this.btnYeniProje_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(47, 47, 47);
            this.pnlMain.Controls.Add(this.btnSonIslemler);
            this.pnlMain.Controls.Add(this.btnEnvanterKiyas);
            this.pnlMain.Controls.Add(this.btnExcelYukle);
            this.pnlMain.Controls.Add(this.btnUrunAra);
            this.pnlMain.Controls.Add(this.btnUrunListele);
            this.pnlMain.Controls.Add(this.btnUrunSil);
            this.pnlMain.Controls.Add(this.btnUrunEkle);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(180, 60);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(20);
            this.pnlMain.Size = new System.Drawing.Size(720, 490);
            this.pnlMain.TabIndex = 2;
            // 
            // btnSonIslemler
            // 
            this.btnSonIslemler.BackColor = System.Drawing.Color.FromArgb(120, 120, 120);
            this.btnSonIslemler.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(160, 160, 160);
            this.btnSonIslemler.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(190, 190, 190);
            this.btnSonIslemler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSonIslemler.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSonIslemler.ForeColor = System.Drawing.Color.White;
            this.btnSonIslemler.Location = new System.Drawing.Point(400, 370);
            this.btnSonIslemler.Margin = new System.Windows.Forms.Padding(10);
            this.btnSonIslemler.Name = "btnSonIslemler";
            this.btnSonIslemler.Size = new System.Drawing.Size(280, 50);
            this.btnSonIslemler.TabIndex = 6;
            this.btnSonIslemler.Text = "Son İşlemler";
            this.btnSonIslemler.UseVisualStyleBackColor = false;
            this.btnSonIslemler.Click += new System.EventHandler(this.btnSonIslemler_Click);
            // 
            // btnEnvanterKiyas
            // 
            this.btnEnvanterKiyas.BackColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.btnEnvanterKiyas.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(140, 140, 140);
            this.btnEnvanterKiyas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(160, 160, 160);
            this.btnEnvanterKiyas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnvanterKiyas.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnEnvanterKiyas.ForeColor = System.Drawing.Color.White;
            this.btnEnvanterKiyas.Location = new System.Drawing.Point(20, 300);
            this.btnEnvanterKiyas.Margin = new System.Windows.Forms.Padding(10);
            this.btnEnvanterKiyas.Name = "btnEnvanterKiyas";
            this.btnEnvanterKiyas.Size = new System.Drawing.Size(300, 50);
            this.btnEnvanterKiyas.TabIndex = 5;
            this.btnEnvanterKiyas.Text = "Envanter Kıyas";
            this.btnEnvanterKiyas.UseVisualStyleBackColor = false;
            this.btnEnvanterKiyas.Click += new System.EventHandler(this.btnEnvanterKiyas_Click);
            // 
            // btnExcelYukle
            // 
            this.btnExcelYukle.BackColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.btnExcelYukle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(140, 140, 140);
            this.btnExcelYukle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(160, 160, 160);
            this.btnExcelYukle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcelYukle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnExcelYukle.ForeColor = System.Drawing.Color.White;
            this.btnExcelYukle.Location = new System.Drawing.Point(20, 240);
            this.btnExcelYukle.Margin = new System.Windows.Forms.Padding(10);
            this.btnExcelYukle.Name = "btnExcelYukle";
            this.btnExcelYukle.Size = new System.Drawing.Size(300, 50);
            this.btnExcelYukle.TabIndex = 4;
            this.btnExcelYukle.Text = "Excel ile Ürün Ekle/Sil";
            this.btnExcelYukle.UseVisualStyleBackColor = false;
            this.btnExcelYukle.Click += new System.EventHandler(this.btnExcelYukle_Click);
            // 
            // btnUrunAra
            // 
            this.btnUrunAra.BackColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.btnUrunAra.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(140, 140, 140);
            this.btnUrunAra.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(160, 160, 160);
            this.btnUrunAra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUrunAra.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnUrunAra.ForeColor = System.Drawing.Color.White;
            this.btnUrunAra.Location = new System.Drawing.Point(20, 180);
            this.btnUrunAra.Margin = new System.Windows.Forms.Padding(10);
            this.btnUrunAra.Name = "btnUrunAra";
            this.btnUrunAra.Size = new System.Drawing.Size(300, 50);
            this.btnUrunAra.TabIndex = 3;
            this.btnUrunAra.Text = "Ürün Ara";
            this.btnUrunAra.UseVisualStyleBackColor = false;
            this.btnUrunAra.Click += new System.EventHandler(this.btnUrunAra_Click);
            // 
            // btnUrunListele
            // 
            this.btnUrunListele.BackColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.btnUrunListele.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(140, 140, 140);
            this.btnUrunListele.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(160, 160, 160);
            this.btnUrunListele.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUrunListele.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnUrunListele.ForeColor = System.Drawing.Color.White;
            this.btnUrunListele.Location = new System.Drawing.Point(20, 120);
            this.btnUrunListele.Margin = new System.Windows.Forms.Padding(10);
            this.btnUrunListele.Name = "btnUrunListele";
            this.btnUrunListele.Size = new System.Drawing.Size(300, 50);
            this.btnUrunListele.TabIndex = 2;
            this.btnUrunListele.Text = "Ürün Listele";
            this.btnUrunListele.UseVisualStyleBackColor = false;
            this.btnUrunListele.Click += new System.EventHandler(this.btnUrunListele_Click);
            // 
            // btnUrunSil
            // 
            this.btnUrunSil.BackColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.btnUrunSil.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(140, 140, 140);
            this.btnUrunSil.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(160, 160, 160);
            this.btnUrunSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUrunSil.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnUrunSil.ForeColor = System.Drawing.Color.White;
            this.btnUrunSil.Location = new System.Drawing.Point(380, 120);
            this.btnUrunSil.Margin = new System.Windows.Forms.Padding(10);
            this.btnUrunSil.Name = "btnUrunSil";
            this.btnUrunSil.Size = new System.Drawing.Size(300, 50);
            this.btnUrunSil.TabIndex = 1;
            this.btnUrunSil.Text = "Ürün Sil";
            this.btnUrunSil.UseVisualStyleBackColor = false;
            this.btnUrunSil.Click += new System.EventHandler(this.btnUrunSil_Click);
            // 
            // btnUrunEkle
            // 
            this.btnUrunEkle.BackColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.btnUrunEkle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(140, 140, 140);
            this.btnUrunEkle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(160, 160, 160);
            this.btnUrunEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUrunEkle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnUrunEkle.ForeColor = System.Drawing.Color.White;
            this.btnUrunEkle.Location = new System.Drawing.Point(380, 60);
            this.btnUrunEkle.Margin = new System.Windows.Forms.Padding(10);
            this.btnUrunEkle.Name = "btnUrunEkle";
            this.btnUrunEkle.Size = new System.Drawing.Size(300, 50);
            this.btnUrunEkle.TabIndex = 0;
            this.btnUrunEkle.Text = "Ürün Ekle";
            this.btnUrunEkle.UseVisualStyleBackColor = false;
            this.btnUrunEkle.Click += new System.EventHandler(this.btnUrunEkle_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(47, 47, 47);
            this.ClientSize = new System.Drawing.Size(900, 550);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "Depo Takip";
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.pnlSidebar.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label lblKullanici;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Button btnProjelerim;
        private System.Windows.Forms.Button btnYeniProje;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnSonIslemler;
        private System.Windows.Forms.Button btnEnvanterKiyas;
        private System.Windows.Forms.Button btnExcelYukle;
        private System.Windows.Forms.Button btnUrunAra;
        private System.Windows.Forms.Button btnUrunListele;
        private System.Windows.Forms.Button btnUrunSil;
        private System.Windows.Forms.Button btnUrunEkle;
        private System.Windows.Forms.Button btnHelp;
    }
}
