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
using System.Net.Configuration;

namespace Personel_Kayit
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-2T252BE\\MSSQL2022;Initial Catalog=omrstaj_PersonelVeriTabani;Integrated Security=True");

        private void btnGiris_Click(object sender, EventArgs e)
        {
            baglanti.Open();    
            SqlCommand komut = new SqlCommand("select * from Tbl_Yonetici where kullaniciad=@p1 and sifre=@p2",baglanti);
            komut.Parameters.AddWithValue("@p1",txtKullaniciAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader rd = komut.ExecuteReader();
            if (rd.Read())
            {
                FrmAna frm = new FrmAna();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı giriş!");
            }
            baglanti.Close();
        }
    }
}
