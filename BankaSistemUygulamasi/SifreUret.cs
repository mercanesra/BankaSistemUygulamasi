using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankaSistemUygulamasi
{
    public partial class SifreUret : Form
    {
        public SifreUret()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-SINNOVD9;Initial Catalog=bankamatik2;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {


            if (txtTC.Text == "" || txtTelefon.Text == "" || txtSifre.Text == "")
            {
                MessageBox.Show("Lütfen Alanları Giriniz", "Şifre Üretme İşlemi");
            }

            else if (txtSifre.Text.Length < 5)
            {
                MessageBox.Show("En az 5 Karakter Uzunluğu Şifre Belirleyiniz", "Şifre Üretme İşlemi");
            }



            else
            {
                SqlCommand komut = new SqlCommand("update  musteriler set sifre = @p1 where tcNo=@p2  and telefon @p3", con);
                komut.Parameters.AddWithValue("@p1", txtSifre.Text);
                komut.Parameters.AddWithValue("@p2", txtTC.Text);
                komut.Parameters.AddWithValue("@p3", txtTelefon.Text);

                con.Open();



                int sonuc = komut.ExecuteNonQuery();
                if (sonuc == 1)
                {
                    MessageBox.Show("Şifre Üretme İşlemi  Yapıldı", "Şifre Üretme İşlemi", MessageBoxButtons.OK);


                  
                }
                else
                {


                    MessageBox.Show("Şifre Üretme  İşlemi Başarısız!", "Şifre Üretme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                }

                con.Close();
                txtTC.Text = "";
                txtTelefon.Text = "";
                txtSifre.Text = "";

            }
        }
    }
}