using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MSAMISUserInterface {
    public partial class PayrollAddAdjustments : Form {
        private readonly Dictionary<string, double> _data = new Dictionary<string, double> {
            {"thirteen", 0},
            {"Cola", 0},
            {"Emergency", 0},
            {"CashBonds", 0},
            {"CashAdv", 0}
        };

        public Payroll Pay;
        public PayrollEmployeeView Refer;
        public string Period;
        public int Pid { get; set; }

        private void AddBTN_Click(object sender, EventArgs e) {
            bool[] changes =  {false, false, false, false, false};
            var changeText = "Are you sure you want to change these values?\n";
            if (!_data["thirteen"].ToString("N2").Equals(ThirteenBX.Value.ToString("N2"))) {
                changes[0] = true;
                changeText += "Thirteenth Month Pay: " + _data["thirteen"].ToString("N2") + " to " + ThirteenBX.Value.ToString("N2") + "\n"; 
            }

            if (!_data["Cola"].ToString("N2").Equals(ColaBX.Value.ToString("N2"))) {
                changes[1] = true;
                changeText += "Cola: " + _data["Cola"].ToString("N2") + " to " + ColaBX.Value.ToString("N2") + "\n";
            }

            if (!_data["Emergency"].ToString("N2").Equals(EmergencyBX.Value.ToString("N2"))) {
                changes[2] = true;
                changeText += "Emergency: " + _data["Emergency"].ToString("N2") + " to " + EmergencyBX.Value.ToString("N2") + "\n";
            }

            if (!_data["CashBonds"].ToString("N2").Equals(BondsBX.Value.ToString("N2"))) {
                changes[3] = true;
                changeText += "Cash Bonds: " + _data["CashBonds"].ToString("N2") + " to " + BondsBX.Value.ToString("N2") + "\n";
            }

            if (!_data["CashAdv"].ToString("N2").Equals(AdvBX.Value.ToString("N2"))) {
                changes[4] = true;
                changeText += "Cash Advance: " + _data["CashAdv"].ToString("N2") + " to " + AdvBX.Value.ToString("N2"); 
            }
            if (!changeText.Equals("Are you sure you want to change these values?")) {
                if(rylui.RylMessageBox.ShowDialog(changeText, "Confirm Chnages", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes ){ 
                if (changes[0]) Pay.ThirteenthMonthPay = double.Parse(ThirteenBX.Value.ToString("N2"));
                if (changes[1]) Pay.Cola = double.Parse(ColaBX.Value.ToString("N2"));
                if (changes[2]) Pay.EmergencyAllowance = double.Parse(EmergencyBX.Value.ToString("N2"));
                if (changes[3]) Pay.CashBond = double.Parse(BondsBX.Value.ToString("N2"));
                if (changes[4]) Pay.CashAdvance = double.Parse(AdvBX.Value.ToString("N2"));
                }
                Refer.LoadAjustments();
                Close();
            }
            else
                rylui.RylMessageBox.ShowDialog("No Changes", "There are no changes to commit", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        #region Form Properties

        public PayrollAddAdjustments() {
            InitializeComponent();
            Opacity = 0;
        }

        private void FadeTMR_Tick(object sender, EventArgs e) {
            Opacity += 0.2;
            if (Opacity >= 1) FadeTMR.Stop();
        }

        private void Payroll_AddAdjustments_FormClosing(object sender, FormClosingEventArgs e) {
            Refer.Close();
                Refer.LoadComputations();
        }

        private void Payroll_AddAdjustments_Load(object sender, EventArgs e) {
            FadeTMR.Start();
            InitializeData();
            PayrollPeriodLBL.Text = Period;
        }

        private void InitializeData() {
            UpdateKeys("thirteen", Pay.ThirteenthMonthPay, ThirteenBX);
            UpdateKeys("Cola", Pay.Cola, ColaBX);
            UpdateKeys("Emergency", Pay.EmergencyAllowance, EmergencyBX);
            UpdateKeys("CashBonds", Pay.CashBond, BondsBX);
            UpdateKeys("CashAdv", Pay.CashAdvance, AdvBX);
        }

        private void UpdateKeys(string key, double value, NumericUpDown bx) {
            bx.Value = decimal.Parse(value.ToString("N2"));
            _data[key] = value;
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            if (rylui.RylMessageBox.ShowDialog("Are you sure you want to stop editing?", "Stop Editing?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Close();
        }

        #endregion
    }
}