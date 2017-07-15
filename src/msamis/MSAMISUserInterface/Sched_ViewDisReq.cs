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
    public partial class Sched_ViewDisReq : Form {
        public int RID { get; set; }
        public MainForm reference;

        public Shadow refer;

        public Sched_ViewDisReq() {
            InitializeComponent();
            this.Opacity = 0;
        }

        private void Sched_ViewDisReq_Load(object sender, EventArgs e) {
            RefreshData();
            this.Location = new Point(this.Location.X + 175, this.Location.Y);
            FadeTMR.Start();
        }
        private void RefreshData() {
            DataTable dt = Scheduling.GetUnassignmentRequestDetails(RID);
            ClientLBL.Text = dt.Rows[0][0].ToString();
            if (dt.Rows[0][1].ToString().Equals("Approved")) {
                ApproveBTN.Visible = false;
                DeclineBTN.Visible = false;
                NameLBL.Text = "Guards Unassigned";
            } else if (dt.Rows[0][1].ToString().Equals("Pending")) {
                ApproveBTN.Visible = true;
                DeclineBTN.Visible = true;
            } else {
                ApproveBTN.Visible = false;
                DeclineBTN.Visible = false;
                NameLBL.Text = "Declined Request to Unassign";
            }

                AssignedGRD.DataSource = Scheduling.GetGuardsToBeUnassigned(RID);
            AssignedGRD.Columns[0].Visible = false;
            AssignedGRD.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            AssignedGRD.Columns[1].Width = 400;
            AssignedGRD.ColumnHeadersVisible = false;

        }
        private void FadeTMR_Tick(object sender, EventArgs e) {
            this.Opacity += 0.2;
            if (this.Opacity >= 1) { FadeTMR.Stop(); }
        }

        private void Sched_ViewDisReq_FormClosing(object sender, FormClosingEventArgs e) {
            refer.Hide();
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void ApproveBTN_Click(object sender, EventArgs e) {
            Scheduling.ApproveUnassignment(RID);
            reference.SCHEDLoadPage();
            this.Close();
        }

        private void DeclineBTN_Click(object sender, EventArgs e) {
            Scheduling.DeclineRequest(RID);
            ApproveBTN.Visible = false;
            DeclineBTN.Visible = false;
            reference.SCHEDRefreshRequests();
        }
    }
}
