﻿using System;
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
    public partial class HesapHareket : Form
    {
        public HesapHareket()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-SINNOVD9;Initial Catalog=bankamatik2;Integrated Security=True");
        private void HesapHareket_Load(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand("select * from hareketler where musteriID=@p1", con);
            komut.Parameters.AddWithValue("@p1", Form1.mID);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;




        }
    }
}
