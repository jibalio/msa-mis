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
    public partial class Sched_ViewAssReq : Form {
        public int RAID { get; set; }
        public MainForm reference;
        public MySqlConnection conn;

        int numGuards;

        public Sched_ViewAssReq() {
            InitializeComponent();
            this.Opacity = 0;
        }

        private void FadeTMR_Tick(object sender, EventArgs e) {
            this.Opacity += 0.2;
            if (reference.Opacity == 0.6 || this.Opacity >= 1) { FadeTMR.Stop(); }
            if (reference.Opacity > 0.7) { reference.Opacity -= 0.1; }
        }

        private void Sched_ViewAssReq_Load(object sender, EventArgs e) {
            RefreshData();
            FadeTMR.Start();
        }
        private void RefreshData() {
            DataTable dt = Scheduling.GetAssignmentRequestDetails(RAID);
            ClientLBL.Text = dt.Rows[0]["name"].ToString();
            PermAddLBL.Text = "Location: " + dt.Rows[0]["location"].ToString();
            ContractStartLBL.Text = "Contract Start: " + dt.Rows[0]["contractstart"].ToString();
            ContractEndLBL.Text = "Contract End: " + dt.Rows[0]["contractend"].ToString();
            numGuards = int.Parse(dt.Rows[0]["noguards"].ToString());
            NoLBL.Text = "Guards Needed: " + numGuards.ToString();

            if (dt.Rows[0]["rstatus"].ToString().Equals(Enumeration.RequestStatus.Pending.ToString())) {
                AssignBTN.Text = "APPROVE";
            } else if (dt.Rows[0]["rstatus"].ToString().Equals(Enumeration.RequestStatus.Approved.ToString())) {
                AssignBTN.Text = "ASSIGN";
            } else {
                AssignBTN.Visible = false;
                AvailablePNL.Visible = false;
                CloseBTN.Location = new Point(305, 600); 
            }


            if (numGuards > Scheduling.GetNumberOfUnassignedGuards()) NeededLBL.ForeColor = Color.Coral;
            else NeededLBL.ForeColor = Color.YellowGreen;

            NeededLBL.Text = Scheduling.GetNumberOfUnassignedGuards().ToString() + " available guards";
        }

        private void Sched_ViewAssReq_FormClosing(object sender, FormClosingEventArgs e) {
            reference.Opacity = 1;
            reference.Show();
        }

        private void button1_Click(object sender, EventArgs e) {
            this.Close();
            reference.SCHEDLoadPage();
        }

        private void AssignBTN_Click(object sender, EventArgs e) {
            if (AssignBTN.Text.Equals("ASSIGN")) {
                try {
                    Sched_AssignGuards view = new Sched_AssignGuards();
                    view.conn = this.conn;
                    view.RID = this.RAID;
                    view.NumberOfGuards = numGuards;
                    view.refer = this;
                    view.ClientName = ClientLBL.Text;
                    view.Location = this.Location;
                    view.ShowDialog();
                }
                catch (Exception) { }
            } else {
                Scheduling.UpdateRequestStatus(RAID, Enumeration.RequestStatus.Approved);
                AssignBTN.Text = "ASSIGN";
            }
        }
    }
}
