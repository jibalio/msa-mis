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
using System.IO;
using System.Runtime.InteropServices;

namespace MSAMISUserInterface {
    public partial class MainForm : Form {

        //Only Paste Global Variable Here//

        public MySqlConnection conn;
        public LoginForm lf;
        Point newFormLocation;
        Shadow shadow = new Shadow();

        Font selectedFont = new Font("Segoe UI Semibold", 10);
        Font defaultFont = new Font("Segoe UI Semilight", 10);

        Panel ScurrentPanel;
        Button ScurrentBTN;

        String FilterText = "Search or filter";
        String EmptyText = "";
        String ExtraQueryParams = "";

        public String user;


        #region Form Initiation and load
        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            //Get the relative position after loading
            newFormLocation = new Point(this.Location.X+50, this.Location.Y + 66);
            shadow.Location = this.Location;

            //Initiate the methods that updates the app
            initiateForm();
        }

        private void initiateForm() {
            //This method is used to initiate the look and feel of the Main Form
            //Can also be used to initiate global variables

            //Main Form Arrangement
            DashboardPage.BringToFront();
            ControlBoxPanel.BringToFront();
            SamplePNL.SendToBack();

            //Buttons Color
            currentBTN = DashboardBTN;
            currentPage = SamplePNL;
            ControlBoxPanel.BackColor = dahsbard;

            //Variable Initialization
            conn = SQLTools.conn;
            ControlBoxTimeLBL.Text = "Logged in as, " + user;
            TimeLBL.Text = DateTime.Now.ToString("dddd, MMMM dd yyyy").ToUpper();
            ScurrentPanel = GViewAllPNL;
            ScurrentBTN = GViewAllPageBTN;

            //Initial Methods
            DailyQuote();
            FadeTMR.Start();
        }

        private void DailyQuote() {
            //This is an extra method to intitate the Daily Quotes behind the Dashboard=

            var lines = File.ReadAllLines("../../Resources/Quotes.txt");
            var r = new Random();
            var randomLineNumber = r.Next(0, lines.Length - 1);
            if (randomLineNumber % 2 != 0) randomLineNumber = randomLineNumber - 1;
            QuoteMainBX.Text = '"' + lines[randomLineNumber] + '"';
            QuoteFromBX.Text = "from " + lines[randomLineNumber + 1];
            if (DateTime.Now.Month == 7) {
                DevBX.Visible = true;
                HBDLBL.Visible = true;
                if (DateTime.Now.Day == 1) DevBX.Text = "Jan Leryc V. Ibalio - MSAMIS Dev";
                else if (DateTime.Now.Day == 18) DevBX.Text = "Anton John B. Pasigado - MSAMIS Dev";
                else {
                    HBDLBL.Visible = false;
                    DevBX.Visible = false;
                }
            } else if (DateTime.Now.Month == 5 && DateTime.Now.Day == 5) {
                DevBX.Text = "Rhyle Abram P. Regodon - MSAMIS Dev";
                HBDLBL.Visible = true;
                DevBX.Visible = true;
            } else {
                HBDLBL.Visible = false;
                DevBX.Visible = false;
            }
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            //For the Logout Button on the Control Box
            this.Close();
        }

        private void LoadNotifications() {
            //To Initiate the the Tooltip notifications

            //Scheduling Tooltip Page Notification

            if (!Scheduling.GetNumberOfClientRequests(Enumeration.RequestStatus.Pending).Equals("0")) {
                ClientRequestsTLTP.Show("You have " + Scheduling.GetNumberOfClientRequests(Enumeration.RequestStatus.Pending) + " pending requests.", SchedBTN, 2000);
                ClientRequestsTLTP.Show("You have " + Scheduling.GetNumberOfClientRequests(Enumeration.RequestStatus.Pending) + " pending requests.", SchedBTN, 2000);
                SchedBTN.Text = Scheduling.GetNumberOfClientRequests(Enumeration.RequestStatus.Pending).ToString();
            } else SchedBTN.Text = String.Empty;
        }
        #endregion

        #region Form Features

        #region Enable Dragging of Form
        bool mouseDown;
        Point lastLocation;

        private void Form_MouseUp(object sender, MouseEventArgs e) {
            mouseDown = false;
        }
        private void Form_MouseDown(object sender, MouseEventArgs e) {
            mouseDown = true;
            lastLocation = e.Location;
        }
        private void Form_MouseMove(object sender, MouseEventArgs e) {
            if (mouseDown) {
                this.Location = new Point((this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                this.Update();
            }
        }
        #endregion

        #region Slide-Up Dashboard
        private void Dashboard_MouseUp(object sender, MouseEventArgs e) {
            mouseDown = false;
            if (DashboardPage.Location.Y <= -300) {
                if (DashboardPage.Location.Y <= -568) DashboardPage.Location = new Point(DashboardPage.Location.X, -628);
                else if (DashboardPage.Location.Y <= -448) DashboardPage.Location = new Point(DashboardPage.Location.X, -508);
                else if (DashboardPage.Location.Y <= -300) DashboardPage.Location = new Point(DashboardPage.Location.X, -328);
                RecordsBTN.PerformClick();
            } else {
                if (DashboardPage.Location.Y > -148) DashboardPage.Location = new Point(DashboardPage.Location.X, -28);
                else if (DashboardPage.Location.Y > -208) DashboardPage.Location = new Point(DashboardPage.Location.X, -148);
                else DashboardPage.Location = new Point(DashboardPage.Location.X, -268);
                DashboardToBeMinimized = false;
                DashboardTMR.Start();
            }
        }
        private void Dashboard_MouseMove(object sender, MouseEventArgs e) {
            if (mouseDown) 
                if (((DashboardPage.Location.Y - lastLocation.Y) + e.Y) < 32)
                    DashboardPage.Location = new Point((DashboardPage.Location.X), (DashboardPage.Location.Y - lastLocation.Y) + e.Y);
        }
        #endregion

        private void FadeTMR_Tick(object sender, EventArgs e) {
            //Gives the form a Fade-In effect

            this.Opacity += 0.2;
            if (this.Opacity == 1) {
                FadeTMR.Stop();
                
                //Call the tooltips after the Timer to avoid them being dismissed
                LoadNotifications();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            shadow.Close();
            lf.Opacity = 0;
            lf.Show();
            lf.Location = newFormLocation;
            this.Hide();
        }

        private void MainForm_LocationChanged(object sender, EventArgs e) {
            newFormLocation = new Point(this.Location.X + 50, this.Location.Y + 66);
            shadow.Location = this.Location;
        }
        #endregion

        #region Form Global Buttons and Events

        bool DashboardToBeMinimized;
        Button currentBTN;
        SplitContainer currentPage;

        Color accent = Color.FromArgb(94, 114, 146);
        Color primary = Color.FromArgb(53, 64, 82);
        Color dahsbard = Color.FromArgb(42, 72, 119);

        private void DashboardBTN_Click(object sender, EventArgs e) {
            DashboardToBeMinimized = false;
            DashboardTMR.Start();
            DashboardBTN.BackColor = accent;
            currentBTN.BackColor = primary;
            currentBTN = DashboardBTN;
            currentPage = SamplePNL;
            SamplePNL.Show();
        }
        private void ChangePage(SplitContainer newP, Button newBTN) {
            //Generic Function to switch the panels that are shown and hidden
            ExtraQueryParams = "";
            DashboardToBeMinimized = true;
            DashboardTMR.Start();
            newP.Show();
            currentBTN.BackColor = primary;
            newBTN.BackColor = accent;

            if (newP != currentPage) currentPage.Hide();
            currentPage = newP;
            currentBTN = newBTN;

            ScurrentPanel.Hide();
            ScurrentBTN.Font = defaultFont;
        }
        private void RecordsBTN_Click(object sender, EventArgs e) {
            ChangePage(GuardsPage, RecordsBTN);
            GUARDSLoadPage();
        }
        private void ClientBTN_Click(object sender, EventArgs e) {
            ChangePage(ClientsPage, ClientBTN);
            CLIENTSLoadPage();
        }
        private void SchedBTN_Click(object sender, EventArgs e) {
            ChangePage(SchedulesPage, SchedBTN);
            SCHEDLoadPage();
        }
        private void PayrollBTN_Click(object sender, EventArgs e) {
            ChangePage(PayrollPage, PayrollBTN);
            PAYLoadPage();
        }
        private void SettingsBTN_Click(object sender, EventArgs e) {
            try {
                shadow.Transparent();
                shadow.Show();
                About view = new About();
                view.reference = this;
                view.conn = this.conn;
                view.UN = user;
                view.refer = shadow;
                view.Location = newFormLocation;
                view.ShowDialog();
            }
            catch (Exception) { }
        }
        private void DashboardTMR_Tick(object sender, EventArgs e) {
            //This event gives the dashboard its slide-up effect when changing panels

            if (DashboardToBeMinimized) {
                Point defaultPoint = new Point(100, -865);
                if (DashboardPage.Location.Y > defaultPoint.Y) DashboardPage.Location = new Point(DashboardPage.Location.X, DashboardPage.Location.Y - 60);
                else { DashboardTMR.Stop(); ControlBoxLBL.Visible = true; ControlBoxTimeLBL.Visible = true; ControlBoxPanel.BackColor = primary; SettingsBTN.Visible = true; }
            } else if (!DashboardToBeMinimized) {
                ControlBoxLBL.Visible = false;
                ControlBoxTimeLBL.Visible = false;
                SettingsBTN.Visible = false;
                Point defaultPoint = new Point(70, 32);
                if (DashboardPage.Location.Y != defaultPoint.Y) {
                    DashboardPage.Location = new Point(DashboardPage.Location.X, DashboardPage.Location.Y + 60);
                } else {
                    DashboardTMR.Stop(); ControlBoxPanel.BackColor = dahsbard;
                    GuardsPage.Hide();
                    SchedulesPage.Hide();
                    PayrollPage.Hide();
                    ClientsPage.Hide();
                }
            }
        }
        #endregion

        #region Dashboard Page Notifs

        Color DashboardDefault = Color.FromArgb(94, 114, 146);
        Color DashboardHover = Color.FromArgb(72, 87, 112);

        private void ArrangeNotif() {
            // This method is used to rearrange the Notifs Widgets when dismissing them

            bool[] pnl = { DMonthlyDutyReportPNL.Visible, DClientSummaryPNL.Visible, DSalaryReportPNL.Visible };
            Point loc1 = new Point(308, 208);
            Point loc2 = new Point(308, 310);
            Point loc3 = new Point(308, 413);
            if (pnl[0]) if (!pnl[1]) DSalaryReportPNL.Location = loc2;
            if (pnl[1]) if (!pnl[0]) { DClientSummaryPNL.Location = loc1; DSalaryReportPNL.Location = loc2; }
            if (pnl[2]) if (!pnl[0] && !pnl[1]) { DSalaryReportPNL.Location = loc1; }
        }

        private void DMonthlyDutyReportPNL_MouseEnter(object sender, EventArgs e) {
            DMonthlyDutyReportPNL.BackColor = DashboardHover;
        }

        private void DMonthlyDutyReportPNL_MouseLeave(object sender, EventArgs e) {
            DMonthlyDutyReportPNL.BackColor = DashboardDefault;
        }

        private void DClientSummaryPNL_MouseEnter(object sender, EventArgs e) {
            DClientSummaryPNL.BackColor = DashboardHover;
        }

        private void DClientSummaryPNL_MouseLeave(object sender, EventArgs e) {
            DClientSummaryPNL.BackColor = DashboardDefault;
        }

        private void DSalaryReportPNL_MouseEnter(object sender, EventArgs e) {
            DSalaryReportPNL.BackColor = DashboardHover;
        }

        private void DSalaryReportPNL_MouseLeave(object sender, EventArgs e) {
            DSalaryReportPNL.BackColor = DashboardDefault;
        }

        private void DMonthlyX_Click(object sender, EventArgs e) {
            DMonthlyDutyReportPNL.Visible = false;
            ArrangeNotif();
        }

        private void DClientX_Click(object sender, EventArgs e) {
            DClientSummaryPNL.Visible = false;
            ArrangeNotif();
        }

        private void DSalaryX_Click(object sender, EventArgs e) {
            DSalaryReportPNL.Visible = false;
            ArrangeNotif();
        }

        private void DMonthlyDutyReportPNL_Click(object sender, EventArgs e) {
            SchedBTN.PerformClick();
            SMonthlyDutyBTN.PerformClick();
        }

        private void DClientSummaryPNL_Click(object sender, EventArgs e) {
            ClientBTN.PerformClick();
            CViewSummaryBTN.PerformClick();
        }

        private void DSalaryReportPNL_Click(object sender, EventArgs e) {
            PayrollBTN.PerformClick();
            PSalaryReportBTN.PerformClick();
        }
        #endregion


        #region Guards Management System

        #region GMS - Page Load and Side Panels

        public void GUARDSLoadPage() {
            //This method is used to intiate the forms

            ScurrentPanel = GViewAllPNL;
            ScurrentBTN = GViewAllPageBTN;
            GViewAllViewByCMBX.SelectedIndex = 0;
            GViewAllPageBTN.PerformClick();
        }
        private void RAddEmpBTN_Click(object sender, EventArgs e) {
            try {
                Guards_Edit view = new Guards_Edit();
                view.reference = this;
                view.conn = this.conn;
                view.refer = this.shadow;
                view.Location = newFormLocation;
                shadow.Transparent();
                shadow.form = view;
                shadow.ShowDialog();
            }
            catch (Exception) { }
        }
        private void GChangePanel(Panel newP, Button newBTN) {
            ExtraQueryParams = "";


            ScurrentPanel.Hide();
            newP.Show();

            ScurrentBTN.Font = defaultFont;
            newBTN.Font = selectedFont;

            ScurrentPanel = newP;
            ScurrentBTN = newBTN;
        }
        private void GArchivePageBTN_Click(object sender, EventArgs e) {
            GChangePanel(GArchivePNL, GArchivePageBTN);
            RefreshArchivedGuards();
        }
        private void GViewAllPageBTN_Click(object sender, EventArgs e) {
            GChangePanel(GViewAllPNL, GViewAllPageBTN);
            GViewAllViewByCMBX.SelectedIndex = 0;
        }
        private void GSummaryPageBTN_Click(object sender, EventArgs e) {
            GChangePanel(GSummaryPNL, GSummaryPageBTN);
        }
        #endregion

        #region GMS - View All

        #region GMS - View All - Data Grid

        private void GViewAllViewByCMBX_SelectedIndexChanged(object sender, EventArgs e) {
            GUARDSRefreshGuardsList();
        }

        public void GUARDSRefreshGuardsList() {
            GAllGuardsGRD.DataSource = GetGuardList(GViewAllViewByCMBX.SelectedIndex);
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

            GActiveLBL.Text = SQLTools.GetNumberOfGuards("active") + " active guards";
            GInactiveLBL.Text = SQLTools.GetNumberOfGuards("inactive") + " inactive guards";
        }

        private void GEditDetailsBTN_Click(object sender, EventArgs e) {
            try {
                List<int> GuardsGID = new List<int>();
                foreach (DataGridViewRow row in GAllGuardsGRD.SelectedRows) {
                    GuardsGID.Add(int.Parse(row.Cells[0].Value.ToString()));
                }
                if (GuardsGID.Count > 1) {
                    rylui.RylMessageBox.ShowDialog("More than 1 guard is selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } else if (GuardsGID.Count == 0) {
                    rylui.RylMessageBox.ShowDialog("No guard is selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } else {
                    Guards_View view = new Guards_View();
                    view.GID = GuardsGID[0];
                    view.reference = this;
                    view.conn = this.conn;
                    view.refer = this.shadow;
                    view.Location = newFormLocation;
                    shadow.Transparent();
                    shadow.form = view;
                    shadow.Show();
                }
            }
            catch (Exception) { }
        }

        private void GAllGuardsGRD_CellEnter(object sender, DataGridViewCellEventArgs e) {
            if (GAllGuardsGRD.SelectedRows.Count == 1) {
                if (GAllGuardsGRD.SelectedRows[0].Cells[2].Value.ToString().Equals("Active")) {
                    GEditDetailsBTN.Location = new Point(294, 600);
                    GArchiveBTN.Location = new Point(214, 601);
                    GEditDetailsBTN.Visible = true;
                    GArchiveBTN.Visible = false;
                } else {
                    GEditDetailsBTN.Location = new Point(214, 601);
                    GArchiveBTN.Location = new Point(346, 600);
                    GEditDetailsBTN.Visible = true;
                    GArchiveBTN.Visible = true;
                }
            } else if (GAllGuardsGRD.SelectedRows.Count > 1) {
                bool ret = true;
                foreach (DataGridViewRow row in GAllGuardsGRD.SelectedRows) {
                    if (row.Cells[2].Value.ToString().Equals("Active")) ret = false;
                }
                if (ret) {
                    GArchiveBTN.Location = new Point(294, 600);
                    GEditDetailsBTN.Visible = false;
                    GArchiveBTN.Visible = true;
                } else {
                    GEditDetailsBTN.Visible = false;
                    GArchiveBTN.Visible = false;
                }
            }
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
            //if (x == DialogResult.Yes) MoveGuardsToArchive(GuardsGID);
        }
        private void RefreshArchivedGuards() {
          
        }
        #endregion

        #region GMS - Archive Search
        private void GArchiveSearchBX_Enter(object sender, EventArgs e) {
            if (GArchiveSearchBX.Text.Equals("Search or filter")) {
                GArchiveSearchBX.Text = "";
            }
            GArchiveSearchLine.Visible = true;
        }

        private void GArchiveSearchBX_Leave(object sender, EventArgs e) {
            if (GArchiveSearchBX.Text.Equals("")) {
                GArchiveSearchBX.Text = "Search or filter";
                ExtraQueryParams = "";
            }
            ExtraQueryParams = "";
            RefreshArchivedGuards();
            GArchiveSearchLine.Visible = false;
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
        
        #region CMS - Page Load and Side Panel
        public void CLIENTSLoadPage() {
            ScurrentBTN = CViewAllClientBTN;
            ScurrentPanel = CViewAllPNL;
            CViewAllClientBTN.PerformClick();
        }

        private void CAddClientBTN_Click(object sender, EventArgs e) {
            try {
                Clients_Edit view = new Clients_Edit();
                view.reference = this;
                view.conn = this.conn;
                view.refer = this.shadow;
                view.Location = newFormLocation;
                shadow.Transparent();
                shadow.form = view;
                shadow.Show();
            }
            catch (Exception) { }
        }

        private void CChangePanel(Panel newP, Button newBTN) {
            ScurrentPanel.Hide();
            newP.Show();
            ScurrentBTN.Font = defaultFont;
            newBTN.Font = selectedFont;
            ScurrentBTN = newBTN;
            ScurrentPanel = newP;
        }

        private void CViewAllClientBTN_Click(object sender, EventArgs e) {
            CChangePanel(CViewAllPNL, CViewAllClientBTN);
            CLIENTSRefreshClientsList();
        }

        private void CViewSummaryBTN_Click(object sender, EventArgs e) {
            CChangePanel(CSummaryPNL, CViewSummaryBTN);
        }
        #endregion

        #region View All

        #region CMS - View All Data Grid

        public void CLIENTSRefreshClientsList() {
            CClientListTBL.DataSource = GetClientList();
            CClientListTBL.Columns["cid"].HeaderText = "ID";
            CClientListTBL.Columns["cid"].Visible = false;
            CClientListTBL.Columns["name"].HeaderText = "NAME";
            CClientListTBL.Columns["name"].Width = 310;
            CClientListTBL.Columns["contactno"].HeaderText = "LOCATION";
            CClientListTBL.Columns["contactno"].Width = 310;
            CClientListTBL.Sort(CClientListTBL.Columns[1], ListSortDirection.Ascending);

            CActiveClientLBL.Text = GetNumberOfActiveClients() + " active clients";
            CTotalClientLBL.Text = GetTotalClients() + " total clients";
        }
        
        private void CViewDetailsBTN_Click(object sender, EventArgs e) {
            try {
                Clients_View view = new Clients_View();
                if (CClientListTBL.SelectedRows.Count == 0) {
                    rylui.RylMessageBox.ShowDialog("No client is selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } else {
                    view.CID = int.Parse(CClientListTBL.SelectedRows[0].Cells[0].Value.ToString());
                    view.reference = this;
                    view.conn = this.conn;
                    view.refer = this.shadow;
                    view.Location = newFormLocation;
                    shadow.Transparent();
                    shadow.form = view;
                    shadow.Show();
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
            CViewAllSearchLine.Visible = true;
        }

        private void CViewAllSearchBX_Leave(object sender, EventArgs e) {
            if (CViewAllSearchBX.Text.Equals("")) {
                CViewAllSearchBX.Text = "Search or filter";
            }
            ExtraQueryParams = "";
            CViewAllSearchLine.Visible = false;
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

        #region SMS - Page Load and Side Panel
        public void SCHEDLoadPage() {
            SCHEDLoadSidePNL();

            ScurrentBTN = SViewReqBTN;
            ScurrentPanel = SViewReqPNL;

            SViewReqBTN.PerformClick();
        }

        public void SCHEDLoadSidePNL() {
            if (!Scheduling.GetNumberOfClientRequests(Enumeration.RequestStatus.Pending).Equals("0"))
                SchedBTN.Text = Scheduling.GetNumberOfClientRequests(Enumeration.RequestStatus.Pending).ToString();
            else SchedBTN.Text = String.Empty;
            SClientRequestsLBL.Text = Scheduling.GetNumberOfClientRequests(Enumeration.RequestStatus.Pending) + " pending requests";
            SUnassignedGuardsLBL.Text = Scheduling.GetNumberOfUnassignedGuards() + " unsassigned guards";
            SAssignedGuardsLBL.Text = Scheduling.GetNumberOfAssignedGuards() + " assigned guards";
        }

        private void SChangePanel(Panel newP, Button newBTN, bool Req) {
            ScurrentPanel.Hide();
            newP.Show();
            ScurrentBTN.Font = defaultFont;
            newBTN.Font = selectedFont;
            ScurrentBTN = newBTN;
            ScurrentPanel = newP;
            SViewReqAssBTN.Visible = Req;
        }

        private void SViewReqBTN_Click(object sender, EventArgs e) {
            SChangePanel(SViewReqPNL, SViewReqBTN, true);
            SCHEDLoadRequestsPage();
        }

        private void SViewAssBTN_Click(object sender, EventArgs e) {
            SChangePanel(SViewAssPNL, SViewAssBTN, false);
            SCHEDLoadAssignmentPage();
        }

        private void SMonthlyDutyBTN_Click(object sender, EventArgs e) {
            SChangePanel(SMonthlyDutyPNL, SMonthlyDutyBTN, false);
        }

        private void SDutyDetailsBTN_Click(object sender, EventArgs e) {
            SChangePanel(SDutyDetailsPNL, SDutyDetailsBTN, false);
        }

        private void SIncidentBTN_Click(object sender, EventArgs e) {
            SChangePanel(SIncidentPNL, SIncidentBTN, false);
        }

        private void SArchiveBTN_Click(object sender, EventArgs e) {
            SChangePanel(SArchivePNL, SArchiveBTN, false);
        }

        private void SViewReqAssBTN_Click(object sender, EventArgs e) {
            try {
                Sched_RequestGuard view = new Sched_RequestGuard();
                view.reference = this;
                view.conn = this.conn;
                view.refer = this.shadow;
                view.Location = newFormLocation;
                shadow.Transparent();
                shadow.form = view;
                shadow.Show();
            }
            catch (Exception) { }
        }
        private void SViewReqDisBTN_Click(object sender, EventArgs e) {
            if (isUnscheduled()) {
                try {
                    Sched_UnassignGuard view = new Sched_UnassignGuard();
                    view.reference = this;
                    view.CID = int.Parse(((ComboBoxItem)SViewAssSearchClientCMBX.SelectedItem).ItemID);
                    view.conn = this.conn;
                    view.refer = this.shadow;
                    view.guards = SViewAssGRD.SelectedRows;
                    view.Location = newFormLocation;
                    shadow.Transparent();
                    shadow.form = view;
                    shadow.Show();
                }
                catch (Exception) { }
            } else {
                rylui.RylMessageBox.ShowDialog("You can't unassign a guard with an active assignment \nPlease dismiss the guards before unassigning them", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region SMS - View Requests
        int RID;
        bool ChangeDate;

        private void SViewReqGRD_CellEnter(object sender, DataGridViewCellEventArgs e) {
            RID = int.Parse(SViewReqGRD.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        private void SViewReqFilterCMBX_SelectedIndexChanged(object sender, EventArgs e) {
            LoadViewReqTable(Scheduling.GetRequests(SViewReqSearchTXTBX.Text, -1, SViewReqFilterCMBX.SelectedIndex, "name", "name asc"));
        }

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
            SViewReqGRD.Columns["status"].HeaderText = "STATUS";

            SViewReqGRD.Columns["name"].Width = 250;
            SViewReqGRD.Columns["dateentry"].Width = 200;
            SViewReqGRD.Columns["type"].Width = 100;
            SViewReqGRD.Columns["status"].Width = 100;

            SViewReqGRD.Sort(SViewReqGRD.Columns["dateentry"], ListSortDirection.Descending);
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
            try {
                if (SViewReqGRD.SelectedRows[0].Cells[3].Value.ToString().Equals("Assignment")) {
                    try {
                        Sched_ViewAssReq view = new Sched_ViewAssReq();
                        view.reference = this;
                        view.RAID = this.RID;
                        view.conn = this.conn;
                        view.refer = this.shadow;
                        view.Location = newFormLocation;

                        shadow.Transparent();
                        shadow.form = view;
                        shadow.Show();
                    }
                    catch (Exception) { }
                } else {
                    try {
                        Sched_ViewDisReq view = new Sched_ViewDisReq();
                        view.reference = this;
                        view.conn = this.conn;
                        view.RID = this.RID;
                        view.refer = this.shadow;
                        view.Location = newFormLocation;

                        shadow.Transparent();
                        shadow.form = view;
                        shadow.Show();
                    }
                    catch (Exception) { }
                }
            }
            catch { }
        }

        #endregion

        #region SMS - View Assignment
        private void SCHEDLoadAssignmentPage() {
            SViewAssSearchClientCMBX.Items.Clear();
            SViewAssSearchClientCMBX.Items.Add(new ComboBoxItem("All", "-1"));
            SViewAssSearchClientCMBX.SelectedIndex = 0;
            SViewAssCMBX.SelectedIndex = 0;

            SViewAssViewDetailsBTN.Location = new Point(282, 600);
            SViewAssUnassignBTN.Visible = false;

            DataView dv = Client.GetClients().DefaultView;
            dv.Sort = "name asc";
            DataTable dt = dv.ToTable();

            for (int i = 0; i < dt.Rows.Count; i++) SViewAssSearchClientCMBX.Items.Add(new ComboBoxItem(dt.Rows[i][1].ToString(), dt.Rows[i][0].ToString()));
        }

        private void SViewAssSearchClientCMBX_SelectedValueChanged(object sender, EventArgs e) {
            SViewAssCMBX.SelectedIndex = 0;
            if (int.Parse(((ComboBoxItem)SViewAssSearchClientCMBX.SelectedItem).ItemID) != -1) {
                SViewAssViewDetailsBTN.Location = new Point(228, 600);
                SViewAssUnassignBTN.Location = new Point(365, 600);
                SViewAssUnassignBTN.Visible = true;
            } else {
                SViewAssViewDetailsBTN.Location = new Point(182, 600);
                SViewAssUnassignBTN.Visible = false;
            }
            SCHEDRefreshAssignments();
        }

        public void SCHEDRefreshAssignments() {
            SViewAssGRD.DataSource = Scheduling.GetAssignmentsByClient(int.Parse(((ComboBoxItem)SViewAssSearchClientCMBX.SelectedItem).ItemID), SViewAssCMBX.SelectedIndex);

            if ( SViewAssGRD.Rows.Count > 0) { 
            SViewAssGRD.Columns[0].Visible = false;
            SViewAssGRD.Columns[1].Visible = false;
            SViewAssGRD.Columns[2].Visible = false;
            SViewAssGRD.Columns[3].HeaderText = "NAME";
            SViewAssGRD.Columns[4].HeaderText = "ASSIGNMENT LOCATION";
            SViewAssGRD.Columns[5].HeaderText = "SCHEDULE";
            SViewAssGRD.Columns[6].HeaderText = "STATUS";

            SViewAssGRD.Columns[3].Width = 200;
            SViewAssGRD.Columns[4].Width = 250;
            SViewAssGRD.Columns[5].Width = 100;
            SViewAssGRD.Columns[5].Width = 100;

            SViewAssGRD.Sort(SViewAssGRD.Columns[3], ListSortDirection.Ascending);
            }
        }

        private void SViewAssCMBX_SelectedIndexChanged(object sender, EventArgs e) {
            SCHEDRefreshAssignments();
        }

        private void SViewAssGRD_CellEnter(object sender, DataGridViewCellEventArgs e) {
            if (SViewAssGRD.Rows[e.RowIndex].Cells[6].Value.ToString().Equals("Inactive")) { SViewAssViewDetailsBTN.Visible = false; SViewAssUnassignBTN.Visible = false;  } 
            else {SViewAssViewDetailsBTN.Visible = true; if (SViewAssSearchClientCMBX.SelectedIndex != 0)SViewAssUnassignBTN.Visible = true; }
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

        private void SViewAssViewDetailsBTN_Click(object sender, EventArgs e) {
            if (SViewAssGRD.SelectedRows.Count > 1) {
                rylui.RylMessageBox.ShowDialog("More than one assignment is selected", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else {
                try {
                    Sched_ViewDutyDetails view = new Sched_ViewDutyDetails();
                    view.reference = this;
                    view.conn = this.conn;
                    view.refer = this.shadow;
                    view.AID = int.Parse(SViewAssGRD.SelectedRows[0].Cells[2].Value.ToString());
                    view.Location = newFormLocation;

                    shadow.Transparent();
                    shadow.form = view;
                    shadow.Show();
                }
                catch (Exception) { }
            }
        }

        private bool isUnscheduled() {
            //Method to check if the selected Guards are ready to be dismissed

            bool ret = true;
            foreach (DataGridViewRow row in SViewAssGRD.SelectedRows)
                if (!row.Cells[5].Value.ToString().Equals("Unscheduled")) ret = false;
            return ret;
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
                view.refer = this.shadow;
                view.Location = newFormLocation;

                shadow.Transparent();
                shadow.form = view;
                shadow.Show();
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
            ScurrentPanel = PPayrollSummaryPage;
            ScurrentBTN = PPayrollSummaryBTN;
            PPayrollSummaryBTN.PerformClick();
        }

        private void PCHnagePanel(Panel newP, Button newBTN, bool BasicPay) {
            ScurrentPanel.Hide();
            newP.Show();
            ScurrentBTN.Font = defaultFont;
            newBTN.Font = selectedFont;
            ScurrentBTN = newBTN;
            ScurrentPanel = newP;
            PBasicPayBTN.Visible = BasicPay;
        }

        private void PEmpListBTN_Click(object sender, EventArgs e) {
            PCHnagePanel(PEmpListPage, PEmpListBTN, true);
            PAYLoadEmployeeList();
        }
        private void PAdjustBTN_Click(object sender, EventArgs e) {
            PCHnagePanel(PBasicPayHistoryPage, PBasicPayBTN, true);
        }

        private void PCashAdvBTN_Click(object sender, EventArgs e) {
            PCHnagePanel(PCashAdvancePage, PCashAdvBTN, false);
        }

        private void PPayrollSummaryBTN_Click(object sender, EventArgs e) {
            PCHnagePanel(PPayrollSummaryPage, PPayrollSummaryBTN, false);
        }

        private void PSalaryReportBTN_Click(object sender, EventArgs e) {
            PCHnagePanel(PSalaryReportPage, PSalaryReportBTN, false);
        }

        private void PArchiveBTN_Click(object sender, EventArgs e) {
            PCHnagePanel(PArchivePage, PArchiveBTN, false);
        }

        #endregion

        #region PMS - Employee List 
        private void PAYLoadEmployeeList() {
            PEmpListSortCMBX.SelectedIndex = 0;
        }

        private void PConfHoliday_Click(object sender, EventArgs e) {
            try {
                Payroll_ConfHolidays view = new Payroll_ConfHolidays();
                view.conn = this.conn;
                view.refer = this.shadow;
                view.Location = newFormLocation;

                shadow.Transparent();
                shadow.form = view;
                shadow.Show();
            }
            catch (Exception) { }
        }
        private void PEmpListViewBTN_Click(object sender, EventArgs e) {
            try {
                Payroll_EmployeeView view = new Payroll_EmployeeView();
                view.reference = this;
                view.conn = this.conn;
                view.refer = this.shadow;
                //view.PID = int.Parse(SViewAssGRD.SelectedRows[0].Cells[2].Value.ToString());
                view.Location = newFormLocation;

                shadow.Transparent();
                shadow.form = view;
                shadow.Show();
            }
            catch (Exception) { }
        }
        private void PEmpListSearchBX_Enter(object sender, EventArgs e) {
            if (PEmpListSearchBX.Text == FilterText) {
                PEmpListSearchBX.Text = EmptyText;
                ExtraQueryParams = EmptyText;
            }
            PEmpListSearchLine.Visible = true;
        }

        private void PEmpListSearchBX_Leave(object sender, EventArgs e) {
            if (PEmpListSearchBX.Text == EmptyText) {
                PEmpListSearchBX.Text = FilterText;
                ExtraQueryParams = EmptyText;
            }
            PEmpListSearchLine.Visible = false;
        }
        #endregion

        #region PMS - Basic Pay 
        private void PBasicPayAddBTN_Click(object sender, EventArgs e) {
            try {
                Payroll_BasicPay view = new Payroll_BasicPay();
                view.reference = this;
                view.conn = this.conn;
                view.refer = this.shadow;
                //view.BPID = int.Parse(SViewAssGRD.SelectedRows[0].Cells[2].Value.ToString());
                view.Location = newFormLocation;

                shadow.Transparent();
                shadow.form = view;
                shadow.Show();
            }
            catch (Exception) { }
        }
        private void PBasicPayEditBTN_Click(object sender, EventArgs e) {
            try {
                Payroll_BasicPay view = new Payroll_BasicPay();
                view.reference = this;
                view.conn = this.conn;
                view.refer = this.shadow;
                //view.BPID = int.Parse(SViewAssGRD.SelectedRows[0].Cells[2].Value.ToString());
                view.Location = newFormLocation;

                shadow.Transparent();
                shadow.form = view;
                shadow.Show();
            }
            catch (Exception) { }
        }

        #endregion

        #region Cash Advance Request
        private void SCashAdvViewBTN_Click(object sender, EventArgs e) {
            try {
                Payroll_ViewCashAdv view = new Payroll_ViewCashAdv();
                view.reference = this;
                view.conn = this.conn;
                view.refer = this.shadow;
                //view.PID = int.Parse(SViewAssGRD.SelectedRows[0].Cells[2].Value.ToString());
                view.Location = newFormLocation;

                shadow.Transparent();
                shadow.form = view;
                shadow.Show();
            }
            catch (Exception) { }
        }


        #endregion

        #endregion



        //======================================//
        //          BES MGA SQL METHODS         //
        //======================================// 

        private DataTable GetGuardList(int Mode) {
            String query;
            String orderbyclause;
            DataTable dt;
            if (Mode == 0) {
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
            dt = new DataTable();
            adp.Fill(dt);
            conn.Close();
            return dt;
        }

        private int GetNumberOfActiveClients() {
            conn.Open();
            MySqlCommand comm = new MySqlCommand("SELECT * FROM client WHERE cstatus = 1", conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            conn.Close();
            return dt.Rows.Count;
        }
        private int GetTotalClients() {
            conn.Open();
            MySqlCommand comm = new MySqlCommand("SELECT * FROM client", conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            conn.Close();
            return dt.Rows.Count;
        }
        private DataTable GetClientList() {
            String q = "SELECT cid, name, CONCAT(Clientstreetno,' ',Clientstreet,', ', Clientbrgy,', ',Clientcity) AS contactno FROM client" + ExtraQueryParams;
            return SQLTools.ExecuteQuery(q);
        }

    }
}