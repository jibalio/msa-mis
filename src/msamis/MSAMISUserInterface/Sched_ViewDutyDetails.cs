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
        String GName;
        String Client;
        Attendance A;

        public Sched_ViewDutyDetails() {
            InitializeComponent();
            this.Opacity = 0;
        }

        private void Sched_ViewDutyDetails_Load(object sender, EventArgs e) {
            FadeTMR.Start();
            A = new Attendance(AID);
            DutyDaysPNL.Visible = false;
            DutyDetailsPNL.Visible = true;
        }

        public void RefreshData() {
            DataTable dt = Scheduling.GetAllAssignmentDetails(AID);
            GName = NameLBL.Text = dt.Rows[0][2].ToString();
            Client = ClientLBL.Text = dt.Rows[0][3].ToString();
            RefreshDutyDetails();
        }

        public void RefreshDutyDetails() {
            DutyDetailsGRD.DataSource = Scheduling.GetDutyDetailsSummary(AID);
            DutyDetailsGRD.Columns[0].Visible = false;
            DutyDetailsGRD.Columns[1].HeaderText = "TIME-IN";
            DutyDetailsGRD.Columns[2].HeaderText = "TIME-OUT";
            DutyDetailsGRD.Columns[3].HeaderText = "DAYS";

            DutyDetailsGRD.Columns[1].Width = 150;
            DutyDetailsGRD.Columns[2].Width = 150;
            DutyDetailsGRD.Columns[3].Width = 150;

            DutyDetailsGRD.Select();

            foreach (DataRow row in Attendance.GetPeriods(AID).Rows) {
                PeriodCMBX.Items.Add(new ComboBoxDays(AID, int.Parse(row["month"].ToString()), int.Parse(row["period"].ToString()), int.Parse(row["year"].ToString())));
            }
            if (PeriodCMBX.Items.Count > 0) PeriodCMBX.SelectedIndex = 0;
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
        private int DID;
        private void EditDutyDetailsBTN_Click(object sender, EventArgs e) {
            Sched_AddDutyDetail view = new Sched_AddDutyDetail();
            view.AID = this.AID;
            view.button = "UPDATE";
            view.refer = this;
            view.conn = this.conn;
            view.DID = this.DID;
            view.Name = this.GName;
            view.Client = this.Client;
            view.Location = this.Location;
            view.ShowDialog();
        }

        private void EditDaysBTN_Click(object sender, EventArgs e) {
            Sched_AddDutyDays view = new Sched_AddDutyDays();
            view.AID = this.AID;
            view.conn = this.conn;
            view.button = "UPDATE";
            view.Name = this.GName;
            view.Client = this.Client;
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
                view.Name = this.GName;
                view.refer = this;
                view.Client = this.Client;
                view.Location = this.Location;
                view.ShowDialog();
            }
            catch (Exception) { }
        }

        private void DutyDetailsGRD_CellEnter(object sender, DataGridViewCellEventArgs e) {
            if (DutyDetailsGRD.SelectedRows.Count > 0) {
                DID = int.Parse(DutyDetailsGRD.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void DismissBTN_Click(object sender, EventArgs e) {
            Scheduling.DismissDuty(DID);
            RefreshDutyDetails();

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) {

        }
    }
}
