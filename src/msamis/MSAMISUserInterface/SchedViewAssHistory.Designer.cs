namespace MSAMISUserInterface {
    partial class SchedViewAssHistory {
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.CloseBTN = new System.Windows.Forms.Button();
            this.NameLBL = new System.Windows.Forms.Label();
            this.TimeLBL = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SGuardHistoryViewBTN = new System.Windows.Forms.Button();
            this.FadeTMR = new System.Windows.Forms.Timer(this.components);
            this.AssignmentsGRD = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AssignmentsGRD)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.panel1.Controls.Add(this.CloseBTN);
            this.panel1.Controls.Add(this.NameLBL);
            this.panel1.Controls.Add(this.TimeLBL);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(499, 107);
            this.panel1.TabIndex = 2;
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
            this.CloseBTN.Location = new System.Drawing.Point(467, 0);
            this.CloseBTN.Name = "CloseBTN";
            this.CloseBTN.Size = new System.Drawing.Size(32, 32);
            this.CloseBTN.TabIndex = 237;
            this.CloseBTN.Text = "X";
            this.CloseBTN.UseVisualStyleBackColor = false;
            this.CloseBTN.Click += new System.EventHandler(this.CloseBTN_Click);
            // 
            // NameLBL
            // 
            this.NameLBL.Dock = System.Windows.Forms.DockStyle.Top;
            this.NameLBL.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.NameLBL.ForeColor = System.Drawing.Color.White;
            this.NameLBL.Location = new System.Drawing.Point(0, 50);
            this.NameLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NameLBL.Name = "NameLBL";
            this.NameLBL.Size = new System.Drawing.Size(499, 43);
            this.NameLBL.TabIndex = 120;
            this.NameLBL.Text = "Regodon, Rhyle Abram";
            this.NameLBL.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // TimeLBL
            // 
            this.TimeLBL.Dock = System.Windows.Forms.DockStyle.Top;
            this.TimeLBL.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.TimeLBL.ForeColor = System.Drawing.Color.White;
            this.TimeLBL.Location = new System.Drawing.Point(0, 25);
            this.TimeLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TimeLBL.Name = "TimeLBL";
            this.TimeLBL.Size = new System.Drawing.Size(499, 25);
            this.TimeLBL.TabIndex = 121;
            this.TimeLBL.Text = "Assignment History for";
            this.TimeLBL.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(499, 25);
            this.label1.TabIndex = 122;
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // SGuardHistoryViewBTN
            // 
            this.SGuardHistoryViewBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.SGuardHistoryViewBTN.BackgroundImage = global::MSAMISUserInterface.Properties.Resources.Button;
            this.SGuardHistoryViewBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SGuardHistoryViewBTN.FlatAppearance.BorderSize = 0;
            this.SGuardHistoryViewBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(47)))), ((int)(((byte)(61)))));
            this.SGuardHistoryViewBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            this.SGuardHistoryViewBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SGuardHistoryViewBTN.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SGuardHistoryViewBTN.ForeColor = System.Drawing.Color.White;
            this.SGuardHistoryViewBTN.Location = new System.Drawing.Point(180, 532);
            this.SGuardHistoryViewBTN.Name = "SGuardHistoryViewBTN";
            this.SGuardHistoryViewBTN.Size = new System.Drawing.Size(130, 32);
            this.SGuardHistoryViewBTN.TabIndex = 9;
            this.SGuardHistoryViewBTN.Text = "VIEW DETAILS";
            this.SGuardHistoryViewBTN.UseVisualStyleBackColor = false;
            this.SGuardHistoryViewBTN.Click += new System.EventHandler(this.SGuardHistoryViewBTN_Click);
            // 
            // FadeTMR
            // 
            this.FadeTMR.Interval = 1;
            this.FadeTMR.Tick += new System.EventHandler(this.FadeTMR_Tick);
            // 
            // AssignmentsGRD
            // 
            this.AssignmentsGRD.AllowUserToAddRows = false;
            this.AssignmentsGRD.AllowUserToDeleteRows = false;
            this.AssignmentsGRD.AllowUserToResizeColumns = false;
            this.AssignmentsGRD.AllowUserToResizeRows = false;
            this.AssignmentsGRD.BackgroundColor = System.Drawing.Color.White;
            this.AssignmentsGRD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AssignmentsGRD.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.AssignmentsGRD.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle1.NullValue = "-";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AssignmentsGRD.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.AssignmentsGRD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.AssignmentsGRD.DefaultCellStyle = dataGridViewCellStyle2;
            this.AssignmentsGRD.EnableHeadersVisualStyles = false;
            this.AssignmentsGRD.Location = new System.Drawing.Point(94, 132);
            this.AssignmentsGRD.MultiSelect = false;
            this.AssignmentsGRD.Name = "AssignmentsGRD";
            this.AssignmentsGRD.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AssignmentsGRD.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.AssignmentsGRD.RowHeadersVisible = false;
            this.AssignmentsGRD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AssignmentsGRD.Size = new System.Drawing.Size(318, 365);
            this.AssignmentsGRD.TabIndex = 10;
            // 
            // SchedViewAssHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(498, 598);
            this.ControlBox = false;
            this.Controls.Add(this.SGuardHistoryViewBTN);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.AssignmentsGRD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SchedViewAssHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SchedViewAssHistory_FormClosing);
            this.Load += new System.EventHandler(this.SchedViewAssHistory_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AssignmentsGRD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CloseBTN;
        private System.Windows.Forms.Label NameLBL;
        private System.Windows.Forms.Label TimeLBL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SGuardHistoryViewBTN;
        private System.Windows.Forms.Timer FadeTMR;
        private System.Windows.Forms.DataGridView AssignmentsGRD;
    }
}