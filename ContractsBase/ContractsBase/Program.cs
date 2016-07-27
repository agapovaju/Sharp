using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContractsBase
{
    
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        public static void SendMail(string message)
        {
            try
            {
                string[] configFile = File.ReadAllLines("config.txt");
                string emailFrom = "ASKID@omg.transneft.ru"; //configFile.Where(s => s.StartsWith("EmailFrom=")).First().Substring(10);
                string emailFromPass = "mkoldA1991"; //configFile.Where(s => s.StartsWith("EmailFromPassword=")).First().Substring(18);

                List<string> mailtoList = new List<string>();
                int indexStart = Array.IndexOf(configFile, "EmailToStart") + 1;
                int indexEnd = Array.IndexOf(configFile, "EmailToEnd");
                for (int i = indexStart; i < indexEnd; i++) mailtoList.Add(configFile[i]);


                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(emailFrom);
                foreach (string mailTo in mailtoList) mail.To.Add(new MailAddress(mailTo));
                mail.Subject = "АСКИД. Новые документы.";
                mail.Body = message;
                //if (!string.IsNullOrEmpty(attachFile))
                //    mail.Attachments.Add(new Attachment(attachFile));
                SmtpClient client = new SmtpClient();
                client.Host = "vom01-pimsg--01.ome.tn.corp";
                client.Port = 25;
                client.EnableSsl = false;
                client.Credentials = new NetworkCredential("agapovay@omg.transneft.ru", emailFromPass);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                MessageBox.Show(message);
                //client.Send(mail);
                mail.Dispose();
            }
            catch (Exception e)
            {
                throw new Exception("Mail.Send: " + e.Message);
            }
        }
    }
}

