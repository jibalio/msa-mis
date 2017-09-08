using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using rylui;

namespace MSAMISUserInterface {
    public partial class SchedAddDutyDetail : Form {
        private readonly bool[] _dutyDays = new bool[7];
        public string Button = "ADD";
        public DateTime MaxDate;
        public DateTime MinDate;
        public int Aid { get; set; }
        public int Did { get; set; }
        public SchedViewDutyDetails Refer { get; set; }

        #region Form Load

        private void Sched_AddDutyDetail_Load(object sender, EventArgs e) {
            FadeTMR.Start();
            AddBTN.Text = Button;
            if (Button.Equals("ADD")) {
                TimeInHrBX.SelectedIndex = 0;
                TimeInMinBX.SelectedIndex = 0;
                TimeInAMPMBX.SelectedIndex = 0;
                TimeOutAMPMBX.SelectedIndex = 0;
                TimeOutHrBX.SelectedIndex = 0;
                TimeOutMinBX.SelectedIndex = 0;
                DateDismissedCheck.Checked = true;
                DateDismissed.MaxDate = MaxDate;
                DateDismissed.MinDate = MinDate;
                DateEffective.MinDate = MinDate;
                DateEffective.MaxDate = MaxDate;
            }
            else {
                DateDismissed.MaxDate = MaxDate;
                DateDismissed.MinDate = MinDate;
                DateEffective.MinDate = MinDate;
                DateEffective.MaxDate = MaxDate;

                var dt = Scheduling.GetDutyDetailsDetails(Did);
                TimeInHrBX.SelectedIndex = int.Parse(dt.Rows[0][0].ToString()) - 1;
                TimeInMinBX.SelectedIndex = int.Parse(dt.Rows[0][1].ToString());
                TimeInAMPMBX.Text = dt.Rows[0][2].ToString();
                TimeOutHrBX.SelectedIndex = int.Parse(dt.Rows[0][3].ToString()) - 1;
                TimeOutMinBX.SelectedIndex = int.Parse(dt.Rows[0][4].ToString());
                TimeOutAMPMBX.Text = dt.Rows[0][5].ToString();
                DateEffective.Value = DateTime.Parse(dt.Rows[0][6].ToString());

                if (DateTime.Parse(dt.Rows[0][7].ToString()).Year != 9999) {
                    DateDismissed.Value = DateTime.Parse(dt.Rows[0][7].ToString());
                    DateDismissedCheck.Checked = true;
                }

                var temp = Scheduling.GetDays(Did).Value;
                if (temp[0]) MBTN.PerformClick();
                if (temp[1]) TBTN.PerformClick();
                if (temp[2]) WBTN.PerformClick();
                if (temp[3]) ThBTN.PerformClick();
                if (temp[4]) FBTN.PerformClick();
                if (temp[5]) SaBTN.PerformClick();
                if (temp[6]) SuBTN.PerformClick();

                FormLBL.Text = "Edit Duty Detail";
            }
        }

        #endregion

        #region Form Properties

        public SchedAddDutyDetail() {
            InitializeComponent();
            Opacity = 0;
            CloseBTN.Tag = "0";
        }

        private void SchedAddDutyDetail_FormClosing(object sender, FormClosingEventArgs e) {
            if (!CloseBTN.Tag.ToString().Equals("1")) e.Cancel = true;
        }

        private void FadeTMR_Tick(object sender, EventArgs e) {
            Opacity += 0.2;
            if (Opacity >= 1) FadeTMR.Stop();
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            if (RylMessageBox.ShowDialog("Are you sure you want to stop editing? Unsaved changes will be lost.", "Stop Editing?",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                CloseBTN.Tag = "1";
                Close();
            }
        }

        private readonly Color _dark = Color.FromArgb(53, 64, 82);

        private void ChangeDayStatus(int n, Button btn) {
            if (_dutyDays[n]) {
                _dutyDays[n] = false;
                btn.BackColor = Color.White;
                btn.ForeColor = _dark;
            }
            else if (_dutyDays[n] == false) {
                _dutyDays[n] = true;
                btn.BackColor = _dark;
                btn.ForeColor = Color.White;
            }
        }

        private void SuBTN_Click(object sender, EventArgs e) {
            ChangeDayStatus(0, SuBTN);
        }

        private void MBTN_Click(object sender, EventArgs e) {
            ChangeDayStatus(1, MBTN);
        }

        private void TBTN_Click(object sender, EventArgs e) {
            ChangeDayStatus(2, TBTN);
        }

        private void WBTN_Click(object sender, EventArgs e) {
            ChangeDayStatus(3, WBTN);
        }

        private void ThBTN_Click(object sender, EventArgs e) {
            ChangeDayStatus(4, ThBTN);
        }

        private void FBTN_Click(object sender, EventArgs e) {
            ChangeDayStatus(5, FBTN);
        }

        private void SaBTN_Click(object sender, EventArgs e) {
            ChangeDayStatus(6, SaBTN);
        }

        #endregion

        #region DataValidation and Adding

        private bool DataValidation() {
            DaysTLTP.Hide(MBTN);
            HoursTLTP.Hide(HoursLBL);
            var ret = true;
            if (!_dutyDays.Contains(true)) {
                DaysTLTP.ToolTipTitle = "Duty Days";
                DaysTLTP.Show("Please choose at least one day", MBTN);
                ret = false;
            }
            return ret;
        }
        private void AddBTN_Click(object sender, EventArgs e) {
            if (DataValidation()) {
                if (Button.Equals("ADD")) {
                    var res = Scheduling.AddDutyDetail(Aid, TimeInHrBX.Text, TimeInMinBX.Text, TimeInAMPMBX.Text,
                        TimeOutHrBX.Text, TimeOutMinBX.Text, TimeOutAMPMBX.Text,
                        new Scheduling.Days(_dutyDays[1], _dutyDays[2], _dutyDays[3], _dutyDays[4], _dutyDays[5],
                            _dutyDays[6], _dutyDays[0]), DateEffective.Value, DateDismissedCheck.Checked ? DateDismissed.Value : new DateTime(9999,12,31)); 
                    if (res.Equals(">")) {
                        HoursTLTP.ToolTipTitle = "Duty Details";
                        HoursTLTP.Show("The specified schedule overlaps one of the current duty details.", HoursLBL, 2000);
                    } else {
                        Refer.LoadPage();
                        CloseBTN.Tag = "1";
                        Close();
                    }
                } else if (Button.Equals("UPDATE") && RylMessageBox.ShowDialog("Editing this Duty Details will reset all connected attendance records.\nAre you sure you want to continue?", "Update Duty Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    var res = Scheduling.UpdateDutyDetail(Did, TimeInHrBX.Text, TimeInMinBX.Text,
                        TimeInAMPMBX.Text,
                        TimeOutHrBX.Text, TimeOutMinBX.Text, TimeOutAMPMBX.Text,
                        new Scheduling.Days(_dutyDays[1], _dutyDays[2], _dutyDays[3], _dutyDays[4], _dutyDays[5],
                            _dutyDays[6], _dutyDays[0]));
                    if (DateDismissedCheck.Checked && DateEffective.Checked) Scheduling.UpdateDutyDetailDates(Did, DateEffective.Value, DateDismissed.Value);
                    if (!DateDismissedCheck.Checked) Scheduling.CancelDismissal(Did);
                    if (res.Equals("<")) {
                        if (RylMessageBox.ShowDialog(
                                "The schedule is less than 8hrs. Do you still want to add the details?", "Duty Hours",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                            Refer.LoadPage();
                            CloseBTN.Tag = "1";
                            Close();
                        }
                    } else if (res.Equals(">")) {
                        if (RylMessageBox.ShowDialog(
                                "The schedule is more than 8hrs. Do you still want to add the details?", "Duty Hours",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                            Refer.LoadPage();
                            CloseBTN.Tag = "1";
                            Close();
                        } 
                    } else if (res.Equals("olap")) {
                        HoursTLTP.ToolTipTitle = "Duty Details";
                        HoursTLTP.Show("The specified schedule overlaps one of the current duty details.", HoursLBL, 2000);
                    } 
                    else {
                        Refer.LoadPage();
                        CloseBTN.Tag = "1";
                        Close();
                    }
                }


            }
        }


        #endregion

        private void DateEffective_ValueChanged(object sender, EventArgs e) {
            DateDismissed.MinDate = DateEffective.Value;
        }

        private void DateDismissedCheck_CheckedChanged(object sender, EventArgs e) {
            DateDismissed.Enabled = DateDismissedCheck.Checked;
        }
    }
}