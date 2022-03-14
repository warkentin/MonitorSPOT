using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitorSPOT
{
    public partial class MainFrm : Form
    {
        string g_username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        int g_FormHeight_Orig = 0;

        public MainFrm()
        {
            InitializeComponent();
            this.TopMost = true;
            btn_change_modus.Text = "$";
        }       

        private void get_data()
        {
            SQL sql = new SQL();
            List<string> data = new List<string>();

            List<int> werke = new List<int>();
            werke.Add(1000);
            werke.Add(2000);
            werke.Add(2500);
            werke.Add(3000);
            werke.Add(4000);
            werke.Add(5000);
            werke.Add(6000);
            werke.Add(6500);
            werke.Add(8200);
            werke.Add(9000);

            int l_summe_ma = 0;
            int l_summe_mo = 0;
            int l_summe_mh = 0;
            string l_werk = "";

            Label label = null;
            ProgressBar pgb = null;

            try            
            {
                foreach (var item in werke)
                {
                    l_werk = item.ToString();
                    double l_mh = 0;
                    double l_mo = 0;
                    double l_ma = 0;
                    bool FolderIsEmpty = true;
                    DateTime l_zeitpunkt;
                    data = sql.get_data_Werk(item.ToString());

                    // Status Garniturfotos manuelle Ablage *********************************************
                    if (data[0].ToString() != "--")
                    {
                        string Foto_Pfad = sql.get_Fotopfad(l_werk);
                        FolderIsEmpty = IsDirectoryEmpty(Foto_Pfad);
                    }

                    this.Invoke((MethodInvoker)delegate
                    {
                        var labelo = Controls.Find("lbl_Foto_" + item, true);
                        if (labelo.Length > 0) label = (Label)labelo[0];
                        SettingText(label, "_", FolderIsEmpty == true ? Color.ForestGreen : Color.Magenta);

                        var labeloo = Controls.Find("lbl_Foto_top_" + item, true);
                        if (labeloo.Length > 0) label = (Label)labeloo[0];
                        SettingText(label, "_", FolderIsEmpty == true ? Color.ForestGreen : Color.Magenta);
                    });

                    // Anzahl Messages Mitarbeiter ******************************************************
                    if (data[0].ToString() != "--")
                    {
                        l_summe_ma = l_summe_ma + Convert.ToInt32((data[0].ToString()));
                        l_ma = Convert.ToInt32((data[0].ToString()));
                    }

                    this.Invoke((MethodInvoker)delegate
                    {
                        var labelo = Controls.Find("lbl_MA_" + item, true);
                        if (labelo.Length > 0) label = (Label)labelo[0];
                        SettingText(label, l_ma.ToString(), Color.Black);
                    });

                    // Anzahl Messages offen *************************************************************
                    if (data[1].ToString() != "--")
                    {
                        l_summe_mo = l_summe_mo + Convert.ToInt32((data[1].ToString()));
                        l_mo = Convert.ToInt32((data[1].ToString()));
                    }

                    this.Invoke((MethodInvoker)delegate
                    {
                        var labelo = Controls.Find("lbl_mo_" + item, true);
                        if (labelo.Length > 0) label = (Label)labelo[0];                        
                        SettingText(label, l_mo.ToString("N0"), l_mo.ToString().Length < 2 ? Color.Green : Color.Red);

                        var labeloo = Controls.Find("lbl_top_" + item, true);
                        if (labeloo.Length > 0) label = (Label)labeloo[0];
                        SettingText(label, item.ToString(), l_mo.ToString().Length < 2 ? Color.Green : Color.Red);
                    });                                        

                    // Anzahl Messages heute **************************************************************
                    if (data[2].ToString() != "--")
                    {
                        l_summe_mh = l_summe_mh + Convert.ToInt32((data[2].ToString()));
                        l_mh = Convert.ToInt32((data[2].ToString()));
                    }                    

                    this.Invoke((MethodInvoker)delegate
                    {
                        var labelo = Controls.Find("lbl_mh_" + item, true);
                        if (labelo.Length > 0) label = (Label)labelo[0];
                        //double l_mh = Convert.ToDouble(data[2].ToString());
                        SettingText(label, l_mh.ToString("N0"), Color.Black);
                    });

                    // Zeitpunkt **************************************************************************
                    this.Invoke((MethodInvoker)delegate
                    {
                        var labelo = Controls.Find("lbl_datetime_" + item, true);
                        if (labelo.Length > 0) label = (Label)labelo[0];
                        l_zeitpunkt = Convert.ToDateTime(data[5].ToString());
                        l_zeitpunkt = l_zeitpunkt.AddHours(1);
                        SettingText(label, l_zeitpunkt.ToString(), l_zeitpunkt < DateTime.UtcNow.AddMinutes(-10) ? Color.Orange : Color.Black);
                    });                  // Servername *************************************************************************
                    this.Invoke((MethodInvoker)delegate
                    {
                        var labelo = Controls.Find("lbl_server_" + item, true);
                        if (labelo.Length > 0) label = (Label)labelo[0];
                        SettingText(label, data[4].ToString().ToLower(), Color.Black);
                    });

                    // Durchschnittsanzahl Messages ********************************************************
                    this.Invoke((MethodInvoker)delegate
                    {
                        var labelo = Controls.Find("lbl_norm_" + item, true);
                        if (labelo.Length > 0) label = (Label)labelo[0];
                        double l_norm = Convert.ToDouble(data[3].ToString());
                        SettingText(label, l_norm.ToString("N0"), Color.Black);
                    });

                    double l_durchschnitt = 0;
                    string l_durchschnitt_t = "";
                    if (data[3].ToString() != "--" && data[2].ToString() != "--")
                    {
                        l_durchschnitt = Convert.ToDouble(data[2].ToString()) / Convert.ToDouble(data[3].ToString());
                        l_durchschnitt_t = l_durchschnitt.ToString("0.%");
                    }
                    
                    this.Invoke((MethodInvoker)delegate
                    {
                        var labelo = Controls.Find("lbl_stand_" + item, true);
                        if (labelo.Length > 0) label = (Label)labelo[0];
                        SettingText(label, l_durchschnitt_t.ToString(), Color.Black);
                    });

                    this.Invoke((MethodInvoker)delegate
                    {
                        var labelo = Controls.Find("pgb_" + item, true);
                        if (labelo.Length > 0) { pgb = (ProgressBar)labelo[0]; }
                        double l_dbl_durchschnitt = l_durchschnitt * 100;
                        SettingProgress(pgb, (int)l_dbl_durchschnitt);
                    });
                }
                lbl_error.Text = "";
            }
            catch (Exception ex)
            {
                lbl_error.Text = "Verbindung zum SQL-Server dpn - svr - membrain nicht möglich!Bitte prüfen! \n"
                                + ex.Message.ToString() + "Werk: " + l_werk;
            }

            lbl_summe_ma.Text = l_summe_ma.ToString("N0");
            lbl_summe_mo.Text = l_summe_mo.ToString("N0");
            lbl_summe_mh.Text = l_summe_mh.ToString("N0");
        }

        static bool IsDirectoryEmpty(string strPath)
        {
            return !System.IO.Directory.EnumerateFileSystemEntries(strPath).Any();
        }

        private void SettingProgress(ProgressBar progressbar, int value)
        {
            if (value > 100) value = 100;
            if (value < 0) value = 0;
            progressbar.Value = value;
        }

        private void SettingText(Label label, string text, Color color)
        {
            label.Text = text;

            switch (color.ToString())
            {
                case "Color [Green]":
                    label.ForeColor = Color.White;
                    label.BackColor = Color.DarkGreen;
                    break;
                case "Color [Red]":
                    label.ForeColor = Color.White;
                    label.BackColor = Color.Red;
                    break;
                case "Color [Orange]":
                    label.ForeColor = Color.White;
                    label.BackColor = Color.Orange;
                    break;
                case "Color [ForestGreen]":
                    label.ForeColor = Color.DarkGreen;
                    label.BackColor = Color.DarkGreen;
                    break;
                case "Color [Magenta]":
                    label.ForeColor = Color.Red;
                    label.BackColor = Color.Red;
                    break;
                default:
                    label.ForeColor = color;
                    label.BackColor = SystemColors.Menu;
                    break;
                    break;
                    break;
                    break;
                    break;
                    break;
                    break;
                    break;
            }            
        }

        private void MainFrm_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            e.Graphics.DrawLine(pen, 10, 125, 1045, 125);
            e.Graphics.DrawLine(pen, 10, 485, 1045, 485);
            e.Graphics.DrawLine(pen, 67, 85, 67, 485);
            e.Graphics.DrawLine(pen, 215, 85, 215, 485);
            e.Graphics.DrawLine(pen, 325, 85, 325, 485);
            e.Graphics.DrawLine(pen, 434, 85, 434, 485);
            e.Graphics.DrawLine(pen, 578, 85, 578, 485);
            e.Graphics.DrawLine(pen, 697, 85, 697, 485);
            e.Graphics.DrawLine(pen, 1000, 85, 1000, 485);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            get_data();
            lbl_status.Text = "Aktualisierung: " + DateTime.Now;
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            get_data();
            lbl_status.Text = "Aktualisierung: " + DateTime.Now;
            this.Text = "  Login: " + g_username + "  -  " + DateTime.Now.ToString();
        }

        private void Lbl_server_1000_DoubleClick(object sender, EventArgs e)
        {
            if (IsTopMostActive() == false)
            {
                ManagFrm frm = new ManagFrm();
                frm.g_servername = lbl_server_1000.Text;
                frm.g_Werksnummer = lbl_1000.Text.ToString();
                frm.ShowDialog();
            }
        }

        private void Lbl_server_2000_DoubleClick(object sender, EventArgs e)
        {
            if (IsTopMostActive() == false)
            {
                ManagFrm frm = new ManagFrm();
                frm.g_servername = lbl_server_2000.Text;
                frm.g_Werksnummer = lbl_2000.Text.ToString();
                frm.ShowDialog();
            }
        }

        private void Lbl_server_2500_DoubleClick(object sender, EventArgs e)
        {
            if (IsTopMostActive() == false)
            {
                ManagFrm frm = new ManagFrm();
                frm.g_servername = lbl_server_2500.Text;
                frm.g_Werksnummer = lbl_2500.Text.ToString();
                frm.ShowDialog();
            }
        }

        private void Lbl_server_3000_DoubleClick(object sender, EventArgs e)
        {
            if (IsTopMostActive() == false)
            {
                ManagFrm frm = new ManagFrm();
                frm.g_servername = lbl_server_3000.Text;
                frm.g_Werksnummer = lbl_3000.Text.ToString();
                frm.ShowDialog();
            }
        }

        private void Lbl_server_4000_DoubleClick(object sender, EventArgs e)
        {
            if (IsTopMostActive() == false)
            {
                ManagFrm frm = new ManagFrm();
                frm.g_servername = lbl_server_4000.Text;
                frm.g_Werksnummer = lbl_4000.Text.ToString();
                frm.ShowDialog();
            }
        }

        private void Lbl_server_5000_DoubleClick(object sender, EventArgs e)
        {
            if (IsTopMostActive() == false)
            {
                ManagFrm frm = new ManagFrm();
                frm.g_servername = lbl_server_5000.Text;
                frm.g_Werksnummer = lbl_5000.Text.ToString();
                frm.ShowDialog();
            }
        }

        private void Lbl_server_6000_DoubleClick(object sender, EventArgs e)
        {
            if (IsTopMostActive() == false)
            {
                ManagFrm frm = new ManagFrm();
                frm.g_servername = lbl_server_6000.Text;
                frm.g_Werksnummer = lbl_6000.Text.ToString();
                frm.ShowDialog();
            }
        }

        private void Lbl_server_7000_DoubleClick(object sender, EventArgs e)
        {
            if (IsTopMostActive() == false)
            {
                ManagFrm frm = new ManagFrm();
                frm.g_servername = lbl_server_6500.Text;
                frm.g_Werksnummer = lbl_6500.Text.ToString();
                frm.ShowDialog();
            }
        }
       
        private void Lbl_server_9000_DoubleClick(object sender, EventArgs e)
        {
            if (IsTopMostActive() == false)
            {
                ManagFrm frm = new ManagFrm();
                frm.g_servername = lbl_server_9000.Text;
                frm.g_Werksnummer = lbl_9000.Text.ToString();
                frm.ShowDialog();
            }
        }

        private void Lbl_faq_Click(object sender, EventArgs e)
        {
            if (IsTopMostActive() == false)
            {
                FaqFrm frm = new FaqFrm();
                frm.ShowDialog();
            }
        }
                
        private bool IsTopMostActive()
        {
            if (this.TopMost == true)
            {
                MessageBox.Show("Bitte zuerst den Vordergrund-Modus deaktivieren!");
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btn_change_modus_Click(object sender, EventArgs e)
        {
            if (btn_change_modus.Text == "$")
            {
                btn_change_modus.Text = "0";
                this.TopMost = false;
            }                
            else
            {
                btn_change_modus.Text = "$";
                this.TopMost = true;
            }
        }

        private void btn_min_Click(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            g_FormHeight_Orig = this.Height + 41;
            this.Size = new Size(this.Width,30);
        }

        private void btn_max_Click(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Size = new Size(this.Width,g_FormHeight_Orig);
        }

        private void lbl_server_8200_DoubleClick(object sender, EventArgs e)
        {
            if (IsTopMostActive() == false)
            {
                ManagFrm frm = new ManagFrm();
                frm.g_servername = lbl_server_8200.Text;
                frm.g_Werksnummer = lbl_8200.Text.ToString();
                frm.ShowDialog();
            }
        }
    }
}