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
    public partial class FormDoktorPaneli : Form
    {
        public FormDoktorPaneli()
        {
            InitializeComponent();
        }
        ClassSQLBaglantisi bgl = new ClassSQLBaglantisi();
        // Doktor paneli yüklendiğinde Doktorun ad csoyad ve tcsini SQLden aktardım.
        private void FormDoktorPaneli_Load(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("select * from Tbl_Doktorlar", bgl.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
            //Sqlden branşını aktarıp yazdırdım
            SqlCommand komut2 = new SqlCommand("select BransAd from Tbl_Branslar", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbbrans.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();

        }
        //Ekle butonuna basıldığında girilen doktor bilgilerini SQLe ekledim
        private void btnekle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Doktorlar(DoktorAd,DoktorSoyad,DoktorBrans,DoktorTC,DoktorSifre)values(@p1,@p2,@p3,@p4,@p5)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmbbrans.Text);
            komut.Parameters.AddWithValue("@p4", masktc.Text);
            komut.Parameters.AddWithValue("@p5", txtsifre.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Yeni Doktor Eklendi.","Bilgi", MessageBoxButtons.OK);

        }
        //doktor silmek içinde tcnin girilmesi şartını koyarak tcsi girilen doktoru SQLden sildim
        private void btnsil_Click(object sender, EventArgs e)
        {
            if (masktc.Text == "")
            {
                MessageBox.Show("Lütfen Doktor Tc Numarasını Giriniz!");


            }
            else {
                
                SqlCommand komut = new SqlCommand("delete from Tbl_Doktorlar where DoktorTC=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", masktc.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Doktor Kaydı Silinmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
    }
}
