using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataGridViewAutoFilter;

namespace ContractsBase
{
    public partial class ContractorDetails : Form
    {
        SqlConnection connection;
        int IdContractor;
        //int IdStaff;
        MainForm.CurrentUserParams UserParams;

        public ContractorDetails(SqlConnection conn, MainForm.CurrentUserParams userParams, int idCont)
        {
            InitializeComponent();
            connection = conn;
            IdContractor = idCont;
            UserParams = userParams;

            try
            {
                // запрос для даннх на форме
                connection.Open();
                SqlDataReader reader = new SqlCommand(String.Format(
                    "SELECT Name, Ogrn, Okpo, Oktmo, Okopf, Kpp, Inn, Member " +
                    "FROM Contractors WHERE Id_contractor = {0}", IdContractor), connection).ExecuteReader();

                reader.Read();
                txtBxName.Text = reader.GetString(0);
                txtBxOgrn.Text = reader.GetString(1);
                txtBxOkpo.Text = reader.GetString(2);
                txtBxOktmo.Text = reader.GetString(3);
                txtBxOkopf.Text = reader.GetString(4);
                txtBxKpp.Text = reader.GetString(5);
                txtBxInn.Text = reader.GetString(6);
                lblMember.Visible = reader.GetBoolean(7);
                this.Text += reader.GetString(0);


                reader.Close();
                connection.Close();

                // запрос для данных контрактов, заключенных с контрагентом
                SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand(String.Format(
                    "SELECT Contracts.Id_cont, Contracts.Name As ContName, Contracts.Date_start, " +
                        "Contracts.Date_end, Contracts.Cost, Staff.Name AS StaffName " +
                    "FROM Contractors_Cont " +
                        "INNER JOIN Contracts ON Contractors_Cont.Id_cont = Contracts.Id_cont " +
                        "INNER JOIN Staff ON Contracts.Id_staff = Staff.Id_staff " +
                    "WHERE Contractors_Cont.Id_contractor = {0}", IdContractor), connection));

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                BindingSource bindSource = new BindingSource();
                bindSource.DataSource = dataTable;

                dgvConts.Columns.Add(new DataGridViewAutoFilterTextBoxColumn { HeaderText = "№ контракта", DataPropertyName = "ContName", Name = "ContName" });
                dgvConts.Columns.Add(new DataGridViewAutoFilterTextBoxColumn { HeaderText = "Дата начала", DataPropertyName = "Date_start", Name = "Date_start" });
                dgvConts.Columns.Add(new DataGridViewAutoFilterTextBoxColumn { HeaderText = "Дата окончания", DataPropertyName = "Date_end", Name = "Date_end" });
                dgvConts.Columns.Add(new DataGridViewAutoFilterTextBoxColumn { HeaderText = "Стоимость", DataPropertyName = "Cost", Name = "Cost" });
                dgvConts.Columns.Add(new DataGridViewAutoFilterTextBoxColumn { HeaderText = "Ответственный", DataPropertyName = "StaffName", Name = "StaffName" });
                dgvConts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id_cont", Name = "Id_cont" });
                dgvConts.Columns["Id_cont"].Visible = false;
                dgvConts.RowHeadersWidth = 5;

                dgvConts.DataSource = bindSource;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка! " + Environment.NewLine + "ContractorDetails: " + ex.Message, "АСКИД");
            }
        }

        private void ContractorDetails_Load(object sender, EventArgs e)
        {

        }

        private void dgvConts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0 || UserParams.AccessType != 1) return;
            ContractDetails form = new ContractDetails(connection, Convert.ToInt32(dgvConts.CurrentRow.Cells["Id_cont"].Value), UserParams);
            form.ShowDialog();
        }
    }
}
