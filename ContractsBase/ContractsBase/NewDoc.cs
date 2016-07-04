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
using System.IO;

namespace ContractsBase
{
    public partial class NewDoc : Form
    {
        SqlConnection connection;

        public string Path;
        public string Kind;
        public int KindId;
        public string Dir;
        public bool Success;
        int? IdCont;
        int IdStaff;

        public NewDoc(SqlConnection conn, int idStaff, List<string> newPaysDirs, int? idContract)
        {
            Success = false;
            InitializeComponent();
            connection = conn;
            IdCont = idContract;
            IdStaff = idStaff;

            // виды документов
            connection.Open();
            SqlDataReader reader = new SqlCommand("SELECT Id_kind, Kind FROM DocsKinds ORDER BY Kind", connection).ExecuteReader();
            while (reader.Read()) cmbBxKind.Items.Add(new CmbItem(reader.GetByte(0), reader.GetString(1)));
            reader.Close();
            connection.Close();

            cmbBxKind.DisplayMember = "Name";
            cmbBxKind.ValueMember = "Id";

            // список папок
            List<string> dirs = new List<string>();
            
            if (IdCont != null)
            {
                // вытаскиваем название отдела, где зарегистрировали договор и номер договора
                string contrPath = File.ReadAllLines("config.txt").Where(s => s.StartsWith("FileServer=")).First();
                contrPath = contrPath.Substring(11);
                connection.Open();
                reader = new SqlCommand(String.Format(
                    "SELECT Blocks.Block, Contracts.Name FROM Contracts " +
                    "INNER JOIN Staff ON Contracts.Id_staff = Staff.Id_staff " +
                    "INNER JOIN Blocks ON Staff.Id_block = Blocks.Id_block " +
                    "WHERE Contracts.Id_cont = {0}", IdCont), connection).ExecuteReader();
                reader.Read();
                contrPath = System.IO.Path.Combine(contrPath, reader.GetString(0), reader.GetString(1), "Docs");
                connection.Close();
                foreach (string dir in Directory.GetDirectories(contrPath)) dirs.Add(new DirectoryInfo(dir).Name);
                cmbBxFolders.Items.Add("Docs");
                cmbBxFolders.Items.AddRange(dirs.ToArray());
                cmbBxFolders.SelectedIndex = 0;
            }
            else if(newPaysDirs != null && newPaysDirs.Count != 0)
            {
                foreach (string dir in newPaysDirs) dirs.Add(new DirectoryInfo(dir).Name);
                cmbBxFolders.Items.Add("Docs");
                cmbBxFolders.Items.AddRange(dirs.ToArray());
                cmbBxFolders.SelectedIndex = 0;
            }
            else
            {
                cmbBxFolders.Visible = false;
                label3.Visible = false;
            }


            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "All files (*.*)|*.*";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtBxFilePath.Text = openFileDialog.FileName;
            };
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBxFilePath.Text == "") MessageBox.Show("Необходимо заполнить поле 'Документ'.", "АСКИД");
                else if (!File.Exists(txtBxFilePath.Text)) MessageBox.Show("Указанный файл не существует.", "АСКИД");
                else if (cmbBxKind.SelectedItem == null) MessageBox.Show("Необходимо указать вид добавляемого документа из списка.", "АСКИД");
                else
                {
                    Success = true;
                    Path = openFileDialog.FileName;
                    Kind = (cmbBxKind.SelectedItem as CmbItem).Name;
                    KindId = (cmbBxKind.SelectedItem as CmbItem).Id;
                    Dir = cmbBxFolders.Visible ? cmbBxFolders.SelectedItem.ToString() : "Docs";

                    // если вызвали из формы уже созданного договора,то сразу копируем файлы в папку договора
                    if (IdCont != null)
                    {
                        // если файл не в основной папке, то вносится ее название
                        string filePath = cmbBxFolders.SelectedItem.ToString() == "Docs" ? System.IO.Path.GetFileName(Path) :
                                System.IO.Path.Combine(cmbBxFolders.SelectedItem.ToString(), System.IO.Path.GetFileName(Path));

                        // вносим в базу
                        connection.Open();
                        SqlCommand command = new SqlCommand(String.Format(
                            "INSERT INTO Docs(Id_kind, Name, Date_add, Id_staff, Id_cont) VALUES ({0}, N'{1}', '{2}', {3}, {4})",
                            KindId, filePath, DateTime.Now, IdStaff, IdCont), connection);
                        command.ExecuteNonQuery();
                        connection.Close(); 


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

                        if (cmbBxFolders.SelectedItem.ToString() != "Docs") contrPath = System.IO.Path.Combine(contrPath, cmbBxFolders.SelectedItem.ToString());
                        if (!Directory.Exists(contrPath))
                        {
                            MessageBox.Show("Папка не найдена и создана.", "АКСИД");
                            Directory.CreateDirectory(contrPath);
                        }

                        if (File.Exists(System.IO.Path.Combine(contrPath, System.IO.Path.GetFileName(Path))) &&
                        MessageBox.Show("В папке уже существует файл '" + System.IO.Path.GetFileName(Path) + "'. Заменить его?", "АСКИД", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            File.Copy(Path, System.IO.Path.Combine(contrPath, System.IO.Path.GetFileName(Path)), true);
                        else File.Copy(Path, System.IO.Path.Combine(contrPath, System.IO.Path.GetFileName(Path)));
                        

                    }

                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка. " + Environment.NewLine + "btnOk: " + ex.Message);
                this.Close();
            }
        }

        private void NewDoc_Load(object sender, EventArgs e)
        {

        }
    }
}
