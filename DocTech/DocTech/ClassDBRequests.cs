using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DocTech
{
    public static class ClassDBRequests
    {
        //Получение списка имен элементов из таблицы
        public static List<string> getNameElements(string table)
        {
            List<string> elements = new List<string>();
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=TechDoc;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = "SELECT name FROM " + table + " ORDER BY name";
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    // выводим названия столбцов
                    //Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));

                    while (reader.Read()) // построчно считываем данные
                    {
                        //int id = reader.GetValue(0);
                        object name = reader.GetValue(0);
                        //string extension = reader.GetValue(2);
                        //byte[] file = reader.GetValue(3);


                        elements.Add(name.ToString());
                    }
                }
                reader.Close();
            }
            return elements;
        }

       
        //Сохранение файла в базу
        public static void SaveFileToDatabase(string filepath)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=TechDoc;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = @"INSERT INTO Files VALUES (@Name, @Extension, @File)";
                command.Parameters.Add("@Name", SqlDbType.Text);
                command.Parameters.Add("@Extension", SqlDbType.Char, 10);
                command.Parameters.Add("@File", SqlDbType.VarBinary);

                // путь к файлу для загрузки
                //string name = @"C:\Users\agapovay.PETROLIGHT\Downloads\Расчет графика импотеки.xlsx";
                // заголовок файла
                string extension = filepath.Substring(filepath.LastIndexOf('.') + 1);
                // получаем короткое имя файла для сохранения в бд
                string shortFileName = filepath.Substring(filepath.LastIndexOf('\\') + 1); // cats.jpg
                                                                                           // массив для хранения бинарных данных файла
                byte[] Data;
                using (System.IO.FileStream fs = new System.IO.FileStream(filepath, System.IO.FileMode.Open))
                {
                    Data = new byte[fs.Length];
                    fs.Read(Data, 0, Data.Length);
                }
                // передаем данные в команду через параметры
                command.Parameters["@Name"].Value = shortFileName;
                command.Parameters["@Extension"].Value = extension;
                command.Parameters["@File"].Value = Data;

                command.ExecuteNonQuery();
            }
        }

        //Четние файла из базы
        private static void ReadFileFromDatabase()
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=TechDoc;Integrated Security=True";
            List<File> files = new List<File>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Files WHERE id=4";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string filename = reader.GetString(1);
                    string extension = reader.GetString(2);
                    byte[] data = (byte[])reader.GetValue(3);

                    File file = new File(id, filename, extension, data);
                    files.Add(file);
                }
            }
            // сохраним первый файл из списка
            if (files.Count > 0)
            {
                string path = @"C:\utils\" + files[0].FileName;
                using (System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.OpenOrCreate))
                {
                    fs.Write(files[0].Data, 0, files[0].Data.Length);
                }
            }
        }
       
        //Добавление нового элемента (устройство, деталь, система)
        public static void newElement(string type, string number, string name)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=TechDoc;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = @"INSERT INTO " + type + " VALUES (@Name)";
                command.Parameters.Add("@Name", SqlDbType.Text);

                string elementName = number + " " + name;

                command.Parameters["@Name"].Value = elementName;

                command.ExecuteNonQuery();
            }
        }
    }
}
