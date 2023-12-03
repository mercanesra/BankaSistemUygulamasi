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
    public partial class ParaYatir : Form
    {
        public ParaYatir()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=LAPTOP-SINNOVD9;Initial Catalog=bankamatik2;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {

            float sayi = float.Parse(maskedTextBox1.Text);
            if (int.Parse(maskedTextBox1.Text)<=10)
            {
                MessageBox.Show("Lütfen en az 10 TL yatiriniz", "Para Yatirma İşlemi");
            }

            else
            {
                SqlCommand komut = new SqlCommand("update  musteriler set bakiye += @p1 where ID=@p2 ", con);
                komut.Parameters.AddWithValue("@p1", sayi);
                komut.Parameters.AddWithValue("@p2", Form1.mID);

                con.Open();



                int sonuc = komut.ExecuteNonQuery();
                if (sonuc == 1)
                {
                    MessageBox.Show("Para Yatirma İşlemi  Yapıldı", "Para Yatirma  İşlemi", MessageBoxButtons.OK);
                    Form1.mBakiye += sayi;

                    HareketKaydet.kaydet(Form1.mID,(sayi + " TL Para Yatırıldı"));
                }
                else
                {


                    MessageBox.Show("Para Yatirma İşlemi Başarısız!", "Para Yatirma İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                }

                con.Close();
                maskedTextBox1.Text = "";
            }
        }
    }
}
