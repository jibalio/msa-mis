namespace MSAMISUserInterface {
    partial class SchedAddDutyDetail {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SchedAddDutyDetail));
            this.label20 = new System.Windows.Forms.Label();
            this.HoursLBL = new System.Windows.Forms.Label();
            this.TimeInAMPMBX = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.FadeTMR = new System.Windows.Forms.Timer(this.components);
            this.AddBTN = new System.Windows.Forms.Button();
            this.CloseBTN = new System.Windows.Forms.Button();
            this.TimeInHrBX = new System.Windows.Forms.ComboBox();
            this.TimeInMinBX = new System.Windows.Forms.ComboBox();
            this.TimeOutMinBX = new System.Windows.Forms.ComboBox();
            this.TimeOutHrBX = new System.Windows.Forms.ComboBox();
            this.TimeOutAMPMBX = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuBTN = new System.Windows.Forms.Button();
            this.MBTN = new System.Windows.Forms.Button();
            this.TBTN = new System.Windows.Forms.Button();
            this.WBTN = new System.Windows.Forms.Button();
            this.ThBTN = new System.Windows.Forms.Button();
            this.FBTN = new System.Windows.Forms.Button();
            this.SaBTN = new System.Windows.Forms.Button();
            this.DaysTLTP = new System.Windows.Forms.ToolTip(this.components);
            this.HoursTLTP = new System.Windows.Forms.ToolTip(this.components);
            this.FormLBL = new System.Windows.Forms.Label();
            this.DateEffective = new System.Windows.Forms.DateTimePicker();
            this.DateDismissed = new System.Windows.Forms.DateTimePicker();
            this.DateDismissedCheck = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label20.Location = new System.Drawing.Point(155, 187);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(58, 19);
            this.label20.TabIndex = 124;
            this.label20.Text = "Time-in:";
            // 
            // HoursLBL
            // 
            this.HoursLBL.AutoSize = true;
            this.HoursLBL.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.HoursLBL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.HoursLBL.Location = new System.Drawing.Point(220, 144);
            this.HoursLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.HoursLBL.Name = "HoursLBL";
            this.HoursLBL.Size = new System.Drawing.Size(100, 21);
            this.HoursLBL.TabIndex = 125;
            this.HoursLBL.Text = "Duty Hours:";
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
            this.TimeInAMPMBX.Location = new System.Drawing.Point(335, 183);
            this.TimeInAMPMBX.Name = "TimeInAMPMBX";
            this.TimeInAMPMBX.Size = new System.Drawing.Size(56, 25);
            this.TimeInAMPMBX.Sorted = true;
            this.TimeInAMPMBX.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label5.Location = new System.Drawing.Point(145, 222);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 19);
            this.label5.TabIndex = 128;
            this.label5.Text = "Time-out:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label6.Location = new System.Drawing.Point(224, 280);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 21);
            this.label6.TabIndex = 131;
            this.label6.Text = "Duty Days:";
            // 
            // FadeTMR
            // 
            this.FadeTMR.Interval = 1;
            this.FadeTMR.Tick += new System.EventHandler(this.FadeTMR_Tick);
            // 
            // AddBTN
            // 
            this.AddBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.AddBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AddBTN.BackgroundImage")));
            this.AddBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AddBTN.FlatAppearance.BorderSize = 0;
            this.AddBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(47)))), ((int)(((byte)(61)))));
            this.AddBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            this.AddBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddBTN.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.AddBTN.ForeColor = System.Drawing.Color.White;
            this.AddBTN.Location = new System.Drawing.Point(188, 534);
            this.AddBTN.Name = "AddBTN";
            this.AddBTN.Size = new System.Drawing.Size(80, 29);
            this.AddBTN.TabIndex = 13;
            this.AddBTN.Text = "ADD";
            this.AddBTN.UseVisualStyleBackColor = false;
            this.AddBTN.Click += new System.EventHandler(this.AddBTN_Click);
            // 
            // CloseBTN
            // 
            this.CloseBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.CloseBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CloseBTN.BackgroundImage")));
            this.CloseBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CloseBTN.FlatAppearance.BorderSize = 0;
            this.CloseBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.CloseBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(97)))), ((int)(((byte)(81)))));
            this.CloseBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBTN.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.CloseBTN.ForeColor = System.Drawing.Color.White;
            this.CloseBTN.Location = new System.Drawing.Point(271, 534);
            this.CloseBTN.Name = "CloseBTN";
            this.CloseBTN.Size = new System.Drawing.Size(80, 29);
            this.CloseBTN.TabIndex = 14;
            this.CloseBTN.Text = "CANCEL";
            this.CloseBTN.UseVisualStyleBackColor = false;
            this.CloseBTN.Click += new System.EventHandler(this.CloseBTN_Click);
            // 
            // TimeInHrBX
            // 
            this.TimeInHrBX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TimeInHrBX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TimeInHrBX.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.TimeInHrBX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.TimeInHrBX.FormattingEnabled = true;
            this.TimeInHrBX.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.TimeInHrBX.Location = new System.Drawing.Point(216, 183);
            this.TimeInHrBX.Name = "TimeInHrBX";
            this.TimeInHrBX.Size = new System.Drawing.Size(46, 25);
            this.TimeInHrBX.Sorted = true;
            this.TimeInHrBX.TabIndex = 0;
            // 
            // TimeInMinBX
            // 
            this.TimeInMinBX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TimeInMinBX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TimeInMinBX.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.TimeInMinBX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.TimeInMinBX.FormattingEnabled = true;
            this.TimeInMinBX.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.TimeInMinBX.Location = new System.Drawing.Point(274, 183);
            this.TimeInMinBX.Name = "TimeInMinBX";
            this.TimeInMinBX.Size = new System.Drawing.Size(46, 25);
            this.TimeInMinBX.Sorted = true;
            this.TimeInMinBX.TabIndex = 1;
            // 
            // TimeOutMinBX
            // 
            this.TimeOutMinBX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TimeOutMinBX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TimeOutMinBX.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.TimeOutMinBX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.TimeOutMinBX.FormattingEnabled = true;
            this.TimeOutMinBX.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.TimeOutMinBX.Location = new System.Drawing.Point(274, 219);
            this.TimeOutMinBX.Name = "TimeOutMinBX";
            this.TimeOutMinBX.Size = new System.Drawing.Size(46, 25);
            this.TimeOutMinBX.Sorted = true;
            this.TimeOutMinBX.TabIndex = 4;
            // 
            // TimeOutHrBX
            // 
            this.TimeOutHrBX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TimeOutHrBX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TimeOutHrBX.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.TimeOutHrBX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.TimeOutHrBX.FormattingEnabled = true;
            this.TimeOutHrBX.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.TimeOutHrBX.Location = new System.Drawing.Point(216, 219);
            this.TimeOutHrBX.Name = "TimeOutHrBX";
            this.TimeOutHrBX.Size = new System.Drawing.Size(46, 25);
            this.TimeOutHrBX.Sorted = true;
            this.TimeOutHrBX.TabIndex = 3;
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
            this.TimeOutAMPMBX.Location = new System.Drawing.Point(335, 219);
            this.TimeOutAMPMBX.Name = "TimeOutAMPMBX";
            this.TimeOutAMPMBX.Size = new System.Drawing.Size(56, 25);
            this.TimeOutAMPMBX.Sorted = true;
            this.TimeOutAMPMBX.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label1.Location = new System.Drawing.Point(262, 186);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 19);
            this.label1.TabIndex = 139;
            this.label1.Text = ":";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label3.Location = new System.Drawing.Point(262, 222);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 19);
            this.label3.TabIndex = 140;
            this.label3.Text = ":";
            // 
            // SuBTN
            // 
            this.SuBTN.BackColor = System.Drawing.Color.White;
            this.SuBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SuBTN.FlatAppearance.BorderSize = 0;
            this.SuBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            this.SuBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SuBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.SuBTN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.SuBTN.Location = new System.Drawing.Point(112, 324);
            this.SuBTN.Name = "SuBTN";
            this.SuBTN.Size = new System.Drawing.Size(40, 40);
            this.SuBTN.TabIndex = 6;
            this.SuBTN.Text = "Su";
            this.SuBTN.UseVisualStyleBackColor = false;
            this.SuBTN.Click += new System.EventHandler(this.SuBTN_Click);
            // 
            // MBTN
            // 
            this.MBTN.BackColor = System.Drawing.Color.White;
            this.MBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MBTN.FlatAppearance.BorderSize = 0;
            this.MBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            this.MBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.MBTN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.MBTN.Location = new System.Drawing.Point(158, 324);
            this.MBTN.Name = "MBTN";
            this.MBTN.Size = new System.Drawing.Size(40, 40);
            this.MBTN.TabIndex = 7;
            this.MBTN.Text = "M";
            this.MBTN.UseVisualStyleBackColor = false;
            this.MBTN.Click += new System.EventHandler(this.MBTN_Click);
            // 
            // TBTN
            // 
            this.TBTN.BackColor = System.Drawing.Color.White;
            this.TBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TBTN.FlatAppearance.BorderSize = 0;
            this.TBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            this.TBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.TBTN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.TBTN.Location = new System.Drawing.Point(204, 324);
            this.TBTN.Name = "TBTN";
            this.TBTN.Size = new System.Drawing.Size(40, 40);
            this.TBTN.TabIndex = 8;
            this.TBTN.Text = "T";
            this.TBTN.UseVisualStyleBackColor = false;
            this.TBTN.Click += new System.EventHandler(this.TBTN_Click);
            // 
            // WBTN
            // 
            this.WBTN.BackColor = System.Drawing.Color.White;
            this.WBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.WBTN.FlatAppearance.BorderSize = 0;
            this.WBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            this.WBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.WBTN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.WBTN.Location = new System.Drawing.Point(250, 324);
            this.WBTN.Name = "WBTN";
            this.WBTN.Size = new System.Drawing.Size(40, 40);
            this.WBTN.TabIndex = 9;
            this.WBTN.Text = "W";
            this.WBTN.UseVisualStyleBackColor = false;
            this.WBTN.Click += new System.EventHandler(this.WBTN_Click);
            // 
            // ThBTN
            // 
            this.ThBTN.BackColor = System.Drawing.Color.White;
            this.ThBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ThBTN.FlatAppearance.BorderSize = 0;
            this.ThBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            this.ThBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ThBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.ThBTN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.ThBTN.Location = new System.Drawing.Point(296, 324);
            this.ThBTN.Name = "ThBTN";
            this.ThBTN.Size = new System.Drawing.Size(40, 40);
            this.ThBTN.TabIndex = 10;
            this.ThBTN.Text = "Th";
            this.ThBTN.UseVisualStyleBackColor = false;
            this.ThBTN.Click += new System.EventHandler(this.ThBTN_Click);
            // 
            // FBTN
            // 
            this.FBTN.BackColor = System.Drawing.Color.White;
            this.FBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FBTN.FlatAppearance.BorderSize = 0;
            this.FBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            this.FBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.FBTN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.FBTN.Location = new System.Drawing.Point(342, 324);
            this.FBTN.Name = "FBTN";
            this.FBTN.Size = new System.Drawing.Size(40, 40);
            this.FBTN.TabIndex = 11;
            this.FBTN.Text = "F";
            this.FBTN.UseVisualStyleBackColor = false;
            this.FBTN.Click += new System.EventHandler(this.FBTN_Click);
            // 
            // SaBTN
            // 
            this.SaBTN.BackColor = System.Drawing.Color.White;
            this.SaBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SaBTN.FlatAppearance.BorderSize = 0;
            this.SaBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            this.SaBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.SaBTN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.SaBTN.Location = new System.Drawing.Point(388, 324);
            this.SaBTN.Name = "SaBTN";
            this.SaBTN.Size = new System.Drawing.Size(40, 40);
            this.SaBTN.TabIndex = 12;
            this.SaBTN.Text = "Sa";
            this.SaBTN.UseVisualStyleBackColor = false;
            this.SaBTN.Click += new System.EventHandler(this.SaBTN_Click);
            // 
            // DaysTLTP
            // 
            this.DaysTLTP.AutoPopDelay = 3000;
            this.DaysTLTP.InitialDelay = 500;
            this.DaysTLTP.ReshowDelay = 100;
            this.DaysTLTP.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            // 
            // HoursTLTP
            // 
            this.HoursTLTP.AutoPopDelay = 3000;
            this.HoursTLTP.InitialDelay = 500;
            this.HoursTLTP.ReshowDelay = 100;
            this.HoursTLTP.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            // 
            // FormLBL
            // 
            this.FormLBL.AutoSize = true;
            this.FormLBL.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.FormLBL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.FormLBL.Location = new System.Drawing.Point(168, 68);
            this.FormLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FormLBL.Name = "FormLBL";
            this.FormLBL.Size = new System.Drawing.Size(223, 37);
            this.FormLBL.TabIndex = 141;
            this.FormLBL.Text = "Add Duty Detail";
            // 
            // DateEffective
            // 
            this.DateEffective.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.DateEffective.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.DateEffective.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateEffective.Location = new System.Drawing.Point(293, 405);
            this.DateEffective.Name = "DateEffective";
            this.DateEffective.Size = new System.Drawing.Size(101, 25);
            this.DateEffective.TabIndex = 234;
            this.DateEffective.ValueChanged += new System.EventHandler(this.DateEffective_ValueChanged);
            // 
            // DateDismissed
            // 
            this.DateDismissed.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.DateDismissed.Enabled = false;
            this.DateDismissed.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.DateDismissed.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateDismissed.Location = new System.Drawing.Point(293, 449);
            this.DateDismissed.Name = "DateDismissed";
            this.DateDismissed.Size = new System.Drawing.Size(101, 25);
            this.DateDismissed.TabIndex = 236;
            // 
            // DateDismissedCheck
            // 
            this.DateDismissedCheck.AutoSize = true;
            this.DateDismissedCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DateDismissedCheck.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.DateDismissedCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.DateDismissedCheck.Location = new System.Drawing.Point(160, 450);
            this.DateDismissedCheck.Name = "DateDismissedCheck";
            this.DateDismissedCheck.Size = new System.Drawing.Size(118, 23);
            this.DateDismissedCheck.TabIndex = 239;
            this.DateDismissedCheck.Text = "Date Dismissed";
            this.DateDismissedCheck.UseVisualStyleBackColor = true;
            this.DateDismissedCheck.CheckedChanged += new System.EventHandler(this.DateDismissedCheck_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label2.Location = new System.Drawing.Point(182, 407);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 19);
            this.label2.TabIndex = 240;
            this.label2.Text = "Date Effective";
            // 
            // SchedAddDutyDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(568, 598);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DateDismissedCheck);
            this.Controls.Add(this.DateDismissed);
            this.Controls.Add(this.DateEffective);
            this.Controls.Add(this.FormLBL);
            this.Controls.Add(this.SaBTN);
            this.Controls.Add(this.FBTN);
            this.Controls.Add(this.ThBTN);
            this.Controls.Add(this.WBTN);
            this.Controls.Add(this.TBTN);
            this.Controls.Add(this.MBTN);
            this.Controls.Add(this.SuBTN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TimeOutMinBX);
            this.Controls.Add(this.TimeOutHrBX);
            this.Controls.Add(this.TimeOutAMPMBX);
            this.Controls.Add(this.TimeInMinBX);
            this.Controls.Add(this.TimeInHrBX);
            this.Controls.Add(this.AddBTN);
            this.Controls.Add(this.CloseBTN);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TimeInAMPMBX);
            this.Controls.Add(this.HoursLBL);
            this.Controls.Add(this.label20);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SchedAddDutyDetail";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SchedAddDutyDetail_FormClosing);
            this.Load += new System.EventHandler(this.Sched_AddDutyDetail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label HoursLBL;
        private System.Windows.Forms.ComboBox TimeInAMPMBX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button AddBTN;
        private System.Windows.Forms.Button CloseBTN;
        private System.Windows.Forms.Timer FadeTMR;
        private System.Windows.Forms.ComboBox TimeInHrBX;
        private System.Windows.Forms.ComboBox TimeInMinBX;
        private System.Windows.Forms.ComboBox TimeOutMinBX;
        private System.Windows.Forms.ComboBox TimeOutHrBX;
        private System.Windows.Forms.ComboBox TimeOutAMPMBX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SuBTN;
        private System.Windows.Forms.Button MBTN;
        private System.Windows.Forms.Button TBTN;
        private System.Windows.Forms.Button WBTN;
        private System.Windows.Forms.Button ThBTN;
        private System.Windows.Forms.Button FBTN;
        private System.Windows.Forms.Button SaBTN;
        private System.Windows.Forms.ToolTip DaysTLTP;
        private System.Windows.Forms.ToolTip HoursTLTP;
        private System.Windows.Forms.Label FormLBL;
        private System.Windows.Forms.DateTimePicker DateEffective;
        private System.Windows.Forms.DateTimePicker DateDismissed;
        private System.Windows.Forms.CheckBox DateDismissedCheck;
        private System.Windows.Forms.Label label2;
    }
}