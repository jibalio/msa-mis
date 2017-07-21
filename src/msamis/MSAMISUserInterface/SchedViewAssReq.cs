using System;
using System.Drawing;
using System.Windows.Forms;

namespace MSAMISUserInterface {
    public partial class SchedViewAssReq : Form {
        public int Raid { get; set; }
        public MainForm Reference;
        public Shadow Refer;

        private int _numGuards;

        public SchedViewAssReq() {
            InitializeComponent();
            Opacity = 0;
        }

        private void FadeTMR_Tick(object sender, EventArgs e) {
            Opacity += 0.2;
            if (Opacity >= 1) { FadeTMR.Stop(); }
        }

        private void Sched_ViewAssReq_Load(object sender, EventArgs e) {
            RefreshData();
            Location = new Point(Location.X + 175, Location.Y);
            FadeTMR.Start();
        }
        private void RefreshData() {
            var dt = Scheduling.GetAssignmentRequestDetails(Raid);
            ClientLBL.Text = dt.Rows[0]["name"].ToString();
            PermAddLBL.Text = "Location: " + dt.Rows[0]["location"];
            ContractStartLBL.Text = "Contract Start: " + dt.Rows[0]["contractstart"];
            ContractEndLBL.Text = "Contract End: " + dt.Rows[0]["contractend"];
            _numGuards = int.Parse(dt.Rows[0]["noguards"].ToString());
            NoLBL.Text = "Guards Needed: " + _numGuards;
            if (dt.Rows[0]["rstatus"].ToString().Equals(Enumeration.RequestStatus.Pending.ToString())) {
                AssignBTN.Text = "APPROVE";
                StatusLBL.Text = "Status: Pending";
            } else if (dt.Rows[0]["rstatus"].ToString().Equals(Enumeration.RequestStatus.Approved.ToString())) {
                AssignBTN.Text = "ASSIGN";
                StatusLBL.Text = "Status: Approved";
                AssignBTN.Location = new Point(220, 411);
                DeclineBTN.Visible = false;

            } else {
                AssignBTN.Visible = false;
                AvailablePNL.Visible = false;
                DeclineBTN.Visible = false;
                if (dt.Rows[0]["rstatus"].ToString().Equals(Enumeration.RequestStatus.Active.ToString())) StatusLBL.Text = "Status: Active";
                else if (dt.Rows[0]["rstatus"].ToString().Equals(Enumeration.RequestStatus.Inactive.ToString())) StatusLBL.Text = "Status: Inctive";
                else if (dt.Rows[0]["rstatus"].ToString().Equals(Enumeration.RequestStatus.Declined.ToString())) StatusLBL.Text = "Status: Decline";
            }
            var b = (_numGuards > Scheduling.GetNumberOfUnassignedGuards()) ? NeededLBL.ForeColor = Color.Salmon : NeededLBL.ForeColor = Color.OliveDrab;
            NeededLBL.Text = Scheduling.GetNumberOfUnassignedGuards().ToString() + " available guards";
        }

        private void Sched_ViewAssReq_FormClosing(object sender, FormClosingEventArgs e) {
            Refer.Hide();
            Reference.SchedLoadPage();
        }

        private void button1_Click(object sender, EventArgs e) {
            Close();
        }

        private void AssignBTN_Click(object sender, EventArgs e) {
            if (AssignBTN.Text.Equals("ASSIGN")) {
                try {
                    var view = new SchedAssignGuards {
                        Rid = Raid,
                        NumberOfGuards = _numGuards,
                        Refer = this,
                        ClientName = ClientLBL.Text,
                        Location = Location
                    };
                    view.ShowDialog();
                }
                catch (Exception) { }
            } else {
                Scheduling.UpdateRequestStatus(Raid, Enumeration.RequestStatus.Approved);
                AssignBTN.Text = "ASSIGN";
                AssignBTN.Location = new Point(220, 411);
                StatusLBL.Text = "Status: Approved";
                DeclineBTN.Visible = false;
            }
        }

        private void DeclineBTN_Click(object sender, EventArgs e) {
            Scheduling.DeclineRequest(Raid);
            AssignBTN.Visible = false;
            DeclineBTN.Visible = false;
            AvailablePNL.Visible = false;
            StatusLBL.Text = "Status: Declined";
        }
    }
}
