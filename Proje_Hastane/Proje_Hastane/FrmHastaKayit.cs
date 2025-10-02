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
    public partial class FrmHastaKayit : Form
    {
        public FrmHastaKayit()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        sqlbaglantisi bgl=new sqlbaglantisi();
        private void btnKayit_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into Tbl_Hastalar (hastaad,hastasoyad,hastatc,hastatel,hastasifre,hastacinsiyet) values(@p1,@p2,@p3,@p4,@p5,@p6)",bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1",txtAd.Text);
            cmd.Parameters.AddWithValue("@p2",txtSoyad.Text);
            cmd.Parameters.AddWithValue("@p3", mskTc.Text);
            cmd.Parameters.AddWithValue("@p4", mskTel.Text);
            cmd.Parameters.AddWithValue("@p5", txtSifre.Text);
            cmd.Parameters.AddWithValue("@p6", cmbCinsiyet.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();

            MessageBox.Show("Kaydınız başarıyla oluşturuldu. Şifreniz: " + txtSifre.Text, "Bilgi", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
