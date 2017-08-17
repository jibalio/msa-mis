using System;
using System.Windows.Forms;

namespace MSAMISUserInterface {
    public partial class SchedViewAssHistory : Form {
        public Shadow Refer;
        public int Gid;
        public string GuardName;


        public SchedViewAssHistory() {
            InitializeComponent();
            Opacity = 0;
        }

        private void SchedViewAssHistory_Load(object sender, EventArgs e) {
            FadeTMR.Start();
            LoadTable();
            NameLBL.Text = GuardName;
        }

        private void LoadTable() {
            AssignmentsGRD.DataSource = Scheduling.GetAssignmentHistory(Gid);
        }

        private void FadeTMR_Tick(object sender, EventArgs e) {
            Opacity += 0.2;
            if (Opacity >= 1) FadeTMR.Stop();
        }

        private void SchedViewAssHistory_FormClosing(object sender, FormClosingEventArgs e) {
            Refer.Hide();
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            Close();
        }

        private void SGuardHistoryViewBTN_Click(object sender, EventArgs e) {
            var view = new SchedViewDutyDetails {
                Gid = Gid,
                Location = Location,
                Name = "Archived"
            };
            view.ShowDialog();
        }

        private void AssignmentsGRD_DoubleClick(object sender, EventArgs e) {
            SGuardHistoryViewBTN.PerformClick();
        }
    }
}
