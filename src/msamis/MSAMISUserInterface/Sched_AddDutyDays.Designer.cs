namespace MSAMISUserInterface {
    partial class Sched_AddDutyDays {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sched_AddDutyDays));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ClientLBL = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NameLBL = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CalendarPKR = new System.Windows.Forms.MonthCalendar();
            this.ContactLBL = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TimeOutAMPMBX = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TimeOutBX = new System.Windows.Forms.MaskedTextBox();
            this.TimeInAMPMBX = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.TimeInBX = new System.Windows.Forms.MaskedTextBox();
            this.AddDaysBTN = new System.Windows.Forms.Button();
            this.DaysGRD = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.ConfirmBTN = new System.Windows.Forms.Button();
            this.CloseBTN = new System.Windows.Forms.Button();
            this.FadeTMR = new System.Windows.Forms.Timer(this.components);
            this.EditBTN = new System.Windows.Forms.Button();
            this.DeleteBTN = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DaysGRD)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ClientLBL);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.NameLBL);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(1, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(718, 134);
            this.panel1.TabIndex = 123;
            // 
            // ClientLBL
            // 
            this.ClientLBL.Dock = System.Windows.Forms.DockStyle.Top;
            this.ClientLBL.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.ClientLBL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.ClientLBL.Location = new System.Drawing.Point(0, 95);
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
            this.label2.Location = new System.Drawing.Point(0, 69);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(718, 26);
            this.label2.TabIndex = 121;
            this.label2.Text = "ASSIGNED AT";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // NameLBL
            // 
            this.NameLBL.Dock = System.Windows.Forms.DockStyle.Top;
            this.NameLBL.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.NameLBL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.NameLBL.Location = new System.Drawing.Point(0, 24);
            this.NameLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NameLBL.Name = "NameLBL";
            this.NameLBL.Size = new System.Drawing.Size(718, 45);
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
            this.label4.Text = "DUTY DAYS FOR";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CalendarPKR
            // 
            this.CalendarPKR.Location = new System.Drawing.Point(91, 231);
            this.CalendarPKR.Name = "CalendarPKR";
            this.CalendarPKR.TabIndex = 124;
            // 
            // ContactLBL
            // 
            this.ContactLBL.AutoSize = true;
            this.ContactLBL.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.ContactLBL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.ContactLBL.Location = new System.Drawing.Point(150, 201);
            this.ContactLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ContactLBL.Name = "ContactLBL";
            this.ContactLBL.Size = new System.Drawing.Size(104, 21);
            this.ContactLBL.TabIndex = 126;
            this.ContactLBL.Text = "PICK A DATE";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label5.Location = new System.Drawing.Point(150, 417);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 21);
            this.label5.TabIndex = 127;
            this.label5.Text = "ADD DETAILS";
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
            this.TimeOutAMPMBX.Location = new System.Drawing.Point(228, 490);
            this.TimeOutAMPMBX.Name = "TimeOutAMPMBX";
            this.TimeOutAMPMBX.Size = new System.Drawing.Size(56, 25);
            this.TimeOutAMPMBX.Sorted = true;
            this.TimeOutAMPMBX.TabIndex = 135;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label6.Location = new System.Drawing.Point(116, 495);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 19);
            this.label6.TabIndex = 134;
            this.label6.Text = "Time-out:";
            // 
            // TimeOutBX
            // 
            this.TimeOutBX.BackColor = System.Drawing.Color.White;
            this.TimeOutBX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TimeOutBX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.TimeOutBX.Location = new System.Drawing.Point(189, 499);
            this.TimeOutBX.Mask = "99:99";
            this.TimeOutBX.Name = "TimeOutBX";
            this.TimeOutBX.Size = new System.Drawing.Size(40, 13);
            this.TimeOutBX.TabIndex = 133;
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
            this.TimeInAMPMBX.Location = new System.Drawing.Point(228, 455);
            this.TimeInAMPMBX.Name = "TimeInAMPMBX";
            this.TimeInAMPMBX.Size = new System.Drawing.Size(56, 25);
            this.TimeInAMPMBX.Sorted = true;
            this.TimeInAMPMBX.TabIndex = 132;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label20.Location = new System.Drawing.Point(126, 460);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(58, 19);
            this.label20.TabIndex = 131;
            this.label20.Text = "Time-in:";
            // 
            // TimeInBX
            // 
            this.TimeInBX.BackColor = System.Drawing.Color.White;
            this.TimeInBX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TimeInBX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.TimeInBX.Location = new System.Drawing.Point(189, 464);
            this.TimeInBX.Mask = "99:99";
            this.TimeInBX.Name = "TimeInBX";
            this.TimeInBX.Size = new System.Drawing.Size(40, 13);
            this.TimeInBX.TabIndex = 130;
            // 
            // AddDaysBTN
            // 
            this.AddDaysBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddDaysBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(87)))), ((int)(((byte)(145)))));
            this.AddDaysBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AddDaysBTN.BackgroundImage")));
            this.AddDaysBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AddDaysBTN.FlatAppearance.BorderSize = 0;
            this.AddDaysBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(87)))), ((int)(((byte)(145)))));
            this.AddDaysBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddDaysBTN.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddDaysBTN.ForeColor = System.Drawing.Color.White;
            this.AddDaysBTN.Location = new System.Drawing.Point(159, 537);
            this.AddDaysBTN.Name = "AddDaysBTN";
            this.AddDaysBTN.Size = new System.Drawing.Size(78, 32);
            this.AddDaysBTN.TabIndex = 136;
            this.AddDaysBTN.Text = "ADD";
            this.AddDaysBTN.UseVisualStyleBackColor = false;
            // 
            // DaysGRD
            // 
            this.DaysGRD.AllowUserToAddRows = false;
            this.DaysGRD.AllowUserToDeleteRows = false;
            this.DaysGRD.AllowUserToResizeColumns = false;
            this.DaysGRD.AllowUserToResizeRows = false;
            this.DaysGRD.BackgroundColor = System.Drawing.Color.White;
            this.DaysGRD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DaysGRD.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DaysGRD.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle1.NullValue = "-";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DaysGRD.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DaysGRD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DaysGRD.DefaultCellStyle = dataGridViewCellStyle2;
            this.DaysGRD.EnableHeadersVisualStyles = false;
            this.DaysGRD.Location = new System.Drawing.Point(380, 231);
            this.DaysGRD.Name = "DaysGRD";
            this.DaysGRD.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DaysGRD.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DaysGRD.RowHeadersVisible = false;
            this.DaysGRD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DaysGRD.Size = new System.Drawing.Size(270, 284);
            this.DaysGRD.TabIndex = 138;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label7.Location = new System.Drawing.Point(468, 201);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 21);
            this.label7.TabIndex = 139;
            this.label7.Text = "SUMMARY";
            // 
            // ConfirmBTN
            // 
            this.ConfirmBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfirmBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(87)))), ((int)(((byte)(145)))));
            this.ConfirmBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ConfirmBTN.BackgroundImage")));
            this.ConfirmBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ConfirmBTN.FlatAppearance.BorderSize = 0;
            this.ConfirmBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(87)))), ((int)(((byte)(145)))));
            this.ConfirmBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConfirmBTN.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmBTN.ForeColor = System.Drawing.Color.White;
            this.ConfirmBTN.Location = new System.Drawing.Point(267, 608);
            this.ConfirmBTN.Name = "ConfirmBTN";
            this.ConfirmBTN.Size = new System.Drawing.Size(96, 32);
            this.ConfirmBTN.TabIndex = 140;
            this.ConfirmBTN.Text = "CONFIRM";
            this.ConfirmBTN.UseVisualStyleBackColor = false;
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
            this.CloseBTN.Location = new System.Drawing.Point(368, 608);
            this.CloseBTN.Name = "CloseBTN";
            this.CloseBTN.Size = new System.Drawing.Size(78, 32);
            this.CloseBTN.TabIndex = 141;
            this.CloseBTN.Text = "CANCEL";
            this.CloseBTN.UseVisualStyleBackColor = false;
            this.CloseBTN.Click += new System.EventHandler(this.CloseBTN_Click);
            // 
            // FadeTMR
            // 
            this.FadeTMR.Interval = 1;
            this.FadeTMR.Tick += new System.EventHandler(this.FadeTMR_Tick);
            // 
            // EditBTN
            // 
            this.EditBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.EditBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(87)))), ((int)(((byte)(145)))));
            this.EditBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EditBTN.BackgroundImage")));
            this.EditBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EditBTN.FlatAppearance.BorderSize = 0;
            this.EditBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(87)))), ((int)(((byte)(145)))));
            this.EditBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditBTN.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditBTN.ForeColor = System.Drawing.Color.White;
            this.EditBTN.Location = new System.Drawing.Point(430, 535);
            this.EditBTN.Name = "EditBTN";
            this.EditBTN.Size = new System.Drawing.Size(96, 32);
            this.EditBTN.TabIndex = 142;
            this.EditBTN.Text = "EDIT";
            this.EditBTN.UseVisualStyleBackColor = false;
            // 
            // DeleteBTN
            // 
            this.DeleteBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteBTN.BackColor = System.Drawing.Color.IndianRed;
            this.DeleteBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DeleteBTN.BackgroundImage")));
            this.DeleteBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DeleteBTN.FlatAppearance.BorderSize = 0;
            this.DeleteBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(87)))), ((int)(((byte)(145)))));
            this.DeleteBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteBTN.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteBTN.ForeColor = System.Drawing.Color.White;
            this.DeleteBTN.Location = new System.Drawing.Point(531, 535);
            this.DeleteBTN.Name = "DeleteBTN";
            this.DeleteBTN.Size = new System.Drawing.Size(78, 32);
            this.DeleteBTN.TabIndex = 143;
            this.DeleteBTN.Text = "DELETE";
            this.DeleteBTN.UseVisualStyleBackColor = false;
            // 
            // Sched_AddDutyDays
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(721, 666);
            this.ControlBox = false;
            this.Controls.Add(this.EditBTN);
            this.Controls.Add(this.DeleteBTN);
            this.Controls.Add(this.ConfirmBTN);
            this.Controls.Add(this.CloseBTN);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.DaysGRD);
            this.Controls.Add(this.AddDaysBTN);
            this.Controls.Add(this.TimeOutAMPMBX);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TimeOutBX);
            this.Controls.Add(this.TimeInAMPMBX);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.TimeInBX);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ContactLBL);
            this.Controls.Add(this.CalendarPKR);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Sched_AddDutyDays";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SAddDutyDays_FormClosing);
            this.Load += new System.EventHandler(this.SAddDutyDays_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DaysGRD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label ClientLBL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label NameLBL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MonthCalendar CalendarPKR;
        private System.Windows.Forms.Label ContactLBL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox TimeOutAMPMBX;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox TimeOutBX;
        private System.Windows.Forms.ComboBox TimeInAMPMBX;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.MaskedTextBox TimeInBX;
        private System.Windows.Forms.Button AddDaysBTN;
        private System.Windows.Forms.DataGridView DaysGRD;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button ConfirmBTN;
        private System.Windows.Forms.Button CloseBTN;
        private System.Windows.Forms.Timer FadeTMR;
        private System.Windows.Forms.Button EditBTN;
        private System.Windows.Forms.Button DeleteBTN;
    }
}