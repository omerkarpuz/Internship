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

namespace Personel_Kayit
{
    public partial class Frmistatistik : Form
    {
        public Frmistatistik()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-2T252BE\\MSSQL2022;Initial Catalog=omrstaj_PersonelVeriTabani;Integrated Security=True");

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Frmistatistik_Load(object sender, EventArgs e)
        {
            //toplam personel sayısı
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select count(*) from Tbl_Personel",baglanti);
            SqlDataReader dr1=komut1.ExecuteReader();
            while (dr1.Read())
            {
                lblToplamPer.Text = dr1[0].ToString();
            }
            baglanti.Close();

            //evli personel sayısı
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select count(*) from Tbl_Personel where perdurum='evli'", baglanti);
            SqlDataReader dr2=komut2.ExecuteReader();
            while (dr2.Read())
            {
                lblEvliSayisi.Text = dr2[0].ToString();
            }
            baglanti.Close();

            //bekar personel sayısı
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select count(*) from Tbl_Personel where perdurum='bekar'",baglanti);
            SqlDataReader dr3=komut3.ExecuteReader();
            while (dr3.Read())
            {
                lblBekarSayisi.Text = dr3[0].ToString();
            }
            baglanti.Close();

            //sehir sayısı
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("select count(distinct(persehir)) from Tbl_Personel where persehir is not null and persehir <> '';",baglanti);
            SqlDataReader dr4 =komut4.ExecuteReader();
            while (dr4.Read())
            {
                lblSehirSayisi.Text = dr4[0].ToString();
            }
            baglanti.Close();

            //toplam maaş
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("select sum(permaas) from Tbl_Personel", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                lblTopMaas.Text = dr5[0].ToString();
            }
            baglanti.Close();

            //ortalama maaş
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("select avg(permaas) from Tbl_Personel",baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                lblOrtMaas.Text = dr6[0].ToString();
            }
            baglanti.Close();


        }
    }
}
