using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ContractsBase
{
    public partial class NewContract : Form
    {
        SqlConnection connection;
        MainForm.CurrentUserParams UserParams;
        public bool Success;

        public NewContract(SqlConnection conn, MainForm.CurrentUserParams userParams)
        {
            InitializeComponent();
            connection = conn;
            UserParams = userParams;
            Success = false;

            try
            {
                connection.Open();
                SqlDataReader reader = new SqlCommand("SELECT * FROM ContTypes", connection).ExecuteReader();
                while (reader.Read()) cmbBxType.Items.Add(
                    new CmbItem(reader.GetByte(0), reader.GetString(1)));
                reader.Close();

                reader = new SqlCommand("SELECT * FROM ContKinds", connection).ExecuteReader();
                while (reader.Read()) cmbBxKind.Items.Add(
                    new CmbItem(reader.GetByte(0), reader.GetString(1)));
                reader.Close();
                connection.Close();
                
                cmbBxType.DisplayMember = "Name";
                cmbBxType.ValueMember = "Id";
                cmbBxKind.DisplayMember = "Name";
                cmbBxKind.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка. " + Environment.NewLine + "NewContract: " + ex.Message);
                this.Close();
            }
        }

        private void NewContract_Load(object sender, EventArgs e)
        {
            dtpDateEnd.Format = DateTimePickerFormat.Custom;
            dtpDateEnd.CustomFormat = "dd.MM.yyyy";
            dtpDateEndFact.Format = DateTimePickerFormat.Custom;
            dtpDateEndFact.CustomFormat = "dd.MM.yyyy";
            dtpDateEndWork.Format = DateTimePickerFormat.Custom;
            dtpDateEndWork.CustomFormat = "dd.MM.yyyy";
            dtpDateStart.Format = DateTimePickerFormat.Custom;
            dtpDateStart.CustomFormat = "dd.MM.yyyy";
            dtpDateStartWork.Format = DateTimePickerFormat.Custom;
            dtpDateStartWork.CustomFormat = "dd.MM.yyyy";
            dtpDateStartFact.Format = DateTimePickerFormat.Custom;
            dtpDateStartFact.CustomFormat = "dd.MM.yyyy";

            ToolTip toolTip = new ToolTip { AutoPopDelay = 5000, InitialDelay = 1000, ReshowDelay = 500, ShowAlways = true };

            toolTip.SetToolTip(btnAddContractor, "Добавить контрагента");
            toolTip.SetToolTip(btnRemoveContractor, "Удалить контрагента");
            toolTip.SetToolTip(btnAddFile, "Добавить документ");
            toolTip.SetToolTip(btnRemovelFile, "Удалить документ");
            toolTip.SetToolTip(btnAddPayment, "Добавить платежное поручение");
            toolTip.SetToolTip(btnRemovePay, "Удалить платежное поручение");
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            // список новых платежек, для которых еще не созданы папки
            List<string> newPaysDirs = new List<string>();
            foreach (ListViewItem item in listViewPayments.Items) newPaysDirs.Add(item.SubItems[2].Text);

            NewDoc form = new NewDoc(connection, UserParams.IdStaff, newPaysDirs, null);
            form.ShowDialog();

            if (form.Success)
            {
                // TODO: id пользователя
                ListViewItem item = new ListViewItem();
                item.Text = Path.GetFileName(form.Path);
                item.SubItems.Add(form.Kind);
                item.SubItems.Add(form.Path);
                item.SubItems.Add(form.KindId.ToString());
                item.SubItems.Add(form.Dir);
                listViewFiles.Items.Add(item);

                listViewFiles.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
        }

        private void btnAddContractor_Click(object sender, EventArgs e)
        {
            try
            {
                bool willAddToContract = true;
                Contractors form = new Contractors(willAddToContract, connection, UserParams);
                form.ShowDialog();

                if (form.ChoosingContractors != null && form.ChoosingContractors.Count() != 0)
                {
                    string commandText = "SELECT Name, Inn, Kpp, Id_contractor FROM Contractors WHERE ";
                    foreach (int id in form.ChoosingContractors.Keys) commandText += "Id_contractor = " + id + " OR ";
                    commandText = commandText.Substring(0, commandText.Length - 3);

                    connection.Open();
                    SqlDataReader reader = new SqlCommand(commandText, connection).ExecuteReader();

                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = reader.GetString(0);
                        item.SubItems.AddRange(new string[] { reader.GetString(1), reader.GetString(2), reader.GetInt32(3).ToString() });
                        listViewContractors.Items.Add(item);
                    }
                    reader.Close();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка. " + Environment.NewLine + "btnAddContractor: " + ex.Message);
                this.Close();
            }
        }

        private void listViewContractors_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete) RemoveContractor();
        }

        private void btnRemoveContractor_Click(object sender, EventArgs e)
        {
            RemoveContractor();
        }

        private void RemoveContractor()
        {
            if (listViewContractors.SelectedItems.Count != 0 && 
                MessageBox.Show("Вы уверены что хотите удалить выбранных контрагентов?", "АСКИД", MessageBoxButtons.YesNo) == DialogResult.Yes)
                foreach (ListViewItem item in listViewContractors.SelectedItems) item.Remove();
        }

        private void listViewFiles_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete) RemoveFile();
        }

        private void btnRemovelFile_Click(object sender, EventArgs e)
        {
            RemoveFile();
        }

        private void RemoveFile()
        {
            if (listViewFiles.SelectedItems.Count != 0 &&
                           MessageBox.Show("Вы уверены что хотите удалить выбранные файлы?", "АСКИД", MessageBoxButtons.YesNo) == DialogResult.Yes)
                foreach (ListViewItem item in listViewFiles.SelectedItems) item.Remove();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (cmbBxKind.SelectedItem == null) MessageBox.Show("Необходимо заполнить поле 'Тип договора'.", "АСКИД");
            else if (cmbBxType.SelectedItem == null) MessageBox.Show("Необходимо заполнить поле 'Типовой контракт'.", "АСКИД");
            else if (new Regex("[\\|/:*?\"<>]+").Replace(txtBxName.Text, "") != txtBxName.Text) MessageBox.Show("Поле 'Номер контракта' не может содержать \\/:*?\"<>|.", "АСКИД");
            else if (txtBxName.Text == "") MessageBox.Show("Необходимо заполнить поле 'Номер контракта'.", "АСКИД");
            else if (txtBxSubject.Text == "") MessageBox.Show("Необходимо заполнить поле 'Предмет договора'.", "АСКИД");
            else if (new Regex("[0-9]+").Replace(txtBxNumber.Text, "") != "") MessageBox.Show("Поле 'Объем (количество)' может содержать только цифры", "АСКИД");
            else if (txtBxOkdp.Text == "") MessageBox.Show("Необходимо заполнить поле 'ОКДП'.", "АСКИД");
            else if (listViewContractors.Items.Count == 0) MessageBox.Show("Необходимо заполнить поле 'Контрагенты'.", "АСКИД");
            else if (txtBxFilePath.Text == "") MessageBox.Show("Необходимо заполнить поле 'Расположение'.", "АСКИД");
            else if (!File.Exists(txtBxFilePath.Text)) MessageBox.Show("Указанный в поле 'Расположение' файл не существует.", "АСКИД");
            else
            {
                try
                {
                    connection.Open();

                    // ******************************************
                    // данные в таблицу контрактов
                    SqlCommand command = new SqlCommand(String.Format(
                        "INSERT INTO Contracts(Name, Date_add, Date_start, Date_end, Date_start_work, Date_end_work, " +
                            "Date_start_fact, Date_end_fact, Id_type, Id_kind, Id_staff, Subject, Cost, Number, Okdp)" +
                        "VALUES(N'{0}','{1}','{2}',{3},{4},{5},{6},{7},{8},{9},{10},N'{11}',{12},{13},N'{14}')",
                        txtBxName.Text, DateTime.Now,
                        dtpDateStart.Value.ToShortDateString(),
                        dtpDateEnd.Checked ? "'" + dtpDateEnd.Value.ToShortDateString() + "'" : "NULL",
                        dtpDateStartWork.Checked ? "'" + dtpDateStartWork.Value.ToShortDateString() + "'" : "NULL",
                        dtpDateEndWork.Checked ? "'" + dtpDateEndWork.Value.ToShortDateString() + "'" : "NULL",
                        dtpDateStartFact.Checked ? "'" + dtpDateStartFact.Value.ToShortDateString() + "'" : "NULL",
                        dtpDateEndFact.Checked ? "'" + dtpDateEndFact.Value.ToShortDateString() + "'" : "NULL",
                        (cmbBxType.SelectedItem as CmbItem).Id, (cmbBxKind.SelectedItem as CmbItem).Id, UserParams.IdStaff,
                        txtBxSubject.Text, txtBxCost.Text == "" ? "NULL" : new Regex(@" *[\,\.] *").Replace(txtBxCost.Text, "."),
                        txtBxNumber.Text == "" ? "NULL" : txtBxNumber.Text, txtBxOkdp.Text), connection);
                    command.ExecuteNonQuery();

                    
                    // попутно формируем тело письма
                    string emailText = "\t" + "Пользователь " + UserParams.Name + " внес новый основной документ \"" + txtBxName.Text + 
                        "\" (" + Path.GetFileName(txtBxFilePath.Text) + ")" + Environment.NewLine;

                    // данные контрагентов
                    SqlDataReader reader = new SqlCommand("SELECT MAX(Id_cont) FROM Contracts", connection).ExecuteReader();
                    reader.Read();
                    int idCont = reader.GetInt32(0);
                    reader.Close();

                    string strCommand = "INSERT INTO Contractors_Cont(Id_cont, Id_contractor) VALUES ";
                    foreach (ListViewItem item in listViewContractors.Items)
                        strCommand += "(" + idCont + ", " + item.SubItems[3].Text + "), ";
                    strCommand = strCommand.Substring(0, strCommand.Length - 2);

                    command = new SqlCommand(strCommand, connection);
                    command.ExecuteNonQuery();


                    // ******************************************
                    // создаем папку контракта, копируем файл
                    // из конфига тянем путь к файловому серверу
                    string contrPath = File.ReadAllLines("config.txt").Where(s => s.StartsWith("FileServer=")).First();
                    contrPath = contrPath.Substring(11);

                    // вытаскиваем название отдела, где зарегистрировали контракт и номер контракта
                    reader = new SqlCommand(String.Format(
                        "SELECT Blocks.Block, Contracts.Name FROM Contracts " +
                        "INNER JOIN Staff ON Contracts.Id_staff = Staff.Id_staff " +
                        "INNER JOIN Blocks ON Staff.Id_block = Blocks.Id_block " +
                        "WHERE(Contracts.Id_cont = {0})", idCont), connection).ExecuteReader();
                    reader.Read();
                    contrPath = System.IO.Path.Combine(contrPath, reader.GetString(0), reader.GetString(1));
                    reader.Close();
                    if (!Directory.Exists(contrPath)) Directory.CreateDirectory(contrPath);
                    string filePath = txtBxFilePath.Text;
                    if(File.Exists(Path.Combine(contrPath, Path.GetFileName(filePath))) && 
                        MessageBox.Show("В папке уже существует файл '" + Path.GetFileName(filePath) + "'. Заменить его?", "АСКИД", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        File.Copy(filePath, Path.Combine(contrPath, Path.GetFileName(filePath)), true);
                    else File.Copy(filePath, Path.Combine(contrPath, Path.GetFileName(filePath)));
                    contrPath = System.IO.Path.Combine(contrPath, "Docs");
                    if (!Directory.Exists(contrPath)) Directory.CreateDirectory(contrPath);
                    

                    // ******************************************
                    // данные платежных поручений
                    if (listViewPayments.Items.Count != 0)
                    {
                        emailText += "\t" + "Платежные поручения:" + Environment.NewLine;

                        // для платежных поручений создаются папки
                        strCommand = "INSERT INTO Payments(Id_cont, Pay_no, Date_pay, Date_add, Invoice, Id_staff, Filename) VALUES ";
                        foreach (ListViewItem item in listViewPayments.Items)
                        {
                            strCommand += String.Format("({0}, N'{1}', '{2}', '{3}', N'{4}', {5}, N'{6}'), ", idCont, item.Text, item.SubItems[1].Text,
                               DateTime.Now, item.SubItems[2].Text, UserParams.IdStaff, item.SubItems[3].Text);
                            // для каждого платежного поручения создаем папку
                            string invoice = item.SubItems[2].Text;
                            string invoicePath = "";
                            if (!Directory.Exists(Path.Combine(contrPath, invoice))) invoicePath = Path.Combine(contrPath, invoice);
                            else invoicePath = Path.Combine(contrPath, invoice + "_" +
                                    (Directory.GetDirectories(contrPath, invoice + "*").Count() + 1));
                            Directory.CreateDirectory(invoicePath);

                            if (File.Exists(Path.Combine(invoicePath, Path.GetFileName(item.SubItems[3].Text))) &&
                                MessageBox.Show("В папке уже существует файл '" + Path.GetFileName(item.SubItems[3].Text) + "'. Заменить его?", "АСКИД", 
                                MessageBoxButtons.YesNo) == DialogResult.Yes)
                                File.Copy(item.SubItems[3].Text, Path.Combine(invoicePath, Path.GetFileName(item.SubItems[3].Text)), true);
                            else File.Copy(item.SubItems[3].Text, Path.Combine(invoicePath, Path.GetFileName(item.SubItems[3].Text)));

                            emailText += "\t\t" + item.Text + Environment.NewLine;
                        }
                        strCommand = strCommand.Substring(0, strCommand.Length - 2);

                        command = new SqlCommand(strCommand, connection);
                        command.ExecuteNonQuery();

                        emailText += Environment.NewLine;
                    }


                    // ******************************************
                    // данные файлов
                    if (listViewFiles.Items.Count != 0)
                    {
                        strCommand = "INSERT INTO Docs(Id_kind, Name, Date_add, Id_staff, Id_cont) VALUES ";
                        emailText += Environment.NewLine + "\t" + "Документы:" + Environment.NewLine;
                        foreach (ListViewItem item in listViewFiles.Items)
                        {
                            strCommand += String.Format("({0}, N'{1}', '{2}', {3}, {4}), ", item.SubItems[3].Text, Path.GetFileName(item.SubItems[2].Text),
                               DateTime.Now.ToShortDateString(), UserParams.IdStaff, idCont);
                            emailText += "\t\t" + item.SubItems[1].Text + " (" + Path.GetFileName(item.SubItems[2].Text) + ")" + Environment.NewLine;

                            string newPath = contrPath;
                            if (item.SubItems[4].Text != "Docs") newPath = Path.Combine(newPath, item.SubItems[4].Text);

                            if (File.Exists(Path.Combine(newPath, Path.GetFileName(item.SubItems[2].Text))) &&
                                MessageBox.Show("В папке уже существует файл '" + Path.GetFileName(item.SubItems[2].Text) + "'. Заменить его?", 
                                "АСКИД", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                File.Copy(item.SubItems[2].Text, Path.Combine(newPath, Path.GetFileName(item.SubItems[2].Text)), true);
                            else File.Copy(item.SubItems[2].Text, Path.Combine(newPath, Path.GetFileName(item.SubItems[2].Text)));
                        }
                        strCommand = strCommand.Substring(0, strCommand.Length - 2);

                        command = new SqlCommand(strCommand, connection);
                        command.ExecuteNonQuery();
                        emailText += Environment.NewLine;

                    }



                    connection.Close();
                    Success = true;

                    // отправка письма с сообщением о создании новго контракта
                    emailText = Environment.NewLine + "\t" + "Добрый день." + Environment.NewLine + Environment.NewLine + emailText + Environment.NewLine +
                        "\t" + "Письмо сформировано автоматически, просьба на него не отвечать.";
                    Program.SendMail(emailText);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка. " + Environment.NewLine + "NewContract.btnOk: " + ex.Message);
                    if (connection.State == ConnectionState.Open) connection.Close();
                }

                Close();
            }
        }

        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            NewPayment form = new NewPayment(connection, UserParams, null, null);

            form.ShowDialog();

            if (form.Success)
            {
                // TODO: id пользователя
                ListViewItem item = new ListViewItem();
                item.Text = Path.GetFileName(form.PayNo);
                item.SubItems.Add(form.PayDate.ToShortDateString());
                item.SubItems.Add(form.Invoice);
                item.SubItems.Add(form.Filename);
                listViewPayments.Items.Add(item);

                listViewFiles.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
        }

        private void listViewPayments_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete) RemovePayments();
        }

        private void btnRemovePay_Click(object sender, EventArgs e)
        {
            RemovePayments();
        }

        private void RemovePayments()
        {
            if (listViewPayments.SelectedItems.Count != 0 &&
                            MessageBox.Show("Вы уверены что хотите удалить выбранные платежные поручения?", "АСКИД", MessageBoxButtons.YesNo) == DialogResult.Yes)
                foreach (ListViewItem item in listViewPayments.SelectedItems) item.Remove();
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
