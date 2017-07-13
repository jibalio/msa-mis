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
            LoadPage();
        }

        private void LoadPage() {
            BasicPayGRD.DataSource = Payroll.GetBasicPayHistory();
            BasicPayGRD.Columns[0].Visible = false;
            BasicPayGRD.Columns[1].HeaderText = "AMOUNT";
            BasicPayGRD.Columns[1].Width = 100;
            BasicPayGRD.Columns[2].HeaderText = "STARTING DATE";
            BasicPayGRD.Columns[2].Width = 150;
            BasicPayGRD.Columns[3].HeaderText = "ENDING DATE";
            BasicPayGRD.Columns[3].Width = 150;
            BasicPayGRD.Columns[4].HeaderText = "STATUS";
            BasicPayGRD.Columns[4].Width = 100;


            CBasicPay.Text = "₱ " + Payroll.GetCurrentBasicPay().Insert(1, " ");
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
            Payroll.AddBasicPay(StartDate.Value, float.Parse(AdjustMBX.Text.Substring(2).Replace(" ", String.Empty)));
            LoadPage();
            CancelBTN.PerformClick();
        }
    }
}
