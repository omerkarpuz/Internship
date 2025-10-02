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
    public partial class FrmDoktorBilgiDuzenle : Form
    {
        public FrmDoktorBilgiDuzenle()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl=new sqlbaglantisi();
        public string tcdoktor;

        private void FrmDoktorBilgiDuzenle_Load(object sender, EventArgs e)
        {
            mskTc.Text = tcdoktor;

            SqlCommand cmd = new SqlCommand("select * from Tbl_Doktorlar where doktortc=@p1",bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", mskTc.Text);
            SqlDataReader dr = cmd.ExecuteReader(); 
            while (dr.Read())
            {
                txtAd.Text = dr["doktorad"].ToString();
                txtSoyad.Text = dr["doktorsoyad"].ToString();
                cmbBrans.Text= dr["doktorbrans"].ToString() ;
                mskSifre.Text = dr["doktorsifre"].ToString();
            }bgl.baglanti().Close();


        }

        private void btnBilgüGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update Tbl_Doktorlar set doktorad=@p1,doktorsoyad=@p2,doktorsifre=@p3,doktorbrans=@p4 where doktortc=@p5 ",bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1",txtAd.Text);
            cmd.Parameters.AddWithValue("@p2", txtSoyad.Text);
            cmd.Parameters.AddWithValue("@p3",mskSifre.Text);
            cmd.Parameters.AddWithValue("@p4", cmbBrans.Text);
            cmd.Parameters.AddWithValue("@p5", mskTc.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Güncelleme başarılı");

        }
    }
}
