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
        Attendance A;

        public Sched_ViewDutyDetails() {
            InitializeComponent();
            this.Opacity = 0;
        }

        private void Sched_ViewDutyDetails_Load(object sender, EventArgs e) {
            FadeTMR.Start();
            A = new Attendance(AID);
            RefreshData();
        }

        public void RefreshData() {
            DataTable dt = Scheduling.GetAllAssignmentDetails(AID);
            NameLBL.Text = dt.Rows[0][2].ToString().Split(',')[0];
            FirstNameLBL.Text = dt.Rows[0][2].ToString().Split(',')[1];
            ClientLBL.Text = dt.Rows[0][3].ToString();
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
            view.Location = new Point(this.Location.X + 330, this.Location.Y);
            view.ShowDialog();
        }

        private void EditDaysBTN_Click(object sender, EventArgs e) {
            Sched_AddDutyDays view = new Sched_AddDutyDays();
            view.AID = this.AID;
            view.conn = this.conn;
            view.button = "UPDATE";
            view.reference = this.reference;
            view.Location = new Point(this.Location.X + 330, this.Location.Y);
            view.ShowDialog();
        }

        private void AddDutyDetailsBTN_Click(object sender, EventArgs e) {
            try {
                Sched_AddDutyDetail view = new Sched_AddDutyDetail();
                view.conn = this.conn;
                view.AID = this.AID;
                view.refer = this;
                view.Location = new Point (this.Location.X + 330, this.Location.Y);
                view.ShowDialog();
            }
            catch (Exception) { }
        }

        private void DutyDetailsGRD_CellEnter(object sender, DataGridViewCellEventArgs e) {
            if (DutyDetailsGRD.SelectedRows.Count > 0) {
                DID = int.Parse(DutyDetailsGRD.SelectedRows[0].Cells[0].Value.ToString());
                AddDutyDetailsBTN.Show();
                EditDutyDetailsBTN.Show();
                DismissBTN.Show();
            }
        }

        private void DismissBTN_Click(object sender, EventArgs e) {
            DialogResult x = rylui.RylMessageBox.ShowDialog("Are you sure you want to dismiss the selected assignments?", "Dismiss Assignments", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (x == DialogResult.Yes) {
                Scheduling.DismissDuty(DID);
                RefreshDutyDetails();
            }
        }

        private void CloseBTN_MouseEnter(object sender, EventArgs e) {
            CloseBTN.ForeColor = Color.White;
        }

        private void CloseBTN_MouseLeave(object sender, EventArgs e) {
            CloseBTN.ForeColor = this.BackColor;
        }
    }
}
