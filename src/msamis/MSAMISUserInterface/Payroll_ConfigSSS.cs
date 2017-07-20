using System;
using System.Windows.Forms;

namespace MSAMISUserInterface {
    public partial class Payroll_ConfigSSS : Form {
        public Shadow refer;

        public Payroll_ConfigSSS() {
            InitializeComponent();
            Opacity = 0;
        }

        private void Payroll_ConfigSSS_Load(object sender, EventArgs e) {
            FadeTMR.Start();
        }

        private void FadeTMR_Tick(object sender, EventArgs e) {
            Opacity += 0.2;
            if (Opacity >= 1) { FadeTMR.Stop(); }
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            Close();
        }

        private void Payroll_ConfigSSS_FormClosing(object sender, FormClosingEventArgs e) {
            refer.Close();
        }
    }
}
