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
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.lblKullanici = new System.Windows.Forms.Label();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnProjelerim = new System.Windows.Forms.Button();
            this.btnYeniProje = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
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

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.SkyBlue;
            this.pnlHeader.Controls.Add(this.pictureBoxLogo);
            this.pnlHeader.Controls.Add(this.lblKullanici);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(800, 60);
            this.pnlHeader.TabIndex = 0;

            // pictureBoxLogo
            this.pictureBoxLogo.Location = new System.Drawing.Point(10, 5);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(150, 50);
            this.pictureBoxLogo.TabIndex = 1;
            this.pictureBoxLogo.TabStop = false;

            // lblKullanici
            this.lblKullanici.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblKullanici.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblKullanici.ForeColor = System.Drawing.Color.White;
            this.lblKullanici.Location = new System.Drawing.Point(500, 0);
            this.lblKullanici.Name = "lblKullanici";
            this.lblKullanici.Size = new System.Drawing.Size(300, 60);
            this.lblKullanici.TabIndex = 0;
            this.lblKullanici.Text = "Hoşgeldiniz, Kullanıcı";
            this.lblKullanici.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // pnlSidebar
            this.pnlSidebar.BackColor = System.Drawing.Color.LightGray;
            this.pnlSidebar.Controls.Add(this.btnProjelerim);
            this.pnlSidebar.Controls.Add(this.btnYeniProje);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 60);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(180, 440);
            this.pnlSidebar.TabIndex = 1;

            // btnProjelerim
            this.btnProjelerim.Location = new System.Drawing.Point(10, 60);
            this.btnProjelerim.Name = "btnProjelerim";
            this.btnProjelerim.Size = new System.Drawing.Size(160, 40);
            this.btnProjelerim.TabIndex = 1;
            this.btnProjelerim.Text = "Projelerim";
            this.btnProjelerim.UseVisualStyleBackColor = true;
            this.btnProjelerim.Click += new System.EventHandler(this.btnProjelerim_Click);

            // btnYeniProje
            this.btnYeniProje.Location = new System.Drawing.Point(10, 10);
            this.btnYeniProje.Name = "btnYeniProje";
            this.btnYeniProje.Size = new System.Drawing.Size(160, 40);
            this.btnYeniProje.TabIndex = 0;
            this.btnYeniProje.Text = "Yeni Proje Başlat";
            this.btnYeniProje.UseVisualStyleBackColor = true;
            this.btnYeniProje.Click += new System.EventHandler(this.btnYeniProje_Click);

            // pnlMain
            this.pnlMain.Controls.Add(this.btnEnvanterKiyas);
            this.pnlMain.Controls.Add(this.btnExcelYukle);
            this.pnlMain.Controls.Add(this.btnUrunAra);
            this.pnlMain.Controls.Add(this.btnUrunListele);
            this.pnlMain.Controls.Add(this.btnUrunSil);
            this.pnlMain.Controls.Add(this.btnUrunEkle);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(180, 60);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(10);
            this.pnlMain.Size = new System.Drawing.Size(520, 440);
            this.pnlMain.TabIndex = 2;

            // Buttons (all follow same pattern)
            this.btnUrunEkle.Location = new System.Drawing.Point(20, 20);
            this.btnUrunEkle.Name = "btnUrunEkle";
            this.btnUrunEkle.Size = new System.Drawing.Size(200, 40);
            this.btnUrunEkle.TabIndex = 0;
            this.btnUrunEkle.Text = "Ürün Ekle";
            this.btnUrunEkle.UseVisualStyleBackColor = true;
            this.btnUrunEkle.Click += new System.EventHandler(this.btnUrunEkle_Click);

            // Other buttons configured similarly...
            this.btnUrunSil.Location = new System.Drawing.Point(20, 70);
            this.btnUrunSil.Name = "btnUrunSil";
            this.btnUrunSil.Size = new System.Drawing.Size(200, 40);
            this.btnUrunSil.TabIndex = 1;
            this.btnUrunSil.Text = "Ürün Sil";
            this.btnUrunSil.UseVisualStyleBackColor = true;
            this.btnUrunSil.Click += new System.EventHandler(this.btnUrunSil_Click);

            this.btnUrunListele.Location = new System.Drawing.Point(20, 120);
            this.btnUrunListele.Name = "btnUrunListele";
            this.btnUrunListele.Size = new System.Drawing.Size(200, 40);
            this.btnUrunListele.TabIndex = 2;
            this.btnUrunListele.Text = "Ürün Listele";
            this.btnUrunListele.UseVisualStyleBackColor = true;
            this.btnUrunListele.Click += new System.EventHandler(this.btnUrunListele_Click);

            this.btnUrunAra.Location = new System.Drawing.Point(20, 170);
            this.btnUrunAra.Name = "btnUrunAra";
            this.btnUrunAra.Size = new System.Drawing.Size(200, 40);
            this.btnUrunAra.TabIndex = 3;
            this.btnUrunAra.Text = "Ürün Ara";
            this.btnUrunAra.UseVisualStyleBackColor = true;
            this.btnUrunAra.Click += new System.EventHandler(this.btnUrunAra_Click);

            this.btnExcelYukle.Location = new System.Drawing.Point(20, 220);
            this.btnExcelYukle.Name = "btnExcelYukle";
            this.btnExcelYukle.Size = new System.Drawing.Size(200, 40);
            this.btnExcelYukle.TabIndex = 4;
            this.btnExcelYukle.Text = "Excel Yükle";
            this.btnExcelYukle.UseVisualStyleBackColor = true;
            this.btnExcelYukle.Click += new System.EventHandler(this.btnExcelYukle_Click);

            this.btnEnvanterKiyas.Location = new System.Drawing.Point(20, 270);
            this.btnEnvanterKiyas.Name = "btnEnvanterKiyas";
            this.btnEnvanterKiyas.Size = new System.Drawing.Size(200, 40);
            this.btnEnvanterKiyas.TabIndex = 5;
            this.btnEnvanterKiyas.Text = "Envanter Kıyas";
            this.btnEnvanterKiyas.UseVisualStyleBackColor = true;
            this.btnEnvanterKiyas.Click += new System.EventHandler(this.btnEnvanterKiyas_Click);

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 450);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Depo Takip Sistemi";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
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
        private System.Windows.Forms.Button btnYeniProje;
        private System.Windows.Forms.Button btnProjelerim;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnUrunEkle;
        private System.Windows.Forms.Button btnUrunSil;
        private System.Windows.Forms.Button btnUrunListele;
        private System.Windows.Forms.Button btnUrunAra;
        private System.Windows.Forms.Button btnExcelYukle;
        private System.Windows.Forms.Button btnEnvanterKiyas;
    }
}