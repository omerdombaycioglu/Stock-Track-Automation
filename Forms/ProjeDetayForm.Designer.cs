namespace DepoTakip.Forms
{
    partial class ProjeDetayForm
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
            this.lblProjeAdi = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblProjeKodu = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblYetkili = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTarih = new System.Windows.Forms.Label();
            this.dataGridViewUrunler = new System.Windows.Forms.DataGridView();
            this.btnKapat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUrunler)).BeginInit();
            this.SuspendLayout();

            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Proje Adı:";

            // lblProjeAdi
            this.lblProjeAdi.AutoSize = true;
            this.lblProjeAdi.Location = new System.Drawing.Point(120, 20);
            this.lblProjeAdi.Name = "lblProjeAdi";
            this.lblProjeAdi.Size = new System.Drawing.Size(0, 15);
            this.lblProjeAdi.TabIndex = 1;

            // label3
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Proje Kodu:";

            // lblProjeKodu
            this.lblProjeKodu.AutoSize = true;
            this.lblProjeKodu.Location = new System.Drawing.Point(120, 50);
            this.lblProjeKodu.Name = "lblProjeKodu";
            this.lblProjeKodu.Size = new System.Drawing.Size(0, 15);
            this.lblProjeKodu.TabIndex = 3;

            // label5
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Proje Yetkilisi:";

            // lblYetkili
            this.lblYetkili.AutoSize = true;
            this.lblYetkili.Location = new System.Drawing.Point(120, 80);
            this.lblYetkili.Name = "lblYetkili";
            this.lblYetkili.Size = new System.Drawing.Size(0, 15);
            this.lblYetkili.TabIndex = 5;

            // label7
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Oluşturma Tarihi:";

            // lblTarih
            this.lblTarih.AutoSize = true;
            this.lblTarih.Location = new System.Drawing.Point(120, 110);
            this.lblTarih.Name = "lblTarih";
            this.lblTarih.Size = new System.Drawing.Size(0, 15);
            this.lblTarih.TabIndex = 7;

            // dataGridViewUrunler
            this.dataGridViewUrunler.AllowUserToAddRows = false;
            this.dataGridViewUrunler.AllowUserToDeleteRows = false;
            this.dataGridViewUrunler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUrunler.Location = new System.Drawing.Point(20, 140);
            this.dataGridViewUrunler.Name = "dataGridViewUrunler";
            this.dataGridViewUrunler.ReadOnly = true;
            this.dataGridViewUrunler.RowTemplate.Height = 25;
            this.dataGridViewUrunler.Size = new System.Drawing.Size(600, 200);
            this.dataGridViewUrunler.TabIndex = 8;

            // btnKapat
            this.btnKapat.Location = new System.Drawing.Point(535, 350);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(85, 30);
            this.btnKapat.TabIndex = 9;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.UseVisualStyleBackColor = true;
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);

            // ProjeDetayForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 390);
            this.Controls.Add(this.btnKapat);
            this.Controls.Add(this.dataGridViewUrunler);
            this.Controls.Add(this.lblTarih);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblYetkili);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblProjeKodu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblProjeAdi);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProjeDetayForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Proje Detayları";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUrunler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblProjeAdi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblProjeKodu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblYetkili;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTarih;
        private System.Windows.Forms.DataGridView dataGridViewUrunler;
        private System.Windows.Forms.Button btnKapat;
    }
}
