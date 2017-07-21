using System;
using System.Drawing;
using System.Windows.Forms;

namespace MSAMISUserInterface {
    public partial class PayrollConfigBasicPay : Form {
        public Shadow Refer;

        public PayrollConfigBasicPay() {
            InitializeComponent();
            Opacity = 0;
        }

        private void FadeTMR_Tick(object sender, EventArgs e) {
            Opacity += 0.2;
            if (Opacity >= 1) FadeTMR.Stop();
        }

        private void Payroll_ConfigBasicPay_Load(object sender, EventArgs e) {
            Location = new Point(Location.X + 150, Location.Y);
            StartDate.MinDate = DateTime.Now;
            FadeTMR.Start();
            LoadPage();
        }

        private void LoadPage() {
            BasicPayGRD.DataSource = Payroll.GetBasicPayHistory();
            BasicPayGRD.Columns[0].Visible = false;
            BasicPayGRD.Columns[1].HeaderText = "AMOUNT";
            BasicPayGRD.Columns[1].Width = 100;
            BasicPayGRD.Columns[2].HeaderText = "STARTING DATE";
            BasicPayGRD.Columns[2].Width = 140;
            BasicPayGRD.Columns[3].HeaderText = "ENDING DATE";
            BasicPayGRD.Columns[3].Width = 140;
            BasicPayGRD.Columns[4].HeaderText = "STATUS";
            BasicPayGRD.Columns[4].Width = 100;

            if (Payroll.GetCurrentBasicPay().Length == 7)
                CBasicPay.Text = "₱ " + Payroll.GetCurrentBasicPay().Insert(1, " ");
            else CBasicPay.Text = "₱ " + Payroll.GetCurrentBasicPay();
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            Close();
        }

        private void Payroll_ConfigBasicPay_FormClosing(object sender, FormClosingEventArgs e) {
            Refer.Close();
        }

        private void AdjustBTN_Click(object sender, EventArgs e) {
            AdjustPNL.Visible = true;
            CurrentPNL.Visible = false;
            BasicPayGRD.Size = new Size(500,160);
            AdjustMBX.Text = "0 000.00";
        }

        private void CancelBTN_Click(object sender, EventArgs e) {
            AdjustPNL.Visible = false;
            CurrentPNL.Visible = true;
            BasicPayGRD.Size = new Size(500, 220);
        }

        private void SaveBTN_Click(object sender, EventArgs e) {
            if (DataVal()) { 
                Payroll.AddBasicPay(StartDate.Value, float.Parse(AdjustMBX.Text.Substring(2).Replace(" ", String.Empty)));
                LoadPage();
                CancelBTN.PerformClick();
            }
        }

        private bool DataVal() {
            var ret = true;

            if (double.Parse(AdjustMBX.Text.Substring(2).Replace(" ", string.Empty)).Equals(0.0) ) {
                InputTLTP.ToolTipTitle = "Adjustment Value";
                InputTLTP.Show("Please specify a valid value", AdjustMBX);
                ret = false;
            }
            return ret;
        }

        private void AdjustMBX_TextChanged(object sender, EventArgs e) {
            InputTLTP.Hide(AdjustMBX);
        }
    }
}
