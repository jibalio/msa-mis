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


        private void DismissBTN_Click(object sender, EventArgs e) {
            if (DataValidation()) {
                var giDs = new int[GuardsGRD.RowCount];
                for (var i = 0; i < GuardsGRD.RowCount; i++)
                    giDs[i] = int.Parse(GuardsGRD.Rows[i].Cells[0].Value.ToString());
                Scheduling.AddUnassignmentRequest(Cid, giDs, IncidentTypeCMBX.SelectedIndex, Login.UserName,
                    DateDTPKR.Value,
                    LocationBX.Text, DescriptionBX.Text, DateEffective.Value);

                try {
                    _iid = int.Parse(SQLTools.getLastInsertedId("IncidentReport", "IID"));
                }
                catch { }
                try {
                    if (!CheckName(Dependent1FirstBX, Dependent1MiddleBX, Dependent1LastBX))
                        InsertDependent(Dependent1RBX.SelectedIndex, Dependent1FirstBX.Text,
                            Dependent1MiddleBX.Text, Dependent1LastBX.Text);
                    if (!CheckName(Dependent2FirstBX, Dependent2MiddleBX, Dependent2LastBX))
                        InsertDependent(Dependent2RBX.SelectedIndex, Dependent2FirstBX.Text,
                            Dependent2MiddleBX.Text, Dependent2LastBX.Text);
                    if (!CheckName(Dependent3FirstBX, Dependent3MiddleBX, Dependent3LastBX))
                        InsertDependent(Dependent3RBX.SelectedIndex, Dependent3FirstBX.Text,
                            Dependent3MiddleBX.Text, Dependent3LastBX.Text);
                    if (!CheckName(Dependent4FirstBX, Dependent4MiddleBX, Dependent4LastBX))
                        InsertDependent(Dependent4RBX.SelectedIndex, Dependent4FirstBX.Text,
                            Dependent4MiddleBX.Text, Dependent4LastBX.Text);
                    if (!CheckName(Dependent5FirstBX, Dependent5MiddleBX, Dependent5LastBX))
                        InsertDependent(Dependent5RBX.SelectedIndex, Dependent5FirstBX.Text,
                            Dependent5MiddleBX.Text, Dependent5LastBX.Text);
                }
                catch { }

                RylMessageBox.ShowDialog("Your Request has been added", "Request Added", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Reference.SchedLoadSidePnl();
                Close();
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

        private static void ClearBox(TextBoxBase textBoxBase) {
            if (textBoxBase.Text.Equals("Last")) textBoxBase.Clear();
            else if (textBoxBase.Text.Equals("Middle")) textBoxBase.Clear();
            else if (textBoxBase.Text.Equals("First")) textBoxBase.Clear();
        }

        private void Dependent1FirstBX_Enter(object sender, EventArgs e) {
            ClearBox(Dependent1FirstBX);
        }

        private void Dependent1MiddleBX_Enter(object sender, EventArgs e) {
            ClearBox(Dependent1MiddleBX);
        }

        private void Dependent1LastBX_Enter(object sender, EventArgs e) {
            ClearBox(Dependent1LastBX);
        }

        private void Dependent2FirstBX_Enter(object sender, EventArgs e) {
            ClearBox(Dependent2FirstBX);
        }

        private void Dependent2MiddleBX_Enter(object sender, EventArgs e) {
            ClearBox(Dependent2MiddleBX);
        }

        private void Dependent2LastBX_Enter(object sender, EventArgs e) {
            ClearBox(Dependent2LastBX);
        }

        private void Dependent3FirstBX_Enter(object sender, EventArgs e) {
            ClearBox(Dependent3FirstBX);
        }

        private void Dependent3MiddleBX_Enter(object sender, EventArgs e) {
            ClearBox(Dependent3MiddleBX);
        }

        private void Dependent3LastBX_Enter(object sender, EventArgs e) {
            ClearBox(Dependent3LastBX);
        }

        private void Dependent4FirstBX_Enter(object sender, EventArgs e) {
            ClearBox(Dependent4FirstBX);
        }

        private void Dependent4MiddleBX_Enter(object sender, EventArgs e) {
            ClearBox(Dependent4MiddleBX);
        }

        private void Dependent4LastBX_Enter(object sender, EventArgs e) {
            ClearBox(Dependent4LastBX);
        }

        private void Dependent5FirstBX_Enter(object sender, EventArgs e) {
            ClearBox(Dependent5FirstBX);
        }

        private void Dependent5MiddleBX_Enter(object sender, EventArgs e) {
            ClearBox(Dependent5MiddleBX);
        }

        private void Dependent5LastBX_Enter(object sender, EventArgs e) {
            ClearBox(Dependent5LastBX);
        }

        private void LastNameBX_Leave(object sender, EventArgs e) {
            var lastbx = sender as TextBox;
            if (lastbx.Text.Trim(' ').Length == 0) lastbx.Text = "Last";
        }

        private void FirstNameBX_Leave(object sender, EventArgs e) {
            var lastbx = sender as TextBox;
            if (lastbx.Text.Trim(' ').Length == 0) lastbx.Text = "First";
        }

        private void MiddleNameBX_Leave(object sender, EventArgs e) {
            var lastbx = sender as TextBox;
            if (lastbx.Text.Trim(' ').Length == 0) lastbx.Text = "Middle";
        }

        #region Form Properties

        private void Sched_DismissGuard_Load(object sender, EventArgs e) {
            LoadPage();
            Location = new Point(Location.X + 175, Location.Y);
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
            if (RylMessageBox.ShowDialog("Are you sure you want to stop editing?", "Stop Editing?",
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
            GuardsPNL.Hide();
            ReportPNL.Show();
            GuardsLBL.ForeColor = _light;
            ReportLBL.ForeColor = _dark;
            if (LocationBX.Text.Equals("")) {
                ShowToolTipOnBx(LocationTLTP, "Event Location", "Where did this incident happen?", LocationBX);
                ret = false;
            }
            if (DescriptionBX.Text.Equals("")) {
                ShowToolTipOnBx(DescriptionTLTP, "Event Description", "What happened in this incident?", DescriptionBX);
                ret = false;
            }
            if (CheckNameNotRequired(Dependent1FirstBX, Dependent1MiddleBX, Dependent1LastBX, Dependent1RBX)) {
                ShowToolTipOnBx(Dep1Warn, "Dependent's Name", "Please complete the fields", Dependent1FirstBX);
                ret = false;
            }
            if (CheckNameNotRequired(Dependent2FirstBX, Dependent2MiddleBX, Dependent2LastBX, Dependent2RBX)) {
                ShowToolTipOnBx(Dep2Warn, "Dependent's Name", "Please complete the fields", Dependent2FirstBX);
                ret = false;
            }
            if (CheckNameNotRequired(Dependent3FirstBX, Dependent3MiddleBX, Dependent3LastBX, Dependent3RBX)) {
                ShowToolTipOnBx(Dep3Warn, "Dependent's Name", "Please complete the fields", Dependent3FirstBX);
                ret = false;
            }
            if (CheckNameNotRequired(Dependent4FirstBX, Dependent4MiddleBX, Dependent4LastBX, Dependent4RBX)) {
                ShowToolTipOnBx(Dep4Warn, "Dependent's Name", "Please complete the fields", Dependent4FirstBX);
                ret = false;
            }
            if (CheckNameNotRequired(Dependent5FirstBX, Dependent5MiddleBX, Dependent5LastBX, Dependent5RBX)) {
                ShowToolTipOnBx(Dep5Warn, "Dependent's Name", "Please complete the fields", Dependent5FirstBX);
                ret = false;
            }
            return ret;
        }

        private static void ShowToolTipOnBx(ToolTip ttp, string title, string message, IWin32Window lb) {
            ttp.ToolTipTitle = title;
            ttp.Show(message, lb);
        }

        private static bool CheckName(Control firstBx, Control middleBx, Control lastBx) {
            return firstBx.Text.Equals("First") || middleBx.Text.Equals("Middle") || lastBx.Text.Equals("Last") ||
                   firstBx.Text.Equals("") || middleBx.Text.Equals("") || lastBx.Text.Equals("");
        }

        private static bool CheckNameNotRequired(Control firstBx, Control middleBx, Control lastBx, ListControl rbx) {
            return CheckNameNotRequired(firstBx, middleBx, lastBx) && CheckForInput(firstBx, middleBx, lastBx, rbx);
        }

        private static bool CheckNameNotRequired(Control firstBx, Control middleBx, Control lastBx) {
            return CheckForInput(firstBx, middleBx, lastBx) && CheckName(firstBx, middleBx, lastBx);
        }

        private static bool CheckForInput(Control firstBx, Control middleBx, Control lastBx) {
            return !(firstBx.Text.Equals("First") || firstBx.Text.Equals("")) ||
                   !(middleBx.Text.Equals("Middle") || middleBx.Text.Equals("")) ||
                   !(lastBx.Text.Equals("Last") || lastBx.Text.Equals(""));
        }

        private static bool CheckForInput(Control firstBx, Control middleBx, Control lastBx, ListControl rbx) {
            return !(firstBx.Text.Equals("First") || firstBx.Text.Equals("")) ||
                   !(middleBx.Text.Equals("Middle") || middleBx.Text.Equals("")) ||
                   !(lastBx.Text.Equals("Last") || lastBx.Text.Equals("")) || rbx.SelectedIndex > 0;
        }

        #endregion
    }
}