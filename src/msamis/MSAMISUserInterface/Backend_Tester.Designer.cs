namespace MSAMISUserInterface {
    partial class Backend_Tester {
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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.dtreturn = new System.Windows.Forms.Label();
            this.dtq = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.esrq = new System.Windows.Forms.TextBox();
            this.result = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(77, 63);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(560, 253);
            this.dgv.TabIndex = 0;
            // 
            // dtreturn
            // 
            this.dtreturn.AutoSize = true;
            this.dtreturn.Location = new System.Drawing.Point(13, 13);
            this.dtreturn.Name = "dtreturn";
            this.dtreturn.Size = new System.Drawing.Size(57, 13);
            this.dtreturn.TabIndex = 1;
            this.dtreturn.Text = "DataTable";
            // 
            // dtq
            // 
            this.dtq.Location = new System.Drawing.Point(77, 7);
            this.dtq.Multiline = true;
            this.dtq.Name = "dtq";
            this.dtq.Size = new System.Drawing.Size(557, 50);
            this.dtq.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 329);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "ExecuteSingleResult()";
            // 
            // esrq
            // 
            this.esrq.Location = new System.Drawing.Point(77, 345);
            this.esrq.Multiline = true;
            this.esrq.Name = "esrq";
            this.esrq.Size = new System.Drawing.Size(557, 50);
            this.esrq.TabIndex = 4;
            // 
            // result
            // 
            this.result.Location = new System.Drawing.Point(77, 401);
            this.result.Multiline = true;
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(557, 50);
            this.result.TabIndex = 5;
            // 
            // Backend_Tester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 480);
            this.Controls.Add(this.result);
            this.Controls.Add(this.esrq);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtq);
            this.Controls.Add(this.dtreturn);
            this.Controls.Add(this.dgv);
            this.Name = "Backend_Tester";
            this.Text = "z";
            this.Load += new System.EventHandler(this.Backend_Tester_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label dtreturn;
        private System.Windows.Forms.TextBox dtq;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox esrq;
        private System.Windows.Forms.TextBox result;
    }
}