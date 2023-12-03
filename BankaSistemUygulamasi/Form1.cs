﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankaSistemUygulamasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=LAPTOP-SINNOVD9;Initial Catalog=bankamatik2;Integrated Security=True");

        public static string adSoyad;
        public static int mID = 0;
        public static float mBakiye = 0.0f;


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton2.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {


            string kAdi = textBox1.Text;
            string parola = textBox2.Text;
            bool sonuc = false;

            if (radioButton1.Checked)
            {
                if (kAdi == "admin" && parola == "123")
                {
                    YetkiliIslem yi = new YetkiliIslem();
                    yi.Show();
                    this.Hide();
                }

                else
                {
                    MessageBox.Show("Hatalı Kullanıcı Adı  veya Parola ", "Hatalı Giriş Denemesi");
                }

            }
            else
            {
                con.Open();
                SqlCommand komut = new SqlCommand("select *from musteriler where tcNo= @p1 and sifre=@p2", con);
                komut.Parameters.AddWithValue("@p1", kAdi);
                komut.Parameters.AddWithValue("@p2", parola);

                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    adSoyad = dr["adSoyad"].ToString();
                    mID = int.Parse(dr["ID"].ToString());
                    mBakiye = float.Parse(dr["bakiye"].ToString());
                    sonuc = true;
                }

                con.Close();

                if (sonuc)
                {

                    sonuc = false;
                    musteriIslem mi = new musteriIslem();
                    mi.Show();
                    this.Hide();

                }

                else
                {

                    MessageBox.Show("Hatalı Kullanıcı Adı/TC  veya Parola ", "Hatalı Giriş Denemesi");
                }


            }
            textBox1.Text = "";
            textBox2.Text = "";





        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SifreUret su = new SifreUret();
            su.Show();
        }
    }





}
    

