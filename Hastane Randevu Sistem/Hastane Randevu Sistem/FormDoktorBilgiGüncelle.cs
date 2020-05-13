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
    public partial class FormDoktorBilgiGüncelle : Form
    {
        public FormDoktorBilgiGüncelle()
        {
            InitializeComponent();
        }
        ClassSQLBaglantisi bgl = new ClassSQLBaglantisi();
        public string tcNO;
        private void FormDoktorBilgiGüncelle_Load(object sender, EventArgs e)
        {
            msktc.Text = tcNO;
            SqlCommand komut = new SqlCommand("select*from Tbl_Doktorlar where DoktorTC=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", msktc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read()){
                txtad.Text = dr[1].ToString();
                txtsoyad.Text = dr[2].ToString();
                cmbbrans.Text = dr[3].ToString();
                txtsifre.Text = dr[5].ToString();
            }
            bgl.baglanti().Close();
        }

        private void btnbilgiguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Tbl_Doktorlar set DoktorSoyad=@p1,DoktorBrans=@p2,DoktorSifre=@p3 where DoktorTC=@p4",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p2", cmbbrans.Text);
            komut.Parameters.AddWithValue("@p3", txtsifre.Text);
            komut.Parameters.AddWithValue("@p4", msktc.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgileriniz Güncellenmiştir.");
        }
    }
}
