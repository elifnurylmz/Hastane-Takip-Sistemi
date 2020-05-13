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
    public partial class FormSekreterGiris : Form
    {
        public FormSekreterGiris()
        {
            InitializeComponent();
        }
        ClassSQLBaglantisi bgl = new ClassSQLBaglantisi();
        //diğer formlarda da olduğu gibi girilen bilgiler doğruysa sekreter paneline aktarıyorum
        private void btngiris_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from Tbl_Sekreter where SekreterTC=@p1 and SekreterSifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", msktc.Text);
            komut.Parameters.AddWithValue("@p2", txtsifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FormSekreterDetay sekreterDetay = new FormSekreterDetay();
                sekreterDetay.tcnum = msktc.Text;
                sekreterDetay.Show();
                this.Hide();

            }
            //yanlışsa hata mesajı veriyorum
            else
            {
                MessageBox.Show("Yanlış Kullanıcı Girişi!", "Uyarı", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            bgl.baglanti().Close();

        }

        private void FormSekreterGiris_Load(object sender, EventArgs e)
        {

        }
    }
}
