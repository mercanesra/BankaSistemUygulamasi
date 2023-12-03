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
    public partial class ParaCek : Form
    {
        public ParaCek()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-SINNOVD9;Initial Catalog=bankamatik2;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {

            float sayi = float.Parse(maskedTextBox1.Text);
            if (sayi > Form1.mBakiye)
            {
                MessageBox.Show("Yetersiz Bakiye", "Para Çekme İşlemi");
            }

            else
            {
                SqlCommand komut = new SqlCommand("update  musteriler set bakiye -= @p1 where ID=@p2 ", con);
                komut.Parameters.AddWithValue("@p1", sayi);
                komut.Parameters.AddWithValue("@p2", Form1.mID);

                con.Open();



                int sonuc = komut.ExecuteNonQuery();
                if (sonuc == 1)
                {
                    MessageBox.Show("Para Çekme İşlemi  Yapıldı", "Para Çekme  İşlemi", MessageBoxButtons.OK);
                    Form1.mBakiye -= sayi;

                    HareketKaydet.kaydet(Form1.mID,(sayi + "TL Para Çekildi"));



                }
                else
                {


                    MessageBox.Show("Para Çekme İşlemi Başarısız!", "Para Çekme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    
                }

                con.Close();
                maskedTextBox1.Text = "";
            }



        }
    }
}

