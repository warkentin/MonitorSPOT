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
    public partial class FaqFrm : Form
    {
        string g_username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

        public FaqFrm()
        {
            InitializeComponent();
        }

        private void FaqFrm_Load(object sender, EventArgs e)
        {
            SQL sql = new SQL();
            Dictionary<string, string> data = new Dictionary<string, string>();
                        
            try
            {
                data = sql.get_faq(); 
            }
            catch (Exception ex)
            { }

            foreach (KeyValuePair<string, string> element in data)
            {
                listbox_faq.Items.Add(element.Key.ToString());
            }

            this.Text = "  Login: " + g_username + "  -  " + DateTime.Now.ToString();
        }

        private void Listbox_faq_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listbox_faq.SelectedItem != null)
            {
                if (listbox_faq.SelectedItem.ToString().Length != 0)
                {
                    string url = "http://naehplan.rah.polipol.intra/SPOT_FAQ/" + listbox_faq.SelectedItem.ToString().Replace('-', '_' ).Replace(" ", "") + ".pdf";

                    System.Diagnostics.Process.Start(url);
                }
            }
        }

        private void Listbox_faq_DrawItem(object sender, DrawItemEventArgs e)
        {
            bool isSelected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);

            if (e.Index > -1)
            {
                /* If the item is selected set the background color to SystemColors.Highlight 
                 or else set the color to either WhiteSmoke or White depending if the item index is even or odd */
                Color color = isSelected ? SystemColors.Highlight :
                    e.Index % 2 == 0 ? Color.WhiteSmoke : Color.White;

                // Background item brush
                SolidBrush backgroundBrush = new SolidBrush(color);
                // Text color brush
                SolidBrush textBrush = new SolidBrush(e.ForeColor);

                // Draw the background
                e.Graphics.FillRectangle(backgroundBrush, e.Bounds);
                // Draw the text
                e.Graphics.DrawString(listbox_faq.Items[e.Index].ToString(), e.Font, textBrush, e.Bounds, StringFormat.GenericDefault);

                // Clean up
                backgroundBrush.Dispose();
                textBrush.Dispose();
            }
            e.DrawFocusRectangle();
        }
    }
}