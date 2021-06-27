using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace traffic_racer
{
    public partial class puan_goruntule : Form
    {
        public puan_goruntule()
        {
            InitializeComponent();
        }

        SqlConnection baglantim = new SqlConnection(@"Data Source=EXCALIBUR\SQLEXPRESS;Initial Catalog=puanlar;Integrated Security=SSPI");


        public void listele()
        {
            baglantim.Open();
            DataTable tbl = new DataTable();
            SqlDataAdapter adptr = new SqlDataAdapter("Select İsim,Puan,Süre,Tarih from puantablo", baglantim);
            adptr.Fill(tbl);
            baglantim.Close();
            dataGridView1.DataSource = tbl;
        }
    }
}
