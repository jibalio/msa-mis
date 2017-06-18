namespace MSAMISUserInterface {
    partial class Sched_AddDutyDetail {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sched_AddDutyDetail));
            this.NameLBL = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ClientLBL = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.TimeInBX = new System.Windows.Forms.MaskedTextBox();
            this.ContactLBL = new System.Windows.Forms.Label();
            this.TimeInAMPMBX = new System.Windows.Forms.ComboBox();
            this.TimeOutAMPMBX = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TimeOutBX = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.DaysMBX = new System.Windows.Forms.MaskedTextBox();
            this.FadeTMR = new System.Windows.Forms.Timer(this.components);
            this.AddBTN = new System.Windows.Forms.Button();
            this.CloseBTN = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // NameLBL
            // 
            this.NameLBL.Dock = System.Windows.Forms.DockStyle.Top;
            this.NameLBL.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.NameLBL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.NameLBL.Location = new System.Drawing.Point(0, 24);
            this.NameLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NameLBL.Name = "NameLBL";
            this.NameLBL.Size = new System.Drawing.Size(718, 61);
            this.NameLBL.TabIndex = 118;
            this.NameLBL.Text = "Laboriki, Dodong Lab W.";
            this.NameLBL.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(718, 24);
            this.label4.TabIndex = 119;
            this.label4.Text = "DUTY DETAILS FOR";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ClientLBL
            // 
            this.ClientLBL.Dock = System.Windows.Forms.DockStyle.Top;
            this.ClientLBL.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.ClientLBL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.ClientLBL.Location = new System.Drawing.Point(0, 111);
            this.ClientLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ClientLBL.Name = "ClientLBL";
            this.ClientLBL.Size = new System.Drawing.Size(718, 40);
            this.ClientLBL.TabIndex = 120;
            this.ClientLBL.Text = "Laboriki Enterprises";
            this.ClientLBL.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label2.Location = new System.Drawing.Point(0, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(718, 26);
            this.label2.TabIndex = 121;
            this.label2.Text = "ASSIGNED AT";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ClientLBL);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.NameLBL);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(1, 91);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(718, 168);
            this.panel1.TabIndex = 122;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label20.Location = new System.Drawing.Point(278, 350);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(58, 19);
            this.label20.TabIndex = 124;
            this.label20.Text = "Time-in:";
            // 
            // TimeInBX
            // 
            this.TimeInBX.BackColor = System.Drawing.Color.White;
            this.TimeInBX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TimeInBX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.TimeInBX.Location = new System.Drawing.Point(341, 354);
            this.TimeInBX.Mask = "99:99";
            this.TimeInBX.Name = "TimeInBX";
            this.TimeInBX.Size = new System.Drawing.Size(40, 13);
            this.TimeInBX.TabIndex = 123;
            // 
            // ContactLBL
            // 
            this.ContactLBL.AutoSize = true;
            this.ContactLBL.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.ContactLBL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.ContactLBL.Location = new System.Drawing.Point(295, 309);
            this.ContactLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ContactLBL.Name = "ContactLBL";
            this.ContactLBL.Size = new System.Drawing.Size(119, 21);
            this.ContactLBL.TabIndex = 125;
            this.ContactLBL.Text = "DUTY DETAILS";
            // 
            // TimeInAMPMBX
            // 
            this.TimeInAMPMBX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TimeInAMPMBX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TimeInAMPMBX.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.TimeInAMPMBX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.TimeInAMPMBX.FormattingEnabled = true;
            this.TimeInAMPMBX.Items.AddRange(new object[] {
            "AM",
            "PM"});
            this.TimeInAMPMBX.Location = new System.Drawing.Point(380, 345);
            this.TimeInAMPMBX.Name = "TimeInAMPMBX";
            this.TimeInAMPMBX.Size = new System.Drawing.Size(56, 25);
            this.TimeInAMPMBX.Sorted = true;
            this.TimeInAMPMBX.TabIndex = 126;
            // 
            // TimeOutAMPMBX
            // 
            this.TimeOutAMPMBX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TimeOutAMPMBX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TimeOutAMPMBX.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.TimeOutAMPMBX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.TimeOutAMPMBX.FormattingEnabled = true;
            this.TimeOutAMPMBX.Items.AddRange(new object[] {
            "AM",
            "PM"});
            this.TimeOutAMPMBX.Location = new System.Drawing.Point(380, 380);
            this.TimeOutAMPMBX.Name = "TimeOutAMPMBX";
            this.TimeOutAMPMBX.Size = new System.Drawing.Size(56, 25);
            this.TimeOutAMPMBX.Sorted = true;
            this.TimeOutAMPMBX.TabIndex = 129;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label5.Location = new System.Drawing.Point(268, 385);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 19);
            this.label5.TabIndex = 128;
            this.label5.Text = "Time-out:";
            // 
            // TimeOutBX
            // 
            this.TimeOutBX.BackColor = System.Drawing.Color.White;
            this.TimeOutBX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TimeOutBX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.TimeOutBX.Location = new System.Drawing.Point(341, 389);
            this.TimeOutBX.Mask = "99:99";
            this.TimeOutBX.Name = "TimeOutBX";
            this.TimeOutBX.Size = new System.Drawing.Size(40, 13);
            this.TimeOutBX.TabIndex = 127;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label6.Location = new System.Drawing.Point(252, 418);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 19);
            this.label6.TabIndex = 131;
            this.label6.Text = "Days/Week:";
            // 
            // DaysMBX
            // 
            this.DaysMBX.BackColor = System.Drawing.Color.White;
            this.DaysMBX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DaysMBX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.DaysMBX.Location = new System.Drawing.Point(342, 424);
            this.DaysMBX.Mask = "9999";
            this.DaysMBX.Name = "DaysMBX";
            this.DaysMBX.Size = new System.Drawing.Size(40, 13);
            this.DaysMBX.TabIndex = 130;
            // 
            // FadeTMR
            // 
            this.FadeTMR.Interval = 1;
            this.FadeTMR.Tick += new System.EventHandler(this.FadeTMR_Tick);
            // 
            // AddBTN
            // 
            this.AddBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(87)))), ((int)(((byte)(145)))));
            this.AddBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AddBTN.BackgroundImage")));
            this.AddBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AddBTN.FlatAppearance.BorderSize = 0;
            this.AddBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(87)))), ((int)(((byte)(145)))));
            this.AddBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddBTN.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddBTN.ForeColor = System.Drawing.Color.White;
            this.AddBTN.Location = new System.Drawing.Point(281, 600);
            this.AddBTN.Name = "AddBTN";
            this.AddBTN.Size = new System.Drawing.Size(78, 32);
            this.AddBTN.TabIndex = 132;
            this.AddBTN.Text = "ADD";
            this.AddBTN.UseVisualStyleBackColor = false;
            // 
            // CloseBTN
            // 
            this.CloseBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBTN.BackColor = System.Drawing.Color.IndianRed;
            this.CloseBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CloseBTN.BackgroundImage")));
            this.CloseBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CloseBTN.FlatAppearance.BorderSize = 0;
            this.CloseBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(87)))), ((int)(((byte)(145)))));
            this.CloseBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBTN.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseBTN.ForeColor = System.Drawing.Color.White;
            this.CloseBTN.Location = new System.Drawing.Point(364, 600);
            this.CloseBTN.Name = "CloseBTN";
            this.CloseBTN.Size = new System.Drawing.Size(78, 32);
            this.CloseBTN.TabIndex = 133;
            this.CloseBTN.Text = "CANCEL";
            this.CloseBTN.UseVisualStyleBackColor = false;
            this.CloseBTN.Click += new System.EventHandler(this.CloseBTN_Click);
            // 
            // Sched_AddDutyDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(721, 666);
            this.ControlBox = false;
            this.Controls.Add(this.AddBTN);
            this.Controls.Add(this.CloseBTN);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DaysMBX);
            this.Controls.Add(this.TimeOutAMPMBX);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TimeOutBX);
            this.Controls.Add(this.TimeInAMPMBX);
            this.Controls.Add(this.ContactLBL);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.TimeInBX);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Sched_AddDutyDetail";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Sched_AddDutyDetail_FormClosing);
            this.Load += new System.EventHandler(this.Sched_AddDutyDetail_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameLBL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label ClientLBL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.MaskedTextBox TimeInBX;
        private System.Windows.Forms.Label ContactLBL;
        private System.Windows.Forms.ComboBox TimeInAMPMBX;
        private System.Windows.Forms.ComboBox TimeOutAMPMBX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox TimeOutBX;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox DaysMBX;
        private System.Windows.Forms.Button AddBTN;
        private System.Windows.Forms.Button CloseBTN;
        private System.Windows.Forms.Timer FadeTMR;
    }
}