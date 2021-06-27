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
    public partial class loadingform : Form
    {
        public loadingform()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity==1)
            {
                timer1.Enabled = false;
                //MessageBox.Show("bitti");
                anamenu anm = new anamenu();
                anm.Show();
                this.Hide();
            }
            else
            {
                this.Opacity += 0.05;
            }
        }

        private void loadingform_Load(object sender, EventArgs e)
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
    }
}
