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
            this.dataGridViewDetay = new System.Windows.Forms.DataGridView();
            this.btnKapat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetay)).BeginInit();
            this.SuspendLayout();

            // dataGridViewDetay
            this.dataGridViewDetay.AllowUserToAddRows = false;
            this.dataGridViewDetay.AllowUserToDeleteRows = false;
            this.dataGridViewDetay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewDetay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDetay.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewDetay.Name = "dataGridViewDetay";
            this.dataGridViewDetay.ReadOnly = true;
            this.dataGridViewDetay.Size = new System.Drawing.Size(760, 400);
            this.dataGridViewDetay.TabIndex = 0;

            // btnKapat
            this.btnKapat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKapat.Location = new System.Drawing.Point(672, 418);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(100, 30);
            this.btnKapat.TabIndex = 1;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.UseVisualStyleBackColor = true;
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);

            // ProjeDetayForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 460);
            this.Controls.Add(this.btnKapat);
            this.Controls.Add(this.dataGridViewDetay);
            this.MinimizeBox = false;
            this.Name = "ProjeDetayForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Proje Detayları";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetay)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewDetay;
        private System.Windows.Forms.Button btnKapat;
    }
}