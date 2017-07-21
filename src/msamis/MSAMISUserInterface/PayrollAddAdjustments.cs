using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MSAMISUserInterface {
    public partial class PayrollAddAdjustments : Form {
        public int Pid { get; set; }
        public string Period;
        public Payroll Pay;
        private readonly Dictionary<string, double> Data = new Dictionary<string, double> {
            {"thirteen", 0},
            {"Cola", 0},
            {"Emergency", 0},
            {"CashBonds", 0},
            {"CashAdv", 0}
        };

        #region Form Properties
        public PayrollAddAdjustments() {
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
            InitializeData();
            PayrollPeriodLBL.Text = Period;
        }

        private void InitializeData() {
            UpdateKeys("thirteen",Pay.thirteen, ThirteenBX);
            UpdateKeys("Cola", Pay.cola, ColaBX);
            UpdateKeys("Emergency", Pay.emerallowance, EmergencyBX);
            UpdateKeys("CashBonds", Pay.cashbond, BondsBX);
            UpdateKeys("CashAdv", Pay.cashadv, AdvBX);
        }

        private void UpdateKeys(string key, double value, NumericUpDown bx) {
            bx.Value = decimal.Parse(value.ToString());
            Data[key] = value;
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
            if (Data["thirteen"].ToString().Equals(ThirteenBX.Value.ToString())) {
            }


            if (DataValidation()) {

            }
        }
    }
}
