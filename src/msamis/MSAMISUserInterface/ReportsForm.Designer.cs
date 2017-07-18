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
            this.PSalaryReportPage = new System.Windows.Forms.Panel();
            this.label42 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.label43 = new System.Windows.Forms.Label();
            this.CClientListTBL = new System.Windows.Forms.DataGridView();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.PSalaryReportPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CClientListTBL)).BeginInit();
            this.SuspendLayout();
            // 
            // PSalaryReportPage
            // 
            this.PSalaryReportPage.Controls.Add(this.CClientListTBL);
            this.PSalaryReportPage.Controls.Add(this.label42);
            this.PSalaryReportPage.Controls.Add(this.button8);
            this.PSalaryReportPage.Controls.Add(this.label43);
            this.PSalaryReportPage.Location = new System.Drawing.Point(12, 12);
            this.PSalaryReportPage.Name = "PSalaryReportPage";
            this.PSalaryReportPage.Size = new System.Drawing.Size(690, 640);
            this.PSalaryReportPage.TabIndex = 21;
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
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.button8.BackgroundImage = global::MSAMISUserInterface.Properties.Resources.Button;
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(87)))), ((int)(((byte)(145)))));
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.Location = new System.Drawing.Point(287, 594);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(112, 32);
            this.button8.TabIndex = 6;
            this.button8.Text = "PRINT";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.PrintClientReportBTN_Click);
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Segoe UI Light", 28F);
            this.label43.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label43.Location = new System.Drawing.Point(14, 9);
            this.label43.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(252, 51);
            this.label43.TabIndex = 4;
            this.label43.Text = "Salary Reports";
            // 
            // CClientListTBL
            // 
            this.CClientListTBL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CClientListTBL.Location = new System.Drawing.Point(18, 109);
            this.CClientListTBL.Name = "CClientListTBL";
            this.CClientListTBL.Size = new System.Drawing.Size(652, 476);
            this.CClientListTBL.TabIndex = 16;
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 669);
            this.Controls.Add(this.PSalaryReportPage);
            this.Name = "ReportsForm";
            this.Text = "ReportsForm";
            this.PSalaryReportPage.ResumeLayout(false);
            this.PSalaryReportPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CClientListTBL)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PSalaryReportPage;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.DataGridView CClientListTBL;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}