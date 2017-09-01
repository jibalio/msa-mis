using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using rylui;

namespace MSAMISUserInterface {
    public partial class SchedAssignGuards : Form {
        private const string FilterText = "Search or filter";
        private const string EmptyText = "";
        private readonly Color _dark = Color.FromArgb(53, 64, 82);
        private readonly Color _light = Color.FromArgb(94, 114, 146);
        private string _extraQueryParams = "";

        private int[] _gidS = {-1};
        public string ClientName;

        public string ContractStart;
        public string ContractEnd;

        public SchedAssignGuards() {
            InitializeComponent();
            Opacity = 0;
        }

        public SchedViewAssReq Refer { get; set; }
        public int Rid { get; set; }
        public int NumberOfGuards { get; set; }

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
            AssignedGRD.Columns[1].Width = 200;
            AssignedGRD.Columns[2].HeaderText = "LOCATION";
            AssignedGRD.Columns[2].Width = 240;
            UpdateNeeded();
        }

        private void RefreshAvailable() {
            AvailableGRD.Rows.Clear();
            var dt = Scheduling.GetUnassignedGuards(_extraQueryParams, ContractStart, ContractEnd);
            foreach (DataRow row in dt.Rows)
                if (!_gidS.Contains(int.Parse(row[0].ToString()))) AvailableGRD.Rows.Add(row[0], row[1], row[2]);
            AvailableGRD.Columns[0].Visible = false;
            AvailableGRD.Columns[1].HeaderText = "NAME";
            AvailableGRD.Columns[1].Width = 200;
            AvailableGRD.Columns[2].HeaderText = "LOCATION";
            AvailableGRD.Columns[2].Width = 240;
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            if (RylMessageBox.ShowDialog("Are you sure you want to stop editing?", "Stop Editing?",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Close();
        }

        private void ConfirmBTN_Click(object sender, EventArgs e) {
            if (NumberOfGuards < _gidS.Length) {
                var rs = RylMessageBox.ShowDialog(
                    "The number of guards you've assigned is \n more than what the client requested \n Continue?",
                    "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rs == DialogResult.Yes) {
                    Scheduling.AddAssignment(Rid, _gidS);
                    Close();
                    Refer.Close();
                }
            }
            else if (NumberOfGuards > _gidS.Length) {
                var rs = RylMessageBox.ShowDialog("The number of guards you've assigned is not enough. Do you still want to assign the selected guards?", "Warning",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rs == DialogResult.Yes) {
                    Scheduling.AddAssignment(Rid, _gidS);
                    Close();
                    Refer.Close();
                }
            }
            else {
                Scheduling.AddAssignment(Rid, _gidS);
                Close();
                Refer.Close();
            }
        }

        private void FadeTMR_Tick(object sender, EventArgs e) {
            Opacity += 0.2;
            if (Opacity >= 1) FadeTMR.Stop();
        }

        private void AssignBTN_Click(object sender, EventArgs e) {
            AddGuards();
            ConfirmBTN.Visible = true;
        }

        private void AddGuards() {
            for (var i = 0; i < AvailableGRD.SelectedRows.Count; i++)
                AssignedGRD.Rows.Add(AvailableGRD.SelectedRows[i].Cells[0].Value.ToString(),
                    AvailableGRD.SelectedRows[i].Cells[1].Value.ToString(),
                    AvailableGRD.SelectedRows[i].Cells[2].Value.ToString());
            foreach (DataGridViewRow row in AvailableGRD.SelectedRows) AvailableGRD.Rows.Remove(row);
            UpdateNeeded();
        }

        private void UpdateNeeded() {
            _gidS = new int[AssignedGRD.Rows.Count];
            for (var i = 0; i < AssignedGRD.Rows.Count; i++)
                _gidS[i] = int.Parse(AssignedGRD.Rows[i].Cells[0].Value.ToString());

            if (NumberOfGuards - AssignedGRD.Rows.Count >= 0)
                NeededLBL.Text = NumberOfGuards - AssignedGRD.Rows.Count + " guards still needed";
            else NeededLBL.Text = "0 guards still needed";
            AssignedLBL.Text = "Assigned Guards (" + AssignedGRD.Rows.Count + ")";
            AvailableLBL.Text = "Available Guards (" + AvailableGRD.Rows.Count + ")";
            AssignedGRD.Sort(AssignedGRD.Columns[1], ListSortDirection.Ascending);
            AvailableGRD.Sort(AvailableGRD.Columns[1], ListSortDirection.Ascending);
        }

        private void AssignedLBL_Click(object sender, EventArgs e) {
            AvailablePNL.Visible = false;
            AssignedPNL.Visible = true;
            AssignedLBL.ForeColor = _dark;
            AvailableLBL.ForeColor = _light;
        }

        private void AvailableLBL_Click(object sender, EventArgs e) {
            AvailablePNL.Visible = true;
            AssignedPNL.Visible = false;
            AssignedLBL.ForeColor = _light;
            AvailableLBL.ForeColor = _dark;
        }

        private void AssignedLBL_MouseHover(object sender, EventArgs e) {
            AssignedLBL.ForeColor = _dark;
        }

        private void AvailableLBL_MouseHover(object sender, EventArgs e) {
            AvailableLBL.ForeColor = _dark;
        }

        private void AssignedLBL_MouseLeave(object sender, EventArgs e) {
            if (!AssignedPNL.Visible) AssignedLBL.ForeColor = _light;
        }

        private void AvailableLBL_MouseLeave(object sender, EventArgs e) {
            if (!AvailablePNL.Visible) AvailableLBL.ForeColor = _light;
        }

        private void DeleteBTN_Click(object sender, EventArgs e) {
            foreach (DataGridViewRow row in AssignedGRD.SelectedRows) {
                var numToRemove = int.Parse(row.Cells[0].Value.ToString());
                var numIdx = Array.IndexOf(_gidS, numToRemove);
                var tmp = new List<int>(_gidS);
                tmp.RemoveAt(numIdx);
                _gidS = tmp.ToArray();
                AssignedGRD.Rows.Remove(row);
            }
            RefreshAvailable();
            UpdateNeeded();
        }

        private void AvailableSearchBX_Enter(object sender, EventArgs e) {
            if (AvailableSearchBX.Text == FilterText) {
                AvailableSearchBX.Text = EmptyText;
                _extraQueryParams = EmptyText;
            }
            AvailableSearchLine.Visible = true;
        }

        private void AvailableSearchBX_Leave(object sender, EventArgs e) {
            if (AvailableSearchBX.Text == EmptyText) {
                AvailableSearchBX.Text = FilterText;
                _extraQueryParams = EmptyText;
            }
            RefreshAvailable();
            AvailableSearchLine.Visible = false;
        }

        private void AvailableSearchBX_TextChanged(object sender, EventArgs e) {
            var temp = AvailableSearchBX.Text;
            string kazoo = NameRDBTN.Checked ? "concat(ln,', ',fn,' ',mn)" : "concat(address.StreetNo,', ', address.Brgy,', ',address.Street, ', ', address.City)";

            if (AvailableSearchBX.Text.Contains("\\")) temp = temp + "?";
            _extraQueryParams = " and (" + kazoo + " like '" + temp + "%' OR " + kazoo + " like '%" + temp +
                                "%' OR " + kazoo + " LIKe '%" + temp + "')";
            RefreshAvailable();
        }
    }
}