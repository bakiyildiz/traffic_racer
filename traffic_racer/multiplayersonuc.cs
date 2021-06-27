using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace traffic_racer
{
    public partial class multiplayersonuc : Form
    {
        public multiplayersonuc()
        {
            InitializeComponent();
        }

        anamenu anm = new anamenu();

        private void button1_Click(object sender, EventArgs e)
        {

            anm.Show();
            this.Hide();
        }

        private void multiplayersonuc_Load(object sender, EventArgs e)
        {
            label1.Text = "Oynanan Süre: " + traffic_racer.Properties.Settings.Default.sonucsure;
            ///
            if (traffic_racer.Properties.Settings.Default.sonucduruma == "1" && traffic_racer.Properties.Settings.Default.sonucdurumb == "0")
            {
                label2.Text = "Kazanan: " + traffic_racer.Properties.Settings.Default.benad;
            }
            else if (traffic_racer.Properties.Settings.Default.sonucduruma == "0" && traffic_racer.Properties.Settings.Default.sonucdurumb == "1")
            {
                label2.Text = "Kazanan: " + traffic_racer.Properties.Settings.Default.rakipad;
            }
            else
            {
                label2.Text = "Kazanan: " + "Belirlenemedi";
            }
            ///
            label4.Text = traffic_racer.Properties.Settings.Default.benad;
            ///
            label3.Text = "Puan: " + traffic_racer.Properties.Settings.Default.sonucpuan;
            ///
            label6.Text = traffic_racer.Properties.Settings.Default.rakipad;
            ///
            label5.Text = traffic_racer.Properties.Settings.Default.rakippuani;
        }
    }
}
