using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.ServiceProcess;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace MonitorSPOT
{
    public partial class ManagFrm : Form
    {

        public string g_servername { get; set; }
        public string g_Werksnummer { get; set; }
        string g_username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

        public ManagFrm()
        {
            InitializeComponent();            
        }

        private void ManagFrm_Load(object sender, EventArgs e)
        {
            lbl_server.Text = g_servername;
            this.Text = "Login: " + g_username + " - " + DateTime.Now.Date.ToString();
        }

        private void Btn_status_Click(object sender, EventArgs e)
        {            
            status_pruefen(lbl_server.Text.ToString());
        }        

        private void status_pruefen(string server)
        {
            Label label = null;
            SQL sql = new SQL();

            try
            {
                Cursor = Cursors.WaitCursor;

                // Prüfung auf den RTC-Dienst
                string serviceName = "Membrain RTC-Server";
                string l_status = "unknown";
                try
                {
                    ServiceController service = new ServiceController(serviceName, lbl_server.Text.ToString());
                    l_status = service.Status.ToString();
                }
                catch (Exception e) { }

                this.Invoke((MethodInvoker)delegate
                {
                    var labelo = Controls.Find("lbl_RTC", true);
                    if (labelo.Length > 0) label = (Label)labelo[0];
                    SettingText(label, "RTC-Dienst: " + l_status,
                        l_status == "Running" ? Color.SpringGreen : Color.IndianRed);
                });                

                // Prüfen ob ein aktuelles Backup vorhanden ist
                string l_text = "";
                int l_backup_ok = 0; // 1 = aktuelles Backup, 2 = altes oder gar kein kein Backup

                try
                {
                    string l_backup_jn = sql.get_Backuppfad(lbl_server.Text.ToString());
                    string[] fileEntries = Directory.GetFiles(l_backup_jn, "*.bak");

                    if (fileEntries.Length == 0)
                    {
                        l_text = "-- kein Backup vorhanden --";
                        l_backup_ok = 2;
                    }
                    else
                    {
                        foreach (string fileName in fileEntries)
                        {
                            l_text = "letztes Backup: " + File.GetLastWriteTime(fileName).Date.ToShortDateString();
                            if (File.GetLastWriteTime(fileName).Date >= DateTime.Now.Date.AddDays(-2)) l_backup_ok = 1;
                            else l_backup_ok = 2;
                        }
                    }
                }
                catch (Exception e) { }

                this.Invoke((MethodInvoker)delegate
                {
                    var labelo = Controls.Find("lbl_Backup", true);
                    if (labelo.Length > 0) label = (Label)labelo[0];
                    SettingText(label, l_text, l_backup_ok == 1 ? Color.SpringGreen : Color.IndianRed);
                });
            }
            catch (Exception ex)
            { }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void SettingText(Label label, string text, Color color)
        {
            label.Text = text;
            label.BackColor = color;
        }

        private void Llbl_server_log_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string l_url = "http://naehplan.rah.polipol.intra/logs_" + g_Werksnummer + "/Server.log";
            Process.Start(l_url);
        }

        private void Llbl_message_log_Click(object sender, EventArgs e)
        {
            string l_url = "http://naehplan.rah.polipol.intra/logs_" + g_Werksnummer + "/Server-SAP.log";
            Process.Start(l_url);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            restart(lbl_server.Text.ToString());
        }

        public void restart(string machineName)
        {
            string serviceName = "Membrain RTC-Server";
            int timeoutMilliseconds = 50000;
            ServiceController service = new ServiceController(serviceName, machineName);
            try
            {
                Cursor = Cursors.WaitCursor;
                int millisec1 = Environment.TickCount;
                TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);

                service.Stop();
                service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);

                // count the rest of the timeout
                int millisec2 = Environment.TickCount;
                timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds - (millisec2 - millisec1));

                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running, timeout);
                MessageBox.Show("Dienst erfolgreich neugestartet!");
            }
            catch (Exception err) { MessageBox.Show(err.ToString()); }
            finally { Cursor = Cursors.Default; }
        }
    }
}
