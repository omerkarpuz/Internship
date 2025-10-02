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
    public partial class FrmDoktorDetay : Form
    {
        public FrmDoktorDetay()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl=new sqlbaglantisi();

        public string tc;

        private void FrmDoktorDetay_Load(object sender, EventArgs e)
        {
            lblTc.Text = tc;
            SqlCommand cmd = new SqlCommand("select doktorad,doktorsoyad from Tbl_Doktorlar where doktortc=@p1", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1",tc);
            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                lblAd.Text = dataReader["doktorad"]+ " " + dataReader["doktorsoyad"];
            }
            bgl.baglanti().Close();

            //randevular
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Randevular where randevudoktor='"+lblAd.Text+"'", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;



        }

        private void btnBilgiDuzenle_Click(object sender, EventArgs e)
        {
            FrmDoktorBilgiDuzenle fr=new FrmDoktorBilgiDuzenle();
            fr.tcdoktor=lblTc.Text;
            fr.ShowDialog();
        }

        private void btnDuyurular_Click(object sender, EventArgs e)
        {
            
            FrmDuyurular fr=new FrmDuyurular();
            fr.Show();


        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtSikayet.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();

        }
    }
}
