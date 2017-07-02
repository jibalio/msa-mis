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
            this.ConfirmBTN = new System.Windows.Forms.Button();
            this.CloseBTN = new System.Windows.Forms.Button();
            this.FadeTMR = new System.Windows.Forms.Timer(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.CertifiedBX = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.CertifiedTLTP = new System.Windows.Forms.ToolTip(this.components);
            this.ShiftTLTP = new System.Windows.Forms.ToolTip(this.components);
            this.SViewReqGRD = new System.Windows.Forms.DataGridView();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeInHr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeInMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeOutHr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeOutMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SViewReqGRD)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ClientLBL);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.NameLBL);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(1, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(718, 134);
            this.panel1.TabIndex = 123;
            // 
            // ClientLBL
            // 
            this.ClientLBL.Dock = System.Windows.Forms.DockStyle.Top;
            this.ClientLBL.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.ClientLBL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.ClientLBL.Location = new System.Drawing.Point(0, 104);
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
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label2.Location = new System.Drawing.Point(0, 78);
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
            this.NameLBL.Size = new System.Drawing.Size(718, 54);
            this.NameLBL.TabIndex = 118;
            this.NameLBL.Text = "Laboriki, Dodong Lab W.";
            this.NameLBL.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(718, 24);
            this.label4.TabIndex = 119;
            this.label4.Text = "DUTY DAYS FOR";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.ConfirmBTN.Location = new System.Drawing.Point(270, 600);
            this.ConfirmBTN.Name = "ConfirmBTN";
            this.ConfirmBTN.Size = new System.Drawing.Size(96, 32);
            this.ConfirmBTN.TabIndex = 140;
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
            this.CloseBTN.Location = new System.Drawing.Point(371, 600);
            this.CloseBTN.Name = "CloseBTN";
            this.CloseBTN.Size = new System.Drawing.Size(96, 32);
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label8.Location = new System.Drawing.Point(312, 501);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 21);
            this.label8.TabIndex = 151;
            this.label8.Text = "Certified by";
            // 
            // CertifiedBX
            // 
            this.CertifiedBX.BackColor = System.Drawing.Color.White;
            this.CertifiedBX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CertifiedBX.Font = new System.Drawing.Font("Segoe UI Semilight", 12F);
            this.CertifiedBX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.CertifiedBX.Location = new System.Drawing.Point(278, 529);
            this.CertifiedBX.Name = "CertifiedBX";
            this.CertifiedBX.Size = new System.Drawing.Size(170, 22);
            this.CertifiedBX.TabIndex = 152;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.BackColor = System.Drawing.Color.White;
            this.label34.ForeColor = System.Drawing.Color.LightGray;
            this.label34.Location = new System.Drawing.Point(273, 543);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(175, 13);
            this.label34.TabIndex = 153;
            this.label34.Text = "____________________________";
            // 
            // CertifiedTLTP
            // 
            this.CertifiedTLTP.AutoPopDelay = 3000;
            this.CertifiedTLTP.InitialDelay = 500;
            this.CertifiedTLTP.ReshowDelay = 100;
            this.CertifiedTLTP.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            // 
            // ShiftTLTP
            // 
            this.ShiftTLTP.AutoPopDelay = 3000;
            this.ShiftTLTP.InitialDelay = 500;
            this.ShiftTLTP.ReshowDelay = 100;
            this.ShiftTLTP.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            // 
            // SViewReqGRD
            // 
            this.SViewReqGRD.AllowUserToDeleteRows = false;
            this.SViewReqGRD.AllowUserToResizeColumns = false;
            this.SViewReqGRD.AllowUserToResizeRows = false;
            this.SViewReqGRD.BackgroundColor = System.Drawing.Color.White;
            this.SViewReqGRD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SViewReqGRD.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.SViewReqGRD.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle1.NullValue = "-";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SViewReqGRD.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.SViewReqGRD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.SViewReqGRD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.TimeInHr,
            this.TimeInMin,
            this.TimeOutHr,
            this.TimeOutMin});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SViewReqGRD.DefaultCellStyle = dataGridViewCellStyle2;
            this.SViewReqGRD.EnableHeadersVisualStyles = false;
            this.SViewReqGRD.Location = new System.Drawing.Point(116, 206);
            this.SViewReqGRD.MultiSelect = false;
            this.SViewReqGRD.Name = "SViewReqGRD";
            this.SViewReqGRD.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SViewReqGRD.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.SViewReqGRD.RowHeadersVisible = false;
            this.SViewReqGRD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.SViewReqGRD.Size = new System.Drawing.Size(504, 276);
            this.SViewReqGRD.TabIndex = 154;
            // 
            // Date
            // 
            this.Date.HeaderText = "DATE";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Date.Width = 200;
            // 
            // TimeInHr
            // 
            this.TimeInHr.HeaderText = "HR";
            this.TimeInHr.Name = "TimeInHr";
            this.TimeInHr.ReadOnly = true;
            this.TimeInHr.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TimeInHr.Width = 75;
            // 
            // TimeInMin
            // 
            this.TimeInMin.HeaderText = "MIN";
            this.TimeInMin.Name = "TimeInMin";
            this.TimeInMin.ReadOnly = true;
            this.TimeInMin.Width = 75;
            // 
            // TimeOutHr
            // 
            this.TimeOutHr.HeaderText = "HR";
            this.TimeOutHr.Name = "TimeOutHr";
            this.TimeOutHr.ReadOnly = true;
            this.TimeOutHr.Width = 75;
            // 
            // TimeOutMin
            // 
            this.TimeOutMin.HeaderText = "MIN";
            this.TimeOutMin.Name = "TimeOutMin";
            this.TimeOutMin.ReadOnly = true;
            this.TimeOutMin.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TimeOutMin.Width = 75;
            // 
            // Sched_AddDutyDays
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(721, 666);
            this.ControlBox = false;
            this.Controls.Add(this.SViewReqGRD);
            this.Controls.Add(this.CertifiedBX);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ConfirmBTN);
            this.Controls.Add(this.CloseBTN);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Sched_AddDutyDays";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.SAddDutyDays_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SViewReqGRD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label ClientLBL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label NameLBL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ConfirmBTN;
        private System.Windows.Forms.Button CloseBTN;
        private System.Windows.Forms.Timer FadeTMR;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox CertifiedBX;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.ToolTip CertifiedTLTP;
        private System.Windows.Forms.ToolTip ShiftTLTP;
        private System.Windows.Forms.DataGridView SViewReqGRD;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeInHr;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeInMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeOutHr;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeOutMin;
    }
}