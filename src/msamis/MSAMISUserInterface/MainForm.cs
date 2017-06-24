using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ryldb.sqltools;

namespace MSAMISUserInterface {
    public partial class MainForm : Form {

        //Only Paste Global Variable Here//
        bool mouseDown;
        Point lastLocation;
        public MySqlConnection conn;
        Color accent = Color.FromArgb(94, 114, 146);
        Color primary = Color.FromArgb(53, 64, 82);
        Color dahsbard = Color.FromArgb(42, 72, 119);
        Font selectedFont = new Font("Segoe UI Semibold", 10);
        Font defaultFont = new Font("Segoe UI Semilight", 10);
        bool DashboardToBeMinimized;
        Button currentBTN;
        SplitContainer currentPage;
        public LoginForm lf;
        String FilterText = "Search or filter";
        String EmptyText = "";

        #region Form Initiation and load
        public MainForm() {
            InitializeComponent();
            initiateForm();
            conn = SQLTools.conn;
            FadeTMR.Start();
        }
        private void initiateForm() {
            DashboardPage.Visible = true;
            DashboardPage.BringToFront();
            GuardsPage.Visible = false;
            ClientsPage.Visible = false;
            SchedulesPage.Visible = false;
            PayrollPage.Visible = false;
            currentBTN = DashboardBTN;
            ControlBoxPanel.BackColor = dahsbard;
        }
        private void MainForm_Load(object sender, EventArgs e) {
            ControlBoxTimeLBL.Text = DateTime.Now.ToString("dddd, MMMM dd yyyy");
            TimeLBL.Text = DateTime.Now.ToString("dddd, MMMM dd yyyy").ToUpper();
        }
        private void CloseBTN_Click(object sender, EventArgs e) {
            lf.Opacity = 0;
            lf.Show();
            this.Hide();
        }
        #endregion

        #region Form Features
        //For Draggable Form
        private void Form_MouseUp(object sender, MouseEventArgs e) {
            mouseDown = false;
        }
        private void Form_MouseDown(object sender, MouseEventArgs e) {
            mouseDown = true;
            lastLocation = e.Location;
        }
        private void Form_MouseMove(object sender, MouseEventArgs e) {
            if (mouseDown) {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y
                    );
                this.Update();
            }
        }
        private void FadeTMR_Tick(object sender, EventArgs e) {
            this.Opacity += 0.2;
            if (this.Opacity == 1) FadeTMR.Stop();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            lf.Opacity = 0;
            lf.Show();
            this.Hide();
        }
        #endregion

        #region Form Global Buttons and Events
        private void DashboardBTN_Click(object sender, EventArgs e) {
            DashboardToBeMinimized = false;
            DashboardTMR.Start();
            DashboardBTN.BackColor = accent;
            currentBTN.BackColor = primary;
            currentBTN = DashboardBTN;
        }
        private void RecordsBTN_Click(object sender, EventArgs e) {
            DashboardToBeMinimized = true;
            DashboardTMR.Start();
            GuardsPage.Show();
            SchedulesPage.Hide();
            PayrollPage.Hide();
            ClientsPage.Hide();
            currentBTN.BackColor = primary;
            RecordsBTN.BackColor = accent;
            currentPage = GuardsPage;
            currentBTN = RecordsBTN;
            GUARDSLoadPage();
        }
        private void ClientBTN_Click(object sender, EventArgs e) {
            DashboardToBeMinimized = true;
            DashboardTMR.Start();
            GuardsPage.Hide();
            SchedulesPage.Hide();
            PayrollPage.Hide();
            ClientsPage.Show();
            currentBTN.BackColor = primary;
            ClientBTN.BackColor = accent;
            currentPage = ClientsPage;
            currentBTN = ClientBTN;
            CLIENTSLoadPage();
        }
        private void SchedBTN_Click(object sender, EventArgs e) {
            DashboardToBeMinimized = true;
            DashboardTMR.Start();
            GuardsPage.Hide();
            SchedulesPage.Show();
            PayrollPage.Hide();
            ClientsPage.Hide();
            currentBTN.BackColor = primary;
            SchedBTN.BackColor = accent;
            currentPage = SchedulesPage;
            currentBTN = SchedBTN;
            SCHEDLoadPage();
        }
        private void PayrollBTN_Click(object sender, EventArgs e) {
            DashboardToBeMinimized = true;
            DashboardTMR.Start();
            GuardsPage.Hide();
            SchedulesPage.Hide();
            PayrollPage.Show();
            ClientsPage.Hide();
            currentBTN.BackColor = primary;
            PayrollBTN.BackColor = accent;
            currentPage = PayrollPage;
            currentBTN = PayrollBTN;
            PAYLoadPage();
        }
        private void DashboardTMR_Tick(object sender, EventArgs e) {
            if (DashboardToBeMinimized) {
                Point defaultPoint = new Point(100, -865);
                if (DashboardPage.Location.Y > defaultPoint.Y) DashboardPage.Location = new Point(DashboardPage.Location.X, DashboardPage.Location.Y - 60);
                else { DashboardTMR.Stop(); ControlBoxLBL.Visible = true; ControlBoxTimeLBL.Visible = true; ControlBoxPanel.BackColor = primary; }
            } else if (!DashboardToBeMinimized) {
                ControlBoxLBL.Visible = false;
                ControlBoxTimeLBL.Visible = false;
                Point defaultPoint = new Point(70, 32);
                if (DashboardPage.Location.Y != defaultPoint.Y) {
                    DashboardPage.Location = new Point(DashboardPage.Location.X, DashboardPage.Location.Y + 60);
                } else { DashboardTMR.Stop(); ControlBoxPanel.BackColor = dahsbard; }
            }

        }
        #endregion

        #region Guards Management System

        #region GMS - Page Load
        public void GUARDSLoadPage() {
            GUARDSRefreshGuardsList();
            GArchivePNL.Hide();
            GSummaryPNL.Hide();
            GViewAllPNL.Show();
            GViewAllPageBTN.Font = selectedFont;
            GArchivePageBTN.Font = defaultFont;
            GSummaryPageBTN.Font = defaultFont;
            GActiveLBL.Text = SQLTools.GetNumberOfGuards("active") + " active guards";
            GInactiveLBL.Text = SQLTools.GetNumberOfGuards("inactive") + " inactive guards";
            GViewAllViewByCMBX.SelectedIndex = 0;
        }
        #endregion

        #region GMS - Side Panel
        private void RAddEmpBTN_Click(object sender, EventArgs e) {
            try {
                Guards_Edit view = new Guards_Edit();
                view.reference = this;
                view.conn = this.conn;
                view.Location = new Point(this.Location.X + 277, this.Location.Y + 33);
                view.ShowDialog();
            }
            catch (Exception) { }
        }
        private void GArchivePageBTN_Click(object sender, EventArgs e) {
            ExtraQueryParams = "";
            GArchivePNL.Show();
            GViewAllPNL.Hide();
            GSummaryPNL.Hide();
            GArchivePageBTN.Font = selectedFont;
            GViewAllPageBTN.Font = defaultFont;
            GSummaryPageBTN.Font = defaultFont;
            RefreshArchivedGuards();
        }
        private void GViewAllPageBTN_Click(object sender, EventArgs e) {
            ExtraQueryParams = "";
            GViewAllPNL.Show();
            GArchivePNL.Hide();
            GSummaryPNL.Hide();
            GViewAllPageBTN.Font = selectedFont;
            GArchivePageBTN.Font = defaultFont;
            GSummaryPageBTN.Font = defaultFont;
            GViewAllViewByCMBX.SelectedIndex = 0;
        }
        private void GSummaryPageBTN_Click(object sender, EventArgs e) {
            GSummaryPNL.Show();
            GViewAllPNL.Hide();
            GArchivePNL.Hide();
            GSummaryPageBTN.Font = selectedFont;
            GArchivePageBTN.Font = defaultFont;
            GViewAllPageBTN.Font = defaultFont;
        }
        #endregion

        #region GMS - View All

        #region GMS - View All - Data Grid
        String ExtraQueryParams = "";
        private void GViewAllViewByCMBX_SelectedIndexChanged(object sender, EventArgs e) {
            GUARDSRefreshGuardsList();
        }
        public void GUARDSRefreshGuardsList() {
            // All column names should be done in SQL Query
            String query;
            String orderbyclause;
            try {
                if (GViewAllViewByCMBX.SelectedIndex == 0) {
                    query = "Select gid,concat(ln,', ',fn,' ',mn) as NAME, " +
                        "case gstatus when 1 then 'Active' when 2 then 'Inactive' end as 'STATUS', " +
                        "bdate as BIRTHDATE, case gender when 1 then 'Male' when 2 then 'Female' end as 'GENDER', " +
                        "cellno as 'CONTACTNO' " +
                        "FROM Guards ";
                    orderbyclause = "ORDER BY NAME ASC;";
                } else {
                    query = "Select Guards.gid,concat(ln,', ',fn,' ',mn) as NAME, " +
                       "concat(StreetNo,', ', Brgy,', ',Street, ', ', City) As LOCATION, case gstatus when 1 then 'Active' when 2 then 'Inactive' end as 'STATUS' " +
                       "FROM Guards LEFT JOIN Address ON Address.GID = Guards.GID ";
                    orderbyclause = "AND Atype = 2 ORDER BY NAME ASC;";
                }
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query + ExtraQueryParams + orderbyclause, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                GAllGuardsGRD.DataSource = dt;
                // 0 must always be ID.
                if (GViewAllViewByCMBX.SelectedIndex == 0) {
                    GAllGuardsGRD.Columns[0].Visible = false;
                    GAllGuardsGRD.Columns["NAME"].Width = 240;
                    GAllGuardsGRD.Columns["GENDER"].Width = 80;
                    GAllGuardsGRD.Columns["GENDER"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    GAllGuardsGRD.Columns["BIRTHDATE"].Width = 80;
                    GAllGuardsGRD.Columns["BIRTHDATE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    GAllGuardsGRD.Columns["CONTACTNO"].Width = 140;

                    GAllGuardsGRD.Columns["STATUS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    GAllGuardsGRD.Columns["STATUS"].Width = 70;
                } else {
                    GAllGuardsGRD.Columns[0].Width = 0;
                    GAllGuardsGRD.Columns["NAME"].Width = 240;
                    GAllGuardsGRD.Columns["LOCATION"].Width = 300;
                    GAllGuardsGRD.Columns["LOCATION"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    GAllGuardsGRD.Columns["STATUS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    GAllGuardsGRD.Columns["STATUS"].Width = 70;
                }
                conn.Close();
            }
            catch (Exception ee) {
                conn.Close();
                MessageBox.Show(ee.Message + " \nLine 171 of MainForm.cs");
            }
        }

        private void GAllGuardsGRD_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e) {
            // For any other operation except, StateChanged, do nothing
            if (e.StateChanged != DataGridViewElementStates.Selected) return;

            GuardsGID.Clear();  // Clear array of selected guards b4 moving to new selection.
            try {
                // Multi-select compatible.
                // Parse in method to get specific guard (i.e. single selections)
                foreach (DataGridViewRow row in GAllGuardsGRD.SelectedRows) {
                    GuardsGID.Add(int.Parse(row.Cells[0].Value.ToString()));
                }
                //rylui.RylMessageBox.ShowDialog(GuardsGID.Count.ToString());
                // Single Cell Selections (Old Code)
                //GuardsGID = int.Parse(GAllGuardsGRD.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            catch { }
        }

        List<int> GuardsGID = new List<int>();

        private void GEditDetailsBTN_Click(object sender, EventArgs e) {
            try {
                Guards_View view = new Guards_View();
                if (GuardsGID.Count > 1) {
                    rylui.RylMessageBox.ShowDialog("More than 1 guard is selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } else if (GuardsGID.Count == 0) {
                    rylui.RylMessageBox.ShowDialog("No guard is selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } else {
                    view.GID = GuardsGID[0];
                    view.reference = this;
                    view.conn = this.conn;
                    view.Location = new Point(this.Location.X + 277, this.Location.Y + 33);
                    view.ShowDialog();
                }
            }
            catch (Exception) { }
        }
        #endregion

        #region GMS - View All - Search
        private void GViewAllSearchTXTBX_Enter(object sender, EventArgs e) {
            if (GViewAllSearchTXTBX.Text == FilterText) {
                GViewAllSearchTXTBX.Text = EmptyText;
                ExtraQueryParams = EmptyText;
            }
            GViewAllSearchLine.Visible = true;
        }

        private void GViewAllSearchTXTBX_Leave(object sender, EventArgs e) {
            if (GViewAllSearchTXTBX.Text == EmptyText) {
                GViewAllSearchTXTBX.Text = FilterText;
                ExtraQueryParams = EmptyText;
            }
            GUARDSRefreshGuardsList();
            GViewAllSearchLine.Visible = false;
        }

        private void GViewAllSearchTXTBX_TextChanged(object sender, EventArgs e) {
            String temp = GViewAllSearchTXTBX.Text;
            String Kazoo;
            if (GViewAllViewByCMBX.SelectedIndex == 0) {
                Kazoo = "concat(ln,', ',fn,' ',mn)";
            } else {
                Kazoo = "concat(StreetNo,', ', Brgy,', ',Street, ', ', City)";
            }

            if (GViewAllSearchTXTBX.Text.Contains("\\")) {
                temp = temp + "?";
            }
            ExtraQueryParams = " where (" + Kazoo + " like '" + temp + "%' OR " + Kazoo + " like '%" + temp + "%' OR " + Kazoo + " LIKe '%" + temp + "')";
            GUARDSRefreshGuardsList();
        }
        #endregion

        #endregion

        #region GMS - Archive 
        private void ArchiveButton_Event(object sender, EventArgs e) {
            // Initialize archive connection.
            DialogResult x = rylui.RylMessageBox.ShowDialog("Are you sure you want to archive the selected record(s)?", "Archive", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (x == DialogResult.Yes) MoveGuardsToArchive(GuardsGID);
        }
        private void MoveGuardsToArchive(List<int> gids) {
            foreach (int gid in gids) {

                SQLTools.MoveRecordToArchive("dependents", "gid", gid);
                SQLTools.DeleteRecord("dependents", "gid", gid);

                SQLTools.MoveRecordToArchive("address", "gid", gid);
                SQLTools.DeleteRecord("address", "gid", gid);

                SQLTools.MoveRecordToArchive("guards", "gid", gid);
                SQLTools.DeleteRecord("guards", "gid", gid);

            }
            rylui.RylMessageBox.ShowDialog((GAllGuardsGRD.SelectedRows.Count + " records moved to guard archive."), "Archive", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GUARDSRefreshGuardsList();

        }

        private void RefreshArchivedGuards() {
          /*  try {
                SQLTools.archiveconn.Open();
                String query = "Select gid,concat(ln,', ',fn,' ',mn) as NAME, " +
                    "" +
                    "bdate as BIRTHDATE, case gender when 1 then 'Male' when 2 then 'Female' end as 'GENDER', " +
                    "cellno as 'CONTACTNO' " +
                    " FROM Guards ";
                MySqlCommand comm = new MySqlCommand(query + ExtraQueryParams, SQLTools.archiveconn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                GArchivedGuardsGRD.DataSource = dt;
         
                GArchivedGuardsGRD.Columns["gid"].Width = 0;
           
                GArchivedGuardsGRD.Columns["name"].Width = 300;
           
                GArchivedGuardsGRD.Columns["contactno"].Width = 250;

                SQLTools.archiveconn.Close();
            }
            catch (Exception ee) {
                conn.Close();
                MessageBox.Show(ee.Message + " \nLine 171 of MainForm.cs");
            } */
        }

        private class ArchiveKeyValuePair {
            ArchiveKeyValuePair(DataTable dt) {

            }
            String column;
            String value;
        }
        private void MoveSpecificGuardToArchive(String a) {

        }
        private List<String> GetColumnHeaders(DataTable dt) {
            List<String> list = new List<String>();
            foreach (DataColumn column in dt.Columns) {
                list.Add(column.ColumnName);
            }
            return list;
        }
        #endregion

        #region GMS - Archive Search
        private void GArchiveSearchBX_Enter(object sender, EventArgs e) {
            if (GArchiveSearchBX.Text.Equals("Search or filter")) {
                GArchiveSearchBX.Text = "";
            }
        }

        private void GArchiveSearchBX_Leave(object sender, EventArgs e) {
            if (GArchiveSearchBX.Text.Equals("")) {
                GArchiveSearchBX.Text = "Search or filter";
                ExtraQueryParams = "";
            }
            ExtraQueryParams = "";
            RefreshArchivedGuards();
            label34.Visible = true;
        }
        private void GArchiveSearchBX_TextChanged(object sender, EventArgs e) {
            String temp = GArchiveSearchBX.Text;
            String Kazoo;

            Kazoo = "name";

            if (GViewAllSearchTXTBX.Text.Contains("\\")) {
                temp = temp + "?";
            }
            ExtraQueryParams = " where (" + Kazoo + " like '" + temp + "%' OR " + Kazoo + " like '%" + temp + "%' OR " + Kazoo + " LIKe '%" + temp + "')";
            RefreshArchivedGuards();
            label34.Visible = false;
        }

        #endregion

        #endregion

        #region Clients Management Page

        #region CMS - Page Load
        public void CLIENTSLoadPage() {
            CViewAllPNL.Show();
            CSummaryPNL.Hide();
            CViewAllClientBTN.Font = selectedFont;
            CViewSummaryBTN.Font = defaultFont;
            try {
                conn.Open();
                MySqlCommand comm = new MySqlCommand("SELECT * FROM client WHERE cstatus = 1", conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                CActiveClientLBL.Text = dt.Rows.Count + " active clients";
                conn.Close();
            }
            catch (Exception ee) {
                conn.Close();
            }
            try {
                conn.Open();
                MySqlCommand comm = new MySqlCommand("SELECT * FROM client", conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                CTotalClientLBL.Text = dt.Rows.Count + " total clients";
                conn.Close();
            }
            catch (Exception ee) {
                conn.Close();
            }
            CLIENTSRefreshClientsList();
        }
        #endregion

        #region CMS - Side Panel
        private void CAddClientBTN_Click(object sender, EventArgs e) {
            try {
                Clients_Edit view = new Clients_Edit();
                view.reference = this;
                view.conn = this.conn;
                view.Location = new Point(this.Location.X + 277, this.Location.Y + 33);
                view.ShowDialog();
            }
            catch (Exception) { }
        }
        private void CViewAllClientBTN_Click(object sender, EventArgs e) {
            CViewAllPNL.Show();
            CSummaryPNL.Hide();
            CViewAllClientBTN.Font = selectedFont;
            CViewSummaryBTN.Font = defaultFont;
        }

        private void CViewSummaryBTN_Click(object sender, EventArgs e) {
            CViewAllPNL.Hide();
            CSummaryPNL.Show();
            CViewAllClientBTN.Font = defaultFont;
            CViewSummaryBTN.Font = selectedFont;
        }

        private void CViewArchiveBTN_Click(object sender, EventArgs e) {
            CViewAllPNL.Hide();
            CSummaryPNL.Hide();
            CViewAllClientBTN.Font = defaultFont;
            CViewSummaryBTN.Font = defaultFont;
        }

        #endregion

        #region View All

        #region CMS - View All Data Grid
        public void CLIENTSRefreshClientsList() {
            try {
                conn.Open();
                MySqlCommand comm = new MySqlCommand("SELECT cid, name, CONCAT(Clientstreetno,' ',Clientstreet,', ', Clientbrgy,', ',Clientcity) AS contactno FROM client" + ExtraQueryParams, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                CClientListTBL.DataSource = dt;
                CClientListTBL.Columns["cid"].HeaderText = "ID";
                CClientListTBL.Columns["cid"].Visible = false;
                CClientListTBL.Columns["name"].HeaderText = "NAME";
                CClientListTBL.Columns["name"].Width = 310;
                CClientListTBL.Columns["contactno"].HeaderText = "LOCATION";
                CClientListTBL.Columns["contactno"].Width = 310;

                conn.Close();
            }
            catch (Exception ee) {
                conn.Close();
                MessageBox.Show(ee.Message + " \nLine 171 of MainForm.cs");
            }
        }
        private void CViewAllClientsTBL_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e) {
            // For any other operation except, StateChanged, do nothing
            if (e.StateChanged != DataGridViewElementStates.Selected) return;

            ClientsCID.Clear();  // Clear array of selected guards b4 moving to new selection.
            try {
                // Multi-select compatible.
                // Parse in method to get specific guard (i.e. single selections)
                foreach (DataGridViewRow row in CClientListTBL.SelectedRows) {
                    ClientsCID.Add(int.Parse(row.Cells[0].Value.ToString()));
                }
                //rylui.RylMessageBox.ShowDialog(GuardsGID.Count.ToString());
                // Single Cell Selections (Old Code)
                //ClientsCID = int.Parse(GAllGuardsGRD.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            catch { }
        }

        List<int> ClientsCID = new List<int>();
        private void CViewDetailsBTN_Click(object sender, EventArgs e) {
            try {
                Clients_View view = new Clients_View();
                if (ClientsCID.Count > 1) {
                    rylui.RylMessageBox.ShowDialog("More than 1 client is selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } else if (ClientsCID.Count == 0) {
                    rylui.RylMessageBox.ShowDialog("No client is selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } else {
                    view.CID = ClientsCID[0];
                    view.reference = this;
                    view.conn = this.conn;
                    view.Location = new Point(this.Location.X + 277, this.Location.Y + 33);
                    view.ShowDialog();
                }
            }
            catch (Exception) { }
        }


        #endregion

        #region CMS - View All Search
        private void CViewAllSearchBX_Enter(object sender, EventArgs e) {
            if (CViewAllSearchBX.Text.Equals("Search or filter")) {
                CViewAllSearchBX.Text = "";
            }
        }

        private void CViewAllSearchBX_Leave(object sender, EventArgs e) {
            if (CViewAllSearchBX.Text.Equals("")) {
                CViewAllSearchBX.Text = "Search or filter";
            }
            ExtraQueryParams = "";
            CLIENTSRefreshClientsList();
        }
        private void CViewAllSearchBX_TextChanged(object sender, EventArgs e) {
            String temp = CViewAllSearchBX.Text;
            String Kazoo;

            Kazoo = "name";

            if (CViewAllSearchBX.Text.Contains("\\")) {
                temp = temp + "?";
            }
            ExtraQueryParams = " where (" + Kazoo + " like '" + temp + "%' OR " + Kazoo + " like '%" + temp + "%' OR " + Kazoo + " LIKe '%" + temp + "')";
            CLIENTSRefreshClientsList();
        }


        #endregion

        #endregion

        #endregion

        #region Schedules Management System
        /* Available Methods:
         * --public static DataTable Scheduling.AddAssignmentRequest(int CID, string AssStreetNo, string AssStreetName, string AssBrgy, string AssCity, DateTime ContractStart, DateTime ContractEnd, int NoGuards)
           --public static DataTable Scheduling.GetClients(DateTime date)
                -- or alternatively: Client.GetClient(DateTime date)
           --public static DataTable Scheduling.GetRequests() 
        */

        #region SMS - Page Load
        public void SCHEDLoadPage() {
            SArchivePNL.Hide();
            SDutyDetailsPNL.Hide();
            SIncidentPNL.Hide();
            SMonthlyDutyPNL.Hide();
            SViewAssPNL.Hide();
            SViewReqPNL.Show();

            SDutyDetailsBTN.Font = defaultFont;
            SIncidentBTN.Font = defaultFont;
            SMonthlyDutyBTN.Font = defaultFont;
            SViewAssBTN.Font = defaultFont;
            SViewReqBTN.Font = selectedFont;
            SArchiveBTN.Font = defaultFont;

            SViewReqAssBTN.Visible = true;

            SCHEDLoadRequestsPage();

            SClientRequestsLBL.Text = Scheduling.GetNumberOfClientRequests(Enumeration.RequestStatus.Pending) + " pending requests";
            SUnassignedGuardsLBL.Text = Scheduling.GetNumberOfUnassignedGuards() + " unsassigned guards";
            SAssignedGuardsLBL.Text = Scheduling.GetNumberOfAssignedGuards() + " assigned guards";
        }
        #endregion

        #region SMS - Side Panel
        private void SViewReqBTN_Click(object sender, EventArgs e) {
            SArchivePNL.Hide();
            SDutyDetailsPNL.Hide();
            SIncidentPNL.Hide();
            SMonthlyDutyPNL.Hide();
            SViewAssPNL.Hide();
            SViewReqPNL.Show();

            SDutyDetailsBTN.Font = defaultFont;
            SIncidentBTN.Font = defaultFont;
            SMonthlyDutyBTN.Font = defaultFont;
            SViewAssBTN.Font = defaultFont;
            SViewReqBTN.Font = selectedFont;
            SArchiveBTN.Font = defaultFont;

            SViewReqAssBTN.Visible = true;

            SCHEDLoadRequestsPage();
        }
        private void SViewAssBTN_Click(object sender, EventArgs e) {
            SArchivePNL.Hide();
            SDutyDetailsPNL.Hide();
            SIncidentPNL.Hide();
            SMonthlyDutyPNL.Hide();
            SViewAssPNL.Show();
            SViewReqPNL.Hide();
            
            SDutyDetailsBTN.Font = defaultFont;
            SIncidentBTN.Font = defaultFont;
            SMonthlyDutyBTN.Font = defaultFont;
            SViewAssBTN.Font = selectedFont;
            SViewReqBTN.Font = defaultFont;
            SArchiveBTN.Font = defaultFont;

            SViewReqAssBTN.Visible = false;

            SCHEDLoadAssignmentPage();
        }
        private void SMonthlyDutyBTN_Click(object sender, EventArgs e) {
            SArchivePNL.Hide();
            SDutyDetailsPNL.Hide();
            SIncidentPNL.Hide();
            SMonthlyDutyPNL.Show();
            SViewAssPNL.Hide();
            SViewReqPNL.Hide();

            SDutyDetailsBTN.Font = defaultFont;
            SIncidentBTN.Font = defaultFont;
            SMonthlyDutyBTN.Font = selectedFont;
            SViewAssBTN.Font = defaultFont;
            SViewReqBTN.Font = defaultFont;
            SArchiveBTN.Font = defaultFont;

            SViewReqAssBTN.Visible = false;
        }
        private void SDutyDetailsBTN_Click(object sender, EventArgs e) {
            SArchivePNL.Hide();
            SDutyDetailsPNL.Show();
            SIncidentPNL.Hide();
            SMonthlyDutyPNL.Hide();
            SViewAssPNL.Hide();
            SViewReqPNL.Hide();

            SDutyDetailsBTN.Font = selectedFont;
            SIncidentBTN.Font = defaultFont;
            SMonthlyDutyBTN.Font = defaultFont;
            SViewAssBTN.Font = defaultFont;
            SViewReqBTN.Font = defaultFont;
            SArchiveBTN.Font = defaultFont;

            SViewReqAssBTN.Visible = false;
        }
        private void SIncidentBTN_Click(object sender, EventArgs e) {
            SArchivePNL.Hide();
            SDutyDetailsPNL.Hide();
            SIncidentPNL.Show();
            SMonthlyDutyPNL.Hide();
            SViewAssPNL.Hide();
            SViewReqPNL.Hide();

            SDutyDetailsBTN.Font = defaultFont;
            SIncidentBTN.Font = selectedFont;
            SMonthlyDutyBTN.Font = defaultFont;
            SViewAssBTN.Font = defaultFont;
            SViewReqBTN.Font = defaultFont;
            SArchiveBTN.Font = defaultFont;

            SViewReqAssBTN.Visible = false;
        }
        private void SArchiveBTN_Click(object sender, EventArgs e) {
            SArchivePNL.Show();
            SDutyDetailsPNL.Hide();
            SIncidentPNL.Hide();
            SMonthlyDutyPNL.Hide();
            SViewAssPNL.Hide();
            SViewReqPNL.Hide();

            SDutyDetailsBTN.Font = defaultFont;
            SIncidentBTN.Font = defaultFont;
            SMonthlyDutyBTN.Font = defaultFont;
            SViewAssBTN.Font = defaultFont;
            SViewReqBTN.Font = defaultFont;
            SArchiveBTN.Font = selectedFont;

            SViewReqAssBTN.Visible = false;
        }
        private void SViewReqAssBTN_Click(object sender, EventArgs e) {
            try {
                Sched_RequestGuard view = new Sched_RequestGuard();
                view.reference = this;
                view.conn = this.conn;
                view.Location = new Point(this.Location.X + 277, this.Location.Y + 33);
                view.ShowDialog();
            }
            catch (Exception) { }
        }
        private void SViewReqDisBTN_Click(object sender, EventArgs e) {
            try {
                Sched_DismissGuard view = new Sched_DismissGuard();
                view.reference = this;
                view.conn = this.conn;
                view.Location = new Point(this.Location.X + 277, this.Location.Y + 33);
                view.ShowDialog();
            }
            catch (Exception) { }
        }
        #endregion

        #region SMS - View Assignment
        private void SCHEDLoadAssignmentPage() {
            SViewAssSearchClientCMBX.Items.Clear();
            SViewAssSearchClientCMBX.Items.Add(new ComboBoxItem("All", "-1"));
            SViewAssSearchClientCMBX.SelectedIndex = 0;
            SViewAssCMBX.SelectedIndex = 0;
            

            DataView dv = Client.GetClients().DefaultView;
            dv.Sort = "name asc";
            DataTable dt = dv.ToTable();

            for (int i = 0; i < dt.Rows.Count; i++) SViewAssSearchClientCMBX.Items.Add(new ComboBoxItem(dt.Rows[i][1].ToString(), dt.Rows[i][0].ToString()));
        }
        private void SViewAssSearchClientCMBX_SelectedValueChanged(object sender, EventArgs e) {
            SViewAssCMBX.SelectedIndex = 0;
            SCHEDRefreshAssignments();
        }
        private void SCHEDRefreshAssignments() {
            SViewAssGRD.DataSource = Scheduling.GetAssignmentsByClient(int.Parse(((ComboBoxItem)SViewAssSearchClientCMBX.SelectedItem).ItemID), SViewAssCMBX.SelectedIndex);
            SViewAssGRD.Columns[0].Visible = false;
            SViewAssGRD.Columns[1].Visible = false;
            SViewAssGRD.Columns[2].Visible = false;
            SViewAssGRD.Columns[3].HeaderText = "NAME";
            SViewAssGRD.Columns[4].HeaderText = "ASSIGNMENT LOCATION";
            SViewAssGRD.Columns[5].HeaderText = "SCHEDULE";

            SViewAssGRD.Columns[3].Width = 230;
            SViewAssGRD.Columns[4].Width = 250;
            SViewAssGRD.Columns[5].Width = 150;

            SViewAssGRD.Sort(SViewAssGRD.Columns[3], ListSortDirection.Ascending);
            SCHEDViewAssGRDButtonChecker();
            SViewAssGRD.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void SViewAssCMBX_SelectedIndexChanged(object sender, EventArgs e) {
            SCHEDRefreshAssignments();
        }
        private void SViewAssGRD_CellEnter(object sender, DataGridViewCellEventArgs e) {
            SCHEDViewAssGRDButtonChecker();
        }

        private void SCHEDViewAssGRDButtonChecker() {
            if (SViewAssGRD.Rows.Count == 0) {
                SViewAssAddDutyBTN.Visible = false;
                SViewAssViewDetailsBTN.Visible = false;
                SVIewAssDisBTN.Visible = false;
                SViewAssUnassignBTN.Visible = false;
            } else {
                if (SViewAssGRD.SelectedRows.Count == 0) SViewAssGRD.Rows[0].Selected = true;

                if (SViewAssGRD.SelectedRows.Count > 1) {
                    SViewAssAddDutyBTN.Visible = false;
                    SViewAssViewDetailsBTN.Visible = false;
                    SVIewAssDisBTN.Visible = true;
                    SViewAssUnassignBTN.Visible = false;
                } else if (SViewAssGRD.SelectedRows[0].Cells[5].Value.ToString().Equals("Unscheduled")) {
                    SViewAssAddDutyBTN.Visible = true;
                    SViewAssViewDetailsBTN.Visible = false;
                    SVIewAssDisBTN.Visible = false;
                    SViewAssUnassignBTN.Visible = true;
                } else {
                    SViewAssAddDutyBTN.Visible = false;
                    SViewAssViewDetailsBTN.Visible = true;
                    SVIewAssDisBTN.Visible = true;
                    SViewAssUnassignBTN.Visible = false;
                }
            }
        }
        private void SViewAssSearchTXTBX_Enter(object sender, EventArgs e) {
            if (SViewAssSearchTXTBX.Text == FilterText) {
                SViewAssSearchTXTBX.Text = EmptyText;
                ExtraQueryParams = EmptyText;
            }
            SViewAssSearchLine.Visible = true;
        }
        private void SViewAssSearchTXTBX_Leave(object sender, EventArgs e) {
            if (SViewAssSearchTXTBX.Text == EmptyText) {
                SViewAssSearchTXTBX.Text = FilterText;
                ExtraQueryParams = EmptyText;
            }
            SCHEDRefreshAssignments();
            SViewAssSearchLine.Visible = false;
        }
        private void SViewAssAddDutyBTN_Click(object sender, EventArgs e) {
            try {
                Sched_AddDutyDetail view = new Sched_AddDutyDetail();
                view.reference = this;
                view.conn = this.conn;
                view.AID = int.Parse(this.SViewAssGRD.SelectedRows[0].Cells[0].Value.ToString());
                view.Location = new Point(this.Location.X + 277, this.Location.Y + 33);
                view.ShowDialog();
            }
            catch (Exception) { }
        }
        private void SViewAssViewDetailsBTN_Click(object sender, EventArgs e) {
            try {
                Sched_ViewDutyDetails view = new Sched_ViewDutyDetails();
                view.reference = this;
                view.conn = this.conn;
                view.Location = new Point(this.Location.X + 277, this.Location.Y + 33);
                view.ShowDialog();
            }
            catch (Exception) { }
        }
        #endregion

        #region SMS - View Requests
        int RID;
        private void SViewReqGRD_CellEnter(object sender, DataGridViewCellEventArgs e) {
            RID = int.Parse(SViewReqGRD.Rows[e.RowIndex].Cells[0].Value.ToString());
        }
        private void SViewReqFilterCMBX_SelectedIndexChanged(object sender, EventArgs e) {
            LoadViewReqTable(Scheduling.GetRequests(SViewReqSearchTXTBX.Text, -1, SViewReqFilterCMBX.SelectedIndex, "name", "name asc"));
        }
        bool ChangeDate;
        private void SViewReqDTPK_ValueChanged(object sender, EventArgs e) {
            LoadViewReqTable(Scheduling.GetRequests(SViewReqSearchTXTBX.Text, -1, SViewReqFilterCMBX.SelectedIndex, "name", "name asc", SViewReqDTPK.Value));
            ChangeDate = true;
        }
        private void SViewReqResetDateBTN_Click(object sender, EventArgs e) {
            LoadViewReqTable(Scheduling.GetRequests("", -1, 0, "name", "name asc"));
            ChangeDate = false;
        }
        private void SCHEDLoadRequestsPage() {
            SViewReqFilterCMBX.SelectedIndex = 0;
            SCHEDRefreshRequests();
        }
        public void SCHEDRefreshRequests() {
            LoadViewReqTable(Scheduling.GetRequests("", -1, SViewReqFilterCMBX.SelectedIndex, "name", "name asc"));
        }
        private void SViewReqSearchTXTBX_TextChanged(object sender, EventArgs e) {
            if (ChangeDate) LoadViewReqTable(Scheduling.GetRequests(SViewReqSearchTXTBX.Text, -1, SViewReqFilterCMBX.SelectedIndex, "name", "name asc", SViewReqDTPK.Value));
            else LoadViewReqTable(Scheduling.GetRequests(SViewReqSearchTXTBX.Text, -1, SViewReqFilterCMBX.SelectedIndex, "name", "name asc"));
        }
        private void LoadViewReqTable(DataTable dv) {
            SViewReqGRD.DataSource = dv;
            SViewReqGRD.Columns["rid"].Visible = false;
            SViewReqGRD.Columns["name"].HeaderText = "NAME";
            SViewReqGRD.Columns["dateentry"].HeaderText = "DATE ENTRY";
            SViewReqGRD.Columns["dateentry"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            SViewReqGRD.Columns["type"].HeaderText = "TYPE";

            SViewReqGRD.Columns["name"].Width = 350;
            SViewReqGRD.Columns["dateentry"].Width = 200;
            SViewReqGRD.Columns["type"].Width = 100;
        }
        private void SViewReqSearchTXTBX_Enter(object sender, EventArgs e) {
            if (SViewReqSearchTXTBX.Text == FilterText) {
                SViewReqSearchTXTBX.Text = EmptyText;
                ExtraQueryParams = EmptyText;
            }
            SViewReqSearchLine.Visible = true;
        }
        private void SViewReqSearchTXTBX_Leave(object sender, EventArgs e) {
            if (SViewReqSearchTXTBX.Text == EmptyText) {
                SViewReqSearchTXTBX.Text = FilterText;
                ExtraQueryParams = EmptyText;
            }
            SCHEDRefreshRequests();
            SViewReqSearchLine.Visible = false;
        }
        private void SViewReqViewBTN_Click(object sender, EventArgs e) {
            if (SViewReqGRD.SelectedRows[0].Cells[3].Value.ToString().Equals("Assignment")) {
                try {
                    Sched_ViewAssReq view = new Sched_ViewAssReq();
                    view.reference = this;
                    view.RAID = this.RID;
                    view.conn = this.conn;
                    view.Location = new Point(this.Location.X + 277, this.Location.Y + 33);
                    view.ShowDialog();
                }
                catch (Exception) { }
            } else if (SViewReqGRD.SelectedRows[0].Cells[3].Value.ToString().Equals("Dismissal")) {
                try {
                    Sched_ViewDisReq view = new Sched_ViewDisReq();
                    view.reference = this;
                    view.conn = this.conn;
                    view.RID = this.RID;
                    view.Location = new Point(this.Location.X + 277, this.Location.Y + 33);
                    view.ShowDialog();
                }
                catch (Exception) { }
            }
        }
        #endregion

        #region SMS - Archive
        private void SCHEDRefreshArchive() {
        }
        private void SArchiveSearchTXTBX_Enter(object sender, EventArgs e) {
            if (SArchiveSearchTXTBX.Text == FilterText) {
                SArchiveSearchTXTBX.Text = EmptyText;
                ExtraQueryParams = EmptyText;
            }
            SArchiveSearchLine.Visible = true;
        }
        private void SArchiveViewDetailsBTN_Click(object sender, EventArgs e) {
            try {
                Sched_ViewDutyDetails view = new Sched_ViewDutyDetails();
                view.reference = this;
                view.conn = this.conn;
                view.Location = new Point(this.Location.X + 277, this.Location.Y + 33);
                view.ShowDialog();
            }
            catch (Exception) { }
        }
        private void SArchiveSearchTXTBX_Leave(object sender, EventArgs e) {
            if (SArchiveSearchTXTBX.Text == EmptyText) {
                SArchiveSearchTXTBX.Text = FilterText;
                ExtraQueryParams = EmptyText;
            }
            SCHEDRefreshArchive();
            SArchiveSearchTXTBX.Visible = false;
        }








        #endregion

        #endregion

        #region Payroll Management System

        #region PMS - Load/Side Panel
        private void PAYLoadPage() {
            PAYChangePanel(0);
        }

        private void PEmpListBTN_Click(object sender, EventArgs e) {
            PAYChangePanel(1);
        }
        private void PAdjustBTN_Click(object sender, EventArgs e) {
            PAYChangePanel(2);
        }

        private void PCashAdvBTN_Click(object sender, EventArgs e) {
            PAYChangePanel(3);
        }

        private void PPayrollSummaryBTN_Click(object sender, EventArgs e) {
            PAYChangePanel(4);
        }

        private void PSalaryReportBTN_Click(object sender, EventArgs e) {
            PAYChangePanel(5);
        }

        private void PArchiveBTN_Click(object sender, EventArgs e) {
            PAYChangePanel(6);
        }
        private void PAYChangePanel(int x) {
            switch (x) {
                case 0:
                    PCashAdvBTN.Font = defaultFont;
                    PEmpListBTN.Font = defaultFont;
                    PArchiveBTN.Font = defaultFont;
                    PAdjustBTN.Font = defaultFont;
                    PPayrollSummaryBTN.Font = selectedFont;
                    PSalaryReportBTN.Font = defaultFont;

                    PAdjustBTN.Visible = false;
                    PAddCashAdvBTN.Visible = false;
                     
                    PSalaryReportPage.Hide();
                    PAdjustmentHistoryPage.Hide();
                    PEmpListPage.Hide();
                    PArchivePage.Hide();
                    PCashAdvancePage.Hide();
                    PPayrollSummaryPage.Show();
                    break;
                case 1:
                    PCashAdvBTN.Font = defaultFont;
                    PEmpListBTN.Font = selectedFont;
                    PArchiveBTN.Font = defaultFont;
                    PAdjustBTN.Font = defaultFont;
                    PPayrollSummaryBTN.Font = defaultFont;
                    PSalaryReportBTN.Font = defaultFont;

                    PAdjustBTN.Visible = true;
                    PAddCashAdvBTN.Visible = false;

                    PSalaryReportPage.Hide();
                    PEmpListPage.Show();
                    PAdjustmentHistoryPage.Hide();
                    PArchivePage.Hide();
                    PCashAdvancePage.Hide();
                    PPayrollSummaryPage.Hide();
                    break;
                case 2:
                    PCashAdvBTN.Font = defaultFont;
                    PEmpListBTN.Font = defaultFont;
                    PArchiveBTN.Font = defaultFont;
                    PAdjustBTN.Font = selectedFont;
                    PPayrollSummaryBTN.Font = defaultFont;
                    PSalaryReportBTN.Font = defaultFont;

                    PAdjustBTN.Visible = true;
                    PAddCashAdvBTN.Visible = false;

                    PSalaryReportPage.Hide();
                    PAdjustmentHistoryPage.Show();
                    PEmpListPage.Hide();
                    PArchivePage.Hide();
                    PCashAdvancePage.Hide();
                    PPayrollSummaryPage.Hide();
                    break;
                case 3:
                    PCashAdvBTN.Font = selectedFont;
                    PEmpListBTN.Font = defaultFont;
                    PArchiveBTN.Font = defaultFont;
                    PAdjustBTN.Font = defaultFont;
                    PPayrollSummaryBTN.Font = defaultFont;
                    PSalaryReportBTN.Font = defaultFont;

                    PAdjustBTN.Visible = false;
                    PAddCashAdvBTN.Visible = true;

                    PSalaryReportPage.Hide();
                    PAdjustmentHistoryPage.Hide();
                    PEmpListPage.Hide();
                    PArchivePage.Hide();
                    PCashAdvancePage.Show();
                    PPayrollSummaryPage.Hide();
                    break;
                case 4:
                    PCashAdvBTN.Font = defaultFont;
                    PEmpListBTN.Font = defaultFont;
                    PArchiveBTN.Font = defaultFont;
                    PAdjustBTN.Font = defaultFont;
                    PPayrollSummaryBTN.Font = selectedFont;
                    PSalaryReportBTN.Font = defaultFont;

                    PAdjustBTN.Visible = false;
                    PAddCashAdvBTN.Visible = false;

                    PSalaryReportPage.Hide();
                    PAdjustmentHistoryPage.Hide();
                    PEmpListPage.Hide();
                    PArchivePage.Hide();
                    PCashAdvancePage.Hide();
                    PPayrollSummaryPage.Show();
                    break;
                case 5:
                    PCashAdvBTN.Font = defaultFont;
                    PEmpListBTN.Font = defaultFont;
                    PArchiveBTN.Font = defaultFont;
                    PAdjustBTN.Font = defaultFont;
                    PPayrollSummaryBTN.Font = defaultFont;
                    PSalaryReportBTN.Font = selectedFont;

                    PAdjustBTN.Visible = false;
                    PAddCashAdvBTN.Visible = false;

                    PSalaryReportPage.Show();
                    PAdjustmentHistoryPage.Hide();
                    PEmpListPage.Hide();
                    PArchivePage.Hide();
                    PCashAdvancePage.Hide();
                    PPayrollSummaryPage.Hide();
                    break;
                case 6:
                    PCashAdvBTN.Font = defaultFont;
                    PEmpListBTN.Font = defaultFont;
                    PArchiveBTN.Font = selectedFont;
                    PAdjustBTN.Font = defaultFont;
                    PPayrollSummaryBTN.Font = defaultFont;
                    PSalaryReportBTN.Font = defaultFont;

                    PAdjustBTN.Visible = false;
                    PAddCashAdvBTN.Visible = false;

                    PSalaryReportPage.Hide();
                    PAdjustmentHistoryPage.Hide();
                    PEmpListPage.Hide();
                    PArchivePage.Show();
                    PCashAdvancePage.Hide();
                    PPayrollSummaryPage.Hide();
                    break;
            }
        }
        #endregion

        #endregion


    }
}