namespace MonitorSPOT
{
    partial class FaqFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FaqFrm));
            this.listbox_faq = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listbox_faq
            // 
            this.listbox_faq.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listbox_faq.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listbox_faq.FormattingEnabled = true;
            this.listbox_faq.ItemHeight = 20;
            this.listbox_faq.Location = new System.Drawing.Point(25, 23);
            this.listbox_faq.Name = "listbox_faq";
            this.listbox_faq.Size = new System.Drawing.Size(753, 324);
            this.listbox_faq.TabIndex = 0;
            this.listbox_faq.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Listbox_faq_DrawItem);
            this.listbox_faq.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Listbox_faq_MouseDoubleClick);
            // 
            // FaqFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 383);
            this.Controls.Add(this.listbox_faq);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FaqFrm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Load += new System.EventHandler(this.FaqFrm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listbox_faq;
    }
}