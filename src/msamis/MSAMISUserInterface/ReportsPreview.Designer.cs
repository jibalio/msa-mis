namespace MSAMISUserInterface {
    partial class ReportsPreview {
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.CloseBTN = new System.Windows.Forms.Button();
            this.TimeLBL = new System.Windows.Forms.Label();
            this.NameLBL = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FadeTMR = new System.Windows.Forms.Timer(this.components);
            this.GReportGRD = new System.Windows.Forms.DataGridView();
            this.PayslipSaveTo = new System.Windows.Forms.Button();
            this.ApproveLBL = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GReportGRD)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.panel1.Controls.Add(this.CloseBTN);
            this.panel1.Controls.Add(this.TimeLBL);
            this.panel1.Controls.Add(this.NameLBL);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(898, 107);
            this.panel1.TabIndex = 1;
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
            this.CloseBTN.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseBTN.ForeColor = System.Drawing.Color.White;
            this.CloseBTN.Location = new System.Drawing.Point(866, 0);
            this.CloseBTN.Name = "CloseBTN";
            this.CloseBTN.Size = new System.Drawing.Size(32, 32);
            this.CloseBTN.TabIndex = 237;
            this.CloseBTN.Text = "X";
            this.CloseBTN.UseVisualStyleBackColor = false;
            this.CloseBTN.Click += new System.EventHandler(this.CloseBTN_Click);
            // 
            // TimeLBL
            // 
            this.TimeLBL.Dock = System.Windows.Forms.DockStyle.Top;
            this.TimeLBL.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.TimeLBL.ForeColor = System.Drawing.Color.White;
            this.TimeLBL.Location = new System.Drawing.Point(0, 63);
            this.TimeLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TimeLBL.Name = "TimeLBL";
            this.TimeLBL.Size = new System.Drawing.Size(898, 24);
            this.TimeLBL.TabIndex = 121;
            this.TimeLBL.Text = "Management Information System";
            this.TimeLBL.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // NameLBL
            // 
            this.NameLBL.Dock = System.Windows.Forms.DockStyle.Top;
            this.NameLBL.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.NameLBL.ForeColor = System.Drawing.Color.White;
            this.NameLBL.Location = new System.Drawing.Point(0, 20);
            this.NameLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NameLBL.Name = "NameLBL";
            this.NameLBL.Size = new System.Drawing.Size(898, 43);
            this.NameLBL.TabIndex = 120;
            this.NameLBL.Text = "Guards Summary";
            this.NameLBL.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(898, 20);
            this.label1.TabIndex = 122;
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FadeTMR
            // 
            this.FadeTMR.Interval = 1;
            this.FadeTMR.Tick += new System.EventHandler(this.FadeTMR_Tick);
            // 
            // GReportGRD
            // 
            this.GReportGRD.AllowUserToAddRows = false;
            this.GReportGRD.AllowUserToDeleteRows = false;
            this.GReportGRD.AllowUserToResizeColumns = false;
            this.GReportGRD.AllowUserToResizeRows = false;
            this.GReportGRD.BackgroundColor = System.Drawing.Color.White;
            this.GReportGRD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GReportGRD.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle4.NullValue = "-";
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GReportGRD.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.GReportGRD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GReportGRD.DefaultCellStyle = dataGridViewCellStyle5;
            this.GReportGRD.EnableHeadersVisualStyles = false;
            this.GReportGRD.Location = new System.Drawing.Point(0, 106);
            this.GReportGRD.Name = "GReportGRD";
            this.GReportGRD.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GReportGRD.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.GReportGRD.RowHeadersVisible = false;
            this.GReportGRD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GReportGRD.Size = new System.Drawing.Size(898, 493);
            this.GReportGRD.TabIndex = 7;
            // 
            // PayslipSaveTo
            // 
            this.PayslipSaveTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PayslipSaveTo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.PayslipSaveTo.BackgroundImage = global::MSAMISUserInterface.Properties.Resources.Button;
            this.PayslipSaveTo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PayslipSaveTo.FlatAppearance.BorderSize = 0;
            this.PayslipSaveTo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(47)))), ((int)(((byte)(61)))));
            this.PayslipSaveTo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            this.PayslipSaveTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PayslipSaveTo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PayslipSaveTo.ForeColor = System.Drawing.Color.White;
            this.PayslipSaveTo.Location = new System.Drawing.Point(378, 526);
            this.PayslipSaveTo.Name = "PayslipSaveTo";
            this.PayslipSaveTo.Size = new System.Drawing.Size(131, 32);
            this.PayslipSaveTo.TabIndex = 19;
            this.PayslipSaveTo.Text = "SAVE TO";
            this.PayslipSaveTo.UseVisualStyleBackColor = false;
            this.PayslipSaveTo.Visible = false;
            this.PayslipSaveTo.Click += new System.EventHandler(this.PayslipSaveTo_Click);
            // 
            // ApproveLBL
            // 
            this.ApproveLBL.BackColor = System.Drawing.Color.Transparent;
            this.ApproveLBL.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.ApproveLBL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.ApproveLBL.Location = new System.Drawing.Point(322, 494);
            this.ApproveLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ApproveLBL.Name = "ApproveLBL";
            this.ApproveLBL.Size = new System.Drawing.Size(252, 19);
            this.ApproveLBL.TabIndex = 244;
            this.ApproveLBL.Text = "Net Pay:";
            this.ApproveLBL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ReportsPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(898, 598);
            this.ControlBox = false;
            this.Controls.Add(this.ApproveLBL);
            this.Controls.Add(this.PayslipSaveTo);
            this.Controls.Add(this.GReportGRD);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ReportsPreview";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GuardsReport_FormClosing);
            this.Load += new System.EventHandler(this.GuardsReport_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GReportGRD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label TimeLBL;
        private System.Windows.Forms.Label NameLBL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CloseBTN;
        private System.Windows.Forms.Timer FadeTMR;
        private System.Windows.Forms.DataGridView GReportGRD;
        private System.Windows.Forms.Button PayslipSaveTo;
        private System.Windows.Forms.Label ApproveLBL;
    }
}