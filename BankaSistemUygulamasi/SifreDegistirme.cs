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
    public partial class SifreDegistirme : Form
    {
        public SifreDegistirme()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-SINNOVD9;Initial Catalog=bankamatik2;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {


            if (txtEski.Text == "" || txtYeni.Text == "")
            {
                MessageBox.Show("Lütfen Alanları Giriniz", "Şifre Değiştirme İşlemi");
            }

            else if (txtYeni.Text.Length < 5)
            {
                MessageBox.Show("En az 5 Karakter Uzunluğu Şifre Belirleyiniz", "Şifre Değiştirme İşlemi");
            }



            else
            {
                SqlCommand komut = new SqlCommand("update  musteriler set sifre = @p1 where sifre=@p2 ", con);
                komut.Parameters.AddWithValue("@p1", txtYeni.Text);
                komut.Parameters.AddWithValue("@p2", txtEski.Text);

                con.Open();



                int sonuc = komut.ExecuteNonQuery();
                if (sonuc == 1)
                {
                    MessageBox.Show("Şifre Değiştirme İşlemi  Yapıldı", "Şifre Değiştirme  İşlemi", MessageBoxButtons.OK);


                    HareketKaydet.kaydet(Form1.mID, "Şifre Değiştirildi");
                }
                else
                {


                    MessageBox.Show("Şifre Değiştirme İşlemi Başarısız!", "Şifre Değiştirme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                }

                con.Close();
                txtEski.Text = "";
                txtYeni.Text = "";


            }
        }
    }
}