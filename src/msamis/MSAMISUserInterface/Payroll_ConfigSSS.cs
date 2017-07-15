using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSAMISUserInterface {
    public partial class Payroll_ConfigSSS : Form {
        public Shadow refer;

        public Payroll_ConfigSSS() {
            InitializeComponent();
            this.Opacity = 0;
        }

        private void Payroll_ConfigSSS_Load(object sender, EventArgs e) {
            FadeTMR.Start();
        }

        private void FadeTMR_Tick(object sender, EventArgs e) {
            this.Opacity += 0.2;
            if (this.Opacity >= 1) { FadeTMR.Stop(); }
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void Payroll_ConfigSSS_FormClosing(object sender, FormClosingEventArgs e) {
            refer.Close();
        }
    }
}
