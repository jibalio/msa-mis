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
    public partial class Sched_AssignGuards : Form {
        public MySqlConnection conn;
        public int RID { get; set; }
        public int NumberOfGuards { get; set; }
        public String ClientName;
        public Sched_AssignGuards() {
            InitializeComponent();
            this.Opacity = 0;
        }

        private void Sched_AssignGuards_Load(object sender, EventArgs e) {
            LoadPage();
            FadeTMR.Start();
        }
        private void LoadPage() {
            ClientLBL.Text = ClientName;
            UpdateNeeded();

            AvailableGRD.DataSource = Scheduling.GetUnassignedGuards("","name asc");
            AvailableGRD.Columns[0].Visible = false;
            AvailableGRD.Columns[1].HeaderText = "NAME";
            AvailableGRD.Columns[1].Width = 200;
            AvailableGRD.Columns[2].HeaderText = "LOCATION";
            AvailableGRD.Columns[2].Visible = false;
        }
        private void CloseBTN_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void ConfirmBTN_Click(object sender, EventArgs e) {
            int[] GIDs = new int[AssignedGRD.Rows.Count];

            for (int i = 0; i < AssignedGRD.Rows.Count; i++) {
                GIDs[i] = int.Parse(AssignedGRD.Rows[i].Cells[0].Value.ToString());
            }
            Scheduling.AddAssignment(RID, GIDs);
            this.Close();
        }

        private void FadeTMR_Tick(object sender, EventArgs e) {
            this.Opacity += 0.2;
            if (this.Opacity >= 1) { FadeTMR.Stop(); }
        }
        private void AssignBTN_Click(object sender, EventArgs e) {
            AddGuards();
        }

        private void AddGuards (){
            for (int i = 0; i < AvailableGRD.SelectedRows.Count; i++) {
                AssignedGRD.Rows.Add(AvailableGRD.SelectedRows[i].Cells[0].Value.ToString(), AvailableGRD.SelectedRows[i].Cells[1].Value.ToString(), AvailableGRD.SelectedRows[i].Cells[2].Value.ToString());
            }
            foreach (DataGridViewRow row in AvailableGRD.SelectedRows) {
                    AvailableGRD.Rows.Remove(row);
            }
            UpdateNeeded();
        }

        private void UpdateNeeded() {
            if ((NumberOfGuards - AssignedGRD.Rows.Count) >= 0) {
                NeededLBL.Text = NumberOfGuards - AssignedGRD.Rows.Count + " guards still needed";
            } else NeededLBL.Text = "0 guards still needed";
        }
    }
}
