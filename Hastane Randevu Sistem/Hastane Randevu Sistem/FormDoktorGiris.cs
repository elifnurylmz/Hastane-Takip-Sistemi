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
    public partial class FormDoktorGiris : Form
    {
        public FormDoktorGiris()
        {
            InitializeComponent();
        }

        ClassSQLBaglantisi bgl = new ClassSQLBaglantisi();
        //Giriş butonuna basıldığında SQL doktorlar tablosunda eğer girilen doktor tc ve şifre doğruysa detay paneline yönlendiriyorum.
        private void btngiris_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from Tbl_Doktorlar where DoktorTC=@p1 and DoktorSifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", msktc.Text);
            komut.Parameters.AddWithValue("@p2", txtsifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FormDoktorDetay doktorDetay = new FormDoktorDetay();
                doktorDetay.TC = msktc.Text;

                doktorDetay.Show();
                this.Hide();
            }
            //yanlışsa hata veriyor
            else
            {
                MessageBox.Show("Yanlış Kullanıcı Girişi!", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            }
            bgl.baglanti().Close();

        }
    }
}
