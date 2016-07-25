using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ContractsBase
{
    public partial class NewAgreement : Form
    {
        SqlConnection connection;
        int IdCont;
        MainForm.CurrentUserParams UserParams;
        int? IdAgr;
        public bool Success;

        public NewAgreement(SqlConnection conn, MainForm.CurrentUserParams userParams, int idcont, int? idArg = null)
        {
            InitializeComponent();
            connection = conn;
            IdCont = idcont;
            IdAgr = idArg;
            UserParams = userParams;

            dtpDateCreate.Format = DateTimePickerFormat.Custom;
            dtpDateCreate.CustomFormat = "dd.MM.yyyy";
            dtpDateEnd.Format = DateTimePickerFormat.Custom;
            dtpDateEnd.CustomFormat = "dd.MM.yyyy";
            dtpDateStartWork.Format = DateTimePickerFormat.Custom;
            dtpDateStartWork.CustomFormat = "dd.MM.yyyy";
            dtpDateStartFact.Format = DateTimePickerFormat.Custom;
            dtpDateStartFact.CustomFormat = "dd.MM.yyyy";
            dtpDateEndWork.Format = DateTimePickerFormat.Custom;
            dtpDateEndWork.CustomFormat = "dd.MM.yyyy";
            dtpDateEndFact.Format = DateTimePickerFormat.Custom;
            dtpDateEndFact.CustomFormat = "dd.MM.yyyy";

            try
            {
                if (IdAgr != null)
                {
                    btnOk.Text = "Обновить";

                    connection.Open();
                    SqlDataReader reader = new SqlCommand(String.Format(
                        "SELECT " +
                            "Agreements.Name AS AgrName, " +
                            "Agreements.Date_create, " +
                            "Agreements.Date_add, " +
                            "Agreements.Date_end, " +
                            "Agreements.Date_start_work, " +
                            "Agreements.Date_start_fact, " +
                            "Agreements.Date_end_work, " +
                            "Agreements.Date_end_fact, " +
                            "Agreements.Cost, " +
                            "Agreements.Number, " +
                            "Staff.Name AS StaffName, " +
                            "Agreements.Ins_docs,  " +
                            "Agreements.Diss " +
                        "FROM Agreements " +
                            "INNER JOIN Staff ON Agreements.Id_staff = Staff.Id_staff " +
                        "WHERE(Agreements.Id_agr = {0})", IdAgr), connection).ExecuteReader();

                    // выносим данные на форму
                    reader.Read();
                    txtBxName.Text = !reader.IsDBNull(0) ? reader.GetString(0) : "";
                    if (reader.IsDBNull(1)) dtpDateCreate.Checked = false;
                    else dtpDateCreate.Value = reader.GetDateTime(1);
                    txtBxDateAdd.Text = reader.GetDateTime(2).ToShortDateString();
                    if (reader.IsDBNull(3)) dtpDateEnd.Checked = false;
                    else dtpDateEnd.Value = reader.GetDateTime(3);
                    if (reader.IsDBNull(4)) dtpDateStartWork.Checked = false;
                    else dtpDateStartWork.Value = reader.GetDateTime(4);
                    if (reader.IsDBNull(5)) dtpDateStartFact.Checked = false;
                    else dtpDateStartFact.Value = reader.GetDateTime(5);
                    if (reader.IsDBNull(6)) dtpDateEndWork.Checked = false;
                    else dtpDateEndWork.Value = reader.GetDateTime(6);
                    if (reader.IsDBNull(7)) dtpDateEndFact.Checked = false;
                    else dtpDateEndFact.Value = reader.GetDateTime(7);

                    txtBxCost.Text = !reader.IsDBNull(8) ? reader.GetSqlMoney(8).ToString() : "";
                    txtBxNumber.Text = !reader.IsDBNull(9) ? reader.GetInt32(9).ToString() : "";
                    txtBxStaff.Text = !reader.IsDBNull(10) ? reader.GetString(10) : "";
                    chkBxInsDocs.Checked = reader.GetBoolean(11);
                    chkBxDiss.Checked = reader.GetBoolean(12);

                    this.Text = "Дополнительное соглашение";
                    if(!reader.IsDBNull(0)) this.Text += reader.GetString(0);

                    txtBxFilePath.Visible = false;
                    btnOpenFile.Visible = false;
                    label11.Visible = false;

                    reader.Close();
                    connection.Close();
                }
                else
                {
                    txtBxDateAdd.Text = DateTime.Now.ToShortDateString();
                    connection.Open();
                    SqlDataReader rdr = new SqlCommand("SELECT Name FROM Staff WHERE Id_staff = " + UserParams.IdStaff, connection).ExecuteReader();
                    rdr.Read();
                    txtBxStaff.Text = rdr.GetString(0);
                    rdr.Close();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка. NewAgreement: " + ex.Message, "АСКИД");
                if (connection.State == ConnectionState.Open) connection.Close();
            }
            Success = false;
        }

        private void NewAgreement_Load(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "All files (*.*)|*.*";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                // если добавляем новое
                if (IdAgr == null)
                {
                    
                    if (txtBxName.Text == "") MessageBox.Show("Необходимо заполнить поле 'Номер ДС'.", "АСКИД");
                    else if (new Regex(@"[0-9\-\+\.\,]*").Replace(txtBxCost.Text, "").Length != 0)
                        MessageBox.Show("В поле 'Сумма' могут содержаться только цифры, '.' или ','.", "АСКИД");
                    else if (new Regex("[0-9]+").Replace(txtBxNumber.Text, "") != "") MessageBox.Show("Поле 'Объем (количество)' может содержать только цифры", "АСКИД");
                    else if (txtBxFilePath.Text == "") MessageBox.Show("Необходимо заполнить поле 'Расположение'.", "АСКИД");
                    else if (!File.Exists(txtBxFilePath.Text)) MessageBox.Show("Необходимо заполнить поле 'Указанный файл не существует'.", "АСКИД");
                    else
                    {
                        connection.Open();

                        // убираем отметку с последнего ДС, что он последний
                        SqlCommand command = new SqlCommand(String.Format(
                            "UPDATE Agreements SET Last = 'False' WHERE Last = 'True' AND Id_cont = {0}", IdCont), connection);
                        command.ExecuteNonQuery();

                        // вносим новый ДС
                        command = new SqlCommand(String.Format(
                            "INSERT INTO Agreements(Id_cont, Name, Date_create, Date_add, " +
                            "Date_end, Date_start_work, Date_start_fact, Date_end_work, Date_end_fact, Cost, Number, Id_staff, Last, Diss, Filename) " +
                            "VALUES({0},N'{1}','{2}','{3}',{4},{5},{6},{7},{8},{9},{10},{11},'True','{12}', N'{13}')",
                            IdCont, txtBxName.Text, dtpDateCreate.Value.ToShortDateString(), DateTime.Now,
                            dtpDateEnd.Checked ? "'" + dtpDateEnd.Value.ToShortDateString() + "'" : "NULL",
                            dtpDateStartWork.Checked ? "'" + dtpDateStartWork.Value.ToShortDateString() + "'" : "NULL",
                            dtpDateStartFact.Checked ? "'" + dtpDateStartFact.Value.ToShortDateString() + "'" : "NULL",
                            dtpDateEndWork.Checked ? "'" + dtpDateEndWork.Value.ToShortDateString() + "'" : "NULL",
                            dtpDateEndFact.Checked ? "'" + dtpDateEndFact.Value.ToShortDateString() + "'" : "NULL",
                            txtBxCost.Text == "" ? "NULL" : new Regex(@" *[\,\.] *").Replace(txtBxCost.Text, "."),
                            txtBxNumber.Text == "" ? "NULL" : txtBxNumber.Text, UserParams.IdStaff, chkBxDiss.Checked,
                            Path.GetFileName(txtBxFilePath.Text) ), connection);

                        command.ExecuteNonQuery();
                        connection.Close();
                        
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
                        contrPath = System.IO.Path.Combine(contrPath, reader.GetString(0), reader.GetString(1), "ДС");
                        reader.Close();
                        connection.Close(); 

                        if (!Directory.Exists(contrPath)) Directory.CreateDirectory(contrPath);
                        string filePath = txtBxFilePath.Text;
                        if (File.Exists(Path.Combine(contrPath, Path.GetFileName(filePath))) &&
                        MessageBox.Show("В папке уже существует файл '" + Path.GetFileName(filePath) + "'. Заменить его?", "АСКИД", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            File.Copy(filePath, Path.Combine(contrPath, Path.GetFileName(filePath)), true);
                        else File.Copy(filePath, Path.Combine(contrPath, Path.GetFileName(filePath)));

                        // название договора, к которому добавляется новый ДС
                        connection.Open();
                        reader = new SqlCommand(String.Format(
                            "SELECT Contracts.Name FROM Contracts WHERE(Contracts.Id_cont = {0})", 
                            IdCont), connection).ExecuteReader();
                        reader.Read();
                        string emailText = Environment.NewLine + "\t" + "Добрый день." + Environment.NewLine + Environment.NewLine +
                            "\t" + "Пользователь " + UserParams.Name + " внес новое дополнительное соглашение \"" + txtBxName.Text + 
                            "\" к основному документу \"" + reader.GetString(0) + "\"." + Environment.NewLine +
                            Environment.NewLine + "\t" + "Письмо сформировано автоматически, просьба на него не отвечать.";
                        reader.Close();
                        connection.Close();

                        // отправка письма с сообщением о создании новго ДС
                        Program.SendMail(emailText);
                        
                        Success = true;
                        Close();
                    }
                }
                // если правим существующее
                else
                {
                    if (new Regex("[0-9]+").Replace(txtBxNumber.Text, "") != "")
                    {
                        MessageBox.Show("Поле 'Объем (количество)' может содержать только цифры", "АСКИД");
                        return;
                    }

                    connection.Open();
                    SqlCommand command = new SqlCommand(String.Format(
                        "UPDATE Agreements SET Name = N'{0}', Date_create ='{1}', Date_end ={2}, Date_start_work ={3}, " +
                        "Date_start_fact ={4}, Date_end_work ={5}, Date_end_fact ={6}, Cost ={7}, Number ={8}, " +
                        "Ins_docs ='{9}', Diss = '{10}' WHERE Id_agr = {11}",
                        txtBxName.Text, dtpDateCreate.Value.ToShortDateString(),
                        dtpDateEnd.Checked ? "'" + dtpDateEnd.Value.ToShortDateString() + "'" : "NULL",
                        dtpDateStartWork.Checked ? "'" + dtpDateStartWork.Value.ToShortDateString() + "'" : "NULL",
                        dtpDateStartFact.Checked ? "'" + dtpDateStartFact.Value.ToShortDateString() + "'" : "NULL",
                        dtpDateEndWork.Checked ? "'" + dtpDateEndWork.Value.ToShortDateString() + "'" : "NULL",
                        dtpDateEndFact.Checked ? "'" + dtpDateEndFact.Value.ToShortDateString() + "'" : "NULL",
                        txtBxCost.Text == "" ? "NULL" : txtBxCost.Text.Replace(",", "."),
                        txtBxNumber.Text == "" ? "NULL" : txtBxNumber.Text, chkBxInsDocs.Checked, chkBxDiss.Checked, IdAgr), connection);

                    command.ExecuteNonQuery();
                    connection.Close();

                    Success = true;
                    Close();
                }

                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка. NewAgreement.Add: " + ex.Message, "АСКИД");
                if (connection.State == ConnectionState.Open) connection.Close();
            }

        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtBxFilePath.Text = openFileDialog.FileName;
            }
        }

      
    }
}
