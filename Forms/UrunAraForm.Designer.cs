namespace DepoTakip.Forms
{
    partial class UrunAraForm
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
            this.txtAramaKelimesi = new System.Windows.Forms.TextBox();
            this.btnAra = new System.Windows.Forms.Button();
            this.dataGridViewSonuclar = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSonuclar)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAramaKelimesi
            // 
            this.txtAramaKelimesi.Location = new System.Drawing.Point(12, 25);
            this.txtAramaKelimesi.Name = "txtAramaKelimesi";
            this.txtAramaKelimesi.Size = new System.Drawing.Size(260, 20);
            this.txtAramaKelimesi.TabIndex = 0;
            // 
            // btnAra
            // 
            this.btnAra.Location = new System.Drawing.Point(12, 51);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(260, 23);
            this.btnAra.TabIndex = 1;
            this.btnAra.Text = "Ara";
            this.btnAra.UseVisualStyleBackColor = true;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // dataGridViewSonuclar
            // 
            this.dataGridViewSonuclar.AllowUserToAddRows = false;
            this.dataGridViewSonuclar.AllowUserToDeleteRows = false;
            this.dataGridViewSonuclar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSonuclar.Location = new System.Drawing.Point(12, 80);
            this.dataGridViewSonuclar.Name = "dataGridViewSonuclar";
            this.dataGridViewSonuclar.ReadOnly = true;
            this.dataGridViewSonuclar.Size = new System.Drawing.Size(750, 400);
            this.dataGridViewSonuclar.TabIndex = 2;
            this.dataGridViewSonuclar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSonuclar_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Arama Kriteri:";
            // 
            // UrunAraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewSonuclar);
            this.Controls.Add(this.btnAra);
            this.Controls.Add(this.txtAramaKelimesi);
            this.Name = "UrunAraForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ürün Arama";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSonuclar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtAramaKelimesi;
        private System.Windows.Forms.Button btnAra;
        private System.Windows.Forms.DataGridView dataGridViewSonuclar;
        private System.Windows.Forms.Label label1;
    }
}