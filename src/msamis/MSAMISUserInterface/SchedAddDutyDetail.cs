using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using rylui;

namespace MSAMISUserInterface {
    public partial class SchedAddDutyDetail : Form {
        private readonly bool[] _dutyDays = new bool[7];
        public string Button = "ADD";
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
            }
            else {
                var dt = Scheduling.GetDutyDetailsDetails(Did);
                TimeInHrBX.SelectedIndex = int.Parse(dt.Rows[0][0].ToString()) - 1;
                TimeInMinBX.SelectedIndex = int.Parse(dt.Rows[0][1].ToString());
                TimeInAMPMBX.Text = dt.Rows[0][2].ToString();
                TimeOutHrBX.SelectedIndex = int.Parse(dt.Rows[0][3].ToString()) - 1;
                TimeOutMinBX.SelectedIndex = int.Parse(dt.Rows[0][4].ToString());
                TimeOutAMPMBX.Text = dt.Rows[0][5].ToString();

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

        private void FadeTMR_Tick(object sender, EventArgs e) {
            Opacity += 0.2;
            if (Opacity >= 1) FadeTMR.Stop();
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            if (RylMessageBox.ShowDialog("Are you sure you want to stop editing?", "Stop Editing?",
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

            var ti = new TimeSpan(0, int.Parse(TimeInHrBX.Text), int.Parse(TimeInMinBX.Text), 0);
            var to = new TimeSpan(0, int.Parse(TimeOutHrBX.Text), int.Parse(TimeOutMinBX.Text), 0);

            if (TimeInAMPMBX.SelectedIndex == 1 && TimeOutAMPMBX.SelectedIndex == 0) {
                ti = new TimeSpan(0, int.Parse(TimeInHrBX.Text) + 12, int.Parse(TimeInMinBX.Text), 0);
                to = new TimeSpan(1, int.Parse(TimeOutHrBX.Text), int.Parse(TimeOutMinBX.Text), 0);
            }
            else if (TimeInAMPMBX.SelectedIndex == 0 && TimeOutAMPMBX.SelectedIndex == 1) {
                to = new TimeSpan(0, int.Parse(TimeOutHrBX.Text) + 12, int.Parse(TimeOutMinBX.Text), 0);
            }
            /*
            if (to.TotalHours - ti.TotalHours < 9) {
                HoursTLTP.ToolTipTitle = "Duty Hours";
                HoursTLTP.Show("The specified time is less than 8hrs", HoursLBL);
                ret = false;
            }
            else if (to.TotalHours - ti.TotalHours > 9) {
                HoursTLTP.ToolTipTitle = "Duty Hours";
                HoursTLTP.Show("The specified time is more than 8hrs", HoursLBL);
                ret = false;
            }*/
            return ret;
        }

        private void AddBTN_Click(object sender, EventArgs e) {
            if (DataValidation()) {

                
                    if (Button.Equals("ADD")) {
                        string res = Scheduling.AddDutyDetail(Aid, TimeInHrBX.Text, TimeInMinBX.Text, TimeInAMPMBX.Text,
                                                TimeOutHrBX.Text, TimeOutMinBX.Text, TimeOutAMPMBX.Text,
                                                new Scheduling.Days(_dutyDays[1], _dutyDays[2], _dutyDays[3], _dutyDays[4], _dutyDays[5],
                                                _dutyDays[6], _dutyDays[0]));
                        if (res.Equals("<")) {
                        HoursTLTP.ToolTipTitle = "Duty Hours";
                        HoursTLTP.Show("The specified time is less than 8hrs", HoursLBL);
                        } else if
                            (res.Equals(">")) {
                            HoursTLTP.ToolTipTitle = "Duty Hours";
                            HoursTLTP.Show("The specified time is more than 8hrs", HoursLBL);
                    } else {
                            Close();
                            Refer.LoadPage();
                        }
                } else if (Button.Equals("UPDATE")) {
                        string res = Scheduling.UpdateDutyDetail(Did, TimeInHrBX.Text, TimeInMinBX.Text,
                                    TimeInAMPMBX.Text,
                                    TimeOutHrBX.Text, TimeOutMinBX.Text, TimeOutAMPMBX.Text,
                                    new Scheduling.Days(_dutyDays[1], _dutyDays[2], _dutyDays[3], _dutyDays[4], _dutyDays[5],
                                        _dutyDays[6], _dutyDays[0]));
                        if (res.Equals("<")) {
                        HoursTLTP.ToolTipTitle = "Duty Hours";
                            HoursTLTP.Show("The specified time is less than 8hrs", HoursLBL);
                    } else if (res.Equals(">")) {
                            HoursTLTP.ToolTipTitle = "Duty Hours";
                            HoursTLTP.Show("The specified time is more than 8hrs", HoursLBL);
                        }
                        else {
                        Close();
                            Refer.LoadPage();
                    }
                    }
                    
                
            }
        }

        #endregion

        private void SchedAddDutyDetail_FormClosing(object sender, FormClosingEventArgs e) {
            if (!CloseBTN.Tag.ToString().Equals("1")) e.Cancel = true;
        }
    }
}