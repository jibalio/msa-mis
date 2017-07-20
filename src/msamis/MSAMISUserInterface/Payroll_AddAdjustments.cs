using System;
using System.Windows.Forms;

namespace MSAMISUserInterface {
    public partial class Payroll_AddAdjustments : Form {
        public int PID { get; set; }
        public int Mode;

        #region Form Properties
        public Payroll_AddAdjustments() {
            InitializeComponent();
            Opacity = 0;
        }
        private void FadeTMR_Tick(object sender, EventArgs e) {
            Opacity += 0.2;
            if (Opacity >= 1) { FadeTMR.Stop(); }
        }

        private void Payroll_AddAdjustments_FormClosing(object sender, FormClosingEventArgs e) {
        }

        private void Payroll_AddAdjustments_Load(object sender, EventArgs e) {
            FadeTMR.Start();
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            Close();
        }
        #endregion
        
        private bool DataValidation() {
            var ret = true;
            return ret;
        }
        private void AddBTN_Click(object sender, EventArgs e) {
            if (DataValidation()) {

            }
        }
    }
}
