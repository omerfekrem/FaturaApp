using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class FrmMusteriDetay : Form
    {
        public static Musteri musteri = new Musteri();
        public FrmMusteriDetay()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            musteri.M_Unvan = txtUnvan.Text;
            musteri.M_VergiDairesi = txtVergiDairesi.Text;
            musteri.M_VergiNo = txtVergiNo.Text;
            MusteriDal.EkleGuncele(musteri);

            MessageBox.Show("İstenilen Düzenleme Yapıldı", "Bilgi");
            FrmMusteri frmMusteri = (FrmMusteri)Application.OpenForms["FrmMusteri"];
            frmMusteri.dataGrid_Doldur();
            
            this.Close();
        }

        private void FrmMusteriDetay_Load(object sender, EventArgs e)
        {
            if (musteri.M_ID==0)
            {
                btnEkleGuncelle.Text = "Ekle";

                txtUnvan.Clear();
                txtVergiDairesi.Clear();
                txtVergiNo.Clear();
            }
            else
            {
                btnEkleGuncelle.Text = "Güncelle";

                txtUnvan.Text = musteri.M_Unvan;
                txtVergiDairesi.Text = musteri.M_VergiDairesi;
                txtVergiNo.Text = musteri.M_VergiNo;
            }
        }
    }
}
