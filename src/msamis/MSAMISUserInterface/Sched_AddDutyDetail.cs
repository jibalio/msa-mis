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
        public MainForm reference;
        public MySqlConnection conn;
        public String button = "ADD";
        public int AID { get; set; }

        private bool[] DutyDays = new bool[7];

        public Sched_AddDutyDetail() {
            InitializeComponent();
            this.Opacity = 0;
        }

        private void Sched_AddDutyDetail_Load(object sender, EventArgs e) {
            FadeTMR.Start();
            AddBTN.Text = button;
            TimeInHrBX.SelectedIndex = 0;
            TimeInMinBX.SelectedIndex = 0;
            TimeInAMPMBX.SelectedIndex = 0;
            TimeOutAMPMBX.SelectedIndex = 0;
            TimeOutHrBX.SelectedIndex = 0;
            TimeOutMinBX.SelectedIndex = 0;
        }

        private void Sched_AddDutyDetail_FormClosing(object sender, FormClosingEventArgs e) {
            if (button.Equals("ADD")) { 
                reference.Opacity = 1;
                reference.Show();
            }
        }

        private void FadeTMR_Tick(object sender, EventArgs e) {
            this.Opacity += 0.2;
            if (reference.Opacity == 0.6 || this.Opacity >= 1) { FadeTMR.Stop(); }
            if (reference.Opacity > 0.7) { reference.Opacity -= 0.1; }
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            this.Close();
        }
        Color dark = Color.FromArgb(53, 64, 82);
        Color light = Color.FromArgb(94, 114, 146);

        private void changeDayStatus(int n, Button btn) {
            if (DutyDays[n] == true) {
                DutyDays[n] = false;
                btn.BackColor = light;
            } else if (DutyDays[n] == false) {
                DutyDays[n] = true;
                btn.BackColor = dark;
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

        private void AddBTN_Click(object sender, EventArgs e) {
            Scheduling.AddDutyDetail(AID, TimeInHrBX.Text, TimeInMinBX.Text, TimeInAMPMBX.Text, TimeOutHrBX.Text, TimeOutMinBX.Text, TimeOutAMPMBX.Text, new Scheduling.Days(DutyDays[1], DutyDays[2], DutyDays[3], DutyDays[4], DutyDays[5], DutyDays[6], DutyDays[0]));
        }
    }
}


























































































































































































































