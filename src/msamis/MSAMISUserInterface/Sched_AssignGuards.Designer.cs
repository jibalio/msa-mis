namespace MSAMISUserInterface {
    partial class Sched_AssignGuards {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sched_AssignGuards));
            this.panel1 = new System.Windows.Forms.Panel();
            this.NeededLBL = new System.Windows.Forms.Label();
            this.ClientLBL = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AvailableLBL = new System.Windows.Forms.Label();
            this.AvailableGRD = new System.Windows.Forms.DataGridView();
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
            this.AssignedPNL = new System.Windows.Forms.Panel();
            this.SArchiveSearchTXTBX = new System.Windows.Forms.TextBox();
            this.SArchiveSearchLine = new System.Windows.Forms.Label();
            this.AvailableSearchBX = new System.Windows.Forms.TextBox();
            this.AvailableSearchLine = new System.Windows.Forms.Label();
            this.nGID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AvailableGRD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AssignedGRD)).BeginInit();
            this.AvailablePNL.SuspendLayout();
            this.AssignedPNL.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.NeededLBL);
            this.panel1.Controls.Add(this.ClientLBL);
            this.panel1.Controls.Add(this.label2);
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(-1, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(718, 101);
            this.panel1.TabIndex = 125;
            // 
            // NeededLBL
            // 
            this.NeededLBL.Dock = System.Windows.Forms.DockStyle.Top;
            this.NeededLBL.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.NeededLBL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.NeededLBL.Location = new System.Drawing.Point(0, 70);
            this.NeededLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NeededLBL.Name = "NeededLBL";
            this.NeededLBL.Size = new System.Drawing.Size(718, 23);
            this.NeededLBL.TabIndex = 122;
            this.NeededLBL.Text = "Laboriki Enterprises";
            this.NeededLBL.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ClientLBL
            // 
            this.ClientLBL.Dock = System.Windows.Forms.DockStyle.Top;
            this.ClientLBL.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.ClientLBL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.ClientLBL.Location = new System.Drawing.Point(0, 26);
            this.ClientLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ClientLBL.Name = "ClientLBL";
            this.ClientLBL.Size = new System.Drawing.Size(718, 44);
            this.ClientLBL.TabIndex = 120;
            this.ClientLBL.Text = "Laboriki Enterprises";
            this.ClientLBL.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(718, 26);
            this.label2.TabIndex = 121;
            this.label2.Text = "ASSIGN GUARDS TO";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // AvailableLBL
            // 
            this.AvailableLBL.AutoSize = true;
            this.AvailableLBL.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.AvailableLBL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.AvailableLBL.Location = new System.Drawing.Point(143, 162);
            this.AvailableLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AvailableLBL.Name = "AvailableLBL";
            this.AvailableLBL.Size = new System.Drawing.Size(182, 21);
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
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle7.NullValue = "-";
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AvailableGRD.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.AvailableGRD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AvailableGRD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nGID,
            this.nName,
            this.nLocation});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.AvailableGRD.DefaultCellStyle = dataGridViewCellStyle8;
            this.AvailableGRD.EnableHeadersVisualStyles = false;
            this.AvailableGRD.Location = new System.Drawing.Point(112, 43);
            this.AvailableGRD.Name = "AvailableGRD";
            this.AvailableGRD.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AvailableGRD.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.AvailableGRD.RowHeadersVisible = false;
            this.AvailableGRD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AvailableGRD.Size = new System.Drawing.Size(599, 294);
            this.AvailableGRD.TabIndex = 140;
            // 
            // AssignedLBL
            // 
            this.AssignedLBL.AutoSize = true;
            this.AssignedLBL.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.AssignedLBL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            this.AssignedLBL.Location = new System.Drawing.Point(416, 162);
            this.AssignedLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AssignedLBL.Name = "AssignedLBL";
            this.AssignedLBL.Size = new System.Drawing.Size(161, 21);
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
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle10.NullValue = "-";
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AssignedGRD.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.AssignedGRD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AssignedGRD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gid,
            this.name,
            this.location});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.AssignedGRD.DefaultCellStyle = dataGridViewCellStyle11;
            this.AssignedGRD.EnableHeadersVisualStyles = false;
            this.AssignedGRD.Location = new System.Drawing.Point(112, 43);
            this.AssignedGRD.Name = "AssignedGRD";
            this.AssignedGRD.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AssignedGRD.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.AssignedGRD.RowHeadersVisible = false;
            this.AssignedGRD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AssignedGRD.Size = new System.Drawing.Size(599, 294);
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
            this.AssignBTN.Location = new System.Drawing.Point(314, 349);
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
            this.DeleteBTN.Location = new System.Drawing.Point(314, 349);
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
            this.ConfirmBTN.Location = new System.Drawing.Point(264, 600);
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
            this.CloseBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.CloseBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CloseBTN.BackgroundImage")));
            this.CloseBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CloseBTN.FlatAppearance.BorderSize = 0;
            this.CloseBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.CloseBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(97)))), ((int)(((byte)(81)))));
            this.CloseBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBTN.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseBTN.ForeColor = System.Drawing.Color.White;
            this.CloseBTN.Location = new System.Drawing.Point(366, 600);
            this.CloseBTN.Name = "CloseBTN";
            this.CloseBTN.Size = new System.Drawing.Size(96, 32);
            this.CloseBTN.TabIndex = 147;
            this.CloseBTN.Text = "CANCEL";
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
            this.AvailablePNL.Controls.Add(this.SArchiveSearchTXTBX);
            this.AvailablePNL.Controls.Add(this.SArchiveSearchLine);
            this.AvailablePNL.Controls.Add(this.AssignBTN);
            this.AvailablePNL.Controls.Add(this.AvailableGRD);
            this.AvailablePNL.Location = new System.Drawing.Point(6, 189);
            this.AvailablePNL.Name = "AvailablePNL";
            this.AvailablePNL.Size = new System.Drawing.Size(711, 390);
            this.AvailablePNL.TabIndex = 149;
            // 
            // AssignedPNL
            // 
            this.AssignedPNL.Controls.Add(this.AvailableSearchBX);
            this.AssignedPNL.Controls.Add(this.AvailableSearchLine);
            this.AssignedPNL.Controls.Add(this.AssignedGRD);
            this.AssignedPNL.Controls.Add(this.DeleteBTN);
            this.AssignedPNL.Location = new System.Drawing.Point(6, 189);
            this.AssignedPNL.Name = "AssignedPNL";
            this.AssignedPNL.Size = new System.Drawing.Size(711, 390);
            this.AssignedPNL.TabIndex = 150;
            // 
            // SArchiveSearchTXTBX
            // 
            this.SArchiveSearchTXTBX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SArchiveSearchTXTBX.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SArchiveSearchTXTBX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.SArchiveSearchTXTBX.Location = new System.Drawing.Point(258, 16);
            this.SArchiveSearchTXTBX.Name = "SArchiveSearchTXTBX";
            this.SArchiveSearchTXTBX.Size = new System.Drawing.Size(199, 18);
            this.SArchiveSearchTXTBX.TabIndex = 145;
            this.SArchiveSearchTXTBX.Text = "Search or filter";
            this.SArchiveSearchTXTBX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SArchiveSearchLine
            // 
            this.SArchiveSearchLine.AutoSize = true;
            this.SArchiveSearchLine.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.SArchiveSearchLine.ForeColor = System.Drawing.Color.Silver;
            this.SArchiveSearchLine.Location = new System.Drawing.Point(259, 21);
            this.SArchiveSearchLine.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SArchiveSearchLine.Name = "SArchiveSearchLine";
            this.SArchiveSearchLine.Size = new System.Drawing.Size(207, 19);
            this.SArchiveSearchLine.TabIndex = 146;
            this.SArchiveSearchLine.Text = "_________________________________";
            this.SArchiveSearchLine.Visible = false;
            // 
            // AvailableSearchBX
            // 
            this.AvailableSearchBX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AvailableSearchBX.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AvailableSearchBX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.AvailableSearchBX.Location = new System.Drawing.Point(258, 16);
            this.AvailableSearchBX.Name = "AvailableSearchBX";
            this.AvailableSearchBX.Size = new System.Drawing.Size(199, 18);
            this.AvailableSearchBX.TabIndex = 147;
            this.AvailableSearchBX.Text = "Search or filter";
            this.AvailableSearchBX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AvailableSearchLine
            // 
            this.AvailableSearchLine.AutoSize = true;
            this.AvailableSearchLine.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.AvailableSearchLine.ForeColor = System.Drawing.Color.Silver;
            this.AvailableSearchLine.Location = new System.Drawing.Point(259, 21);
            this.AvailableSearchLine.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AvailableSearchLine.Name = "AvailableSearchLine";
            this.AvailableSearchLine.Size = new System.Drawing.Size(207, 19);
            this.AvailableSearchLine.TabIndex = 148;
            this.AvailableSearchLine.Text = "_________________________________";
            this.AvailableSearchLine.Visible = false;
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
            // Sched_AssignGuards
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(721, 666);
            this.ControlBox = false;
            this.Controls.Add(this.AssignedLBL);
            this.Controls.Add(this.CloseBTN);
            this.Controls.Add(this.ConfirmBTN);
            this.Controls.Add(this.AvailableLBL);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.AssignedPNL);
            this.Controls.Add(this.AvailablePNL);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Sched_AssignGuards";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.Sched_AssignGuards_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AvailableGRD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AssignedGRD)).EndInit();
            this.AvailablePNL.ResumeLayout(false);
            this.AvailablePNL.PerformLayout();
            this.AssignedPNL.ResumeLayout(false);
            this.AssignedPNL.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.TextBox SArchiveSearchTXTBX;
        private System.Windows.Forms.Label SArchiveSearchLine;
        private System.Windows.Forms.TextBox AvailableSearchBX;
        private System.Windows.Forms.Label AvailableSearchLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn nGID;
        private System.Windows.Forms.DataGridViewTextBoxColumn nName;
        private System.Windows.Forms.DataGridViewTextBoxColumn nLocation;
    }
}