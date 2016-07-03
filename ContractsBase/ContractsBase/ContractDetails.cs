using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace ContractsBase
{
    public partial class ContractDetails : Form
    {
        int IdCont;
        SqlConnection connection;
        SqlDataAdapter adapterAgrs;
        SqlDataAdapter adapterContractors;
        SqlDataAdapter adapterDocs;
        SqlDataAdapter adapterPayments;
        MainForm.CurrentUserParams UserParams;

        public ContractDetails(SqlConnection conn, int idCotract, MainForm.CurrentUserParams userParams)
        {
            InitializeComponent();
            IdCont = idCotract;
            UserParams = userParams;
            connection = conn;

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

            toolTip.SetToolTip(btnAddAgreement, "Добавить платежное поручение");
            toolTip.SetToolTip(btnRemoveAgreement, "Удалить платежное поручение");
            toolTip.SetToolTip(btnAddDoc, "Добавить документ");
            toolTip.SetToolTip(btnRemoveDoc, "Удалить документ");
            toolTip.SetToolTip(btnAddPayment, "Добавить платежное поручение");
            toolTip.SetToolTip(btnRemovePay, "Удалить платежное поручение");
            toolTip.SetToolTip(btnOpenFolder, "Откурыть папку контракта");
            toolTip.SetToolTip(btnSaveChanges, "Сохранить изменения данных контракта");

        }

        private void ContractDetails_Load(object sender, EventArgs e)
        {
            try
            {
                // **************************************
                // общие данные по контракту
                SelectContractDetails();
                if (UserParams.AccessType != 1) chkBxInsDocs.AutoCheck = false;


                // **************************************
                // список дополнительных соглашений
                adapterAgrs = new SqlDataAdapter(new SqlCommand(String.Format(
                    "SELECT Agreements.Name AS AgrName, " +
                        "Agreements.Date_add, " +
                        "CONVERT(varchar(10), CONVERT(money, Agreements.Cost), 0) AS Cost, " +
                        "Staff.Name AS StaffName, " +
                        "Agreements.Date_create, " +
                        "Agreements.Ins_docs, " +
                        "Agreements.Id_agr, " +
                        "IIF(Agreements.Diss = 'False', 'Нет', 'Да') as ADiss, " +
                        "Agreements.Filename " +
                    "FROM Agreements " +
                    "INNER JOIN Staff ON Agreements.Id_staff = Staff.Id_staff " +
                    "WHERE Agreements.Id_cont = {0} " +
                    "ORDER BY Agreements.Date_add DESC", IdCont), connection));

                DataTable dataTable = new DataTable();
                adapterAgrs.Fill(dataTable);

                dgvAgrs.Columns.Add(new DataGridViewTextBoxColumn { Name = "AgrName", DataPropertyName = "AgrName", HeaderText = "Номер" });
                dgvAgrs.Columns.Add(new DataGridViewTextBoxColumn { Name = "Date_add", DataPropertyName = "Date_add", HeaderText = "Дата" });
                dgvAgrs.Columns.Add(new DataGridViewTextBoxColumn { Name = "Cost", DataPropertyName = "Cost", HeaderText = "Стоимость" });
                dgvAgrs.Columns.Add(new DataGridViewTextBoxColumn { Name = "StaffName", DataPropertyName = "StaffName", HeaderText = "Ответственный" });
                dgvAgrs.Columns.Add(new DataGridViewTextBoxColumn { Name = "ADiss", DataPropertyName = "ADiss", HeaderText = "СОР" });
                dgvAgrs.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id_agr", DataPropertyName = "Id_agr", HeaderText = "Id_agr" });
                dgvAgrs.Columns.Add(new DataGridViewTextBoxColumn { Name = "Filename", DataPropertyName = "Filename", HeaderText = "Filename" });

                dgvAgrs.DataSource = dataTable;
                dgvAgrs.Columns["Id_agr"].Visible = false;
                dgvAgrs.Columns["Ins_docs"].Visible = false;
                dgvAgrs.Columns["Date_create"].Visible = false;
                dgvAgrs.Columns["Filename"].Visible = false;

                // выделяем цветом просроченные
                ColoredRows(3, dgvAgrs, "Date_create", "Date_add");


                // **************************************
                // данные документов
                adapterDocs = new SqlDataAdapter(new SqlCommand(String.Format(
                                    "SELECT " +
                                        "Docs.Name AS DocName, " +
                                        "DocsKinds.Kind, " +
                                        "Docs.Date_add, " +
                                        "Staff.Name AS StaffName, " +
                                        "Docs.Id_doc " +
                                    "FROM Docs " +
                                        "INNER JOIN Staff ON Staff.Id_staff = Docs.Id_staff " +
                                        "INNER JOIN DocsKinds ON Docs.Id_kind = DocsKinds.Id_kind " +
                                    "WHERE Docs.Id_cont = {0} " +
                                    "ORDER BY Docs.Date_add DESC", IdCont), connection));

                dataTable = new DataTable();
                adapterDocs.Fill(dataTable);

                dgvDocs.Columns.Add(new DataGridViewTextBoxColumn { Name = "DocName", DataPropertyName = "DocName", HeaderText = "Имя файла" });
                dgvDocs.Columns.Add(new DataGridViewTextBoxColumn { Name = "Kind", DataPropertyName = "Kind", HeaderText = "Вид" });
                dgvDocs.Columns.Add(new DataGridViewTextBoxColumn { Name = "Date_add", DataPropertyName = "Date_add", HeaderText = "Дата загрузки" });
                dgvDocs.Columns.Add(new DataGridViewTextBoxColumn { Name = "StaffName", DataPropertyName = "StaffName", HeaderText = "Ответственный" });
                dgvDocs.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id_doc", DataPropertyName = "Id_doc" });
                dgvDocs.Columns["Id_doc"].Visible = false;

                dgvDocs.DataSource = dataTable;




                // **************************************
                // данные контраегнтов
                adapterContractors = new SqlDataAdapter(new SqlCommand(String.Format(
                    "SELECT Contractors.Name, Contractors.Inn, Contractors.Kpp, Contractors.Id_contractor " +
                    "FROM Contractors_Cont " +
                        "INNER JOIN Contractors ON Contractors_Cont.Id_contractor = Contractors.Id_contractor " +
                    "WHERE(Contractors_Cont.Id_cont = {0})", IdCont), connection));

                dataTable = new DataTable();
                adapterContractors.Fill(dataTable);

                dgvContractors.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name", DataPropertyName = "Name", HeaderText = "Организация/ФИО" });
                dgvContractors.Columns.Add(new DataGridViewTextBoxColumn { Name = "Inn", DataPropertyName = "Inn", HeaderText = "ИНН" });
                dgvContractors.Columns.Add(new DataGridViewTextBoxColumn { Name = "Kpp", DataPropertyName = "Kpp", HeaderText = "КПП" });
                dgvContractors.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id_contractor", DataPropertyName = "Id_contractor" });

                dgvContractors.DataSource = dataTable;
                dgvContractors.Columns["Id_contractor"].Visible = false;



                // **************************************
                // данные платежных поручений
                adapterPayments = new SqlDataAdapter(new SqlCommand(String.Format(
                    "SELECT Payments.Pay_no, Payments.Date_pay, Payments.Date_add, Payments.Invoice, Staff.Name AS SName, Ins_docs, Id_pay, Filename " +
                    "FROM Payments INNER JOIN Staff ON Payments.Id_staff=Staff.Id_staff WHERE Id_cont = {0}", IdCont), connection));

                dataTable = new DataTable();
                adapterPayments.Fill(dataTable);

                dgvPayments.Columns.Add(new DataGridViewTextBoxColumn { Name = "Pay_no", DataPropertyName = "Pay_no", HeaderText = "№ платежного поручения" });
                dgvPayments.Columns.Add(new DataGridViewTextBoxColumn { Name = "Date_pay", DataPropertyName = "Date_pay", HeaderText = "Дата платежного поручения" });
                dgvPayments.Columns.Add(new DataGridViewTextBoxColumn { Name = "Date_add", DataPropertyName = "Date_add", HeaderText = "Дата добавления" });
                dgvPayments.Columns.Add(new DataGridViewTextBoxColumn { Name = "Invoice", DataPropertyName = "Invoice", HeaderText = "Оплата по счету" });
                dgvPayments.Columns.Add(new DataGridViewTextBoxColumn { Name = "SName", DataPropertyName = "SName", HeaderText = "Ответственный" });
                dgvPayments.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id_pay", DataPropertyName = "Id_pay" });
                dgvPayments.Columns.Add(new DataGridViewTextBoxColumn { Name = "Filename", DataPropertyName = "Filename" });

                dgvPayments.DataSource = dataTable;
                dgvPayments.Columns["Id_pay"].Visible = false;
                dgvPayments.Columns["Ins_docs"].Visible = false;
                dgvPayments.Columns["Filename"].Visible = false;


                // **************************************
                // дублируем элементы для возможности менять данные
                if (UserParams.AccessType == 1)
                {
                    List<CmbItem> itemsList = new List<CmbItem>();
                    connection.Open();
                    SqlDataReader reader = new SqlCommand("SELECT Id_type, Type FROM ContTypes", connection).ExecuteReader();
                    while (reader.Read()) itemsList.Add(new CmbItem(reader.GetByte(0), reader.GetString(1)));
                    reader.Close();
                    cmbBxType.Items.AddRange(itemsList.ToArray());
                    cmbBxType.DisplayMember = "Name";
                    cmbBxType.ValueMember = "Id";
                    cmbBxType.SelectedIndex = itemsList.IndexOf(itemsList.Where(i => i.Name == txtBxType.Text).First());

                    itemsList = new List<CmbItem>();
                    reader = new SqlCommand("SELECT * FROM ContKinds", connection).ExecuteReader();
                    while (reader.Read()) itemsList.Add(new CmbItem(reader.GetByte(0), reader.GetString(1)));
                    reader.Close();
                    connection.Close();
                    cmbBxKind.Items.AddRange(itemsList.ToArray());
                    cmbBxKind.DisplayMember = "Name";
                    cmbBxKind.ValueMember = "Id";
                    cmbBxKind.SelectedIndex = itemsList.IndexOf(itemsList.Where(i => i.Name == txtBxKind.Text).First());

                    if (txtBxDateStart.Text == "") dtpDateStart.Checked = false;
                    else dtpDateStart.Value = DateTime.Parse(txtBxDateStart.Text);

                    if (txtBxStartWork.Text == "") dtpDateStartWork.Checked = false;
                    else dtpDateStartWork.Value = DateTime.Parse(txtBxStartWork.Text);

                    if (txtBxStartFact.Text == "") dtpDateStartFact.Checked = false;
                    else dtpDateStartFact.Value = DateTime.Parse(txtBxStartFact.Text);

                    if (txtBxDateEnd.Text == "") dtpDateEnd.Checked = false;
                    else dtpDateEnd.Value = DateTime.Parse(txtBxDateEnd.Text);

                    if (txtBxEndFact.Text == "") dtpDateEndFact.Checked = false;
                    else dtpDateEndFact.Value = DateTime.Parse(txtBxEndFact.Text);

                    if (txtBxEndWork.Text == "") dtpDateEndWork.Checked = false;
                    else dtpDateEndWork.Value = DateTime.Parse(txtBxEndWork.Text);

                    cmbBxType.Visible = true;
                    cmbBxKind.Visible = true;
                    txtBxSubject.ReadOnly = false;
                    txtBxCost.ReadOnly = false;
                    //txtBxContrName.ReadOnly = false;
                    txtBxNumber.ReadOnly = false;
                    txtBxOkdp.ReadOnly = false;
                    btnSaveChanges.Visible = true;

                    dtpDateStart.Visible = true;
                    dtpDateStartWork.Visible = true;
                    dtpDateStartFact.Visible = true;
                    dtpDateEnd.Visible = true;
                    dtpDateEndFact.Visible = true;
                    dtpDateEndWork.Visible = true;
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + Environment.NewLine + "ContractDetails_Load: " + ex.Message);
                if (connection.State == ConnectionState.Open) connection.Close();
            }
        }

        private void ColoredRows(int days, DataGridView dgv, string colNameStart, string colNameEnd)
        {
            // дни календарные
            int addDays = 3;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells["Ins_docs"].Value.ToString() == "False" && row.Cells[colNameStart].Value.ToString() != "")
                {
                    DateTime dateStart = DateTime.Parse(row.Cells[colNameStart].Value.ToString());
                    DateTime dateAdd = DateTime.Parse(row.Cells[colNameEnd].Value.ToString());
                    if (dateAdd >= dateStart.AddDays(addDays)) row.DefaultCellStyle.BackColor = Color.LightPink;
                }
            }
        }

        private void RefreshDgv(DataGridView dgv, SqlDataAdapter adapter)
        {
            try
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dgv.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + Environment.NewLine + "RefreshDgv: " + ex.Message);
            }
        }

        private void SelectContractDetails()
        {
            try
            {
                // зпрос для общих данных по контракту
                connection.Open();
                SqlDataReader reader = new SqlCommand(String.Format(
                   "SELECT Contracts.Id_cont, " +
                        "ContTypes.Type, " +
                        "Contracts.Name, " +
                        "ContKinds.Kind, " +
                        "Contracts.Date_add, " +
                        "ISNULL(Contracts.Cost, ''), " +
                        "CASE " +
                          "WHEN Contracts.Cost IS NULL AND Agreements.Cost IS NULL THEN '' " +
                          "WHEN Contracts.Cost IS NOT NULL AND Agreements.Cost IS NULL THEN Contracts.Cost " +
                          "WHEN Contracts.Cost IS NULL AND Agreements.Cost IS NOT NULL THEN Agreements.Cost " +
                          "WHEN Contracts.Cost IS NOT NULL AND Agreements.Cost IS NOT NULL THEN Contracts.Cost + Agreements.Cost " +
                       "END, " +
                        "Staff.Name AS SName, " +
                        "Contracts.Date_start, " +
                        //"Contracts.Date_end, " +
                        "ISNULL(Agreements.Date_end, Contracts.Date_end) AS DateStartWorkResult, " +
                        "ISNULL(Agreements.Date_start_work, Contracts.Date_start_work) AS DateStartWorkResult, " +
                        "ISNULL(Agreements.Date_start_fact, Contracts.Date_start_fact) AS DateStartFactResult, " +
                        "ISNULL(Agreements.Date_end_work, Contracts.Date_end_work) AS DateEndWorkResult, " +
                        "ISNULL(Agreements.Date_end_fact, Contracts.Date_end_fact) AS DateEndFactResult, " +
                        "ISNULL(Agreements.Number, ISNULL(Contracts.Number, 0)) AS NumberResult, " + 
                        "Contracts.Okdp, " +
                        "Contracts.Subject, " +
                        "Contracts.Ins_docs " +
                    "FROM Contracts  " +
                        "INNER JOIN ContTypes ON Contracts.Id_type = ContTypes.Id_type  " +
                        "INNER JOIN ContKinds ON Contracts.Id_kind = ContKinds.Id_kind  " +
                        "INNER JOIN Staff ON Contracts.Id_staff = Staff.Id_staff " +
                        "LEFT OUTER JOIN Agreements ON Agreements.Id_cont = Contracts.Id_cont " +
                    "WHERE ((Agreements.Last = 'True') OR (Agreements.Last IS NULL)) AND (Contracts.Id_cont = {0})", IdCont), connection).ExecuteReader();

                // выносим данные на форму
                reader.Read();
                txtBxType.Text = reader.GetString(1) ?? "";
                txtBxContrName.Text = reader.GetString(2) ?? "";
                txtBxKind.Text = reader.GetString(3) ?? "";
                txtBxCost.Text = reader.GetSqlMoney(5).ToString() ?? "";
                txtBxCostDs.Text = reader.GetSqlMoney(6).ToString() ?? "";
                txtBxStaff.Text = reader.GetString(7) ?? "";
                txtBxSubject.Text = reader.GetString(16) ?? "";
                chkBxInsDocs.CheckedChanged -= chkBxInsDocs_CheckedChanged;
                chkBxInsDocs.Checked = reader.GetBoolean(17);
                chkBxInsDocs.CheckedChanged += chkBxInsDocs_CheckedChanged;

                if (!reader.IsDBNull(4)) txtBxDateAdd.Text = reader.GetDateTime(4).ToShortDateString();
                if (!reader.IsDBNull(8))
                {
                    txtBxDateStart.Text = reader.GetDateTime(8).ToShortDateString();
                    dtpDateStart.Checked = true;
                    dtpDateStart.Value = reader.GetDateTime(8);
                }
                if (!reader.IsDBNull(9))
                {
                    txtBxDateEnd.Text = reader.GetDateTime(9).ToShortDateString();
                    dtpDateEnd.Checked = true;
                    dtpDateEnd.Value = reader.GetDateTime(9);
                }
                if (!reader.IsDBNull(10))
                {
                    txtBxStartWork.Text = reader.GetDateTime(10).ToShortDateString();
                    dtpDateStartWork.Checked = true;
                    dtpDateStartWork.Value = reader.GetDateTime(10);
                }
                if (!reader.IsDBNull(11))
                {
                    txtBxStartFact.Text = reader.GetDateTime(11).ToShortDateString();
                    dtpDateStartFact.Checked = true;
                    dtpDateStartFact.Value = reader.GetDateTime(11);
                }
                if (!reader.IsDBNull(12))
                {
                    txtBxEndWork.Text = reader.GetDateTime(12).ToShortDateString();
                    dtpDateEndWork.Checked = true;
                    dtpDateEndWork.Value = reader.GetDateTime(12);
                }
                if (!reader.IsDBNull(13))
                {
                    txtBxEndFact.Text = reader.GetDateTime(13).ToShortDateString();
                    dtpDateEndFact.Checked = true;
                    dtpDateEndFact.Value = reader.GetDateTime(13);
                }

                if (!reader.IsDBNull(14)) txtBxNumber.Text = reader.GetInt32(14).ToString();
                if (!reader.IsDBNull(15)) txtBxOkdp.Text = reader.GetValue(15).ToString();

                this.Text = "Контракт №" + reader.GetString(2);

                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + Environment.NewLine + "RefrechContractDetails: " + ex.Message);
                if (connection.State == ConnectionState.Open) connection.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddAgreement_Click(object sender, EventArgs e)
        {
            NewAgreement form = new NewAgreement(connection, UserParams, IdCont);
            form.ShowDialog();
            if (form.Success)
            {
                RefreshDgv(dgvAgrs, adapterAgrs);
                SelectContractDetails();
            }
        }

        private void dgvAgrs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            if (UserParams.AccessType != 1)
            {
                AgreementDetails form = new AgreementDetails(connection, Convert.ToInt32(dgvAgrs.CurrentRow.Cells["Id_agr"].Value));
                form.ShowDialog();
            }
            else
            {
                NewAgreement form = new NewAgreement(connection, UserParams, IdCont, Convert.ToInt32(dgvAgrs.CurrentRow.Cells["Id_agr"].Value));
                form.ShowDialog();
                SelectContractDetails();
            }

            RefreshDgv(dgvAgrs, adapterAgrs);
        }

        private void btnAddDoc_Click(object sender, EventArgs e)
        {
            NewDoc form = new NewDoc(connection, UserParams.IdStaff, null, IdCont);
            form.ShowDialog();

            if (form.Success) RefreshDgv(dgvDocs, adapterDocs);
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            string contrPath = GetContractDirPath();
            System.Diagnostics.Process.Start("explorer", contrPath);
        }

        private string GetContractDirPath()
        {
            // из конфига тянем путь к файловому серверу
            string contrPath = File.ReadAllLines("config.txt").Where(s => s.StartsWith("FileServer=")).First();
            contrPath = contrPath.Substring(11);

            // вытаскиваем название отдела, где зарегистрировали контракт и номер контракта
            connection.Open();
            SqlDataReader reader = new SqlCommand(String.Format(
                "SELECT Blocks.Block, Contracts.Name FROM Contracts " +
                "INNER JOIN Staff ON Contracts.Id_staff = Staff.Id_staff " +
                "INNER JOIN Blocks ON Staff.Id_block = Blocks.Id_block " +
                "WHERE(Contracts.Id_cont = {0})", IdCont), connection).ExecuteReader();
            reader.Read();
            contrPath = System.IO.Path.Combine(contrPath, reader.GetString(0), reader.GetString(1));
            reader.Close();
            connection.Close();
            return contrPath;
        }

        private void dgvDocs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;

            try
            {
                string filePath = Path.Combine(GetContractDirPath(), "Docs", dgvDocs.CurrentRow.Cells["DocName"].Value.ToString());

                var proc = new System.Diagnostics.Process();
                proc.StartInfo.FileName = filePath;
                proc.StartInfo.UseShellExecute = true;
                proc.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! dgvDocs.CellDoubleClick: " + ex.Message);
            }
        }

        private void dgvContractors_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ContractorDetails form = new ContractorDetails(connection, UserParams,
                Convert.ToInt32(dgvContractors.CurrentRow.Cells["Id_contractor"].Value));
            form.ShowDialog();
        }

        private void dgvAgrs_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ColoredRows(3, dgvAgrs, "Date_create", "Date_add");
        }

        private void chkBxInsDocs_CheckedChanged(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand(String.Format("UPDATE Contracts SET Ins_docs='{0}' WHERE Id_cont={1}",
                chkBxInsDocs.Checked, IdCont), connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            NewPayment form = new NewPayment(connection, UserParams, IdCont, null);
            form.ShowDialog();

            if (form.Success) RefreshDgv(dgvPayments, adapterPayments);
        }

        private void dgvPayments_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (UserParams.AccessType != 1)
            {
                PaymentDetails form = new PaymentDetails(connection,
                Convert.ToInt32(dgvPayments.CurrentRow.Cells["Id_pay"].Value));
                form.ShowDialog();
            }
            else
            {
                NewPayment form = new NewPayment(connection, UserParams, IdCont,
                    Convert.ToInt32(dgvPayments.CurrentRow.Cells["Id_pay"].Value));
                form.ShowDialog();
            }

            RefreshDgv(dgvPayments, adapterPayments);
        }

        private void dgvPayments_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ColoredRows(3, dgvPayments, "Date_pay", "Date_add");
        }

        private void dgvAgrs_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && UserParams.AccessType == 1)
                RemoveAgreement();
        }

        private void RemoveAgreement()
        {
            if (dgvAgrs.CurrentRow != null  && 
                MessageBox.Show("Вы уверены, что хотите удалить выбранное дополнительное соглашение?", "АСКИД", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                connection.Open();
                SqlCommand command = new SqlCommand(String.Format("DELETE FROM Agreements WHERE Id_agr = {0}",
                    Convert.ToInt32(dgvAgrs.CurrentRow.Cells["Id_agr"].Value)), connection);
                command.ExecuteNonQuery();
                // устанавливаем в качестве последнего самый поздний ДС
                command = new SqlCommand(String.Format("UPDATE Agreements SET Last= 'True' WHERE Id_cont = {0} AND Date_add = (SELECT MAX(Date_add) FROM Agreements)", 
                    IdCont), connection);
                command.ExecuteNonQuery();
                connection.Close();

                // текущее расположение файла
                string filePath = Path.Combine(GetContractDirPath(), "ДС");
                string fileName = dgvAgrs.CurrentRow.Cells["Filename"].Value.ToString();
                if (!File.Exists(Path.Combine(filePath, fileName))) MessageBox.Show("Файл '" + Path.Combine(filePath, fileName) + "' не найден!", "АСКИД");
                else
                {
                    string newFileName = Path.GetFileNameWithoutExtension(fileName) + DateTime.Now.ToString("ddMMyyyyHHmmss") + Path.GetExtension(fileName);

                    // из конфига тянем путь к файловому серверу
                    string trashPath = File.ReadAllLines("config.txt").Where(s => s.StartsWith("FileServer=")).First();
                    trashPath = Path.Combine(trashPath.Substring(11), "Trash");

                    if (!Directory.Exists(trashPath)) Directory.CreateDirectory(trashPath);
                    File.Move(Path.Combine(filePath, fileName), Path.Combine(trashPath, newFileName));
                }


                RefreshDgv(dgvAgrs, adapterAgrs);
                SelectContractDetails();
            }
        }

        private void dgvDocs_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && UserParams.AccessType == 1)
                RemoveDoc();
            
        }

        private void RemoveDoc()
        {
            if (dgvDocs.CurrentRow != null && MessageBox.Show("Вы уверены, что хотите удалить выбранный документ?", "АСКИД", MessageBoxButtons.OKCancel) == DialogResult.OK)
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(String.Format("DELETE FROM Docs WHERE Id_doc = {0}",
                    Convert.ToInt32(dgvDocs.CurrentRow.Cells["Id_doc"].Value)), connection);
                command.ExecuteNonQuery();
                connection.Close();

                // текущее расположение файла
                string filePath = Path.Combine(GetContractDirPath(), "Docs");
                string fileName = dgvDocs.CurrentRow.Cells["DocName"].Value.ToString();
                if (!File.Exists(Path.Combine(filePath, fileName))) MessageBox.Show("Файл '" + Path.Combine(filePath, fileName) + "' не найден!", "АСКИД");
                else
                {
                    string newFileName = Path.GetFileNameWithoutExtension(fileName) + DateTime.Now.ToString("ddMMyyyyHHmmss") + Path.GetExtension(fileName);

                    // из конфига тянем путь к файловому серверу
                    string trashPath = File.ReadAllLines("config.txt").Where(s => s.StartsWith("FileServer=")).First();
                    trashPath = Path.Combine(trashPath.Substring(11), "Trash");

                    if (!Directory.Exists(trashPath)) Directory.CreateDirectory(trashPath);
                    File.Move(Path.Combine(filePath, fileName), Path.Combine(trashPath, newFileName));
                }

                RefreshDgv(dgvDocs, adapterDocs);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! dgvDocs.KeyUp: " + ex.Message);
                if (connection.State == ConnectionState.Open) connection.Close();
            }
        }

        private void dgvPayments_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && UserParams.AccessType == 1)
            {
                RemovePay();

            }
        }

        private void RemovePay()
        {
            if (dgvPayments.CurrentRow != null && MessageBox.Show("Вы уверены, что хотите удалить выбранное платежное поручение?", "АСКИД", MessageBoxButtons.OKCancel) == DialogResult.OK)
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(String.Format("DELETE FROM Payments WHERE Id_pay = {0}",
                    Convert.ToInt32(dgvPayments.CurrentRow.Cells["Id_pay"].Value)), connection);
                command.ExecuteNonQuery();
                connection.Close();

                // текущее расположение файла: папка контракта\Docs\номер счета\имя файла
                string filePath = Path.Combine(GetContractDirPath(), "Docs", dgvPayments.CurrentRow.Cells["Invoice"].Value.ToString(), dgvPayments.CurrentRow.Cells["Filename"].Value.ToString());
                string fileName = dgvPayments.CurrentRow.Cells["Filename"].Value.ToString();
                if (!File.Exists(filePath)) MessageBox.Show("Файл '" + Path.Combine(filePath, fileName) + "' не найден!", "АСКИД");
                else
                {
                    string newFileName = Path.GetFileNameWithoutExtension(fileName) + DateTime.Now.ToString("_ddMMyyyyHHmmss") + Path.GetExtension(fileName);

                    // из конфига тянем путь к файловому серверу
                    string trashPath = File.ReadAllLines("config.txt").Where(s => s.StartsWith("FileServer=")).First();
                    trashPath = Path.Combine(trashPath.Substring(11), "Trash");

                    if (!Directory.Exists(trashPath)) Directory.CreateDirectory(trashPath);
                    File.Move(filePath, Path.Combine(trashPath, newFileName));
                }

                RefreshDgv(dgvPayments, adapterPayments);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! dgvDocs.KeyUp: " + ex.Message);
                if (connection.State == ConnectionState.Open) connection.Close();
            }
        }

        private void btnRemoveAgreement_Click(object sender, EventArgs e)
        {
            RemoveAgreement();
        }

        private void btnRemoveDoc_Click(object sender, EventArgs e)
        {
            RemoveDoc();
        }

        private void btnRemovePay_Click(object sender, EventArgs e)
        {
            RemovePay();
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (txtBxContrName.Text == "") MessageBox.Show("Поле 'Номер контракта' необходимо заполнить.", "АСКИД");
            else if (txtBxSubject.Text == "") MessageBox.Show("Поле 'Предмет' необходимо заполнить.", "АСКИД");
            else if (new Regex("[0-9]+").Replace(txtBxNumber.Text, "") != "") MessageBox.Show("Поле 'Объем (количество)' может содержать только цифры", "АСКИД");
            else
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(String.Format(
                        "UPDATE Contracts SET Name=N'{0}', Date_start='{1}', Date_end={2}, Date_start_work={3}, Date_end_work={4}, " +
                            "Date_start_fact={5}, Date_end_fact={6}, Id_type={7}, Id_kind={8}, Subject=N'{9}', Cost=CONVERT(money, '{10}', 0), Number={11}, Okdp=N'{12}' " +
                        " WHERE Contracts.Id_cont={13}",
                        txtBxContrName.Text,
                        dtpDateStart.Value.ToShortDateString(),
                        dtpDateEnd.Checked ? "'" + dtpDateEnd.Value.ToShortDateString() + "'" : "NULL",
                        dtpDateStartWork.Checked ? "'" + dtpDateStartWork.Value.ToShortDateString() + "'" : "NULL",
                        dtpDateEndWork.Checked ? "'" + dtpDateEndWork.Value.ToShortDateString() + "'" : "NULL",
                        dtpDateStartFact.Checked ? "'" + dtpDateStartFact.Value.ToShortDateString() + "'" : "NULL",
                        dtpDateEndFact.Checked ? "'" + dtpDateEndFact.Value.ToShortDateString() + "'" : "NULL",
                        (cmbBxType.SelectedItem as CmbItem).Id, (cmbBxKind.SelectedItem as CmbItem).Id,
                        txtBxSubject.Text, txtBxCost.Text == "" ? "NULL" : new Regex(@" *[\,\.] *").Replace(txtBxCost.Text, "."),
                        txtBxNumber.Text == "" ? "NULL" : txtBxNumber.Text, txtBxOkdp.Text, IdCont), connection);
                    command.ExecuteNonQuery();
                    connection.Close();

                    SelectContractDetails();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка! btnSaveChanges: " + ex.Message);
                    if (connection.State == ConnectionState.Open) connection.Close();
                }
        }
    }
}

