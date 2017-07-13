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
        }
        private void FadeTMR_Tick(object sender, EventArgs e) {
            this.Opacity += 0.2;
            if (this.Opacity >= 1) { FadeTMR.Stop(); }
        }

        private void Payroll_AddAdjustments_FormClosing(object sender, FormClosingEventArgs e) {
        }

        private void Payroll_AddAdjustments_Load(object sender, EventArgs e) {
            FadeTMR.Start();
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            this.Close();
        }
        #endregion
        
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
