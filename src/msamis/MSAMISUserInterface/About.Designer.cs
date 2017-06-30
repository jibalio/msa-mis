namespace MSAMISUserInterface {
    partial class About {
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
            this.FadeTMR = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.NameLBL = new System.Windows.Forms.Label();
            this.UsersLBL = new System.Windows.Forms.Label();
            this.AboutLBL = new System.Windows.Forms.Label();
            this.SettingsLBL = new System.Windows.Forms.Label();
            this.CloseBTN = new System.Windows.Forms.Button();
            this.AboutPNL = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.UsersPNL = new System.Windows.Forms.Panel();
            this.SettingsPNL = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.AboutPNL.SuspendLayout();
            this.SuspendLayout();
            // 
            // FadeTMR
            // 
            this.FadeTMR.Interval = 1;
            this.FadeTMR.Tick += new System.EventHandler(this.FadeTMR_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.NameLBL);
            this.panel1.Location = new System.Drawing.Point(0, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(722, 79);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label4.Location = new System.Drawing.Point(0, 43);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(722, 24);
            this.label4.TabIndex = 121;
            this.label4.Text = "Management Information System";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // NameLBL
            // 
            this.NameLBL.Dock = System.Windows.Forms.DockStyle.Top;
            this.NameLBL.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.NameLBL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.NameLBL.Location = new System.Drawing.Point(0, 0);
            this.NameLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NameLBL.Name = "NameLBL";
            this.NameLBL.Size = new System.Drawing.Size(722, 43);
            this.NameLBL.TabIndex = 120;
            this.NameLBL.Text = "Makabayan Security Agency";
            this.NameLBL.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // UsersLBL
            // 
            this.UsersLBL.AutoSize = true;
            this.UsersLBL.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.UsersLBL.ForeColor = System.Drawing.Color.Gray;
            this.UsersLBL.Location = new System.Drawing.Point(335, 153);
            this.UsersLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UsersLBL.Name = "UsersLBL";
            this.UsersLBL.Size = new System.Drawing.Size(51, 21);
            this.UsersLBL.TabIndex = 135;
            this.UsersLBL.Text = "Users";
            this.UsersLBL.Click += new System.EventHandler(this.UsersLBL_Click);
            this.UsersLBL.MouseEnter += new System.EventHandler(this.UsersLBL_MouseEnter);
            this.UsersLBL.MouseLeave += new System.EventHandler(this.UsersLBL_MouseLeave);
            // 
            // AboutLBL
            // 
            this.AboutLBL.AutoSize = true;
            this.AboutLBL.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.AboutLBL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.AboutLBL.Location = new System.Drawing.Point(216, 153);
            this.AboutLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AboutLBL.Name = "AboutLBL";
            this.AboutLBL.Size = new System.Drawing.Size(57, 21);
            this.AboutLBL.TabIndex = 134;
            this.AboutLBL.Text = "About";
            this.AboutLBL.Click += new System.EventHandler(this.AboutLBL_Click);
            this.AboutLBL.MouseEnter += new System.EventHandler(this.AboutLBL_MouseEnter);
            this.AboutLBL.MouseLeave += new System.EventHandler(this.AboutLBL_MouseLeave);
            // 
            // SettingsLBL
            // 
            this.SettingsLBL.AutoSize = true;
            this.SettingsLBL.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.SettingsLBL.ForeColor = System.Drawing.Color.Gray;
            this.SettingsLBL.Location = new System.Drawing.Point(445, 153);
            this.SettingsLBL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SettingsLBL.Name = "SettingsLBL";
            this.SettingsLBL.Size = new System.Drawing.Size(72, 21);
            this.SettingsLBL.TabIndex = 136;
            this.SettingsLBL.Text = "Settings";
            this.SettingsLBL.Click += new System.EventHandler(this.SettingsLBL_Click);
            this.SettingsLBL.MouseEnter += new System.EventHandler(this.SettingsLBL_MouseEnter);
            this.SettingsLBL.MouseLeave += new System.EventHandler(this.SettingsLBL_MouseLeave);
            // 
            // CloseBTN
            // 
            this.CloseBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.CloseBTN.BackgroundImage = global::MSAMISUserInterface.Properties.Resources.Button;
            this.CloseBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CloseBTN.FlatAppearance.BorderSize = 0;
            this.CloseBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.CloseBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(97)))), ((int)(((byte)(81)))));
            this.CloseBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBTN.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseBTN.ForeColor = System.Drawing.Color.White;
            this.CloseBTN.Location = new System.Drawing.Point(305, 600);
            this.CloseBTN.Name = "CloseBTN";
            this.CloseBTN.Size = new System.Drawing.Size(101, 32);
            this.CloseBTN.TabIndex = 236;
            this.CloseBTN.Text = "CLOSE";
            this.CloseBTN.UseVisualStyleBackColor = false;
            this.CloseBTN.Click += new System.EventHandler(this.CloseBTN_Click);
            // 
            // AboutPNL
            // 
            this.AboutPNL.BackgroundImage = global::MSAMISUserInterface.Properties.Resources.HomeBG;
            this.AboutPNL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AboutPNL.Controls.Add(this.label10);
            this.AboutPNL.Controls.Add(this.label9);
            this.AboutPNL.Controls.Add(this.label8);
            this.AboutPNL.Controls.Add(this.label7);
            this.AboutPNL.Controls.Add(this.label5);
            this.AboutPNL.Controls.Add(this.label6);
            this.AboutPNL.Controls.Add(this.label3);
            this.AboutPNL.Controls.Add(this.label2);
            this.AboutPNL.Location = new System.Drawing.Point(122, 189);
            this.AboutPNL.Name = "AboutPNL";
            this.AboutPNL.Size = new System.Drawing.Size(474, 379);
            this.AboutPNL.TabIndex = 237;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label10.Location = new System.Drawing.Point(124, 326);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(224, 19);
            this.label10.TabIndex = 247;
            this.label10.Text = " acquired a license for the software.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label9.Location = new System.Drawing.Point(47, 307);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(385, 19);
            this.label9.TabIndex = 246;
            this.label9.Text = "to when you signed up for the subscription and by which you";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label8.Location = new System.Drawing.Point(35, 288);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(409, 19);
            this.label8.TabIndex = 245;
            this.label8.Text = "subject to the terms and conditions of the agreement you agreed";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label7.Location = new System.Drawing.Point(30, 269);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(415, 19);
            this.label7.TabIndex = 244;
            this.label7.Text = "PLEASE NOTE:  Your use of the subscription service and software is";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label5.Location = new System.Drawing.Point(140, 162);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(213, 21);
            this.label5.TabIndex = 243;
            this.label5.Text = "SADMakaSys ver 0.4.187b1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label6.Location = new System.Drawing.Point(195, 135);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 19);
            this.label6.TabIndex = 242;
            this.label6.Text = "App Version:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label3.Location = new System.Drawing.Point(196, 69);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 21);
            this.label3.TabIndex = 241;
            this.label3.Text = "RylDB Inc.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.label2.Location = new System.Drawing.Point(99, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(280, 19);
            this.label2.TabIndex = 240;
            this.label2.Text = "This Software is Managed and Developed by";
            // 
            // UsersPNL
            // 
            this.UsersPNL.Location = new System.Drawing.Point(122, 189);
            this.UsersPNL.Name = "UsersPNL";
            this.UsersPNL.Size = new System.Drawing.Size(474, 379);
            this.UsersPNL.TabIndex = 238;
            // 
            // SettingsPNL
            // 
            this.SettingsPNL.Location = new System.Drawing.Point(122, 189);
            this.SettingsPNL.Name = "SettingsPNL";
            this.SettingsPNL.Size = new System.Drawing.Size(474, 379);
            this.SettingsPNL.TabIndex = 239;
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(721, 666);
            this.ControlBox = false;
            this.Controls.Add(this.CloseBTN);
            this.Controls.Add(this.SettingsLBL);
            this.Controls.Add(this.UsersLBL);
            this.Controls.Add(this.AboutLBL);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.AboutPNL);
            this.Controls.Add(this.SettingsPNL);
            this.Controls.Add(this.UsersPNL);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "About";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.About_FormClosing);
            this.Load += new System.EventHandler(this.About_Load);
            this.panel1.ResumeLayout(false);
            this.AboutPNL.ResumeLayout(false);
            this.AboutPNL.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer FadeTMR;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label NameLBL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label UsersLBL;
        private System.Windows.Forms.Label AboutLBL;
        private System.Windows.Forms.Label SettingsLBL;
        private System.Windows.Forms.Button CloseBTN;
        private System.Windows.Forms.Panel AboutPNL;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel UsersPNL;
        private System.Windows.Forms.Panel SettingsPNL;
    }
}