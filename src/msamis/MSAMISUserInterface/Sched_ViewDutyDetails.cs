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

        public Shadow refer;

        private Attendance A;
        private int DID;

        #region Form Initialization and Load
        public Sched_ViewDutyDetails() {
            InitializeComponent();
            this.Opacity = 0;
        }
        private void Sched_ViewDutyDetails_Load(object sender, EventArgs e) {
            FadeTMR.Start();
            Attendance.Period p = Attendance.GetCurrentPayPeriod(0);
            A = new Attendance(AID, p.month, p.period, p.year);
            RefreshData();
            
        }
        public void RefreshData() {
            DataTable dt = Scheduling.GetAllAssignmentDetails(AID);
            NameLBL.Text = dt.Rows[0][2].ToString().Split(',')[0];
            FirstNameLBL.Text = dt.Rows[0][2].ToString().Split(',')[1];
            ClientLBL.Text = dt.Rows[0][3].ToString();

            Attendance.Hours hrs = A.GetAttendanceSummary();
            RShiftLBL.Text = hrs.GetNormalDay() + " hrs";
            RNightLBL.Text = hrs.GetNormalNight() + " hrs";
            HShiftLBL.Text = hrs.GetHolidayDay() + " hrs";
            HNightLBL.Text = hrs.GetHolidayNight() + " hrs";
            CertifiedLBL.Text = A.GetCertifiedBy();

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
                PeriodCMBX.Items.Add(new ComboBoxDays(int.Parse(row["month"].ToString()), int.Parse(row["period"].ToString()), int.Parse(row["year"].ToString())));
            }
            if (PeriodCMBX.Items.Count > 0) PeriodCMBX.SelectedIndex = 0;
        }
        public void RefreshAttendance() {
            AttendanceGRD.DataSource = A.GetAttendance_View(((ComboBoxDays)PeriodCMBX.SelectedItem).Month, ((ComboBoxDays)PeriodCMBX.SelectedItem).Period, ((ComboBoxDays)PeriodCMBX.SelectedItem).Year);
            AttendanceGRD.Columns[0].Visible = false;
            AttendanceGRD.Columns[1].Visible = false;
            AttendanceGRD.Columns[2].Width = 140;
            AttendanceGRD.Sort(AttendanceGRD.Columns[2], ListSortDirection.Ascending);
            AttendanceGRD.Columns[2].HeaderText = "DAY / SCHEDULE";
            AttendanceGRD.Columns[3].Width = 120;
            AttendanceGRD.Columns[3].HeaderText = "IN-OUT";
            AttendanceGRD.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            AttendanceGRD.Columns[4].Width = 50;
            AttendanceGRD.Columns[4].HeaderText = "REG";
            AttendanceGRD.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            AttendanceGRD.Columns[5].Width = 50;
            AttendanceGRD.Columns[5].HeaderText = "NIGHT";
            AttendanceGRD.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
            AttendanceGRD.Columns[6].Width = 50;
            AttendanceGRD.Columns[6].HeaderText = "OT";
            AttendanceGRD.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
            AttendanceGRD.Columns[7].Width = 60;
            AttendanceGRD.Columns[7].HeaderText = "HOLIDAY";
            AttendanceGRD.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
            AttendanceGRD.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            Attendance B = new Attendance(AID, ((ComboBoxDays)PeriodCMBX.SelectedItem).Month, ((ComboBoxDays)PeriodCMBX.SelectedItem).Period, ((ComboBoxDays)PeriodCMBX.SelectedItem).Year);
            Attendance.Hours hrs = B.GetAttendanceSummary();
            AShiftLBL.Text = hrs.GetNormalDay();
            ANightLBL.Text = hrs.GetNormalNight();
            AHShiftLBL.Text = hrs.GetHolidayDay();
            AHNightLBL.Text = hrs.GetHolidayNight();
            ACertifiedLBL.Text = B.GetCertifiedBy();

            Attendance.Hours hrp = A.GetAttendanceSummary();
            RShiftLBL.Text = hrp.GetNormalDay() + " hrs";
            RNightLBL.Text = hrp.GetNormalNight() + " hrs";
            HShiftLBL.Text = hrp.GetHolidayDay() + " hrs";
            HNightLBL.Text = hrp.GetHolidayNight() + " hrs";
            CertifiedLBL.Text = A.GetCertifiedBy();
        }
        #endregion

        #region Form Props
        private void FadeTMR_Tick(object sender, EventArgs e) {
            this.Opacity += 0.2;
            if (this.Opacity >= 1) { FadeTMR.Stop(); }
        }
        private void CloseBTN_Click(object sender, EventArgs e) {
            reference.SCHEDRefreshAssignments();
            this.Close();
        }
        private void Sched_ViewDutyDetails_FormClosing(object sender, FormClosingEventArgs e) {
            refer.Hide();
        }
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
            view.reference = this;
            view.Location = new Point(this.Location.X + 330, this.Location.Y);
            view.ShowDialog();
        }

        private void AddDutyDetailsBTN_Click(object sender, EventArgs e) {
            try {
                Sched_AddDutyDetail view = new Sched_AddDutyDetail();
                view.conn = this.conn;
                view.AID = this.AID;
                view.refer = this;
                view.Location = new Point(this.Location.X + 330, this.Location.Y);
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

        private void PeriodCMBX_SelectedIndexChanged(object sender, EventArgs e) {
            RefreshAttendance();
            if (PeriodCMBX.SelectedIndex == 0) {
                EditDaysBTN.Visible = true;
                PeriodCMBX.Size = new System.Drawing.Size(257, 25);
            } else if (PeriodCMBX.SelectedIndex > 0) {
                EditDaysBTN.Visible = false;
                PeriodCMBX.Size = new System.Drawing.Size(352, 25);
            }

            

        }
        #endregion

        #region Form Navigation
        Color dark = Color.FromArgb(53, 64, 82);
        Color light = Color.DarkGray;

        private void AttendanceLBL_Click(object sender, EventArgs e) {
            AttendanceLBL.ForeColor = dark;
            DutyDetailsLBL.ForeColor = light;
            DutyDetailsPNL.Visible = false;
            AttendancePNL.Visible = true;
        }

        private void DutyDetailsLBL_Click(object sender, EventArgs e) {
            DutyDetailsLBL.ForeColor = dark;
            AttendanceLBL.ForeColor = light;
            DutyDetailsPNL.Visible = true;
            AttendancePNL.Visible = false;
        }

        private void AttendanceLBL_MouseEnter(object sender, EventArgs e) {
            AttendanceLBL.ForeColor = dark;
        }

        private void DutyDetailsLBL_MouseEnter(object sender, EventArgs e) {
            DutyDetailsLBL.ForeColor = dark;
        }

        private void AttendanceLBL_MouseLeave(object sender, EventArgs e) {
            if (!AttendancePNL.Visible) AttendanceLBL.ForeColor = light;
        }

        private void DutyDetailsLBL_MouseLeave(object sender, EventArgs e) {
            if (!DutyDetailsPNL.Visible) DutyDetailsLBL.ForeColor = light;
        }
        #endregion



    }
}
