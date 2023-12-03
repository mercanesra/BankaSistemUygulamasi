using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaSistemUygulamasi
{
    internal class HareketKaydet
    {

        public static void kaydet(int mId,string msj)
        {

            SqlConnection con = new SqlConnection("Data Source=LAPTOP-SINNOVD9;Initial Catalog=bankamatik2;Integrated Security=True");

            SqlCommand komut = new SqlCommand("insert into hareketler (musteriID,islem,tarih  values (p1,@p2,@p3)", con);
            komut.Parameters.AddWithValue("@p1", mId);
            komut.Parameters.AddWithValue("@p2", msj);
            komut.Parameters.AddWithValue("@p3", DateTime.Now);

            con.Open();
            komut.ExecuteNonQuery();
            con.Close();


        }


    }
}
