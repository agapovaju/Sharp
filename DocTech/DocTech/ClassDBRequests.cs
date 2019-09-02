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
                connection.Close();
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
                connection.Close();
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
                connection.Close();
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
                connection.Close();
            }
        }

        //Создание новых связей
        public static void newRelation(string elementType, string containerType, string elementName, string containerName, string table)
        {
            int containerId = new int();
            int elementId = new int(); ;
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=TechDoc;Integrated Security=True";
            string tableForGI = containerType + "s";
            containerId = getId(containerName, tableForGI);
            tableForGI = elementType + "s";
            elementId = getId(elementName, tableForGI);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                //string sqlExpression = "SELECT id FROM " + containerType + "s WHERE Name=" + "'" + containerName + "'";
                //SqlCommand command = new SqlCommand(sqlExpression, connection);
                //SqlDataReader reader = command.ExecuteReader();
                //if (reader.HasRows) // если есть данные
                //{
                //    while (reader.Read()) // построчно считываем данные
                //    {
                //        //int id = reader.GetValue(0);
                //        containerId = (int)reader.GetValue(0);
                //        //string extension = reader.GetValue(2);
                //        //byte[] file = reader.GetValue(3);
                //    }
                //}
                //reader.Close();

                //sqlExpression = "SELECT id FROM " + elementType + "s WHERE Name=" + "'"+elementName+"'";
                //command = new SqlCommand(sqlExpression, connection);
                //reader = command.ExecuteReader();
                //if (reader.HasRows) // если есть данные
                //{
                //    while (reader.Read()) // построчно считываем данные
                //    {
                //        //int id = reader.GetValue(0);
                //        elementId = (int)reader.GetValue(0);
                //        //string extension = reader.GetValue(2);
                //        //byte[] file = reader.GetValue(3);
                //    }
                //}
                //reader.Close();
                                    
                
                    
                    command.Connection = connection;
                    command.CommandText = @"INSERT INTO " + table + " VALUES (@" + containerType + "s_Id,@" + elementType + "s_Id)";
                    string containerIdstring = "@" + containerType + "s_Id";
                    string elementIdstring = "@" + elementType + "s_Id";
                    command.Parameters.Add(containerIdstring, SqlDbType.Int);
                    command.Parameters.Add(elementIdstring, SqlDbType.Int);
                    command.Parameters[containerIdstring].Value = containerId;
                    command.Parameters[elementIdstring].Value = elementId;
                    command.ExecuteNonQuery();
                               
            }
        }

        //Получение id элемента
        public static int getId(string elementName, string table)
        {
            int elementId = new int();
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=TechDoc;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int count = new int();
                string sqlExpression = "SELECT Count(*) from " + table + " where name=" + "'" + elementName + "'";
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    count = (int)reader.GetValue(0);
                }
                reader.Close();
                if (count == 1) // если есть данные
                {
                    sqlExpression = "SELECT id from " + table + " WHERE name=" + "'" + elementName + "'";
                    command = new SqlCommand(sqlExpression, connection);
                    reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            elementId = (int)reader.GetValue(0);
                        }
                    }
                }
                reader.Close();
            }
            return elementId;
        }

        //Получение данных из таблиц со связями (Dev_Det, Sys_Files и т.д.)
        public static List<string> getRelation(string elementName, string table1, string table2, string table3)
        {
            int id = getId(elementName,table2);
            List<string> elements = new List<string>();
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=TechDoc;Integrated Security=True";            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = @"SELECT " + table1 + ".Name FROM " + table2 + " INNER JOIN " + table3 + " ON " + table2 + ".Id = " + table3 + "." + table2 + "_id INNER JOIN " + table1 + " ON " + table1 + ".Id = " + table3 + "." + table1 + "_id WHERE " + table2 + ".id = " + id;
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
                        elements.Add((string)reader.GetValue(0));
                        //string extension = reader.GetValue(2);
                        //byte[] file = reader.GetValue(3);                        
                    }
                }
                reader.Close();
            }
            return elements;
        }

        public static void removeElement(string elementName, string elementType)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=TechDoc;Integrated Security=True";
            int elementId = new int();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                switch (elementType)
                {                    
                    case "File":
                        elementId = getId(elementName, "Files");                        
                        connection.Open();                        
                        command.Connection = connection;
                        command.CommandText = "DELETE FROM Sys_Files WHERE Files_id=" + elementId;
                        command.ExecuteNonQuery();
                        command.CommandText = "DELETE FROM Det_Files WHERE Files_id=" + elementId;
                        command.ExecuteNonQuery();
                        command.CommandText = "DELETE FROM Dev_Files WHERE Files_id=" + elementId;
                        command.ExecuteNonQuery();
                        command.CommandText = "DELETE FROM Files WHERE name=" + "'" + elementName + "'";
                        command.ExecuteNonQuery();
                        break;
                    case "Detail":
                        elementId = getId(elementName, "Details");
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = "DELETE FROM Det_Files WHERE Details_id=" + elementId;
                        command.ExecuteNonQuery();
                        command.CommandText = "DELETE FROM Dev_Det WHERE Details_id=" + elementId;
                        command.ExecuteNonQuery();
                        command.CommandText = "DELETE FROM Details WHERE name=" + "'" + elementName + "'";
                        command.ExecuteNonQuery();
                        break;
                    case "Device":
                        elementId = getId(elementName, "Devices");
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = "DELETE FROM Sys_Dev WHERE Devices_id=" + elementId;
                        command.ExecuteNonQuery();
                        command.CommandText = "DELETE FROM Dev_Files WHERE Devices_id=" + elementId;
                        command.ExecuteNonQuery();
                        command.CommandText = "DELETE FROM Dev_Det WHERE Devices_id=" + elementId;
                        command.ExecuteNonQuery();
                        command.CommandText = "DELETE FROM Devices WHERE name=" + "'" + elementName + "'";
                        command.ExecuteNonQuery();
                        break;
                    case "System":
                        elementId = getId(elementName, "Systems");
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = "DELETE FROM Sys_Dev WHERE Systems_id=" + elementId;
                        command.ExecuteNonQuery();
                        command.CommandText = "DELETE FROM Sys_Files WHERE Systems_id=" + elementId;
                        command.ExecuteNonQuery();
                        command.CommandText = "DELETE FROM Systems WHERE name=" + "'" + elementName + "'";
                        command.ExecuteNonQuery();
                        break;
                }                
            }
        }
    }
}
