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

namespace Hastane_Randevu_Sistem
{
    public partial class FormDoktorDetay : Form
    {
        public FormDoktorDetay()
        {
            InitializeComponent();
        }
        
        ClassSQLBaglantisi bgl = new ClassSQLBaglantisi();
        public string TC;
        private void FormDoktorDetay_Load(object sender, EventArgs e)
        {
            lbltc.Text = TC;

            //Doktorun adını soyadını SQLden çekip yazdırıyoruz
            SqlCommand komut = new SqlCommand("select DoktorAd,DoktorSoyad from Tbl_Doktorlar where DoktorTC=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", lbltc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lbladsoyad.Text = dr[0] + " " + dr[1];
            }
            bgl.baglanti().Close();

            //Doktorun randevularını çekip datagride yazdırıyorum
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Randevular where RandevuDoktor='" + lbladsoyad.Text + "'", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        // bilgi güncelle butonuna basınca bilgi güncelleme paneline aktarıyorum
        private void btnbilgiguncelle_Click(object sender, EventArgs e)
        {
            FormDoktorBilgiGüncelle doktorBilgiGüncelle = new FormDoktorBilgiGüncelle();
            doktorBilgiGüncelle.tcNO = lbltc.Text;
            doktorBilgiGüncelle.Show();
        }
        //duyurular butonuna tıklayınca duyurular paneline aktarıyorum.
        private void btnduyuru_Click(object sender, EventArgs e)
        {
            FormDuyurular duyurular = new FormDuyurular();
            duyurular.Show();
        }
        //çıkışa basınca sistemi kapatıyorum
        private void btncikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    }

