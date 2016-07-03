using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ContractsBase
{
    public partial class NewPayment : Form
    {
        SqlConnection connection;
        public string PayNo;
        public DateTime PayDate;
        public string Invoice;
        public string Filename;
        public bool Success;
        int? IdCont;
        int? IdPay;
        MainForm.CurrentUserParams UserParams;

        public NewPayment(SqlConnection conn, MainForm.CurrentUserParams userParams, int? idContract, int? idPay)
        {
            InitializeComponent();

            Success = false;
            connection = conn;
            IdCont = idContract;
            UserParams = userParams;
            IdPay = idPay;
            txtBxDateAdd.Text = DateTime.Now.ToShortDateString();

            dtpDatePay.Format = DateTimePickerFormat.Custom;
            dtpDatePay.CustomFormat = "dd.MM.yyyy";

            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "All files (*.*)|*.*";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;

            // если документ уже существует
            if (idPay != null)
            {
                txtBxFilePath.Visible = false;
                label4.Visible = false;
                btnOpenFile.Visible = false;
                btnOk.Text = "Обновить";

                try
                {
                    // запрос для данных по договору
                    connection.Open();
                    SqlDataReader reader = new SqlCommand(String.Format(
                        "SELECT Pay_no, Date_pay, Date_add, Invoice, Name, Ins_docs " +
                        "FROM Payments INNER JOIN Staff ON Payments.Id_staff = Staff.Id_staff " +
                        "WHERE(Payments.Id_pay = {0})", IdPay), connection).ExecuteReader();

                    // выносим данные на форму
                    reader.Read();
                    txtBxPayNo.Text = !reader.IsDBNull(0) ? reader.GetString(0) : "";
                    if (reader.IsDBNull(1)) dtpDatePay.Checked = false;
                    else dtpDatePay.Value = reader.GetDateTime(1);
                    txtBxDateAdd.Text = !reader.IsDBNull(2) ? reader.GetDateTime(2).ToShortDateString() : "";
                    txtBxInvoice.Text = !reader.IsDBNull(3) ? reader.GetString(3) : "";
                    txtBxSName.Text = !reader.IsDBNull(4) ? reader.GetString(4) : "";
                    chkBxInsDocs.Checked = reader.GetBoolean(5);

                    txtBxInvoice.ReadOnly = true;
                    if (!reader.IsDBNull(0)) this.Text = "Платежное поручение №" + reader.GetString(0);

                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка. NewPayment: " + ex.Message);
                    if (connection.State == ConnectionState.Open) connection.Close();
                    this.Close();
                }

            }
            else
            {
                connection.Open();
                SqlDataReader reader = new SqlCommand(String.Format(
                    "SELECT Name FROM Staff WHERE Id_staff = {0}", UserParams.IdStaff), connection).ExecuteReader();

                reader.Read();
                txtBxSName.Text = reader.GetString(0);
                reader.Close();
                connection.Close();
            }
        }

        private void NewPayment_Load(object sender, EventArgs e)
        {
           
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            if (txtBxPayNo.Text == "") MessageBox.Show("Необходимо заполнить поле '№ поручения'", "АСКИД");
            else if (txtBxInvoice.Text == "") MessageBox.Show("Необходимо заполнить поле 'Оплата по счсету'", "АСКИД");
            else if (new Regex("[\\|/:*?\"<>]+").Replace(txtBxInvoice.Text, "") != txtBxInvoice.Text) MessageBox.Show("Поле 'Оплата по счсету' не может содержать \\/:*?\"<>|.", "АСКИД");
            else if (txtBxFilePath.Visible == true && txtBxFilePath.Text == "") MessageBox.Show("Необходимо выбрать файл 'Расположение'", "АСКИД");
            else
            {
                Success = true;

                PayNo = txtBxPayNo.Text;
                PayDate = dtpDatePay.Value;
                Invoice = txtBxInvoice.Text;
                Filename = txtBxFilePath.Text;

                try
                {
                    
                    // если вызвали из формы уже созданного договора,то сразу копируем файлы в папку договора
                    if (IdPay == null && IdCont != null)
                    {
                        // создаем папку
                        // из конфига тянем путь к файловому серверу
                        string contrPath = File.ReadAllLines("config.txt").Where(s => s.StartsWith("FileServer=")).First();
                        contrPath = contrPath.Substring(11);

                        // вытаскиваем название отдела, где зарегистрировали договор и номер договора
                        connection.Open();
                        SqlDataReader reader = new SqlCommand(String.Format(
                            "SELECT Blocks.Block, Contracts.Name FROM Contracts " +
                            "INNER JOIN Staff ON Contracts.Id_staff = Staff.Id_staff " +
                            "INNER JOIN Blocks ON Staff.Id_block = Blocks.Id_block " +
                            "WHERE(Contracts.Id_cont = {0})", IdCont), connection).ExecuteReader();
                        reader.Read();
                        contrPath = System.IO.Path.Combine(contrPath, reader.GetString(0), reader.GetString(1), "Docs");
                        reader.Close();
                        connection.Close();

                        contrPath = Path.Combine(contrPath, Invoice);
                        if (!Directory.Exists(contrPath)) Directory.CreateDirectory(contrPath);

                        // проверяем, существует ли уже такой файл
                        string filePath = txtBxFilePath.Text;
                        string fileName = Path.GetFileName(filePath);
                        if (Directory.GetFiles(contrPath).Contains(Path.Combine(contrPath, fileName)))
                            fileName = Path.Combine(contrPath, Path.GetFileNameWithoutExtension(filePath) + "_" +
                                (Directory.GetFiles(contrPath, Path.GetFileNameWithoutExtension(filePath) + "*").Count() + 1) +
                                Path.GetExtension(filePath));
                        
                        File.Copy(filePath, Path.Combine(contrPath, fileName));

                        // вносим в базу
                        connection.Open();
                        SqlCommand command = new SqlCommand(String.Format(
                            "INSERT INTO Payments(Id_cont, Pay_no, Date_pay, Date_add, Invoice, Id_staff, Filename) VALUES ({0}, N'{1}', '{2}', '{3}', N'{4}', {5}, N'{6}')",
                            IdCont, PayNo, PayDate, DateTime.Now, Invoice, UserParams.IdStaff, Path.GetFileName(fileName)), connection);
                        command.ExecuteNonQuery();
                        connection.Close();

                        // название договора, к которому добавляется новое платежное поручение
                        connection.Open();
                        reader = new SqlCommand(String.Format(
                            "SELECT Contracts.Name FROM Contracts WHERE(Contracts.Id_cont = {0})",
                            IdCont), connection).ExecuteReader();
                        reader.Read();
                        string emailText = Environment.NewLine + "\t" + "Добрый день." + Environment.NewLine + Environment.NewLine +
                            "\t" + "Пользователь " + UserParams.Name + " внес новое платежное поручение \"" + PayNo + "\"" + Environment.NewLine + Environment.NewLine +
                            "\" к основному документу \"" + reader.GetString(0) + "\"." + Environment.NewLine +
                            Environment.NewLine + "\t" + "Письмо сформировано автоматически, просьба на него не отвечать.";
                        reader.Close();
                        connection.Close();

                        // отправка письма с сообщением о создании новго документа
                        Program.SendMail(emailText);

                    }
                    // если документ уже существует
                    else if(IdPay != null)
                    {
                       
                        // обновляем в базе
                        connection.Open();
                        SqlCommand command = new SqlCommand(String.Format(
                            "UPDATE Payments SET Pay_no = N'{0}', Date_pay = '{1}', Invoice =N'{2}', Ins_docs = '{3}'" +
                            "WHERE Id_pay = {4}",
                            PayNo, PayDate, Invoice, chkBxInsDocs.Checked, IdPay), connection);
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка. " + Environment.NewLine + "NewPayment.btnOk: " + ex.Message);
                    if (connection.State == ConnectionState.Open) connection.Close();
                    this.Close();
                }

                Close();
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtBxFilePath.Text = openFileDialog.FileName;
            }
        }

        private void txtBxFilePath_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
