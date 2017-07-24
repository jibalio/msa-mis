namespace MSAMISUserInterface {
    partial class PayrollConfigSss {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.RatesPNL = new System.Windows.Forms.Panel();
            this.CloseBTN = new System.Windows.Forms.Button();
            this.FadeTMR = new System.Windows.Forms.Timer(this.components);
            this.SSSGRD = new System.Windows.Forms.DataGridView();
            this.TaxPnl = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.TaxConLbl = new System.Windows.Forms.Label();
            this.TaxLbl = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.SSSPnl = new System.Windows.Forms.Panel();
            this.SSScon = new System.Windows.Forms.Label();
            this.SSSlbl = new System.Windows.Forms.Label();
            this.RatesPNL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SSSGRD)).BeginInit();
            this.TaxPnl.SuspendLayout();
            this.SSSPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // RatesPNL
            // 
            this.RatesPNL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.RatesPNL.Controls.Add(this.SSSPnl);
            this.RatesPNL.Controls.Add(this.label19);
            this.RatesPNL.Controls.Add(this.TaxPnl);
            this.RatesPNL.Location = new System.Drawing.Point(0, 0);
            this.RatesPNL.Name = "RatesPNL";
            this.RatesPNL.Size = new System.Drawing.Size(350, 600);
            this.RatesPNL.TabIndex = 170;
            // 
            // CloseBTN
            // 
            this.CloseBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBTN.BackColor = System.Drawing.Color.White;
            this.CloseBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CloseBTN.FlatAppearance.BorderSize = 0;
            this.CloseBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.CloseBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(97)))), ((int)(((byte)(81)))));
            this.CloseBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBTN.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold);
            this.CloseBTN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.CloseBTN.Location = new System.Drawing.Point(865, 0);
            this.CloseBTN.Name = "CloseBTN";
            this.CloseBTN.Size = new System.Drawing.Size(33, 29);
            this.CloseBTN.TabIndex = 170;
            this.CloseBTN.Text = "X";
            this.CloseBTN.UseVisualStyleBackColor = false;
            this.CloseBTN.Click += new System.EventHandler(this.CloseBTN_Click);
            this.CloseBTN.MouseEnter += new System.EventHandler(this.CloseBTN_MouseEnter);
            this.CloseBTN.MouseLeave += new System.EventHandler(this.CloseBTN_MouseLeave);
            // 
            // FadeTMR
            // 
            this.FadeTMR.Interval = 1;
            this.FadeTMR.Tick += new System.EventHandler(this.FadeTMR_Tick);
            // 
            // SSSGRD
            // 
            this.SSSGRD.AllowUserToAddRows = false;
            this.SSSGRD.AllowUserToDeleteRows = false;
            this.SSSGRD.AllowUserToResizeColumns = false;
            this.SSSGRD.AllowUserToResizeRows = false;
            this.SSSGRD.BackgroundColor = System.Drawing.Color.White;
            this.SSSGRD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SSSGRD.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.SSSGRD.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle4.NullValue = "-";
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SSSGRD.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.SSSGRD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SSSGRD.DefaultCellStyle = dataGridViewCellStyle5;
            this.SSSGRD.EnableHeadersVisualStyles = false;
            this.SSSGRD.Location = new System.Drawing.Point(409, 60);
            this.SSSGRD.MultiSelect = false;
            this.SSSGRD.Name = "SSSGRD";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SSSGRD.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.SSSGRD.RowHeadersVisible = false;
            this.SSSGRD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SSSGRD.ShowCellToolTips = false;
            this.SSSGRD.Size = new System.Drawing.Size(442, 421);
            this.SSSGRD.TabIndex = 171;
            // 
            // TaxPnl
            // 
            this.TaxPnl.Controls.Add(this.TaxConLbl);
            this.TaxPnl.Controls.Add(this.TaxLbl);
            this.TaxPnl.Location = new System.Drawing.Point(32, 285);
            this.TaxPnl.Name = "TaxPnl";
            this.TaxPnl.Size = new System.Drawing.Size(318, 90);
            this.TaxPnl.TabIndex = 283;
            this.TaxPnl.MouseEnter += new System.EventHandler(this.TaxPnl_MouseEnter);
            this.TaxPnl.MouseLeave += new System.EventHandler(this.TaxPnl_MouseLeave);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label12.Location = new System.Drawing.Point(655, 523);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(187, 25);
            this.label12.TabIndex = 281;
            this.label12.Text = "Admin";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label13.Location = new System.Drawing.Point(655, 503);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(187, 20);
            this.label13.TabIndex = 280;
            this.label13.Text = "Last Configured by";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TaxConLbl
            // 
            this.TaxConLbl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TaxConLbl.ForeColor = System.Drawing.Color.White;
            this.TaxConLbl.Location = new System.Drawing.Point(14, 52);
            this.TaxConLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TaxConLbl.Name = "TaxConLbl";
            this.TaxConLbl.Size = new System.Drawing.Size(251, 20);
            this.TaxConLbl.TabIndex = 279;
            this.TaxConLbl.Text = "Configure Tax Rates";
            this.TaxConLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TaxConLbl.MouseEnter += new System.EventHandler(this.TaxPnl_MouseEnter);
            this.TaxConLbl.MouseLeave += new System.EventHandler(this.TaxPnl_MouseLeave);
            // 
            // TaxLbl
            // 
            this.TaxLbl.BackColor = System.Drawing.Color.Transparent;
            this.TaxLbl.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.TaxLbl.ForeColor = System.Drawing.Color.White;
            this.TaxLbl.Location = new System.Drawing.Point(14, 15);
            this.TaxLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TaxLbl.Name = "TaxLbl";
            this.TaxLbl.Size = new System.Drawing.Size(259, 37);
            this.TaxLbl.TabIndex = 157;
            this.TaxLbl.Text = "Withholding Tax";
            this.TaxLbl.MouseEnter += new System.EventHandler(this.TaxPnl_MouseEnter);
            this.TaxLbl.MouseLeave += new System.EventHandler(this.TaxPnl_MouseLeave);
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label16.Location = new System.Drawing.Point(442, 523);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(209, 25);
            this.label16.TabIndex = 278;
            this.label16.Text = "January 31, 2018";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label17.Location = new System.Drawing.Point(442, 503);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(209, 20);
            this.label17.TabIndex = 277;
            this.label17.Text = "Last Configuration";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(47, 47);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(259, 37);
            this.label19.TabIndex = 157;
            this.label19.Text = "Configure Rates";
            // 
            // SSSPnl
            // 
            this.SSSPnl.Controls.Add(this.SSScon);
            this.SSSPnl.Controls.Add(this.SSSlbl);
            this.SSSPnl.Location = new System.Drawing.Point(32, 192);
            this.SSSPnl.Name = "SSSPnl";
            this.SSSPnl.Size = new System.Drawing.Size(318, 90);
            this.SSSPnl.TabIndex = 283;
            this.SSSPnl.MouseEnter += new System.EventHandler(this.SSSPnl_Enter);
            this.SSSPnl.MouseLeave += new System.EventHandler(this.SSSPnl_Leave);
            // 
            // SSScon
            // 
            this.SSScon.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.SSScon.ForeColor = System.Drawing.Color.White;
            this.SSScon.Location = new System.Drawing.Point(14, 53);
            this.SSScon.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SSScon.Name = "SSScon";
            this.SSScon.Size = new System.Drawing.Size(251, 20);
            this.SSScon.TabIndex = 279;
            this.SSScon.Text = "Configure SSS brackets";
            this.SSScon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SSScon.MouseEnter += new System.EventHandler(this.SSSPnl_Enter);
            this.SSScon.MouseLeave += new System.EventHandler(this.SSSPnl_Leave);
            // 
            // SSSlbl
            // 
            this.SSSlbl.BackColor = System.Drawing.Color.Transparent;
            this.SSSlbl.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.SSSlbl.ForeColor = System.Drawing.Color.White;
            this.SSSlbl.Location = new System.Drawing.Point(14, 17);
            this.SSSlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SSSlbl.Name = "SSSlbl";
            this.SSSlbl.Size = new System.Drawing.Size(259, 37);
            this.SSSlbl.TabIndex = 157;
            this.SSSlbl.Text = "SSS Benefit";
            this.SSSlbl.MouseEnter += new System.EventHandler(this.SSSPnl_Enter);
            this.SSSlbl.MouseLeave += new System.EventHandler(this.SSSPnl_Leave);
            // 
            // PayrollConfigSss
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(898, 598);
            this.ControlBox = false;
            this.Controls.Add(this.label12);
            this.Controls.Add(this.SSSGRD);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.RatesPNL);
            this.Controls.Add(this.CloseBTN);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PayrollConfigSss";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Payroll_ConfigSSS_FormClosing);
            this.Load += new System.EventHandler(this.Payroll_ConfigSSS_Load);
            this.RatesPNL.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SSSGRD)).EndInit();
            this.TaxPnl.ResumeLayout(false);
            this.SSSPnl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel RatesPNL;
        private System.Windows.Forms.Button CloseBTN;
        private System.Windows.Forms.Timer FadeTMR;
        private System.Windows.Forms.DataGridView SSSGRD;
        private System.Windows.Forms.Panel TaxPnl;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label TaxConLbl;
        private System.Windows.Forms.Label TaxLbl;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel SSSPnl;
        private System.Windows.Forms.Label SSScon;
        private System.Windows.Forms.Label SSSlbl;
        private System.Windows.Forms.Label label19;
    }
}