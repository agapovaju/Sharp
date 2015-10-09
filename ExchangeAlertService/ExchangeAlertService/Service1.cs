using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Threading;
using System.Management;
using System.Management.Instrumentation;
using System.Xml;
using System.IO;

namespace ExchangeAlertService
{
    public partial class Service1 : ServiceBase
    {
        string svc;
        int err_count = 0;
        string err_path = @"D:\LOG\log.txt";/////////////////////////////////////////////////////поменять папку с логом
        string address="tolik_pc";///////////////////////////////////////////////////////////////поменять адрес

        public Service1()
        {
            InitializeComponent();
            eventLog1 = new System.Diagnostics.EventLog();
            if (!System.Diagnostics.EventLog.SourceExists("MySource"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "MySource", "MyNewLog");
            }
            eventLog1.Source = "MySource";
            eventLog1.Log = "MyNewLog";
        }

        protected override void OnStart(string[] args)
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 60000; // 60 seconds
            timer.Elapsed += new System.Timers.ElapsedEventHandler(this.OnTimer);
            timer.Start();
            eventLog1.WriteEntry("ExchangeAlertService запущен");
        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("ExchangeAlertService выключен");
        }

        public void OnTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
            // TODO: Insert monitoring activities here.
            eventLog1.WriteEntry("Таймер сработал");
            try
            {
                ManagementScope scope = new ManagementScope("\\\\" + address + "\\root\\cimv2");
                scope.Connect();
                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_Service WHERE Name = 'BITS'");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

                ManagementObjectCollection queryCollection = searcher.Get();
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    svc = queryObj["state"].ToString();
                    using (StreamWriter sw = new StreamWriter(err_path, true, Encoding.UTF8))
                    {
                        sw.WriteLine(svc);
                    }
                }
            }
            catch (ManagementException em)
            {
                err_count++;
                using (StreamWriter sw = new StreamWriter(err_path, true, Encoding.UTF8))
                {
                    sw.WriteLine(err_count + "  " + DateTime.Today.ToString() + " При запросе состояния службы возникла ошибка " + address + ": " + em.Message);
                    svc = "";

                }
            }
            catch (System.NullReferenceException en)
            {
                err_count++;
                using (StreamWriter sw = new StreamWriter(err_path, true, Encoding.UTF8))
                {
                    sw.WriteLine(err_count + "  " + DateTime.Today.ToString() + " При запросе состояния службы возникла ошибка " + address + ": " + en.Message);
                    svc = "";

                }
            }
            catch (System.Runtime.InteropServices.COMException ec)
            {
                err_count++;
                using (StreamWriter sw = new StreamWriter(err_path, true, Encoding.UTF8))
                {
                    sw.WriteLine(err_count + "  " + DateTime.Today.ToString() + " При запросе состояния службы возникла ошибка " + address + ": " + ec.Message);
                    svc = "";

                }
            }
        }
    }
}
