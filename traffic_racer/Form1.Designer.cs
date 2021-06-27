namespace traffic_racer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.seritlertimer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.arabam = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.hiztimer = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sure = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.polisolustur = new System.Windows.Forms.Timer(this.components);
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.yavaslat = new System.Windows.Forms.Timer(this.components);
            this.bosta = new System.Windows.Forms.Timer(this.components);
            this.sagagidis = new System.Windows.Forms.Timer(this.components);
            this.solagidis = new System.Windows.Forms.Timer(this.components);
            this.ses_polis = new AxWMPLib.AxWindowsMediaPlayer();
            this.ses_arabam = new AxWMPLib.AxWindowsMediaPlayer();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.arabam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ses_polis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ses_arabam)).BeginInit();
            this.SuspendLayout();
            // 
            // seritlertimer
            // 
            this.seritlertimer.Interval = 10;
            this.seritlertimer.Tick += new System.EventHandler(this.seritler_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.arabam);
            this.panel1.Location = new System.Drawing.Point(226, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(690, 891);
            this.panel1.TabIndex = 1;
            // 
            // arabam
            // 
            this.arabam.Image = global::traffic_racer.Properties.Resources.arac1;
            this.arabam.Location = new System.Drawing.Point(25, 694);
            this.arabam.Name = "arabam";
            this.arabam.Size = new System.Drawing.Size(100, 173);
            this.arabam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.arabam.TabIndex = 0;
            this.arabam.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(986, 553);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "HIZ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(986, 594);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "0";
            // 
            // hiztimer
            // 
            this.hiztimer.Interval = 20;
            this.hiztimer.Tick += new System.EventHandler(this.hiztimer_Tick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(194, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(33, 891);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(916, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(33, 891);
            this.panel3.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(1022, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 26);
            this.label3.TabIndex = 4;
            this.label3.Text = "GEÇEN SÜRE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(1056, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 26);
            this.label4.TabIndex = 5;
            this.label4.Text = "00:00";
            // 
            // sure
            // 
            this.sure.Interval = 1000;
            this.sure.Tick += new System.EventHandler(this.sure_Tick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(1106, 594);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 26);
            this.label5.TabIndex = 7;
            this.label5.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(1106, 553);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 26);
            this.label6.TabIndex = 6;
            this.label6.Text = "Alınan Yol";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(1075, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 26);
            this.label7.TabIndex = 9;
            this.label7.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(1056, 122);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 26);
            this.label8.TabIndex = 8;
            this.label8.Text = "PUAN";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 9);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(1, 4);
            this.listBox1.TabIndex = 10;
            this.listBox1.Visible = false;
            // 
            // polisolustur
            // 
            this.polisolustur.Enabled = true;
            this.polisolustur.Interval = 25000;
            this.polisolustur.Tick += new System.EventHandler(this.polisolustur_Tick);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(12, 399);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(176, 60);
            this.axWindowsMediaPlayer1.TabIndex = 11;
            this.axWindowsMediaPlayer1.Visible = false;
            // 
            // yavaslat
            // 
            this.yavaslat.Interval = 20;
            // 
            // bosta
            // 
            this.bosta.Tick += new System.EventHandler(this.bosta_Tick);
            // 
            // sagagidis
            // 
            this.sagagidis.Interval = 1;
            this.sagagidis.Tick += new System.EventHandler(this.sagagidis_Tick);
            // 
            // solagidis
            // 
            this.solagidis.Interval = 1;
            this.solagidis.Tick += new System.EventHandler(this.solagidis_Tick);
            // 
            // ses_polis
            // 
            this.ses_polis.Enabled = true;
            this.ses_polis.Location = new System.Drawing.Point(12, 16);
            this.ses_polis.Name = "ses_polis";
            this.ses_polis.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ses_polis.OcxState")));
            this.ses_polis.Size = new System.Drawing.Size(176, 49);
            this.ses_polis.TabIndex = 12;
            this.ses_polis.Visible = false;
            // 
            // ses_arabam
            // 
            this.ses_arabam.Enabled = true;
            this.ses_arabam.Location = new System.Drawing.Point(12, 71);
            this.ses_arabam.Name = "ses_arabam";
            this.ses_arabam.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ses_arabam.OcxState")));
            this.ses_arabam.Size = new System.Drawing.Size(176, 49);
            this.ses_arabam.TabIndex = 13;
            this.ses_arabam.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 892);
            this.Controls.Add(this.ses_arabam);
            this.Controls.Add(this.ses_polis);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1247, 931);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1247, 931);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.arabam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ses_polis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ses_arabam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer seritlertimer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox arabam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer hiztimer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer sure;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox listBox1;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.Timer polisolustur;
        private System.Windows.Forms.Timer yavaslat;
        private System.Windows.Forms.Timer bosta;
        private System.Windows.Forms.Timer sagagidis;
        private System.Windows.Forms.Timer solagidis;
        private AxWMPLib.AxWindowsMediaPlayer ses_polis;
        private AxWMPLib.AxWindowsMediaPlayer ses_arabam;
    }
}

