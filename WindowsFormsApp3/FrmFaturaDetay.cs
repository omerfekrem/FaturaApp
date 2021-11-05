using System;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class FrmFaturaDetay : Form
    {
        public int F_ID = 0;
        public FrmFaturaDetay()
        {
            InitializeComponent();
        }
        Fatura fatura;
        private void FrmFaturaDetay_Load(object sender, EventArgs e)
        {
            fatura = FaturaDal.FaturayiGetir(F_ID);

            txtF_Tarih.Text = fatura.F_Tarih.ToString("dd/MM/yyyy");
            lblToplamTutar.Text = fatura.ToplamTutar.ToString();

            cBoxMusteri.DataSource = MusteriDal.KayitlariGetir();
            cBoxMusteri.DisplayMember = "M_Unvan";
            cBoxMusteri.ValueMember = "M_ID";
            cBoxMusteri.SelectedValue = fatura.F_M_ID;

            dataGridView1.DataSource = fatura.kalems;

            DataGridViewComboBoxColumn boxColumn = new DataGridViewComboBoxColumn();
            boxColumn.Name = "U_Adi";
            boxColumn.DataSource = UrunDal.KalemleriGetir();
            boxColumn.DisplayMember = "U_Adi";
            boxColumn.ValueMember = "U_ID";
            boxColumn.DataPropertyName = "K_U_ID";

            dataGridView1.Columns.Add(boxColumn);

            dataGridView1.Columns["K_F_ID"].Visible = false;
            dataGridView1.Columns["K_U_ID"].Visible = false;
            dataGridView1.Columns["U_Adi"].DisplayIndex = 1;
            dataGridView1.Columns["U_Adi"].Width = 250;

        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if(e.Control is ComboBox)
            {
                ComboBox comboBox = e.Control as ComboBox;
                comboBox.SelectedIndexChanged -= u_adi_cBox_SelectedIndexChanged;
                comboBox.SelectedIndexChanged += u_adi_cBox_SelectedIndexChanged;
            }
        }

        private void u_adi_cBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            MessageBox.Show(comboBox.SelectedValue.ToString());
        }
    }
}
