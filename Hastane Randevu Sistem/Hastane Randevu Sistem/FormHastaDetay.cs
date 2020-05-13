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
    public partial class FormHastaDetay : Form
    {
        public FormHastaDetay()
        {
            InitializeComponent();
        }
        ClassSQLBaglantisi bgl = new ClassSQLBaglantisi();
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        // tc steingi oluşturup girişte kullandığımız tc yi paneldeki tc ye yazdırıyorum
        public string tc;
        
        private void FormHastaDetay_Load(object sender, EventArgs e)
        {
            lbltc.Text = tc;
            //Hastalar tablosundan girilen tcnin uyduğu hastanın adını soyadını çekiyorum
            SqlCommand komut = new SqlCommand("Select HastaAd,HastaSoyad from Tbl_Hastalar where HastaTc=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", tc);
            SqlDataReader dr = komut.ExecuteReader();
            //okuduğumuz veriden ad ve soyad parametrelini yazdırıyoruz.
            while (dr.Read())
            {
                lbladsoyad.Text = dr[0] + " " + dr[1];

            }
            bgl.baglanti().Close();

            //Veri kaynağımızdan girilen tc nin randevularını çekiyoruz
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Randevular where HastaTC=" + tc, bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //Branşlar tablomuzdanda doktorların branşlarını çekiyorum
            SqlCommand komut2 = new SqlCommand("select BransAd from Tbl_Branslar", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbdoktorbrans.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();

        }
        
        private void cmbdoktorbrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            //doktorların adını sürekli yazmaması için temizliyoruz her seferinde
            cmbdoktoradı.Items.Clear();
            //Girilen doktor branşına ait doktorın adını soyadını çekiyoruz
            SqlCommand komut3 = new SqlCommand("select DoktorAd,DoktorSoyad from Tbl_Doktorlar where DoktorBrans=@p1", bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1", cmbdoktorbrans.Text);
            SqlDataReader dr3 = komut3.ExecuteReader();
            //yazdırıyoruz
            while (dr3.Read())
            {
                cmbdoktoradı.Items.Add(dr3[0] + " " + dr3[1]);
            }
            bgl.baglanti().Close();
        }

        private void cmbdoktoradı_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            //randevularda sadece seçilen doktorun randevuları gözüksün istiyoruz
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Randevular where RandevuBrans='" + cmbdoktorbrans.Text + "'"+" and RandevuDoktor='"+cmbdoktoradı.Text+"' and RandevuDurum=0", bgl.baglanti());
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }
        //Bilgi güncelleme paneline yönlendiriyorum.
        private void linkbilgiguncelle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormBilgiGüncelle bilgiGüncelle = new FormBilgiGüncelle();
            bilgiGüncelle.Show();
        }
        //Gririlen randevu bilgilerini SQL e aktarıyorum.Bunun için if-else kullanarak randevu id girilmesini zorunlu tuttum.
        private void btnrandevual_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Tbl_Randevular set RandevuDurum=1,HastaTC=@p1,HastaSikayet=@p2 where Randevuid=@p3", bgl.baglanti());
            if (txtrandevuid.Text=="")
            {
                MessageBox.Show("Lütfen RandevuID Giriniz!", "Hata", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                komut.Parameters.AddWithValue("@p1", lbltc.Text);
                komut.Parameters.AddWithValue("@p2", richtextsikayet.Text);
                komut.Parameters.AddWithValue("@p3", txtrandevuid.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show("Randevu Alınmıştır.Sağlıklı Günler.");
            }
            

        }
        //Temizle butonuna basıldığında girilen randevu bilgilerini temziledim.
        private void btntemizle_Click(object sender, EventArgs e)
        {
            cmbdoktorbrans.Text = "";
            cmbdoktoradı.Text = "";
            txtrandevuid.Clear();
            richtextsikayet.Clear();
        }
    }
}
