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


/*
         ███╗   ███╗ █████╗ ██╗  ██╗ █████╗ ██████╗  █████╗ ██╗   ██╗ █████╗ ███╗   ██╗
        ████╗ ████║██╔══██╗██║ ██╔╝██╔══██╗██╔══██╗██╔══██╗╚██╗ ██╔╝██╔══██╗████╗  ██║
        ██╔████╔██║███████║█████╔╝ ███████║██████╔╝███████║ ╚████╔╝ ███████║██╔██╗ ██║
        ██║╚██╔╝██║██╔══██║██╔═██╗ ██╔══██║██╔══██╗██╔══██║  ╚██╔╝  ██╔══██║██║╚██╗██║
        ██║ ╚═╝ ██║██║  ██║██║  ██╗██║  ██║██████╔╝██║  ██║   ██║   ██║  ██║██║ ╚████║
        ╚═╝     ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝╚═════╝ ╚═╝  ╚═╝   ╚═╝   ╚═╝  ╚═╝╚═╝  ╚═══╝
                                                                              
        ███████╗███████╗ ██████╗██╗   ██╗██████╗ ██╗████████╗██╗   ██╗                
        ██╔════╝██╔════╝██╔════╝██║   ██║██╔══██╗██║╚══██╔══╝╚██╗ ██╔╝                
        ███████╗█████╗  ██║     ██║   ██║██████╔╝██║   ██║    ╚████╔╝                 
        ╚════██║██╔══╝  ██║     ██║   ██║██╔══██╗██║   ██║     ╚██╔╝                  
        ███████║███████╗╚██████╗╚██████╔╝██║  ██║██║   ██║      ██║                   
        ╚══════╝╚══════╝ ╚═════╝ ╚═════╝ ╚═╝  ╚═╝╚═╝   ╚═╝      ╚═╝                   
                                                                              
         █████╗  ██████╗ ███████╗███╗   ██╗ ██████╗██╗   ██╗                          
        ██╔══██╗██╔════╝ ██╔════╝████╗  ██║██╔════╝╚██╗ ██╔╝                          
        ███████║██║  ███╗█████╗  ██╔██╗ ██║██║      ╚████╔╝                           
        ██╔══██║██║   ██║██╔══╝  ██║╚██╗██║██║       ╚██╔╝                            
        ██║  ██║╚██████╔╝███████╗██║ ╚████║╚██████╗   ██║                             
        ╚═╝  ╚═╝ ╚═════╝ ╚══════╝╚═╝  ╚═══╝ ╚═════╝   ╚═╝                             
                                                                              
         **/


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

        #region Form Initiation and load
        public MainForm() {
            InitializeComponent();
            initiateForm();
            conn = SQLTools.conn;
            FadeTMR.Start();
        }
        private void initiateForm() {
            DashboardPage.Visible = true;
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
            try {
                conn.Open();
                MySqlCommand comm = new MySqlCommand("SELECT * FROM guards WHERE gstatus = 1", conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                GActiveLBL.Text = dt.Rows.Count + " active guards";
                conn.Close();
            }
            catch (Exception ee) {
                conn.Close();
            }
            try {
                conn.Open();
                MySqlCommand comm = new MySqlCommand("SELECT * FROM guards WHERE gstatus = 2", conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                GInactiveLBL.Text = dt.Rows.Count + " inactive guards";
                conn.Close();
            }
            catch (Exception ee) {
                conn.Close();
            }
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

        public void GUARDSRefreshGuardsList() {
            // All column names should be done in SQL Query
            try {
                String query = "Select gid,concat(ln,', ',fn,' ',mn) as NAME, " +
                    "case gstatus when 1 then 'Active' when 2 then 'Inactive' end as 'STATUS', " +
                    "bdate as BIRTHDATE, case gender when 1 then 'Male' when 2 then 'Female' end as 'GENDER', " +
                    "cellno as 'CONTACTNO' " +
                    "FROM Guards ";
                String orderbyclause = "ORDER BY NAME ASC;";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(query + ExtraQueryParams + orderbyclause, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                GAllGuardsGRD.DataSource = dt;
                // 0 must always be ID.
                GAllGuardsGRD.Columns[0].Width = 0;
                GAllGuardsGRD.Columns["NAME"].Width = 240;
                GAllGuardsGRD.Columns["GENDER"].Width = 80;
                GAllGuardsGRD.Columns["GENDER"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GAllGuardsGRD.Columns["BIRTHDATE"].Width = 80;
                GAllGuardsGRD.Columns["BIRTHDATE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GAllGuardsGRD.Columns["CONTACTNO"].Width = 140;
                
                GAllGuardsGRD.Columns["STATUS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GAllGuardsGRD.Columns["STATUS"].Width = 70;

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
        String FilterText = "Search or filter";
        String EmptyText = "";
        private void GViewAllSearchTXTBX_Enter(object sender, EventArgs e) {
            if (GViewAllSearchTXTBX.Text == FilterText) {
                GViewAllSearchTXTBX.Text = EmptyText;
                ExtraQueryParams = EmptyText;

            }
        }

        private void GViewAllSearchTXTBX_Leave(object sender, EventArgs e) {
            if (GViewAllSearchTXTBX.Text == EmptyText) {
                GViewAllSearchTXTBX.Text = FilterText;
                ExtraQueryParams = EmptyText;
            }
            GUARDSRefreshGuardsList();
        }

        private void GViewAllSearchTXTBX_TextChanged(object sender, EventArgs e) {
            String temp = GViewAllSearchTXTBX.Text;
            String Kazoo;

                Kazoo = "concat(ln,', ',fn,' ',mn)";

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
            try {
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
            }
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
        }

        #endregion

        #endregion

        #region Clients Management Page

        #region CMS - Page Load
        public void CLIENTSLoadPage() {
            CViewAllPNL.Show();
            CSummaryPNL.Hide();
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
                CClientListTBL.Columns["cid"].Width = 0;
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
    }
}