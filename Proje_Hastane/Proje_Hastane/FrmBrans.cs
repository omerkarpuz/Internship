using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proje_Hastane
{
    public partial class FrmBrans : Form
    {
        public FrmBrans()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl=new sqlbaglantisi();

        private void FrmBrans_Load(object sender, EventArgs e)
        {

            DataTable dt=new DataTable();
            SqlDataAdapter da=new SqlDataAdapter("select * from Tbl_Branslar",bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            



        }

        private void brnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd= new SqlCommand("insert into Tbl_Branslar (bransad) values (@b1)",bgl.baglanti());
            cmd.Parameters.AddWithValue("@b1", txtAd.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Branş eklendi!");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtId.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("delete * from Tbl_Branslar where bransid=@b1",bgl.baglanti());
            cmd.Parameters.AddWithValue("@b1",txtId.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt silindi!");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("update Tbl_Branslar set bransad=@b1 where bransid=@b2",bgl.baglanti());
            cmd.Parameters.AddWithValue("@b1",txtAd.Text);
            cmd.Parameters.AddWithValue("@b2", txtId.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt güncellendi!");

        }
    }
}
