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
    public partial class FrmFaturaListesi : Form
    {
        public FrmFaturaListesi()
        {
            InitializeComponent();
        }

        private void FrmFaturaListesi_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = FaturaListesiDal.KayitlariGetir();
        }

        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = FaturaListesiDal.KayitlariGetir(txtArama.Text);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==0)
            {
                FrmFaturaDetay frmFaturaDetay = new FrmFaturaDetay();
                frmFaturaDetay.F_ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["F_ID"].Value.ToString());
                frmFaturaDetay.Show();
            }
        }
    }
}
