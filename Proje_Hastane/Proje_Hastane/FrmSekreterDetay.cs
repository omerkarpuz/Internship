using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace Proje_Hastane
{
    public partial class FrmSekreterDetay : Form
    {
        public FrmSekreterDetay()
        {
            InitializeComponent();
        }
        public string tc;
        sqlbaglantisi bgl=new sqlbaglantisi();
        private void FrmSekreterDetay_Load(object sender, EventArgs e)
        {
            lblTc.Text = tc;
            SqlCommand cmd = new SqlCommand("select sekreterad,sekretersoyad from Tbl_Sekreter where sekretertc=@p1", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", lblTc.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lblAd.Text = dr[0] + " " + dr[1];
            }
            bgl.baglanti().Close();

            //branşları gösterme
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select bransad Branş from Tbl_Branslar",bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //doktorları gösterme
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select (doktorad + ' ' + doktorsoyad) as 'Doktorlar',doktorbrans as 'Doktor Branş' from Tbl_Doktorlar", bgl.baglanti());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;

            //branşları combobox'a çekme
            SqlCommand cmd2 = new SqlCommand("select bransad from Tbl_Branslar", bgl.baglanti());
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                cmbBrans.Items.Add(dr2[0]);

            }bgl.baglanti().Close();

            //doktorları combobox'a çekme


        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand cmdkaydet = new SqlCommand("insert into Tbl_Randevular (randevutarih,randevusaat,randevubrans,randevudoktor) values (@r1,@r2,@r3,@r4)", bgl.baglanti());
            cmdkaydet.Parameters.AddWithValue("@r1", mskTarih.Text);
            cmdkaydet.Parameters.AddWithValue("@r2",mskSaat.Text);
            cmdkaydet.Parameters.AddWithValue("@r3",cmbBrans.Text);
            cmdkaydet.Parameters.AddWithValue("@r4",cmbDoktor.Text);
            cmdkaydet.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu oluşturuldu!");
        }

        private void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDoktor.Items.Clear();    
            SqlCommand cmd3 = new SqlCommand("select (doktorad+' '+doktorsoyad) from Tbl_Doktorlar where doktorbrans=@b1", bgl.baglanti());
            cmd3.Parameters.AddWithValue("@b1",cmbBrans.Text);

            SqlDataReader dr3 = cmd3.ExecuteReader();
            while(dr3.Read())
            {
                cmbDoktor.Items.Add(dr3[0]);

            }
            bgl.baglanti().Close();
        }

        private void btnDuyuruOlustur_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into Tbl_Duyurular (duyuru) values (@d1)", bgl.baglanti());
            cmd.Parameters.AddWithValue("@d1", txtDuyuru.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Duyuru oluşturuldu!");

        }

        private void btnDoktorPaneli_Click(object sender, EventArgs e)
        {
            FrmDoktorPaneli fr=new FrmDoktorPaneli();
            fr.Show();
        }

        private void brnBransPaneli_Click(object sender, EventArgs e)
        {
            FrmBrans fr=new FrmBrans();
            fr.Show();
        }

        private void btnRandevuListe_Click(object sender, EventArgs e)
        {
            FrmRandevuListesi fr=new FrmRandevuListesi();
            fr.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDuyurular fr=new FrmDuyurular();
            fr.Show();
        }

        private void cmbDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }
    }
}
