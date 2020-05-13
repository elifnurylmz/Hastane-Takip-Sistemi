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
    public partial class FormHastaGiris : Form
    {
        public FormHastaGiris()
        {
            InitializeComponent();
        }
        //SQL bağlantımızı sınıf içerisinde tanımlayıp her formda tekrar etmemek için sınıf üzerinden bağlantıyı oluşturdum
        ClassSQLBaglantisi bgl = new ClassSQLBaglantisi();

        //Linke tıklandığında üye olma formuna gidilmesini sağladım.
        private void linküye_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormHastaKayit hastaKayit = new FormHastaKayit();
            hastaKayit.Show();      
        }
        //Giriş butonuna basıldığında sqlden Hastalar tablosundaki hasta bilgilerini çekip eğer tc ve şifre doğruysa hasta detay panelinin açılmasını sağladım
        private void btngiris_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from Tbl_Hastalar where HastaTC=@p1 and HastaSifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", msktc.Text);
            komut.Parameters.AddWithValue("@p2", txtsifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
              
                FormHastaDetay hastaDetay = new FormHastaDetay();
                hastaDetay.tc = msktc.Text;
                hastaDetay.Show();
                this.Hide();
            }
            //Eğer yanlışsa messageboxla hata mesajı verdim
            else
            {
                MessageBox.Show("Hatalı Giriş Yaptınız! Lütfen tekrar deneyiniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            bgl.baglanti().Close();
        }
    }
}
