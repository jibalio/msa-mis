using System;
using System.Data;
using System.Windows.Forms;
using rylui;

namespace MSAMISUserInterface {
    public partial class SchedAddDutyDays : Form {
        private Attendance _attendance;
        public string Button = "ADD";
        public SchedViewDutyDetails Reference;
        public int Aid { get; set; }

        #region Form Properties and Load

        public SchedAddDutyDays() {
            InitializeComponent();
            Opacity = 0;
        }

        private void SAddDutyDays_Load(object sender, EventArgs e) {
            LoadPage();
            FadeTMR.Start();
        }

        private void FadeTMR_Tick(object sender, EventArgs e) {
            Opacity += 0.2;
            if (Opacity >= 1) FadeTMR.Stop();
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            if (RylMessageBox.ShowDialog("Are you sure you want to stop editing?", "Stop Editing?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Close();
        }

        private void LoadPage() {
            var p = Attendance.GetCurrentPayPeriod();
            _attendance = new Attendance(Aid, p.month, p.period, p.year);
            RefreshData();
        }

        #endregion

        #region Form Props

        private void ConfirmBTN_Click(object sender, EventArgs e) {
            if (DataValidation()) {
                foreach (DataGridViewRow row in DaysGRD.Rows)
                    _attendance.SetAttendance(int.Parse(row.Cells[0].Value.ToString()),
                        int.Parse(row.Cells[2].Value.ToString()), int.Parse(row.Cells[4].Value.ToString()),
                        row.Cells[5].Value.ToString(), int.Parse(row.Cells[6].Value.ToString()),
                        int.Parse(row.Cells[8].Value.ToString()), row.Cells[9].Value.ToString());
                _attendance.SetCertifiedBy(Aid, CertifiedBX.Text);
                Reference.RefreshAttendance();
                Close();
            }
        }

        private void DaysGRD_CellEnter(object sender, DataGridViewCellEventArgs e) {
            if (DaysGRD.Rows[DaysGRD.CurrentCell.RowIndex].Cells[DaysGRD.CurrentCell.ColumnIndex].ReadOnly)
                SendKeys.Send("{Tab}");
        }

        #endregion

        #region Data Refresh and Validation

        private bool DataValidation() {
            var ret = true;
            if (CertifiedBX.Text.Equals("")) {
                CertifiedTLTP.ToolTipTitle = "Certification";
                CertifiedTLTP.Show("Who certified this attendanca?", CertifiedBX);
                ret = false;
            }
            return ret;
        }

        private void RefreshData() {
            if (_attendance.GetAttendance_View().Rows.Count > 0) {
                foreach (DataRow row in _attendance.GetAttendance().Rows)
                    DaysGRD.Rows.Add(row[0], row[2], row[5].ToString().Split(':')[0], ":",
                        row[5].ToString().Split(':')[1].Split(' ')[0], row[5].ToString().Split(':')[1].Split(' ')[1],
                        row[6].ToString().Split(':')[0], ":", row[6].ToString().Split(':')[1].Split(' ')[0],
                        row[6].ToString().Split(':')[1].Split(' ')[1], "0");
                DaysGRD.CurrentCell = DaysGRD.Rows[0].Cells[1];
            }
            CertifiedBX.Text = _attendance.GetCertifiedBy();
        }

        #endregion
    }
}