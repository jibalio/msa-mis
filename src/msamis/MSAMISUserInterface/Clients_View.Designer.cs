namespace MSAMISUserInterface {
    partial class Clients_View {
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
            this.CIDLBL = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ContactLBL = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.StatusLBL = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.NameLBL = new System.Windows.Forms.Label();
            this.ContactNoLBL = new System.Windows.Forms.Label();
            this.FadeTMR = new System.Windows.Forms.Timer(this.components);
            this.DetailsPNL = new System.Windows.Forms.Panel();
            this.ManagerLBL = new System.Windows.Forms.Label();
            this.LocationLBL = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.CloseBTN = new System.Windows.Forms.Button();
            this.CEditDetailsBTN = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.DetailsPNL.SuspendLayout();
            this.SuspendLayout();
            // 
            // CIDLBL
            // 
            this.CIDLBL.AutoSize = true;
            this.CIDLBL.BackColor = System.Drawing.Color.Transparent;
            this.CIDLBL.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.CIDLBL.ForeColor = System.Drawing.Color.White;
            this.CIDLBL.Location = new System.Drawing.Point(317, 47);
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
            this.label4.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(251, 47);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Client ID:";
            // 
            // ContactLBL
            // 
            this.ContactLBL.Dock = System.Windows.Forms.DockStyle.Top;
            this.ContactLBL.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.ContactLBL.ForeColor = System.Drawing.Color.White;
            this.ContactLBL.Location = new System.Drawing.Point(0, 151);
            this.ContactLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ContactLBL.Name = "ContactLBL";
            this.ContactLBL.Size = new System.Drawing.Size(721, 30);
            this.ContactLBL.TabIndex = 119;
            this.ContactLBL.Text = "---------------";
            this.ContactLBL.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label43
            // 
            this.label43.Dock = System.Windows.Forms.DockStyle.Top;
            this.label43.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label43.ForeColor = System.Drawing.Color.White;
            this.label43.Location = new System.Drawing.Point(0, 111);
            this.label43.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(721, 40);
            this.label43.TabIndex = 117;
            this.label43.Text = "CONTACT INFO";
            this.label43.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // StatusLBL
            // 
            this.StatusLBL.AutoSize = true;
            this.StatusLBL.BackColor = System.Drawing.Color.Transparent;
            this.StatusLBL.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.StatusLBL.ForeColor = System.Drawing.Color.White;
            this.StatusLBL.Location = new System.Drawing.Point(403, 47);
            this.StatusLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.StatusLBL.Name = "StatusLBL";
            this.StatusLBL.Size = new System.Drawing.Size(45, 19);
            this.StatusLBL.TabIndex = 7;
            this.StatusLBL.Text = "Active";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(351, 47);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Status:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Controls.Add(this.StatusLBL);
            this.panel1.Controls.Add(this.CIDLBL);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.NameLBL);
            this.panel1.Location = new System.Drawing.Point(4, 89);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(718, 80);
            this.panel1.TabIndex = 226;
            // 
            // NameLBL
            // 
            this.NameLBL.BackColor = System.Drawing.Color.Transparent;
            this.NameLBL.Dock = System.Windows.Forms.DockStyle.Top;
            this.NameLBL.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.NameLBL.ForeColor = System.Drawing.Color.White;
            this.NameLBL.Location = new System.Drawing.Point(0, 0);
            this.NameLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NameLBL.Name = "NameLBL";
            this.NameLBL.Size = new System.Drawing.Size(718, 30);
            this.NameLBL.TabIndex = 0;
            this.NameLBL.Text = "AAA Marketing Inc.";
            this.NameLBL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ContactNoLBL
            // 
            this.ContactNoLBL.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ContactNoLBL.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.ContactNoLBL.ForeColor = System.Drawing.Color.White;
            this.ContactNoLBL.Location = new System.Drawing.Point(0, 184);
            this.ContactNoLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ContactNoLBL.Name = "ContactNoLBL";
            this.ContactNoLBL.Size = new System.Drawing.Size(721, 19);
            this.ContactNoLBL.TabIndex = 89;
            this.ContactNoLBL.Text = "---------------";
            this.ContactNoLBL.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FadeTMR
            // 
            this.FadeTMR.Interval = 1;
            this.FadeTMR.Tick += new System.EventHandler(this.FadeTMR_Tick);
            // 
            // DetailsPNL
            // 
            this.DetailsPNL.AutoScroll = true;
            this.DetailsPNL.Controls.Add(this.ContactLBL);
            this.DetailsPNL.Controls.Add(this.label43);
            this.DetailsPNL.Controls.Add(this.ContactNoLBL);
            this.DetailsPNL.Controls.Add(this.ManagerLBL);
            this.DetailsPNL.Controls.Add(this.LocationLBL);
            this.DetailsPNL.Controls.Add(this.label6);
            this.DetailsPNL.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.DetailsPNL.Location = new System.Drawing.Point(1, 219);
            this.DetailsPNL.Name = "DetailsPNL";
            this.DetailsPNL.Size = new System.Drawing.Size(721, 203);
            this.DetailsPNL.TabIndex = 229;
            // 
            // ManagerLBL
            // 
            this.ManagerLBL.Dock = System.Windows.Forms.DockStyle.Top;
            this.ManagerLBL.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.ManagerLBL.ForeColor = System.Drawing.Color.White;
            this.ManagerLBL.Location = new System.Drawing.Point(0, 70);
            this.ManagerLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ManagerLBL.Name = "ManagerLBL";
            this.ManagerLBL.Size = new System.Drawing.Size(721, 41);
            this.ManagerLBL.TabIndex = 77;
            this.ManagerLBL.Text = "---------";
            this.ManagerLBL.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LocationLBL
            // 
            this.LocationLBL.Dock = System.Windows.Forms.DockStyle.Top;
            this.LocationLBL.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.LocationLBL.ForeColor = System.Drawing.Color.White;
            this.LocationLBL.Location = new System.Drawing.Point(0, 40);
            this.LocationLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LocationLBL.Name = "LocationLBL";
            this.LocationLBL.Size = new System.Drawing.Size(721, 30);
            this.LocationLBL.TabIndex = 74;
            this.LocationLBL.Text = "---------";
            this.LocationLBL.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(721, 40);
            this.label6.TabIndex = 7;
            this.label6.Text = "CLIENT DETAILS";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CloseBTN
            // 
            this.CloseBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.CloseBTN.BackgroundImage = global::MSAMISUserInterface.Properties.Resources.BTNV2;
            this.CloseBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CloseBTN.FlatAppearance.BorderSize = 0;
            this.CloseBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.CloseBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(97)))), ((int)(((byte)(81)))));
            this.CloseBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBTN.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseBTN.ForeColor = System.Drawing.Color.White;
            this.CloseBTN.Location = new System.Drawing.Point(384, 609);
            this.CloseBTN.Name = "CloseBTN";
            this.CloseBTN.Size = new System.Drawing.Size(78, 32);
            this.CloseBTN.TabIndex = 228;
            this.CloseBTN.Text = "CLOSE";
            this.CloseBTN.UseVisualStyleBackColor = false;
            this.CloseBTN.Click += new System.EventHandler(this.CloseBTN_Click);
            // 
            // CEditDetailsBTN
            // 
            this.CEditDetailsBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CEditDetailsBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(109)))), ((int)(((byte)(140)))));
            this.CEditDetailsBTN.BackgroundImage = global::MSAMISUserInterface.Properties.Resources.BTNV2;
            this.CEditDetailsBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CEditDetailsBTN.FlatAppearance.BorderSize = 0;
            this.CEditDetailsBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(87)))), ((int)(((byte)(112)))));
            this.CEditDetailsBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(149)))), ((int)(((byte)(191)))));
            this.CEditDetailsBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CEditDetailsBTN.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CEditDetailsBTN.ForeColor = System.Drawing.Color.White;
            this.CEditDetailsBTN.Location = new System.Drawing.Point(301, 609);
            this.CEditDetailsBTN.Name = "CEditDetailsBTN";
            this.CEditDetailsBTN.Size = new System.Drawing.Size(78, 32);
            this.CEditDetailsBTN.TabIndex = 227;
            this.CEditDetailsBTN.Text = "EDIT";
            this.CEditDetailsBTN.UseVisualStyleBackColor = false;
            this.CEditDetailsBTN.Click += new System.EventHandler(this.CEditDetailsBTN_Click);
            // 
            // Clients_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(723, 668);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CloseBTN);
            this.Controls.Add(this.CEditDetailsBTN);
            this.Controls.Add(this.DetailsPNL);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Clients_View";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Clients_View";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Clients_View_FormClosing);
            this.Load += new System.EventHandler(this.Clients_View_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.DetailsPNL.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label CIDLBL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label ContactLBL;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label StatusLBL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label NameLBL;
        private System.Windows.Forms.Label ContactNoLBL;
        private System.Windows.Forms.Button CloseBTN;
        private System.Windows.Forms.Button CEditDetailsBTN;
        private System.Windows.Forms.Timer FadeTMR;
        private System.Windows.Forms.Panel DetailsPNL;
        private System.Windows.Forms.Label ManagerLBL;
        private System.Windows.Forms.Label LocationLBL;
        private System.Windows.Forms.Label label6;
    }
}