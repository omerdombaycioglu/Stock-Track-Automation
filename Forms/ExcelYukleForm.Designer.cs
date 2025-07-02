namespace DepoTakip.Forms
{
    partial class ExcelYukleForm
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

        private void InitializeComponent()
        {
            this.txtDosyaYolu = new System.Windows.Forms.TextBox();
            this.btnDosyaSec = new System.Windows.Forms.Button();
            this.dataGridViewExcel = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioSil = new System.Windows.Forms.RadioButton();
            this.radioEkle = new System.Windows.Forms.RadioButton();
            this.btnIslemYap = new System.Windows.Forms.Button();
            this.lblKayitSayisi = new System.Windows.Forms.Label();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExcel)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();

            // txtDosyaYolu
            this.txtDosyaYolu.Location = new System.Drawing.Point(16, 15);
            this.txtDosyaYolu.Margin = new System.Windows.Forms.Padding(4);
            this.txtDosyaYolu.Name = "txtDosyaYolu";
            this.txtDosyaYolu.ReadOnly = true;
            this.txtDosyaYolu.Size = new System.Drawing.Size(532, 22);
            this.txtDosyaYolu.TabIndex = 0;

            // btnDosyaSec
            this.btnDosyaSec.Location = new System.Drawing.Point(557, 12);
            this.btnDosyaSec.Margin = new System.Windows.Forms.Padding(4);
            this.btnDosyaSec.Name = "btnDosyaSec";
            this.btnDosyaSec.Size = new System.Drawing.Size(100, 28);
            this.btnDosyaSec.TabIndex = 1;
            this.btnDosyaSec.Text = "Dosya Seç";
            this.btnDosyaSec.UseVisualStyleBackColor = true;
            this.btnDosyaSec.Click += new System.EventHandler(this.btnDosyaSec_Click);

            // dataGridViewExcel
            this.dataGridViewExcel.AllowUserToAddRows = false;
            this.dataGridViewExcel.AllowUserToDeleteRows = false;
            this.dataGridViewExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExcel.Location = new System.Drawing.Point(16, 47);
            this.dataGridViewExcel.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewExcel.Name = "dataGridViewExcel";
            this.dataGridViewExcel.ReadOnly = true;
            this.dataGridViewExcel.RowHeadersWidth = 51;
            this.dataGridViewExcel.Size = new System.Drawing.Size(880, 369);
            this.dataGridViewExcel.TabIndex = 2;

            // groupBox1
            this.groupBox1.Controls.Add(this.radioSil);
            this.groupBox1.Controls.Add(this.radioEkle);
            this.groupBox1.Location = new System.Drawing.Point(16, 423);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(400, 62);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "İşlem Türü";

            // radioSil
            this.radioSil.AutoSize = true;
            this.radioSil.Location = new System.Drawing.Point(200, 25);
            this.radioSil.Margin = new System.Windows.Forms.Padding(4);
            this.radioSil.Name = "radioSil";
            this.radioSil.Size = new System.Drawing.Size(171, 20);
            this.radioSil.TabIndex = 1;
            this.radioSil.Text = "İlgili ürünleri depodan sil";
            this.radioSil.UseVisualStyleBackColor = true;

            // radioEkle
            this.radioEkle.AutoSize = true;
            this.radioEkle.Checked = true;
            this.radioEkle.Location = new System.Drawing.Point(13, 25);
            this.radioEkle.Margin = new System.Windows.Forms.Padding(4);
            this.radioEkle.Name = "radioEkle";
            this.radioEkle.Size = new System.Drawing.Size(176, 20);
            this.radioEkle.TabIndex = 0;
            this.radioEkle.TabStop = true;
            this.radioEkle.Text = "İlgili ürünleri depoya ekle";
            this.radioEkle.UseVisualStyleBackColor = true;

            // btnIslemYap
            this.btnIslemYap.Location = new System.Drawing.Point(440, 431);
            this.btnIslemYap.Margin = new System.Windows.Forms.Padding(4);
            this.btnIslemYap.Name = "btnIslemYap";
            this.btnIslemYap.Size = new System.Drawing.Size(200, 49);
            this.btnIslemYap.TabIndex = 4;
            this.btnIslemYap.Text = "İşlemi Gerçekleştir";
            this.btnIslemYap.UseVisualStyleBackColor = true;
            this.btnIslemYap.Click += new System.EventHandler(this.btnIslemYap_Click);

            // lblKayitSayisi
            this.lblKayitSayisi.AutoSize = true;
            this.lblKayitSayisi.Location = new System.Drawing.Point(667, 431);
            this.lblKayitSayisi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblKayitSayisi.Name = "lblKayitSayisi";
            this.lblKayitSayisi.Size = new System.Drawing.Size(0, 16);
            this.lblKayitSayisi.TabIndex = 5;

            // txtAciklama
            this.txtAciklama.Location = new System.Drawing.Point(16, 493);
            this.txtAciklama.Margin = new System.Windows.Forms.Padding(4);
            this.txtAciklama.Multiline = true;
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(880, 60);
            this.txtAciklama.TabIndex = 6;

            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 473);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Silme Açıklaması:";

            // ExcelYukleForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 570);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAciklama);
            this.Controls.Add(this.lblKayitSayisi);
            this.Controls.Add(this.btnIslemYap);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridViewExcel);
            this.Controls.Add(this.btnDosyaSec);
            this.Controls.Add(this.txtDosyaYolu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExcelYukleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Excel'den Ürün Yükleme";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExcel)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtDosyaYolu;
        private System.Windows.Forms.Button btnDosyaSec;
        private System.Windows.Forms.DataGridView dataGridViewExcel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioSil;
        private System.Windows.Forms.RadioButton radioEkle;
        private System.Windows.Forms.Button btnIslemYap;
        private System.Windows.Forms.Label lblKayitSayisi;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.Label label1;
    }
}