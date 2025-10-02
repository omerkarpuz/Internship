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
    public partial class FrmDoktorGiris : Form
    {
        public FrmDoktorGiris()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl=new sqlbaglantisi();


        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Tbl_Doktorlar where doktortc=@p1 and doktorsifre=@p2",bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1",mskTc.Text);
            cmd.Parameters.AddWithValue("@p2", mskSifre.Text);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd != null || rd.ToString()!="")
            {
                FrmDoktorDetay fr=new FrmDoktorDetay();
                fr.tc=mskTc.Text;
                fr.Show();
                this.Close();
            }else
            {
                MessageBox.Show("Hatalı giriş!");
            }
            bgl.baglanti().Close();




        }
    }
}
