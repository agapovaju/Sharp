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
    public partial class Contractors : Form
    {
        bool willAddToContract;
        SqlConnection connection;
        SqlDataAdapter adapter;
        public Dictionary<int, string> ChoosingContractors;
        MainForm.CurrentUserParams UserParams;
        //private bool willAddToContract;

        public Contractors(bool fromNewContract, SqlConnection conn, MainForm.CurrentUserParams userParams)
        {
            InitializeComponent();
            willAddToContract = fromNewContract;
            connection = conn;
            UserParams = userParams;

            if (!willAddToContract) btnAddToCont.Visible = false;

            adapter = new SqlDataAdapter(new SqlCommand(
                "SELECT Id_contractor, Name, Inn, Kpp, IIF (Member='True', 'Да', 'Нет') AS Mem FROM Contractors", connection));

            if (willAddToContract)
            {
                dgvContractors.Columns.Add(new DataGridViewCheckBoxColumn { HeaderText = "", Name = "AddToContr" });
                dgvContractors.Columns["AddToContr"].FillWeight = 50;
            }
            dgvContractors.Columns.Add(new DataGridViewAutoFilterTextBoxColumn { HeaderText = "Организация/ФИО", DataPropertyName = "Name", Name = "Name" });
            dgvContractors.Columns.Add(new DataGridViewAutoFilterTextBoxColumn { HeaderText = "ИНН", DataPropertyName = "Inn", Name = "Inn" });
            dgvContractors.Columns.Add(new DataGridViewAutoFilterTextBoxColumn { HeaderText = "КПП", DataPropertyName = "Kpp", Name = "Kpp" });
            dgvContractors.Columns.Add(new DataGridViewAutoFilterTextBoxColumn { HeaderText = "СМП", DataPropertyName = "Mem", Name = "Mem" });
            dgvContractors.Columns.Add(new DataGridViewAutoFilterTextBoxColumn { HeaderText = "Id_contractor", DataPropertyName = "Id_contractor", Name = "Id_contractor" });

            dgvContractors.RowHeadersWidth = 5;
            dgvContractors.Columns["Name"].FillWeight = 300;
            dgvContractors.Columns["Id_contractor"].Visible = false;

            

            RefreshDataInDgv();

            
        }

        private void Contractors_Load(object sender, EventArgs e)
        {
            
        }

        private void RefreshDataInDgv()
        {
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            BindingSource bindSource = new BindingSource();
            bindSource.DataSource = dataTable;
            dgvContractors.DataSource = bindSource;
        }

        private void btnNewContractor_Click(object sender, EventArgs e)
        {
            NewContractor form = new NewContractor(connection);
            form.ShowDialog();
            RefreshDataInDgv();
        }

        private void btnAddToCont_Click(object sender, EventArgs e)
        {
            ChoosingContractors = new Dictionary<int, string>();
            foreach (DataGridViewRow row in dgvContractors.Rows)
                if (Convert.ToBoolean(row.Cells["AddToContr"].Value))
                    ChoosingContractors.Add(Convert.ToInt32(row.Cells["Id_contractor"].Value),
                    row.Cells["Name"].Value.ToString());
            //ChoosingContractors = new List<string>();
            //foreach (DataGridViewRow row in dgvContractors.Rows)
            //    if (Convert.ToBoolean(row.Cells["AddToContr"].Value))
            //        ChoosingContractors.Add(row.Cells["Name"].Value.ToString());

            Close();
        }

        private void dgvContractors_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0 || e.RowIndex < 0) return;
            ContractorDetails form = new ContractorDetails(connection, UserParams,
                Convert.ToInt32(dgvContractors.CurrentRow.Cells["Id_contractor"].Value));
            form.ShowDialog();
        }

        private void txtBxFindName_TextChanged(object sender, EventArgs e)
        {
            BindingSource bindSource = new BindingSource();
            bindSource.DataSource = dgvContractors.DataSource as BindingSource;

            if (txtBxFindName.Text == "") bindSource.Filter = "";
            else bindSource.Filter = String.Format("Name LIKE '*{0}*'", txtBxFindName.Text);
        }

        private void dgvContractors_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0 || e.RowIndex < 0) return;
            (dgvContractors.CurrentCell as DataGridViewCheckBoxCell).Value = 
                !Convert.ToBoolean((dgvContractors.CurrentCell as DataGridViewCheckBoxCell).Value);
        }
    }
}
