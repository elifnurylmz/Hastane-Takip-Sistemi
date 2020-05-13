﻿using System;
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
    public partial class FormBilgiGüncelle : Form
    {
        public FormBilgiGüncelle()
        {
            InitializeComponent();
        }
        ClassSQLBaglantisi bgl = new ClassSQLBaglantisi();
        public string TcNo;
        //SQl den hastanın tcsini adını soyadını bilgilerini panele aktarıyorum
        private void FormBilgiGüncelle_Load(object sender, EventArgs e)
        {
            msktc.Text = TcNo;
            SqlCommand komut = new SqlCommand("select * from Tbl_Hastalar where HastaTC=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", msktc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtad.Text = dr[1].ToString();
                txtsoyad.Text = dr[2].ToString();
                msktel.Text = dr[4].ToString();
                txtsifre.Text = dr[5].ToString();
                cmbcinsiyet.Text = dr[6].ToString();
                
            }
            bgl.baglanti().Close();
        }
        //değiştirdiğim bilgileri güncelle butonuyla SQLde güncelliyorum
        private void btnbilgiguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut2= new SqlCommand("update Tbl_Hastalar set HastaAd=@p1,HastaSoyad=@p2,HastaTelefon=@p3,HastaSifre=@p4,HastaCinsiyet=@p5 where HastaTc=@p6", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", txtad.Text);
            komut2.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut2.Parameters.AddWithValue("@p3", msktel.Text);
            komut2.Parameters.AddWithValue("@p4", txtsifre.Text);
            komut2.Parameters.AddWithValue("@p5", cmbcinsiyet.Text);
            komut2.Parameters.AddWithValue("@p6", msktc.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgileriniz Güncellenmiştir.","Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
