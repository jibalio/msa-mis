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
    public partial class Sched_AddDutyDetail : Form {
        public MySqlConnection conn;
        public String button = "ADD";
        public int AID { get; set; }
        public int DID { get; set; }
        public Sched_ViewDutyDetails refer { get; set; }

        private bool[] DutyDays = new bool[7];

        #region Form Properties
        public Sched_AddDutyDetail() {
            InitializeComponent();
            this.Opacity = 0;
        }
        private void FadeTMR_Tick(object sender, EventArgs e) {
            this.Opacity += 0.2;
            if (this.Opacity >= 1) { FadeTMR.Stop(); }
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            this.Close();
        }
        Color dark = Color.FromArgb(53, 64, 82);
        Color light = Color.White;

        private void changeDayStatus(int n, Button btn) {
            if (DutyDays[n] == true) {
                DutyDays[n] = false;
                btn.BackColor = Color.White;
                btn.ForeColor = dark;
            } else if (DutyDays[n] == false) {
                DutyDays[n] = true;
                btn.BackColor = dark;
                btn.ForeColor = Color.White;
            }
        }

        private void SuBTN_Click(object sender, EventArgs e) {
            changeDayStatus(0, SuBTN);
        }

        private void MBTN_Click(object sender, EventArgs e) {
            changeDayStatus(1, MBTN);
        }

        private void TBTN_Click(object sender, EventArgs e) {
            changeDayStatus(2, TBTN);
        }

        private void WBTN_Click(object sender, EventArgs e) {
            changeDayStatus(3, WBTN);
        }

        private void ThBTN_Click(object sender, EventArgs e) {
            changeDayStatus(4, ThBTN);
        }

        private void FBTN_Click(object sender, EventArgs e) {
            changeDayStatus(5, FBTN);
        }

        private void SaBTN_Click(object sender, EventArgs e) {
            changeDayStatus(6, SaBTN);
        }
        #endregion

        #region Form Load
        private void Sched_AddDutyDetail_Load(object sender, EventArgs e) {
            FadeTMR.Start();
            AddBTN.Text = button;

            if (button.Equals("ADD")) {
                TimeInHrBX.SelectedIndex = 0;
                TimeInMinBX.SelectedIndex = 0;
                TimeInAMPMBX.SelectedIndex = 0;
                TimeOutAMPMBX.SelectedIndex = 0;
                TimeOutHrBX.SelectedIndex = 0;
                TimeOutMinBX.SelectedIndex = 0;
            } else {
                DataTable dt = Scheduling.GetDutyDetailsDetails(DID);
                TimeInHrBX.SelectedIndex = int.Parse(dt.Rows[0][0].ToString())-1;
                TimeInMinBX.SelectedIndex = int.Parse(dt.Rows[0][1].ToString()); 
                TimeInAMPMBX.Text = dt.Rows[0][2].ToString();
                TimeOutHrBX.SelectedIndex = int.Parse(dt.Rows[0][3].ToString()) - 1;
                TimeOutMinBX.SelectedIndex = int.Parse(dt.Rows[0][4].ToString());
                TimeOutAMPMBX.Text = dt.Rows[0][5].ToString();

                bool[] temp = Scheduling.GetDays(DID).Value;
                if (temp[0]) MBTN.PerformClick();
                if (temp[1]) TBTN.PerformClick();
                if (temp[2]) WBTN.PerformClick();
                if (temp[3]) ThBTN.PerformClick();
                if (temp[4]) FBTN.PerformClick();
                if (temp[5]) SaBTN.PerformClick();
                if (temp[6]) SuBTN.PerformClick();
            }
        }


        #endregion

        private bool DataValidation() {
            DaysTLTP.Hide(MBTN);
            HoursTLTP.Hide(HoursLBL);
            bool ret = true;
            if (!DutyDays.Contains(true)) {
                DaysTLTP.ToolTipTitle = "Duty Days";
                DaysTLTP.Show("Please choose at least one day", MBTN);
                ret = false;
            }

            float TimeIn = float.Parse(TimeInHrBX.Text.ToString()) + (float.Parse(TimeInMinBX.Text.ToString()) / 100);
            float TimeOut = float.Parse(TimeOutHrBX.Text.ToString()) + (float.Parse(TimeOutMinBX.Text.ToString()) / 100);
            if (TimeInAMPMBX.SelectedIndex == 1) TimeIn = TimeIn + 12;
            if (TimeOutAMPMBX.SelectedIndex == 1) TimeOut = TimeOut + 12;
            if ((TimeOut - TimeIn) < 8) {
                HoursTLTP.ToolTipTitle = "Duty Hours";
                HoursTLTP.Show("The specified time is less than 8hrs", HoursLBL);
                ret = false;
            }
            if ((TimeOut - TimeIn) < 0) {
                HoursTLTP.ToolTipTitle = "Duty Hours";
                HoursTLTP.Show("Please specify a valid shift", HoursLBL);
                ret = false;
            }
            return ret;
        }

        private void AddBTN_Click(object sender, EventArgs e) {
            if (DataValidation()) { 
                if (button.Equals("ADD")) { 
                    Scheduling.AddDutyDetail(AID, TimeInHrBX.Text, TimeInMinBX.Text, TimeInAMPMBX.Text, TimeOutHrBX.Text, TimeOutMinBX.Text, TimeOutAMPMBX.Text, new Scheduling.Days(DutyDays[1], DutyDays[2], DutyDays[3], DutyDays[4], DutyDays[5], DutyDays[6], DutyDays[0]));
                } else if (button.Equals("UPDATE")) { 
                    Scheduling.UpdateDutyDetail(DID, TimeInHrBX.Text, TimeInMinBX.Text, TimeInAMPMBX.Text, TimeOutHrBX.Text, TimeOutMinBX.Text, TimeOutAMPMBX.Text, new Scheduling.Days(DutyDays[1], DutyDays[2], DutyDays[3], DutyDays[4], DutyDays[5], DutyDays[6], DutyDays[0]));
                }
                this.Close();
                refer.RefreshDutyDetails();
            }
        }
    }
}


























































































































































































































