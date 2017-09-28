namespace MSAMISUserInterface {
    partial class Exporting {
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
            this.label68 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.FadeInTMR = new System.Windows.Forms.Timer(this.components);
            this.FadeOutTMR = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label68
            // 
            this.label68.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.label68.ForeColor = System.Drawing.Color.White;
            this.label68.Location = new System.Drawing.Point(11, 54);
            this.label68.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(297, 19);
            this.label68.TabIndex = 36;
            this.label68.Text = "Please wait...";
            this.label68.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label69
            // 
            this.label69.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label69.ForeColor = System.Drawing.Color.White;
            this.label69.Location = new System.Drawing.Point(11, 21);
            this.label69.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(295, 39);
            this.label69.TabIndex = 35;
            this.label69.Text = "Exporting to PDF";
            this.label69.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FadeInTMR
            // 
            this.FadeInTMR.Interval = 1;
            this.FadeInTMR.Tick += new System.EventHandler(this.FadeInTMR_Tick);
            // 
            // FadeOutTMR
            // 
            this.FadeOutTMR.Interval = 1;
            this.FadeOutTMR.Tick += new System.EventHandler(this.FadeOutTMR_Tick);
            // 
            // Exporting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(317, 100);
            this.ControlBox = false;
            this.Controls.Add(this.label68);
            this.Controls.Add(this.label69);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Exporting";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Exporting_FormClosing);
            this.Load += new System.EventHandler(this.Exporting_Load);
            this.Shown += new System.EventHandler(this.Exporting_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.Timer FadeInTMR;
        private System.Windows.Forms.Timer FadeOutTMR;
    }
}