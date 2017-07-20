namespace MSAMISUserInterface {
    partial class Payroll_ConfHolidays {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Payroll_ConfHolidays));
            this.label2 = new System.Windows.Forms.Label();
            this.HoldaysCLNDR = new System.Windows.Forms.MonthCalendar();
            this.HolidaysGRD = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.DescBX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DateLBL = new System.Windows.Forms.Label();
            this.CloseBTN = new System.Windows.Forms.Button();
            this.FadeTMR = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.RemoveBTN = new System.Windows.Forms.Button();
            this.EditBTN = new System.Windows.Forms.Button();
            this.CancelBTN = new System.Windows.Forms.Button();
            this.AddBTN = new System.Windows.Forms.Button();
            this.DescTLTP = new System.Windows.Forms.ToolTip(this.components);
            this.DateTLTP = new System.Windows.Forms.ToolTip(this.components);
            this.RegularBTN = new System.Windows.Forms.RadioButton();
            this.SpecialBTN = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.HolidaysGRD)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(13, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(569, 37);
            this.label2.TabIndex = 157;
            this.label2.Text = "Configure Holidays";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // HoldaysCLNDR
            // 
            this.HoldaysCLNDR.Location = new System.Drawing.Point(59, 143);
            this.HoldaysCLNDR.Name = "HoldaysCLNDR";
            this.HoldaysCLNDR.ShowTodayCircle = false;
            this.HoldaysCLNDR.TabIndex = 158;
            this.HoldaysCLNDR.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.HoldaysCLNDR_DateSelected);
            // 
            // HolidaysGRD
            // 
            this.HolidaysGRD.AllowUserToAddRows = false;
            this.HolidaysGRD.AllowUserToDeleteRows = false;
            this.HolidaysGRD.AllowUserToResizeColumns = false;
            this.HolidaysGRD.AllowUserToResizeRows = false;
            this.HolidaysGRD.BackgroundColor = System.Drawing.Color.White;
            this.HolidaysGRD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.HolidaysGRD.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.HolidaysGRD.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle1.NullValue = "-";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.HolidaysGRD.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.HolidaysGRD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.HolidaysGRD.DefaultCellStyle = dataGridViewCellStyle2;
            this.HolidaysGRD.EnableHeadersVisualStyles = false;
            this.HolidaysGRD.Location = new System.Drawing.Point(62, 325);
            this.HolidaysGRD.MultiSelect = false;
            this.HolidaysGRD.Name = "HolidaysGRD";
            this.HolidaysGRD.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.HolidaysGRD.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.HolidaysGRD.RowHeadersVisible = false;
            this.HolidaysGRD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.HolidaysGRD.ShowCellToolTips = false;
            this.HolidaysGRD.Size = new System.Drawing.Size(466, 180);
            this.HolidaysGRD.TabIndex = 157;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label1.Location = new System.Drawing.Point(310, 147);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 19);
            this.label1.TabIndex = 158;
            this.label1.Text = "Selected date";
            // 
            // DescBX
            // 
            this.DescBX.BackColor = System.Drawing.Color.White;
            this.DescBX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DescBX.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.DescBX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.DescBX.Location = new System.Drawing.Point(313, 249);
            this.DescBX.Name = "DescBX";
            this.DescBX.Size = new System.Drawing.Size(170, 18);
            this.DescBX.TabIndex = 160;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.ForeColor = System.Drawing.Color.LightGray;
            this.label4.Location = new System.Drawing.Point(311, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 13);
            this.label4.TabIndex = 162;
            this.label4.Text = "____________________________";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label5.Location = new System.Drawing.Point(310, 226);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 19);
            this.label5.TabIndex = 161;
            this.label5.Text = "Description";
            // 
            // DateLBL
            // 
            this.DateLBL.AutoSize = true;
            this.DateLBL.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.DateLBL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.DateLBL.Location = new System.Drawing.Point(310, 166);
            this.DateLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.DateLBL.Name = "DateLBL";
            this.DateLBL.Size = new System.Drawing.Size(174, 19);
            this.DateLBL.TabIndex = 163;
            this.DateLBL.Text = "Please choose a date/dates";
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
            this.CloseBTN.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.CloseBTN.ForeColor = System.Drawing.Color.White;
            this.CloseBTN.Location = new System.Drawing.Point(565, 0);
            this.CloseBTN.Name = "CloseBTN";
            this.CloseBTN.Size = new System.Drawing.Size(33, 29);
            this.CloseBTN.TabIndex = 165;
            this.CloseBTN.Text = "X";
            this.CloseBTN.UseVisualStyleBackColor = false;
            this.CloseBTN.Click += new System.EventHandler(this.CloseBTN_Click);
            // 
            // FadeTMR
            // 
            this.FadeTMR.Interval = 1;
            this.FadeTMR.Tick += new System.EventHandler(this.FadeTMR_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(607, 120);
            this.panel1.TabIndex = 168;
            // 
            // RemoveBTN
            // 
            this.RemoveBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.RemoveBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RemoveBTN.BackgroundImage")));
            this.RemoveBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RemoveBTN.FlatAppearance.BorderSize = 0;
            this.RemoveBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.RemoveBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(97)))), ((int)(((byte)(81)))));
            this.RemoveBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RemoveBTN.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.RemoveBTN.ForeColor = System.Drawing.Color.White;
            this.RemoveBTN.Location = new System.Drawing.Point(288, 533);
            this.RemoveBTN.Name = "RemoveBTN";
            this.RemoveBTN.Size = new System.Drawing.Size(80, 29);
            this.RemoveBTN.TabIndex = 169;
            this.RemoveBTN.Text = "REMOVE";
            this.RemoveBTN.UseVisualStyleBackColor = false;
            this.RemoveBTN.Click += new System.EventHandler(this.RemoveBTN_Click);
            // 
            // EditBTN
            // 
            this.EditBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.EditBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.EditBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EditBTN.BackgroundImage")));
            this.EditBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EditBTN.FlatAppearance.BorderSize = 0;
            this.EditBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(47)))), ((int)(((byte)(61)))));
            this.EditBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            this.EditBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditBTN.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.EditBTN.ForeColor = System.Drawing.Color.White;
            this.EditBTN.Location = new System.Drawing.Point(202, 533);
            this.EditBTN.Name = "EditBTN";
            this.EditBTN.Size = new System.Drawing.Size(80, 29);
            this.EditBTN.TabIndex = 167;
            this.EditBTN.Text = "EDIT";
            this.EditBTN.UseVisualStyleBackColor = false;
            this.EditBTN.Click += new System.EventHandler(this.EditBTN_Click);
            // 
            // CancelBTN
            // 
            this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.CancelBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CancelBTN.BackgroundImage")));
            this.CancelBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelBTN.FlatAppearance.BorderSize = 0;
            this.CancelBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.CancelBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(97)))), ((int)(((byte)(81)))));
            this.CancelBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelBTN.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.CancelBTN.ForeColor = System.Drawing.Color.White;
            this.CancelBTN.Location = new System.Drawing.Point(379, 280);
            this.CancelBTN.Name = "CancelBTN";
            this.CancelBTN.Size = new System.Drawing.Size(60, 22);
            this.CancelBTN.TabIndex = 166;
            this.CancelBTN.Text = "CANCEL";
            this.CancelBTN.UseVisualStyleBackColor = false;
            this.CancelBTN.Visible = false;
            this.CancelBTN.Click += new System.EventHandler(this.CancelBTN_Click);
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
            this.AddBTN.Location = new System.Drawing.Point(313, 280);
            this.AddBTN.Name = "AddBTN";
            this.AddBTN.Size = new System.Drawing.Size(60, 22);
            this.AddBTN.TabIndex = 164;
            this.AddBTN.Text = "ADD";
            this.AddBTN.UseVisualStyleBackColor = false;
            this.AddBTN.Click += new System.EventHandler(this.AddBTN_Click);
            // 
            // DescTLTP
            // 
            this.DescTLTP.AutoPopDelay = 3000;
            this.DescTLTP.InitialDelay = 500;
            this.DescTLTP.ReshowDelay = 100;
            this.DescTLTP.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            // 
            // DateTLTP
            // 
            this.DateTLTP.AutoPopDelay = 3000;
            this.DateTLTP.InitialDelay = 500;
            this.DateTLTP.ReshowDelay = 100;
            this.DateTLTP.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            // 
            // RegularBTN
            // 
            this.RegularBTN.AutoSize = true;
            this.RegularBTN.Font = new System.Drawing.Font("Segoe UI Semilight", 9F);
            this.RegularBTN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.RegularBTN.Location = new System.Drawing.Point(314, 197);
            this.RegularBTN.Name = "RegularBTN";
            this.RegularBTN.Size = new System.Drawing.Size(65, 19);
            this.RegularBTN.TabIndex = 170;
            this.RegularBTN.TabStop = true;
            this.RegularBTN.Text = "Regular";
            this.RegularBTN.UseVisualStyleBackColor = true;
            // 
            // SpecialBTN
            // 
            this.SpecialBTN.AutoSize = true;
            this.SpecialBTN.Font = new System.Drawing.Font("Segoe UI Semilight", 9F);
            this.SpecialBTN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.SpecialBTN.Location = new System.Drawing.Point(395, 197);
            this.SpecialBTN.Name = "SpecialBTN";
            this.SpecialBTN.Size = new System.Drawing.Size(61, 19);
            this.SpecialBTN.TabIndex = 171;
            this.SpecialBTN.TabStop = true;
            this.SpecialBTN.Text = "Special";
            this.SpecialBTN.UseVisualStyleBackColor = true;
            // 
            // Payroll_ConfHolidays
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(598, 598);
            this.ControlBox = false;
            this.Controls.Add(this.SpecialBTN);
            this.Controls.Add(this.RegularBTN);
            this.Controls.Add(this.RemoveBTN);
            this.Controls.Add(this.EditBTN);
            this.Controls.Add(this.CancelBTN);
            this.Controls.Add(this.CloseBTN);
            this.Controls.Add(this.AddBTN);
            this.Controls.Add(this.DateLBL);
            this.Controls.Add(this.DescBX);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.HolidaysGRD);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HoldaysCLNDR);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Payroll_ConfHolidays";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Payroll_ConfHolidays_FormClosing);
            this.Load += new System.EventHandler(this.Sched_ConfHolidays_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HolidaysGRD)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MonthCalendar HoldaysCLNDR;
        private System.Windows.Forms.DataGridView HolidaysGRD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox DescBX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label DateLBL;
        private System.Windows.Forms.Button AddBTN;
        private System.Windows.Forms.Button CloseBTN;
        private System.Windows.Forms.Timer FadeTMR;
        private System.Windows.Forms.Button CancelBTN;
        private System.Windows.Forms.Button EditBTN;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button RemoveBTN;
        private System.Windows.Forms.ToolTip DescTLTP;
        private System.Windows.Forms.ToolTip DateTLTP;
        private System.Windows.Forms.RadioButton RegularBTN;
        private System.Windows.Forms.RadioButton SpecialBTN;
    }
}