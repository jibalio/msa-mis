using System;
using System.Drawing;
using System.Windows.Forms;

namespace MSAMISUserInterface {
    public partial class PayrollConfigSss : Form {
        public Shadow Refer;

        public PayrollConfigSss() {
            InitializeComponent();
            Opacity = 0;
        }

        private void Payroll_ConfigSSS_Load(object sender, EventArgs e) {
            FadeTMR.Start();
            LoadTable();
        }

        private void LoadTable() {
            SSSGRD.DataSource = Payroll.GetSssContribTable();
            SSSGRD.Columns[0].Visible = false;
            SSSGRD.Columns[1].HeaderText = "RANGE START";
            SSSGRD.Columns[1].Width = 140;
            SSSGRD.Columns[2].HeaderText = "RANGE END";
            SSSGRD.Columns[2].Width = 140;
            SSSGRD.Columns[3].HeaderText = "CONTRIBUTION";
            SSSGRD.Columns[3].Width = 140;
        }

        private void FadeTMR_Tick(object sender, EventArgs e) {
            Opacity += 0.2;
            if (Opacity >= 1) { FadeTMR.Stop(); }
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            Close();
        }

        private void Payroll_ConfigSSS_FormClosing(object sender, FormClosingEventArgs e) {
            Refer.Close();
        }

        private void SSSPnl_Enter(object sender, EventArgs e) {
            SSSPnl.BackColor = Color.White;
            SSScon.ForeColor = RatesPNL.BackColor;
            SSSlbl.ForeColor = RatesPNL.BackColor;
        }

        private void SSSPnl_Leave(object sender, EventArgs e) {
            SSSPnl.BackColor = RatesPNL.BackColor;
            SSScon.ForeColor = Color.White;
            SSSlbl.ForeColor = Color.White;
        }

        private void TaxPnl_MouseEnter(object sender, EventArgs e) {
            TaxPnl.BackColor = Color.White;
            TaxLbl.ForeColor = RatesPNL.BackColor;
            TaxConLbl.ForeColor = RatesPNL.BackColor;
        }

        private void TaxPnl_MouseLeave(object sender, EventArgs e) {
            TaxPnl.BackColor = RatesPNL.BackColor;
            TaxLbl.ForeColor = Color.White;
            TaxConLbl.ForeColor = Color.White;
        }

        private void CloseBTN_MouseEnter(object sender, EventArgs e) {
            CloseBTN.ForeColor = Color.White;
        }

        private void CloseBTN_MouseLeave(object sender, EventArgs e) {
            CloseBTN.ForeColor = RatesPNL.BackColor;
        }
    }
}
