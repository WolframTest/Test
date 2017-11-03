using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmailBot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
//01
            InitializeComponent();
        }

        private void Send(string email, int i)
        {
            try
            {

                MailAddress from = new MailAddress("monitorgame25@gmail.com", "MonitorGame");
                MailAddress to = new MailAddress(email);
                MailMessage m = new MailMessage(from, to);
                m.Subject = "Новая игра!";
                m.Body = "01.02 стартовали 2 новых игры! \r\n https://goo.gl/EZsR1i - Смешарики. \r\n https://goo.gl/DJegdD - WARDING RUNE. \r\n В обеих играх 3-уровневая реферальная система!";
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);

                smtp.Credentials = new NetworkCredential("monitorgame25@gmail.com", "s1b1y2monitor96");
                smtp.EnableSsl = true;
                smtp.Send(m);
            }
            catch
            {
                MessageBox.Show(i.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string FileName = openFileDialog1.FileName;
            FileStream stream = File.Open(FileName, FileMode.Open, FileAccess.Read);
            if (stream != null)
            {
                StreamReader reader = new StreamReader(stream, Encoding.Default);
                for (int i = 0; !reader.EndOfStream; i++)
                {
                    string email = reader.ReadLine();
                    //MessageBox.Show(email);
                    Send(email, i);
                    if (i % 200 == 0)
                        MessageBox.Show(i + " files have sent");
                }
                stream.Close();
            }
            
        }
    }
}
