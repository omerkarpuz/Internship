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
    public partial class FrmGrafik : Form
    {
        public FrmGrafik()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-2T252BE\\MSSQL2022;Initial Catalog=omrstaj_PersonelVeriTabani;Integrated Security=True");

        private void FrmGrafik_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutg1 = new SqlCommand("select persehir,count(*) toplam from Tbl_Personel where persehir is not null and persehir <>'' group by persehir", baglanti);
            SqlDataReader drg1= komutg1.ExecuteReader();
            while (drg1.Read()) 
            {
                chart1.Series["Sehirler"].Points.AddXY(drg1["persehir"], drg1["toplam"]);
                
            }

            baglanti.Close();

            baglanti.Open();

            SqlCommand komutg2 = new SqlCommand("select permeslek,avg(permaas) permaas from Tbl_Personel group by permeslek",baglanti);
            SqlDataReader drg2 = komutg2.ExecuteReader();
            while (drg2.Read()) 
            {
                chart2.Series["Meslek-Maas"].Points.AddXY(drg2["permeslek"], drg2["permaas"]);
            }
            baglanti.Close();

        }
    }
}
