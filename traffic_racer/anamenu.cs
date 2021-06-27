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
    public partial class anamenu : Form
    {
        public anamenu()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = traffic_racer.Properties.Resources.oynaover;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = traffic_racer.Properties.Resources.oyna;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Image = traffic_racer.Properties.Resources.cikover;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = traffic_racer.Properties.Resources.cik;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                System.Environment.Exit(1);
            }
            catch (Exception)
            {
            }
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.Image = traffic_racer.Properties.Resources.skorover;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Image = traffic_racer.Properties.Resources.skor;
        }

        private void anamenu_Load(object sender, EventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath p = new System.Drawing.Drawing2D.GraphicsPath();
            p.StartFigure();
            p.AddArc(new Rectangle(0, 0, 40, 40), 180, 90);
            p.AddLine(40, 0, this.Width - 40, 0);
            p.AddArc(new Rectangle(this.Width - 40, 0, 40, 40), -90, 90);
            p.AddLine(this.Width, 40, this.Width, this.Height - 40);
            p.AddArc(new Rectangle(this.Width - 40, this.Height - 40, 40, 40), 0, 90);
            p.AddLine(this.Width - 40, this.Height, 40, this.Height);
            p.AddArc(new Rectangle(0, this.Height - 40, 40, 40), 90, 90);
            p.CloseFigure();
            this.Region = new Region(p);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            selectcar slcc = new selectcar();
            slcc.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            puan_goruntule pngrntl = new puan_goruntule();
            pngrntl.listele();
            pngrntl.ShowDialog();
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.Image = traffic_racer.Properties.Resources.multioynaover;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Image = traffic_racer.Properties.Resources.multioyna;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            multiplayerset slcc = new multiplayerset();
            slcc.Show();
            this.Hide();
        }
    }
}
