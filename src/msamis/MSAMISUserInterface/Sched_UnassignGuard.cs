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
    public partial class Sched_UnassignGuard : Form {
        public MainForm reference;
        public MySqlConnection conn;
        public DataGridViewSelectedRowCollection guards { get; set; }
        public int CID { get; set; }
        public Shadow refer;
        public Sched_UnassignGuard() {
            InitializeComponent();
            this.Opacity = 0;
        }

        #region Form Properties
        private void Sched_DismissGuard_Load(object sender, EventArgs e) {
            LoadPage();
            this.Location = new Point(this.Location.X + 175, this.Location.Y);
            FadeTMR.Start();
            IncidentTypeCMBX.SelectedIndex = 1;
            GuardsPNL.Show();
            ReportPNL.Hide();
            GuardsLBL.ForeColor = dark;
            ReportLBL.ForeColor = light;
        }
        
        private void LoadPage() {
            GuardsGRD.ColumnHeadersVisible = false;
            foreach (DataGridViewRow row in guards) {
                GuardsGRD.Rows.Add(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString());
            }
            GuardsGRD.Sort(GuardsGRD.Columns[3], ListSortDirection.Ascending);
        }

        private void FadeTMR_Tick(object sender, EventArgs e) {
            this.Opacity += 0.2;
            if (this.Opacity >= 1) { FadeTMR.Stop(); }
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void Sched_DismissGuard_FormClosing(object sender, FormClosingEventArgs e) {
            refer.Hide();
        }

        private void RemoveBTN_Click(object sender, EventArgs e) {
            foreach (DataGridViewRow row in GuardsGRD.SelectedRows) {
                GuardsGRD.Rows.Remove(row);
            }
        }
        #endregion

        #region DataValidation
        private bool DataValidation() {
            bool ret = true;

            if (GuardsGRD.RowCount == 0) {
                rylui.RylMessageBox.ShowDialog("There are no guards to be dismissed \nThis request will be canceled", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                GuardsPNL.Show();
                ReportPNL.Hide();
                GuardsLBL.ForeColor = dark;
                ReportLBL.ForeColor = light;
                ret = false;
            }

            if (LocationBX.Text.Equals("")) {
                GuardsPNL.AutoScrollPosition = new Point(GuardsPNL.Location.X, 600);
                ShowToolTipOnBX(LocationTLTP, "Event Location", "Where did this incident happen?", LocationBX);
                ret = false;
            }
            if (DescriptionBX.Text.Equals("")) {
                GuardsPNL.AutoScrollPosition = new Point(GuardsPNL.Location.X, 600);
                ShowToolTipOnBX(DescriptionTLTP, "Event Description", "What happened in this incident?", DescriptionBX);
                ret = false;
            }
            if (CheckNameNotRequired(Dependent1FirstBX, Dependent1MiddleBX, Dependent1LastBX, Dependent1RBX)) {
                GuardsPNL.AutoScrollPosition = new Point(GuardsPNL.Location.X, 600);
                ShowToolTipOnBX(Dep1Warn, "Dependent's Name", "Please complete the fields", Dependent1FirstBX);
                ret = false;
            }
            if (CheckNameNotRequired(Dependent2FirstBX, Dependent2MiddleBX, Dependent2LastBX, Dependent2RBX)) {
                GuardsPNL.AutoScrollPosition = new Point(GuardsPNL.Location.X, 600);
                ShowToolTipOnBX(Dep2Warn, "Dependent's Name", "Please complete the fields", Dependent2FirstBX);
               ret = false;
            }
            if (CheckNameNotRequired(Dependent3FirstBX, Dependent3MiddleBX, Dependent3LastBX, Dependent3RBX)) {
                GuardsPNL.AutoScrollPosition = new Point(GuardsPNL.Location.X, 600);
                ShowToolTipOnBX(Dep3Warn, "Dependent's Name", "Please complete the fields", Dependent3FirstBX);
                ret = false;
            }
            if (CheckNameNotRequired(Dependent4FirstBX, Dependent4MiddleBX, Dependent4LastBX, Dependent4RBX)) {
                GuardsPNL.AutoScrollPosition = new Point(GuardsPNL.Location.X, 600);
                ShowToolTipOnBX(Dep4Warn, "Dependent's Name", "Please complete the fields", Dependent4FirstBX);
                ret = false;
            }
            if (CheckNameNotRequired(Dependent5FirstBX, Dependent5MiddleBX, Dependent5LastBX, Dependent5RBX)) {
                GuardsPNL.AutoScrollPosition = new Point(GuardsPNL.Location.X, 600);
                ShowToolTipOnBX(Dep5Warn, "Dependent's Name", "Please complete the fields", Dependent5FirstBX);
                ret = false;
            }
            return ret;
        }
        private void ShowToolTipOnBX(ToolTip ttp, String title, String message, TextBox lb) {
            ttp.ToolTipTitle = title;
            ttp.Show(message, lb);
        }
        private bool CheckName(TextBox FirstBX, TextBox MiddleBX, TextBox LastBX) {
            return (FirstBX.Text.Equals("First") || MiddleBX.Text.Equals("Middle") || LastBX.Text.Equals("Last") ||
                FirstBX.Text.Equals("") || MiddleBX.Text.Equals("") || LastBX.Text.Equals(""));
        }

        private bool CheckNameNotRequired(TextBox FirstBX, TextBox MiddleBX, TextBox LastBX, ComboBox RBX) {
            return (CheckNameNotRequired(FirstBX, MiddleBX, LastBX) && CheckForInput(FirstBX, MiddleBX, LastBX, RBX));
        }

        private bool CheckNameNotRequired(TextBox FirstBX, TextBox MiddleBX, TextBox LastBX) {
            return (CheckForInput(FirstBX, MiddleBX, LastBX) && CheckName(FirstBX, MiddleBX, LastBX));
        }

        private bool CheckForInput(TextBox FirstBX, TextBox MiddleBX, TextBox LastBX) {
            return (!(FirstBX.Text.Equals("First") || FirstBX.Text.Equals("")) || !(MiddleBX.Text.Equals("Middle") || MiddleBX.Text.Equals("")) ||
               !(LastBX.Text.Equals("Last") || LastBX.Text.Equals("")));
        }

        private bool CheckForInput(TextBox FirstBX, TextBox MiddleBX, TextBox LastBX, ComboBox RBX) {
            return (!(FirstBX.Text.Equals("First") || FirstBX.Text.Equals("")) || !(MiddleBX.Text.Equals("Middle") || MiddleBX.Text.Equals("")) ||
               !(LastBX.Text.Equals("Last") || LastBX.Text.Equals("")) || RBX.SelectedIndex > 0);
        }
        #endregion


        private void DismissBTN_Click(object sender, EventArgs e) {
            if (DataValidation()) {
                int[] GIDs = new int[GuardsGRD.RowCount];
                for (int i = 0; i < GuardsGRD.RowCount; i++) {
                    GIDs[i] = int.Parse(GuardsGRD.Rows[i].Cells[0].Value.ToString());
                }
                Scheduling.AddUnassignmentRequest(CID, GIDs, IncidentTypeCMBX.SelectedIndex, "Admin", DateDTPKR.Value, LocationBX.Text, DescriptionBX.Text);
                reference.SCHEDLoadSidePNL();
                this.Close();
            }
        }
        private Color dark = Color.FromArgb(53, 64, 82);
        private Color light = Color.DarkGray;


        private void ReportLBL_Click(object sender, EventArgs e) {
            GuardsPNL.Hide();
            ReportPNL.Show();
            GuardsLBL.ForeColor = light;
            ReportLBL.ForeColor = dark;
        }

        private void GuardsLBL_Click(object sender, EventArgs e) {
            GuardsPNL.Show();
            ReportPNL.Hide();
            GuardsLBL.ForeColor = dark;
            ReportLBL.ForeColor = light;
        }

        private void ReportLBL_MouseEnter(object sender, EventArgs e) {
            ReportLBL.ForeColor = dark;
        }

        private void GuardsLBL_MouseEnter(object sender, EventArgs e) {
            GuardsLBL.ForeColor = dark;
        }

        private void ReportLBL_MouseLeave(object sender, EventArgs e) {
            if(!ReportPNL.Visible) ReportLBL.ForeColor = light;
        }

        private void GuardsLBL_MouseLeave(object sender, EventArgs e) {
            if (!GuardsPNL.Visible) GuardsLBL.ForeColor = light;
        }
    }
}
