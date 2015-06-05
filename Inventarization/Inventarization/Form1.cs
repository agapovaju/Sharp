using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Threading;
using System.Management;
using System.Management.Instrumentation;
using System.Xml;
using System.IO;

namespace Inventarization
{
    public partial class inventarization : Form
    {
        string[] comp_mass;
        string[] err_mass;
        string ram;
        string gpu;
        string os;
        string sp;
        string cpu;
        
        string err_path;
        int err_count;
        
        public inventarization()
        {
            InitializeComponent();
            dataGridView_services.RowHeadersVisible = false;
            dataGridView_services.Rows.Clear();
            dataGridView_services.ColumnCount = 3;
            dataGridView_services.ColumnHeadersVisible = true;
            dataGridView_services.Columns[0].Name = "Имя";
            dataGridView_services.Columns[1].Name = "Название службы";
            dataGridView_services.Columns[2].Name = "Состояние";
            dataGridView_services.Columns[0].Width = 170;
            dataGridView_services.Columns[1].Width = 540;
            dataGridView_services.Columns[2].Width = 70;
            dataGridView_services.Width = 800;
            cpu = "";
            ram = "";
            os = "";
            sp = "";
            gpu = "";            
            err_path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Inventarization_log.txt";
            err_mass = System.IO.File.ReadAllLines(err_path, Encoding.UTF8);
            if (System.IO.File.Exists(err_path) == false)
            {
                System.IO.File.WriteAllText(err_path, "", Encoding.UTF8);
            }
            err_count = err_mass.Length;            
            dataGridView_comps_information.Rows.Clear();
            dataGridView_comps_information.RowHeadersVisible = false;
            dataGridView_comps_information.ColumnCount = 6;
            dataGridView_comps_information.ColumnHeadersVisible = true;
            dataGridView_comps_information.Columns[0].Name = "Имя";
            dataGridView_comps_information.Columns[1].Name = "Процессор";
            dataGridView_comps_information.Columns[2].Name = "Оперативка";
            dataGridView_comps_information.Columns[3].Name = "Видеокарта";
            dataGridView_comps_information.Columns[4].Name = "Операционка";
            dataGridView_comps_information.Columns[5].Name = "Сервиспак";
            dataGridView_comps_information.Columns[0].Width = 100;
            dataGridView_comps_information.Columns[1].Width = 250;
            dataGridView_comps_information.Columns[2].Width = 100;
            dataGridView_comps_information.Columns[3].Width = 250;
            dataGridView_comps_information.Columns[4].Width = 250;
            dataGridView_comps_information.Columns[5].Width = 180;
            dataGridView_comps_information.Width = 1150;
        }

        public string get_CPU(string address)
        {
            try
            {
                ManagementScope scope = new ManagementScope("\\\\" + address + "\\root\\cimv2");
                scope.Connect();
                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_Processor");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

                ManagementObjectCollection queryCollection = searcher.Get();
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    cpu = queryObj["Name"].ToString();
                }
            }
            catch (ManagementException em)
            {
                err_count++;
                using (StreamWriter sw = new StreamWriter(err_path, true, Encoding.UTF8))
                {
                    sw.WriteLine(err_count + "  " + DateTime.Today.ToString() + " Метод get_CPU говорит WMIException при опросе " + address + ": " + em.Message);
                    
                }
            }
            catch (System.NullReferenceException en)
            {
                err_count++;
                using (StreamWriter sw = new StreamWriter(err_path, true, Encoding.UTF8))
                {
                    sw.WriteLine(err_count + "  " + DateTime.Today.ToString() + " Метод get_CPU говорит упс, кажется вернулось значение NULL при опросе " + address + ": " + en.Message);

                }
            }
            catch (System.Runtime.InteropServices.COMException ec)
            {
                err_count++;
                using (StreamWriter sw = new StreamWriter(err_path, true, Encoding.UTF8))
                {
                    sw.WriteLine(err_count + "  " + DateTime.Today.ToString() + " Метод get_CPU говорит ComException при опросе " + address + ": " + ec.Message);

                }
            }
            return cpu;
        }

        public string get_RAM(string address)
        {
            try
            {
                ManagementScope scope = new ManagementScope("\\\\" + address + "\\root\\cimv2");
                scope.Connect();
                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_ComputerSystem");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
                
                ManagementObjectCollection queryCollection = searcher.Get();
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    UInt64 t = Convert.ToUInt64(queryObj["TotalPhysicalMemory"].ToString());
                    ram = (t / 1024 / 1024).ToString() + " MB";
                }
            }
            catch (ManagementException em)
            {
                err_count++;
                using (StreamWriter sw = new StreamWriter(err_path, true, Encoding.UTF8))
                {
                    sw.WriteLine(err_count + "  " + DateTime.Today.ToString() + " Метод get_RAM говорит WMIException при опросе " + address + ": " + em.Message);

                }
            }
            catch (System.NullReferenceException en)
            {
                err_count++;
                using (StreamWriter sw = new StreamWriter(err_path, true, Encoding.UTF8))
                {
                    sw.WriteLine(err_count + "  " + DateTime.Today.ToString() + " Метод get_RAM говорит упс, кажется вернулось значение NULL при опросе " + address + ": " + en.Message);

                }
            }
            catch (System.Runtime.InteropServices.COMException ec)
            {
                err_count++;
                using (StreamWriter sw = new StreamWriter(err_path, true, Encoding.UTF8))
                {
                    sw.WriteLine(err_count + "  " + DateTime.Today.ToString() + " Метод get_RAM говорит ComException при опросе " + address + ": " + ec.Message);

                }
            }
            return ram;
        }

        public string get_GPU(string address)
        {
            try
            {
                ManagementScope scope = new ManagementScope("\\\\" + address + "\\root\\cimv2");
                scope.Connect();
                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_VideoController");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

                ManagementObjectCollection queryCollection = searcher.Get();
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    gpu = queryObj["Name"].ToString();
                }
            }
            catch (ManagementException em)
            {
                err_count++;
                using (StreamWriter sw = new StreamWriter(err_path, true, Encoding.UTF8))
                {
                    sw.WriteLine(err_count + "  " + DateTime.Today.ToString() + " Метод get_GPU говорит WMIException при опросе " + address + ": " + em.Message);

                }
            }
            catch (System.NullReferenceException en)
            {
                err_count++;
                using (StreamWriter sw = new StreamWriter(err_path, true, Encoding.UTF8))
                {
                    sw.WriteLine(err_count + "  " + DateTime.Today.ToString() + " Метод get_GPU говорит упс, кажется вернулось значение NULL при опросе " + address + ": " + en.Message);

                }
            }
            catch (System.Runtime.InteropServices.COMException ec)
            {
                err_count++;
                using (StreamWriter sw = new StreamWriter(err_path, true, Encoding.UTF8))
                {
                    sw.WriteLine(err_count + "  " + DateTime.Today.ToString() + " Метод get_GPU говорит ComException при опросе " + address + ": " + ec.Message);

                }
            }
            return gpu;
        }

        public void get_OS_SP(string address)
        {
            try
            {
                ManagementScope scope = new ManagementScope("\\\\" + address + "\\root\\cimv2");
                scope.Connect();
                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

                ManagementObjectCollection queryCollection = searcher.Get();
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    os = queryObj["Caption"].ToString();
                    sp = queryObj["csdVersion"].ToString();
                }
            }
            catch (ManagementException em)
            {
                err_count++;
                using (StreamWriter sw = new StreamWriter(err_path, true, Encoding.UTF8))
                {
                    sw.WriteLine(err_count + "  " + DateTime.Today.ToString() + " Метод get_OS_SP говорит WMIException при опросе " + address + ": " + em.Message);

                }
            }
            catch (System.NullReferenceException en)
            {
                err_count++;
                using (StreamWriter sw = new StreamWriter(err_path, true, Encoding.UTF8))
                {
                    sw.WriteLine(err_count + "  " + DateTime.Today.ToString() + " Метод get_OS_SP говорит упс, кажется вернулось значение NULL при опросе " + address + ": " + en.Message);

                }
            }
            catch (System.Runtime.InteropServices.COMException ec)
            {
                err_count++;
                using (StreamWriter sw = new StreamWriter(err_path, true, Encoding.UTF8))
                {
                    sw.WriteLine(err_count + "  " + DateTime.Today.ToString() + " Метод get_OS_SP говорит ComException при опросе " + address + ": " + ec.Message);

                }
            }
        }

        public void get_services(string address)
        {
            try
            {
                dataGridView_services.Rows.Clear();
                ManagementScope scope = new ManagementScope("\\\\" + address + "\\root\\cimv2");
                scope.Connect();
                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_Service");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

                ManagementObjectCollection queryCollection = searcher.Get();
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    dataGridView_services.Rows.Add(new object[] { queryObj["Name"].ToString(), queryObj["DisplayName"].ToString(), queryObj["State"].ToString() });
                }
            }
            catch (ManagementException em)
            {
                err_count++;
                using (StreamWriter sw = new StreamWriter(err_path, true, Encoding.UTF8))
                {
                    sw.WriteLine(err_count + "  " + DateTime.Today.ToString() + " Метод get_services говорит WMIException при опросе " + address + ": " + em.Message);

                }
            }
            catch (System.NullReferenceException en)
            {
                err_count++;
                using (StreamWriter sw = new StreamWriter(err_path, true, Encoding.UTF8))
                {
                    sw.WriteLine(err_count + "  " + DateTime.Today.ToString() + " Метод get_services говорит упс, кажется вернулось значение NULL при опросе " + address + ": " + en.Message);

                }
            }
            catch (System.Runtime.InteropServices.COMException ec)
            {
                err_count++;
                using (StreamWriter sw = new StreamWriter(err_path, true, Encoding.UTF8))
                {
                    sw.WriteLine(err_count + "  " + DateTime.Today.ToString() + " Метод get_services говорит ComException при опросе " + address + ": " + ec.Message);

                }
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                listbox_comp_list.Items.Clear();
                comp_mass = System.IO.File.ReadAllLines(openFileDialog1.FileName, Encoding.UTF8);
                for (int i = 0; i < comp_mass.Length; i++)
                {
                    listbox_comp_list.Items.Add(comp_mass[i]);
                }
            }
        }

        private void listbox_comp_list_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listbox_comp_list.SelectedItem!=null)
            {
                label_curr_comp.Text = listbox_comp_list.SelectedItem.ToString();
                try
                {
                    progress_bar.Value = 16;
                    Ping ping = new Ping();
                    string address = listbox_comp_list.SelectedItem.ToString();
                    string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                    Byte[] buffer = Encoding.ASCII.GetBytes(data);
                    int timeout = 10000;
                    PingOptions options = new PingOptions(64, true);
                    PingReply reply = ping.Send(address, timeout, buffer, options);
                    if (reply.Status == IPStatus.Success)
                    {
                        label_status_val.ForeColor = System.Drawing.Color.LimeGreen;
                        label_status_val.Text = "На связи";
                        //try
                        //{
                        progress_bar.Value = 32;
                        get_CPU(address);
                        label_cpu_val.Text = cpu;
                        progress_bar.Value = 48;
                        get_RAM(address);
                        label_ram_val.Text = ram;
                        progress_bar.Value = 64;
                        get_GPU(address);
                        label_gpu_val.Text = gpu;
                        progress_bar.Value = 80;
                        get_OS_SP(address);
                        label_os_val.Text = os;
                        label_sp_val.Text = sp;
                        progress_bar.Value = 100;
                        get_services(address);
                        progress_bar.Value = 0;
                        //}
                        //catch (ManagementException em)
                        //{
                        //    MessageBox.Show("An error occurred while querying for WMI data: " + em.Message);
                        //}
                    }
                    else
                    {
                        label_status_val.ForeColor = System.Drawing.Color.Red;
                        label_status_val.Text = "Нет соединения";
                        label_cpu_val.Text = "";
                        label_ram_val.Text = "";
                        label_gpu_val.Text = "";
                        label_os_val.Text = "";
                        label_sp_val.Text = "";
                        dataGridView_services.Rows.Clear();
                        progress_bar.Value = 0;
                    }
                }
                catch (PingException ex)
                {
                    
                    err_count++;
                    using (StreamWriter sw = new StreamWriter(err_path, true, Encoding.UTF8))
                    {
                        sw.WriteLine(err_count + "  " + DateTime.Today.ToString() + " Метод listbox_comp_list_SelectedIndexChanged_1 говорит: Упс, при пинге " + listbox_comp_list.SelectedItem.ToString() + " ошибочка вышла: " +
                        ex.Message +
                        " Проверьте существует ли запись в DNS");
                    }
                    
                    progress_bar.Value = 0;
                    label_status_val.ForeColor = Color.Red;
                    label_status_val.Text = "Нет соединения";
                    label_cpu_val.Text = "";
                    label_ram_val.Text = "";
                    label_gpu_val.Text = "";
                    label_os_val.Text = "";
                    label_sp_val.Text = "";
                    dataGridView_services.Rows.Clear();
                }
            }
            
        }

        private void button_report_Click(object sender, EventArgs e)
        {
            if (listbox_comp_list.Items.Count != 0)
            {
                dataGridView_comps_information.Rows.Clear();
                listbox_offline_comps.Items.Clear();
                Ping ping = new Ping();
                string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                Byte[] buffer = Encoding.ASCII.GetBytes(data);
                int timeout = 10000;
                PingOptions options = new PingOptions(64, true);
                for (int i = 0; i < comp_mass.Length; i++)
                {
                    label_curr_comp.Text = comp_mass[i];
                    progress_bar.Value = (100 / comp_mass.Length) * (i + 1);
                    string address = comp_mass[i];
                    try
                    {
                        PingReply reply = ping.Send(address, timeout, buffer, options);
                        if (reply.Status == IPStatus.Success)
                        {
                            get_CPU(address);
                            get_GPU(address);
                            get_OS_SP(address);
                            get_RAM(address);
                            dataGridView_comps_information.Rows.Add(new object[] { address, cpu, ram, gpu, os, sp });
                        }
                        else
                        {
                            listbox_offline_comps.Items.Add(address);
                        }
                    }
                    catch (PingException ex)
                    {
                        err_count++;
                        using (StreamWriter sw = new StreamWriter(err_path, true, Encoding.UTF8))
                        {
                            sw.WriteLine(err_count + "  " + DateTime.Today.ToString() + " Метод button_report_Click говорит: Упс, при пинге " + comp_mass[i] + " ошибочка вышла: " +
                            ex.Message +
                            " Проверьте существует ли запись в DNS");
                        }
                        continue;
                    }
                }
                progress_bar.Value = 0;
            }
            else
            {
                MessageBox.Show("Список компьютеров пуст");
            }
        }

        private void текущийКомпьютерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (listbox_comp_list.SelectedItem.ToString() != "")
                {

                    string comp_info =
                        "Процессор: " + cpu + "\r\n" +
                        "RAM: " + ram + "\r\n" +
                        "Videocard: " + gpu + "\r\n" +
                        "OS: " + os + "\r\n" +
                        "SP: " + sp;

                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Text File (.txt)|*.txt";
                    saveFileDialog1.ShowDialog();

                    if (saveFileDialog1.FileName != "")
                    {
                        System.IO.File.WriteAllText(saveFileDialog1.FileName, comp_info);
                    }
                }
                else
                {
                    MessageBox.Show("Выберите компьютер из списка");
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Выберите компьютер из списка\r\n");
            }
        }

        private void всеКомпьютерыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listbox_comp_list.Items.Count != 0)
            {
                string path_not_connect = "";
                string not_connect_comps = "";
                string comp_info = "";
                string path = "";
                string header = "Имя компьютера;Процессор;Оперативка;Видяха;Операционка;Сервиспак;\r\n";
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    path = folderBrowserDialog1.SelectedPath + @"\all_comps.csv";
                    path_not_connect = folderBrowserDialog1.SelectedPath + @"\not_connect.txt";

                    Ping ping = new Ping();
                    string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                    Byte[] buffer = Encoding.ASCII.GetBytes(data);
                    int timeout = 10000;
                    PingOptions options = new PingOptions(64, true);
                    string all_comps_info = "";
                    all_comps_info = header;
                    for (int i = 0; i < comp_mass.Length; i++)
                    {
                        label_curr_comp.Text = comp_mass[i];
                        progress_bar.Value = (100 / comp_mass.Length) * (i + 1);
                        string address = comp_mass[i];
                        try
                        {
                            PingReply reply = ping.Send(address, timeout, buffer, options);
                            if (reply.Status == IPStatus.Success)
                            {
                                get_CPU(address);
                                get_GPU(address);
                                get_OS_SP(address);
                                get_RAM(address);

                                comp_info =
                                    address + ";" +
                                    cpu + ";" +
                                    ram + ";" +
                                    gpu + ";" +
                                    os + ";" +
                                    sp + ";\r\n";
                                all_comps_info = all_comps_info + comp_info;
                            }
                            else
                            {
                                not_connect_comps = not_connect_comps + "\r\n" + address;
                            }
                        }
                        catch (PingException ex)
                        {
                            err_count++;
                            using (StreamWriter sw = new StreamWriter(err_path, true, Encoding.UTF8))
                            {
                                sw.WriteLine(err_count + "  " + DateTime.Today.ToString() + " Метод всеКомпьютерыToolStripMenuItem_Click говорит: Упс, при пинге " + comp_mass[i] + " ошибочка вышла: " +
                                ex.Message +
                                " Проверьте существует ли запись в DNS");
                            }
                            continue;
                        }
                    }
                    System.IO.File.WriteAllText(path, all_comps_info, Encoding.UTF8);
                    System.IO.File.WriteAllText(path_not_connect, not_connect_comps, Encoding.UTF8);
                    progress_bar.Value = 0;
                }
            }
            else
            {
                MessageBox.Show("Список компьютеров пуст");
            }
        }

        private void отчетОбОшибкахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //System.IO.File.WriteAllText(err_path, errors, Encoding.UTF8);
            Process.Start("notepad.exe", err_path);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа была создана при помощи кривых рук и воспаленного сознания ведущего инженера-программиста службы информационных технологий Агапова А.Ю.1111");
        }

        private void какПользоватьсяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Меню 'Файл':\r\n"+
                "Открыть - используется для загрузки списка компьютеров.Принимается формат .txt или .csv, имена компьютеров должны начинаться с новой строки\r\n"+
                "Сохранить текущий компьютер - сохраняет в файл .txt информацию по выделенному в списке компьютеру\r\n"+
                "Сохранить все компьютеры - сохраняет в файл .csv информацию по всем компьютерам из списка\r\n"+
                "Отчет об ошибках - открывает файл лога с ошибками\r\n"+
                "Выход - выход из программы");
        }
    }
}
