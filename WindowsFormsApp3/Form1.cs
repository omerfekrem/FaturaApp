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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnMusteri_Click(object sender, EventArgs e)
        {
            FrmMusteri frmMusteri = new FrmMusteri();
            frmMusteri.Show();
        }

        private void btnFaturaListesi_Click(object sender, EventArgs e)
        {
            FrmFaturaListesi frmFaturaListesi = new FrmFaturaListesi();
            frmFaturaListesi.Show();
        }
    }
}
