using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankaSistemUygulamasi
{
    public partial class Bakiye : Form
    {
        public Bakiye()
        {
            InitializeComponent();
        }

        private void Bakiye_Load(object sender, EventArgs e)
        {
            labelBakiye.Text = Form1.mBakiye.ToString() + "TL";
            HareketKaydet.kaydet(Form1.mID, "Bakiye Sorgulandı");
        }
    }
}
