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
using System.Media;

namespace traffic_racer
{
    public partial class multiplayerset : Form
    {
        public multiplayerset()
        {
            InitializeComponent();

            sck = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            txtyerelip.Text = GetLocalIP();
            //txtrakipip.Text = GetLocalIP();
        }

        public string rakipadi;
        public string serverkim;

        // 0 durumum, 1 konumum.x, 2 arac1 koordinat, 3 arac2 koordinat, 4 arac3 koordinat, 5 polis koordinat, 6 rakip puan, 7 rakip aldığı yol

        int benhazirmi = 0;
        int rakiphazirmi = 0;

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

        string gelen;
        public string aktarilacakrakipbilgi;
        private void MessageCallBack(IAsyncResult aResult)
        {
            try
            {
                int size = sck.EndReceiveFrom(aResult, ref epRemote);
                if (size > 0)
                {
                    byte[] receiveData = new byte[1464];
                    receiveData = (byte[])aResult.AsyncState;
                    UTF8Encoding enc = new UTF8Encoding();
                    string receiveM = enc.GetString(receiveData);
                    aktarilacakrakipbilgi = receiveM;
                    listBox2.Items.Clear();

                    listBox2.Items.AddRange(receiveM.Split('/'));
                    for (int i = 0; i < 10; i++)
                    {
                        try
                        {
                            try
                            {
                                listBox1.Items[i] = listBox2.Items[i];
                            }
                            catch
                            {
                            }

                            try
                            {
                                if (i == 0)
                                {
                                    traffic_racer.Properties.Settings.Default.aktarilacakbilgiler1 = listBox1.Items[i].ToString();
                                }
                                if (i == 1)
                                {
                                    traffic_racer.Properties.Settings.Default.aktarilacakbilgiler2 = listBox1.Items[i].ToString();
                                }
                                if (i == 2)
                                {
                                    traffic_racer.Properties.Settings.Default.aktarilacakbilgiler3 = listBox1.Items[i].ToString();
                                }
                                if (i == 3)
                                {
                                    traffic_racer.Properties.Settings.Default.aktarilacakbilgiler4 = listBox1.Items[i].ToString();
                                }
                                if (i == 4)
                                {
                                    traffic_racer.Properties.Settings.Default.aktarilacakbilgiler5 = listBox1.Items[i].ToString();
                                }
                                if (i == 5)
                                {
                                    traffic_racer.Properties.Settings.Default.aktarilacakbilgilerpolis = listBox1.Items[i].ToString();
                                }
                                if (i == 6)
                                {
                                    traffic_racer.Properties.Settings.Default.rakippuani = listBox1.Items[i].ToString();
                                }
                                if (i == 7)
                                {
                                    traffic_racer.Properties.Settings.Default.rakipyol = listBox1.Items[i].ToString();
                                }
                            }
                            catch (Exception)
                            {
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }
                    gelen = receiveM;
                }
                byte[] buffer = new byte[1500];
                sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);
                try
                {
                    if (asama == 1)
                    {
                        asama = 2;
                        try
                        {
                            rakipadi = listBox1.Items[0].ToString();
                        }
                        catch
                        {
                        }
                        try
                        {
                            traffic_racer.Properties.Settings.Default.rakiparaci = listBox1.Items[1].ToString();
                        }
                        catch
                        {
                        }
                    }
                }
                catch (Exception)
                {
                }
                if (listBox1.Items[2].ToString() == "oyuncu1")
                {
                    radioButton1.Enabled = false;
                    radioButton2.Enabled = true;
                }
                else if (listBox1.Items[2].ToString() == "oyuncu2")
                {
                    radioButton1.Enabled = true;
                    radioButton2.Enabled = false;
                }

                try
                {
                    rakiphazirmi = Convert.ToInt32(listBox1.Items[3].ToString());
                }
                catch (Exception)
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("hata3" + ex.Message);
            }
        }

        Socket sck;
        EndPoint epLocal, epRemote;
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                epLocal = new IPEndPoint(IPAddress.Parse(txtyerelip.Text), Convert.ToInt32(txtyerelport.Text));
                sck.Bind(epLocal);
                epRemote = new IPEndPoint(IPAddress.Parse(txtrakipip.Text), Convert.ToInt32(txtrakipport.Text));
                sck.Connect(epRemote);
                byte[] buffer = new byte[1500];
                sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);
                button2.Text = "Adres Kaydedildi";
                button2.Enabled = false;
                button5.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("hata4" + ex.Message);
            }
        }

        string mesaj;
        private void gonder_Tick(object sender, EventArgs e)
        {
            gonder.Enabled = false;
            mesaj = txtyerelisim.Text + "/" + arac_secimi.ToString();
            if (radioButton1.Checked == true)
            {
                mesaj += "/" + "oyuncu1";
            }
            if (radioButton2.Checked == true)
            {
                mesaj += "/" + "oyuncu2";
            }
            if (radioButton1.Checked != true && radioButton2.Checked != true)
            {
                mesaj = "secilmemis";
            }
            mesaj += "/" + benhazirmi;
            try
            {
                UTF8Encoding enc = new UTF8Encoding();
                byte[] msg = new byte[1500];
                msg = enc.GetBytes(mesaj);
                sck.Send(msg);
                listmesaj.Items.Clear();
                listmesaj.Items.Add("You: " + mesaj);
            }
            catch (Exception ex)
            {
                MessageBox.Show("hata5" + ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtyerelisim.Text == "")
            {
                MessageBox.Show("Lütfen isim girin.", "");
            }
            else
            {
                if (radioButton1.Checked == false && radioButton2.Checked == false)
                {
                    MessageBox.Show("Lütfen taraf seçin.", "");
                }
                else
                {
                    Properties.Settings.Default.aracno = arac_secimi.ToString();
                    benhazirmi = 1;

                    txtyerelisim.Enabled = false;
                    radioButton1.Enabled = false;
                    radioButton2.Enabled = false;

                    gonder.Enabled = true;
                }
            }
        }

        int arac_secimi;
        private void multiplayerset_Load(object sender, EventArgs e)
        {
            arac_secimi = 1;
            pic_secim.Location = new Point(300, 112);
            pictureBox1.Image = traffic_racer.Properties.Resources.arac1;
        }

        private void multiplayerset_FormClosing(object sender, FormClosingEventArgs e)
        {
            anamenu frm = new anamenu();
            frm.Show();
        }

        int asama = 1;

        private void multiplayerset_KeyDown(object sender, KeyEventArgs e)
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
            catch
            {
            }
            Thread.Sleep(250);
            if (arac_secimi == 1)
            {
                pic_secim.Location = new Point(300, 112);
                pictureBox1.Image = traffic_racer.Properties.Resources.arac1;
            }
            else if (arac_secimi == 2)
            {
                pic_secim.Location = new Point(365, 112);
                pictureBox1.Image = traffic_racer.Properties.Resources.arac2;
            }
            else if (arac_secimi == 3)
            {
                pic_secim.Location = new Point(430, 112);
                pictureBox1.Image = traffic_racer.Properties.Resources.arac3;
            }
            else if (arac_secimi == 4)
            {
                pic_secim.Location = new Point(495, 112);
                pictureBox1.Image = traffic_racer.Properties.Resources.arac4;
            }
            else if (arac_secimi == 5)
            {
                pic_secim.Location = new Point(560, 112);
                pictureBox1.Image = traffic_racer.Properties.Resources.arac5;
            }
            else if (arac_secimi == 6)
            {
                pic_secim.Location = new Point(300, 255);
                pictureBox1.Image = traffic_racer.Properties.Resources.arac6;
            }
            else if (arac_secimi == 7)
            {
                pic_secim.Location = new Point(365, 255);
                pictureBox1.Image = traffic_racer.Properties.Resources.arac7;
            }
            else if (arac_secimi == 8)
            {
                pic_secim.Location = new Point(430, 255);
                pictureBox1.Image = traffic_racer.Properties.Resources.arac8;
            }
            else if (arac_secimi == 9)
            {
                pic_secim.Location = new Point(495, 255);
                pictureBox1.Image = traffic_racer.Properties.Resources.arac9;
            }
            else if (arac_secimi == 10)
            {
                pic_secim.Location = new Point(560, 255);
                pictureBox1.Image = traffic_racer.Properties.Resources.arac10;
            }
        }

        SoundPlayer secim_sesim = new SoundPlayer(Application.StartupPath + "\\dosyalar\\car_change_sound.wav");
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            secim_sesim.PlaySync();
        }

        protected override bool IsInputKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Right:
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                    return true;
                case Keys.Shift | Keys.Right:
                case Keys.Shift | Keys.Left:
                case Keys.Shift | Keys.Up:
                case Keys.Shift | Keys.Down:
                    return true;
            }
            return base.IsInputKey(keyData);
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            switch (e.KeyCode)
            {
                case Keys.Left:
                case Keys.Right:
                case Keys.Up:
                case Keys.Down:
                    if (e.Shift)
                    {

                    }
                    else
                    {
                    }
                    break;
            }
        }

        private void oyunbaslatici_Tick(object sender, EventArgs e)
        {
            if (benhazirmi + rakiphazirmi == 2)
            {
                oyunbaslatici.Enabled = false;
                if (radioButton1.Checked == true)
                {
                    serverkim = "ben";
                }
                else
                {
                    serverkim = "rakip";
                }
                form1multiplayer gecis = new form1multiplayer();

                gecis.yerelip = txtyerelip.Text;
                gecis.yerelport = txtyerelport.Text;
                gecis.rakipip = txtrakipip.Text;
                gecis.rakipport = txtrakipport.Text;

                traffic_racer.Properties.Settings.Default.rakipad = rakipadi;
                traffic_racer.Properties.Settings.Default.benad = txtyerelisim.Text;
                gecis.serverrkim = serverkim;
                Thread.Sleep(300);
                gecis.Show();
                this.Hide();
            }
        }
    }
}