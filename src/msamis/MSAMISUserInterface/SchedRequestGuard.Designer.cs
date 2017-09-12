namespace MSAMISUserInterface {
    partial class SchedRequestGuard {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SchedRequestGuard));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.AddBTN = new System.Windows.Forms.Button();
            this.CloseBTN = new System.Windows.Forms.Button();
            this.AssBrgyBX = new System.Windows.Forms.TextBox();
            this.AssCityBX = new System.Windows.Forms.TextBox();
            this.AssStreetNameBX = new System.Windows.Forms.TextBox();
            this.AssStreetNoBX = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ContractStartDTPKR = new System.Windows.Forms.DateTimePicker();
            this.BdayLBL = new System.Windows.Forms.Label();
            this.ContractEndDTPKR = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.ClientGRD = new System.Windows.Forms.DataGridView();
            this.RequestLBL = new System.Windows.Forms.Label();
            this.PickLBL = new System.Windows.Forms.Label();
            this.FadeTMR = new System.Windows.Forms.Timer(this.components);
            this.ClientSearchBX = new System.Windows.Forms.TextBox();
            this.ClientSearchLine = new System.Windows.Forms.Label();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.NeededTLTP = new System.Windows.Forms.ToolTip(this.components);
            this.LocationTLTP = new System.Windows.Forms.ToolTip(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.NeededBX = new System.Windows.Forms.NumericUpDown();
            this.RequestPNL = new System.Windows.Forms.Panel();
            this.PickPNL = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ClientLBL = new System.Windows.Forms.Label();
            this.NextBTN = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ClientGRD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NeededBX)).BeginInit();
            this.RequestPNL.SuspendLayout();
            this.PickPNL.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddBTN
            // 
            this.AddBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.AddBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AddBTN.BackgroundImage")));
            this.AddBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AddBTN.FlatAppearance.BorderSize = 0;
            this.AddBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(87)))), ((int)(((byte)(145)))));
            this.AddBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddBTN.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddBTN.ForeColor = System.Drawing.Color.White;
            this.AddBTN.Location = new System.Drawing.Point(279, 540);
            this.AddBTN.Name = "AddBTN";
            this.AddBTN.Size = new System.Drawing.Size(78, 32);
            this.AddBTN.TabIndex = 71;
            this.AddBTN.Text = "ADD";
            this.AddBTN.UseVisualStyleBackColor = false;
            this.AddBTN.Click += new System.EventHandler(this.AddBTN_Click);
            // 
            // CloseBTN
            // 
            this.CloseBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.CloseBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CloseBTN.FlatAppearance.BorderSize = 0;
            this.CloseBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.CloseBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(97)))), ((int)(((byte)(81)))));
            this.CloseBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBTN.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold);
            this.CloseBTN.ForeColor = System.Drawing.Color.White;
            this.CloseBTN.Location = new System.Drawing.Point(514, 0);
            this.CloseBTN.Name = "CloseBTN";
            this.CloseBTN.Size = new System.Drawing.Size(34, 32);
            this.CloseBTN.TabIndex = 72;
            this.CloseBTN.Text = "X";
            this.CloseBTN.UseVisualStyleBackColor = false;
            this.CloseBTN.Click += new System.EventHandler(this.CloseBTN_Click);
            // 
            // AssBrgyBX
            // 
            this.AssBrgyBX.BackColor = System.Drawing.Color.White;
            this.AssBrgyBX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AssBrgyBX.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.AssBrgyBX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.AssBrgyBX.Location = new System.Drawing.Point(343, 36);
            this.AssBrgyBX.MaxLength = 60;
            this.AssBrgyBX.Name = "AssBrgyBX";
            this.AssBrgyBX.Size = new System.Drawing.Size(77, 18);
            this.AssBrgyBX.TabIndex = 82;
            this.AssBrgyBX.Text = "Brgy";
            this.AssBrgyBX.Enter += new System.EventHandler(this.AssBrgyBX_Enter);
            this.AssBrgyBX.Leave += new System.EventHandler(this.AssBrgyBX_Leave);
            // 
            // AssCityBX
            // 
            this.AssCityBX.BackColor = System.Drawing.Color.White;
            this.AssCityBX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AssCityBX.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.AssCityBX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.AssCityBX.Location = new System.Drawing.Point(419, 36);
            this.AssCityBX.MaxLength = 45;
            this.AssCityBX.Name = "AssCityBX";
            this.AssCityBX.Size = new System.Drawing.Size(77, 18);
            this.AssCityBX.TabIndex = 83;
            this.AssCityBX.Text = "City";
            this.AssCityBX.Enter += new System.EventHandler(this.AssCityBX_Enter);
            this.AssCityBX.Leave += new System.EventHandler(this.AssCityBX_Leave);
            // 
            // AssStreetNameBX
            // 
            this.AssStreetNameBX.BackColor = System.Drawing.Color.White;
            this.AssStreetNameBX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AssStreetNameBX.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.AssStreetNameBX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.AssStreetNameBX.Location = new System.Drawing.Point(241, 36);
            this.AssStreetNameBX.MaxLength = 45;
            this.AssStreetNameBX.Name = "AssStreetNameBX";
            this.AssStreetNameBX.Size = new System.Drawing.Size(90, 18);
            this.AssStreetNameBX.TabIndex = 81;
            this.AssStreetNameBX.Text = "Street Name";
            this.AssStreetNameBX.Enter += new System.EventHandler(this.AssStreetNameBX_Enter);
            this.AssStreetNameBX.Leave += new System.EventHandler(this.AssStreetNameBX_Leave);
            // 
            // AssStreetNoBX
            // 
            this.AssStreetNoBX.BackColor = System.Drawing.Color.White;
            this.AssStreetNoBX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AssStreetNoBX.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.AssStreetNoBX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.AssStreetNoBX.Location = new System.Drawing.Point(200, 36);
            this.AssStreetNoBX.MaxLength = 11;
            this.AssStreetNoBX.Name = "AssStreetNoBX";
            this.AssStreetNoBX.Size = new System.Drawing.Size(38, 18);
            this.AssStreetNoBX.TabIndex = 80;
            this.AssStreetNoBX.Text = "No.";
            this.AssStreetNoBX.Enter += new System.EventHandler(this.AssStreetNoBX_Enter);
            this.AssStreetNoBX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AssStreetNoBX_KeyPress);
            this.AssStreetNoBX.Leave += new System.EventHandler(this.AssStreetNoBX_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label7.Location = new System.Drawing.Point(41, 35);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 19);
            this.label7.TabIndex = 84;
            this.label7.Text = "Assignment Location:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.ForeColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(195, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 85;
            this.label1.Text = "______";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.ForeColor = System.Drawing.Color.LightGray;
            this.label4.Location = new System.Drawing.Point(238, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 86;
            this.label4.Text = "_______________";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.ForeColor = System.Drawing.Color.LightGray;
            this.label5.Location = new System.Drawing.Point(413, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 87;
            this.label5.Text = "____________";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.White;
            this.label21.ForeColor = System.Drawing.Color.LightGray;
            this.label21.Location = new System.Drawing.Point(336, 45);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(79, 13);
            this.label21.TabIndex = 88;
            this.label21.Text = "____________";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label9.Location = new System.Drawing.Point(41, 169);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 19);
            this.label9.TabIndex = 97;
            this.label9.Text = "Guards Needed:";
            // 
            // ContractStartDTPKR
            // 
            this.ContractStartDTPKR.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.ContractStartDTPKR.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.ContractStartDTPKR.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ContractStartDTPKR.Location = new System.Drawing.Point(198, 77);
            this.ContractStartDTPKR.Name = "ContractStartDTPKR";
            this.ContractStartDTPKR.Size = new System.Drawing.Size(101, 25);
            this.ContractStartDTPKR.TabIndex = 100;
            this.ContractStartDTPKR.ValueChanged += new System.EventHandler(this.ContractStartDTPKR_ValueChanged);
            // 
            // BdayLBL
            // 
            this.BdayLBL.AutoSize = true;
            this.BdayLBL.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.BdayLBL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.BdayLBL.Location = new System.Drawing.Point(41, 80);
            this.BdayLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BdayLBL.Name = "BdayLBL";
            this.BdayLBL.Size = new System.Drawing.Size(94, 19);
            this.BdayLBL.TabIndex = 101;
            this.BdayLBL.Text = "Contract Start:";
            // 
            // ContractEndDTPKR
            // 
            this.ContractEndDTPKR.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.ContractEndDTPKR.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.ContractEndDTPKR.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ContractEndDTPKR.Location = new System.Drawing.Point(198, 122);
            this.ContractEndDTPKR.Name = "ContractEndDTPKR";
            this.ContractEndDTPKR.Size = new System.Drawing.Size(101, 25);
            this.ContractEndDTPKR.TabIndex = 102;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label2.Location = new System.Drawing.Point(41, 126);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 19);
            this.label2.TabIndex = 103;
            this.label2.Text = "Contract End:";
            // 
            // ClientGRD
            // 
            this.ClientGRD.AllowUserToAddRows = false;
            this.ClientGRD.AllowUserToDeleteRows = false;
            this.ClientGRD.AllowUserToResizeColumns = false;
            this.ClientGRD.AllowUserToResizeRows = false;
            this.ClientGRD.BackgroundColor = System.Drawing.Color.White;
            this.ClientGRD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ClientGRD.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.ClientGRD.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle1.NullValue = "-";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ClientGRD.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ClientGRD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ClientGRD.DefaultCellStyle = dataGridViewCellStyle2;
            this.ClientGRD.EnableHeadersVisualStyles = false;
            this.ClientGRD.Location = new System.Drawing.Point(91, 41);
            this.ClientGRD.MultiSelect = false;
            this.ClientGRD.Name = "ClientGRD";
            this.ClientGRD.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ClientGRD.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ClientGRD.RowHeadersVisible = false;
            this.ClientGRD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ClientGRD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ClientGRD.Size = new System.Drawing.Size(434, 284);
            this.ClientGRD.TabIndex = 104;
            this.ClientGRD.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClientGRD_CellEnter);
            this.ClientGRD.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ClientGRD_MouseDoubleClick);
            // 
            // RequestLBL
            // 
            this.RequestLBL.AutoSize = true;
            this.RequestLBL.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.RequestLBL.ForeColor = System.Drawing.Color.DarkGray;
            this.RequestLBL.Location = new System.Drawing.Point(294, 131);
            this.RequestLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RequestLBL.Name = "RequestLBL";
            this.RequestLBL.Size = new System.Drawing.Size(144, 25);
            this.RequestLBL.TabIndex = 105;
            this.RequestLBL.Text = "Request Details";
            this.RequestLBL.Click += new System.EventHandler(this.RequestLBL_Click);
            this.RequestLBL.MouseEnter += new System.EventHandler(this.RequestLBL_MouseEnter);
            this.RequestLBL.MouseLeave += new System.EventHandler(this.RequestLBL_MouseLeave);
            // 
            // PickLBL
            // 
            this.PickLBL.AutoSize = true;
            this.PickLBL.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.PickLBL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.PickLBL.Location = new System.Drawing.Point(141, 131);
            this.PickLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PickLBL.Name = "PickLBL";
            this.PickLBL.Size = new System.Drawing.Size(114, 25);
            this.PickLBL.TabIndex = 106;
            this.PickLBL.Text = "Pick a client";
            this.PickLBL.Click += new System.EventHandler(this.PickLBL_Click);
            this.PickLBL.MouseEnter += new System.EventHandler(this.PickLBL_MouseEnter);
            this.PickLBL.MouseLeave += new System.EventHandler(this.PickLBL_MouseLeave);
            // 
            // FadeTMR
            // 
            this.FadeTMR.Interval = 1;
            this.FadeTMR.Tick += new System.EventHandler(this.FadeTMR_Tick);
            // 
            // ClientSearchBX
            // 
            this.ClientSearchBX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ClientSearchBX.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientSearchBX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.ClientSearchBX.Location = new System.Drawing.Point(155, 4);
            this.ClientSearchBX.Name = "ClientSearchBX";
            this.ClientSearchBX.Size = new System.Drawing.Size(199, 18);
            this.ClientSearchBX.TabIndex = 107;
            this.ClientSearchBX.Text = "Search or filter";
            this.ClientSearchBX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ClientSearchBX.TextChanged += new System.EventHandler(this.ClientSearchBX_TextChanged);
            this.ClientSearchBX.Enter += new System.EventHandler(this.SViewAssSearchTXTBX_Enter);
            this.ClientSearchBX.Leave += new System.EventHandler(this.SViewAssSearchTXTBX_Leave);
            // 
            // ClientSearchLine
            // 
            this.ClientSearchLine.AutoSize = true;
            this.ClientSearchLine.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.ClientSearchLine.ForeColor = System.Drawing.Color.Silver;
            this.ClientSearchLine.Location = new System.Drawing.Point(151, 9);
            this.ClientSearchLine.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ClientSearchLine.Name = "ClientSearchLine";
            this.ClientSearchLine.Size = new System.Drawing.Size(207, 19);
            this.ClientSearchLine.TabIndex = 108;
            this.ClientSearchLine.Text = "_________________________________";
            this.ClientSearchLine.Visible = false;
            // 
            // NeededTLTP
            // 
            this.NeededTLTP.AutoPopDelay = 3000;
            this.NeededTLTP.InitialDelay = 500;
            this.NeededTLTP.ReshowDelay = 100;
            this.NeededTLTP.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            // 
            // LocationTLTP
            // 
            this.LocationTLTP.AutoPopDelay = 3000;
            this.LocationTLTP.InitialDelay = 500;
            this.LocationTLTP.ReshowDelay = 100;
            this.LocationTLTP.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(0, 22);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(548, 45);
            this.label8.TabIndex = 109;
            this.label8.Text = "Request for guards";
            this.label8.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // NeededBX
            // 
            this.NeededBX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NeededBX.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.NeededBX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.NeededBX.Location = new System.Drawing.Point(199, 169);
            this.NeededBX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NeededBX.Name = "NeededBX";
            this.NeededBX.Size = new System.Drawing.Size(102, 21);
            this.NeededBX.TabIndex = 110;
            this.NeededBX.ThousandsSeparator = true;
            // 
            // RequestPNL
            // 
            this.RequestPNL.Controls.Add(this.label7);
            this.RequestPNL.Controls.Add(this.NeededBX);
            this.RequestPNL.Controls.Add(this.AssStreetNoBX);
            this.RequestPNL.Controls.Add(this.AssStreetNameBX);
            this.RequestPNL.Controls.Add(this.AssCityBX);
            this.RequestPNL.Controls.Add(this.AssBrgyBX);
            this.RequestPNL.Controls.Add(this.label9);
            this.RequestPNL.Controls.Add(this.ContractEndDTPKR);
            this.RequestPNL.Controls.Add(this.BdayLBL);
            this.RequestPNL.Controls.Add(this.label2);
            this.RequestPNL.Controls.Add(this.ContractStartDTPKR);
            this.RequestPNL.Controls.Add(this.label21);
            this.RequestPNL.Controls.Add(this.label5);
            this.RequestPNL.Controls.Add(this.label4);
            this.RequestPNL.Controls.Add(this.label1);
            this.RequestPNL.Location = new System.Drawing.Point(22, 170);
            this.RequestPNL.Name = "RequestPNL";
            this.RequestPNL.Size = new System.Drawing.Size(526, 343);
            this.RequestPNL.TabIndex = 113;
            // 
            // PickPNL
            // 
            this.PickPNL.Controls.Add(this.ClientGRD);
            this.PickPNL.Controls.Add(this.ClientSearchBX);
            this.PickPNL.Controls.Add(this.ClientSearchLine);
            this.PickPNL.Location = new System.Drawing.Point(22, 170);
            this.PickPNL.Name = "PickPNL";
            this.PickPNL.Size = new System.Drawing.Size(526, 343);
            this.PickPNL.TabIndex = 114;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.panel3.Controls.Add(this.CloseBTN);
            this.panel3.Controls.Add(this.ClientLBL);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(554, 116);
            this.panel3.TabIndex = 115;
            // 
            // ClientLBL
            // 
            this.ClientLBL.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ClientLBL.ForeColor = System.Drawing.Color.White;
            this.ClientLBL.Location = new System.Drawing.Point(-1, 70);
            this.ClientLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ClientLBL.Name = "ClientLBL";
            this.ClientLBL.Size = new System.Drawing.Size(548, 27);
            this.ClientLBL.TabIndex = 110;
            this.ClientLBL.Text = "Pick a client";
            this.ClientLBL.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // NextBTN
            // 
            this.NextBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NextBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.NextBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("NextBTN.BackgroundImage")));
            this.NextBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.NextBTN.FlatAppearance.BorderSize = 0;
            this.NextBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(87)))), ((int)(((byte)(145)))));
            this.NextBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NextBTN.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NextBTN.ForeColor = System.Drawing.Color.White;
            this.NextBTN.Location = new System.Drawing.Point(195, 540);
            this.NextBTN.Name = "NextBTN";
            this.NextBTN.Size = new System.Drawing.Size(78, 32);
            this.NextBTN.TabIndex = 116;
            this.NextBTN.Text = "NEXT";
            this.NextBTN.UseVisualStyleBackColor = false;
            this.NextBTN.Click += new System.EventHandler(this.NextBTN_Click);
            // 
            // SchedRequestGuard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(548, 598);
            this.ControlBox = false;
            this.Controls.Add(this.NextBTN);
            this.Controls.Add(this.PickLBL);
            this.Controls.Add(this.RequestLBL);
            this.Controls.Add(this.AddBTN);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.PickPNL);
            this.Controls.Add(this.RequestPNL);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SchedRequestGuard";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Sched_RequestGuard_FormClosing);
            this.Load += new System.EventHandler(this.Sched_RequestGuard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ClientGRD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NeededBX)).EndInit();
            this.RequestPNL.ResumeLayout(false);
            this.RequestPNL.PerformLayout();
            this.PickPNL.ResumeLayout(false);
            this.PickPNL.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddBTN;
        private System.Windows.Forms.Button CloseBTN;
        private System.Windows.Forms.TextBox AssBrgyBX;
        private System.Windows.Forms.TextBox AssCityBX;
        private System.Windows.Forms.TextBox AssStreetNameBX;
        private System.Windows.Forms.TextBox AssStreetNoBX;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker ContractStartDTPKR;
        private System.Windows.Forms.Label BdayLBL;
        private System.Windows.Forms.DateTimePicker ContractEndDTPKR;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView ClientGRD;
        private System.Windows.Forms.Label RequestLBL;
        private System.Windows.Forms.Label PickLBL;
        private System.Windows.Forms.Timer FadeTMR;
        private System.Windows.Forms.TextBox ClientSearchBX;
        private System.Windows.Forms.Label ClientSearchLine;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.ToolTip NeededTLTP;
        private System.Windows.Forms.ToolTip LocationTLTP;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown NeededBX;
        private System.Windows.Forms.Panel RequestPNL;
        private System.Windows.Forms.Panel PickPNL;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button NextBTN;
        private System.Windows.Forms.Label ClientLBL;
    }
}