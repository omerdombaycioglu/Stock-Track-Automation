namespace DepoTakip.Forms
{
    partial class IslemGecmisiForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewGecmis = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGecmis)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewGecmis
            // 
            this.dataGridViewGecmis.AllowUserToAddRows = false;
            this.dataGridViewGecmis.AllowUserToDeleteRows = false;
            this.dataGridViewGecmis.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewGecmis.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewGecmis.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewGecmis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGecmis.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewGecmis.Name = "dataGridViewGecmis";
            this.dataGridViewGecmis.ReadOnly = true;
            this.dataGridViewGecmis.RowHeadersVisible = false;
            this.dataGridViewGecmis.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewGecmis.Size = new System.Drawing.Size(960, 537);
            this.dataGridViewGecmis.TabIndex = 0;
            this.dataGridViewGecmis.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewGecmis_CellFormatting);
            // 
            // IslemGecmisiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.dataGridViewGecmis);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "IslemGecmisiForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "İşlem Geçmişi";
            this.Load += new System.EventHandler(this.IslemGecmisiForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGecmis)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewGecmis;
    }
}