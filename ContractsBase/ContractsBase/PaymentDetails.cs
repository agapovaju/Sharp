using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContractsBase
{
    public partial class PaymentDetails : Form
    {
        SqlConnection connection;
        int IdPay;

        public PaymentDetails(SqlConnection conn, int idPay)
        {
            try
            { 
            InitializeComponent();
            connection = conn;
            IdPay = idPay;

            // запрос для данны по контракту
            connection.Open();
            SqlDataReader reader = new SqlCommand(String.Format(
                "SELECT Pay_no, Date_pay, Date_add, Invoice, Name, Ins_docs " +
                "FROM Payments INNER JOIN Staff ON Payments.Id_staff = Staff.Id_staff " +
                "WHERE(Payments.Id_pay = {0})", IdPay), connection).ExecuteReader();

            // выносим данные на форму
            reader.Read();
            txtBxPayNo.Text = !reader.IsDBNull(0) ? reader.GetString(0) : "";
            txtBxDatePay.Text = !reader.IsDBNull(1) ? reader.GetDateTime(1).ToShortDateString() : "";
            txtBxDateAdd.Text = !reader.IsDBNull(2) ? reader.GetDateTime(2).ToShortDateString() : "";
            txtBxInvoice.Text = !reader.IsDBNull(3) ? reader.GetString(3) : "";
            txtBxSName.Text = !reader.IsDBNull(4) ? reader.GetString(4) : "";
            chkBxInsDocs.CheckedChanged -= chkBxInsDocs_CheckedChanged;
            chkBxInsDocs.Checked = reader.GetBoolean(5);
            chkBxInsDocs.CheckedChanged += chkBxInsDocs_CheckedChanged;

            if (!reader.IsDBNull(0)) this.Text += " №" + reader.GetString(0);

            reader.Close();
            connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка. " + Environment.NewLine + "btnOk: " + ex.Message);
                if (connection.State == ConnectionState.Open) connection.Close();
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chkBxInsDocs_CheckedChanged(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand(String.Format("UPDATE Payments SET Ins_docs='{0}' WHERE Id_pay={1}",
                chkBxInsDocs.Checked, IdPay), connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
