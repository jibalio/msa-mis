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
        public Sched_ViewAssReq refer { get; set; }
        public int RID { get; set; }
        public int NumberOfGuards { get; set; }
        public String ClientName;

        int[] GIDs = { -1 };

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
            AvailablePNL.Visible = true;
            AssignedPNL.Visible = false;
            RefreshAvailable();
            AssignedGRD.Columns[0].Visible = false;
            AssignedGRD.Columns[1].HeaderText = "NAME";
            AssignedGRD.Columns[1].Width = 210;
            AssignedGRD.Columns[2].HeaderText = "LOCATION";
            AssignedGRD.Columns[2].Width = 210;
            UpdateNeeded();
        }
        private void RefreshAvailable() {
            AvailableGRD.Rows.Clear();
            DataTable dt = Scheduling.GetUnassignedGuards("", "name asc");
            foreach (DataRow row in dt.Rows) {
                if (!GIDs.Contains(int.Parse(row[0].ToString()))) AvailableGRD.Rows.Add(row[0], row[1], row[2]);
            }
            AvailableGRD.Columns[0].Visible = false;
            AvailableGRD.Columns[1].HeaderText = "NAME";
            AvailableGRD.Columns[1].Width = 210;
            AvailableGRD.Columns[2].HeaderText = "LOCATION";
            AvailableGRD.Columns[2].Width = 210;
        }
        private void CloseBTN_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void ConfirmBTN_Click(object sender, EventArgs e) {
            if (NumberOfGuards < GIDs.Count()) {
                DialogResult rs = rylui.RylMessageBox.ShowDialog("The number of guards you've assigned is \n more than what the client requested \n Continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rs == DialogResult.Yes) {
                    Scheduling.AddAssignment(RID, GIDs);
                    this.Close();
                    refer.Close();
                }
            } else if (NumberOfGuards > GIDs.Count()) {
                DialogResult rs = rylui.RylMessageBox.ShowDialog("The number of guards you've assigned is not enough", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                Scheduling.AddAssignment(RID, GIDs);
                this.Close();
                refer.Close();
            }
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
            GIDs = new int[AssignedGRD.Rows.Count];
            for (int i = 0; i < AssignedGRD.Rows.Count; i++) {
                GIDs[i] = int.Parse(AssignedGRD.Rows[i].Cells[0].Value.ToString());
            }

            if ((NumberOfGuards - AssignedGRD.Rows.Count) >= 0) {
                NeededLBL.Text = NumberOfGuards - AssignedGRD.Rows.Count + " guards still needed";
            } else NeededLBL.Text = "0 guards still needed";
            AssignedLBL.Text = "Assigned Guards (" + AssignedGRD.Rows.Count + ")";
            AvailableLBL.Text = "Available Guards (" + AvailableGRD.Rows.Count + ")";
            AssignedGRD.Sort(AssignedGRD.Columns[1], ListSortDirection.Ascending);
            AvailableGRD.Sort(AvailableGRD.Columns[1], ListSortDirection.Ascending);
        }

        private Color dark = Color.FromArgb(53, 64, 82);
        private Color light = Color.FromArgb(94, 114, 146);

        private void AssignedLBL_Click(object sender, EventArgs e) {
            AvailablePNL.Visible = false;
            AssignedPNL.Visible = true;
            AssignedLBL.ForeColor = dark;
            AvailableLBL.ForeColor = light;
        }

        private void AvailableLBL_Click(object sender, EventArgs e) {
            AvailablePNL.Visible = true;
            AssignedPNL.Visible = false;
            AssignedLBL.ForeColor = light;
            AvailableLBL.ForeColor = dark;
        }

        private void AssignedLBL_MouseHover(object sender, EventArgs e) {
            AssignedLBL.ForeColor = dark;
        }

        private void AvailableLBL_MouseHover(object sender, EventArgs e) {
            AvailableLBL.ForeColor = dark;
        }

        private void AssignedLBL_MouseLeave(object sender, EventArgs e) {
            if (!AssignedPNL.Visible) AssignedLBL.ForeColor = light;
        }

        private void AvailableLBL_MouseLeave(object sender, EventArgs e) {
            if (!AvailablePNL.Visible) AvailableLBL.ForeColor = light;
        }
        private void DeleteBTN_Click(object sender, EventArgs e) {
            foreach (DataGridViewRow row in AssignedGRD.SelectedRows) {
                int numToRemove = int.Parse(row.Cells[0].Value.ToString());
                int numIdx = Array.IndexOf(GIDs, numToRemove);
                List<int> tmp = new List<int>(GIDs);
                tmp.RemoveAt(numIdx);
                GIDs = tmp.ToArray();
                AssignedGRD.Rows.Remove(row);
            }
            RefreshAvailable();
            UpdateNeeded();
        }
        
    }
}
