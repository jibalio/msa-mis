namespace MSAMISUserInterface {
    partial class SchedAssignGuards {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SchedAssignGuards));
            this.panel1 = new System.Windows.Forms.Panel();
            this.NeededLBL = new System.Windows.Forms.Label();
            this.ClientLBL = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AvailableLBL = new System.Windows.Forms.Label();
            this.AvailableGRD = new System.Windows.Forms.DataGridView();
            this.nGID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssignedLBL = new System.Windows.Forms.Label();
            this.AssignedGRD = new System.Windows.Forms.DataGridView();
            this.gid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssignBTN = new System.Windows.Forms.Button();
            this.DeleteBTN = new System.Windows.Forms.Button();
            this.ConfirmBTN = new System.Windows.Forms.Button();
            this.CloseBTN = new System.Windows.Forms.Button();
            this.FadeTMR = new System.Windows.Forms.Timer(this.components);
            this.AvailablePNL = new System.Windows.Forms.Panel();
            this.AvailableSearchBX = new System.Windows.Forms.TextBox();
            this.AvailableSearchLine = new System.Windows.Forms.Label();
            this.AssignedPNL = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AvailableGRD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AssignedGRD)).BeginInit();
            this.AvailablePNL.SuspendLayout();
            this.AssignedPNL.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.NeededLBL);
            this.panel1.Controls.Add(this.ClientLBL);
            this.panel1.Controls.Add(this.label2);
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(-1, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(550, 93);
            this.panel1.TabIndex = 125;
            // 
            // NeededLBL
            // 
            this.NeededLBL.Dock = System.Windows.Forms.DockStyle.Top;
            this.NeededLBL.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.NeededLBL.ForeColor = System.Drawing.Color.White;
            this.NeededLBL.Location = new System.Drawing.Point(0, 65);
            this.NeededLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NeededLBL.Name = "NeededLBL";
            this.NeededLBL.Size = new System.Drawing.Size(550, 23);
            this.NeededLBL.TabIndex = 122;
            this.NeededLBL.Text = "Laboriki Enterprises";
            this.NeededLBL.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ClientLBL
            // 
            this.ClientLBL.Dock = System.Windows.Forms.DockStyle.Top;
            this.ClientLBL.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.ClientLBL.ForeColor = System.Drawing.Color.White;
            this.ClientLBL.Location = new System.Drawing.Point(0, 21);
            this.ClientLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ClientLBL.Name = "ClientLBL";
            this.ClientLBL.Size = new System.Drawing.Size(550, 44);
            this.ClientLBL.TabIndex = 120;
            this.ClientLBL.Text = "Laboriki Enterprises";
            this.ClientLBL.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(550, 21);
            this.label2.TabIndex = 121;
            this.label2.Text = "ASSIGN GUARDS TO";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // AvailableLBL
            // 
            this.AvailableLBL.AutoSize = true;
            this.AvailableLBL.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.AvailableLBL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.AvailableLBL.Location = new System.Drawing.Point(58, 15);
            this.AvailableLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AvailableLBL.Name = "AvailableLBL";
            this.AvailableLBL.Size = new System.Drawing.Size(206, 25);
            this.AvailableLBL.TabIndex = 141;
            this.AvailableLBL.Text = "Available Guards (300)";
            this.AvailableLBL.Click += new System.EventHandler(this.AvailableLBL_Click);
            this.AvailableLBL.MouseEnter += new System.EventHandler(this.AvailableLBL_MouseHover);
            this.AvailableLBL.MouseLeave += new System.EventHandler(this.AvailableLBL_MouseLeave);
            // 
            // AvailableGRD
            // 
            this.AvailableGRD.AllowUserToAddRows = false;
            this.AvailableGRD.AllowUserToDeleteRows = false;
            this.AvailableGRD.AllowUserToResizeColumns = false;
            this.AvailableGRD.AllowUserToResizeRows = false;
            this.AvailableGRD.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.AvailableGRD.BackgroundColor = System.Drawing.Color.White;
            this.AvailableGRD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AvailableGRD.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.AvailableGRD.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle1.NullValue = "-";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AvailableGRD.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.AvailableGRD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AvailableGRD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nGID,
            this.nName,
            this.nLocation});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.AvailableGRD.DefaultCellStyle = dataGridViewCellStyle2;
            this.AvailableGRD.EnableHeadersVisualStyles = false;
            this.AvailableGRD.Location = new System.Drawing.Point(62, 43);
            this.AvailableGRD.Name = "AvailableGRD";
            this.AvailableGRD.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AvailableGRD.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.AvailableGRD.RowHeadersVisible = false;
            this.AvailableGRD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.AvailableGRD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AvailableGRD.Size = new System.Drawing.Size(420, 259);
            this.AvailableGRD.TabIndex = 140;
            // 
            // nGID
            // 
            this.nGID.HeaderText = "GID";
            this.nGID.Name = "nGID";
            this.nGID.ReadOnly = true;
            this.nGID.Visible = false;
            // 
            // nName
            // 
            this.nName.HeaderText = "NAME";
            this.nName.Name = "nName";
            this.nName.ReadOnly = true;
            // 
            // nLocation
            // 
            this.nLocation.HeaderText = "LOCATION";
            this.nLocation.Name = "nLocation";
            this.nLocation.ReadOnly = true;
            // 
            // AssignedLBL
            // 
            this.AssignedLBL.AutoSize = true;
            this.AssignedLBL.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.AssignedLBL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            this.AssignedLBL.Location = new System.Drawing.Point(301, 15);
            this.AssignedLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AssignedLBL.Name = "AssignedLBL";
            this.AssignedLBL.Size = new System.Drawing.Size(182, 25);
            this.AssignedLBL.TabIndex = 143;
            this.AssignedLBL.Text = "Assigned Guards (0)";
            this.AssignedLBL.Click += new System.EventHandler(this.AssignedLBL_Click);
            this.AssignedLBL.MouseEnter += new System.EventHandler(this.AssignedLBL_MouseHover);
            this.AssignedLBL.MouseLeave += new System.EventHandler(this.AssignedLBL_MouseLeave);
            // 
            // AssignedGRD
            // 
            this.AssignedGRD.AllowUserToAddRows = false;
            this.AssignedGRD.AllowUserToDeleteRows = false;
            this.AssignedGRD.AllowUserToResizeColumns = false;
            this.AssignedGRD.AllowUserToResizeRows = false;
            this.AssignedGRD.BackgroundColor = System.Drawing.Color.White;
            this.AssignedGRD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AssignedGRD.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.AssignedGRD.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle4.NullValue = "-";
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AssignedGRD.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.AssignedGRD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AssignedGRD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gid,
            this.name,
            this.location});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.AssignedGRD.DefaultCellStyle = dataGridViewCellStyle5;
            this.AssignedGRD.EnableHeadersVisualStyles = false;
            this.AssignedGRD.Location = new System.Drawing.Point(62, 8);
            this.AssignedGRD.Name = "AssignedGRD";
            this.AssignedGRD.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AssignedGRD.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.AssignedGRD.RowHeadersVisible = false;
            this.AssignedGRD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.AssignedGRD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AssignedGRD.Size = new System.Drawing.Size(420, 294);
            this.AssignedGRD.TabIndex = 142;
            // 
            // gid
            // 
            this.gid.HeaderText = "GID";
            this.gid.Name = "gid";
            this.gid.ReadOnly = true;
            this.gid.Visible = false;
            // 
            // name
            // 
            this.name.HeaderText = "NAME";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // location
            // 
            this.location.HeaderText = "LOCATION";
            this.location.Name = "location";
            this.location.ReadOnly = true;
            // 
            // AssignBTN
            // 
            this.AssignBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AssignBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.AssignBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AssignBTN.BackgroundImage")));
            this.AssignBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AssignBTN.FlatAppearance.BorderSize = 0;
            this.AssignBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(47)))), ((int)(((byte)(61)))));
            this.AssignBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            this.AssignBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AssignBTN.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.AssignBTN.ForeColor = System.Drawing.Color.White;
            this.AssignBTN.Location = new System.Drawing.Point(234, 311);
            this.AssignBTN.Name = "AssignBTN";
            this.AssignBTN.Size = new System.Drawing.Size(80, 29);
            this.AssignBTN.TabIndex = 144;
            this.AssignBTN.Text = "ASSIGN";
            this.AssignBTN.UseVisualStyleBackColor = false;
            this.AssignBTN.Click += new System.EventHandler(this.AssignBTN_Click);
            // 
            // DeleteBTN
            // 
            this.DeleteBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.DeleteBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DeleteBTN.BackgroundImage")));
            this.DeleteBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DeleteBTN.FlatAppearance.BorderSize = 0;
            this.DeleteBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.DeleteBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(97)))), ((int)(((byte)(81)))));
            this.DeleteBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteBTN.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.DeleteBTN.ForeColor = System.Drawing.Color.White;
            this.DeleteBTN.Location = new System.Drawing.Point(234, 311);
            this.DeleteBTN.Name = "DeleteBTN";
            this.DeleteBTN.Size = new System.Drawing.Size(80, 29);
            this.DeleteBTN.TabIndex = 145;
            this.DeleteBTN.Text = "REMOVE";
            this.DeleteBTN.UseVisualStyleBackColor = false;
            this.DeleteBTN.Click += new System.EventHandler(this.DeleteBTN_Click);
            // 
            // ConfirmBTN
            // 
            this.ConfirmBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfirmBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.ConfirmBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ConfirmBTN.BackgroundImage")));
            this.ConfirmBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ConfirmBTN.FlatAppearance.BorderSize = 0;
            this.ConfirmBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(47)))), ((int)(((byte)(61)))));
            this.ConfirmBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            this.ConfirmBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConfirmBTN.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmBTN.ForeColor = System.Drawing.Color.White;
            this.ConfirmBTN.Location = new System.Drawing.Point(227, 416);
            this.ConfirmBTN.Name = "ConfirmBTN";
            this.ConfirmBTN.Size = new System.Drawing.Size(96, 32);
            this.ConfirmBTN.TabIndex = 146;
            this.ConfirmBTN.Text = "CONFIRM";
            this.ConfirmBTN.UseVisualStyleBackColor = false;
            this.ConfirmBTN.Click += new System.EventHandler(this.ConfirmBTN_Click);
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
            this.CloseBTN.Location = new System.Drawing.Point(513, 0);
            this.CloseBTN.Name = "CloseBTN";
            this.CloseBTN.Size = new System.Drawing.Size(35, 32);
            this.CloseBTN.TabIndex = 147;
            this.CloseBTN.Text = "X";
            this.CloseBTN.UseVisualStyleBackColor = false;
            this.CloseBTN.Click += new System.EventHandler(this.CloseBTN_Click);
            // 
            // FadeTMR
            // 
            this.FadeTMR.Interval = 1;
            this.FadeTMR.Tick += new System.EventHandler(this.FadeTMR_Tick);
            // 
            // AvailablePNL
            // 
            this.AvailablePNL.BackColor = System.Drawing.Color.White;
            this.AvailablePNL.Controls.Add(this.AvailableSearchBX);
            this.AvailablePNL.Controls.Add(this.AvailableSearchLine);
            this.AvailablePNL.Controls.Add(this.AssignBTN);
            this.AvailablePNL.Controls.Add(this.AvailableGRD);
            this.AvailablePNL.Location = new System.Drawing.Point(0, 51);
            this.AvailablePNL.Name = "AvailablePNL";
            this.AvailablePNL.Size = new System.Drawing.Size(549, 352);
            this.AvailablePNL.TabIndex = 149;
            // 
            // AvailableSearchBX
            // 
            this.AvailableSearchBX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AvailableSearchBX.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AvailableSearchBX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.AvailableSearchBX.Location = new System.Drawing.Point(176, 3);
            this.AvailableSearchBX.Name = "AvailableSearchBX";
            this.AvailableSearchBX.Size = new System.Drawing.Size(199, 18);
            this.AvailableSearchBX.TabIndex = 145;
            this.AvailableSearchBX.Text = "Search or filter";
            this.AvailableSearchBX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AvailableSearchBX.TextChanged += new System.EventHandler(this.AvailableSearchBX_TextChanged);
            this.AvailableSearchBX.Enter += new System.EventHandler(this.AvailableSearchBX_Enter);
            this.AvailableSearchBX.Leave += new System.EventHandler(this.AvailableSearchBX_Leave);
            // 
            // AvailableSearchLine
            // 
            this.AvailableSearchLine.AutoSize = true;
            this.AvailableSearchLine.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.AvailableSearchLine.ForeColor = System.Drawing.Color.Silver;
            this.AvailableSearchLine.Location = new System.Drawing.Point(172, 8);
            this.AvailableSearchLine.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AvailableSearchLine.Name = "AvailableSearchLine";
            this.AvailableSearchLine.Size = new System.Drawing.Size(207, 19);
            this.AvailableSearchLine.TabIndex = 146;
            this.AvailableSearchLine.Text = "_________________________________";
            this.AvailableSearchLine.Visible = false;
            // 
            // AssignedPNL
            // 
            this.AssignedPNL.BackColor = System.Drawing.Color.White;
            this.AssignedPNL.Controls.Add(this.AssignedGRD);
            this.AssignedPNL.Controls.Add(this.DeleteBTN);
            this.AssignedPNL.Location = new System.Drawing.Point(0, 51);
            this.AssignedPNL.Name = "AssignedPNL";
            this.AssignedPNL.Size = new System.Drawing.Size(549, 352);
            this.AssignedPNL.TabIndex = 150;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.AssignedLBL);
            this.panel2.Controls.Add(this.ConfirmBTN);
            this.panel2.Controls.Add(this.AvailableLBL);
            this.panel2.Controls.Add(this.AssignedPNL);
            this.panel2.Controls.Add(this.AvailablePNL);
            this.panel2.Location = new System.Drawing.Point(-1, 135);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(550, 467);
            this.panel2.TabIndex = 151;
            // 
            // SchedAssignGuards
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(548, 598);
            this.ControlBox = false;
            this.Controls.Add(this.CloseBTN);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SchedAssignGuards";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.Sched_AssignGuards_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AvailableGRD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AssignedGRD)).EndInit();
            this.AvailablePNL.ResumeLayout(false);
            this.AvailablePNL.PerformLayout();
            this.AssignedPNL.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label ClientLBL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label AvailableLBL;
        private System.Windows.Forms.DataGridView AvailableGRD;
        private System.Windows.Forms.Label AssignedLBL;
        private System.Windows.Forms.DataGridView AssignedGRD;
        private System.Windows.Forms.Button AssignBTN;
        private System.Windows.Forms.Button DeleteBTN;
        private System.Windows.Forms.Button ConfirmBTN;
        private System.Windows.Forms.Button CloseBTN;
        private System.Windows.Forms.Timer FadeTMR;
        private System.Windows.Forms.Label NeededLBL;
        private System.Windows.Forms.DataGridViewTextBoxColumn gid;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn location;
        private System.Windows.Forms.Panel AvailablePNL;
        private System.Windows.Forms.Panel AssignedPNL;
        private System.Windows.Forms.TextBox AvailableSearchBX;
        private System.Windows.Forms.Label AvailableSearchLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn nGID;
        private System.Windows.Forms.DataGridViewTextBoxColumn nName;
        private System.Windows.Forms.DataGridViewTextBoxColumn nLocation;
        private System.Windows.Forms.Panel panel2;
    }
}