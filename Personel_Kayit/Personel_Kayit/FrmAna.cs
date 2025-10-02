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
    public partial class FrmAna : Form
    {
        public FrmAna()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-2T252BE\\MSSQL2022;Initial Catalog=omrstaj_PersonelVeriTabani;Integrated Security=True");


        void temizle()
        {
            txtId.Text = "";
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtMeslek.Text = "";
            cmbSehir.Text = "";
            mskMaas.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;   
            txtAd.Focus();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnListele_Click(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'omrstaj_PersonelVeriTabaniDataSet.Tbl_Personel' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tbl_PersonelTableAdapter.Fill(this.omrstaj_PersonelVeriTabaniDataSet.Tbl_Personel);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'omrstaj_PersonelVeriTabaniDataSet.Tbl_Personel' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tbl_PersonelTableAdapter.Fill(this.omrstaj_PersonelVeriTabaniDataSet.Tbl_Personel);
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (label8.Text == "Evli")
            {
                radioButton1.Checked = true;
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (label8.Text == "Bekar")
            {
                radioButton2.Checked = true;
            }
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("insert into Tbl_Personel(PerAd,PerSoyad,PerSehir,PerMaas,PerMeslek,PerDurum) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti); //nesne oluştur ve sql komutunu göm

            komut.Parameters.AddWithValue("@p1", txtAd.Text);           //komutları form elementleriyle eşleştiriyorum.
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmbSehir.Text);
            komut.Parameters.AddWithValue("@p4", mskMaas.Text);
            komut.Parameters.AddWithValue("@p5", txtMeslek.Text);
            komut.Parameters.AddWithValue("@p6", label8.Text);

            komut.ExecuteNonQuery();       

            baglanti.Close();
            
            MessageBox.Show("Personel eklendi!");
        }


        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txtId.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbSehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mskMaas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtMeslek.Text = dataGridView1.Rows[secilen ].Cells[6].Value.ToString();    

        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if (label8.Text == "Evli")
            {
                radioButton1.Checked = true;
            }
            if (label8.Text == "Bekar")
            {
                radioButton2.Checked = true;   
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            
            SqlCommand komutsil= new SqlCommand("delete from Tbl_Personel where perid=@k1",baglanti);
            komutsil.Parameters.AddWithValue("@k1", txtId.Text);

            komutsil.ExecuteNonQuery();
            
            baglanti.Close();

            MessageBox.Show("Seçilen Id silindi!");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
 
            baglanti.Open();
            SqlCommand komutguncelle = new SqlCommand("update Tbl_Personel set perad=@a1, persoyad=@a2,persehir=@a3,permaas=@a4,perdurum=@a5,permeslek=@a6 where perid=@a7",baglanti);
            komutguncelle.Parameters.AddWithValue("@a1", txtAd.Text);
            komutguncelle.Parameters.AddWithValue("@a2",txtSoyad.Text);
            komutguncelle.Parameters.AddWithValue("@a3",cmbSehir.Text);
            komutguncelle.Parameters.AddWithValue("@a4",mskMaas.Text);
            if (radioButton1.Checked) { label8.Text = "Evli"; } if (radioButton2.Checked) { label8.Text = "Bekar"; }
            komutguncelle.Parameters.AddWithValue("@a5",label8.Text);
            komutguncelle.Parameters.AddWithValue("@a6",txtMeslek.Text);
            komutguncelle.Parameters.AddWithValue("@a7", txtId.Text );




            komutguncelle.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Veriler güncellendi!");

        }

        private void btnIst_Click(object sender, EventArgs e)
        {
            Frmistatistik fr = new Frmistatistik();
            fr.Show();
        }

        private void btnGraph_Click(object sender, EventArgs e)
        {
            FrmGrafik frmGrafik= new FrmGrafik();

            frmGrafik.Show();
        }
    }
}
