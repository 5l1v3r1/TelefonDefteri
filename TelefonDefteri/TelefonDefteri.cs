using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TelefonDefteri.Models;

namespace TelefonDefteri
{
    public partial class TelefonDefteri : Form
    {
        public TelefonDefteri()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TelefonDefteriEntities db = new TelefonDefteriEntities();
            
            Kisiler ks = new Kisiler();
            ks.Ad = txtAd.Text;
            ks.Soyad = txtSoyad.Text;
            ks.Telefon = txtTelefon.Text;
            db.Kisilers.Add(ks);
            db.SaveChanges();

            txtAd.Text = "";
            txtSoyad.Text = "";
            txtTelefon.Text = "";
            MessageBox.Show("Kayıt Başarıyla Eklendi");
            Doldur();

        }

        void Doldur()
        {
            TelefonDefteriEntities db = new TelefonDefteriEntities();

            lstKisiler.DataSource = db.Kisilers.ToList();
            //lstKisiler.DisplayMember = "Ad + Soyad";
 
        }

        private void TelefonDefteri_Load(object sender, EventArgs e)
        {
            Doldur();
        }
    }
}
