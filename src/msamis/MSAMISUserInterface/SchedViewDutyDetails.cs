using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using rylui;

namespace MSAMISUserInterface {
    public partial class SchedViewDutyDetails : Form {
        private Attendance _attendance;
        private int _did;
        public Shadow Refer;
        public MainForm Reference;
        public int Aid { get; set; }
        public int Gid { get; set; }

        #region Form Initialization and Load

        public SchedViewDutyDetails() {
            InitializeComponent();
            Opacity = 0;
        }

        private const int CsDropshadow = 0x20000;

        protected override CreateParams CreateParams {
            get {
                var cp = base.CreateParams;
                cp.ClassStyle |= CsDropshadow;
                return cp;
            }
        }

        private void Sched_ViewDutyDetails_Load(object sender, EventArgs e) {
            if (Name.Equals("Archived") || Name.Equals("History")) {
                AddDutyDetailsBTN.Visible = false;
                EditDaysBTN.Visible = false;
                PeriodCMBX.Size = new Size(352, 25);
            }
            LoadPage();
            FadeTMR.Start();
            if (Login.AccountType == 2) DismissBTN.Visible = false;
        }

        public void LoadPage() {
            if (!Name.Equals("Archived")) {
                var p = Attendance.GetCurrentPayPeriod();
                _attendance = new Attendance(Aid, p.month, p.period, p.year);
            }
            RefreshDutyDetails();
            RefreshCurrent();
            RefreshData();
            RefreshAttendance();
        }

        public void RefreshData() {
            PeriodCMBX.Items.Clear();
            if (!Name.Equals("Archived")) {
                var dt = Scheduling.GetAllAssignmentDetails(Aid);
                NameLBL.Text = dt.Rows[0][2].ToString().Split(',')[0] + ",";
                FirstNameLBL.Text = dt.Rows[0][2].ToString().Split(',')[1];
                ClientLBL.Text = dt.Rows[0][3].ToString();

                foreach (DataRow row in Attendance.GetPeriods(Gid).Rows)
                    PeriodCMBX.Items.Add(new ComboBoxDays(int.Parse(row["month"].ToString()),
                        int.Parse(row["period"].ToString()), int.Parse(row["year"].ToString())));
                if (PeriodCMBX.Items.Count > 0) PeriodCMBX.SelectedIndex = 0;
            }
            else {
                var dt = Archiver.GetAllAssignmentDetails(Aid);
                NameLBL.Text = dt.Rows[0][2].ToString().Split(',')[0] + ",";
                FirstNameLBL.Text = dt.Rows[0][2].ToString().Split(',')[1];
                ClientLBL.Text = dt.Rows[0][3].ToString();


                foreach (DataRow row in Archiver.GetPeriods(Gid).Rows)
                    PeriodCMBX.Items.Add(new ComboBoxDays(int.Parse(row["month"].ToString()),
                        int.Parse(row["period"].ToString()), int.Parse(row["year"].ToString())));
                if (PeriodCMBX.Items.Count > 0) PeriodCMBX.SelectedIndex = 0;
            }
            if (DutyDetailsGRD.Rows.Count == 0) {
                ErrorPNL.Visible = true;
                ErrorPNL.BringToFront();
            }
            else {
                ErrorPNL.Visible = false;
            }
        }

        public void RefreshCurrent() {
            if (!Name.Equals("Archived")) {
                var dt = Scheduling.GetAssignmentDetails(Aid);
                LocationLBL.Text = dt.Rows[0][0].ToString();
                StartLBL.Text = dt.Rows[0][1].ToString().Split(' ')[0];
                EndLBL.Text = dt.Rows[0][2].ToString().Split(' ')[0];
            }
            else {
                var dt = Archiver.GetAssignmentDetails(Aid);
                LocationLBL.Text = dt.Rows[0][0].ToString();
                StartLBL.Text = dt.Rows[0][1].ToString().Split(' ')[0];
                EndLBL.Text = dt.Rows[0][2].ToString().Split(' ')[0];
            }
        }

        public void RefreshDutyDetails() {
            DutyDetailsGRD.DataSource = !Name.Equals("Archived")
                ? Scheduling.GetDutyDetailsSummary(Aid)
                : Archiver.GetDutyDetailsSummary(Aid);
            DutyDetailsGRD.Columns[0].Visible = false;
            DutyDetailsGRD.Columns[1].HeaderText = "TIME-IN";
            DutyDetailsGRD.Columns[2].HeaderText = "TIME-OUT";
            DutyDetailsGRD.Columns[3].HeaderText = "DAYS";

            DutyDetailsGRD.Columns[1].Width = 150;
            DutyDetailsGRD.Columns[2].Width = 150;
            DutyDetailsGRD.Columns[3].Width = 150;

            DutyDetailsGRD.Select();
        }

        public void RefreshAttendance() {
            if (!Name.Equals("Archived")) {
                AttendanceGRD.DataSource = _attendance.GetAttendance_View(
                    ((ComboBoxDays)PeriodCMBX.SelectedItem).Month,
                    ((ComboBoxDays)PeriodCMBX.SelectedItem).Period, ((ComboBoxDays)PeriodCMBX.SelectedItem).Year);
                AttendanceGRD.Columns[8].Visible = false;
                AttendanceGRD.Columns[9].Visible = false;
                AttendanceGRD.Columns[10].Visible = false;
                AttendanceGRD.Columns[11].Visible = false;
            }
            else {
                AttendanceGRD.DataSource = Archiver.GetAttendance(Gid, ((ComboBoxDays) PeriodCMBX.SelectedItem).Month,
                    ((ComboBoxDays) PeriodCMBX.SelectedItem).Period, ((ComboBoxDays) PeriodCMBX.SelectedItem).Year);
            }

            AttendanceGRD.Columns[0].Visible = false;
            AttendanceGRD.Columns[1].Visible = false;
            AttendanceGRD.Columns[2].Width = 140;
            AttendanceGRD.Sort(AttendanceGRD.Columns[2], ListSortDirection.Ascending);
            AttendanceGRD.Columns[2].HeaderText = "DAY / SCHEDULE";
            AttendanceGRD.Columns[3].Width = 120;
            AttendanceGRD.Columns[3].HeaderText = "IN-OUT";
            AttendanceGRD.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            AttendanceGRD.Columns[4].Width = 50;
            AttendanceGRD.Columns[4].HeaderText = "RD";
            AttendanceGRD.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            AttendanceGRD.Columns[5].Width = 50;
            AttendanceGRD.Columns[5].HeaderText = "RN";
            AttendanceGRD.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
            AttendanceGRD.Columns[6].Width = 50;
            AttendanceGRD.Columns[6].HeaderText = "HD";
            AttendanceGRD.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
            AttendanceGRD.Columns[7].Width = 60;
            AttendanceGRD.Columns[7].HeaderText = "HN";
            AttendanceGRD.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
            AttendanceGRD.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;



            if (!Name.Equals("Archived")) {
                var attendance = new Attendance(Aid, ((ComboBoxDays) PeriodCMBX.SelectedItem).Month,
                    ((ComboBoxDays) PeriodCMBX.SelectedItem).Period, ((ComboBoxDays) PeriodCMBX.SelectedItem).Year);
                var hrs = attendance.GetAttendanceSummary();
                AShiftLBL.Text = hrs.GetNormalDay() + " hrs";
                ANightLBL.Text = hrs.GetNormalNight() + " hrs";
                AHShiftLBL.Text = hrs.GetHolidayDay() + " hrs";
                AHNightLBL.Text = hrs.GetHolidayNight() + " hrs";


                ACertifiedLBL.Text = attendance.GetCertifiedBy().Equals("")
                    ? "Unedited Attendance"
                    : attendance.GetCertifiedBy();

                try {
                    string[] tooltip = attendance.GetAttendanceTooltip();

                    OrdinaryDay.Items[3].Text = tooltip[0];
                    OrdinaryDay.Items[4].Text = tooltip[1];
                    OrdinaryDay.Items[6].Text = tooltip[2];
                    OrdinaryDay.Items[7].Text = tooltip[3];

                    OrdinaryNight.Items[3].Text = tooltip[4];
                    OrdinaryNight.Items[4].Text = tooltip[5];
                    OrdinaryNight.Items[6].Text = tooltip[6];
                    OrdinaryNight.Items[7].Text = tooltip[7];

                    HolidayDay.Items[3].Text = tooltip[8];
                    HolidayDay.Items[4].Text = tooltip[9];
                    HolidayDay.Items[6].Text = tooltip[10];
                    HolidayDay.Items[7].Text = tooltip[11];
                    HolidayDay.Items[11].Text = tooltip[12];
                    HolidayDay.Items[12].Text = tooltip[13];
                    HolidayDay.Items[14].Text = tooltip[14];
                    HolidayDay.Items[15].Text = tooltip[15];

                    HolidayNight.Items[3].Text = tooltip[16];
                    HolidayNight.Items[4].Text = tooltip[17];
                    HolidayNight.Items[6].Text = tooltip[18];
                    HolidayNight.Items[7].Text = tooltip[19];
                    HolidayNight.Items[11].Text = tooltip[20];
                    HolidayNight.Items[12].Text = tooltip[21];
                    HolidayNight.Items[14].Text = tooltip[22];
                    HolidayNight.Items[15].Text = tooltip[23];
                }
                catch (Exception exception) {
                    Console.WriteLine(exception);
                }

            } else {
                var attendance = Archiver.GetAttendanceSummary(((ComboBoxDays) PeriodCMBX.SelectedItem).Year,
                    ((ComboBoxDays) PeriodCMBX.SelectedItem).Month,
                    ((ComboBoxDays) PeriodCMBX.SelectedItem).Period, Gid);

                AShiftLBL.Text = attendance.Rows[0][4] + " hrs";
                ANightLBL.Text = attendance.Rows[0][5] + " hrs";
                AHShiftLBL.Text = attendance.Rows[0][2] + " hrs";
                AHNightLBL.Text = attendance.Rows[0][3] + " hrs";


                ACertifiedLBL.Text = attendance.Rows[0][1].ToString();
               
                try {
                    string[] tooltip = Archiver.GetAttendanceTooltip(Aid, ((ComboBoxDays)PeriodCMBX.SelectedItem).Period, ((ComboBoxDays)PeriodCMBX.SelectedItem).Month, ((ComboBoxDays)PeriodCMBX.SelectedItem).Year);

                    OrdinaryDay.Items[3].Text = tooltip[0];
                    OrdinaryDay.Items[4].Text = tooltip[1];
                    OrdinaryDay.Items[6].Text = tooltip[2];
                    OrdinaryDay.Items[7].Text = tooltip[3];

                    OrdinaryNight.Items[3].Text = tooltip[4];
                    OrdinaryNight.Items[4].Text = tooltip[5];
                    OrdinaryNight.Items[6].Text = tooltip[6];
                    OrdinaryNight.Items[7].Text = tooltip[7];

                    HolidayDay.Items[3].Text = tooltip[8];
                    HolidayDay.Items[4].Text = tooltip[9];
                    HolidayDay.Items[6].Text = tooltip[10];
                    HolidayDay.Items[7].Text = tooltip[11];
                    HolidayDay.Items[11].Text = tooltip[12];
                    HolidayDay.Items[12].Text = tooltip[13];
                    HolidayDay.Items[14].Text = tooltip[14];
                    HolidayDay.Items[15].Text = tooltip[15];

                    HolidayNight.Items[3].Text = tooltip[16];
                    HolidayNight.Items[4].Text = tooltip[17];
                    HolidayNight.Items[6].Text = tooltip[18];
                    HolidayNight.Items[7].Text = tooltip[19];
                    HolidayNight.Items[11].Text = tooltip[20];
                    HolidayNight.Items[12].Text = tooltip[21];
                    HolidayNight.Items[14].Text = tooltip[22];
                    HolidayNight.Items[15].Text = tooltip[23];
                }
                catch (Exception exception) {
                    Console.WriteLine(exception);
                }

            }
        }

        private static void ArchiveLoadAttendance() {
            
        }

        #endregion

        #region Form Props

        private void FadeTMR_Tick(object sender, EventArgs e) {
            Opacity += 0.2;
            if (Opacity >= 1) FadeTMR.Stop();
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            if (!Name.Equals("Archived") && !Name.Equals("History")) Reference.SchedRefreshAssignments();
            Close();
        }

        private void Sched_ViewDutyDetails_FormClosing(object sender, FormClosingEventArgs e) {
            if (!Name.Equals("Archived") && !Name.Equals("History")) Refer.Hide();
        }

        private void EditDutyDetailsBTN_Click(object sender, EventArgs e) {
            var view = new SchedAddDutyDetail {
                Aid = Aid,
                Button = "UPDATE",
                Refer = this,
                Did = _did,
                Location = new Point(Location.X + 330, Location.Y)
            };
            view.ShowDialog();
        }

        private void EditDaysBTN_Click(object sender, EventArgs e) {
            var view = new SchedAddDutyDays {
                Aid = Aid,
                Button = "UPDATE",
                Reference = this,
                Location = new Point(Location.X + 330, Location.Y)
            };

            view.ShowDialog();
        }

        private void AddDutyDetailsBTN_Click(object sender, EventArgs e) {
            var view = new SchedAddDutyDetail {
                Aid = Aid,
                Refer = this,
                Location = new Point(Location.X + 330, Location.Y)
            };
            view.ShowDialog();
        }

        private void DutyDetailsGRD_CellEnter(object sender, DataGridViewCellEventArgs e) {
            if (DutyDetailsGRD.SelectedRows.Count > 0) {
                _did = int.Parse(DutyDetailsGRD.SelectedRows[0].Cells[0].Value.ToString());
                if (Login.AccountType != 2) DismissBTN.Visible = true;
                EditDutyDetailsBTN.Visible = true;

                if (Name.Equals("Archived") || Name.Equals("History")) {
                    AddDutyDetailsBTN.Visible = false;
                    DismissBTN.Visible = false;
                    EditDutyDetailsBTN.Visible = false;
                }
            }
        }

        private void DismissBTN_Click(object sender, EventArgs e) {
            var x = RylMessageBox.ShowDialog("Are you sure you want to dismiss the selected schedule?",
                "Dismiss Schedule", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (x == DialogResult.Yes) {
                Scheduling.DismissDuty(_did);
                LoadPage();
            }
            if (DutyDetailsGRD.Rows.Count == 0) {
                DismissBTN.Visible = false;
                EditDutyDetailsBTN.Visible = false;
            }
        }

        private void CloseBTN_MouseEnter(object sender, EventArgs e) {
            CloseBTN.ForeColor = Color.White;
        }

        private void CloseBTN_MouseLeave(object sender, EventArgs e) {
            CloseBTN.ForeColor = BackColor;
        }

        private void PeriodCMBX_SelectedIndexChanged(object sender, EventArgs e) {
            RefreshAttendance();
            if (PeriodCMBX.SelectedIndex == 0) {
                EditDaysBTN.Visible = true;
                PeriodCMBX.Size = new Size(257, 25);
            }
            else if (PeriodCMBX.SelectedIndex > 0) {
                EditDaysBTN.Visible = false;
                PeriodCMBX.Size = new Size(352, 25);
            }

            if (Name.Equals("Archived") || Name.Equals("History")) {
                EditDaysBTN.Visible = false;
                PeriodCMBX.Size = new Size(352, 25);
            }
        }

        #endregion

        #region Form Navigation

        private readonly Color _dark = Color.FromArgb(53, 64, 82);
        private readonly Color _light = Color.DarkGray;

        private void AttendanceLBL_Click(object sender, EventArgs e) {
            AttendanceLBL.ForeColor = _dark;
            DutyDetailsLBL.ForeColor = _light;
            DutyDetailsPNL.Visible = false;
            AttendancePNL.Visible = true;
        }

        private void DutyDetailsLBL_Click(object sender, EventArgs e) {
            DutyDetailsLBL.ForeColor = _dark;
            AttendanceLBL.ForeColor = _light;
            DutyDetailsPNL.Visible = true;
            AttendancePNL.Visible = false;
        }

        private void AttendanceLBL_MouseEnter(object sender, EventArgs e) {
            AttendanceLBL.ForeColor = _dark;
        }

        private void DutyDetailsLBL_MouseEnter(object sender, EventArgs e) {
            DutyDetailsLBL.ForeColor = _dark;
        }

        private void AttendanceLBL_MouseLeave(object sender, EventArgs e) {
            if (!AttendancePNL.Visible) AttendanceLBL.ForeColor = _light;
        }

        private void DutyDetailsLBL_MouseLeave(object sender, EventArgs e) {
            if (!DutyDetailsPNL.Visible) DutyDetailsLBL.ForeColor = _light;
        }

        #endregion

        private static void ShowPopup(ToolStripDropDown cms, Control cntrl) {
            cms.Show(cntrl, new Point(cntrl.Size.Width + 5, -cms.Height+cntrl.Height));
        }

        private static void HidePop(Control cms) {
            cms.Hide();
        }

        private void RDSLBL_MouseEnter(object sender, EventArgs e) {
            ShowPopup(OrdinaryDay, RDSLBL);
        }

        private void RNSLBL_MouseEnter(object sender, EventArgs e) {
            ShowPopup(OrdinaryNight, RNSLBL);
        }

        private void HDSLBL_MouseEnter(object sender, EventArgs e) {
            ShowPopup(HolidayDay, HDSLBL);
        }

        private void HNSLBL_MouseEnter(object sender, EventArgs e) {
            ShowPopup(HolidayNight, HNSLBL);
        }

        private void HNSLBL_MouseLeave(object sender, EventArgs e) {
            HidePop(HolidayNight);
        }

        private void HDSLBL_MouseLeave(object sender, EventArgs e) {
            HidePop(HolidayDay);
        }

        private void RNSLBL_MouseLeave(object sender, EventArgs e) {
            HidePop(OrdinaryNight);
        }

        private void RDSLBL_MouseLeave(object sender, EventArgs e) {
            HidePop(OrdinaryDay);
        }
    }
}