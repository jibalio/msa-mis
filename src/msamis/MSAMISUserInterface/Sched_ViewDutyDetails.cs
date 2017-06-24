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
    public partial class Sched_ViewDutyDetails : Form {
        public int AID { get; set; }
        public MainForm reference;
        public MySqlConnection conn;

        public Sched_ViewDutyDetails() {
            InitializeComponent();
            this.Opacity = 0;
        }

        private void Sched_ViewDutyDetails_Load(object sender, EventArgs e) {
            //RefreshData();
            FadeTMR.Start();
            DutyDaysPNL.Visible = false;
            DutyDetailsPNL.Visible = true;
        }

        private void FadeTMR_Tick(object sender, EventArgs e) {
            this.Opacity += 0.2;
            if (reference.Opacity == 0.6 || this.Opacity >= 1) { FadeTMR.Stop(); }
            if (reference.Opacity > 0.7) { reference.Opacity -= 0.1; }
        }

        private void Sched_ViewDutyDetails_FormClosing(object sender, FormClosingEventArgs e) {
            reference.Opacity = 1;
            reference.Show();
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            reference.SCHEDRefreshAssignments();
            this.Close();
        }

        private void EditDutyDetailsBTN_Click(object sender, EventArgs e) {
            Sched_AddDutyDetail view = new Sched_AddDutyDetail();
            view.AID = this.AID;
            view.button = "UPDATE";
            view.conn = this.conn;
            view.Location = this.Location;
            view.ShowDialog();
        }

        private void EditDaysBTN_Click(object sender, EventArgs e) {
            Sched_AddDutyDays view = new Sched_AddDutyDays();
            view.AID = this.AID;
            view.conn = this.conn;
            view.button = "UPDATE";
            view.reference = this.reference;
            view.Location = this.Location;
            view.ShowDialog();
        }

        private void DutyDetailsLBL_Click(object sender, EventArgs e) {
            DutyDaysPNL.Visible = false;
            DutyDetailsPNL.Visible = true;
            DutyDaysLBL.ForeColor = Color.Gray;
        }

        private void DutyDetailsLBL_MouseLeave(object sender, EventArgs e) {
            if (DutyDetailsPNL.Visible == false) DutyDetailsLBL.ForeColor = Color.Gray;
        }

        private void DutyDaysLBL_MouseLeave(object sender, EventArgs e) {
            if (DutyDaysPNL.Visible == false) DutyDaysLBL.ForeColor = Color.Gray;
        }

        private void DutyDaysLBL_MouseEnter(object sender, EventArgs e) {
            DutyDaysLBL.ForeColor = Color.White;
        }

        private void DutyDetailsLBL_MouseEnter(object sender, EventArgs e) {
            DutyDetailsLBL.ForeColor = Color.White;
        }

        private void DutyDaysLBL_Click(object sender, EventArgs e) {
            DutyDaysPNL.Visible = true;
            DutyDetailsPNL.Visible = false;
            DutyDetailsLBL.ForeColor = Color.Gray;
        }

        private void AddDutyDetailsBTN_Click(object sender, EventArgs e) {
            try {
                Sched_AddDutyDetail view = new Sched_AddDutyDetail();
                view.conn = this.conn;
                view.AID = this.AID;
                view.Location = this.Location;
                view.ShowDialog();
            }
            catch (Exception) { }
        }
    }
}
