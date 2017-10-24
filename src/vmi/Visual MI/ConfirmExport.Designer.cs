namespace Visual_MI {
    partial class ConfirmExport {
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
            this.cb = new System.Windows.Forms.CheckBox();
            this.ttpath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ttperiod = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // cb
            // 
            this.cb.AutoSize = true;
            this.cb.Checked = true;
            this.cb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb.Location = new System.Drawing.Point(64, 64);
            this.cb.Name = "cb";
            this.cb.Size = new System.Drawing.Size(154, 17);
            this.cb.TabIndex = 15;
            this.cb.Text = "Update StartAt # on Export";
            this.cb.UseVisualStyleBackColor = true;
            // 
            // ttpath
            // 
            this.ttpath.Enabled = false;
            this.ttpath.Location = new System.Drawing.Point(64, 38);
            this.ttpath.Name = "ttpath";
            this.ttpath.Size = new System.Drawing.Size(259, 20);
            this.ttpath.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 87);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(310, 34);
            this.button1.TabIndex = 16;
            this.button1.Text = "Export";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ttperiod
            // 
            this.ttperiod.Location = new System.Drawing.Point(64, 12);
            this.ttperiod.Name = "ttperiod";
            this.ttperiod.Size = new System.Drawing.Size(259, 20);
            this.ttperiod.TabIndex = 17;
            this.ttperiod.TextChanged += new System.EventHandler(this.ttperiod_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Filename";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Path";
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            this.ofd.FileOk += new System.ComponentModel.CancelEventHandler(this.ofd_FileOk);
            // 
            // ConfirmExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 132);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ttperiod);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cb);
            this.Controls.Add(this.ttpath);
            this.Name = "ConfirmExport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.CheckBox cb;
        public System.Windows.Forms.TextBox ttpath;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox ttperiod;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog ofd;
    }
}