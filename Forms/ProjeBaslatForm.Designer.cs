namespace DepoTakip.Forms
{
    partial class ProjeBaslatForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtProjeYetkilisi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProjeAdi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProjeKodu = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtExcelDosyaYolu = new System.Windows.Forms.TextBox();
            this.btnExcelYukle = new System.Windows.Forms.Button();
            this.btnOlustur = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Proje Yetkilisi:";

            // txtProjeYetkilisi
            this.txtProjeYetkilisi.Location = new System.Drawing.Point(120, 17);
            this.txtProjeYetkilisi.Name = "txtProjeYetkilisi";
            this.txtProjeYetkilisi.Size = new System.Drawing.Size(250, 23);
            this.txtProjeYetkilisi.TabIndex = 1;

            // label2
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Proje Adı:";

            // txtProjeAdi
            this.txtProjeAdi.Location = new System.Drawing.Point(120, 47);
            this.txtProjeAdi.Name = "txtProjeAdi";
            this.txtProjeAdi.Size = new System.Drawing.Size(250, 23);
            this.txtProjeAdi.TabIndex = 3;

            // label3
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Proje Kodu:";

            // txtProjeKodu
            this.txtProjeKodu.Location = new System.Drawing.Point(120, 77);
            this.txtProjeKodu.Name = "txtProjeKodu";
            this.txtProjeKodu.Size = new System.Drawing.Size(250, 23);
            this.txtProjeKodu.TabIndex = 5;

            // label4
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ürün Listesi (Excel):";

            // txtExcelDosyaYolu
            this.txtExcelDosyaYolu.Location = new System.Drawing.Point(120, 107);
            this.txtExcelDosyaYolu.Name = "txtExcelDosyaYolu";
            this.txtExcelDosyaYolu.ReadOnly = true;
            this.txtExcelDosyaYolu.Size = new System.Drawing.Size(200, 23);
            this.txtExcelDosyaYolu.TabIndex = 7;

            // btnExcelYukle
            this.btnExcelYukle.Location = new System.Drawing.Point(330, 107);
            this.btnExcelYukle.Name = "btnExcelYukle";
            this.btnExcelYukle.Size = new System.Drawing.Size(40, 23);
            this.btnExcelYukle.TabIndex = 8;
            this.btnExcelYukle.Text = "...";
            this.btnExcelYukle.UseVisualStyleBackColor = true;
            this.btnExcelYukle.Click += new System.EventHandler(this.btnExcelYukle_Click);

            // btnOlustur
            this.btnOlustur.Location = new System.Drawing.Point(220, 150);
            this.btnOlustur.Name = "btnOlustur";
            this.btnOlustur.Size = new System.Drawing.Size(75, 30);
            this.btnOlustur.TabIndex = 9;
            this.btnOlustur.Text = "Oluştur";
            this.btnOlustur.UseVisualStyleBackColor = true;
            this.btnOlustur.Click += new System.EventHandler(this.btnOlustur_Click);

            // btnIptal
            this.btnIptal.Location = new System.Drawing.Point(300, 150);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(75, 30);
            this.btnIptal.TabIndex = 10;
            this.btnIptal.Text = "İptal";
            this.btnIptal.UseVisualStyleBackColor = true;
            this.btnIptal.Click += new System.EventHandler((sender, e) => this.Close());

            // ProjeBaslatForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnOlustur);
            this.Controls.Add(this.btnExcelYukle);
            this.Controls.Add(this.txtExcelDosyaYolu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtProjeKodu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtProjeAdi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtProjeYetkilisi);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProjeBaslatForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Yeni Proje Başlat";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProjeYetkilisi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProjeAdi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProjeKodu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtExcelDosyaYolu;
        private System.Windows.Forms.Button btnExcelYukle;
        private System.Windows.Forms.Button btnOlustur;
        private System.Windows.Forms.Button btnIptal;
    }
}