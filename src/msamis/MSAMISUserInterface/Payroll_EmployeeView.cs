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
    public partial class Payroll_EmployeeView : Form {
        public int PID { get; set; }
        public MainForm reference;
        public MySqlConnection conn;

        public Shadow refer;

        public Payroll_EmployeeView() {
            InitializeComponent();
            this.Opacity = 0;
        }

        Label currentLBL;
        Panel currentPNL;

        private void Payroll_EmployeeView_Load(object sender, EventArgs e) {
            FadeTMR.Start();
            currentLBL = AdjLBL;
            currentPNL = AdjPNL;
            AdjPNL.Visible = true;
            BonusPNL.Visible = false;
            DeductionsPNL.Visible = false;
            AdjPNL.Visible = false;
        }

        private void ChangePanel(Label newL, Panel newP) {
            currentLBL.ForeColor = Color.Gray;
            currentPNL.Visible = false;
            newL.ForeColor = Color.FromArgb(53, 64, 82);
            newP.Visible = true;
            currentLBL = newL;
            currentPNL = newP;
        }

        private void FadeTMR_Tick(object sender, EventArgs e) {
            this.Opacity += 0.2;
            if (this.Opacity >= 1) { FadeTMR.Stop(); }
        }

        private void Payroll_EmployeeView_FormClosing(object sender, FormClosingEventArgs e) {
            refer.Hide();
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void BonusesLBL_Click(object sender, EventArgs e) {
            ChangePanel(BonusesLBL, BonusPNL);
        }

        private void DeductionsLBL_Click(object sender, EventArgs e) {
            ChangePanel(DeductionsLBL, DeductionsPNL);
        }

        private void AdjLBL_Click(object sender, EventArgs e) {
            ChangePanel(AdjLBL, AdjPNL);
        }

        private void BonusesLBL_MouseEnter(object sender, EventArgs e) {
            BonusesLBL.ForeColor = Color.FromArgb(53, 64, 82);
        }

        private void DeductionsLBL_MouseEnter(object sender, EventArgs e) {
            DeductionsLBL.ForeColor = Color.FromArgb(53, 64, 82);
        }

        private void AdjLBL_MouseEnter(object sender, EventArgs e) {
            AdjLBL.ForeColor = Color.FromArgb(53, 64, 82);
        }

        private void BonusesLBL_MouseLeave(object sender, EventArgs e) {
            if(!BonusPNL.Visible) BonusesLBL.ForeColor = Color.Gray;
        }

        private void DeductionsLBL_MouseLeave(object sender, EventArgs e) {
            if(!DeductionsPNL.Visible) DeductionsLBL.ForeColor = Color.Gray;
        }

        private void AdjLBL_MouseLeave(object sender, EventArgs e) {
            if(!AdjPNL.Visible) AdjLBL.ForeColor = Color.Gray;
        }

        private void BonusAddBTN_Click(object sender, EventArgs e) {
           Payroll_AddAdjustments view = new Payroll_AddAdjustments();
            view.PID = this.PID;
            view.conn = this.conn;
            view.Location = new Point(this.Location.X + 350, this.Location.Y);
            view.ShowDialog();
        }

        private void DedAddBTN_Click(object sender, EventArgs e) {
            Payroll_AddAdjustments view = new Payroll_AddAdjustments();
            view.PID = this.PID;
            view.conn = this.conn;
            view.Location = new Point(this.Location.X + 350, this.Location.Y);
            view.ShowDialog();
        }

        private void CloseBTN_MouseEnter(object sender, EventArgs e) {
            CloseBTN.ForeColor = Color.White;
        }

        private void CloseBTN_MouseLeave(object sender, EventArgs e) {
            CloseBTN.ForeColor = Color.FromArgb(53, 64, 82);
        }
    }
}
