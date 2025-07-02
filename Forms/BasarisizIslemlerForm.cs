using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DepoTakip.Forms
{
    public partial class BasarisizIslemlerForm : Form
    {
        public BasarisizIslemlerForm(List<string> basarisizIslemler)
        {
            InitializeComponent();
            ListeyiDoldur(basarisizIslemler);
        }

        private void ListeyiDoldur(List<string> basarisizIslemler)
        {
            listBoxBasarisizIslemler.Items.Clear();

            if (basarisizIslemler != null && basarisizIslemler.Count > 0)
            {
                foreach (var hata in basarisizIslemler)
                {
                    listBoxBasarisizIslemler.Items.Add(hata);
                }
            }
            else
            {
                listBoxBasarisizIslemler.Items.Add("Başarısız işlem bulunamadı.");
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBoxBasarisizIslemler_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}