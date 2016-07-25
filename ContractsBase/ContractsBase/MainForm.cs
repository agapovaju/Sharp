using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using SData = System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using DataGridViewAutoFilter;
using System.Windows.Forms;
using System.IO;

namespace ContractsBase
{

    public partial class MainForm : Form
    {
        SqlConnection connection;
        SqlDataAdapter adapter;
        public CurrentUserParams UserParams;
        int[] SearchContractors;

        public struct CurrentUserParams
        {
            public int IdStaff;
            public int AccessType;
            public int IdBlock;
            public string Name;
        }

        public MainForm()
        {
            InitializeComponent();
            dtpDateStart.Format = DateTimePickerFormat.Custom;
            dtpDateStart.CustomFormat = "dd.MM.yyyy";
            dtpDateEnd.Format = DateTimePickerFormat.Custom;
            dtpDateEnd.CustomFormat = "dd.MM.yyyy";

            dtpDocsStart.Format = DateTimePickerFormat.Custom;
            dtpDocsStart.CustomFormat = "dd.MM.yyyy";
            dtpDocsEnd.Format = DateTimePickerFormat.Custom;
            dtpDocsEnd.CustomFormat = "dd.MM.yyyy";

            cmbBxDate.SelectedIndex = 0;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                string strConn = File.ReadAllLines("config.txt").Where(s => s.StartsWith("ConnectionString=")).First();
                connection = new SqlConnection(strConn.Substring(17));

                // если в конфиге не протписан длругой пользователь, то берем того, что вошел
                if (File.ReadAllLines("config.txt").Where(s => s.StartsWith("user=")).Any() &&
                    File.ReadAllLines("config.txt").Where(s => s.StartsWith("user=")).First() != "user=")
                    UserParams = new CurrentUserParams
                    {
                        IdStaff = Convert.ToInt32(File.ReadAllLines("config.txt").Where(s => s.StartsWith("user=")).First().Substring(5).Split(';')[0]),
                        AccessType = Convert.ToInt32(File.ReadAllLines("config.txt").Where(s => s.StartsWith("user=")).First().Substring(5).Split(';')[1]),
                        IdBlock = Convert.ToInt32(File.ReadAllLines("config.txt").Where(s => s.StartsWith("user=")).First().Substring(5).Split(';')[2]),
                        Name = File.ReadAllLines("config.txt").Where(s => s.StartsWith("user=")).First().Substring(5).Split(';')[3]
                    };
                else
                {
                    connection.Open();
                    SqlDataReader reader = new SqlCommand(String.Format(
                        "SELECT Id_staff, Access_type, Id_block, Name FROM Staff " +
                        "WHERE Login = '{0}'", Environment.UserName), connection).ExecuteReader();
                    if (!reader.HasRows)
                    {
                        MessageBox.Show("У вас нет досутпа к этой программе.", "АСКИД");
                        System.Windows.Forms.Application.Exit();
                    }
                    reader.Read();
                    UserParams = new CurrentUserParams { IdStaff = reader.GetByte(0), AccessType = reader.GetByte(1),
                        IdBlock = reader.GetByte(2), Name = reader.GetString(3) };
                    reader.Close();
                    connection.Close();
                }

                // скрываем для непосвещенных сводку по документам
                if (UserParams.AccessType != 1) groupBoxSummary.Visible = false;

                // запрос на заполнение таблицы договоров
                string strCommand = "SELECT Contracts.Name as CName, " +
                    "Contracts.Date_start, " +
                    "CONVERT(nvarchar(10), Contracts.Date_add, 104) AS Date_add, " +
                    "Contracts.Date_end, " +
                    //"CONVERT(varchar(10), CONVERT(money, Contracts.Cost), 0) AS Cost, " +
                    "CONVERT(varchar(21), CONVERT(money, " +
                        "CASE " +
                              "WHEN Contracts.Cost IS NULL AND Agreements.Cost IS NULL THEN '' " +
                              "WHEN Contracts.Cost IS NOT NULL AND Agreements.Cost IS NULL THEN Contracts.Cost " +
                              "WHEN Contracts.Cost IS NULL AND Agreements.Cost IS NOT NULL THEN Agreements.Cost " +
                              "WHEN Contracts.Cost IS NOT NULL AND Agreements.Cost IS NOT NULL THEN Contracts.Cost + Agreements.Cost " +
                           "END), 0) AS Cost, " +
                    "Staff.Name as SName, " +
                    "Contracts.Ins_docs, " +
                    "Contracts.Id_cont " +
                "FROM Contracts INNER JOIN Staff ON Contracts.Id_staff = Staff.Id_staff " +
                    "INNER JOIN Blocks ON Staff.Id_block = Blocks.Id_block " +
                    "LEFT OUTER JOIN Agreements ON Agreements.Id_cont = Contracts.Id_cont " +
                "WHERE ((Agreements.Last = 'True') OR (Agreements.Last IS NULL))";

                if (UserParams.AccessType != 1) strCommand += " AND Blocks.Id_block = " + UserParams.IdBlock;

                adapter = new SqlDataAdapter(new SqlCommand(strCommand, connection));

                dgvConts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id_cont", Name = "Id_cont" });
                dgvConts.Columns.Add(new DataGridViewAutoFilterTextBoxColumn { DataPropertyName = "CName", HeaderText = "№ договора", Name = "CName" });
                dgvConts.Columns.Add(new DataGridViewAutoFilterTextBoxColumn { DataPropertyName = "Date_start", HeaderText = "Дата заключения", Name = "Date_start" });
                dgvConts.Columns.Add(new DataGridViewAutoFilterTextBoxColumn { DataPropertyName = "Date_add", HeaderText = "Дата внесения", Name = "Date_add" });
                dgvConts.Columns.Add(new DataGridViewAutoFilterTextBoxColumn { DataPropertyName = "Date_end", HeaderText = "Дата завершения", Name = "Date_end" });
                dgvConts.Columns.Add(new DataGridViewAutoFilterTextBoxColumn { DataPropertyName = "Cost", HeaderText = "Стоимость", Name = "Cost" });
                dgvConts.Columns.Add(new DataGridViewAutoFilterTextBoxColumn { DataPropertyName = "SName", HeaderText = "Ответственный", Name = "SName" });
                dgvConts.Columns.Add(new DataGridViewAutoFilterTextBoxColumn { DataPropertyName = "Ins_docs", HeaderText = "Документы на ГЗ", Name = "Ins_docs" });
                dgvConts.Columns["Id_cont"].Visible = false;
                dgvConts.Columns["Ins_docs"].Visible = false;

                RefreshDgv();

                dgvConts.RowHeadersWidth = 10;

                // выделяем цветом просроченные договора
                ColoredRows();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка. MainForm.Load:" + ex.Message);
                if (connection.State == SData.ConnectionState.Open) connection.Close();
                this.Close();
            }
        }

        private void RefreshDgv()
        {
            SData.DataTable dataTable = new SData.DataTable("Contracts");
            adapter.Fill(dataTable);
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = dataTable;
            dgvConts.DataSource = bindingSource;
        }

        private void ColoredRows()
        {
            // запрос на список договоров, где есть просроченные документы
            Dictionary<int, bool> coloredContrs = new Dictionary<int, bool>();
            try
            {
                connection.Open();
                SqlDataReader reader = new SqlCommand(
                    "SELECT DISTINCT Contracts.Id_cont, " +
                         "IIF( " +
                            "(Agreements.Ins_docs = 'False' AND DATEDIFF(day, Agreements.Date_create, Agreements.Date_add) >= 3) OR " +
                            "(Payments.Ins_docs = 'False' AND DATEDIFF(day, Payments.Date_pay, Payments.Date_add) >= 3) OR " +
                            "(Contracts.Ins_docs = 'False'AND DATEDIFF(day, Contracts.Date_start, Contracts.Date_add) >= 1), 'True', 'False') AS ColoredRow " +
                    "FROM Contracts INNER JOIN Staff ON Contracts.Id_staff = Staff.Id_staff " +
                        "LEFT OUTER JOIN Payments ON Contracts.Id_cont = Payments.Id_cont " +
                        "LEFT OUTER JOIN Agreements ON Contracts.Id_cont = Agreements.Id_cont", connection).ExecuteReader();
                while (reader.Read()) coloredContrs.Add(reader.GetInt32(0), reader.GetString(1) == "True" ? true : false);
                reader.Close();
                connection.Close();

                foreach (DataGridViewRow row in dgvConts.Rows)
                {
                    if (coloredContrs[Convert.ToInt32(row.Cells["Id_cont"].Value)])
                        row.DefaultCellStyle.BackColor = Color.LightPink;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка. MainForm.ColoredRows:" + ex.Message);
                if (connection.State == SData.ConnectionState.Open) connection.Close();
            }

        }

        private void NewContract_Click(object sender, EventArgs e)
        {
            NewContract form = new NewContract(connection, UserParams);
            form.ShowDialog();

            // если договор был добавлен, то обновить таблицу договор
            if (form.Success)
            {
                int selRowIndex = dgvConts.CurrentRow.Index;

                SData.DataTable dataTable = new SData.DataTable("Contracts");
                adapter.Fill(dataTable);
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                dgvConts.DataSource = bindingSource;

                if (dgvConts.Rows.Count >= selRowIndex)
                {
                    dgvConts.Rows[selRowIndex].Selected = true;
                    dgvConts.FirstDisplayedScrollingRowIndex = selRowIndex;
                }
            }


        }

        private void btnContractors_Click(object sender, EventArgs e)
        {
            bool willAddToContract = false;
            Contractors form = new Contractors(willAddToContract, connection, UserParams);
            form.ShowDialog();
        }

        private void btnAllContractors_Click(object sender, EventArgs e)
        {
            bool willAddToContract = true;
            Contractors form = new Contractors(willAddToContract, connection, UserParams);
            form.ShowDialog();

            if (form.ChoosingContractors != null) 
            {
                SearchContractors = form.ChoosingContractors.Keys.ToArray();
                txtBxContractor.Text = String.Join(" ИЛИ ", form.ChoosingContractors.Values);
                //txtBxContractor.Text = String.Join(" ИЛИ ", form.ChoosingContractors);
            }
        }

        private void dgvConts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;
            int selRowIndex = dgvConts.CurrentRow.Index;

            ContractDetails form = new ContractDetails(connection, 
                Convert.ToInt32(dgvConts.CurrentRow.Cells["Id_cont"].Value), UserParams);
            form.ShowDialog();
            RefreshDgv();

            if (dgvConts.Rows.Count >= selRowIndex)
            {
                dgvConts.Rows[selRowIndex].Selected = true;
                dgvConts.FirstDisplayedScrollingRowIndex = selRowIndex;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBxContract.Text = "";
            txtBxContractor.Text = "";
            cmbBxDate.SelectedIndex = 0;
            dtpDateStart.Value = DateTime.Now;
            dtpDateStart.Checked = false;
            dtpDateEnd.Value = DateTime.Now;
            dtpDateEnd.Checked = false;

            (dgvConts.DataSource as BindingSource).Filter = "";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string filter = "";
            try
            {
                //if (SearchContractors != null && SearchContractors.Count() > 0)
                //{
                //    // список контрагентов, пересекающихся с контрагентами
                //    connection.Open();
                //    SqlDataReader reader = new SqlCommand("SELECT id_cont FROM Contractors_Cont WHERE Id_contractor=" +
                //        String.Join(" OR Id_contractor=", SearchContractors), connection).ExecuteReader();
                //    while(reader.Read()) filter += "Id_cont = " + reader.GetInt32(0).ToString() + " OR ";
                //    reader.Close();
                //    connection.Close();

                //    if (filter.Length > 0) filter = "(" + filter.Substring(0, filter.Length - 3) + ")";
                //    else filter = "(Id_cont=0)";
                //}
                if(txtBxContractor.Text != "")
                {

                    string strCommand = "SELECT id_cont FROM Contractors_Cont INNER JOIN Contractors ON Contractors_Cont.Id_contractor = Contractors.Id_contractor WHERE ";
                    foreach (string contractor in txtBxContractor.Text.Replace(" ИЛИ ", "@").Split('@'))
                        strCommand += String.Format(" Contractors.Name Like '%{0}%' OR ", contractor);
                    strCommand = strCommand.Substring(0, strCommand.Length - 3);

                    connection.Open();
                    SqlDataReader reader = new SqlCommand(strCommand, connection).ExecuteReader();
                    while (reader.Read()) filter += "Id_cont = " + reader.GetInt32(0).ToString() + " OR ";
                    reader.Close();
                    connection.Close();

                    if (filter.Length > 0) filter = "(" + filter.Substring(0, filter.Length - 3) + ")";
                        else filter = "(Id_cont=0)";
                    //filter = String.Format("(CName LIKE '%{0}%')", txtBxContract.Text);
                }
                if (txtBxContract.Text != "")
                {
                    if (filter != "") filter += " AND ";
                    filter += String.Format("(CName LIKE '%{0}%')", txtBxContract.Text);
                }

                // моного условий для дат
                if (dtpDateStart.Checked || dtpDateEnd.Checked)
                {
                    if (filter != "") filter += " AND ";
                    if (dtpDateStart.Checked && dtpDateEnd.Checked)
                    {
                        if (cmbBxDate.Text == "по всем датам")
                            filter += "((Date_start >= '" + dtpDateStart.Value.ToShortDateString() + "' AND Date_start <= '" + dtpDateEnd.Value.ToShortDateString() +
                                "') OR (Date_end >= '" + dtpDateStart.Value.ToShortDateString() + "' AND Date_end <= '" + dtpDateEnd.Value.ToShortDateString() + "'))";
                        else if (cmbBxDate.Text == "заключения")
                            filter += "(Date_end >= '" + dtpDateStart.Value.ToShortDateString() + "' AND Date_end <= '" + dtpDateEnd.Value.ToShortDateString() + "')";
                        else if (cmbBxDate.Text == "окончания")
                            filter += "(Date_end >= '" + dtpDateStart.Value.ToShortDateString() + "' AND Date_end <= '" + dtpDateEnd.Value.ToShortDateString() + "')";
                    }
                    else if (dtpDateStart.Checked)
                    {
                        if (cmbBxDate.Text == "по всем датам")
                            filter += "((Date_start >= '" + dtpDateStart.Value.ToShortDateString() + "') OR (Date_end >= '" + dtpDateStart.Value.ToShortDateString() + "'))";
                        else if (cmbBxDate.Text == "заключения") filter += "(Date_start >= '" + dtpDateStart.Value.ToShortDateString() + "')";
                        else if (cmbBxDate.Text == "окончания") filter += "(Date_end >= '" + dtpDateStart.Value.ToShortDateString() + "')";
                    }
                    else
                    {
                        if (cmbBxDate.Text == "по всем датам")
                            filter += "((Date_start <= '" + dtpDateEnd.Value.ToShortDateString() + "') OR (Date_end <= '" + dtpDateEnd.Value.ToShortDateString() + "'))";
                        else if (cmbBxDate.Text == "заключения") filter += "(Date_start <= '" + dtpDateEnd.Value.ToShortDateString() + "')";
                        else if (cmbBxDate.Text == "окончания") filter += "(Date_end <= '" + dtpDateEnd.Value.ToShortDateString() + "')";
                    }
                }

            (dgvConts.DataSource as BindingSource).Filter = filter;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка. btnSearch: " + ex.Message);
                if (connection.State == SData.ConnectionState.Open) connection.Close();
            }
        }
        
        private void dgvConts_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ColoredRows();
        }

        private void btnDocsOk_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string strContrPart =
                    "SELECT Contracts.Date_add, ContKinds.Kind, Contracts.Name, Contracts.Name, CStaff.Name , " +
                        "(SELECT Contractors.Name + ', ' " +
                        "FROM Contractors_Cont CC1 INNER JOIN Contractors ON CC1.Id_contractor = Contractors.Id_contractor " +
                        "WHERE CC1.Id_cont=CC2.Id_cont FOR xml path('') ) " +
                    "FROM Contracts " +
                        "INNER JOIN ContKinds ON Contracts.Id_kind = ContKinds.Id_kind " +
                        "INNER JOIN Staff AS CStaff ON Contracts.Id_staff = CStaff.Id_staff " +
                        "INNER JOIN Blocks ON CStaff.Id_block = Blocks.Id_block " +
                        "INNER JOIN Contractors_Cont AS CC2 ON CC2.Id_cont = Contracts.Id_cont " +
                    "WHERE_CONDITION " +
                    "GROUP BY Contracts.Id_cont, Contracts.Date_add, ContKinds.Kind, Contracts.Name, Contracts.Name, CStaff.Name, CC2.Id_cont ";
                string strAgrPart =
                    "UNION " +
                    "SELECT Agreements.Date_add, 'Дополнительное соглашение', Contracts.Name, Agreements.Name, AStaff.Name, " +
                        "(SELECT Contractors.Name + ', ' " +
                        "FROM Contractors_Cont CC1 INNER JOIN Contractors ON CC1.Id_contractor = Contractors.Id_contractor " +
                        "WHERE CC1.Id_cont=CC2.Id_cont FOR xml path('') ) " +
                    "FROM Agreements " +
                        "INNER JOIN Contracts ON Agreements.Id_cont = Contracts.Id_cont " +
                        "INNER JOIN Staff AS AStaff ON Agreements.Id_staff = AStaff.Id_staff " +
                        "INNER JOIN Contractors_Cont AS CC2 ON CC2.Id_cont = Contracts.Id_cont " +
                    "WHERE_CONDITION " +
                    "GROUP BY Agreements.Date_add, Contracts.Name, Agreements.Name, AStaff.Name, CC2.Id_cont ";
                string strPayPart =
                    "UNION " +
                    "SELECT Payments.Date_add, 'Платежное поручение', Contracts.Name, Payments.Pay_no, Staff.Name , " +
                        "(SELECT Contractors.Name + ', ' " +
                        "FROM Contractors_Cont CC1 INNER JOIN Contractors ON CC1.Id_contractor = Contractors.Id_contractor " +
                        "WHERE CC1.Id_cont=CC2.Id_cont FOR xml path('') ) " +
                    "FROM Payments " +
                        "INNER JOIN Staff ON Payments.Id_staff = Staff.Id_staff " +
                        "INNER JOIN Contracts ON Payments.Id_cont = Contracts.Id_cont " +
                        "INNER JOIN Contractors_Cont AS CC2 ON CC2.Id_cont = Contracts.Id_cont " +
                    "WHERE_CONDITION " +
                    "GROUP BY Payments.Date_add, Contracts.Name, Payments.Pay_no, Staff.Name, CC2.Id_cont ";
                string strDocsPart =
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
                    "WHERE_CONDITION " +
                    "GROUP BY Docs.Date_add, DocsKinds.Kind, Contracts.Name, Docs.Name, Staff.Name, CC2.Id_cont ";

                // т.к. в базе хранится дата+время
                DateTime dateStart = new DateTime(dtpDocsStart.Value.Year, dtpDocsStart.Value.Month, dtpDocsStart.Value.Day, 0,0,1);
                DateTime dateEnd = new DateTime(dtpDocsEnd.Value.Year, dtpDocsEnd.Value.Month, dtpDocsEnd.Value.Day, 23, 59, 59);

                if (dtpDocsStart.Checked && dtpDocsEnd.Checked)
                {
                    strContrPart = strContrPart.Replace("WHERE_CONDITION ", "WHERE Contracts.Date_add >='" + dateStart + "' AND Contracts.Date_add <='" + dateEnd + "' ");
                    strAgrPart = strAgrPart.Replace("WHERE_CONDITION ", "WHERE Agreements.Date_add >='" + dateStart + "' AND Agreements.Date_add <='" + dateEnd + "' ");
                    strPayPart = strPayPart.Replace("WHERE_CONDITION ", "WHERE Payments.Date_add >='" + dateStart + "' AND Payments.Date_add <='" + dateEnd + "' ");
                    strDocsPart = strDocsPart.Replace("WHERE_CONDITION ", "WHERE Docs.Date_add >='" + dateStart + "' AND Docs.Date_add <='" + dateEnd + "' ");
                }
                else if (dtpDocsStart.Checked)
                {
                    strContrPart = strContrPart.Replace("WHERE_CONDITION ", "WHERE Contracts.Date_add >='" + dateStart + "' ");
                    strAgrPart = strAgrPart.Replace("WHERE_CONDITION ", "WHERE Agreements.Date_add >='" + dateStart + "' ");
                    strPayPart = strPayPart.Replace("WHERE_CONDITION ", "WHERE Payments.Date_add >='" + dateStart + "' ");
                    strDocsPart = strDocsPart.Replace("WHERE_CONDITION ", "WHERE Docs.Date_add >='" + dateStart + "' ");
                }
                else if (dtpDocsEnd.Checked)
                {
                    strContrPart = strContrPart.Replace("WHERE_CONDITION ", "WHERE Contracts.Date_add <='" + dateEnd + "' ");
                    strAgrPart = strAgrPart.Replace("WHERE_CONDITION ", "WHERE Agreements.Date_add <='" + dateEnd + "' ");
                    strPayPart = strPayPart.Replace("WHERE_CONDITION ", "WHERE Payments.Date_add <='" + dateEnd + "' ");
                    strDocsPart = strDocsPart.Replace("WHERE_CONDITION ", "WHERE Docs.Date_add <='" + dateEnd + "' ");
                }
                else
                {
                    strContrPart = strContrPart.Replace("WHERE_CONDITION ", "");
                    strAgrPart = strAgrPart.Replace("WHERE_CONDITION ", "");
                    strPayPart = strPayPart.Replace("WHERE_CONDITION ", "");
                    strDocsPart = strDocsPart.Replace("WHERE_CONDITION ", "");
                }

                connection.Open();
                SqlDataReader reader = new SqlCommand(strContrPart + strAgrPart + strPayPart + strDocsPart, connection).ExecuteReader();

                if (!reader.HasRows)
                {
                    MessageBox.Show("Документов за этот период не было.", "АСКИД");
                    if (connection.State == SData.ConnectionState.Open) connection.Close();
                    return;
                }


                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                #region сводка в .csv
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
                #endregion

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
                xlSheet.Cells[rowCounter, 6] = "Контрагенты";
                rowCounter++;

                while (reader.Read())
                {
                    xlSheet.Cells[rowCounter, 1] = reader.GetDateTime(0).ToShortDateString();
                    xlSheet.Cells[rowCounter, 2] = reader.GetString(1);
                    xlSheet.Cells[rowCounter, 3] = reader.GetString(2);
                    xlSheet.Cells[rowCounter, 4] = reader.GetString(3);
                    xlSheet.Cells[rowCounter, 5] = reader.GetString(4);
                    xlSheet.Cells[rowCounter, 6] = reader.GetString(5);
                    rowCounter++;
                }

                reader.Close();
                connection.Close();

                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
                string fileName = "Сводка документов.xlsx";
                if (File.Exists(Path.Combine(path, fileName)))
                    fileName = "Сводка документов_" + Directory.GetFiles(path, "Сводка документов*.xlsx").Count() + ".xlsx";

                xlApp.ActiveWorkbook.SaveAs(Path.Combine(path, fileName));
                xlApp.Visible = true;

                this.Cursor = Cursors.Default;

                stopWatch.Stop();
                if(UserParams.IdStaff == 18) MessageBox.Show("Время генерации отчета: " + stopWatch.ElapsedMilliseconds.ToString() + " мс.", "АСКИД");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка. btnDocsOk: " + ex.Message);
                if (connection.State == SData.ConnectionState.Open) connection.Close();
            }
        }
    }
}


