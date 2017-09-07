using System;
using System.Drawing;
using System.Windows.Forms;

namespace MSAMISUserInterface {
    public partial class SchedViewAssReq : Form {
        private int _numGuards;
        public Shadow Refer;
        public MainForm Reference;

        private string _contractStart;
        private string _contractEnd;

        public SchedViewAssReq() {
            InitializeComponent();
            Opacity = 0;
        }

        public int Raid { get; set; }

        private void FadeTMR_Tick(object sender, EventArgs e) {
            Opacity += 0.2;
            if (Opacity >= 1) FadeTMR.Stop();
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
            _contractStart = ContractStartLBL.Text = "Contract Start: " + dt.Rows[0]["contractstart"];
            _contractEnd = ContractEndLBL.Text = "Contract End: " + dt.Rows[0]["contractend"];
            _numGuards = int.Parse(dt.Rows[0]["noguards"].ToString());
            NoLBL.Text = "Guards Needed: " + _numGuards;
            UnassignedPNL.Visible = false;
            if (dt.Rows[0]["rstatus"].ToString().Equals(Enumeration.RequestStatus.Pending.ToString())) {
                AssignBTN.Text = "APPROVE";
                StatusLBL.Text = "Status: Pending";
                if (Login.AccountType == 2) {
                    AssignBTN.Visible = false;
                    DeclineBTN.Visible = false;
                }
                ApprovedBy.Visible = false;
            }
            else if (dt.Rows[0]["rstatus"].ToString().Equals(Enumeration.RequestStatus.Approved.ToString())) {
                AssignBTN.Text = "ASSIGN";
                StatusLBL.Text = "Status: Approved";
                AssignBTN.Location = new Point(220, 411);
                if (Login.AccountType == 2) AssignBTN.Visible = false;
                DeclineBTN.Visible = false;
                ApprovedBy.Text = "Approved by: " + dt.Rows[0]["uname"];
            }
            else {
                AssignBTN.Visible = false;
                AvailablePNL.Visible = false;
                DeclineBTN.Visible = false;
                if (dt.Rows[0]["rstatus"].ToString().Equals(Enumeration.RequestStatus.Active.ToString())) {
                    StatusLBL.Text = "Status: Active";
                    ApprovedBy.Text = "Approved by: " + dt.Rows[0]["uname"];
                    UnassignedPNL.Visible = true;
                    LoadRequestedGuard();
                } else if (dt.Rows[0]["rstatus"].ToString().Equals(Enumeration.RequestStatus.Inactive.ToString())) {
                    StatusLBL.Text = "Status: Inctive";
                    UnassignedPNL.Visible = true;
                    LoadRequestedGuard();
                } else if (dt.Rows[0]["rstatus"].ToString().Equals(Enumeration.RequestStatus.Declined.ToString())) {
                    StatusLBL.Text = "Status: Decline";
                    ApprovedBy.Text = "Declined by: " + dt.Rows[0]["uname"];
                }
            }
            NeededLBL.ForeColor = _numGuards > Scheduling.GetNumberOfUnassignedGuards()
                ? Color.Salmon
                : Color.OliveDrab;
            NeededLBL.Text = Scheduling.GetUnassignedGuards("", ContractStartLBL.Text, ContractEndLBL.Text).Rows.Count + " available guards";
        }

        private void LoadRequestedGuard() {
            RequestedGRD.DataSource = Scheduling.GetRequestedGuards(Raid);
            RequestedGRD.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            RequestedGRD.Columns[0].Width = 400;
            RequestedGRD.ColumnHeadersVisible = false;
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
                var view = new SchedAssignGuards {
                    Rid = Raid,
                    NumberOfGuards = _numGuards,
                    Refer = this,
                    ClientName = ClientLBL.Text,
                    Location = Location,
                    ContractStart = _contractStart,
                    ContractEnd = _contractEnd
                };
                view.ShowDialog();
            }
            else {
                Scheduling.UpdateRequestStatus(Raid, Enumeration.RequestStatus.Approved, Login.LoggedInUser);
                AssignBTN.Text = "ASSIGN";
                AssignBTN.Location = new Point(220, 411);
                StatusLBL.Text = "Status: Approved";
                DeclineBTN.Visible = false;
                RefreshData();
            }
        }

        private void DeclineBTN_Click(object sender, EventArgs e) {
            Scheduling.DeclineRequest(Raid);
            AssignBTN.Visible = false;
            DeclineBTN.Visible = false;
            AvailablePNL.Visible = false;
            StatusLBL.Text = "Status: Declined";
            RefreshData();
        }
    }
}