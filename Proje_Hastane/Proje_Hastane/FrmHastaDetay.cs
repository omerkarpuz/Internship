using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proje_Hastane
{
    public partial class FrmHastaDetay : Form
    {
        public FrmHastaDetay() { InitializeComponent(); }

        public string tc;
        sqlbaglantisi bgl = new sqlbaglantisi();

        private void LoadRandevuGecmisi()
        {
            using (var con = bgl.baglanti())
            using (var da = new SqlDataAdapter(
                "SELECT RandevuId, RandevuTarih, RandevuSaat, RandevuDurum, RandevuBrans, RandevuDoktor, HastaTc, HastaSikayet " +
                "FROM Tbl_Randevular WHERE HastaTc = @tc ORDER BY RandevuTarih DESC, RandevuSaat DESC", con))
            {
                da.SelectCommand.Parameters.AddWithValue("@tc", lblTc.Text);
                var dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt; // Geçmiş Randevular
            }
        }

        private void LoadAktifRandevular()
        {
            if (string.IsNullOrWhiteSpace(cmbBrans.Text) || string.IsNullOrWhiteSpace(cmbDoktor.Text))
            {
                dataGridView2.DataSource = new DataTable();
                return;
            }

            using (var con = bgl.baglanti())

            using (var da = new SqlDataAdapter(
                "SELECT RandevuId, RandevuTarih, RandevuSaat, RandevuDurum, RandevuBrans, RandevuDoktor, HastaTc, HastaSikayet " +
                "FROM Tbl_Randevular " +
                "WHERE RandevuBrans=@brans AND RandevuDoktor=@doktor AND RandevuDurum=0 " +
                "ORDER BY RandevuTarih, RandevuSaat", con))
            {
                da.SelectCommand.Parameters.AddWithValue("@brans", cmbBrans.Text);
                da.SelectCommand.Parameters.AddWithValue("@doktor", cmbDoktor.Text);
                var dt = new DataTable();
                da.Fill(dt);
                dataGridView2.DataSource = dt; // Aktif Randevular (boş olanlar)
            }
        }

        private void FrmHastaDetay_Load(object sender, EventArgs e)
        {
            lblTc.Text = tc;

            using (var con = bgl.baglanti())
            using (var cmd = new SqlCommand("SELECT HastaAd, HastaSoyad FROM Tbl_Hastalar WHERE HastaTc=@tc", con))
            {
                cmd.Parameters.AddWithValue("@tc", lblTc.Text);
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                        lblAd.Text = $"{dr["HastaAd"]} {dr["HastaSoyad"]}";
                }
            }

            using (var con = bgl.baglanti())
            using (var cmd = new SqlCommand("SELECT BransAd FROM Tbl_Branslar ORDER BY BransAd", con))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read()) cmbBrans.Items.Add(dr.GetString(0));
            }

            LoadRandevuGecmisi();
        }

        private void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDoktor.Items.Clear();
            cmbDoktor.Text = "";

            using (var con = bgl.baglanti())
            using (var cmd = new SqlCommand(
                "SELECT DoktorAd, DoktorSoyad FROM Tbl_Doktorlar WHERE DoktorBrans=@brans ORDER BY DoktorAd, DoktorSoyad", con))
            {
                cmd.Parameters.AddWithValue("@brans", cmbBrans.SelectedItem.ToString());
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                        cmbDoktor.Items.Add($"{dr["DoktorAd"]} {dr["DoktorSoyad"]}");
                }
            }

            // Doktor henüz seçilmedi, aktif randevuları temizle
            dataGridView2.DataSource = new DataTable();
        }

        private void cmbDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAktifRandevular();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // header tıklaması

            var row = dataGridView2.Rows[e.RowIndex];

            txtId.Text = row.Cells["RandevuId"].Value?.ToString();

            // mskTarih.Text  = Convert.ToDateTime(row.Cells["RandevuTarih"].Value).ToString("dd.MM.yyyy");
            // mskSaat.Text   = row.Cells["RandevuSaat"].Value?.ToString();
        }

        private void btnRandevu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Lütfen listeden randevu seçin.");
                return;
            }

            using (var con = bgl.baglanti())
            using (var cmd = new SqlCommand(
                "UPDATE Tbl_Randevular " +
                "SET RandevuDurum=1, HastaTc=@tc, HastaSikayet=@sikayet " +
                "WHERE RandevuId=@id", con))
            {
                cmd.Parameters.AddWithValue("@tc", lblTc.Text);
                cmd.Parameters.AddWithValue("@sikayet", txtSikayet.Text);
                cmd.Parameters.AddWithValue("@id", txtId.Text);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Randevu alındı!");

            LoadAktifRandevular();
            LoadRandevuGecmisi();


            txtId.Clear(); txtSikayet.Clear();
        }

        private void lnkBilgiDüzenle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var fr = new FrmBilgiDüzenle { tcNo = lblTc.Text };
            fr.ShowDialog();

            // Hasta bilgileri güncellenmiş olabilir:
            FrmHastaDetay_Load(sender, e);
        }
    }
}
