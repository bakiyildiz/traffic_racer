using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

namespace traffic_racer
{
    public partial class puan_kaydet : Form
    {
        public puan_kaydet()
        {
            InitializeComponent();
        }

        public string stpuan;
        public string stsure;

        SqlConnection baglantim = new SqlConnection(@"Data Source=EXCALIBUR\SQLEXPRESS;Initial Catalog=puanlar;Integrated Security=SSPI");
        SqlCommand cmd;
        anamenu anm = new anamenu();
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (checkBox1.Checked == true)
                {
                    if (textBox2.Text == "")
                    {
                        MessageBox.Show("Lütfen mail adresinizi girin!", "");
                    }
                    else
                    {
                        cmd = new SqlCommand();
                        baglantim.Open();
                        cmd.Connection = baglantim;
                        cmd.CommandText = "Insert into puantablo VALUES('" + textBox1.Text + "','" + stpuan + "','" + stsure + "','" + DateTime.Now.ToString() + "')";
                        cmd.ExecuteNonQuery();
                        baglantim.Close();

                        mail_gonder.RunWorkerAsync();
                    }
                }
                else
                {
                    cmd = new SqlCommand();
                    baglantim.Open();
                    cmd.Connection = baglantim;
                    cmd.CommandText = "Insert into puantablo VALUES('" + textBox1.Text + "','" + stpuan + "','" + stsure + "','" + DateTime.Now.ToString() + "')";
                    cmd.ExecuteNonQuery();
                    baglantim.Close();

                    MessageBox.Show("Kayıt başarılı.", "");

                    anm.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Lütfen isim girin!", "");
            }
        }

        private void puan_kaydet_FormClosing(object sender, FormClosingEventArgs e)
        {
            anm.Show();
            this.Hide();
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                this.Size = new Size(251, 160);
            }
            else
            {
                this.Size = new Size(251, 102);
            }
        }

        private void mail_gonder_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                MailMessage email = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";

                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("mailusername@gmail.com", "mailpassword");
                //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                //smtp.UseDefaultCredentials = false;

                MailAddress fromAddress = new MailAddress("mailusername@gmail.com");
                email.From = fromAddress;
                email.To.Add(textBox2.Text);
                email.Subject = "Puanınız";
                email.Body = "Sayın " + textBox1.Text + Environment.NewLine + "Puanınız: " + stpuan + Environment.NewLine + "Oynanan süre: " + stsure + Environment.NewLine + "Tarih: " + DateTime.Now.ToString();

                smtp.Send(email);

                MessageBox.Show("Mail başarıyla gönderildi, kayıt başarıyla gerçekleştirildi.", "");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mail gönderilirken sorun oluştu! " + Environment.NewLine + Environment.NewLine + ex.Message, "");
            }
        }

        private void mail_gonder_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            anm.Show();
            this.Hide();
        }
    }
}
