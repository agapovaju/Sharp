using System;
using System.Linq;
using System.IO;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;

namespace ContractsReport
{
    class Program
    {
        static void Main(string[] args)
        {
            if(!File.Exists("config.txt"))
            {
                Console.WriteLine("Файл config.txt не найден!");
                Console.ReadLine();
            }
            string strConn = File.ReadAllLines("config.txt").Where(s => s.StartsWith("ConnectionString=")).First();
            SqlConnection connection = new SqlConnection(strConn.Substring(17));

            try
            {
                

                DateTime dateStart = DateTime.Now.AddDays(-1);
                //DATEADD(day, -1, GETDATE())

                string strCommand = String.Format(
                   // данные контрактов
                   "SELECT Contracts.Date_add, ContKinds.Kind, Contracts.Name, Contracts.Name, CStaff.Name , " +
                        "(SELECT Contractors.Name + ', ' " +
                        "FROM Contractors_Cont CC1 INNER JOIN Contractors ON CC1.Id_contractor = Contractors.Id_contractor " +
                        "WHERE CC1.Id_cont=CC2.Id_cont FOR xml path('') ) " +
                    "FROM Contracts " +
                        "INNER JOIN ContKinds ON Contracts.Id_kind = ContKinds.Id_kind " +
                        "INNER JOIN Staff AS CStaff ON Contracts.Id_staff = CStaff.Id_staff " +
                        "INNER JOIN Blocks ON CStaff.Id_block = Blocks.Id_block " +
                        "INNER JOIN Contractors_Cont AS CC2 ON CC2.Id_cont = Contracts.Id_cont " +
                    "WHERE Contracts.Date_add >= '{0}' " +
                    "GROUP BY Contracts.Id_cont, Contracts.Date_add, ContKinds.Kind, Contracts.Name, Contracts.Name, CStaff.Name, CC2.Id_cont " +
                // данные ДС
                    "UNION " +
                    "SELECT Agreements.Date_add, 'Дополнительное соглашение', Contracts.Name, Agreements.Name, AStaff.Name, " +
                        "(SELECT Contractors.Name + ', ' " +
                        "FROM Contractors_Cont CC1 INNER JOIN Contractors ON CC1.Id_contractor = Contractors.Id_contractor " +
                        "WHERE CC1.Id_cont=CC2.Id_cont FOR xml path('') ) " +
                    "FROM Agreements " +
                        "INNER JOIN Contracts ON Agreements.Id_cont = Contracts.Id_cont " +
                        "INNER JOIN Staff AS AStaff ON Agreements.Id_staff = AStaff.Id_staff " +
                        "INNER JOIN Contractors_Cont AS CC2 ON CC2.Id_cont = Contracts.Id_cont " +
                    "WHERE Agreements.Date_add >= '{0}' " +
                    "GROUP BY Agreements.Date_add, Contracts.Name, Agreements.Name, AStaff.Name, CC2.Id_cont " +
                // данные платежек
                    "UNION " +
                    "SELECT Payments.Date_add, 'Платежное поручение', Contracts.Name, Payments.Pay_no, Staff.Name , " +
                        "(SELECT Contractors.Name + ', ' " +
                        "FROM Contractors_Cont CC1 INNER JOIN Contractors ON CC1.Id_contractor = Contractors.Id_contractor " +
                        "WHERE CC1.Id_cont=CC2.Id_cont FOR xml path('') ) " +
                    "FROM Payments " +
                        "INNER JOIN Staff ON Payments.Id_staff = Staff.Id_staff " +
                        "INNER JOIN Contracts ON Payments.Id_cont = Contracts.Id_cont " +
                        "INNER JOIN Contractors_Cont AS CC2 ON CC2.Id_cont = Contracts.Id_cont " +
                    "WHERE Payments.Date_add >= '{0}' " +
                    "GROUP BY Payments.Date_add, Contracts.Name, Payments.Pay_no, Staff.Name, CC2.Id_cont "+
                // данные документов
                    "UNION " +
                    "SELECT Docs.Date_add, DocsKinds.Kind, Contracts.Name, Docs.Name, Staff.Name, " +
                        "(SELECT Contractors.Name + ', ' " +
                        "FROM Contractors_Cont CC1 INNER JOIN Contractors ON CC1.Id_contractor = Contractors.Id_contractor " +
                        "WHERE CC1.Id_cont=CC2.Id_cont FOR xml path('') ) " +
                    "FROM Docs " +
                        "INNER JOIN DocsKinds ON Docs.Id_kind = DocsKinds.Id_kind " +
                        "INNER JOIN Staff ON Docs.Id_staff = Staff.Id_staff " +
                        "INNER JOIN Contracts ON Docs.Id_cont = Contracts.Id_cont " +
                        "INNER JOIN Contractors_Cont AS CC2 ON CC2.Id_cont = Contracts.Id_cont " +
                    "WHERE Docs.Date_add >= '{0}' " +
                    "GROUP BY Docs.Date_add, DocsKinds.Kind, Contracts.Name, Docs.Name, Staff.Name, CC2.Id_cont ", dateStart);
               

                connection.Open();
                SqlDataReader reader = new SqlCommand(strCommand, connection).ExecuteReader();


                //string reportPath = Path.Combine(
                //    Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "Сводка документов.csv");
                //using (StreamWriter file = new StreamWriter(reportPath, false, Encoding.GetEncoding(1251)))
                //{
                //    file.WriteLine("Дата внесения;Тип документа;Основной документ;Имя;Ответственный");
                //    while (reader.Read())
                //    {
                //        file.WriteLine(reader.GetDateTime(0).ToShortDateString() + ";" +
                //            reader.GetString(1) + ";" + reader.GetString(2) + ";" +
                //            reader.GetString(3) + ";" + reader.GetString(4) + ";");
                //    }
                //}

                //var proc = new System.Diagnostics.Process();
                //proc.StartInfo.FileName = reportPath;
                //proc.StartInfo.UseShellExecute = true;
                //proc.Start();

                // если данных не было, то ничего не отправляем
                if (!reader.HasRows)
                {
                    reader.Close();
                    connection.Close();
                    return;
                }

                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

                xlApp.DisplayAlerts = false;

                xlApp.Visible = false;
                xlApp.SheetsInNewWorkbook = 1;
                xlApp.Workbooks.Add(Path.Combine(Environment.CurrentDirectory, "rep_tmplt.xltx"));

                int rowCounter = 1;
                Microsoft.Office.Interop.Excel.Worksheet xlSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlApp.ActiveWorkbook.Worksheets.get_Item(1);
                xlSheet.Cells[rowCounter, 1] = "Дата внесения";
                xlSheet.Cells[rowCounter, 2] = "Тип документа";
                xlSheet.Cells[rowCounter, 3] = "Основной документ";
                xlSheet.Cells[rowCounter, 4] = "Имя";
                xlSheet.Cells[rowCounter, 5] = "Ответственный";
                rowCounter++;

                while (reader.Read())
                {
                    xlSheet.Cells[rowCounter, 1] = reader.GetDateTime(0).ToString("dd.MM.yyyy hh:mm:ss");
                    xlSheet.Cells[rowCounter, 2] = reader.GetString(1);
                    xlSheet.Cells[rowCounter, 3] = reader.GetString(2);
                    xlSheet.Cells[rowCounter, 4] = reader.GetString(3);
                    xlSheet.Cells[rowCounter, 5] = reader.GetString(4);
                    rowCounter++;
                }

                reader.Close();
                connection.Close();

                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
                string fileName = "Сводка документов.xlsx";
                if (File.Exists(Path.Combine(path, fileName)))
                    fileName = "Сводка документов_" + Directory.GetFiles(path, "Сводка документов*.xlsx").Count() + ".xlsx";
                fileName = Path.Combine(path, fileName);

                xlApp.ActiveWorkbook.SaveAs(fileName);
                xlApp.Quit();


                // отправляем письмо
                string[] configFile = File.ReadAllLines("config.txt");
                string emailFrom = "ASKID@omg.transneft.ru";
                string emailFromPass = "mkoldA1991";

                List<string> mailtoList = new List<string>();
                int indexStart = Array.IndexOf(configFile, "EmailToStart") + 1;
                int indexEnd = Array.IndexOf(configFile, "EmailToEnd");
                for (int i = indexStart; i < indexEnd; i++) mailtoList.Add(configFile[i]);

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(emailFrom);
                foreach (string mailTo in mailtoList) mail.To.Add(new MailAddress(mailTo));
                mail.Subject = "АСКИД. Новые документы.";
                mail.Body = Environment.NewLine + "\t" + "Пиьмо сформировано и отослано автоматически.";
                if (!string.IsNullOrEmpty(fileName))
                    mail.Attachments.Add(new Attachment(fileName));
                SmtpClient client = new SmtpClient();
                //client.Host = "vom01-pimsg--01.ome.tn.corp";
                client.Host = "10.245.2.31";
                client.Port = 25;
                client.EnableSsl = false;
                client.Credentials = new NetworkCredential("agapovay@omg.transneft.ru", emailFromPass);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                //MessageBox.Show(message);
                client.Send(mail);
                mail.Dispose();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                connection.Close();
                //Console.ReadLine();
            }
        }
    }
}
