namespace MonitorSPOT
{
    partial class ManagFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagFrm));
            this.lbl_Ueberschrift = new System.Windows.Forms.Label();
            this.lbl_RTC = new System.Windows.Forms.Label();
            this.lbl_Backup = new System.Windows.Forms.Label();
            this.llbl_server_log = new System.Windows.Forms.LinkLabel();
            this.llbl_message_log = new System.Windows.Forms.LinkLabel();
            this.btn_status = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lbl_server = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_Ueberschrift
            // 
            this.lbl_Ueberschrift.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Ueberschrift.Location = new System.Drawing.Point(13, 13);
            this.lbl_Ueberschrift.Name = "lbl_Ueberschrift";
            this.lbl_Ueberschrift.Size = new System.Drawing.Size(247, 23);
            this.lbl_Ueberschrift.TabIndex = 0;
            this.lbl_Ueberschrift.Text = "Management Werk";
            this.lbl_Ueberschrift.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_RTC
            // 
            this.lbl_RTC.Location = new System.Drawing.Point(9, 147);
            this.lbl_RTC.Name = "lbl_RTC";
            this.lbl_RTC.Size = new System.Drawing.Size(250, 20);
            this.lbl_RTC.TabIndex = 1;
            this.lbl_RTC.Text = "Status des RTC-Dienstes: ...";
            this.lbl_RTC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Backup
            // 
            this.lbl_Backup.Location = new System.Drawing.Point(9, 182);
            this.lbl_Backup.Name = "lbl_Backup";
            this.lbl_Backup.Size = new System.Drawing.Size(251, 20);
            this.lbl_Backup.TabIndex = 2;
            this.lbl_Backup.Text = "letztes SQL-Backup: ...";
            this.lbl_Backup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // llbl_server_log
            // 
            this.llbl_server_log.Location = new System.Drawing.Point(9, 221);
            this.llbl_server_log.Name = "llbl_server_log";
            this.llbl_server_log.Size = new System.Drawing.Size(251, 13);
            this.llbl_server_log.TabIndex = 3;
            this.llbl_server_log.TabStop = true;
            this.llbl_server_log.Text = "Server-Log";
            this.llbl_server_log.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.llbl_server_log.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Llbl_server_log_LinkClicked);
            // 
            // llbl_message_log
            // 
            this.llbl_message_log.Location = new System.Drawing.Point(12, 257);
            this.llbl_message_log.Name = "llbl_message_log";
            this.llbl_message_log.Size = new System.Drawing.Size(248, 13);
            this.llbl_message_log.TabIndex = 4;
            this.llbl_message_log.TabStop = true;
            this.llbl_message_log.Text = "Message-Log";
            this.llbl_message_log.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.llbl_message_log.Click += new System.EventHandler(this.Llbl_message_log_Click);
            // 
            // btn_status
            // 
            this.btn_status.Location = new System.Drawing.Point(12, 84);
            this.btn_status.Name = "btn_status";
            this.btn_status.Size = new System.Drawing.Size(248, 40);
            this.btn_status.TabIndex = 5;
            this.btn_status.Text = "Status prüfen ...";
            this.btn_status.UseVisualStyleBackColor = true;
            this.btn_status.Click += new System.EventHandler(this.Btn_status_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 288);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(248, 40);
            this.button1.TabIndex = 6;
            this.button1.Text = "RTC-Dienst neustarten";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // lbl_server
            // 
            this.lbl_server.BackColor = System.Drawing.SystemColors.Info;
            this.lbl_server.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_server.Location = new System.Drawing.Point(12, 48);
            this.lbl_server.Name = "lbl_server";
            this.lbl_server.Size = new System.Drawing.Size(248, 23);
            this.lbl_server.TabIndex = 7;
            this.lbl_server.Text = "server";
            this.lbl_server.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ManagFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(272, 367);
            this.Controls.Add(this.lbl_server);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_status);
            this.Controls.Add(this.llbl_message_log);
            this.Controls.Add(this.llbl_server_log);
            this.Controls.Add(this.lbl_Backup);
            this.Controls.Add(this.lbl_RTC);
            this.Controls.Add(this.lbl_Ueberschrift);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManagFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.ManagFrm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_Ueberschrift;
        private System.Windows.Forms.Label lbl_RTC;
        private System.Windows.Forms.Label lbl_Backup;
        private System.Windows.Forms.LinkLabel llbl_server_log;
        private System.Windows.Forms.LinkLabel llbl_message_log;
        private System.Windows.Forms.Button btn_status;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbl_server;
    }
}