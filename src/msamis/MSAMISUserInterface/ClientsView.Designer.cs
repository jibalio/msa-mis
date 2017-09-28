namespace MSAMISUserInterface {
    partial class ClientsView {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientsView));
            this.CIDLBL = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ContactLBL = new System.Windows.Forms.Label();
            this.NameLBL = new System.Windows.Forms.Label();
            this.ContactNoLBL = new System.Windows.Forms.Label();
            this.FadeTMR = new System.Windows.Forms.Timer(this.components);
            this.DetailsPNL = new System.Windows.Forms.Panel();
            this.ErrorPNL = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CertifiersGRD = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.ManagerLBL = new System.Windows.Forms.Label();
            this.LocationLBL = new System.Windows.Forms.Label();
            this.CloseBTN = new System.Windows.Forms.Button();
            this.CEditDetailsBTN = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.BasicPayLBL = new System.Windows.Forms.Label();
            this.DetailsPNL.SuspendLayout();
            this.ErrorPNL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CertifiersGRD)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CIDLBL
            // 
            this.CIDLBL.AutoSize = true;
            this.CIDLBL.BackColor = System.Drawing.Color.Transparent;
            this.CIDLBL.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.CIDLBL.ForeColor = System.Drawing.Color.White;
            this.CIDLBL.Location = new System.Drawing.Point(317, 119);
            this.CIDLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CIDLBL.Name = "CIDLBL";
            this.CIDLBL.Size = new System.Drawing.Size(21, 19);
            this.CIDLBL.TabIndex = 5;
            this.CIDLBL.Text = "10";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(248, 119);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Client ID:";
            // 
            // ContactLBL
            // 
            this.ContactLBL.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.ContactLBL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.ContactLBL.Location = new System.Drawing.Point(240, 73);
            this.ContactLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ContactLBL.Name = "ContactLBL";
            this.ContactLBL.Size = new System.Drawing.Size(276, 28);
            this.ContactLBL.TabIndex = 119;
            this.ContactLBL.Text = "---------------";
            this.ContactLBL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NameLBL
            // 
            this.NameLBL.BackColor = System.Drawing.Color.Transparent;
            this.NameLBL.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.NameLBL.ForeColor = System.Drawing.Color.White;
            this.NameLBL.Location = new System.Drawing.Point(-1, 32);
            this.NameLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NameLBL.Name = "NameLBL";
            this.NameLBL.Size = new System.Drawing.Size(599, 45);
            this.NameLBL.TabIndex = 0;
            this.NameLBL.Text = "AAA Marketing Inc.";
            this.NameLBL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ContactNoLBL
            // 
            this.ContactNoLBL.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.ContactNoLBL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.ContactNoLBL.Location = new System.Drawing.Point(240, 102);
            this.ContactNoLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ContactNoLBL.Name = "ContactNoLBL";
            this.ContactNoLBL.Size = new System.Drawing.Size(276, 28);
            this.ContactNoLBL.TabIndex = 89;
            this.ContactNoLBL.Text = "---------------";
            this.ContactNoLBL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FadeTMR
            // 
            this.FadeTMR.Interval = 1;
            this.FadeTMR.Tick += new System.EventHandler(this.FadeTMR_Tick);
            // 
            // DetailsPNL
            // 
            this.DetailsPNL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DetailsPNL.AutoScroll = true;
            this.DetailsPNL.Controls.Add(this.label8);
            this.DetailsPNL.Controls.Add(this.BasicPayLBL);
            this.DetailsPNL.Controls.Add(this.label7);
            this.DetailsPNL.Controls.Add(this.label1);
            this.DetailsPNL.Controls.Add(this.label2);
            this.DetailsPNL.Controls.Add(this.label3);
            this.DetailsPNL.Controls.Add(this.label28);
            this.DetailsPNL.Controls.Add(this.ManagerLBL);
            this.DetailsPNL.Controls.Add(this.ContactNoLBL);
            this.DetailsPNL.Controls.Add(this.ContactLBL);
            this.DetailsPNL.Controls.Add(this.ErrorPNL);
            this.DetailsPNL.Controls.Add(this.CertifiersGRD);
            this.DetailsPNL.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.DetailsPNL.Location = new System.Drawing.Point(0, 0);
            this.DetailsPNL.Name = "DetailsPNL";
            this.DetailsPNL.Size = new System.Drawing.Size(599, 350);
            this.DetailsPNL.TabIndex = 229;
            // 
            // ErrorPNL
            // 
            this.ErrorPNL.Controls.Add(this.label6);
            this.ErrorPNL.Controls.Add(this.label5);
            this.ErrorPNL.Location = new System.Drawing.Point(103, 208);
            this.ErrorPNL.Name = "ErrorPNL";
            this.ErrorPNL.Size = new System.Drawing.Size(413, 134);
            this.ErrorPNL.TabIndex = 148;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label6.Location = new System.Drawing.Point(103, 65);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(194, 19);
            this.label6.TabIndex = 150;
            this.label6.Text = "Please edit and add a new one";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label5.Location = new System.Drawing.Point(121, 40);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 21);
            this.label5.TabIndex = 149;
            this.label5.Text = "No Certifiers Found";
            // 
            // CertifiersGRD
            // 
            this.CertifiersGRD.AllowUserToAddRows = false;
            this.CertifiersGRD.AllowUserToDeleteRows = false;
            this.CertifiersGRD.AllowUserToResizeColumns = false;
            this.CertifiersGRD.AllowUserToResizeRows = false;
            this.CertifiersGRD.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.CertifiersGRD.BackgroundColor = System.Drawing.Color.White;
            this.CertifiersGRD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CertifiersGRD.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.CertifiersGRD.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.NullValue = "-";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CertifiersGRD.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.CertifiersGRD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.CertifiersGRD.DefaultCellStyle = dataGridViewCellStyle2;
            this.CertifiersGRD.EnableHeadersVisualStyles = false;
            this.CertifiersGRD.Location = new System.Drawing.Point(116, 208);
            this.CertifiersGRD.MultiSelect = false;
            this.CertifiersGRD.Name = "CertifiersGRD";
            this.CertifiersGRD.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CertifiersGRD.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.CertifiersGRD.RowHeadersVisible = false;
            this.CertifiersGRD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CertifiersGRD.Size = new System.Drawing.Size(400, 142);
            this.CertifiersGRD.TabIndex = 147;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label1.Location = new System.Drawing.Point(116, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 28);
            this.label1.TabIndex = 128;
            this.label1.Text = "Manager:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label2.Location = new System.Drawing.Point(116, 102);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 28);
            this.label2.TabIndex = 129;
            this.label2.Text = "Contact No:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label3.Location = new System.Drawing.Point(116, 73);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 28);
            this.label3.TabIndex = 130;
            this.label3.Text = "Contact Person:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label28.Location = new System.Drawing.Point(115, 171);
            this.label28.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(94, 21);
            this.label28.TabIndex = 120;
            this.label28.Text = "CERTIFIERS";
            // 
            // ManagerLBL
            // 
            this.ManagerLBL.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.ManagerLBL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.ManagerLBL.Location = new System.Drawing.Point(240, 43);
            this.ManagerLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ManagerLBL.Name = "ManagerLBL";
            this.ManagerLBL.Size = new System.Drawing.Size(276, 28);
            this.ManagerLBL.TabIndex = 77;
            this.ManagerLBL.Text = "---------";
            this.ManagerLBL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LocationLBL
            // 
            this.LocationLBL.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.LocationLBL.ForeColor = System.Drawing.Color.White;
            this.LocationLBL.Location = new System.Drawing.Point(-1, 86);
            this.LocationLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LocationLBL.Name = "LocationLBL";
            this.LocationLBL.Size = new System.Drawing.Size(599, 21);
            this.LocationLBL.TabIndex = 74;
            this.LocationLBL.Text = "Asa Mani Dapit?";
            this.LocationLBL.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.CloseBTN.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold);
            this.CloseBTN.ForeColor = System.Drawing.Color.White;
            this.CloseBTN.Location = new System.Drawing.Point(564, 0);
            this.CloseBTN.Name = "CloseBTN";
            this.CloseBTN.Size = new System.Drawing.Size(34, 32);
            this.CloseBTN.TabIndex = 228;
            this.CloseBTN.Text = "X";
            this.CloseBTN.UseVisualStyleBackColor = false;
            this.CloseBTN.Click += new System.EventHandler(this.CloseBTN_Click);
            // 
            // CEditDetailsBTN
            // 
            this.CEditDetailsBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CEditDetailsBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.CEditDetailsBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CEditDetailsBTN.BackgroundImage")));
            this.CEditDetailsBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CEditDetailsBTN.FlatAppearance.BorderSize = 0;
            this.CEditDetailsBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(87)))), ((int)(((byte)(112)))));
            this.CEditDetailsBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(149)))), ((int)(((byte)(191)))));
            this.CEditDetailsBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CEditDetailsBTN.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CEditDetailsBTN.ForeColor = System.Drawing.Color.White;
            this.CEditDetailsBTN.Location = new System.Drawing.Point(260, 356);
            this.CEditDetailsBTN.Name = "CEditDetailsBTN";
            this.CEditDetailsBTN.Size = new System.Drawing.Size(78, 32);
            this.CEditDetailsBTN.TabIndex = 227;
            this.CEditDetailsBTN.Text = "EDIT";
            this.CEditDetailsBTN.UseVisualStyleBackColor = false;
            this.CEditDetailsBTN.Click += new System.EventHandler(this.CEditDetailsBTN_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.DetailsPNL);
            this.panel1.Controls.Add(this.CEditDetailsBTN);
            this.panel1.Location = new System.Drawing.Point(-1, 187);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(599, 411);
            this.panel1.TabIndex = 120;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label7.Location = new System.Drawing.Point(114, 14);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 21);
            this.label7.TabIndex = 240;
            this.label7.Text = "CONTACT INFO";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label8.Location = new System.Drawing.Point(116, 132);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 28);
            this.label8.TabIndex = 242;
            this.label8.Text = "Officer Basic Pay:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BasicPayLBL
            // 
            this.BasicPayLBL.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.BasicPayLBL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.BasicPayLBL.Location = new System.Drawing.Point(240, 132);
            this.BasicPayLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BasicPayLBL.Name = "BasicPayLBL";
            this.BasicPayLBL.Size = new System.Drawing.Size(276, 28);
            this.BasicPayLBL.TabIndex = 241;
            this.BasicPayLBL.Text = "---------------";
            this.BasicPayLBL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ClientsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(598, 598);
            this.ControlBox = false;
            this.Controls.Add(this.CloseBTN);
            this.Controls.Add(this.CIDLBL);
            this.Controls.Add(this.LocationLBL);
            this.Controls.Add(this.NameLBL);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ClientsView";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Clients_View_FormClosing);
            this.Load += new System.EventHandler(this.Clients_View_Load);
            this.DetailsPNL.ResumeLayout(false);
            this.DetailsPNL.PerformLayout();
            this.ErrorPNL.ResumeLayout(false);
            this.ErrorPNL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CertifiersGRD)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CIDLBL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label ContactLBL;
        private System.Windows.Forms.Label NameLBL;
        private System.Windows.Forms.Label ContactNoLBL;
        private System.Windows.Forms.Button CloseBTN;
        private System.Windows.Forms.Button CEditDetailsBTN;
        private System.Windows.Forms.Timer FadeTMR;
        private System.Windows.Forms.Panel DetailsPNL;
        private System.Windows.Forms.Label ManagerLBL;
        private System.Windows.Forms.Label LocationLBL;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView CertifiersGRD;
        private System.Windows.Forms.Panel ErrorPNL;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label BasicPayLBL;
    }
}