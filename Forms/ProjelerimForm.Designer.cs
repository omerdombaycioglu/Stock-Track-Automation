namespace DepoTakip.Forms
{
    partial class ProjelerimForm
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
            this.dataGridViewProjeler = new System.Windows.Forms.DataGridView();
            this.btnDetay = new System.Windows.Forms.Button();
            this.btnKapat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProjeler)).BeginInit();
            this.SuspendLayout();

            // dataGridViewProjeler
            this.dataGridViewProjeler.AllowUserToAddRows = false;
            this.dataGridViewProjeler.AllowUserToDeleteRows = false;
            this.dataGridViewProjeler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProjeler.Location = new System.Drawing.Point(20, 20);
            this.dataGridViewProjeler.Name = "dataGridViewProjeler";
            this.dataGridViewProjeler.ReadOnly = true;
            this.dataGridViewProjeler.RowTemplate.Height = 25;
            this.dataGridViewProjeler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProjeler.Size = new System.Drawing.Size(600, 300);
            this.dataGridViewProjeler.TabIndex = 0;

            // btnDetay
            this.btnDetay.Location = new System.Drawing.Point(440, 330);
            this.btnDetay.Name = "btnDetay";
            this.btnDetay.Size = new System.Drawing.Size(85, 30);
            this.btnDetay.TabIndex = 1;
            this.btnDetay.Text = "Detay Göster";
            this.btnDetay.UseVisualStyleBackColor = true;
            this.btnDetay.Click += new System.EventHandler(this.btnDetay_Click);

            // btnKapat
            this.btnKapat.Location = new System.Drawing.Point(535, 330);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(85, 30);
            this.btnKapat.TabIndex = 2;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.UseVisualStyleBackColor = true;
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);

            // ProjelerimForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 370);
            this.Controls.Add(this.btnKapat);
            this.Controls.Add(this.btnDetay);
            this.Controls.Add(this.dataGridViewProjeler);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProjelerimForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Projelerim";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProjeler)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewProjeler;
        private System.Windows.Forms.Button btnDetay;
        private System.Windows.Forms.Button btnKapat;
    }
}