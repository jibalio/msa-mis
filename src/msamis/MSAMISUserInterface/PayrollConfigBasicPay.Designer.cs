namespace MSAMISUserInterface {
    partial class PayrollConfigBasicPay {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PayrollConfigBasicPay));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CloseBTN = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.FadeTMR = new System.Windows.Forms.Timer(this.components);
            this.AdjustPNL = new System.Windows.Forms.Panel();
            this.CancelBTN = new System.Windows.Forms.Button();
            this.SaveBTN = new System.Windows.Forms.Button();
            this.StartDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.AdjustMBX = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BasicPayGRD = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.CurrentPNL = new System.Windows.Forms.Panel();
            this.AdjustBTN = new System.Windows.Forms.Button();
            this.CBasicPay = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.InputTLTP = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.AdjustPNL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BasicPayGRD)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.CurrentPNL.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.panel1.Controls.Add(this.CloseBTN);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(607, 120);
            this.panel1.TabIndex = 169;
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
            this.CloseBTN.Location = new System.Drawing.Point(567, 0);
            this.CloseBTN.Name = "CloseBTN";
            this.CloseBTN.Size = new System.Drawing.Size(33, 29);
            this.CloseBTN.TabIndex = 170;
            this.CloseBTN.Text = "X";
            this.CloseBTN.UseVisualStyleBackColor = false;
            this.CloseBTN.Click += new System.EventHandler(this.CloseBTN_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(9, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(578, 37);
            this.label2.TabIndex = 157;
            this.label2.Text = "Configure Basic Pay";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FadeTMR
            // 
            this.FadeTMR.Interval = 1;
            this.FadeTMR.Tick += new System.EventHandler(this.FadeTMR_Tick);
            // 
            // AdjustPNL
            // 
            this.AdjustPNL.Controls.Add(this.CancelBTN);
            this.AdjustPNL.Controls.Add(this.SaveBTN);
            this.AdjustPNL.Controls.Add(this.StartDate);
            this.AdjustPNL.Controls.Add(this.label1);
            this.AdjustPNL.Controls.Add(this.AdjustMBX);
            this.AdjustPNL.Location = new System.Drawing.Point(3, 94);
            this.AdjustPNL.Name = "AdjustPNL";
            this.AdjustPNL.Size = new System.Drawing.Size(547, 145);
            this.AdjustPNL.TabIndex = 237;
            this.AdjustPNL.Visible = false;
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
            this.CancelBTN.Location = new System.Drawing.Point(277, 110);
            this.CancelBTN.Name = "CancelBTN";
            this.CancelBTN.Size = new System.Drawing.Size(71, 25);
            this.CancelBTN.TabIndex = 239;
            this.CancelBTN.Text = "CANCEL";
            this.CancelBTN.UseVisualStyleBackColor = false;
            this.CancelBTN.Click += new System.EventHandler(this.CancelBTN_Click);
            // 
            // SaveBTN
            // 
            this.SaveBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.SaveBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SaveBTN.BackgroundImage")));
            this.SaveBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SaveBTN.FlatAppearance.BorderSize = 0;
            this.SaveBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(47)))), ((int)(((byte)(61)))));
            this.SaveBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            this.SaveBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveBTN.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.SaveBTN.ForeColor = System.Drawing.Color.White;
            this.SaveBTN.Location = new System.Drawing.Point(198, 111);
            this.SaveBTN.Name = "SaveBTN";
            this.SaveBTN.Size = new System.Drawing.Size(71, 25);
            this.SaveBTN.TabIndex = 236;
            this.SaveBTN.Text = "SAVE";
            this.SaveBTN.UseVisualStyleBackColor = false;
            this.SaveBTN.Click += new System.EventHandler(this.SaveBTN_Click);
            // 
            // StartDate
            // 
            this.StartDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.StartDate.Location = new System.Drawing.Point(266, 60);
            this.StartDate.Name = "StartDate";
            this.StartDate.Size = new System.Drawing.Size(125, 29);
            this.StartDate.TabIndex = 132;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label1.Location = new System.Drawing.Point(156, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 21);
            this.label1.TabIndex = 238;
            this.label1.Text = "Starting Date:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // AdjustMBX
            // 
            this.AdjustMBX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AdjustMBX.Dock = System.Windows.Forms.DockStyle.Top;
            this.AdjustMBX.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.AdjustMBX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.AdjustMBX.Location = new System.Drawing.Point(0, 0);
            this.AdjustMBX.Mask = "₱ 9 999.99";
            this.AdjustMBX.Name = "AdjustMBX";
            this.AdjustMBX.Size = new System.Drawing.Size(547, 43);
            this.AdjustMBX.TabIndex = 131;
            this.AdjustMBX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AdjustMBX.TextChanged += new System.EventHandler(this.AdjustMBX_TextChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label3.Location = new System.Drawing.Point(48, 144);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(491, 21);
            this.label3.TabIndex = 236;
            this.label3.Text = "Current Basic Pay";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // BasicPayGRD
            // 
            this.BasicPayGRD.AllowUserToAddRows = false;
            this.BasicPayGRD.AllowUserToDeleteRows = false;
            this.BasicPayGRD.AllowUserToResizeColumns = false;
            this.BasicPayGRD.AllowUserToResizeRows = false;
            this.BasicPayGRD.BackgroundColor = System.Drawing.Color.White;
            this.BasicPayGRD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.BasicPayGRD.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.BasicPayGRD.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle1.NullValue = "-";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.BasicPayGRD.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.BasicPayGRD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.BasicPayGRD.DefaultCellStyle = dataGridViewCellStyle2;
            this.BasicPayGRD.EnableHeadersVisualStyles = false;
            this.BasicPayGRD.Location = new System.Drawing.Point(39, 0);
            this.BasicPayGRD.MultiSelect = false;
            this.BasicPayGRD.Name = "BasicPayGRD";
            this.BasicPayGRD.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.BasicPayGRD.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.BasicPayGRD.RowHeadersVisible = false;
            this.BasicPayGRD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.BasicPayGRD.ShowCellToolTips = false;
            this.BasicPayGRD.Size = new System.Drawing.Size(500, 220);
            this.BasicPayGRD.TabIndex = 241;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label5.Location = new System.Drawing.Point(2, 242);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(551, 48);
            this.label5.TabIndex = 240;
            this.label5.Text = "Basic Pay History";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.CurrentPNL);
            this.flowLayoutPanel1.Controls.Add(this.AdjustPNL);
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(20, 173);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(547, 402);
            this.flowLayoutPanel1.TabIndex = 242;
            // 
            // CurrentPNL
            // 
            this.CurrentPNL.Controls.Add(this.AdjustBTN);
            this.CurrentPNL.Controls.Add(this.CBasicPay);
            this.CurrentPNL.Location = new System.Drawing.Point(3, 3);
            this.CurrentPNL.Name = "CurrentPNL";
            this.CurrentPNL.Size = new System.Drawing.Size(544, 85);
            this.CurrentPNL.TabIndex = 243;
            // 
            // AdjustBTN
            // 
            this.AdjustBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AdjustBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.AdjustBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AdjustBTN.BackgroundImage")));
            this.AdjustBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AdjustBTN.FlatAppearance.BorderSize = 0;
            this.AdjustBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(47)))), ((int)(((byte)(61)))));
            this.AdjustBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            this.AdjustBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AdjustBTN.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.AdjustBTN.ForeColor = System.Drawing.Color.White;
            this.AdjustBTN.Location = new System.Drawing.Point(240, 51);
            this.AdjustBTN.Name = "AdjustBTN";
            this.AdjustBTN.Size = new System.Drawing.Size(71, 25);
            this.AdjustBTN.TabIndex = 240;
            this.AdjustBTN.Text = "ADJUST";
            this.AdjustBTN.UseVisualStyleBackColor = false;
            this.AdjustBTN.Click += new System.EventHandler(this.AdjustBTN_Click);
            // 
            // CBasicPay
            // 
            this.CBasicPay.Dock = System.Windows.Forms.DockStyle.Top;
            this.CBasicPay.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.CBasicPay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.CBasicPay.Location = new System.Drawing.Point(0, 0);
            this.CBasicPay.Name = "CBasicPay";
            this.CBasicPay.Size = new System.Drawing.Size(544, 43);
            this.CBasicPay.TabIndex = 244;
            this.CBasicPay.Text = "label6";
            this.CBasicPay.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label4.Location = new System.Drawing.Point(2, 290);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(551, 20);
            this.label4.TabIndex = 243;
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BasicPayGRD);
            this.panel2.Location = new System.Drawing.Point(3, 313);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(544, 250);
            this.panel2.TabIndex = 245;
            // 
            // InputTLTP
            // 
            this.InputTLTP.AutoPopDelay = 3000;
            this.InputTLTP.InitialDelay = 500;
            this.InputTLTP.ReshowDelay = 100;
            this.InputTLTP.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            // 
            // PayrollConfigBasicPay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(598, 598);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PayrollConfigBasicPay";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Payroll_ConfigBasicPay_FormClosing);
            this.Load += new System.EventHandler(this.Payroll_ConfigBasicPay_Load);
            this.panel1.ResumeLayout(false);
            this.AdjustPNL.ResumeLayout(false);
            this.AdjustPNL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BasicPayGRD)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.CurrentPNL.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CloseBTN;
        private System.Windows.Forms.Timer FadeTMR;
        private System.Windows.Forms.Panel AdjustPNL;
        private System.Windows.Forms.DateTimePicker StartDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox AdjustMBX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SaveBTN;
        private System.Windows.Forms.Button AdjustBTN;
        private System.Windows.Forms.DataGridView BasicPayGRD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button CancelBTN;
        private System.Windows.Forms.Label CBasicPay;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel CurrentPNL;
        private System.Windows.Forms.ToolTip InputTLTP;
    }
}