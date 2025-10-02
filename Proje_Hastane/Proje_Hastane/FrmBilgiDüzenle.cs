using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proje_Hastane
{
    public partial class FrmBilgiDüzenle : Form
    {
        public FrmBilgiDüzenle()
        {
            InitializeComponent();
        }
        public string tcNo;

        sqlbaglantisi bgl=new sqlbaglantisi();

        private void FrmBilgiDüzenle_Load(object sender, EventArgs e)
        {
            mskTc.Text= tcNo;
            SqlCommand cmd = new SqlCommand("select * from Tbl_Hastalar where hastatc=@p1", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1",mskTc.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                txtAd.Text = reader["hastaad"].ToString();
                txtSoyad.Text = reader["hastasoyad"].ToString();
                mskTel.Text = reader["hastatel"].ToString();
                mskSifre.Text = reader["hastasifre"].ToString();
                cmbCinsiyet.Text = reader["hastacinsiyet"].ToString();
            }

            bgl.baglanti().Close();



        }

        private void btnBilgüGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update Tbl_Hastalar set hastaad=@p1,hastasoyad=@p2,hastatel=@p3,hastasifre=@p4,hastacinsiyet=@p5 where hastatc=@p6", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1",txtAd.Text);
            cmd.Parameters.AddWithValue("@p2",txtSoyad.Text);
            cmd.Parameters.AddWithValue("@p3",mskTel.Text);
            cmd.Parameters.AddWithValue("@p4",mskSifre.Text);
            cmd.Parameters.AddWithValue("@p5",cmbCinsiyet.Text);
            cmd.Parameters.AddWithValue("@p6",mskTc.Text);
            cmd.ExecuteNonQuery();

            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Güncellendi!","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.Close();
        }
    }
}
