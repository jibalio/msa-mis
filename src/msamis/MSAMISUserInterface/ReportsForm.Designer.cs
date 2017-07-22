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
            this.ClientsSummaryTBL = new System.Windows.Forms.DataGridView();
            this.label42 = new System.Windows.Forms.Label();
            this.ExportClientsSummaryBTN = new System.Windows.Forms.Button();
            this.label43 = new System.Windows.Forms.Label();
            this.GuardsReportPNL = new System.Windows.Forms.Panel();
            this.GuardsSummaryTBL = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
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
            this.ClientsReportPNL.Controls.Add(this.ClientsSummaryTBL);
            this.ClientsReportPNL.Controls.Add(this.label42);
            this.ClientsReportPNL.Controls.Add(this.ExportClientsSummaryBTN);
            this.ClientsReportPNL.Controls.Add(this.label43);
            this.ClientsReportPNL.Location = new System.Drawing.Point(12, 12);
            this.ClientsReportPNL.Name = "ClientsReportPNL";
            this.ClientsReportPNL.Size = new System.Drawing.Size(690, 640);
            this.ClientsReportPNL.TabIndex = 21;
            // 
            // ClientsSummaryTBL
            // 
            this.ClientsSummaryTBL.AllowUserToAddRows = false;
            this.ClientsSummaryTBL.AllowUserToDeleteRows = false;
            this.ClientsSummaryTBL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ClientsSummaryTBL.Location = new System.Drawing.Point(18, 109);
            this.ClientsSummaryTBL.Name = "ClientsSummaryTBL";
            this.ClientsSummaryTBL.ReadOnly = true;
            this.ClientsSummaryTBL.Size = new System.Drawing.Size(652, 476);
            this.ClientsSummaryTBL.TabIndex = 16;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.label42.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label42.Location = new System.Drawing.Point(19, 71);
            this.label42.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(165, 19);
            this.label42.TabIndex = 15;
            this.label42.Text = "Summary as of 01/01/2017";
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
            this.ExportClientsSummaryBTN.Location = new System.Drawing.Point(287, 594);
            this.ExportClientsSummaryBTN.Name = "ExportClientsSummaryBTN";
            this.ExportClientsSummaryBTN.Size = new System.Drawing.Size(112, 32);
            this.ExportClientsSummaryBTN.TabIndex = 6;
            this.ExportClientsSummaryBTN.Text = "EXPORT";
            this.ExportClientsSummaryBTN.UseVisualStyleBackColor = false;
            this.ExportClientsSummaryBTN.Click += new System.EventHandler(this.ExportClientsSummaryBTN_Click);
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Segoe UI Light", 28F);
            this.label43.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label43.Location = new System.Drawing.Point(14, 9);
            this.label43.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(245, 51);
            this.label43.TabIndex = 4;
            this.label43.Text = "Clients Report";
            this.label43.Click += new System.EventHandler(this.label43_Click);
            // 
            // GuardsReportPNL
            // 
            this.GuardsReportPNL.Controls.Add(this.GuardsSummaryTBL);
            this.GuardsReportPNL.Controls.Add(this.label1);
            this.GuardsReportPNL.Controls.Add(this.ExportGuardsSummaryBTN);
            this.GuardsReportPNL.Controls.Add(this.label2);
            this.GuardsReportPNL.Location = new System.Drawing.Point(12, 12);
            this.GuardsReportPNL.Name = "GuardsReportPNL";
            this.GuardsReportPNL.Size = new System.Drawing.Size(690, 640);
            this.GuardsReportPNL.TabIndex = 22;
            // 
            // GuardsSummaryTBL
            // 
            this.GuardsSummaryTBL.AllowUserToAddRows = false;
            this.GuardsSummaryTBL.AllowUserToDeleteRows = false;
            this.GuardsSummaryTBL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GuardsSummaryTBL.Location = new System.Drawing.Point(18, 109);
            this.GuardsSummaryTBL.Name = "GuardsSummaryTBL";
            this.GuardsSummaryTBL.ReadOnly = true;
            this.GuardsSummaryTBL.Size = new System.Drawing.Size(652, 476);
            this.GuardsSummaryTBL.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label1.Location = new System.Drawing.Point(19, 71);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 19);
            this.label1.TabIndex = 15;
            this.label1.Text = "Summary as of 01/01/2017";
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
            this.label2.Location = new System.Drawing.Point(14, 9);
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
            this.Controls.Add(this.GuardsReportPNL);
            this.Controls.Add(this.ClientsReportPNL);
            this.Name = "ReportsForm";
            this.Text = resources.GetString("$this.Text");
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
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Button ExportClientsSummaryBTN;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.DataGridView ClientsSummaryTBL;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Panel GuardsReportPNL;
        private System.Windows.Forms.DataGridView GuardsSummaryTBL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ExportGuardsSummaryBTN;
        private System.Windows.Forms.Label label2;
    }
}