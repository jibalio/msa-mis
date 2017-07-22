using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace MSAMISUserInterface {
    public partial class MainForm : Form {

        //Only Paste Global Variable Here//

        public MySqlConnection Conn;
        public LoginForm Lf;
        public string User;

        private Point _newFormLocation;
        private readonly Shadow _shadow = new Shadow();
        private readonly Font _selectedFont = new Font("Segoe UI Semibold", 10);
        private readonly Font _defaultFont = new Font("Segoe UI Semilight", 10);
        private Panel _scurrentPanel;
        private Button _scurrentBtn;
        private const string FilterText = "Search or filter";
        private const string EmptyText = "";
        private string _extraQueryParams = "";

        #region Form Initiation and load
        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            //Get the relative position after loading
            _newFormLocation = new Point(Location.X + 50, Location.Y + 66);
            _shadow.Location = Location;

            //Initiate the methods that updates the app
            InitiateForm();
        }

        private void InitiateForm() {
            //This method is used to initiate the look and feel of the Main Form
            //Can also be used to initiate global variables

            //Main Form Arrangement
            DashboardPage.BringToFront();
            ControlBoxPanel.BringToFront();
            SamplePNL.SendToBack();

            //Buttons Color
            _currentBtn = DashboardBTN;
            _splitContainer = SamplePNL;
            ControlBoxPanel.BackColor = _dashboard;

            //Variable Initialization
            Conn = SQLTools.conn;
            ControlBoxTimeLBL.Text = "Logged in as, " + User;
            TimeLBL.Text = DateTime.Now.ToString("dddd, MMMM dd yyyy").ToUpper();
            _scurrentPanel = GViewAllPNL;
            _scurrentBtn = GViewAllPageBTN;

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
            Close();
        }

        private void LoadNotifications() {
            //To Initiate the the Tooltip notifications

            //Scheduling Tooltip Page Notification

            if (!Scheduling.GetNumberOfClientRequests(Enumeration.RequestStatus.Pending).Equals("0")) {
                ClientRequestsTLTP.Show("You have " + Scheduling.GetNumberOfClientRequests(Enumeration.RequestStatus.Pending) + " pending requests.", SchedBTN, 2000);
                ClientRequestsTLTP.Show("You have " + Scheduling.GetNumberOfClientRequests(Enumeration.RequestStatus.Pending) + " pending requests.", SchedBTN, 2000);
                SchedBTN.Text = Scheduling.GetNumberOfClientRequests(Enumeration.RequestStatus.Pending);
            } else SchedBTN.Text = String.Empty;
        }
        #endregion

        #region Form Features

        #region Enable Dragging of Form
        private bool _mouseDown;
        private Point _lastLocation;

        private void Form_MouseUp(object sender, MouseEventArgs e) {
            _mouseDown = false;
        }
        private void Form_MouseDown(object sender, MouseEventArgs e) {
            _mouseDown = true;
            _lastLocation = e.Location;
        }
        private void Form_MouseMove(object sender, MouseEventArgs e) {
            if (_mouseDown) {
                Location = new Point((Location.X - _lastLocation.X) + e.X, (Location.Y - _lastLocation.Y) + e.Y);
                Update();
            }
        }
        #endregion

        #region Slide-Up Dashboard
        private void Dashboard_MouseUp(object sender, MouseEventArgs e) {
            _mouseDown = false;
            if (DashboardPage.Location.Y <= -300) {
                if (DashboardPage.Location.Y <= -568) DashboardPage.Location = new Point(DashboardPage.Location.X, -628);
                else if (DashboardPage.Location.Y <= -448) DashboardPage.Location = new Point(DashboardPage.Location.X, -508);
                else if (DashboardPage.Location.Y <= -300) DashboardPage.Location = new Point(DashboardPage.Location.X, -328);
                RecordsBTN.PerformClick();
            } else {
                if (DashboardPage.Location.Y > -148) DashboardPage.Location = new Point(DashboardPage.Location.X, -28);
                else if (DashboardPage.Location.Y > -208) DashboardPage.Location = new Point(DashboardPage.Location.X, -148);
                else DashboardPage.Location = new Point(DashboardPage.Location.X, -268);
                _dashboardToBeMinimized = false;
                DashboardTMR.Start();
            }
        }
        private void Dashboard_MouseMove(object sender, MouseEventArgs e) {
            if (_mouseDown)
                if (((DashboardPage.Location.Y - _lastLocation.Y) + e.Y) < 32)
                    DashboardPage.Location = new Point((DashboardPage.Location.X), (DashboardPage.Location.Y - _lastLocation.Y) + e.Y);
        }
        #endregion

        private void FadeTMR_Tick(object sender, EventArgs e) {
            //Gives the form a Fade-In effect

            Opacity += 0.2;
            if (Opacity.Equals(1)) {
                FadeTMR.Stop();

                //Call the tooltips after the Timer to avoid them being dismissed
                LoadNotifications();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            _shadow.Close();
            Lf.Opacity = 0;
            Lf.Show();
            Lf.Location = _newFormLocation;
            Hide();
        }

        private void MainForm_LocationChanged(object sender, EventArgs e) {
            _newFormLocation = new Point(Location.X + 50, Location.Y + 66);
            _shadow.Location = Location;
        }
        #endregion

        #region Form Global Buttons and Events

        private bool _dashboardToBeMinimized;
        private Button _currentBtn;
        private SplitContainer _splitContainer;

        private readonly Color _accent = Color.FromArgb(94, 114, 146);
        private readonly Color _primary = Color.FromArgb(53, 64, 82);
        private readonly Color _dashboard = Color.FromArgb(42, 72, 119);

        private void DashboardBTN_Click(object sender, EventArgs e) {
            _dashboardToBeMinimized = false;
            DashboardTMR.Start();
            DashboardBTN.BackColor = _accent;
            _currentBtn.BackColor = _primary;
            _currentBtn = DashboardBTN;
            _splitContainer = SamplePNL;
            SamplePNL.Show();
        }
        private void ChangePage(SplitContainer newP, Button button) {
            //Generic Function to switch the panels that are shown and hidden
            _extraQueryParams = "";
            _dashboardToBeMinimized = true;
            DashboardTMR.Start();
            newP.Show();
            _currentBtn.BackColor = _primary;
            button.BackColor = _accent;

            if (newP != _splitContainer) _splitContainer.Hide();
            _splitContainer = newP;
            _currentBtn = button;

            _scurrentPanel.Hide();
            _scurrentBtn.Font = _defaultFont;
        }
        private void RecordsBTN_Click(object sender, EventArgs e) {
            ChangePage(GuardsPage, RecordsBTN);
            GuardsLoadPage();
        }
        private void ClientBTN_Click(object sender, EventArgs e) {
            ChangePage(ClientsPage, ClientBTN);
            ClientsLoadPage();
        }
        private void SchedBTN_Click(object sender, EventArgs e) {
            ChangePage(SchedulesPage, SchedBTN);
            SchedLoadPage();
        }
        private void PayrollBTN_Click(object sender, EventArgs e) {
            ChangePage(PayrollPage, PayrollBTN);
            PayLoadPage();
        }
        private void SettingsBTN_Click(object sender, EventArgs e) {
            try {
                var view = new About {
                    Reference = this,
                    Username = User,
                    Refer = _shadow,
                    Location = _newFormLocation
                };
                _shadow.Transparent();
                _shadow.Form = view;
                _shadow.ShowDialog();
            }
            catch (Exception) { }
        }
        private void DashboardTMR_Tick(object sender, EventArgs e) {
            //This event gives the dashboard its slide-up effect when changing panels

            if (_dashboardToBeMinimized) {
                var defaultPoint = new Point(100, -865);
                if (DashboardPage.Location.Y > defaultPoint.Y) DashboardPage.Location = new Point(DashboardPage.Location.X, DashboardPage.Location.Y - 60);
                else { DashboardTMR.Stop(); ControlBoxLBL.Visible = true; ControlBoxTimeLBL.Visible = true; ControlBoxPanel.BackColor = _primary; SettingsBTN.Visible = true; }
            } else if (!_dashboardToBeMinimized) {
                ControlBoxLBL.Visible = false;
                ControlBoxTimeLBL.Visible = false;
                SettingsBTN.Visible = false;
                var defaultPoint = new Point(70, 32);
                if (DashboardPage.Location.Y != defaultPoint.Y) {
                    DashboardPage.Location = new Point(DashboardPage.Location.X, DashboardPage.Location.Y + 60);
                } else {
                    DashboardTMR.Stop(); ControlBoxPanel.BackColor = _dashboard;
                    GuardsPage.Hide();
                    SchedulesPage.Hide();
                    PayrollPage.Hide();
                    ClientsPage.Hide();
                }
            }
        }
        #endregion

        #region Dashboard Page Notifs

        private readonly Color _dashboardHover = Color.FromArgb(72, 87, 112);

        private void ArrangeNotif() {
            // This method is used to rearrange the Notifs Widgets when dismissing them

            bool[] pnl = { DMonthlyDutyReportPNL.Visible, DClientSummaryPNL.Visible, DSalaryReportPNL.Visible };
            Point loc1 = new Point(308, 208);
            Point loc2 = new Point(308, 310);
            if (pnl[0]) if (!pnl[1]) DSalaryReportPNL.Location = loc2;
            if (pnl[1]) if (!pnl[0]) { DClientSummaryPNL.Location = loc1; DSalaryReportPNL.Location = loc2; }
            if (pnl[2]) if (!pnl[0] && !pnl[1]) { DSalaryReportPNL.Location = loc1; }
        }

        private void DMonthlyDutyReportPNL_MouseEnter(object sender, EventArgs e) {
            DMonthlyDutyReportPNL.BackColor = _dashboardHover;
        }

        private void DMonthlyDutyReportPNL_MouseLeave(object sender, EventArgs e) {
            DMonthlyDutyReportPNL.BackColor = _accent;
        }

        private void DClientSummaryPNL_MouseEnter(object sender, EventArgs e) {
            DClientSummaryPNL.BackColor = _dashboardHover;
        }

        private void DClientSummaryPNL_MouseLeave(object sender, EventArgs e) {
            DClientSummaryPNL.BackColor = _accent;
        }

        private void DSalaryReportPNL_MouseEnter(object sender, EventArgs e) {
            DSalaryReportPNL.BackColor = _dashboardHover;
        }

        private void DSalaryReportPNL_MouseLeave(object sender, EventArgs e) {
            DSalaryReportPNL.BackColor = _accent;
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

        public void GuardsLoadPage() {
            //This method is used to intiate the forms

            _scurrentPanel = GViewAllPNL;
            _scurrentBtn = GViewAllPageBTN;
            GViewAllViewByCMBX.SelectedIndex = 0;
            GViewAllPageBTN.PerformClick();
        }
        private void RAddEmpBTN_Click(object sender, EventArgs e) {
            try {
                var view = new GuardsEdit {
                    Reference = this,
                    Connection = Conn,
                    Refer = _shadow,
                    Location = _newFormLocation
                };
                _shadow.Transparent();
                _shadow.Form = view;
                _shadow.ShowDialog();
            }
            catch (Exception) { }
        }
        private void GChangePanel(Panel newP, Button newBtn) {
            _extraQueryParams = "";


            _scurrentPanel.Hide();
            newP.Show();

            _scurrentBtn.Font = _defaultFont;
            newBtn.Font = _selectedFont;

            _scurrentPanel = newP;
            _scurrentBtn = newBtn;
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
            GuardsRefreshGuardsList();
        }

        private void GAllGuardsGRD_DoubleClick(object sender, EventArgs e) {
            if (GEditDetailsBTN.Visible) GEditDetailsBTN.PerformClick();
        }

        public void GuardsRefreshGuardsList() {
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
            GAllGuardsGRD.ClearSelection();

            GActiveLBL.Text = SQLTools.GetNumberOfGuards("active") + " active guards";
            GInactiveLBL.Text = SQLTools.GetNumberOfGuards("inactive") + " inactive guards";


        }

        private void GEditDetailsBTN_Click(object sender, EventArgs e) {
            try {
                if (GAllGuardsGRD.SelectedRows.Count > 1) {
                    rylui.RylMessageBox.ShowDialog("More than 1 guard is selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } else if (GAllGuardsGRD.SelectedRows.Count == 0) {
                    rylui.RylMessageBox.ShowDialog("No guard is selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } else {
                    var view = new GuardsView {
                        Gid = int.Parse(GAllGuardsGRD.SelectedRows[0].Cells[0].Value.ToString()),
                        Reference = this,
                        Connection =  Conn,
                        Shadow = _shadow,
                        Location = _newFormLocation
                    };
                    _shadow.Transparent();
                    _shadow.Form = view;
                    _shadow.ShowDialog();
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
                var ret = true;
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
                _extraQueryParams = EmptyText;
            }
            GViewAllSearchLine.Visible = true;
        }

        private void GViewAllSearchTXTBX_Leave(object sender, EventArgs e) {
            if (GViewAllSearchTXTBX.Text == EmptyText) {
                GViewAllSearchTXTBX.Text = FilterText;
                _extraQueryParams = EmptyText;
            }
            GuardsRefreshGuardsList();
            GViewAllSearchLine.Visible = false;
        }

        private void GViewAllSearchTXTBX_TextChanged(object sender, EventArgs e) {
            var temp = GViewAllSearchTXTBX.Text;
            string Kazoo;
            if (GViewAllViewByCMBX.SelectedIndex == 0) {
                Kazoo = "concat(ln,', ',fn,' ',mn)";
            } else {
                Kazoo = "concat(StreetNo,', ', Brgy,', ',Street, ', ', City)";
            }

            if (GViewAllSearchTXTBX.Text.Contains("\\")) {
                temp = temp + "?";
            }
            _extraQueryParams = " where (" + Kazoo + " like '" + temp + "%' OR " + Kazoo + " like '%" + temp + "%' OR " + Kazoo + " LIKe '%" + temp + "')";
            GuardsRefreshGuardsList();
        }
        #endregion

        #endregion

        #region GMS - Archive 
        private void ArchiveButton_Event(object sender, EventArgs e) {
            // Initialize archive connection.
            var x = rylui.RylMessageBox.ShowDialog("Are you sure you want to archive the selected record(s)?", "Archive", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
                _extraQueryParams = "";
            }
            _extraQueryParams = "";
            RefreshArchivedGuards();
            GArchiveSearchLine.Visible = false;
        }
        private void GArchiveSearchBX_TextChanged(object sender, EventArgs e) {
            var temp = GArchiveSearchBX.Text;
            string Kazoo;

            Kazoo = "name";

            if (GViewAllSearchTXTBX.Text.Contains("\\")) {
                temp = temp + "?";
            }
            _extraQueryParams = " where (" + Kazoo + " like '" + temp + "%' OR " + Kazoo + " like '%" + temp + "%' OR " + Kazoo + " LIKe '%" + temp + "')";
            RefreshArchivedGuards();
        }

        #endregion

        #endregion

        #region Clients Management Page

        #region CMS - Page Load and Side Panel
        public void ClientsLoadPage() {
            _scurrentBtn = CViewAllClientBTN;
            _scurrentPanel = CViewAllPNL;
            CViewAllClientBTN.PerformClick();
        }

        private void CAddClientBTN_Click(object sender, EventArgs e) {
            try {
                var view = new ClientsEdit {
                    Reference = this,
                    Connection = Conn,
                    Refer = _shadow,
                    Location = _newFormLocation
                };
                _shadow.Transparent();
                _shadow.Form = view;
                _shadow.ShowDialog();
            }
            catch (Exception) { }
        }

        private void CChangePanel(Panel newP, Button newBtn) {
            _scurrentPanel.Hide();
            newP.Show();
            _scurrentBtn.Font = _defaultFont;
            newBtn.Font = _selectedFont;
            _scurrentBtn = newBtn;
            _scurrentPanel = newP;
        }

        private void CViewAllClientBTN_Click(object sender, EventArgs e) {
            CChangePanel(CViewAllPNL, CViewAllClientBTN);
            ClientsRefreshClientsList();
        }

        private void CViewSummaryBTN_Click(object sender, EventArgs e) {
            CChangePanel(CSummaryPNL, CViewSummaryBTN);
        }
        #endregion

        #region View All

        #region CMS - View All Data Grid

        public void ClientsRefreshClientsList() {
            CClientListTBL.DataSource = GetClientList();
            CClientListTBL.Columns["cid"].HeaderText = "ID";
            CClientListTBL.Columns["cid"].Visible = false;
            CClientListTBL.Columns["name"].HeaderText = "NAME";
            CClientListTBL.Columns["name"].Width = 300;
            CClientListTBL.Columns["contactno"].HeaderText = "LOCATION";
            CClientListTBL.Columns["contactno"].Width = 300;
            CClientListTBL.Sort(CClientListTBL.Columns[1], ListSortDirection.Ascending);

            CActiveClientLBL.Text = GetNumberOfActiveClients() + " active clients";
            CTotalClientLBL.Text = GetTotalClients() + " total clients";

            CClientListTBL.ClearSelection();
        }
        private void CClientListTBL_DoubleClick(object sender, EventArgs e) {
            CViewDetailsBTN.PerformClick();
        }
        private void CViewDetailsBTN_Click(object sender, EventArgs e) {
            try {
                if (CClientListTBL.SelectedRows.Count == 0) {
                    rylui.RylMessageBox.ShowDialog("No client is selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } else {
                    var view = new ClientsView {
                        Cid = int.Parse(CClientListTBL.SelectedRows[0].Cells[0].Value.ToString()),
                        Reference = this,
                        Connection = Conn,
                        Refer = _shadow,
                        Location = _newFormLocation
                    };
                    _shadow.Transparent();
                    _shadow.Form = view;
                    _shadow.ShowDialog();
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
            _extraQueryParams = "";
            CViewAllSearchLine.Visible = false;
            ClientsRefreshClientsList();
        }
        private void CViewAllSearchBX_TextChanged(object sender, EventArgs e) {
            var temp = CViewAllSearchBX.Text;
            string Kazoo;

            Kazoo = "name";

            if (CViewAllSearchBX.Text.Contains("\\")) {
                temp = temp + "?";
            }
            _extraQueryParams = " where (" + Kazoo + " like '" + temp + "%' OR " + Kazoo + " like '%" + temp + "%' OR " + Kazoo + " LIKe '%" + temp + "')";
            ClientsRefreshClientsList();
        }


        #endregion

        #endregion

        #endregion

        #region Schedules Management System

        #region SMS - Page Load and Side Panel
        public void SchedLoadPage() {
            SchedLoadSidePnl();

            _scurrentBtn = SViewReqBTN;
            _scurrentPanel = SViewReqPNL;

            SViewReqBTN.PerformClick();
        }

        public void SchedLoadSidePnl() {
            var b = (!Scheduling.GetNumberOfClientRequests(Enumeration.RequestStatus.Pending).Equals("0")) ?
                SchedBTN.Text = Scheduling.GetNumberOfClientRequests(Enumeration.RequestStatus.Pending) :
                SchedBTN.Text = string.Empty;
            SClientRequestsLBL.Text = Scheduling.GetNumberOfClientRequests(Enumeration.RequestStatus.Pending) + " pending requests";
            SUnassignedGuardsLBL.Text = Scheduling.GetNumberOfUnassignedGuards() + " unsassigned guards";
            SAssignedGuardsLBL.Text = Scheduling.GetNumberOfAssignedGuards() + " assigned guards";
        }

        private void SChangePanel(Panel newP, Button newBtn, bool req) {
            _scurrentPanel.Hide();
            newP.Show();
            _scurrentBtn.Font = _defaultFont;
            newBtn.Font = _selectedFont;
            _scurrentBtn = newBtn;
            _scurrentPanel = newP;
            SViewReqAssBTN.Visible = req;
        }

        private void SViewReqBTN_Click(object sender, EventArgs e) {
            SChangePanel(SViewReqPNL, SViewReqBTN, true);
            SchedLoadRequestsPage();
        }

        private void SViewAssBTN_Click(object sender, EventArgs e) {
            SChangePanel(SViewAssPNL, SViewAssBTN, false);
            SchedLoadAssignmentPage();
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
                var view = new SchedRequestGuard {
                    Reference = this,
                    Refer = _shadow,
                    Location = _newFormLocation,
                };

                _shadow.Transparent();
                _shadow.Form = view;
                _shadow.ShowDialog();
            }
            catch (Exception) { }
        }
        private void SViewReqDisBTN_Click(object sender, EventArgs e) {
            if (IsUnscheduled()) {
                try {
                    var view = new SchedUnassignGuard {
                        Reference = this,
                        Cid = int.Parse(((ComboBoxItem)SViewAssSearchClientCMBX.SelectedItem).ItemID),
                        Refer = _shadow,
                        Guards = SViewAssGRD.SelectedRows,
                        Location = _newFormLocation
                    };
                    _shadow.Transparent();
                    _shadow.Form = view;
                    _shadow.ShowDialog();
                }
                catch (Exception) { }
            } else {
                rylui.RylMessageBox.ShowDialog("You can't unassign a guard with an active assignment \nPlease dismiss the guards before unassigning them", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region SMS - View Requests
        private int _rid;
        private bool _changeDate;

        private void SViewReqGRD_CellEnter(object sender, DataGridViewCellEventArgs e) {
            _rid = int.Parse(SViewReqGRD.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        private void SViewReqGRD_DoubleClick(object sender, EventArgs e) {
            SViewReqViewBTN.PerformClick();
        }

        private void SViewReqFilterCMBX_SelectedIndexChanged(object sender, EventArgs e) {
            LoadViewReqTable(Scheduling.GetRequests(SViewReqSearchTXTBX.Text, -1, SViewReqFilterCMBX.SelectedIndex, "name", "name asc"));
        }

        private void SViewReqDTPK_ValueChanged(object sender, EventArgs e) {
            LoadViewReqTable(Scheduling.GetRequests(SViewReqSearchTXTBX.Text, -1, SViewReqFilterCMBX.SelectedIndex, "name", "name asc", SViewReqDTPK.Value));
            _changeDate = true;
        }

        private void SViewReqResetDateBTN_Click(object sender, EventArgs e) {
            LoadViewReqTable(Scheduling.GetRequests("", -1, 0, "name", "name asc"));
            _changeDate = false;
        }

        private void SchedLoadRequestsPage() {
            SViewReqFilterCMBX.SelectedIndex = 0;
            SchedRefreshRequests();
        }

        public void SchedRefreshRequests() {
            LoadViewReqTable(Scheduling.GetRequests("", -1, SViewReqFilterCMBX.SelectedIndex, "name", "name asc"));
        }

        private void SViewReqSearchTXTBX_TextChanged(object sender, EventArgs e) {
            if (_changeDate) LoadViewReqTable(Scheduling.GetRequests(SViewReqSearchTXTBX.Text, -1, SViewReqFilterCMBX.SelectedIndex, "name", "name asc", SViewReqDTPK.Value));
            else LoadViewReqTable(Scheduling.GetRequests(SViewReqSearchTXTBX.Text, -1, SViewReqFilterCMBX.SelectedIndex, "name", "name asc"));
        }

        private void LoadViewReqTable(DataTable dv) {
            SViewReqGRD.DataSource = dv;
            SViewReqGRD.Columns[0].Visible = false;
            SViewReqGRD.Columns[1].HeaderText = "NAME";
            SViewReqGRD.Columns[2].HeaderText = "DATE ENTRY";
            SViewReqGRD.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            SViewReqGRD.Columns[3].HeaderText = "TYPE";
            SViewReqGRD.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            SViewReqGRD.Columns[4].HeaderText = "STATUS";
            SViewReqGRD.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            SViewReqGRD.Columns[1].Width = 250;
            SViewReqGRD.Columns[2].Width = 120;
            SViewReqGRD.Columns[3].Width = 120;
            SViewReqGRD.Columns[4].Width = 100;

            SViewReqGRD.Sort(SViewReqGRD.Columns[2], ListSortDirection.Descending);
        }
        private void SViewReqSearchTXTBX_Enter(object sender, EventArgs e) {
            if (SViewReqSearchTXTBX.Text == FilterText) {
                SViewReqSearchTXTBX.Text = EmptyText;
                _extraQueryParams = EmptyText;
            }
            SViewReqSearchLine.Visible = true;
        }

        private void SViewReqSearchTXTBX_Leave(object sender, EventArgs e) {
            if (SViewReqSearchTXTBX.Text == EmptyText) {
                SViewReqSearchTXTBX.Text = FilterText;
                _extraQueryParams = EmptyText;
            }
            SchedRefreshRequests();
            SViewReqSearchLine.Visible = false;
        }

        private void SViewReqViewBTN_Click(object sender, EventArgs e) {
            try {
                if (SViewReqGRD.SelectedRows[0].Cells[3].Value.ToString().Equals("Assignment")) {
                    try {
                        var view = new SchedViewAssReq {
                            Reference = this,
                            Raid = _rid,
                            Refer = _shadow,
                            Location = _newFormLocation
                        };
                        _shadow.Transparent();
                        _shadow.Form = view;
                        _shadow.ShowDialog();
                    }
                    catch (Exception) { }
                } else {
                    try {
                        var view = new SchedViewDisReq {
                            Reference = this,
                            Rid = _rid,
                            Refer = _shadow,
                            Location = _newFormLocation
                        };
                        _shadow.Transparent();
                        _shadow.Form = view;
                        _shadow.ShowDialog();
                    }
                    catch (Exception) { }
                }
            }
            catch { }
        }

        #endregion

        #region SMS - View Assignment
        private void SchedLoadAssignmentPage() {
            SViewAssSearchClientCMBX.Items.Clear();
            SViewAssSearchClientCMBX.Items.Add(new ComboBoxItem("All", "-1"));
            SViewAssSearchClientCMBX.SelectedIndex = 0;
            SViewAssCMBX.SelectedIndex = 0;

            SViewAssViewDetailsBTN.Location = new Point(282, 600);
            SViewAssUnassignBTN.Visible = false;

            var dv = Client.GetClients().DefaultView;
            dv.Sort = "name asc";
            var dt = dv.ToTable();

            for (var i = 0; i < dt.Rows.Count; i++) SViewAssSearchClientCMBX.Items.Add(new ComboBoxItem(dt.Rows[i][1].ToString(), dt.Rows[i][0].ToString()));
        }
        private void SViewAssGRD_DoubleClick(object sender, EventArgs e) {
            if (SViewAssViewDetailsBTN.Visible) SViewAssViewDetailsBTN.PerformClick();
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
            SchedRefreshAssignments();
        }

        public void SchedRefreshAssignments() {
            SViewAssGRD.DataSource = Scheduling.GetAssignmentsByClient(int.Parse(((ComboBoxItem)SViewAssSearchClientCMBX.SelectedItem).ItemID), SViewAssCMBX.SelectedIndex);

            if (SViewAssGRD.Rows.Count > 0) {
                SViewAssGRD.Columns[0].Visible = false;
                SViewAssGRD.Columns[1].Visible = false;
                SViewAssGRD.Columns[2].Visible = false;
                SViewAssGRD.Columns[3].HeaderText = "NAME";
                SViewAssGRD.Columns[4].HeaderText = "ASSIGNMENT LOCATION";
                SViewAssGRD.Columns[5].HeaderText = "SCHEDULE";
                SViewAssGRD.Columns[6].HeaderText = "STATUS";

                SViewAssGRD.Columns[3].Width = 200;
                SViewAssGRD.Columns[4].Width = 210;
                SViewAssGRD.Columns[5].Width = 100;
                SViewAssGRD.Columns[5].Width = 100;

                SViewAssGRD.Sort(SViewAssGRD.Columns[3], ListSortDirection.Ascending);
                SViewAssGRD.ClearSelection();
            }
        }

        private void SViewAssCMBX_SelectedIndexChanged(object sender, EventArgs e) {
            SchedRefreshAssignments();
        }

        private void SViewAssGRD_CellEnter(object sender, DataGridViewCellEventArgs e) {
            if (SViewAssGRD.Rows[e.RowIndex].Cells[6].Value.ToString().Equals("Inactive")) { SViewAssViewDetailsBTN.Visible = false; SViewAssUnassignBTN.Visible = false; } else { SViewAssViewDetailsBTN.Visible = true; if (SViewAssSearchClientCMBX.SelectedIndex != 0) SViewAssUnassignBTN.Visible = true; }
        }

        private void SViewAssSearchTXTBX_Enter(object sender, EventArgs e) {
            if (SViewAssSearchTXTBX.Text == FilterText) {
                SViewAssSearchTXTBX.Text = EmptyText;
                _extraQueryParams = EmptyText;
            }
            SViewAssSearchLine.Visible = true;
        }

        private void SViewAssSearchTXTBX_Leave(object sender, EventArgs e) {
            if (SViewAssSearchTXTBX.Text == EmptyText) {
                SViewAssSearchTXTBX.Text = FilterText;
                _extraQueryParams = EmptyText;
            }
            SchedRefreshAssignments();
            SViewAssSearchLine.Visible = false;
        }

        private void SViewAssViewDetailsBTN_Click(object sender, EventArgs e) {
            if (SViewAssGRD.SelectedRows.Count > 1) {
                rylui.RylMessageBox.ShowDialog("More than one assignment is selected", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else {
                try {
                    var view = new SchedViewDutyDetails {
                        Reference = this,
                        Refer = _shadow,
                        Aid = int.Parse(SViewAssGRD.SelectedRows[0].Cells[2].Value.ToString()),
                        Gid = int.Parse(SViewAssGRD.SelectedRows[0].Cells[0].Value.ToString()),
                        Location = _newFormLocation
                    };
                    _shadow.Transparent();
                    _shadow.Form = view;
                    _shadow.ShowDialog();
                }
                catch (Exception) { }
            }
        }

        private bool IsUnscheduled() {
            //Method to check if the selected Guards are ready to be dismissed

            var ret = true;
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
                _extraQueryParams = EmptyText;
            }
            SArchiveSearchLine.Visible = true;
        }

        private void SArchiveViewDetailsBTN_Click(object sender, EventArgs e) {
            try {
                var view = new SchedViewDutyDetails {
                    Reference = this,
                    Refer = _shadow,
                    Location = _newFormLocation
                };
                _shadow.Transparent();
                _shadow.Form = view;
                _shadow.ShowDialog();
            }
            catch (Exception) { }
        }

        private void SArchiveSearchTXTBX_Leave(object sender, EventArgs e) {
            if (SArchiveSearchTXTBX.Text == EmptyText) {
                SArchiveSearchTXTBX.Text = FilterText;
                _extraQueryParams = EmptyText;
            }
            SCHEDRefreshArchive();
            SArchiveSearchTXTBX.Visible = false;
        }
        #endregion

        #endregion

        #region Payroll Management System

        #region PMS - Load/Side Panel
        private void PayLoadPage() {
            _scurrentPanel = PPayrollSummaryPage;
            _scurrentBtn = PPayrollSummaryBTN;
            PPayrollSummaryBTN.PerformClick();
        }
        private void PConfHoliday_Click(object sender, EventArgs e) {
            try {
                var view = new PayrollConfHolidays {
                    Refer = _shadow,
                    Location = _newFormLocation
                };


                _shadow.Transparent();
                _shadow.Form = view;
                _shadow.ShowDialog();
            }
            catch (Exception) { }
        }
        private void PConfigSSSBTN_Click(object sender, EventArgs e) {
            try {
                var view = new PayrollConfigSss {
                    Refer = _shadow,
                    Location = _newFormLocation
                };
                _shadow.Transparent();
                _shadow.Form = view;
                _shadow.ShowDialog();
            }
            catch (Exception) { }
        }
        private void PcHnagePanel(Panel newP, Button newBtn) {
            _scurrentPanel.Hide();
            newP.Show();
            _scurrentBtn.Font = _defaultFont;
            newBtn.Font = _selectedFont;
            _scurrentBtn = newBtn;
            _scurrentPanel = newP;
        }

        private void PEmpListBTN_Click(object sender, EventArgs e) {
            PcHnagePanel(PEmpListPage, PEmpListBTN);
            PayLoadEmployeeList();
        }
        private void PAdjustBTN_Click(object sender, EventArgs e) {
            try {
                var view = new PayrollConfigBasicPay {
                    Refer = _shadow,
                    Location = _newFormLocation,
                };


                _shadow.Transparent();
                _shadow.Form = view;
                _shadow.ShowDialog();
            }
            catch (Exception) { }
        }

        private void PPayrollSummaryBTN_Click(object sender, EventArgs e) {
            PcHnagePanel(PPayrollSummaryPage, PPayrollSummaryBTN);
        }

        private void PSalaryReportBTN_Click(object sender, EventArgs e) {
            PcHnagePanel(PSalaryReportPage, PSalaryReportBTN);
        }

        private void PArchiveBTN_Click(object sender, EventArgs e) {
            PcHnagePanel(PArchivePage, PArchiveBTN);
        }

        #endregion

        #region PMS - Employee List 
        private void PayLoadEmployeeList() {
            PEmpListSortCMBX.SelectedIndex = 0;
            PEmpListGRD.DataSource = Payroll.GetGuardsPayrollMain();
            PEmpListGRD.Columns[0].Visible = false;
            PEmpListGRD.Columns[1].HeaderText = "GUARD'S NAME";
            PEmpListGRD.Columns[2].HeaderText = "ASSIGNED TO";
            PEmpListGRD.Columns[3].HeaderText = "ATTENDANCE";
            PEmpListGRD.Columns[4].HeaderText = "STATUS";

            PEmpListGRD.Columns[1].Width = 200;
            PEmpListGRD.Columns[2].Width = 180;
            PEmpListGRD.Columns[3].Width = 130;
            PEmpListGRD.Columns[4].Width = 90;

            PEmpListGRD.Sort(PEmpListGRD.Columns[1], ListSortDirection.Ascending);
            PEmpListViewBTN.Visible = false;
        }
        private void PEmpListGRD_CellEnter(object sender, DataGridViewCellEventArgs e) {
            PEmpListViewBTN.Visible = true;
        }
        private void PEmpListGRD_DoubleClick(object sender, EventArgs e) {
            PEmpListViewBTN.PerformClick();
        }
        private void PEmpListViewBTN_Click(object sender, EventArgs e) {
            try {
                var view = new PayrollEmployeeView {
                    Reference = this,
                    Refer = _shadow,
                    Gid = int.Parse(PEmpListGRD.SelectedRows[0].Cells[0].Value.ToString()),
                    Location = _newFormLocation
                };
                _shadow.Transparent();
                _shadow.Form = view;
                _shadow.ShowDialog();
            }
            catch (Exception) { }
        }

        private void PEmpListSearchBX_Enter(object sender, EventArgs e) {
            if (PEmpListSearchBX.Text == FilterText) {
                PEmpListSearchBX.Text = EmptyText;
                _extraQueryParams = EmptyText;
            }
            PEmpListSearchLine.Visible = true;
        }

        private void PEmpListSearchBX_Leave(object sender, EventArgs e) {
            if (PEmpListSearchBX.Text == EmptyText) {
                PEmpListSearchBX.Text = FilterText;
                _extraQueryParams = EmptyText;
            }
            PEmpListSearchLine.Visible = false;
        }
        #endregion

        #endregion



        //======================================//
        //          BES MGA SQL METHODS         //
        //======================================// 

        private DataTable GetGuardList(int mode) {
            String query;
            String orderbyclause;
            
            if (mode == 0) {
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
            Conn.Open();
            MySqlCommand comm = new MySqlCommand(query + _extraQueryParams + orderbyclause, Conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            Conn.Close();
            return dt;
        }

        private int GetNumberOfActiveClients() {
            Conn.Open();
            MySqlCommand comm = new MySqlCommand("SELECT * FROM client WHERE cstatus = 1", Conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            Conn.Close();
            return dt.Rows.Count;
        }
        private int GetTotalClients() {
            Conn.Open();
            MySqlCommand comm = new MySqlCommand("SELECT * FROM client", Conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            Conn.Close();
            return dt.Rows.Count;
        }
        private DataTable GetClientList() {
            String q = "SELECT cid, name, CONCAT(Clientstreetno,' ',Clientstreet,', ', Clientbrgy,', ',Clientcity) AS contactno FROM client" + _extraQueryParams;
            return SQLTools.ExecuteQuery(q);
        }


    }
}