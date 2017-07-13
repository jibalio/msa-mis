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
    public partial class Payroll_ConfigBasicPay : Form {
        public MySqlConnection conn;
        public Shadow refer;

        public Payroll_ConfigBasicPay() {
            InitializeComponent();
            this.Opacity = 0;
        }

        private void FadeTMR_Tick(object sender, EventArgs e) {
            this.Opacity += 0.2;
            if (this.Opacity >= 1) FadeTMR.Stop();
        }

        private void Payroll_ConfigBasicPay_Load(object sender, EventArgs e) {
            this.Location = new Point(this.Location.X + 150, this.Location.Y);
            StartDate.MinDate = DateTime.Now;
            FadeTMR.Start();
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void Payroll_ConfigBasicPay_FormClosing(object sender, FormClosingEventArgs e) {
            refer.Close();
        }

        private void AdjustBTN_Click(object sender, EventArgs e) {
            AdjustPNL.Visible = true;
            CBasicPay.Visible = false;
            AdjustBTN.Visible = false;
        }

        private void CancelBTN_Click(object sender, EventArgs e) {
            AdjustPNL.Visible = false;
            CBasicPay.Visible = true;
            AdjustBTN.Visible = true;
        }

        private void SaveBTN_Click(object sender, EventArgs e) {
            Payroll.AddBasicPay(StartDate.Value, Double.Parse(AdjustMBX.Text.Split('P')[0]));
        }
    }
}
