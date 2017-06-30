using MySql.Data.MySqlClient;
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
    public partial class Payroll_AddAdjustments : Form {
        public int PID { get; set; }
        public MySqlConnection conn;
        public int Mode;

        #region Form Properties
        public Payroll_AddAdjustments() {
            InitializeComponent();
            this.Opacity = 0;
            ChangeMode();
        }
        private void FadeTMR_Tick(object sender, EventArgs e) {
            this.Opacity += 0.2;
            if (this.Opacity >= 1) { FadeTMR.Stop(); }
        }

        private void Payroll_AddAdjustments_FormClosing(object sender, FormClosingEventArgs e) {
            FadeTMR.Start();
        }

        private void Payroll_AddAdjustments_Load(object sender, EventArgs e) {
            FadeTMR.Start();
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            this.Close();
        }
        #endregion

        private void ChangeMode() {
            switch (Mode) {
                case 1:
                    DAdjBTN.Enabled = false;
                    DCashAdvBTN.Enabled = false;
                    DStoreCreditBTN.Enabled = false;
                    DSocialBenefitBTN.Enabled = false;
                    DCashBondBTN.Enabled = false;
                    break;
                case 2:
                    B13MonthBTN.Enabled = false;
                    BColaBTN.Enabled = false;
                    BAdjBTN.Enabled = false;
                    break;
            }

        }
        private bool DataValidation() {
            bool ret = true;
         /*   if (float.Parse(ValueMBX.Text.ToString()) < 0) {
                ValueTLTP.ToolTipTitle = "Value";
                ValueTLTP.Show("Please enter a valid amount", ValueMBX);
                ret = false;
            }*/

            if (Mode == 1) {


            }
            return ret;
        }
        private void AddBTN_Click(object sender, EventArgs e) {
            if (DataValidation()) {

            }
        }
    }
}
