namespace MSAMISUserInterface {
    partial class ReportsForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportsForm));
            this.ClientsReportPNL = new System.Windows.Forms.Panel();
            this.CExportToPDFBTN = new System.Windows.Forms.Button();
            this.CTotalActiveLBL = new System.Windows.Forms.Label();
            this.CTotalLBL = new System.Windows.Forms.Label();
            this.CSummaryDateLBL = new System.Windows.Forms.Label();
            this.ClientsSummaryTBL = new System.Windows.Forms.DataGridView();
            this.ExportClientsSummaryBTN = new System.Windows.Forms.Button();
            this.label43 = new System.Windows.Forms.Label();
            this.GuardsReportPNL = new System.Windows.Forms.Panel();
            this.GTotalActiveLBL = new System.Windows.Forms.Label();
            this.GTotalLBL = new System.Windows.Forms.Label();
            this.GuardsSummaryTBL = new System.Windows.Forms.DataGridView();
            this.GSummaryDateLBL = new System.Windows.Forms.Label();
            this.ExportGuardsSummaryBTN = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.ClientsReportPNL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClientsSummaryTBL)).BeginInit();
            this.GuardsReportPNL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GuardsSummaryTBL)).BeginInit();
            this.SuspendLayout();
            // 
            // ClientsReportPNL
            // 
            this.ClientsReportPNL.Controls.Add(this.CExportToPDFBTN);
            this.ClientsReportPNL.Controls.Add(this.CTotalActiveLBL);
            this.ClientsReportPNL.Controls.Add(this.CTotalLBL);
            this.ClientsReportPNL.Controls.Add(this.CSummaryDateLBL);
            this.ClientsReportPNL.Controls.Add(this.ClientsSummaryTBL);
            this.ClientsReportPNL.Controls.Add(this.ExportClientsSummaryBTN);
            this.ClientsReportPNL.Controls.Add(this.label43);
            this.ClientsReportPNL.Location = new System.Drawing.Point(12, 12);
            this.ClientsReportPNL.Name = "ClientsReportPNL";
            this.ClientsReportPNL.Size = new System.Drawing.Size(690, 640);
            this.ClientsReportPNL.TabIndex = 21;
            // 
            // CExportToPDFBTN
            // 
            this.CExportToPDFBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.CExportToPDFBTN.BackgroundImage = global::MSAMISUserInterface.Properties.Resources.Button;
            this.CExportToPDFBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CExportToPDFBTN.FlatAppearance.BorderSize = 0;
            this.CExportToPDFBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(87)))), ((int)(((byte)(145)))));
            this.CExportToPDFBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CExportToPDFBTN.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CExportToPDFBTN.ForeColor = System.Drawing.Color.White;
            this.CExportToPDFBTN.Location = new System.Drawing.Point(548, 591);
            this.CExportToPDFBTN.Name = "CExportToPDFBTN";
            this.CExportToPDFBTN.Size = new System.Drawing.Size(112, 46);
            this.CExportToPDFBTN.TabIndex = 22;
            this.CExportToPDFBTN.Text = "EXPORT TO PDF";
            this.CExportToPDFBTN.UseVisualStyleBackColor = false;
            this.CExportToPDFBTN.Click += new System.EventHandler(this.CExportToPDFBTN_Click);
            // 
            // CTotalActiveLBL
            // 
            this.CTotalActiveLBL.AutoSize = true;
            this.CTotalActiveLBL.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.CTotalActiveLBL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.CTotalActiveLBL.Location = new System.Drawing.Point(427, 90);
            this.CTotalActiveLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CTotalActiveLBL.Name = "CTotalActiveLBL";
            this.CTotalActiveLBL.Size = new System.Drawing.Size(124, 19);
            this.CTotalActiveLBL.TabIndex = 21;
            this.CTotalActiveLBL.Text = "Total Active Clients:";
            // 
            // CTotalLBL
            // 
            this.CTotalLBL.AutoSize = true;
            this.CTotalLBL.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.CTotalLBL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.CTotalLBL.Location = new System.Drawing.Point(427, 58);
            this.CTotalLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CTotalLBL.Name = "CTotalLBL";
            this.CTotalLBL.Size = new System.Drawing.Size(84, 19);
            this.CTotalLBL.TabIndex = 20;
            this.CTotalLBL.Text = "Total Clients:";
            // 
            // CSummaryDateLBL
            // 
            this.CSummaryDateLBL.AutoSize = true;
            this.CSummaryDateLBL.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.CSummaryDateLBL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.CSummaryDateLBL.Location = new System.Drawing.Point(31, 58);
            this.CSummaryDateLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CSummaryDateLBL.Name = "CSummaryDateLBL";
            this.CSummaryDateLBL.Size = new System.Drawing.Size(165, 19);
            this.CSummaryDateLBL.TabIndex = 19;
            this.CSummaryDateLBL.Text = "Summary as of 01/01/2017";
            // 
            // ClientsSummaryTBL
            // 
            this.ClientsSummaryTBL.AllowUserToAddRows = false;
            this.ClientsSummaryTBL.AllowUserToDeleteRows = false;
            this.ClientsSummaryTBL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ClientsSummaryTBL.Location = new System.Drawing.Point(18, 122);
            this.ClientsSummaryTBL.Name = "ClientsSummaryTBL";
            this.ClientsSummaryTBL.ReadOnly = true;
            this.ClientsSummaryTBL.Size = new System.Drawing.Size(652, 463);
            this.ClientsSummaryTBL.TabIndex = 16;
            // 
            // ExportClientsSummaryBTN
            // 
            this.ExportClientsSummaryBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.ExportClientsSummaryBTN.BackgroundImage = global::MSAMISUserInterface.Properties.Resources.Button;
            this.ExportClientsSummaryBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ExportClientsSummaryBTN.FlatAppearance.BorderSize = 0;
            this.ExportClientsSummaryBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(87)))), ((int)(((byte)(145)))));
            this.ExportClientsSummaryBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExportClientsSummaryBTN.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExportClientsSummaryBTN.ForeColor = System.Drawing.Color.White;
            this.ExportClientsSummaryBTN.Location = new System.Drawing.Point(287, 589);
            this.ExportClientsSummaryBTN.Name = "ExportClientsSummaryBTN";
            this.ExportClientsSummaryBTN.Size = new System.Drawing.Size(112, 51);
            this.ExportClientsSummaryBTN.TabIndex = 6;
            this.ExportClientsSummaryBTN.Text = "EXPORT ALL REPORTS";
            this.ExportClientsSummaryBTN.UseVisualStyleBackColor = false;
            this.ExportClientsSummaryBTN.Click += new System.EventHandler(this.ExportClientsSummaryBTN_Click);
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Segoe UI Light", 28F);
            this.label43.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label43.Location = new System.Drawing.Point(14, 4);
            this.label43.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(245, 51);
            this.label43.TabIndex = 4;
            this.label43.Text = "Clients Report";
            this.label43.Click += new System.EventHandler(this.label43_Click);
            // 
            // GuardsReportPNL
            // 
            this.GuardsReportPNL.Controls.Add(this.GTotalActiveLBL);
            this.GuardsReportPNL.Controls.Add(this.GTotalLBL);
            this.GuardsReportPNL.Controls.Add(this.GuardsSummaryTBL);
            this.GuardsReportPNL.Controls.Add(this.GSummaryDateLBL);
            this.GuardsReportPNL.Controls.Add(this.ExportGuardsSummaryBTN);
            this.GuardsReportPNL.Controls.Add(this.label2);
            this.GuardsReportPNL.Location = new System.Drawing.Point(12, 12);
            this.GuardsReportPNL.Name = "GuardsReportPNL";
            this.GuardsReportPNL.Size = new System.Drawing.Size(690, 640);
            this.GuardsReportPNL.TabIndex = 22;
            // 
            // GTotalActiveLBL
            // 
            this.GTotalActiveLBL.AutoSize = true;
            this.GTotalActiveLBL.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.GTotalActiveLBL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.GTotalActiveLBL.Location = new System.Drawing.Point(427, 90);
            this.GTotalActiveLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.GTotalActiveLBL.Name = "GTotalActiveLBL";
            this.GTotalActiveLBL.Size = new System.Drawing.Size(127, 19);
            this.GTotalActiveLBL.TabIndex = 18;
            this.GTotalActiveLBL.Text = "Total Active Guards:";
            // 
            // GTotalLBL
            // 
            this.GTotalLBL.AutoSize = true;
            this.GTotalLBL.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.GTotalLBL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.GTotalLBL.Location = new System.Drawing.Point(427, 58);
            this.GTotalLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.GTotalLBL.Name = "GTotalLBL";
            this.GTotalLBL.Size = new System.Drawing.Size(87, 19);
            this.GTotalLBL.TabIndex = 17;
            this.GTotalLBL.Text = "Total Guards:";
            // 
            // GuardsSummaryTBL
            // 
            this.GuardsSummaryTBL.AllowUserToAddRows = false;
            this.GuardsSummaryTBL.AllowUserToDeleteRows = false;
            this.GuardsSummaryTBL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GuardsSummaryTBL.Location = new System.Drawing.Point(18, 122);
            this.GuardsSummaryTBL.Name = "GuardsSummaryTBL";
            this.GuardsSummaryTBL.ReadOnly = true;
            this.GuardsSummaryTBL.Size = new System.Drawing.Size(652, 463);
            this.GuardsSummaryTBL.TabIndex = 16;
            // 
            // GSummaryDateLBL
            // 
            this.GSummaryDateLBL.AutoSize = true;
            this.GSummaryDateLBL.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.GSummaryDateLBL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.GSummaryDateLBL.Location = new System.Drawing.Point(31, 58);
            this.GSummaryDateLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.GSummaryDateLBL.Name = "GSummaryDateLBL";
            this.GSummaryDateLBL.Size = new System.Drawing.Size(165, 19);
            this.GSummaryDateLBL.TabIndex = 15;
            this.GSummaryDateLBL.Text = "Summary as of 01/01/2017";
            // 
            // ExportGuardsSummaryBTN
            // 
            this.ExportGuardsSummaryBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.ExportGuardsSummaryBTN.BackgroundImage = global::MSAMISUserInterface.Properties.Resources.Button;
            this.ExportGuardsSummaryBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ExportGuardsSummaryBTN.FlatAppearance.BorderSize = 0;
            this.ExportGuardsSummaryBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(87)))), ((int)(((byte)(145)))));
            this.ExportGuardsSummaryBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExportGuardsSummaryBTN.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExportGuardsSummaryBTN.ForeColor = System.Drawing.Color.White;
            this.ExportGuardsSummaryBTN.Location = new System.Drawing.Point(287, 594);
            this.ExportGuardsSummaryBTN.Name = "ExportGuardsSummaryBTN";
            this.ExportGuardsSummaryBTN.Size = new System.Drawing.Size(112, 32);
            this.ExportGuardsSummaryBTN.TabIndex = 6;
            this.ExportGuardsSummaryBTN.Text = "EXPORT";
            this.ExportGuardsSummaryBTN.UseVisualStyleBackColor = false;
            this.ExportGuardsSummaryBTN.Click += new System.EventHandler(this.ExportGuardsSummaryBTN_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Light", 28F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label2.Location = new System.Drawing.Point(13, 4);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(252, 51);
            this.label2.TabIndex = 4;
            this.label2.Text = "Guards Report";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 669);
            this.Controls.Add(this.ClientsReportPNL);
            this.Controls.Add(this.GuardsReportPNL);
            this.Name = "ReportsForm";
            this.Text = resources.GetString("$this.Text");
            this.Load += new System.EventHandler(this.ReportsForm_Load);
            this.ClientsReportPNL.ResumeLayout(false);
            this.ClientsReportPNL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClientsSummaryTBL)).EndInit();
            this.GuardsReportPNL.ResumeLayout(false);
            this.GuardsReportPNL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GuardsSummaryTBL)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ClientsReportPNL;
        private System.Windows.Forms.Button ExportClientsSummaryBTN;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Panel GuardsReportPNL;
        private System.Windows.Forms.Label GSummaryDateLBL;
        private System.Windows.Forms.Button ExportGuardsSummaryBTN;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DataGridView ClientsSummaryTBL;
        public System.Windows.Forms.DataGridView GuardsSummaryTBL;
        private System.Windows.Forms.Label GTotalActiveLBL;
        private System.Windows.Forms.Label GTotalLBL;
        private System.Windows.Forms.Label CTotalActiveLBL;
        private System.Windows.Forms.Label CTotalLBL;
        private System.Windows.Forms.Label CSummaryDateLBL;
        private System.Windows.Forms.Button CExportToPDFBTN;
    }
}