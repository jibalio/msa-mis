namespace MSAMISUserInterface {
    partial class Clients_Edit {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Clients_Edit));
            this.EmerLBL = new System.Windows.Forms.Label();
            this.label86 = new System.Windows.Forms.Label();
            this.ContactBX = new System.Windows.Forms.TextBox();
            this.LocationStreetNoBX = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.NameBX = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.ContactNoBX = new System.Windows.Forms.TextBox();
            this.ManagerBX = new System.Windows.Forms.TextBox();
            this.LocationCityBX = new System.Windows.Forms.TextBox();
            this.LocationStreetNameBX = new System.Windows.Forms.TextBox();
            this.DetailsPNL = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label87 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.LocationBrgyBX = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CloseBTN = new System.Windows.Forms.Button();
            this.GEditDetailsBTN = new System.Windows.Forms.Button();
            this.FadeTMR = new System.Windows.Forms.Timer(this.components);
            this.NameTLTP = new System.Windows.Forms.ToolTip(this.components);
            this.LocationTLTP = new System.Windows.Forms.ToolTip(this.components);
            this.ManagerTLTP = new System.Windows.Forms.ToolTip(this.components);
            this.ContactTLTP = new System.Windows.Forms.ToolTip(this.components);
            this.ContactNoTLTP = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.AddLBL = new System.Windows.Forms.Label();
            this.DetailsPNL.SuspendLayout();
            this.SuspendLayout();
            // 
            // EmerLBL
            // 
            this.EmerLBL.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.EmerLBL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.EmerLBL.Location = new System.Drawing.Point(0, 65);
            this.EmerLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.EmerLBL.Name = "EmerLBL";
            this.EmerLBL.Size = new System.Drawing.Size(597, 21);
            this.EmerLBL.TabIndex = 215;
            this.EmerLBL.Text = "CONTACT INFO";
            this.EmerLBL.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.label86.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label86.Location = new System.Drawing.Point(134, 148);
            this.label86.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(103, 19);
            this.label86.TabIndex = 216;
            this.label86.Text = "Contact Person:";
            // 
            // ContactBX
            // 
            this.ContactBX.BackColor = System.Drawing.Color.White;
            this.ContactBX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ContactBX.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.ContactBX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.ContactBX.Location = new System.Drawing.Point(243, 150);
            this.ContactBX.Name = "ContactBX";
            this.ContactBX.Size = new System.Drawing.Size(132, 18);
            this.ContactBX.TabIndex = 66;
            this.ContactBX.TextChanged += new System.EventHandler(this.NameBX_TextChanged);
            // 
            // LocationStreetNoBX
            // 
            this.LocationStreetNoBX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.LocationStreetNoBX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LocationStreetNoBX.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.LocationStreetNoBX.ForeColor = System.Drawing.Color.White;
            this.LocationStreetNoBX.Location = new System.Drawing.Point(190, 138);
            this.LocationStreetNoBX.Name = "LocationStreetNoBX";
            this.LocationStreetNoBX.Size = new System.Drawing.Size(38, 18);
            this.LocationStreetNoBX.TabIndex = 5;
            this.LocationStreetNoBX.Text = "No.";
            this.LocationStreetNoBX.TextChanged += new System.EventHandler(this.NameBX_TextChanged);
            this.LocationStreetNoBX.Enter += new System.EventHandler(this.LocationStreetNoBX_MouseEnter);
            this.LocationStreetNoBX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LocationStreetNoBX_KeyPress);
            this.LocationStreetNoBX.Leave += new System.EventHandler(this.StreetNoBX_Leave);
            // 
            // label45
            // 
            this.label45.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label45.AutoSize = true;
            this.label45.ForeColor = System.Drawing.Color.White;
            this.label45.Location = new System.Drawing.Point(111, 112);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(367, 13);
            this.label45.TabIndex = 116;
            this.label45.Text = "____________________________________________________________";
            // 
            // NameBX
            // 
            this.NameBX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.NameBX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NameBX.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.NameBX.ForeColor = System.Drawing.Color.White;
            this.NameBX.Location = new System.Drawing.Point(120, 101);
            this.NameBX.Name = "NameBX";
            this.NameBX.Size = new System.Drawing.Size(358, 18);
            this.NameBX.TabIndex = 0;
            this.NameBX.Text = "Name";
            this.NameBX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NameBX.TextChanged += new System.EventHandler(this.NameBX_TextChanged);
            this.NameBX.Enter += new System.EventHandler(this.NameBX_MouseEnter);
            this.NameBX.Leave += new System.EventHandler(this.NameBX_Leave);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.label23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label23.Location = new System.Drawing.Point(157, 189);
            this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(80, 19);
            this.label23.TabIndex = 73;
            this.label23.Text = "Contact No:";
            // 
            // ContactNoBX
            // 
            this.ContactNoBX.BackColor = System.Drawing.Color.White;
            this.ContactNoBX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ContactNoBX.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.ContactNoBX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.ContactNoBX.Location = new System.Drawing.Point(243, 189);
            this.ContactNoBX.Name = "ContactNoBX";
            this.ContactNoBX.Size = new System.Drawing.Size(131, 18);
            this.ContactNoBX.TabIndex = 67;
            this.ContactNoBX.TextChanged += new System.EventHandler(this.NameBX_TextChanged);
            // 
            // ManagerBX
            // 
            this.ManagerBX.BackColor = System.Drawing.Color.White;
            this.ManagerBX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ManagerBX.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.ManagerBX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.ManagerBX.Location = new System.Drawing.Point(250, 109);
            this.ManagerBX.Name = "ManagerBX";
            this.ManagerBX.Size = new System.Drawing.Size(121, 18);
            this.ManagerBX.TabIndex = 14;
            this.ManagerBX.TextChanged += new System.EventHandler(this.NameBX_TextChanged);
            // 
            // LocationCityBX
            // 
            this.LocationCityBX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.LocationCityBX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LocationCityBX.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.LocationCityBX.ForeColor = System.Drawing.Color.White;
            this.LocationCityBX.Location = new System.Drawing.Point(409, 137);
            this.LocationCityBX.Name = "LocationCityBX";
            this.LocationCityBX.Size = new System.Drawing.Size(77, 18);
            this.LocationCityBX.TabIndex = 8;
            this.LocationCityBX.Text = "City";
            this.LocationCityBX.TextChanged += new System.EventHandler(this.NameBX_TextChanged);
            this.LocationCityBX.Enter += new System.EventHandler(this.LocationCityBX_MouseEnter);
            this.LocationCityBX.Leave += new System.EventHandler(this.CityBX_Leave);
            // 
            // LocationStreetNameBX
            // 
            this.LocationStreetNameBX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.LocationStreetNameBX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LocationStreetNameBX.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.LocationStreetNameBX.ForeColor = System.Drawing.Color.White;
            this.LocationStreetNameBX.Location = new System.Drawing.Point(231, 138);
            this.LocationStreetNameBX.Name = "LocationStreetNameBX";
            this.LocationStreetNameBX.Size = new System.Drawing.Size(90, 18);
            this.LocationStreetNameBX.TabIndex = 6;
            this.LocationStreetNameBX.Text = "Street Name";
            this.LocationStreetNameBX.TextChanged += new System.EventHandler(this.NameBX_TextChanged);
            this.LocationStreetNameBX.Enter += new System.EventHandler(this.LocationStreetNameBX_MouseEnter);
            this.LocationStreetNameBX.Leave += new System.EventHandler(this.StreetNameBX_Leave);
            // 
            // DetailsPNL
            // 
            this.DetailsPNL.AutoScroll = true;
            this.DetailsPNL.BackColor = System.Drawing.Color.White;
            this.DetailsPNL.Controls.Add(this.EmerLBL);
            this.DetailsPNL.Controls.Add(this.label86);
            this.DetailsPNL.Controls.Add(this.ContactBX);
            this.DetailsPNL.Controls.Add(this.label23);
            this.DetailsPNL.Controls.Add(this.ContactNoBX);
            this.DetailsPNL.Controls.Add(this.ManagerBX);
            this.DetailsPNL.Controls.Add(this.label9);
            this.DetailsPNL.Controls.Add(this.label34);
            this.DetailsPNL.Controls.Add(this.label87);
            this.DetailsPNL.Controls.Add(this.label41);
            this.DetailsPNL.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.DetailsPNL.Location = new System.Drawing.Point(-1, 200);
            this.DetailsPNL.Name = "DetailsPNL";
            this.DetailsPNL.Size = new System.Drawing.Size(599, 400);
            this.DetailsPNL.TabIndex = 228;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label9.Location = new System.Drawing.Point(173, 109);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 19);
            this.label9.TabIndex = 10;
            this.label9.Text = "Manager:";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.BackColor = System.Drawing.Color.White;
            this.label34.ForeColor = System.Drawing.Color.LightGray;
            this.label34.Location = new System.Drawing.Point(245, 113);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(141, 19);
            this.label34.TabIndex = 96;
            this.label34.Text = "______________________";
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.BackColor = System.Drawing.Color.White;
            this.label87.ForeColor = System.Drawing.Color.LightGray;
            this.label87.Location = new System.Drawing.Point(242, 154);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(147, 19);
            this.label87.TabIndex = 217;
            this.label87.Text = "_______________________";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.BackColor = System.Drawing.Color.White;
            this.label41.ForeColor = System.Drawing.Color.Silver;
            this.label41.Location = new System.Drawing.Point(241, 193);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(147, 19);
            this.label41.TabIndex = 112;
            this.label41.Text = "_______________________";
            // 
            // LocationBrgyBX
            // 
            this.LocationBrgyBX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.LocationBrgyBX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LocationBrgyBX.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.LocationBrgyBX.ForeColor = System.Drawing.Color.White;
            this.LocationBrgyBX.Location = new System.Drawing.Point(333, 138);
            this.LocationBrgyBX.Name = "LocationBrgyBX";
            this.LocationBrgyBX.Size = new System.Drawing.Size(77, 18);
            this.LocationBrgyBX.TabIndex = 7;
            this.LocationBrgyBX.Text = "Brgy";
            this.LocationBrgyBX.TextChanged += new System.EventHandler(this.NameBX_TextChanged);
            this.LocationBrgyBX.Enter += new System.EventHandler(this.LocationBrgyBX_MouseEnter);
            this.LocationBrgyBX.Leave += new System.EventHandler(this.BrgyBX_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label7.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(115, 137);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 19);
            this.label7.TabIndex = 8;
            this.label7.Text = "Location:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(185, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 76;
            this.label1.Text = "______";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(228, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 77;
            this.label4.Text = "_______________";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(326, 149);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(79, 13);
            this.label21.TabIndex = 79;
            this.label21.Text = "____________";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(403, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 78;
            this.label5.Text = "____________";
            // 
            // CloseBTN
            // 
            this.CloseBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.CloseBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CloseBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseBTN.FlatAppearance.BorderSize = 0;
            this.CloseBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.CloseBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(97)))), ((int)(((byte)(81)))));
            this.CloseBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBTN.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseBTN.ForeColor = System.Drawing.Color.White;
            this.CloseBTN.Location = new System.Drawing.Point(567, 1);
            this.CloseBTN.Name = "CloseBTN";
            this.CloseBTN.Size = new System.Drawing.Size(31, 32);
            this.CloseBTN.TabIndex = 230;
            this.CloseBTN.Text = "X";
            this.CloseBTN.UseVisualStyleBackColor = false;
            this.CloseBTN.Click += new System.EventHandler(this.CloseBTN_Click);
            // 
            // GEditDetailsBTN
            // 
            this.GEditDetailsBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.GEditDetailsBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.GEditDetailsBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("GEditDetailsBTN.BackgroundImage")));
            this.GEditDetailsBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GEditDetailsBTN.FlatAppearance.BorderSize = 0;
            this.GEditDetailsBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(47)))), ((int)(((byte)(61)))));
            this.GEditDetailsBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            this.GEditDetailsBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GEditDetailsBTN.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GEditDetailsBTN.ForeColor = System.Drawing.Color.White;
            this.GEditDetailsBTN.Location = new System.Drawing.Point(259, 542);
            this.GEditDetailsBTN.Name = "GEditDetailsBTN";
            this.GEditDetailsBTN.Size = new System.Drawing.Size(78, 32);
            this.GEditDetailsBTN.TabIndex = 229;
            this.GEditDetailsBTN.Text = "SAVE";
            this.GEditDetailsBTN.UseVisualStyleBackColor = false;
            this.GEditDetailsBTN.Click += new System.EventHandler(this.GEditDetailsBTN_Click);
            // 
            // FadeTMR
            // 
            this.FadeTMR.Interval = 1;
            this.FadeTMR.Tick += new System.EventHandler(this.FadeTMR_Tick);
            // 
            // NameTLTP
            // 
            this.NameTLTP.AutoPopDelay = 3000;
            this.NameTLTP.InitialDelay = 500;
            this.NameTLTP.ReshowDelay = 100;
            this.NameTLTP.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            // 
            // LocationTLTP
            // 
            this.LocationTLTP.AutoPopDelay = 3000;
            this.LocationTLTP.InitialDelay = 500;
            this.LocationTLTP.ReshowDelay = 100;
            this.LocationTLTP.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            // 
            // ManagerTLTP
            // 
            this.ManagerTLTP.AutoPopDelay = 3000;
            this.ManagerTLTP.InitialDelay = 500;
            this.ManagerTLTP.ReshowDelay = 100;
            this.ManagerTLTP.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            // 
            // ContactTLTP
            // 
            this.ContactTLTP.AutoPopDelay = 3000;
            this.ContactTLTP.InitialDelay = 500;
            this.ContactTLTP.ReshowDelay = 100;
            this.ContactTLTP.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            // 
            // ContactNoTLTP
            // 
            this.ContactNoTLTP.AutoPopDelay = 3000;
            this.ContactNoTLTP.InitialDelay = 500;
            this.ContactNoTLTP.ReshowDelay = 100;
            this.ContactNoTLTP.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            // 
            // ToolTip
            // 
            this.ToolTip.AutoPopDelay = 1500;
            this.ToolTip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(161)))), ((int)(((byte)(206)))));
            this.ToolTip.ForeColor = System.Drawing.Color.White;
            this.ToolTip.InitialDelay = 500;
            this.ToolTip.ReshowDelay = 100;
            this.ToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ToolTip.ToolTipTitle = "Info";
            // 
            // AddLBL
            // 
            this.AddLBL.BackColor = System.Drawing.Color.Transparent;
            this.AddLBL.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.AddLBL.ForeColor = System.Drawing.Color.White;
            this.AddLBL.Location = new System.Drawing.Point(-1, 47);
            this.AddLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AddLBL.Name = "AddLBL";
            this.AddLBL.Size = new System.Drawing.Size(599, 45);
            this.AddLBL.TabIndex = 229;
            this.AddLBL.Text = "Add a client";
            this.AddLBL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Clients_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.CancelButton = this.CloseBTN;
            this.ClientSize = new System.Drawing.Size(598, 598);
            this.ControlBox = false;
            this.Controls.Add(this.AddLBL);
            this.Controls.Add(this.NameBX);
            this.Controls.Add(this.CloseBTN);
            this.Controls.Add(this.label45);
            this.Controls.Add(this.GEditDetailsBTN);
            this.Controls.Add(this.DetailsPNL);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.LocationStreetNoBX);
            this.Controls.Add(this.LocationStreetNameBX);
            this.Controls.Add(this.LocationBrgyBX);
            this.Controls.Add(this.LocationCityBX);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Clients_Edit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Clients_Edit_FormClosing);
            this.Load += new System.EventHandler(this.Clients_Edit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Clients_Edit_KeyDown);
            this.DetailsPNL.ResumeLayout(false);
            this.DetailsPNL.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label EmerLBL;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.TextBox ContactBX;
        private System.Windows.Forms.Button CloseBTN;
        private System.Windows.Forms.TextBox LocationStreetNoBX;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.TextBox NameBX;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox ContactNoBX;
        private System.Windows.Forms.Button GEditDetailsBTN;
        private System.Windows.Forms.TextBox ManagerBX;
        private System.Windows.Forms.TextBox LocationCityBX;
        private System.Windows.Forms.TextBox LocationStreetNameBX;
        private System.Windows.Forms.Panel DetailsPNL;
        private System.Windows.Forms.TextBox LocationBrgyBX;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label87;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Timer FadeTMR;
        private System.Windows.Forms.ToolTip NameTLTP;
        private System.Windows.Forms.ToolTip LocationTLTP;
        private System.Windows.Forms.ToolTip ManagerTLTP;
        private System.Windows.Forms.ToolTip ContactTLTP;
        private System.Windows.Forms.ToolTip ContactNoTLTP;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.Label AddLBL;
    }
}