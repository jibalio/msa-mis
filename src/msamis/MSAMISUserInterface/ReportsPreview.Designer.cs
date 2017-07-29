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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TimeLBL = new System.Windows.Forms.Label();
            this.NameLBL = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CloseBTN = new System.Windows.Forms.Button();
            this.FadeTMR = new System.Windows.Forms.Timer(this.components);
            this.GReportGRD = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
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
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle7.NullValue = "-";
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GReportGRD.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.GReportGRD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GReportGRD.DefaultCellStyle = dataGridViewCellStyle8;
            this.GReportGRD.EnableHeadersVisualStyles = false;
            this.GReportGRD.Location = new System.Drawing.Point(0, 106);
            this.GReportGRD.Name = "GReportGRD";
            this.GReportGRD.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GReportGRD.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.GReportGRD.RowHeadersVisible = false;
            this.GReportGRD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GReportGRD.Size = new System.Drawing.Size(898, 433);
            this.GReportGRD.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.button1.BackgroundImage = global::MSAMISUserInterface.Properties.Resources.Button;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(87)))), ((int)(((byte)(145)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(774, 554);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 32);
            this.button1.TabIndex = 18;
            this.button1.Text = "EXPORT";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GuardsReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(898, 598);
            this.ControlBox = false;
            this.Controls.Add(this.GReportGRD);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GuardsReport";
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
        private System.Windows.Forms.Button button1;
    }
}