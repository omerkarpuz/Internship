using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje_Hastane
{
    public partial class FrmDataSetDeneme : Form
    {
        public FrmDataSetDeneme()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        DataSet1TableAdapters.Tbl_DoktorlarTableAdapter ds = new DataSet1TableAdapters.Tbl_DoktorlarTableAdapter();

        public void secim(DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void FrmDataSetDeneme_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DoktorListesi();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ds.DoktorAdGuncelle(textBox1.Text,byte.Parse(id));
        }

        private void btnListe_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DoktorListesi();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            ds.DoktorEkle(txtAd.Text,txtSoyad.Text,txtBrans.Text,txtTc.Text,txtSifre.Text);
        }
        string id;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            secim(e);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            ds.DoktorSil(byte.Parse(id));
        }
    }
}
