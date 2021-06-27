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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool oyunbasladimi = true;
        bool ileri;
        bool yavasla;
        int arachiz = 0;
        int arackonum = 1;
        int puan = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Turquoise;

            string aracnom = Properties.Settings.Default.aracno;
            if (aracnom == "1")
            {
                arabam.Image = traffic_racer.Properties.Resources.arac1;
            }
            else if (aracnom == "2")
            {
                arabam.Image = traffic_racer.Properties.Resources.arac2;
            }
            else if (aracnom == "3")
            {
                arabam.Image = traffic_racer.Properties.Resources.arac3;
            }
            else if (aracnom == "4")
            {
                arabam.Image = traffic_racer.Properties.Resources.arac4;
            }
            else if (aracnom == "5")
            {
                arabam.Image = traffic_racer.Properties.Resources.arac5;
            }
            else if (aracnom == "6")
            {
                arabam.Image = traffic_racer.Properties.Resources.arac6;
            }
            else if (aracnom == "7")
            {
                arabam.Image = traffic_racer.Properties.Resources.arac7;
            }
            else if (aracnom == "8")
            {
                arabam.Image = traffic_racer.Properties.Resources.arac8;
            }
            else if (aracnom == "9")
            {
                arabam.Image = traffic_racer.Properties.Resources.arac9;
            }
            else if (aracnom == "10")
            {
                arabam.Image = traffic_racer.Properties.Resources.arac10;
            }
            //-
            //serit olusturma
            for (int i = 60; i < panel1.Height; i++)
            {
                for (int j = 150; j < panel1.Width; j++)
                {
                    seritolustur(j, i);
                    j += 180;
                }
                i += 150;
            }

            seritlertimer.Enabled = true;
            hiztimer.Enabled = true;
            sure.Enabled = true;
            serit_degistir();
            ses_arabam.URL = Application.StartupPath +"\\dosyalar\\baslangic.mp3";
            ses_arabam.Ctlcontrols.play();
        }

        private void seritolustur(int x, int y)
        {
            PictureBox serit1 = new PictureBox();
            serit1.Size = new Size(30, 100);
            serit1.Name = "serit";
            serit1.BackColor = Color.White;
            serit1.Location = new Point(x, y);
            panel1.Controls.Add(serit1);
            serit1.SendToBack();
        }

        private void seritler_Tick(object sender, EventArgs e)
        {
            if (oyunbasladimi == true)
            {
                if (arachiz > 0)
                {
                    for (int i = 0; i < panel1.Controls.Count; i++)
                    {
                        if (panel1.Controls[i].Name == "serit")
                        {
                            PictureBox srt = (PictureBox)panel1.Controls[i];
                            if (srt.Location.Y > panel1.Height)
                            {
                                srt.Location = new Point(srt.Location.X, -1);
                            }
                            else
                            {
                                int deger = arachiz / 20;
                                srt.Location = new Point(srt.Location.X, srt.Location.Y + deger);
                            }
                        }
                    }
                }
                for (int i = 0; i < panel1.Controls.Count; i++)
                {
                    if (panel1.Controls[i].Name == "dusman")
                    {
                        PictureBox dsm = (PictureBox)panel1.Controls[i];

                        int karsilastirmadusmankonum = 0;
                        if (dsm.Location.X == 25)
                        {
                            karsilastirmadusmankonum = 0;
                        }
                        else if (dsm.Location.X == 205)
                        {
                            karsilastirmadusmankonum = 1;
                        }
                        else if (dsm.Location.X == 385)
                        {
                            karsilastirmadusmankonum = 2;
                        }
                        else if (dsm.Location.X == 565)
                        {
                            karsilastirmadusmankonum = 3;
                        }
                        //-
                        if (karsilastirmadusmankonum == arackonum)
                        {
                            if (arabam.Location.Y <= dsm.Location.Y + dsm.Height && arabam.Location.Y > dsm.Location.Y || dsm.Location.Y <= arabam.Location.Y + arabam.Height && dsm.Location.Y > arabam.Location.Y)
                            {
                                oyunu_kaybettin();
                            }
                        }

                        if (dsm.Location.Y > panel1.Height)
                        {
                            panel1.Controls.RemoveAt(i);
                            if (puansuresi < 20)
                            {
                                puan += 10;
                            }
                            else if (puansuresi > 20 && puansuresi < 40)
                            {
                                puan += 20;
                            }
                            else if (puansuresi > 40)
                            {
                                puan += 30;
                            }
                        }
                        else
                        {
                            int hiz = 0;
                            if (arachiz <= 20)
                            {
                                hiz = -1;
                            }
                            else if (arachiz > 20 && arachiz < 60)
                            {
                                hiz = 0;
                            }
                            else
                            {
                                hiz = arachiz / 18;
                            }
                            dsm.Location = new Point(dsm.Location.X, dsm.Location.Y + hiz);
                        }
                    }
                }
                for (int i = 0; i < panel1.Controls.Count; i++)
                {
                    if (panel1.Controls[i].Name == "polis")
                    {
                        PictureBox pls = (PictureBox)panel1.Controls[i];

                        if (arabam.Location.X == pls.Location.X)
                        {
                            if (arabam.Location.Y <= pls.Location.Y + pls.Height && arabam.Location.Y > pls.Location.Y || pls.Location.Y <= arabam.Location.Y + arabam.Height && pls.Location.Y > arabam.Location.Y)
                            {
                                oyunu_kaybettin();
                            }
                        }

                        if (pls.Location.Y > panel1.Height)
                        {
                            panel1.Controls.RemoveAt(i);
                            polisvarmi = false;
                            ses_polis.Ctlcontrols.stop();
                        }
                        else
                        {
                            int hiz = 0;
                            if (arachiz <= 20)
                            {
                                hiz = -1;
                            }
                            else if (arachiz > 20 && arachiz < 60)
                            {
                                hiz = 0;
                            }
                            else
                            {
                                hiz = arachiz / 18;
                            }
                            pls.Location = new Point(pls.Location.X, pls.Location.Y + hiz);
                        }
                    }
                }
            }
        }
        //-
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                ileri = false;
                ses_arabam.Ctlcontrols.stop();
            }

            if (e.KeyCode == Keys.Down)
            {
                yavasla = false;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                ileri = true;
            }

            if (e.KeyCode == Keys.Down)
            {
                yavasla = true;
            }

            if (e.KeyCode == Keys.Right)
            {
                saga_git();
            }
            if (e.KeyCode == Keys.Left)
            {
                sola_git();
            }
        }

        private void saga_git()
        {
            if (arackonum < 3)
            {
                sagagidis.Enabled = true;
                sagagidisadet = 0;
            }
        }
        int sagagidisadet;
        private void sagagidis_Tick(object sender, EventArgs e)
        {
            if (sagagidisadet == 4)
            {
                arackonum += 1;
            }
            if (sagagidisadet == 7)
            {
                sagagidis.Enabled = false;
                serit_degistir();
            }
            else
            {
                sagagidisadet++;
                arabam.Location = new Point(arabam.Location.X + 20, arabam.Location.Y);
            }
        }
        int solagidisadet;
        private void sola_git()
        {
            if (arackonum > 0)
            {
                solagidis.Enabled = true;
                solagidisadet = 0;
            }
        }
        private void solagidis_Tick(object sender, EventArgs e)
        {
            if (solagidisadet == 4)
            {
                arackonum -= 1;
            }
            if (solagidisadet == 7)
            {
                solagidis.Enabled = false;
                serit_degistir();
            }
            else
            {
                solagidisadet++;
                arabam.Location = new Point(arabam.Location.X - 20, arabam.Location.Y);
            }
        }

        private void serit_degistir()
        {
            if (arackonum == 0)
            {
                arabam.Location = new Point(25, arabam.Location.Y);
            }
            else if (arackonum == 1)
            {
                arabam.Location = new Point(205, arabam.Location.Y);
            }
            else if (arackonum == 2)
            {
                arabam.Location = new Point(385, arabam.Location.Y);
            }
            else if (arackonum == 3)
            {
                arabam.Location = new Point(565, arabam.Location.Y);
            }
        }

        int gazsesi = 0;
        private void hiztimer_Tick(object sender, EventArgs e)
        {
            if (polisvarmi == true)
            {
                if (arachiz > 150)
                {
                    puan -= 5;
                }
            }
            label2.Text = arachiz.ToString();
            if (ileri == true)
            {
                if (arachiz < 180)
                {
                    arachiz += 1;
                }

                if (ses_arabam.URL == Application.StartupPath + "\\dosyalar\\arac_ilerleme.mp3")
                {
                    if (ses_arabam.playState != WMPLib.WMPPlayState.wmppsPlaying)
                    {
                        ses_arabam.Ctlcontrols.play();
                        if (arachiz > 10 && arachiz < 180)
                        {
                            ses_arabam.Ctlcontrols.currentPosition = 8;
                        }
                    }
                    else
                    {
                        if (arachiz == 180)
                        {
                            if (ses_arabam.Ctlcontrols.currentPosition < 15)
                            {
                                ses_arabam.Ctlcontrols.currentPosition = 15;
                            }
                            if (ses_arabam.Ctlcontrols.currentPosition > 20)
                            {
                                ses_arabam.Ctlcontrols.currentPosition = 15;
                            }
                        }
                    }
                }
                else
                {
                    ses_arabam.Ctlcontrols.stop();
                    ses_arabam.URL = Application.StartupPath + "\\dosyalar\\arac_ilerleme.mp3";
                }
            }
            else if (ileri == false)
            {
                bosta.Start();
                if (yavasla == false)
                {
                    if (arachiz > 0)
                    {
                        if (ses_arabam.URL != Application.StartupPath + "\\dosyalar\\arac_sabithiz.mp3")
                        {
                            ses_arabam.URL = Application.StartupPath + "\\dosyalar\\arac_sabithiz.mp3";
                        }
                        else
                        {
                            if (ses_arabam.playState != WMPLib.WMPPlayState.wmppsPlaying)
                            {
                                ses_arabam.Ctlcontrols.play();
                            }
                        }
                    }
                    else
                    {
                        if (ses_arabam.URL == Application.StartupPath + "\\dosyalar\\arac_sabithiz.mp3")
                        {
                            ses_arabam.Ctlcontrols.stop();
                        }
                    }
                }
            }
            if (yavasla == true)
            {
                ileri = false;
                if (arachiz > 4)
                {
                    arachiz -= 4;
                }
                if (arachiz == 3 || arachiz == 2 || arachiz == 1)
                {
                    arachiz = 0;
                }
                if (arachiz > 0)
                {
                    if (ses_arabam.URL == Application.StartupPath + "\\dosyalar\\arac_fren.mp3")
                    {
                        if (ses_arabam.playState != WMPLib.WMPPlayState.wmppsPlaying)
                        {
                            ses_arabam.Ctlcontrols.play();
                            if (arachiz < 90 && arachiz > 0)
                            {
                                ses_arabam.Ctlcontrols.currentPosition = 1;
                            }
                        }
                    }
                    else
                    {
                        ses_arabam.URL = Application.StartupPath + "\\dosyalar\\arac_fren.mp3";
                    }
                }
                else
                {
                    ses_arabam.Ctlcontrols.stop();
                }
            }
        }

        private void bosta_Tick(object sender, EventArgs e)
        {
            bosta.Stop();
            if (arachiz >= 4)
            {
                arachiz -= 1;
            }
            if (arachiz == 3 || arachiz == 2 || arachiz == 1)
            {
                arachiz = 0;
            }
        }

        int gecensaniye = 0;
        int gecendakika = 0;
        string saniye;
        string dakika;

        float hizbolusaat = 0;
        int dusmansure = 0;
        int puansuresi = 0;
        private void sure_Tick(object sender, EventArgs e)
        {
            puansuresi += 1;
            //sure
            gecensaniye += 1;
            if (gecensaniye == 60)
            {
                gecensaniye = 0;
                gecendakika += 1;
            }
            if (gecensaniye < 10)
            {
                saniye = "0" + gecensaniye.ToString();
            }
            else
            {
                saniye = gecensaniye.ToString();
            }
            if (gecendakika < 10)
            {
                dakika = "0" + gecendakika.ToString();
            }
            else
            {
                dakika = gecendakika.ToString();
            }
            label4.Text = dakika + ":" + saniye;

            //alınan yol
            hizbolusaat += (arachiz * 1000) / 3600;
            label5.Text = hizbolusaat.ToString() + "m";

            label7.Text = puan.ToString();
            //dusman oluştur
            
            int engelkonumadedi = 0;
            if (dusmansure == 4)
            {
                engelkonumadedi = 0;
                for (int i = 0; i < panel1.Controls.Count; i++)
                {
                    if (panel1.Controls[i].Name == "dusman")
                    {
                        PictureBox dusmanknm = (PictureBox)panel1.Controls[i];
                        if (dusmanknm.Location.Y < 180)
                        {
                            engelkonumadedi++;
                        }
                    }
                }
                for (int i = 0; i < panel1.Controls.Count; i++)
                {
                    if (panel1.Controls[i].Name == "polis")
                    {
                        PictureBox dusmanknm3 = (PictureBox)panel1.Controls[i];
                        if (dusmanknm3.Location.Y < 180)
                        {
                            engelkonumadedi++;
                        }
                    }
                }
                if (engelkonumadedi == 0)
                {
                    dusmansure = 0;
                    dusman_araci_olustur();
                }
                else
                {
                    dusmansure = 3;
                }
            }
            else
            {
                dusmansure += 1;
            }
        }

        Random rnd = new Random();
        int dusmanadedim = 0;
        int randomsira;
        int randomsayim = 0;
        int uckontrol;
        private void konumrandomat()
        {
            randomsayim = rnd.Next(0, 4);
            uckontrol = 0;
            if (rand1 == randomsayim)
            {
                uckontrol++;
            }
            if (rand2 == randomsayim)
            {
                uckontrol++;
            }
            if (rand3 == randomsayim)
            {
                uckontrol++;
            }
            if (uckontrol == 0)
            {
                if (randomsira == 1)
                {
                    rand1 = randomsayim;
                }
                else if (randomsira == 2)
                {
                    rand2 = randomsayim;
                }
                else if (randomsira == 3)
                {
                    rand3 = randomsayim;
                }
            }
            else
            {
                konumrandomat();
            }
        }
        //-
        int rand1, rand2, rand3;
        private void dusman_araci_olustur()
        {
            //önceki randomu sıfırlamak
            rand1 = 5;
            rand2 = 5;
            rand3 = 5;
            randomsira = 0;
            //
            if (puansuresi < 10)
            {
                dusmanadedim = 1;
            }
            else if (puansuresi > 10 && puansuresi < 20)
            {
                dusmanadedim = 2;
            }
            else if (puansuresi > 20)
            {
                dusmanadedim = 3;
            }
            for (int i = 0; i < dusmanadedim; i++)
            {
                PictureBox dusman = new PictureBox();
                dusman.Size = new Size(100, 170);
                int x = 0;
                randomsira++;
                konumrandomat();
                x = randomsayim;
                if (x == 0)
                {
                    x = 25;
                }
                else if (x == 1)
                {
                    x = 205;
                }
                else if (x == 2)
                {
                    x = 385;
                }
                else if (x == 3)
                {
                    x = 565;
                }
                int arac = rnd.Next(0, 10);
                if (arac == 0)
                {
                    dusman.Image = traffic_racer.Properties.Resources.arac1;
                }
                else if (arac == 1)
                {
                    dusman.Image = traffic_racer.Properties.Resources.arac2;
                }
                else if (arac == 2)
                {
                    dusman.Image = traffic_racer.Properties.Resources.arac3;
                }
                else if (arac == 3)
                {
                    dusman.Image = traffic_racer.Properties.Resources.arac4;
                }
                else if (arac == 4)
                {
                    dusman.Image = traffic_racer.Properties.Resources.arac5;
                }
                else if (arac == 5)
                {
                    dusman.Image = traffic_racer.Properties.Resources.arac6;
                }
                else if (arac == 6)
                {
                    dusman.Image = traffic_racer.Properties.Resources.arac7;
                }
                else if (arac == 7)
                {
                    dusman.Image = traffic_racer.Properties.Resources.arac8;
                }
                else if (arac == 8)
                {
                    dusman.Image = traffic_racer.Properties.Resources.arac9;
                }
                else if (arac == 9)
                {
                    dusman.Image = traffic_racer.Properties.Resources.arac10;
                }
                dusman.Location = new Point(x, 0);
                dusman.Name = "dusman";
                dusman.SizeMode = PictureBoxSizeMode.StretchImage;
                panel1.Controls.Add(dusman);
                dusman.BringToFront();
            }
        }

        bool polisvarmi = false;
        int polissiren = 0;
        int polisengelkonumadedi = 0;
        private void polisolustur_Tick(object sender, EventArgs e)
        {
            if (polissiren == 0)
            {
                polissiren = 1;

                polisolustur.Interval = 5000;
                ses_polis.URL = Application.StartupPath + "\\dosyalar\\polisuyari.mp3";
                ses_polis.Ctlcontrols.play();
            }
            else
            {
                polisengelkonumadedi = 0;
                for (int i = 0; i < panel1.Controls.Count; i++)
                {
                    if (panel1.Controls[i].Name == "dusman")
                    {
                        PictureBox dusmanknm2 = (PictureBox)panel1.Controls[i];

                        if (dusmanknm2.Location.Y < 180)
                        {
                            polisengelkonumadedi++;
                        }
                    }
                }
                if (polisengelkonumadedi == 0)
                {
                    polissiren = 0;
                    polis_olustur();
                    polisolustur.Interval = 25000;
                }
                else
                {
                    polisolustur.Interval = 1000;
                }
            }
        }

        private void polis_olustur()
        {
            PictureBox polis = new PictureBox();
            polis.Size = new Size(100, 170);
            int x = rnd.Next(0, 4);
            if (x == 0)
            {
                x = 25;
            }
            else if (x == 1)
            {
                x = 205;
            }
            else if (x == 2)
            {
                x = 385;
            }
            else if (x == 3)
            {
                x = 565;
            }
            polis.Image = traffic_racer.Properties.Resources.polis;
            polis.Location = new Point(x, 0);
            polis.Name = "polis";
            polis.SizeMode = PictureBoxSizeMode.StretchImage;
            ses_polis.URL = Application.StartupPath + "\\dosyalar\\polissiren.mp3";
            ses_polis.Ctlcontrols.play();
            panel1.Controls.Add(polis);
            polis.BringToFront();

            polisvarmi = true;
        }

        private void oyunu_kaybettin()
        {
            seritlertimer.Enabled = false;
            hiztimer.Enabled = false;
            sure.Enabled = false;
            polisolustur.Enabled = false;
            bosta.Enabled = false;
            yavaslat.Enabled = false;

            axWindowsMediaPlayer1.Ctlcontrols.stop();
            ses_polis.Ctlcontrols.stop();
            ses_arabam.Ctlcontrols.stop();

            ses_arabam.URL = Application.StartupPath + "\\dosyalar\\kaybettin.mp3";
            ses_arabam.Ctlcontrols.play();
            MessageBox.Show("Oyunu kaybettin!", "");

            puan_kaydet pn = new puan_kaydet();
            pn.stpuan = puan.ToString();
            pn.stsure = label4.Text;
            pn.Show();
            this.Hide();
        }
    }
}
