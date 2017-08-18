using System;
using System.Drawing;
using System.Windows.Forms;

namespace MSAMISUserInterface {
    public partial class SchedViewAssHistory : Form {
        public int Gid;
        public string GuardName;
        public Shadow Refer;


        public SchedViewAssHistory() {
            InitializeComponent();
            Opacity = 0;
        }

        private void SchedViewAssHistory_Load(object sender, EventArgs e) {
            Location = new Point(Location.X + 200, Location.Y);
            FadeTMR.Start();
            LoadTable();
            NameLBL.Text = GuardName;
        }

        private void LoadTable() {
            if (!Name.Equals("Archived")) {
                AssignmentsGRD.DataSource = Scheduling.GetAssignmentHistory(Gid);
                AssignmentsGRD.Columns[0].Visible = false;
                AssignmentsGRD.Columns[0].Visible = false;
                AssignmentsGRD.Columns[1].HeaderText = "ASSIGNED AT";
                AssignmentsGRD.Columns[1].Width = 200;
                AssignmentsGRD.Columns[2].HeaderText = "ASSIGNED";
                AssignmentsGRD.Columns[2].Width = 100;
                AssignmentsGRD.Columns[3].HeaderText = "UNASSIGNED";
                AssignmentsGRD.Columns[3].Width = 100;
            }
            else {
                AssignmentsGRD.Location = new Point(AssignmentsGRD.Location.X + 60, AssignmentsGRD.Location.Y);
                AssignmentsGRD.Size = new Size(AssignmentsGRD.Size.Width - 50, AssignmentsGRD.Size.Height);
                AssignmentsGRD.DataSource = Archiver.GetAssignmentHistory(Gid);
                AssignmentsGRD.Columns[0].Visible = false;
                AssignmentsGRD.Columns[1].HeaderText = "ASSIGNED ON";
                AssignmentsGRD.Columns[1].Width = 100;
                AssignmentsGRD.Columns[2].Visible = false;
                AssignmentsGRD.Columns[3].HeaderText = "ASSIGNED AT";
                AssignmentsGRD.Columns[3].Width = 200;
            }
        }

        private void FadeTMR_Tick(object sender, EventArgs e) {
            Opacity += 0.2;
            if (Opacity >= 1) FadeTMR.Stop();
        }

        private void SchedViewAssHistory_FormClosing(object sender, FormClosingEventArgs e) {
            Refer.Close();
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            Close();
        }

        private void SGuardHistoryViewBTN_Click(object sender, EventArgs e) {
            var view = new SchedViewDutyDetails {
                Gid = Gid,
                Aid = int.Parse(AssignmentsGRD.SelectedRows[0].Cells[0].Value.ToString()),
                Location = new Point(Location.X - 200, Location.Y),
                Name = Name.Equals("Archived") ? "Archived" : "History"
            };
            view.ShowDialog();
        }

        private void AssignmentsGRD_DoubleClick(object sender, EventArgs e) {
            SGuardHistoryViewBTN.PerformClick();
        }
    }
}