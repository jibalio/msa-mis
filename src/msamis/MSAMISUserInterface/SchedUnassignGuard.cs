using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using rylui;

namespace MSAMISUserInterface {
    public partial class SchedUnassignGuard : Form {
        private readonly Color _dark = Color.FromArgb(53, 64, 82);
        private readonly Color _light = Color.DarkGray;

        private int _iid;
        public Shadow Refer;
        public MainForm Reference;

        public SchedUnassignGuard() {
            InitializeComponent();
            Opacity = 0;
        }

        public DataGridViewSelectedRowCollection Guards { get; set; }
        public int Cid { get; set; }

        private const int CsDropshadow = 0x20000;

        protected override CreateParams CreateParams {
            get {
                var cp = base.CreateParams;
                cp.ClassStyle |= CsDropshadow;
                return cp;
            }
        }

        private void DismissBTN_Click(object sender, EventArgs e) {
            if (DataValidation()) {
                var giDs = new int[GuardsGRD.RowCount];
                for (var i = 0; i < GuardsGRD.RowCount; i++)
                    giDs[i] = int.Parse(GuardsGRD.Rows[i].Cells[0].Value.ToString());

                if (EnableIncidentCHKBX.Checked) {
                    Scheduling.AddUnassignmentRequest(Cid, giDs, IncidentTypeCMBX.SelectedIndex, Login.UserName,
                        DateDTPKR.Value,
                        LocationBX.Text.Replace("'", string.Empty), DescriptionBX.Text.Replace("'", string.Empty),
                        DateEffective.Value);

                    try {
                        _iid = int.Parse(SQLTools.getLastInsertedId("IncidentReport", "IID"));
                    }
                    catch { }
                    try {
                        foreach (DataGridViewRow row in DepsGRD.Rows) {
                            InsertDependent(GetRelationshipIndex(row.Cells[4].Value.ToString()),
                                row.Cells[1].Value.ToString().Replace("'", string.Empty),
                                row.Cells[2].Value.ToString().Replace("'", string.Empty),
                                row.Cells[3].Value.ToString().Replace("'", string.Empty));
                        }
                    }
                    catch { }
                }
                else {
                    Scheduling.AddUnassignmentRequestNoIncident(Cid, giDs, DateEffective.Value);
                }
                RylMessageBox.ShowDialog("Your Request has been added", "Request Added", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Reference.SchedLoadSidePnl();
                Close();
            }
        }

        private static int GetRelationshipIndex(string rep) {
            switch (rep) {
                case "Involved":
                    return 1;
                case "Witness":
                    return 2;
                default:
                    return 0;
            }
        }

        private void InsertDependent(int type, string first, string middle, string last) {
            Scheduling.AddIncidentReportInvolvement(_iid, type, first, middle, last);
        }


        private void ReportLBL_Click(object sender, EventArgs e) {
            GuardsPNL.Hide();
            ReportPNL.Show();
            GuardsLBL.ForeColor = _light;
            ReportLBL.ForeColor = _dark;
        }

        private void GuardsLBL_Click(object sender, EventArgs e) {
            GuardsPNL.Show();
            ReportPNL.Hide();
            GuardsLBL.ForeColor = _dark;
            ReportLBL.ForeColor = _light;
        }

        private void ReportLBL_MouseEnter(object sender, EventArgs e) {
            ReportLBL.ForeColor = _dark;
        }

        private void GuardsLBL_MouseEnter(object sender, EventArgs e) {
            GuardsLBL.ForeColor = _dark;
        }

        private void ReportLBL_MouseLeave(object sender, EventArgs e) {
            if (!ReportPNL.Visible) ReportLBL.ForeColor = _light;
        }

        private void GuardsLBL_MouseLeave(object sender, EventArgs e) {
            if (!GuardsPNL.Visible) GuardsLBL.ForeColor = _light;
        }

        private void LocationBX_TextChanged(object sender, EventArgs e) { }
        
        #region Form Properties

        private void Sched_DismissGuard_Load(object sender, EventArgs e) {
            LoadPage();
            FadeTMR.Start();
            IncidentTypeCMBX.SelectedIndex = 1;
            GuardsPNL.Show();
            ReportPNL.Hide();
            GuardsLBL.ForeColor = _dark;
            ReportLBL.ForeColor = _light;
        }

        private void LoadPage() {
            GuardsGRD.ColumnHeadersVisible = false;
            foreach (DataGridViewRow row in Guards)
                GuardsGRD.Rows.Add(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(),
                    row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(),
                    row.Cells[5].Value.ToString());
            GuardsGRD.Sort(GuardsGRD.Columns[3], ListSortDirection.Ascending);
        }

        private void FadeTMR_Tick(object sender, EventArgs e) {
            Opacity += 0.2;
            if (Opacity >= 1) FadeTMR.Stop();
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            if (RylMessageBox.ShowDialog("Are you sure you want to stop editing? Unsaved changes will be lost.", "Stop Editing?",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Close();
        }

        private void Sched_DismissGuard_FormClosing(object sender, FormClosingEventArgs e) {
            Refer.Close();
        }

        private void RemoveBTN_Click(object sender, EventArgs e) {
            foreach (DataGridViewRow row in GuardsGRD.SelectedRows) GuardsGRD.Rows.Remove(row);
        }

        #endregion

        #region DataValidation

        private bool DataValidation() {
            var ret = true;

            if (GuardsGRD.RowCount == 0) {
                RylMessageBox.ShowDialog("There are no guards to be dismissed \nThis request will be canceled",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                GuardsPNL.Show();
                ReportPNL.Hide();
                GuardsLBL.ForeColor = _dark;
                ReportLBL.ForeColor = _light;
                ret = false;
            }
            if (EnableIncidentCHKBX.Checked) {
                if (LocationBX.Text.Equals("")) {
                    ShowToolTipOnBx(LocationTLTP, "Event Location", "Where did this incident happen?", LocationBX);
                    ret = false;
                }
                if (DescriptionBX.Text.Equals("")) {
                    ShowToolTipOnBx(DescriptionTLTP, "Event Description", "What happened in this incident?",
                        DescriptionBX);
                    ret = false;
                }
                if (!ret) {
                    GuardsPNL.Hide();
                    ReportPNL.Show();
                    GuardsLBL.ForeColor = _light;
                    ReportLBL.ForeColor = _dark;
                }
            }
            return ret;
        }

        private static void ShowToolTipOnBx(ToolTip ttp, string title, string message, IWin32Window lb) {
            ttp.ToolTipTitle = title;
            ttp.Show(message, lb, 2000);
        }
        #endregion

        private void SchedUnassignGuard_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.F4 && e.Alt) {
                e.SuppressKeyPress = true;
            }
        }

        private void AddRowBTN_Click(object sender, EventArgs e) {
            DepsGRD.Rows.Add(-1, "First", "Middle", "Last", "");
        }

        private void DelRowBTN_Click(object sender, EventArgs e) {
            if (DepsGRD.SelectedRows.Count > 0)
            DepsGRD.Rows.Remove(DepsGRD.SelectedRows[0]);
        }

        private void EnableIncidentCHKBX_CheckedChanged(object sender, EventArgs e) {
            DisableIncidentPNL.Visible = !EnableIncidentCHKBX.Checked;
        }
    }
}