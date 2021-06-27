using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace traffic_racer
{
    public partial class form1multiplayer : Form
    {
        public form1multiplayer()
        {
            InitializeComponent();

            scka = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            scka.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
        }

        /// ///
        /// 
        bool oyunbasladimi = true;
        bool ileri;
        bool yavasla;
        int arachiz = 0;
        int arackonum = 1;
        int puan = 0;

        public string yerelip, yerelport, rakipip, rakipport;

        string gelenrakiptekidusman1 = "0";
        string gelenrakiptekidusman2 = "0";
        string gelenrakiptekidusman3 = "0";
        string polisnewkonum = "0";

        public string rakippuans;
        public string rakipyols;
        /// ///
        /// 
        private string GetLocalIP()
        {
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    return ip.ToString();
            }
            return "127.0.0.1";
        }

        Socket scka;
        EndPoint epLocal, epRemote;
        private void form1multiplayer_Load(object sender, EventArgs e)
        {
            traffic_racer.Properties.Settings.Default.sonucduruma = "1";
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

            multiplayerset msd = new multiplayerset();
            if (traffic_racer.Properties.Settings.Default.rakiparaci == "1")
            {
                rakiparac.Image = traffic_racer.Properties.Resources.arac1;
            }
            else if (traffic_racer.Properties.Settings.Default.rakiparaci == "2")
            {
                rakiparac.Image = traffic_racer.Properties.Resources.arac2;
            }
            else if (traffic_racer.Properties.Settings.Default.rakiparaci == "3")
            {
                rakiparac.Image = traffic_racer.Properties.Resources.arac3;
            }
            else if (traffic_racer.Properties.Settings.Default.rakiparaci == "4")
            {
                rakiparac.Image = traffic_racer.Properties.Resources.arac4;
            }
            else if (traffic_racer.Properties.Settings.Default.rakiparaci == "5")
            {
                rakiparac.Image = traffic_racer.Properties.Resources.arac5;
            }
            else if (traffic_racer.Properties.Settings.Default.rakiparaci == "6")
            {
                rakiparac.Image = traffic_racer.Properties.Resources.arac6;
            }
            else if (traffic_racer.Properties.Settings.Default.rakiparaci == "7")
            {
                rakiparac.Image = traffic_racer.Properties.Resources.arac7;
            }
            else if (traffic_racer.Properties.Settings.Default.rakiparaci == "8")
            {
                rakiparac.Image = traffic_racer.Properties.Resources.arac8;
            }
            else if (traffic_racer.Properties.Settings.Default.rakiparaci == "9")
            {
                rakiparac.Image = traffic_racer.Properties.Resources.arac9;
            }
            else if (traffic_racer.Properties.Settings.Default.rakiparaci == "10")
            {
                rakiparac.Image = traffic_racer.Properties.Resources.arac10;
            }

            rakiparac.BringToFront();
            arabam.BringToFront();
            sureklidusmankonumyenile.Enabled = true;

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

            polisolustur.Enabled = true;

            seritlertimer.Enabled = true;
            hiztimer.Enabled = true;
            sure.Enabled = true;
            serit_degistir();
            ses_arabam.URL = Application.StartupPath + "\\dosyalar\\baslangic.mp3";
            ses_arabam.Ctlcontrols.play();


            try
            {
                epLocal = new IPEndPoint(IPAddress.Parse(yerelip), Convert.ToInt32(yerelport));
                scka.Bind(epLocal);
                epRemote = new IPEndPoint(IPAddress.Parse(rakipip), Convert.ToInt32(rakipport));
                scka.Connect(epRemote);
                byte[] buffer = new byte[1500];
                //scka.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);
            }
            catch (Exception)
            {
            }

            bilgigonder.Enabled = true;
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

        private void seritlertimer_Tick(object sender, EventArgs e)
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

        private void form1multiplayer_KeyUp(object sender, KeyEventArgs e)
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

        private void form1multiplayer_KeyDown(object sender, KeyEventArgs e)
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

        int rand1, rand2, rand3;

        public string serverrkim;

        private void dusman_araci_olustur()
        {
            //önceki randomu sıfırlamak
            rand1 = 5;
            rand2 = 5;
            rand3 = 5;
            randomsira = 0;
            //
            if (puansuresi < 20)
            {
                dusmanadedim = 1;
            }
            else if (puansuresi > 20 && puansuresi < 40)
            {
                dusmanadedim = 2;
            }
            else if (puansuresi > 40)
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

        private void sureklidusmankonumyenile_Tick(object sender, EventArgs e)
        {
            try
            {
                dusmankonumlandir();
            }
            catch
            {
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

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // 0 durumum, 1 konumum.x, 2 arac1 koordinat, 3 arac2 koordinat, 4 arac3 koordinat, 5 polis koordinat, 6 rakip puan, 7 rakip yol

            kkontrol = "0";
            kkontroladet = "1";
            for (int i = 0; i < panel1.Controls.Count; i++)
            {
                if (panel1.Controls[i].Name == "dusman")
                {
                    PictureBox dsm = (PictureBox)panel1.Controls[i];

                    if (kkontroladet == "1")
                    {
                        try
                        {
                            garac1 = dsm.Location.X.ToString();
                        }
                        catch (Exception)
                        {
                        }
                        kkontroladet = "2";
                    }
                    else if (kkontroladet == "2")
                    {
                        try
                        {
                            garac2 = dsm.Location.X.ToString();
                        }
                        catch (Exception)
                        {
                        }
                        kkontroladet = "3";
                    }
                    else if (kkontroladet == "3")
                    {
                        try
                        {
                            garac3 = dsm.Location.X.ToString();
                        }
                        catch (Exception)
                        {
                        }
                        kkontroladet = "4";
                    }
                }
                if (panel1.Controls[i].Name == "polis")
                {
                    PictureBox dsm = (PictureBox)panel1.Controls[i];
                    gpolis = dsm.Location.X.ToString();
                }
            }
            mesaj = traffic_racer.Properties.Settings.Default.sonucduruma + "/" + arabam.Location.X + "/" + garac1 + "/" + garac2 + "/" + garac3 + "/" + gpolis + "/" + puan.ToString() + "/" + hizbolusaat;
            label9.Text = traffic_racer.Properties.Settings.Default.sonucduruma + Environment.NewLine + arabam.Location.X + Environment.NewLine + garac1 + Environment.NewLine + garac2 + Environment.NewLine + garac3 + Environment.NewLine + gpolis + Environment.NewLine + puan.ToString() + Environment.NewLine + hizbolusaat;
            try
            {
                UTF8Encoding enc = new UTF8Encoding();
                byte[] msg = new byte[2045];
                msg = enc.GetBytes(mesaj);
                scka.Send(msg);
                listBox2.Items.Clear();
                listBox2.Items.Add("You: " + mesaj);
            }
            catch (Exception ex)
            {
                MessageBox.Show("hata2" + ex.Message);
            }
            // //
            if (traffic_racer.Properties.Settings.Default.aktarilacakbilgiler1 == "")
            {
                traffic_racer.Properties.Settings.Default.aktarilacakbilgiler1 = " ";
            }
            if (traffic_racer.Properties.Settings.Default.aktarilacakbilgiler2 == "")
            {
                traffic_racer.Properties.Settings.Default.aktarilacakbilgiler2 = " ";
            }
            if (traffic_racer.Properties.Settings.Default.aktarilacakbilgiler3 == "")
            {
                traffic_racer.Properties.Settings.Default.aktarilacakbilgiler3 = " ";
            }
            if (traffic_racer.Properties.Settings.Default.aktarilacakbilgiler4 == "")
            {
                traffic_racer.Properties.Settings.Default.aktarilacakbilgiler4 = " ";
            }
            if (traffic_racer.Properties.Settings.Default.aktarilacakbilgiler5 == "")
            {
                traffic_racer.Properties.Settings.Default.aktarilacakbilgiler5 = " ";
            }
            if (traffic_racer.Properties.Settings.Default.aktarilacakbilgilerpolis == "")
            {
                traffic_racer.Properties.Settings.Default.aktarilacakbilgilerpolis = " ";
            }
            if (traffic_racer.Properties.Settings.Default.rakippuani == "")
            {
                traffic_racer.Properties.Settings.Default.rakippuani = " ";
            }
            if (traffic_racer.Properties.Settings.Default.rakipyol == "")
            {
                traffic_racer.Properties.Settings.Default.rakipyol = " ";
            }
            if (traffic_racer.Properties.Settings.Default.benad == "")
            {
                traffic_racer.Properties.Settings.Default.benad = " ";
            }
            if (traffic_racer.Properties.Settings.Default.rakipad == "")
            {
                traffic_racer.Properties.Settings.Default.rakipad = " ";
            }
            if (traffic_racer.Properties.Settings.Default.sonucsure == "")
            {
                traffic_racer.Properties.Settings.Default.sonucsure = " ";
            }
            if (traffic_racer.Properties.Settings.Default.sonucduruma == "")
            {
                traffic_racer.Properties.Settings.Default.sonucduruma = " ";
            }
            if (traffic_racer.Properties.Settings.Default.sonucdurumb == "")
            {
                traffic_racer.Properties.Settings.Default.sonucdurumb = " ";
            }
            if (traffic_racer.Properties.Settings.Default.sonucpuan == "")
            {
                traffic_racer.Properties.Settings.Default.sonucpuan = " ";
            }
            // //
            textBox1.Text = traffic_racer.Properties.Settings.Default.aktarilacakbilgiler1 + "/" + traffic_racer.Properties.Settings.Default.aktarilacakbilgiler2 + "/" + traffic_racer.Properties.Settings.Default.aktarilacakbilgiler3 + "/" + traffic_racer.Properties.Settings.Default.aktarilacakbilgiler4 + "/" + traffic_racer.Properties.Settings.Default.aktarilacakbilgiler5 + "/" + traffic_racer.Properties.Settings.Default.aktarilacakbilgilerpolis + "/" + puan + "/" + hizbolusaat;

            try
            {
                listBox3.Items.Clear();
                listBox3.Items.AddRange(textBox1.Text.Split('/'));
            }
            catch
            {
            }
            try
            {
                traffic_racer.Properties.Settings.Default.sonucdurumb = listBox3.Items[0].ToString();
                label10.Text = traffic_racer.Properties.Settings.Default.sonucdurumb;
                
            }
            catch
            {
            }
            try
            {
                rakiparac.Location = new Point(Convert.ToInt32(listBox3.Items[1].ToString()), rakiparac.Location.Y);
            }
            catch
            {
            }
            try
            {
                gelenrakiptekidusman1 = listBox3.Items[2].ToString();
            }
            catch
            {
            }
            try
            {
                gelenrakiptekidusman2 = listBox3.Items[3].ToString();
            }
            catch
            {
            }
            try
            {
                gelenrakiptekidusman3 = listBox3.Items[4].ToString();
            }
            catch
            {
            }
            try
            {
                polisnewkonum = listBox3.Items[5].ToString();
            }
            catch
            {
            }
            try
            {
                rakippuans = listBox3.Items[6].ToString();
            }
            catch
            {
            }
            try
            {
                rakipyols = listBox3.Items[7].ToString();
            }
            catch
            {
            }
        }

        private void oyunu_kaybettin()
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            ses_polis.Ctlcontrols.stop();
            ses_arabam.Ctlcontrols.stop();

            traffic_racer.Properties.Settings.Default.sonucduruma = "0";

            ses_arabam.URL = Application.StartupPath + "\\dosyalar\\kaybettin.mp3";
            ses_arabam.Ctlcontrols.play();

            mulltibitir();
        }

        private void oyunbittimi_Tick(object sender, EventArgs e)
        {
            if (traffic_racer.Properties.Settings.Default.sonucdurumb == "0")
            {
                axWindowsMediaPlayer1.Ctlcontrols.stop();
                ses_polis.Ctlcontrols.stop();
                ses_arabam.Ctlcontrols.stop();
                oyunbittimi.Enabled = false;
                hiztimer.Enabled = false;
                sure.Enabled = false;
                polisolustur.Enabled = false;
                bosta.Enabled = false;
                yavaslat.Enabled = false;
                sureklidusmankonumyenile.Enabled = false;
                seritlertimer.Enabled = false;
                bilgigonder.Enabled = false;
                traffic_racer.Properties.Settings.Default.sonucsure = label4.Text;
                traffic_racer.Properties.Settings.Default.sonucpuan = label7.Text;
                MessageBox.Show("Oyun Bitti", "");
                
                multiplayersonuc mls = new multiplayersonuc();
                mls.Show();
                this.Hide();
            }
        }

        private void form1multiplayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            oyunu_kaybettin();
        }

        void mulltibitir()
        {
            hiztimer.Enabled = false;
            sure.Enabled = false;
            polisolustur.Enabled = false;
            bosta.Enabled = false;
            yavaslat.Enabled = false;
            sureklidusmankonumyenile.Enabled = false;
            seritlertimer.Enabled = false;
            bilgigonder.Enabled = false;
            try
            {
                backgroundWorker1.RunWorkerAsync();
            }
            catch
            {
            }
            traffic_racer.Properties.Settings.Default.sonucsure = label4.Text;
            traffic_racer.Properties.Settings.Default.sonucpuan = label7.Text;
            Thread.Sleep(500);
            MessageBox.Show("Oyun Bitti", "");
            oyunbittimi.Enabled = false;
            multiplayersonuc mls = new multiplayersonuc();
            mls.Show();
            this.Hide();
        }

        string mesaj;
        string garac1, garac2, garac3, gpolis, kkontrol, kkontroladet;
        private void bilgigonder_Tick(object sender, EventArgs e)
        {
            try
            {
                backgroundWorker1.CancelAsync();
                backgroundWorker1.RunWorkerAsync();
            }
            catch
            {
            }
        }
        string baskakontroladet;
        void dusmankonumlandir()
        {
            if (serverrkim != "ben")
            {
                baskakontroladet = "1";
                for (int i = 0; i < panel1.Controls.Count; i++)
                {
                    if (panel1.Controls[i].Name == "dusman")
                    {
                        PictureBox dsm = (PictureBox)panel1.Controls[i];

                        if (baskakontroladet == "1")
                        {
                            try
                            {
                                dsm.Location = new Point(Convert.ToInt32(gelenrakiptekidusman1), dsm.Location.Y);
                            }
                            catch
                            {
                            }
                            baskakontroladet = "2";
                        }
                        else if (baskakontroladet == "2")
                        {
                            try
                            {
                                dsm.Location = new Point(Convert.ToInt32(gelenrakiptekidusman2), dsm.Location.Y);
                            }
                            catch
                            {
                            }
                            baskakontroladet = "3";
                        }
                        else if (baskakontroladet == "3")
                        {
                            try
                            {
                                dsm.Location = new Point(Convert.ToInt32(gelenrakiptekidusman3), dsm.Location.Y);
                            }
                            catch
                            {
                            }
                        }
                    }
                }

                for (int i = 0; i < panel1.Controls.Count; i++)
                {
                    if (panel1.Controls[i].Name == "polis")
                    {
                        PictureBox pls = (PictureBox)panel1.Controls[i];
                        pls.Location = new Point(Convert.ToInt32(polisnewkonum), pls.Location.Y);
                    }
                }
            }
        }
    }
}