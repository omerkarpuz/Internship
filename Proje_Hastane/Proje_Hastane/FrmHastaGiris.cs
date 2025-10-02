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
    public partial class FrmHastaGiris : Form
    {
        public FrmHastaGiris()
        {
            InitializeComponent();
        }

        private void lnkHesapOlustur_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmHastaKayit fr=new FrmHastaKayit();
            fr.Show();
        }
        
        sqlbaglantisi bgl=new sqlbaglantisi();
        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Tbl_Hastalar where hastatc=@p1 and hastasifre=@p2", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1",mskTc.Text);
            cmd.Parameters.AddWithValue("@p2",mskSifre.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read()) 
            {
                FrmHastaDetay frm = new FrmHastaDetay();
                frm.tc = mskTc.Text;
                frm.Show();
                this.Hide();
            } else
            {
                MessageBox.Show("Hatalı giriş.");
            }
            bgl.baglanti().Close();
        }
    }
}
