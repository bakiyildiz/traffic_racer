using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
namespace traffic_racer
{
    public partial class selectcar : Form
    {
        public selectcar()
        {
            InitializeComponent();
        }
        public int arac_secimi = 1;
        private void selectcar_Load(object sender, EventArgs e)
        {
            arac_secimi = 1;
            pic_secim.Location = new Point(103, 294);
            pictureBox1.Image = traffic_racer.Properties.Resources.arac1;
        }

        private void selectcar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                if (arac_secimi < 10)
                {
                    arac_secimi++;
                    arac_sec();
                }
            }
            if (e.KeyCode == Keys.Left)
            {
                if (arac_secimi > 1)
                {
                    arac_secimi--;
                    arac_sec();
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                oyunabasla();
            }
            if (e.KeyCode == Keys.Up)
            {
                if (arac_secimi > 5)
                {
                    arac_secimi -= 5;
                    arac_sec();
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (arac_secimi < 6)
                {
                    arac_secimi += 5;
                    arac_sec();
                }
            }
        }

        private void arac_sec()
        {
            try
            {
                backgroundWorker1.RunWorkerAsync();
            }
            catch (Exception)
            {
            }
            Thread.Sleep(250);
            if (arac_secimi == 1)
            {
                pic_secim.Location = new Point(103, 294);
                pictureBox1.Image = traffic_racer.Properties.Resources.arac1;
            }
            else if (arac_secimi == 2)
            {
                pic_secim.Location = new Point(210, 294);
                pictureBox1.Image = traffic_racer.Properties.Resources.arac2;
            }
            else if (arac_secimi == 3)
            {
                pic_secim.Location = new Point(315, 294);
                pictureBox1.Image = traffic_racer.Properties.Resources.arac3;
            }
            else if (arac_secimi == 4)
            {
                pic_secim.Location = new Point(417, 294);
                pictureBox1.Image = traffic_racer.Properties.Resources.arac4;
            }
            else if (arac_secimi == 5)
            {
                pic_secim.Location = new Point(523, 294);
                pictureBox1.Image = traffic_racer.Properties.Resources.arac5;
            }
            else if (arac_secimi == 6)
            {
                pic_secim.Location = new Point(103, 460);
                pictureBox1.Image = traffic_racer.Properties.Resources.arac6;
            }
            else if (arac_secimi == 7)
            {
                pic_secim.Location = new Point(210, 460);
                pictureBox1.Image = traffic_racer.Properties.Resources.arac7;
            }
            else if (arac_secimi == 8)
            {
                pic_secim.Location = new Point(315, 460);
                pictureBox1.Image = traffic_racer.Properties.Resources.arac8;
            }
            else if (arac_secimi == 9)
            {
                pic_secim.Location = new Point(417, 460);
                pictureBox1.Image = traffic_racer.Properties.Resources.arac9;
            }
            else if (arac_secimi == 10)
            {
                pic_secim.Location = new Point(523, 460);
                pictureBox1.Image = traffic_racer.Properties.Resources.arac10;
            }
        }

        private void selectcar_FormClosing(object sender, FormClosingEventArgs e)
        {
            anamenu anm = new anamenu();
            anm.Show();
            this.Hide();
        }

        private void pictureBox12_MouseEnter(object sender, EventArgs e)
        {
            pictureBox12.Image = traffic_racer.Properties.Resources.oynaover;
        }

        private void pictureBox12_MouseLeave(object sender, EventArgs e)
        {
            pictureBox12.Image = traffic_racer.Properties.Resources.oyna;
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            oyunabasla();
        }

        void oyunabasla()
        {
            Properties.Settings.Default.aracno = arac_secimi.ToString();
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        SoundPlayer secim_sesim = new SoundPlayer(Application.StartupPath + "\\dosyalar\\car_change_sound.wav");
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            secim_sesim.PlaySync();
        }
    }
}
