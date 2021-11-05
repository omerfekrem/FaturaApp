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
    public partial class FrmMusteri : Form
    {
        public FrmMusteri()
        {
            InitializeComponent();
        }

        private void FrmMusteri_Load(object sender, EventArgs e)
        {
            dataGrid_Doldur(true);
        }

        public void dataGrid_Doldur(bool ilk=false)
        {
            dataGridView1.DataSource = MusteriDal.KayitlariGetir();

            if (ilk)
            {
                DataGridViewImageColumn stnSil = new DataGridViewImageColumn();
                stnSil.Image = Resource1.icon_delete;
                stnSil.HeaderText = "Sil2";
                stnSil.Name = "Sil2";
                stnSil.Width = 20;


                dataGridView1.Columns.Add(stnSil);
            }
        }

        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = MusteriDal.KayitlariGetir(txtArama.Text);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //int satirNo = dataGridView1.SelectedRows[0].Index;
            //int satirNo = dataGridView1.SelectedCells[0].RowIndex;
            int satirNo = e.RowIndex;
            List<Musteri> musteriler = (List<Musteri>)dataGridView1.DataSource;

            FrmMusteriDetay.musteri = musteriler[satirNo];

            //MessageBox.Show(dataGridView1.SelectedCells[0].ColumnIndex.ToString());
            //MessageBox.Show(e.ColumnIndex.ToString());

            if(e.ColumnIndex==0 || e.ColumnIndex==(dataGridView1.ColumnCount-1))
            {
                if( MessageBox.Show("Kayıt Silinsin Mi?", "Dikkat", MessageBoxButtons.YesNo) ==DialogResult.Yes)
                {
                    MusteriDal.KaydiSil(FrmMusteriDetay.musteri.M_ID);
                    MessageBox.Show("Kayıt Silindi");

                    dataGrid_Doldur();
                }
            }
            else
            {
                FrmMusteriDetay frmMusteriDetay = new FrmMusteriDetay();
                frmMusteriDetay.Show();
            }
        }

        private void btnMusEkle_Click(object sender, EventArgs e)
        {
            FrmMusteriDetay.musteri = new Musteri();

            FrmMusteriDetay frmMusteriDetay = new FrmMusteriDetay();
            frmMusteriDetay.Show();
        }
    }
}
