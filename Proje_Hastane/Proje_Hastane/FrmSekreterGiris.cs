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
    public partial class FrmSekreterGiris : Form
    {
        public FrmSekreterGiris()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl=new sqlbaglantisi();
        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand cmd= new SqlCommand("select * from Tbl_Sekreter where sekretertc=@p1 and sekretersifre=@p2",bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1",mskTc.Text);
            cmd.Parameters.AddWithValue("@p2",mskSifre.Text);
            SqlDataReader rd=cmd.ExecuteReader();
            if (rd.Read())
            {
                FrmSekreterDetay fr=new FrmSekreterDetay();
                MessageBox.Show("Giriş Başarılı","Sekreter Girişi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                fr.tc = mskTc.Text;
                fr.Show();
                this.Close();
            }else
            {
                MessageBox.Show("Hatalı Giriş!","Sekreter Girişi",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
                bgl.baglanti().Close();
            
        }

        private void mskTc_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
