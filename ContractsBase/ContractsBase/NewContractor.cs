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

namespace ContractsBase
{
    public partial class NewContractor : Form
    {
        SqlConnection connection;
        public NewContractor(SqlConnection conn)
        {
            InitializeComponent();
            connection = conn;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtBxName.Text == "") MessageBox.Show("Необходимо заполнить поле 'Организация/ФИО'.", "АСКИД");
            else if (txtBxOktmo.Text == "") MessageBox.Show("Необходимо заполнить поле 'ОКТМО'.", "АСКИД");
            else if (txtBxOkopf.Text == "") MessageBox.Show("Необходимо заполнить поле 'ОКОПФ'.", "АСКИД");
            else if (txtBxOgrn.Text == "") MessageBox.Show("Необходимо заполнить поле 'ОГРН'.", "АСКИД");
            else if (txtBxOkpo.Text == "") MessageBox.Show("Необходимо заполнить поле 'ОКПО'.", "АСКИД");
            else if (txtBxInn.Text == "") MessageBox.Show("Необходимо заполнить поле 'ИНН'.", "АСКИД");
            else if (txtBxKpp.Text == "") MessageBox.Show("Необходимо заполнить поле 'КПП'.", "АСКИД");
            else
            {
                connection.Open();
                SqlCommand command = new SqlCommand(String.Format(
                    "INSERT INTO Contractors(Name, Oktmo, Okopf, Ogrn, Okpo, Inn, Kpp, Member, Id_staff) " +
                    "VALUES (N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}', '{7}', {8} )",
                    txtBxName.Text.Replace("'","\""), txtBxOktmo.Text, txtBxOkopf.Text, txtBxOgrn.Text, txtBxOkpo.Text, txtBxInn.Text, txtBxKpp.Text, chkBxMember.Checked, "21"), connection);

                command.ExecuteNonQuery();
                connection.Close();
                Close();
            }
        }

        private void NewContractor_Load(object sender, EventArgs e)
        {

        }
    }
}
