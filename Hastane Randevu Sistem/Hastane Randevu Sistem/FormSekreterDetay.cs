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
    public partial class FormSekreterDetay : Form
    {
        public FormSekreterDetay()
        {
            InitializeComponent();
        }
        public string tcnum;
        ClassSQLBaglantisi bgl = new ClassSQLBaglantisi();
        private void FormSekreterDetay_Load(object sender, EventArgs e)
        {
            lbltc.Text = tcnum;
            //ad-soyad aktarma
            SqlCommand komut1 = new SqlCommand("select SekreterAdSoyad from Tbl_Sekreter where SekreterTC=@p1", bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", lbltc.Text);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                lbladsoyad.Text = dr1[0].ToString();
            }
            bgl.baglanti().Close();

            //Branşı datagride aktarma

            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Branslar",bgl.baglanti());
            da.Fill(dt1);
            dataGridView1.DataSource = dt1;

            //Doktorları aktarma
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select DoktorAd,DoktorSoyad,DoktorBrans from Tbl_Doktorlar", bgl.baglanti());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;

            //Branşı combobaxa aktarma
            SqlCommand komut2 = new SqlCommand("select BransAd from Tbl_Branslar", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                combbranş.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();
        }
        //randevu oluşturma
        private void btnrandevuolustur_Click(object sender, EventArgs e)
        {//close yapmıyoruz çünkü arka arkaya randevu oluşturabilmek için
            SqlCommand komutrandevuolustur = new SqlCommand("insert into Tbl_Randevular (RandevuTarih,RandevuSaat,RandevuBrans,RandevuDoktor,HastaTC)values (@p1,@p2,@p3,@p4,@p6)",bgl.baglanti());
            if (masktc.Text == "")
            {
                MessageBox.Show("Lütfen Bilgileri Doldurunuz");
            }
            else
            {
                komutrandevuolustur.Parameters.AddWithValue("@p1", masktarih.Text);
                komutrandevuolustur.Parameters.AddWithValue("@p2", masksaat.Text);
                komutrandevuolustur.Parameters.AddWithValue("@p3", combbranş.Text);
                komutrandevuolustur.Parameters.AddWithValue("@p4", combdoktor.Text);
                komutrandevuolustur.Parameters.AddWithValue("@p6", masktc.Text);

                komutrandevuolustur.ExecuteNonQuery();

                MessageBox.Show("Randevunuz Oluşturulmuştur.Sağlıklı Günler.", "#evdekal", MessageBoxButtons.OK);
            }
            
        }
        //brnşa tıklayınca doktor gelsin
        private void combbranş_SelectedIndexChanged(object sender, EventArgs e)
        {
            combdoktor.Items.Clear();
            SqlCommand komut = new SqlCommand("select DoktorAd,DoktorSoyad from Tbl_Doktorlar where DoktorBrans=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", combbranş.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                combdoktor.Items.Add(dr[0] + " " + dr[1]);
            }
            bgl.baglanti().Close();
        }
        //duyuru oluşturma
        private void btnduyuru_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Duyurular(duyuru) values (@p1)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", richTxtduyuru.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Duyuru Oluşturulmuştur.", "Duyurular", MessageBoxButtons.OK, MessageBoxIcon.Information);

              
        }
        //randevu bilgilerini temizleme
        private void randevutemizle_Click(object sender, EventArgs e)
        {
            txtrandevuid.Clear();
            masktarih.Clear();
            masksaat.Clear();
            combbranş.Text = " ";
            combdoktor.Text = " ";
            masktc.Clear();
        }
        //doktor panelini açma
        private void btndoktorpaneli_Click(object sender, EventArgs e)
        {
            FormDoktorPaneli doktorPaneli = new FormDoktorPaneli();
            doktorPaneli.Show();
        }
        //branş panelini açma
        private void btnbranspaneli_Click(object sender, EventArgs e)
        {
            
            FormBransPaneli bransPaneli = new FormBransPaneli();
            bransPaneli.Show();
        }
        //randevu listesini açma
        private void btnrandevulist_Click(object sender, EventArgs e)
        {
            FormRandevuListesi randevuListesi = new FormRandevuListesi();
            randevuListesi.Show();
        }
        //randevu silme
        private void btnrandevusil_Click(object sender, EventArgs e)
        {
            if (masktc.Text == "")
            {
                MessageBox.Show("Lütfen Hasta TC No Giriniz!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlCommand komut = new SqlCommand("delete from Tbl_Randevular where HastaTC=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", masktc.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Randevunuz Silinmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //duyuru panelni açma
        private void btnduyurular_Click(object sender, EventArgs e)
        {
            FormDuyurular duyurular = new FormDuyurular();
            duyurular.Show();
        }
        //girilen duyuruyu temizleme
        private void btnduyurutemizle_Click(object sender, EventArgs e)
        {
            richTxtduyuru.Clear();

        }
    }
}
