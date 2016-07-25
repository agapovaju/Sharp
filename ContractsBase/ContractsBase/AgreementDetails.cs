using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ContractsBase
{
    public partial class AgreementDetails : Form
    {
        SqlConnection connection;
        int IdAgr;

        public AgreementDetails(SqlConnection conn, int idAgr)
        {
            InitializeComponent();
            connection = conn;
            IdAgr = idAgr;

            // запрос для данны по догоору
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
            txtBxDateCreate.Text = !reader.IsDBNull(1) ? reader.GetDateTime(1).ToShortDateString() : "";
            txtBxDateAdd.Text = !reader.IsDBNull(2) ? reader.GetDateTime(2).ToShortDateString() : "";
            txtBxDateEnd.Text = !reader.IsDBNull(3) ? reader.GetDateTime(3).ToShortDateString() : "";
            txtBxStartWork.Text = !reader.IsDBNull(4) ? reader.GetDateTime(4).ToShortDateString() : "";
            txtBxStartFact.Text = !reader.IsDBNull(5) ? reader.GetDateTime(5).ToShortDateString() : "";
            txtBxEndWork.Text = !reader.IsDBNull(6) ? reader.GetDateTime(6).ToShortDateString() : "";
            txtBxEndFact.Text = !reader.IsDBNull(7) ? reader.GetDateTime(7).ToShortDateString() : "";
            txtBxCost.Text = !reader.IsDBNull(8) ? reader.GetSqlMoney(8).ToString() : "";
            txtBxNumber.Text = !reader.IsDBNull(9) ? reader.GetInt32(9).ToString() : "";
            txtBxStaff.Text = !reader.IsDBNull(10) ? reader.GetString(10) : "";
            chkBxInsDocs.CheckedChanged -= chkBxInsDocs_CheckedChanged;
            chkBxInsDocs.Checked = reader.GetBoolean(11);
            chkBxInsDocs.CheckedChanged += chkBxInsDocs_CheckedChanged;
            chkBxDiss.Checked = reader.GetBoolean(12);

            if (!reader.IsDBNull(0)) this.Text += " №" + reader.GetString(0);

            reader.Close();
            connection.Close();
        }

        private void AgreementDetails_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkBxInsDocs_CheckedChanged(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand(String.Format("UPDATE Agreements SET Ins_docs='{0}' WHERE Id_agr={1}",
                chkBxInsDocs.Checked, IdAgr), connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
