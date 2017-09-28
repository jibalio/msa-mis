using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using rylui;

namespace MSAMISUserInterface {
    public partial class MainForm : Form {
        private const string FilterText = "Search or filter";
        private readonly Font _defaultFont = new Font("Segoe UI", 10);
        private readonly Font _selectedFont = new Font("Segoe UI", 10, FontStyle.Bold);
        private readonly Shadow _shadow = new Shadow();
        private string _extraQueryParams = "";
        private readonly bool[] _notif = {false, false, false};
        private int _day = DateTime.Now.Day;

        private Point _formLocation;
        private Button _scurrentBtn;
        private Panel _scurrentPanel;
        private bool _allowResize;

        //Only Paste Global Variable Here//

        public LoginForm Lf;
        public string User;

        #region Form Initiation and load

        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            //Get the relative position after loading
            _shadow.Size = Size;
            _shadow.Transparency = 0.6;
            //Initiate the methods that updates the app
            InitiateForm();
        }

        private void InitiateForm() {
            //This method is used to initiate the look and feel of the Main Form
            //Can also be used to initiate global variables

            //Main Form Arrangement
            DashboardPage.BringToFront();
            DragPanel.BringToFront();
            ControlBoxPanel.BringToFront();
            SamplePNL.SendToBack();

            //Buttons Color
            _currentBtn = DashboardBTN;
            _splitContainer = SamplePNL;
            ControlBoxPanel.BackColor = _dashboard;

            //Variable Initialization
            ControlBoxTimeLBL.Text = "Logged in as " + User;
            TimeLBL.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy").ToUpper();
            _scurrentPanel = GViewAllPNL;
            _scurrentBtn = GViewAllPageBTN;
            _formLocation = Location;

            //Initial Methods
            FadeTMR.Start();
            DailyQuote();
            CheckPayday();
            NotifTMR.Start();
        }

        private void DailyQuote() {
            //This is an extra method to intitate the Daily Quotes behind the Dashboard=

            try {
                var lines = File.ReadAllLines("../../Resources/Quotes.txt");
                var r = new Random();
                var randomLineNumber = r.Next(0, lines.Length - 1);
                if (randomLineNumber % 2 != 0) randomLineNumber = randomLineNumber - 1;
                QuoteMainBX.Text = '"' + lines[randomLineNumber] + '"';
                QuoteFromBX.Text = "from " + lines[randomLineNumber + 1];
                if (DateTime.Now.Month == 7) {
                    DevBX.Visible = true;
                    HBDLBL.Visible = true;
                    if (DateTime.Now.Day == 1) {
                        DevBX.Text = "Jan Leryc V. Ibalio - MSAMIS Dev";
                    }
                    else if (DateTime.Now.Day == 18) {
                        DevBX.Text = "Anton John B. Pasigado - MSAMIS Dev";
                    }
                    else {
                        HBDLBL.Visible = false;
                        DevBX.Visible = false;
                    }
                }
                else if (DateTime.Now.Month == 5 && DateTime.Now.Day == 5) {
                    DevBX.Text = "Rhyle Abram P. Regodon - MSAMIS Dev";
                    HBDLBL.Visible = true;
                    DevBX.Visible = true;
                }
                else {
                    HBDLBL.Visible = false;
                    DevBX.Visible = false;
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            //For the Logout Button on the Control Box

            if (RylMessageBox.ShowDialog("Are you sure you want to Logout?", "Logout?", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                Close();
        }

        private void LoadNotifications() {
            //To Initiate the the Tooltip notifications

            //Scheduling Tooltip Page Notification

            try {
                if (!Scheduling.GetNumberOfClientRequests(Enumeration.RequestStatus.Pending).Equals("0")) {
                    ClientRequestsTLTP.Show(
                        "You have " + Scheduling.GetNumberOfClientRequests(Enumeration.RequestStatus.Pending) +
                        " pending requests.", SchedBTN, 2000);
                    ClientRequestsTLTP.Show(
                        "You have " + Scheduling.GetNumberOfClientRequests(Enumeration.RequestStatus.Pending) +
                        " pending requests.", SchedBTN, 2000);
                    SchedBTN.Text = Scheduling.GetNumberOfClientRequests(Enumeration.RequestStatus.Pending);
                }
                else {
                    SchedBTN.Text = string.Empty;
                }
            }
            catch (Exception ex) {
                ShowErrorBox("Notifications", ex.Message);
            }
        }

        #endregion

        #region Form Features

        private const int CsDropshadow = 0x20000;

        protected override CreateParams CreateParams {
            get {
                var cp = base.CreateParams;
                cp.ClassStyle |= CsDropshadow;
                return cp;
            }
        }

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
            if (_mouseDown && MaximizeBTN.Tag.ToString().Equals("0")) {
                Location = new Point(Location.X - _lastLocation.X + e.X, Location.Y - _lastLocation.Y + e.Y);
                Update();
            } 
            if (MaximizeBTN.Tag.ToString().Equals("0")) _formLocation = Location;
        }

        private void DragPanel_MouseUp(object sender, MouseEventArgs e) {
            _allowResize = false;
        }

        private void DragPanel_MouseMove(object sender, MouseEventArgs e) {
            if (_allowResize) {
                Height = Height + e.Y;
                Invalidate();
                Update();
                Width = Width + e.X;
                Invalidate();
                Update();
            }
        }

        private void DragPanel_MouseDown(object sender, MouseEventArgs e) {
            _allowResize = true;
        }

        #endregion

        #region Slide-Up Dashboard

        private void Dashboard_MouseUp(object sender, MouseEventArgs e) {
            if (_mouseDown) { 
                if (DashboardPage.Location.Y <= (DashboardPage.Height/2)) {
                    if (DashboardPage.Location.Y <= -(DashboardPage.Height / 4))
                        DashboardPage.Location = new Point(DashboardPage.Location.X, -(DashboardPage.Height - (60 * 2)));
                    else if (DashboardPage.Location.Y <= -(DashboardPage.Height / 3))
                        DashboardPage.Location = new Point(DashboardPage.Location.X, -(DashboardPage.Height - (60 * 3)));
                    else if (DashboardPage.Location.Y <= -(DashboardPage.Height / 2))
                        DashboardPage.Location = new Point(DashboardPage.Location.X, -(DashboardPage.Height - (60 * 4)));
                    RecordsBTN.PerformClick();
                }
            }
            _mouseDown = false;
        }

        private void Dashboard_MouseMove(object sender, MouseEventArgs e) {
            if (_mouseDown)
                if (DashboardPage.Location.Y - _lastLocation.Y + e.Y < 32)
                    DashboardPage.Location = new Point(DashboardPage.Location.X,
                        DashboardPage.Location.Y - _lastLocation.Y + e.Y);
        }

        #endregion

        #region Pressing Enter on DataGrids

        private void GAllGuardsGRD_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                GEditDetailsBTN.PerformClick();
            }
        }

        private void GArchivedGuardsGRD_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                GArchiveViewDetailsBTN.PerformClick();
            }
        }

        private void CClientListTBL_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                CViewDetailsBTN.PerformClick();
            }
        }

        private void SViewAssGRD_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                SViewAssViewDetailsBTN.PerformClick();
            }
        }

        private void SGuardHistoryGRD_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                SGuardHistoryViewBTN.PerformClick();
            }
        }

        private void SViewReqGRD_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                SViewReqViewBTN.PerformClick();
            }
        }

        private void PEmpListGRD_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                PEmpListViewBTN.PerformClick();
            }
        }

        #endregion

        private void FadeTMR_Tick(object sender, EventArgs e) {
            //Gives the form a Fade-In effect

            Opacity += 0.2;
            if (Opacity.Equals(1)) {
                FadeTMR.Stop();

                //Call the tooltips after the Timer to avoid them being dismissed
                if (Login.AccountType == 1)
                    LoadNotifications();
                else SchedBTN.Text = string.Empty;
            }
        }
        private static void ShowErrorBox(string name, string error) {
            RylMessageBox.ShowDialog("Please try again.\nIf the problem still persist, please contact your administrator. \n\n\nError Message: \n=============================\n" + error + "\n=============================\n", "Error Configuring " + name,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            _shadow.Close();
            Lf.Opacity = 0;
            Lf.Show();
            Hide();
        }
        private void MainForm_SizeChanged(object sender, EventArgs e) {
            _shadow.Size = Size;
            UpdateLayout();
        }

        private void UpdateLayout() {
            if (GArchivePNL.Visible) GArchiveListFormat();
            if (GViewAllPNL.Visible) GuardsListFormat();
            if (GSummaryPNL.Visible) GuardsLoadReport();
            if (CViewAllPNL.Visible) CListFormat();
            if (CCurrentSummaryPNL.Visible) ClientsLoadSummary();
            if (SViewReqPNL.Visible) SchedViewRequestFormat();
            if (SDutyDetailsPNL.Visible) SchedLoadReport();
            if (SViewAssPNL.Visible) SchedRefreshAssignmentLayout();
            if (SGuardHistoryPNL.Visible) SchedGuardHistoryFormat();
            if (PSalaryReportPage.Visible) PayLoadReportLayout();
            if (PEmpListPage.Visible) PayChnageSize();
            NotifLayout();
        }


        private void MainForm_LocationChanged(object sender, EventArgs e) {
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

        private void MaximizeBTN_Click(object sender, EventArgs e) {
            if (MaximizeBTN.Tag.ToString().Equals("0")) {
                Left = Top = 0;
                Width = Screen.PrimaryScreen.WorkingArea.Width;
                Height = Screen.PrimaryScreen.WorkingArea.Height;
                MaximizeBTN.Tag = "1";
                MaximizeBTN.Image = Properties.Resources.Minimize;
                DragPanel.Visible = false;
            } else {
                DragPanel.Visible = true;
                Location = _formLocation;
                Width = 1000;
                Height = 700;
                MaximizeBTN.Tag = "0";
                MaximizeBTN.Image = Properties.Resources.Maximize;
            }
        }

        private void MinimizeBTN_Click(object sender, EventArgs e) {
            WindowState = FormWindowState.Minimized;
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
                    Username = User,
                    Refer = _shadow,
                };
                _shadow.Transparent();
                _shadow.Form = view;
                _shadow.ShowDialog();
            }
            catch (Exception exception) { Console.WriteLine(exception); }
        }

        private void DashboardTMR_Tick(object sender, EventArgs e) {
            //This event gives the dashboard its slide-up effect when changing panels

            if (_dashboardToBeMinimized) {
                DragPanel.BackColor = Color.White;
                DragPanel.BackgroundImage = Properties.Resources.Drag;
                var defaultPoint = new Point(70, -Height-DashboardPage.Height);
                if (DashboardPage.Location.Y > defaultPoint.Y) {
                    DashboardPage.Location = new Point(DashboardPage.Location.X, DashboardPage.Location.Y - 60);
                }
                else {
                    DashboardTMR.Stop();
                    ControlBoxLBL.Visible = true;
                    ControlBoxTimeLBL.Visible = true;
                    ControlBoxPanel.BackColor = _primary;
                    SettingsBTN.Visible = true;
                }
            }
            else if (!_dashboardToBeMinimized) {
                ControlBoxLBL.Visible = false;
                ControlBoxTimeLBL.Visible = false;
                SettingsBTN.Visible = false;
                var defaultPoint = new Point(70, 32);
                if (DashboardPage.Location.Y < defaultPoint.Y && DashboardPage.Location.Y < 32) {
                    DashboardPage.Location = new Point(DashboardPage.Location.X, DashboardPage.Location.Y + 60);
                }
                else {
                    DashboardPage.Location = new Point(DashboardPage.Location.X, 32);
                    DashboardTMR.Stop();
                    DragPanel.BackColor = _dashboard;
                    DragPanel.BackgroundImage = Properties.Resources.DragWhite;
                    ControlBoxPanel.BackColor = _dashboard;
                    GuardsPage.Hide();
                    SchedulesPage.Hide();
                    PayrollPage.Hide();
                    ClientsPage.Hide();
                }
            }
            Invalidate();
        }

        private void RightClickStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {
            if (_splitContainer == GuardsPage) GuardsSummaryRightClick(e.ClickedItem.Text);
            else if (_splitContainer == ClientsPage) ClientsSummaryRightClick(e.ClickedItem.Text);
            else if (_splitContainer == PayrollPage) PaySummaryRightClick(e.ClickedItem.Text);
            else if (_splitContainer == SchedulesPage) SchedSummaryRightClick(e.ClickedItem.Text);
        }

        #endregion

        #region Dashboard Page Notifs

        private readonly Color _dashboardHover = Color.FromArgb(72, 87, 112);

        private void ArrangeNotif() {
            NotifLayout();
            // This method is used to rearrange the Notifs Widgets when dismissing them
            bool[] pnl = {DPaydayNotifPNL.Visible, DDutyDetailNotifPNL.Visible, DSalaryReportNotifPNL.Visible};
            var loc1 = new Point(DPaydayNotifPNL.Location.X, 208);
            var loc2 = new Point(DPaydayNotifPNL.Location.X, 310);
            if (pnl[0]) if (!pnl[1]) DSalaryReportNotifPNL.Location = loc2;
            if (pnl[1])
                if (!pnl[0]) {
                    DDutyDetailNotifPNL.Location = loc1;
                    DSalaryReportNotifPNL.Location = loc2;
                }
            if (pnl[2]) if (!pnl[0] && !pnl[1]) DSalaryReportNotifPNL.Location = loc1;
        }

        private void NotifLayout() {
            DPaydayNotifPNL.Location = new Point(
                DashboardPage.Width / 2 - DPaydayNotifPNL.Size.Width / 2, DPaydayNotifPNL.Location.Y);

            DDutyDetailNotifPNL.Location = new Point(
                DashboardPage.Width / 2 - DDutyDetailNotifPNL.Size.Width / 2, DDutyDetailNotifPNL.Location.Y);

            DSalaryReportNotifPNL.Location = new Point(
                DashboardPage.Width / 2 - DSalaryReportNotifPNL.Size.Width / 2, DSalaryReportNotifPNL.Location.Y);
        }

        private void NotifTMR_Tick(object sender, EventArgs e) {
            try {
                if (_day != DateTime.Now.Day) {
                    CheckPayday();
                    SQLTools.ExecuteNonQuery("call init_CHECKDATE_ALL()");
                }
                _day = DateTime.Now.Day;
            }
            catch (Exception ex) {
                ShowErrorBox("Date Checker", ex.Message);
            }
        }

        private void CheckPayday() {
            try {
                var payday = Payroll.GetPreviousPayDay();

                if (DateTime.Now.Day >= 1 && DateTime.Now.Day < 5 && !DPaydayNotifPNL.Visible && !_notif[0]) {
                    DPaydayNotifPNL.Visible = true;
                    DPayDayTitle.Text = "Attendance Period";
                    DPayDayNotifLBL.Text = "Time to add attendance details for guards";
                }
                if (DateTime.Now.Day == payday.Day &&
                    DateTime.Now.Month == payday.Month &&
                    DateTime.Now.Year == payday.Year && !DPaydayNotifPNL.Visible && !_notif[0]) {
                    DPaydayNotifPNL.Visible = true;
                    DPayDayTitle.Text = "Payroll Payday";
                    DPayDayNotifLBL.Text = "for the month of " + payday.ToString("MMMM yyyy");
                }
                if (DateTime.Now.Day == 5) {
                    DDutyDetailNotifPNL.Visible = !_notif[1];
                    DSalaryReportNotifPNL.Visible = !_notif[2];
                    DDutyDetailNotifLBL.Text = DSalaryReportNotifLBL.Text =
                        "for the month of " +
                        new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 1).ToString("MMMM yyyy");
                   ReportsExportWorker.RunWorkerAsync();
                }
                ArrangeNotif();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }


        private void ReportsExportWorker_DoWork(object sender, DoWorkEventArgs e) {
            var rp = new ReportsPreview();
            rp.FormatPDF('d');
            rp.FormatPDF('s');
        }

        private void DMonthlyDutyReportPNL_MouseEnter(object sender, EventArgs e) {
            DPaydayNotifPNL.BackColor = _dashboardHover;
        }

        private void DMonthlyDutyReportPNL_MouseLeave(object sender, EventArgs e) {
            DPaydayNotifPNL.BackColor = _accent;
        }

        private void DClientSummaryPNL_MouseEnter(object sender, EventArgs e) {
            DDutyDetailNotifPNL.BackColor = _dashboardHover;
        }

        private void DClientSummaryPNL_MouseLeave(object sender, EventArgs e) {
            DDutyDetailNotifPNL.BackColor = _accent;
        }

        private void DSalaryReportPNL_MouseEnter(object sender, EventArgs e) {
            DSalaryReportNotifPNL.BackColor = _dashboardHover;
        }

        private void DSalaryReportPNL_MouseLeave(object sender, EventArgs e) {
            DSalaryReportNotifPNL.BackColor = _accent;
        }

        private void DMonthlyX_Click(object sender, EventArgs e) {
            DPaydayNotifPNL.Visible = false;
            _notif[0] = true;
            ArrangeNotif();
        }

        private void DClientX_Click(object sender, EventArgs e) {
            DDutyDetailNotifPNL.Visible = false;
            _notif[1] = true;
            ArrangeNotif();
        }

        private void DSalaryX_Click(object sender, EventArgs e) {
            DSalaryReportNotifPNL.Visible = false;
            _notif[2] = true;
            ArrangeNotif();
        }

        private void DMonthlyDutyReportPNL_Click(object sender, EventArgs e) {
            PayrollBTN.PerformClick();
        }

        private void DClientSummaryPNL_Click(object sender, EventArgs e) {
            SchedBTN.PerformClick();
            SDutyDetailsBTN.PerformClick();
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
            GViewAllPageBTN.PerformClick();
        }

        private void RAddEmpBTN_Click(object sender, EventArgs e) {
            try {
                var view = new GuardsEdit {
                    Reference = this,
                    Refer = _shadow,
                };
                _shadow.Transparent();
                _shadow.Form = view;
                _shadow.ShowDialog();
            }
            catch (Exception exception) { Console.WriteLine(exception); }
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
            GuardsRefreshGuardsList();
        }

        private void GSummaryPageBTN_Click(object sender, EventArgs e) {
            GChangePanel(GSummaryPNL, GSummaryPageBTN);
            GuardsLoadReport();
        }

        #endregion

        #region GMS - View All

        #region GMS - View All - Data Grid

        private void GAllGuardsGRD_DoubleClick(object sender, EventArgs e) {
            if (GEditDetailsBTN.Visible) GEditDetailsBTN.PerformClick();
        }

        private void GViewAllNameRDBTN_CheckedChanged(object sender, EventArgs e) {
            GuardsRefreshGuardsList();
        }

        public void GuardsRefreshGuardsList() {
            try {
                GAllGuardsGRD.DataSource = Guard.GetAllGuards(_extraQueryParams, GViewAllNameRDBTN.Checked ? 0 : 1);
                GuardsListFormat();
                GAllGuardsGRD.ClearSelection();

                GActiveLBL.Text = SQLTools.GetNumberOfGuards("active") + " active guards";
                GInactiveLBL.Text = SQLTools.GetNumberOfGuards("inactive") + " inactive guards";
            }
            catch (Exception ex) {
                ShowErrorBox("Guards Management Module", ex.Message);
            }
        }

        private void GuardsListFormat() {
            if (GViewAllNameRDBTN.Checked) {
                GAllGuardsGRD.Columns[0].Visible = false;
                GAllGuardsGRD.Columns[1].Width = (int)(GAllGuardsGRD.Width * 0.3664);
                GAllGuardsGRD.Columns[4].Width = (int)(GAllGuardsGRD.Width * 0.1221);
                GAllGuardsGRD.Columns[3].Width = (int)(GAllGuardsGRD.Width * 0.1221);
                GAllGuardsGRD.Columns[5].Width = (int)(GAllGuardsGRD.Width * 0.2137);
                GAllGuardsGRD.Columns[2].Width = (int)(GAllGuardsGRD.Width * 0.1069);
            } else {
                GAllGuardsGRD.Columns[0].Visible = false;
                GAllGuardsGRD.Columns[1].Width = (int)(GAllGuardsGRD.Width * 0.3664);
                GAllGuardsGRD.Columns[2].Width = (int)(GAllGuardsGRD.Width * 0.4580);
                GAllGuardsGRD.Columns[3].Width = (int)(GAllGuardsGRD.Width * 0.1069);
            }
        }

        private void GEditDetailsBTN_Click(object sender, EventArgs e) {
            try {
                if (GAllGuardsGRD.SelectedRows.Count > 1) {
                    RylMessageBox.ShowDialog("More than 1 guard is selected.", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else if (GAllGuardsGRD.SelectedRows.Count == 0) {
                    RylMessageBox.ShowDialog("No guard is selected.", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else {
                    var view = new GuardsView {
                        Gid = int.Parse(GAllGuardsGRD.SelectedRows[0].Cells[0].Value.ToString()),
                        Reference = this,
                        Shadow = _shadow,
                    };
                    _shadow.Transparent();
                    _shadow.Form = view;
                    _shadow.ShowDialog();
                }
            }
            catch (Exception exception) { Console.WriteLine(exception); }
        }

        private void GAllGuardsGRD_CellEnter(object sender, DataGridViewCellEventArgs e) {
            if (GViewAllNameRDBTN.Checked) { 
                if (GAllGuardsGRD.SelectedRows.Count == 1) {
                    if (!GAllGuardsGRD.SelectedRows[0].Cells[2].Value.ToString().Equals("Inactive")) HideBtNs(true, false);
                    else HideBtNs(true, Login.AccountType != 2);
                }
                else if (GAllGuardsGRD.SelectedRows.Count > 1) {
                    var ret = true;
                    foreach (DataGridViewRow row in GAllGuardsGRD.SelectedRows)
                        if (!row.Cells[2].Value.ToString().Equals("Inactive")) ret = false;
                    if (ret) HideBtNs(false, Login.AccountType != 2);
                    else HideBtNs(false, false);
                }
            } else {
                if (GAllGuardsGRD.SelectedRows.Count == 1) {
                    if (!GAllGuardsGRD.SelectedRows[0].Cells[3].Value.ToString().Equals("Inactive")) HideBtNs(true, false);
                    else HideBtNs(true, Login.AccountType != 2);
                } else if (GAllGuardsGRD.SelectedRows.Count > 1) {
                    var ret = true;
                    foreach (DataGridViewRow row in GAllGuardsGRD.SelectedRows)
                        if (!row.Cells[3].Value.ToString().Equals("Inactive")) ret = false;
                    if (ret) HideBtNs(false, Login.AccountType != 2);
                    else HideBtNs(false, false);
                }
            }
        }

        private void HideBtNs(bool add, bool archive) {
            GEditDetailsBTN.Visible = add;
            GArchiveBTN.Visible = archive;
        }

        #endregion

        #region GMS - View All - Search

        private void GViewAllSearchTXTBX_Enter(object sender, EventArgs e) {
            if (GViewAllSearchTXTBX.Text == FilterText) {
                GViewAllSearchTXTBX.Text = string.Empty;
                _extraQueryParams = string.Empty;
            }
            GViewAllSearchLine.Visible = true;
        }

        private void GViewAllSearchTXTBX_Leave(object sender, EventArgs e) {
            if (GViewAllSearchTXTBX.Text == string.Empty) {
                GViewAllSearchTXTBX.Text = FilterText;
                _extraQueryParams = string.Empty;
            }
            GuardsRefreshGuardsList();
            GViewAllSearchLine.Visible = false;
        }

        private void GViewAllSearchTXTBX_TextChanged(object sender, EventArgs e) {
            var temp = GViewAllSearchTXTBX.Text.Replace("'", string.Empty);
            var kazoo = GViewAllNameRDBTN.Checked
                ? "concat(ln,', ',fn,' ',mn)"
                : "concat(StreetNo,', ', Brgy,', ',Street, ', ', City)";

            if (GViewAllSearchTXTBX.Text.Contains("\\")) temp = temp + "?";
            _extraQueryParams = " where (" + kazoo + " like '" + temp + "%' OR " + kazoo + " like '%" + temp +
                                "%' OR " + kazoo + " LIKe '%" + temp + "')";
            GuardsRefreshGuardsList();
        }

        #endregion

        #endregion

        #region GMS - Archive 

        private void ArchiveButton_Event(object sender, EventArgs e) {
            // Initialize archive connection.
            if (RylMessageBox.ShowDialog("Are you sure you want to archive the selected record(s)?", "Archive",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                try {
                    foreach (DataGridViewRow row in GAllGuardsGRD.SelectedRows)
                        Archiver.ArchiveGuard(int.Parse(row.Cells[0].Value.ToString()));
                    RylMessageBox.ShowDialog("Successfully archived Guard(s)", "Archive", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    GuardsRefreshGuardsList();
                }
                catch (Exception ex) {
                    ShowErrorBox("Guards Archiving", ex.Message);
                }
            }
        }

        private void GArchiveViewDetailsBTN_Click(object sender, EventArgs e) {
            try {
                var view = new GuardsArchive {
                    Shadow = _shadow,
                    Gid = int.Parse(GArchivedGuardsGRD.SelectedRows[0].Cells[0].Value.ToString())
                };
                _shadow.Transparent();
                _shadow.Form = view;
                _shadow.ShowDialog();
            }
            catch (Exception exception) { Console.WriteLine(exception); }
        }

        private void RefreshArchivedGuards() {
            try {
                GArchivedGuardsGRD.DataSource = Archiver.GetAllGuards(_extraQueryParams, "name asc");
                GArchivedGuardsGRD.Columns[0].Visible = false;
                GArchivedGuardsGRD.Columns[1].HeaderText = "NAME";
                GArchivedGuardsGRD.Columns[3].Visible = false;
                GArchiveListFormat();
                GArchivedGuardsGRD.ClearSelection();
            }
            catch (Exception ex) {
                ShowErrorBox("Guards Archive - Load", ex.Message);
            }
        }

        private void GArchiveListFormat() {
            GArchivedGuardsGRD.Columns[1].Width = (int)(GArchivedGuardsGRD.Width * 0.5068);
            GArchivedGuardsGRD.Columns[2].Width = (int)(GArchivedGuardsGRD.Width * 0.1365);
            GArchivedGuardsGRD.Columns[4].Width = (int)(GArchivedGuardsGRD.Width * 0.2924);
        }

        private void GArchivedGuardsGRD_DoubleClick(object sender, EventArgs e) {
            if (GArchivedGuardsGRD.SelectedRows.Count > 0) GArchiveViewDetailsBTN.PerformClick();
        }

        #endregion

        #region GMS - Archive Search

        private void GArchiveSearchBX_Enter(object sender, EventArgs e) {
            if (GArchiveSearchBX.Text.Equals("Search or filter")) GArchiveSearchBX.Text = "";
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
            var temp = GArchiveSearchBX.Text.Replace("'", string.Empty);
            if (GArchiveSearchBX.Text.Contains("\\")) temp = "";
            _extraQueryParams = temp;
            RefreshArchivedGuards();
        }

        #endregion

        #region GMS - Summary

        public void GuardsLoadReport() {
            try {
                GCurrentSummaryPNL.Location = new Point(
                    GSummaryPNL.Width / 2 - GCurrentSummaryPNL.Size.Width / 2, GCurrentSummaryPNL.Location.Y);

                var d = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                                          "\\MSAMIS Reports"); //Assuming Test is your Folder
                var files = d.GetFiles("GuardsSummaryReport*.pdf")
                    .OrderByDescending(p => p.CreationTime); //Getting Text files]

                GSummaryFilesLST.Items.Clear();
                foreach (var file in files) {
                    string[] row = {file.CreationTime.ToString("MMMM dd, yyyy"), file.FullName};
                    var listViewItem = new ListViewItem(row) {ImageIndex = 0};
                    GSummaryFilesLST.Items.Add(listViewItem);
                }
                GSummaryErrorPNL.Visible = GSummaryFilesLST.Items.Count == 0;
                GSummaryDateLBL.Text = TimeLBL.Text = DateTime.Now.ToString("dddd, MMMM dd yyyy");
                GTotalLBL.Text = Reports.GetTotalGuards('g', 't') + " guards";
                GTotalActiveLBL.Text = Reports.GetTotalGuards('g', 'a') + " guards";
            }
            catch (Exception ex) {
                ShowErrorBox("Guards Summary Report", ex.Message);
            }
        }

        private void GSummaryViewCurrent_Click(object sender, EventArgs e) {
            try {
                var view = new ReportsPreview {
                    Refer = _shadow,
                    Main = this,
                    Mode = 1
                };
                _shadow.Transparent();
                _shadow.Form = view;
                _shadow.ShowDialog();
            }
            catch (Exception exception) { Console.WriteLine(exception); }
        }

        private void GSummaryExportBTN_Click(object sender, EventArgs e) {
            try {
                var view = new Exporting {
                    Refer = _shadow,
                    Main = this,
                    Mode = 'g'
                };
                _shadow.Transparent();
                _shadow.Form = view;
                _shadow.ShowDialog();
            }
            catch (Exception exception) { Console.WriteLine(exception); }
        }

        private void GSummaryFilesLST_DoubleClick(object sender, EventArgs e) {
            try {
                Process.Start(GSummaryFilesLST.SelectedItems[0].SubItems[1].Text);
            }
            catch {
                RylMessageBox.ShowDialog("File not found \nThe file must have been moved or corrupted",
                    "File Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GuardsLoadReport();
            }
        }

        private void GSummaryFilesLST_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right)
                if (GSummaryFilesLST.FocusedItem.Bounds.Contains(e.Location)) RightClickStrip.Show(Cursor.Position);
        }

        private void GuardsSummaryRightClick(string text) {
            RightClickStrip.Hide();
            if (text.Equals("Open")) {
                try {
                    Process.Start(GSummaryFilesLST.SelectedItems[0].SubItems[1].Text);
                }
                catch {
                    RylMessageBox.ShowDialog("File not found \nThe file must have been moved or corrupted",
                        "File Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    GuardsLoadReport();
                }
            }
            else if (text.Equals("Save to...")) {
                var savefile = new SaveFileDialog {
                    FileName = "GuardsSummaryReport_" + GSummaryFilesLST.SelectedItems[0].SubItems[0].Text,
                    Filter = "Portable Document Format (.pdf)|*.pdf"
                };
                try {
                    if (savefile.ShowDialog() == DialogResult.OK)
                        File.Copy(GSummaryFilesLST.SelectedItems[0].SubItems[1].Text, savefile.FileName, true);
                }
                catch {
                    RylMessageBox.ShowDialog("File not found \nThe file must have been moved or corrupted",
                        "File Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    GuardsLoadReport();
                }
            } else if (text.Equals("Print")) {
                var FileName = GSummaryFilesLST.SelectedItems[0].SubItems[1].Text;
                try {
                    Reports.PrintPDF(FileName);
                }
                catch {
                    RylMessageBox.ShowDialog("File not found \nThe file must have been moved or corrupted",
                        "File Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else {
                if (RylMessageBox.ShowDialog(
                        "Are you sure you want to delete the report for this month? \nThis action cannot be undone.",
                        "Delete Report", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    try {
                        File.Delete(GSummaryFilesLST.SelectedItems[0].SubItems[1].Text);
                        GuardsLoadReport();
                    }
                    catch {
                        RylMessageBox.ShowDialog("File not found \nThe file must have been moved or corrupted",
                            "File Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        GuardsLoadReport();
                    }
                }
            }
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
                    Refer = _shadow
                };
                _shadow.Transparent();
                _shadow.Form = view;
                _shadow.ShowDialog();
            }
            catch (Exception exception) { Console.WriteLine(exception); }
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
            ClientsLoadSummary();
        }

        #endregion

        #region View All

        #region CMS - View All Data Grid

        public void ClientsRefreshClientsList() {
            try {
                CClientListTBL.DataSource = Client.GetAllClientDetails(_extraQueryParams);
                CClientListTBL.Columns[0].HeaderText = "ID";
                CClientListTBL.Columns[0].Visible = false;
                CClientListTBL.Columns[1].HeaderText = "NAME";
                CClientListTBL.Columns[2].HeaderText = "LOCATION";
                CClientListTBL.Columns[3].HeaderText = "STATUS";
                CClientListTBL.Sort(CClientListTBL.Columns[1], ListSortDirection.Ascending);
                CActiveClientLBL.Text = Client.GetNumberOfActiveClients() + " active clients";
                CTotalClientLBL.Text = Client.GetNumberOfTotalClients() + " total clients";
                CListFormat();
                CClientListTBL.ClearSelection();
            }
            catch (Exception ex) {
                ShowErrorBox("Clients Management Module", ex.Message);
            }
        }

        private void CListFormat() {
            CClientListTBL.Columns[1].Width = (int)(CClientListTBL.Width * 0.3511);
            CClientListTBL.Columns[2].Width = (int)(CClientListTBL.Width * 0.4580);
            CClientListTBL.Columns[3].Width = (int)(CClientListTBL.Width * 0.1069);
        }

        private void CClientListTBL_DoubleClick(object sender, EventArgs e) {
            CViewDetailsBTN.PerformClick();
        }

        private void CViewDetailsBTN_Click(object sender, EventArgs e) {
            try {
                if (CClientListTBL.SelectedRows.Count == 0) {
                    RylMessageBox.ShowDialog("No client is selected.", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else {
                    var view = new ClientsView {
                        Cid = int.Parse(CClientListTBL.SelectedRows[0].Cells[0].Value.ToString()),
                        Reference = this,
                        Refer = _shadow
                    };
                    _shadow.Transparent();
                    _shadow.Form = view;
                    _shadow.ShowDialog();
                }
            }
            catch (Exception exception) {
                Console.WriteLine(exception);
            }
        }

        #endregion

        #region CMS - View All Search

        private void CViewAllSearchBX_Enter(object sender, EventArgs e) {
            if (CViewAllSearchBX.Text.Equals("Search or filter")) CViewAllSearchBX.Text = "";
            CViewAllSearchLine.Visible = true;
        }

        private void CViewAllSearchBX_Leave(object sender, EventArgs e) {
            if (CViewAllSearchBX.Text.Equals("")) CViewAllSearchBX.Text = "Search or filter";
            _extraQueryParams = "";
            CViewAllSearchLine.Visible = false;
            ClientsRefreshClientsList();
        }

        private void CViewAllSearchBX_TextChanged(object sender, EventArgs e) {
            var temp = CViewAllSearchBX.Text.Replace("'", string.Empty);
            const string kazoo = "name";

            if (CViewAllSearchBX.Text.Contains("\\")) temp = temp + "?";
            _extraQueryParams = " where (" + kazoo + " like '" + temp + "%' OR " + kazoo + " like '%" + temp +
                                "%' OR " + kazoo + " LIKe '%" + temp + "')";
            ClientsRefreshClientsList();
        }

        #endregion

        #endregion

        #region CMS - Summary

        public void ClientsLoadSummary() {
            try {
                CCurrentSummaryPNL.Location = new Point(
                    CSummaryPNL.Width / 2 - CCurrentSummaryPNL.Size.Width / 2, CCurrentSummaryPNL.Location.Y);

                CSummaryDateLBL.Text = DateTime.Now.ToString("dddd, MMMM dd yyyy");

                var d = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                                          "\\MSAMIS Reports"); //Assuming Test is your Folder
                var files = d.GetFiles("ClientsSummaryReport*.pdf")
                    .OrderByDescending(p => p.CreationTime); //Getting Text files]

                CSummaryFileLST.Items.Clear();
                foreach (var file in files) {
                    string[] row = {file.CreationTime.ToString("MMMM dd, yyyy"), file.FullName};
                    var listViewItem = new ListViewItem(row) {ImageIndex = 0};
                    CSummaryFileLST.Items.Add(listViewItem);
                }
                CSummaryErrorPNL.Visible = CSummaryFileLST.Items.Count == 0;
                CTotalActiveLBL.Text = Reports.GetTotalGuards('c', 't') + " clients";
                CTotalLBL.Text = Reports.GetTotalGuards('c', 'a') + " clients";
            }
            catch (Exception ex) {
                ShowErrorBox("Clients Report", ex.Message);
            }
        }

        private void CSummaryExport_Click(object sender, EventArgs e) {
            try {
                var view = new Exporting {
                    Refer = _shadow,
                    Main = this,
                    Mode = 'c'
                };
                _shadow.Transparent();
                _shadow.Form = view;
                _shadow.ShowDialog();
            }
            catch (Exception exception) {
                Console.WriteLine(exception);
            }
        }

        private void CSummaryPreview_Click(object sender, EventArgs e) {
            try {
                var view = new ReportsPreview {
                    Refer = _shadow,
                    Main = this,
                    Mode = 2
                };
                _shadow.Transparent();
                _shadow.Form = view;
                _shadow.ShowDialog();
            }
            catch (Exception exception) { Console.WriteLine(exception); }
        }

        private void CSummaryFileLST_DoubleClick(object sender, EventArgs e) {
            try {
                Process.Start(CSummaryFileLST.SelectedItems[0].SubItems[1].Text);
            }
            catch {
                RylMessageBox.ShowDialog("File not found \nThe file must have been moved or corrupted",
                    "File Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClientsLoadSummary();
            }
        }

        private void ClientsSummaryRightClick(string text) {
            RightClickStrip.Hide();
            if (text.Equals("Open")) {
                try {
                    Process.Start(CSummaryFileLST.SelectedItems[0].SubItems[1].Text);
                }
                catch {
                    RylMessageBox.ShowDialog("File not found \nThe file must have been moved or corrupted",
                        "File Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClientsLoadSummary();
                }
            }
            else if (text.Equals("Save to...")) {
                var savefile = new SaveFileDialog {
                    FileName = "ClientSummaryReport_" + CSummaryFileLST.SelectedItems[0].SubItems[0].Text,
                    Filter = "Portable Document Format (.pdf)|*.pdf"
                };
                try {
                    if (savefile.ShowDialog() == DialogResult.OK)
                        File.Copy(CSummaryFileLST.SelectedItems[0].SubItems[1].Text, savefile.FileName, true);
                }
                catch {
                    RylMessageBox.ShowDialog("File not found \nThe file must have been moved or corrupted",
                        "File Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClientsLoadSummary();
                }
            } else if (text.Equals("Print")) {
                var FileName = CSummaryFileLST.SelectedItems[0].SubItems[1].Text;
                try {
                    Reports.PrintPDF(FileName);
                }
                catch {
                    RylMessageBox.ShowDialog("File not found \nThe file must have been moved or corrupted",
                        "File Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else {
                if (RylMessageBox.ShowDialog(
                        "Are you sure you want to delete the report for this month? \nThis action cannot be undone.",
                        "Delete Report", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    try {
                        File.Delete(CSummaryFileLST.SelectedItems[0].SubItems[1].Text);
                        ClientsLoadSummary();
                    }
                    catch {
                        RylMessageBox.ShowDialog("File not found \nThe file must have been moved or corrupted",
                            "File Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ClientsLoadSummary();
                    }
                }
            }
        }

        private void CSummaryFileLST_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right)
                if (CSummaryFileLST.FocusedItem.Bounds.Contains(e.Location)) RightClickStrip.Show(Cursor.Position);
        }

        #endregion

        #endregion

        #region Schedules Management System

        #region SMS - Page Load and Side Panel

        public void SchedLoadPage() {
            SchedLoadSidePnl();

            SViewReqPNL.Visible = true;
            _scurrentBtn = SViewReqBTN;
            _scurrentPanel = SViewAssPNL;

            SViewReqBTN.PerformClick();
        }

        public void SchedLoadSidePnl() {
            try {
                if (Login.AccountType == 1)
                    SchedBTN.Text = !Scheduling.GetNumberOfClientRequests(Enumeration.RequestStatus.Pending).Equals("0")
                        ? Scheduling.GetNumberOfClientRequests(Enumeration.RequestStatus.Pending)
                        : SchedBTN.Text = string.Empty;
                else SchedBTN.Text = string.Empty;
                SClientRequestsLBL.Text = Scheduling.GetNumberOfClientRequests(Enumeration.RequestStatus.Pending) +
                                          " pending requests";
                SUnassignedGuardsLBL.Text = Scheduling.GetNumberOfUnassignedGuards() + " unsassigned guards";
                SAssignedGuardsLBL.Text = Scheduling.GetNumberOfAssignedGuards() + " assigned guards";

                switch (Login.AccountType) {
                    case 2:
                        SViewReqsAssBTN.Visible = true;
                        break;
                    case 1:
                        SViewReqsAssBTN.Visible = false;
                        break;
                    default:
                        SViewReqsAssBTN.Visible = true;
                        break;
                }
            }
            catch (Exception ex) {
                ShowErrorBox("Assignments and Duty Schedules Module - Laoding", ex.Message);
            }
        }

        private void SChangePanel(Panel newP, Button newBtn, bool req) {
            if (newP != _scurrentPanel) {
                newP.Show();
                _scurrentPanel.Hide();
                _scurrentBtn.Font = _defaultFont;
                newBtn.Font = _selectedFont;
                _scurrentBtn = newBtn;
                _scurrentPanel = newP;
                SViewReqsAssBTN.Visible = req;
                SViewAssHistoryBTN.Visible = !req && (SViewAssPNL.Visible || SGuardHistoryPNL.Visible);
            }
        }

        private void SViewReqBTN_Click(object sender, EventArgs e) {
            SChangePanel(SViewReqPNL, SViewReqBTN, Login.AccountType != 1);
            SchedLoadRequestsPage();
        }

        private void SViewAssBTN_Click(object sender, EventArgs e) {
            SChangePanel(SViewAssPNL, SViewAssBTN, false);
            SchedLoadAssignmentPage();
        }

        private void SDutyDetailsBTN_Click(object sender, EventArgs e) {
            SChangePanel(SDutyDetailsPNL, SDutyDetailsBTN, false);
            SchedLoadReport();
        }

        private void SViewReqAssBTN_Click(object sender, EventArgs e) {
            try {
                var view = new SchedRequestGuard {
                    Reference = this,
                    Refer = _shadow
                };

                _shadow.Transparent();
                _shadow.Form = view;
                _shadow.ShowDialog();
            }
            catch (Exception exception) { Console.WriteLine(exception); }
        }

        private void SViewReqDisBTN_Click(object sender, EventArgs e) {
            if (IsUnscheduled()) { 
                if (SViewAssSearchClientCMBX.SelectedIndex != 0) { 
                try {
                    var view = new SchedUnassignGuard {
                        Reference = this,
                        Cid = int.Parse(((ComboBoxItem) SViewAssSearchClientCMBX.SelectedItem).ItemID),
                        Refer = _shadow,
                        Guards = SViewAssGRD.SelectedRows
                    };
                    _shadow.Transparent();
                    _shadow.Form = view;
                    _shadow.ShowDialog();
                }
                catch (Exception exception) { Console.WriteLine(exception); }
                } else {
                    RylMessageBox.ShowDialog(
                    "You can't unassign guards from different clients \nPlease select a client and unassign the guards",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } else
                RylMessageBox.ShowDialog(
                    "You can't unassign a guard with an active assignment \nPlease dismiss the guards before unassigning them",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            try {
                LoadViewReqTable(Scheduling.GetRequests(SViewReqSearchTXTBX.Text, -1, SViewReqFilterCMBX.SelectedIndex,
                    "name", "name asc"));
            }
            catch (Exception ex) {
                ShowErrorBox("Clients Requests", ex.Message);
            }
        }

        private void SViewReqDTPK_ValueChanged(object sender, EventArgs e) {
            try {
                LoadViewReqTable(Scheduling.GetRequests(SViewReqSearchTXTBX.Text, -1, SViewReqFilterCMBX.SelectedIndex,
                    "name", "name asc", SViewReqDTPK.Value));
                _changeDate = true;
            }
            catch (Exception ex) {
                ShowErrorBox("Clients Requests", ex.Message);
            }
        }

        private void SViewReqResetDateBTN_Click(object sender, EventArgs e) {
            try {
                LoadViewReqTable(Scheduling.GetRequests("", -1, 0, "name", "name asc"));
                _changeDate = false;
            }
            catch (Exception ex) {
                ShowErrorBox("Clients Requests", ex.Message);
            }
        }

        private void SchedLoadRequestsPage() {
            SViewReqFilterCMBX.SelectedIndex = 0;
            SchedRefreshRequests();
        }

        public void SchedRefreshRequests() {
            try {
                LoadViewReqTable(Scheduling.GetRequests("", -1, SViewReqFilterCMBX.SelectedIndex, "name", "name asc"));
            }
            catch (Exception ex) {
                ShowErrorBox("Clients Requests", ex.Message);
            }
        }

        private void SViewReqSearchTXTBX_TextChanged(object sender, EventArgs e) {
            try {
                if (_changeDate)
                    LoadViewReqTable(Scheduling.GetRequests(SViewReqSearchTXTBX.Text, -1,
                        SViewReqFilterCMBX.SelectedIndex,
                        "name", "name asc", SViewReqDTPK.Value));
                else
                    LoadViewReqTable(Scheduling.GetRequests(SViewReqSearchTXTBX.Text, -1,
                        SViewReqFilterCMBX.SelectedIndex,
                        "name", "name asc"));
            }
            catch (Exception ex) {
                ShowErrorBox("Clients Requests", ex.Message);
            }
        }

        private void LoadViewReqTable(DataTable dv) {
            SViewReqGRD.DataSource = dv;
            SViewReqGRD.Columns[0].Visible = false;
            SViewReqGRD.Columns[1].HeaderText = "REQUESTED BY";
            SViewReqGRD.Columns[2].HeaderText = "DATE ENTRY";
            SViewReqGRD.Columns[3].HeaderText = "TYPE";
            SViewReqGRD.Columns[4].HeaderText = "STATUS";

            SchedViewRequestFormat();

            SViewReqGRD.Sort(SViewReqGRD.Columns[0], ListSortDirection.Descending);

            SViewReqGRD.ClearSelection();
        }

        private void SchedViewRequestFormat() {
            SViewReqGRD.Columns[1].Width = (int)(SViewReqGRD.Width * 0.3817);
            SViewReqGRD.Columns[2].Width = (int)(SViewReqGRD.Width * 0.1832);
            SViewReqGRD.Columns[3].Width = (int)(SViewReqGRD.Width * 0.1832);
            SViewReqGRD.Columns[4].Width = (int)(SViewReqGRD.Width * 0.1527);

        }

        private void SViewReqSearchTXTBX_Enter(object sender, EventArgs e) {
            if (SViewReqSearchTXTBX.Text == FilterText) {
                SViewReqSearchTXTBX.Text = string.Empty;
                _extraQueryParams = string.Empty;
            }
            SViewReqSearchLine.Visible = true;
        }

        private void SViewReqSearchTXTBX_Leave(object sender, EventArgs e) {
            if (SViewReqSearchTXTBX.Text == string.Empty) {
                SViewReqSearchTXTBX.Text = FilterText;
                _extraQueryParams = string.Empty;
            }
            SchedRefreshRequests();
            SViewReqSearchLine.Visible = false;
        }

        private void SViewReqViewBTN_Click(object sender, EventArgs e) {
            try {
                if (SViewReqGRD.SelectedRows[0].Cells[3].Value.ToString().Equals("Assignment"))
                    try {
                        var view = new SchedViewAssReq {
                            Reference = this,
                            Raid = _rid,
                            Refer = _shadow
                        };
                        _shadow.Transparent();
                        _shadow.Form = view;
                        _shadow.ShowDialog();
                    }
                    catch (Exception exception) { Console.WriteLine(exception); }
                else
                    try {
                        var view = new SchedViewDisReq {
                            Reference = this,
                            Rid = _rid,
                            Refer = _shadow
                        };
                        _shadow.Transparent();
                        _shadow.Form = view;
                        _shadow.ShowDialog();
                    }
                    catch (Exception exception) { Console.WriteLine(exception); }
            }
            catch (Exception exception){ Console.WriteLine(exception); }
        }

        #endregion

        #region SMS - View Assignment

        private void SchedLoadAssignmentPage() {
            try {
                SViewAssSearchClientCMBX.Items.Clear();
                SViewAssSearchClientCMBX.Items.Add(new ComboBoxItem("All", "-1"));
                SViewAssSearchClientCMBX.SelectedIndex = 0;
                SViewAssCMBX.SelectedIndex = 0;

                var dv = Client.GetClients().DefaultView;
                dv.Sort = "name asc";
                var dt = dv.ToTable();

                for (var i = 0; i < dt.Rows.Count; i++)
                    SViewAssSearchClientCMBX.Items.Add(
                        new ComboBoxItem(dt.Rows[i][1].ToString(), dt.Rows[i][0].ToString()));
            }
            catch (Exception ex) {
                ShowErrorBox("Loading Clients", ex.Message);
            }
        }

        private void SViewAssGRD_DoubleClick(object sender, EventArgs e) {
            if (SViewAssViewDetailsBTN.Visible) SViewAssViewDetailsBTN.PerformClick();
        }

        private void SViewAssSearchClientCMBX_SelectedValueChanged(object sender, EventArgs e) {
            SViewAssCMBX.SelectedIndex = 0;
            if (Login.AccountType != 2) SViewAssUnassignBTN.Visible = true;
            else {
                SViewAssUnassignBTN.Visible = false;
            }
            SchedRefreshAssignments();

            if (SViewAssGRD.Rows.Count == 0) {
                SViewAssignmentErrorPNL.Visible = true;
                SViewAssignmentErrorPNL.BringToFront();
            }
            else {
                SViewAssignmentErrorPNL.Visible = false;
            }
        }

        public void SchedRefreshAssignments() {
            try {
                SViewAssGRD.DataSource =
                    Scheduling.GetAssignmentsByClient(
                        int.Parse(((ComboBoxItem) SViewAssSearchClientCMBX.SelectedItem).ItemID),
                        SViewAssCMBX.SelectedIndex, _extraQueryParams);

                if (SViewAssGRD.Rows.Count > 0) {
                    SViewAssGRD.Columns[0].Visible = false;
                    SViewAssGRD.Columns[1].Visible = false;
                    SViewAssGRD.Columns[2].Visible = false;
                    SViewAssGRD.Columns[3].HeaderText = "NAME";

                    SViewAssGRD.Columns[4].HeaderText = "ASSIGNMENT LOCATION";
                    SViewAssGRD.Columns[5].HeaderText = "ASSIGNED TO";

                    SViewAssGRD.Columns[4].Visible = SViewAssSearchClientCMBX.SelectedIndex != 0;
                    SViewAssGRD.Columns[5].Visible = SViewAssSearchClientCMBX.SelectedIndex == 0;

                    SViewAssGRD.Columns[6].HeaderText = "SCHEDULE";
                    SViewAssGRD.Columns[7].Visible = false;

                    SchedRefreshAssignmentLayout();

                    SViewAssGRD.Sort(SViewAssGRD.Columns[3], ListSortDirection.Ascending);
                    SViewAssGRD.ClearSelection();
                }
            }
            catch (Exception ex) {
                ShowErrorBox("Loading Assignments", ex.Message);
            }
        }

        private void SchedRefreshAssignmentLayout() {
            SViewAssGRD.Columns[3].Width = (int)(SViewAssGRD.Width * 0.355);
            SViewAssGRD.Columns[4].Width = (int)(SViewAssGRD.Width * 0.4275);
            SViewAssGRD.Columns[5].Width = (int)(SViewAssGRD.Width * 0.4275);
            SViewAssGRD.Columns[6].Width = (int)(SViewAssGRD.Width * 0.1527);
            SViewAssGRD.Columns[6].Width = (int)(SViewAssGRD.Width * 0.1527); 
        }

        private void SViewAssSearchTXTBX_TextChanged(object sender, EventArgs e) {
            var temp = SViewAssSearchTXTBX.Text.Replace("'", string.Empty);
            var kazoo = "concat(ln,', ',fn,' ',mn)";

            if (SViewAssSearchTXTBX.Text.Contains("\\")) temp = temp + "?";
            _extraQueryParams = " AND (" + kazoo + " like '" + temp + "%' OR " + kazoo + " like '%" + temp +
                                "%' OR " + kazoo + " LIKe '%" + temp + "')";
            SchedRefreshAssignments();
        }

        private void SViewAssCMBX_SelectedIndexChanged(object sender, EventArgs e) {
            SchedRefreshAssignments();
        }

        private void SViewAssGRD_CellEnter(object sender, DataGridViewCellEventArgs e) {
            if (SViewAssGRD.SelectedRows.Count == 1) {
                if (SViewAssGRD.SelectedRows[0].Cells[6].Value.ToString().Equals("Scheduled")) {
                    SViewAssViewDetailsBTN.Visible = true;
                    SViewAssUnassignBTN.Visible = false;
                } else if (SViewAssGRD.SelectedRows[0].Cells[6].Value.ToString().Equals("Unscheduled")) {
                    SViewAssViewDetailsBTN.Visible = true;
                    if (Login.AccountType != 2 && SViewAssSearchClientCMBX.SelectedIndex != 0)
                        SViewAssUnassignBTN.Visible = true;
                }
            } else if (SViewAssGRD.SelectedRows.Count > 1 && IsUnscheduled()) {
                SViewAssViewDetailsBTN.Visible = false;
                if (Login.AccountType != 2 && SViewAssSearchClientCMBX.SelectedIndex != 0)
                    SViewAssUnassignBTN.Visible = true;
            } else {
                SViewAssViewDetailsBTN.Visible = false;
                SViewAssUnassignBTN.Visible = false;
            }
        }

        private void SViewAssSearchTXTBX_Enter(object sender, EventArgs e) {
            if (SViewAssSearchTXTBX.Text == FilterText) {
                SViewAssSearchTXTBX.Text = string.Empty;
                _extraQueryParams = string.Empty;
            }
            SViewAssSearchLine.Visible = true;
        }

        private void SViewAssSearchTXTBX_Leave(object sender, EventArgs e) {
            if (SViewAssSearchTXTBX.Text == string.Empty) {
                SViewAssSearchTXTBX.Text = FilterText;
                _extraQueryParams = string.Empty;
            }
            SchedRefreshAssignments();
            SViewAssSearchLine.Visible = false;
        }

        private void SViewAssViewDetailsBTN_Click(object sender, EventArgs e) {
            if (SViewAssGRD.SelectedRows.Count > 1)
                RylMessageBox.ShowDialog("More than one assignment is selected", "Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
                try {
                    var view = new SchedViewDutyDetails {
                        Reference = this,
                        Refer = _shadow,
                        Aid = int.Parse(SViewAssGRD.SelectedRows[0].Cells[2].Value.ToString()),
                        Gid = int.Parse(SViewAssGRD.SelectedRows[0].Cells[0].Value.ToString())
                    };
                    _shadow.Transparent();
                    _shadow.Form = view;
                    _shadow.ShowDialog();
                }
                catch (Exception exception) { Console.WriteLine(exception); }
        }

        private bool IsUnscheduled() {
            //Method to check if the selected Guards are ready to be dismissed

            var ret = true;
            foreach (DataGridViewRow row in SViewAssGRD.SelectedRows)
                if (!row.Cells[6].Value.ToString().Equals("Unscheduled")) ret = false;
            return ret;
        }

        #endregion

        #region SMS - Guards History

        private void SViewAssHistoryBTN_Click(object sender, EventArgs e) {
            SChangePanel(SGuardHistoryPNL, SViewAssHistoryBTN, false);
            SchedLoadGuardHistory();
        }

        private void SchedLoadGuardHistory() {
            try {
                SGuardHistoryGRD.DataSource = Scheduling.GetGuardsWithAssignment(_extraQueryParams);
                SGuardHistoryGRD.Columns[0].Visible = false;
                SGuardHistoryGRD.Columns[1].Visible = false;
                SGuardHistoryGRD.Columns[2].Visible = false;
                SGuardHistoryGRD.Columns[3].HeaderText = "NAME";
                SGuardHistoryGRD.Columns[4].Visible = false;
                SGuardHistoryGRD.Columns[5].Visible = false;
                SGuardHistoryGRD.Columns[6].Visible = false;
                SchedGuardHistoryFormat();
                SGuardHistoryGRD.Columns[9].HeaderText = "STATUS";
                SGuardHistoryGRD.Sort(SGuardHistoryGRD.Columns[3], ListSortDirection.Ascending);
                SGuardHistoryGRD.ClearSelection();
            }
            catch (Exception ex) {
                ShowErrorBox("Assignment History", ex.Message);
            }
        }

        private void SchedGuardHistoryFormat() {
            SGuardHistoryGRD.Columns[3].Width = (int)(SGuardHistoryGRD.Width * 0.3817);
            SGuardHistoryGRD.Columns[4].Width = (int)(SGuardHistoryGRD.Width * 0.4275);
            SGuardHistoryGRD.Columns[5].Width = (int)(SGuardHistoryGRD.Width * 0.1527);
            SGuardHistoryGRD.Columns[5].Width = (int)(SGuardHistoryGRD.Width * 0.1527);
            SGuardHistoryGRD.Columns[6].Width = (int)(SGuardHistoryGRD.Width * 0.1527);
            SGuardHistoryGRD.Columns[7].Width = (int)(SGuardHistoryGRD.Width * 0.1985);
            SGuardHistoryGRD.Columns[8].Width = (int)(SGuardHistoryGRD.Width * 0.1985);
            SGuardHistoryGRD.Columns[9].Width = (int)(SGuardHistoryGRD.Width * 0.1527);
        }

        private void SGuardHistorySearchBX_Enter(object sender, EventArgs e) {
            if (SGuardHistorySearchBX.Text == FilterText) {
                SGuardHistorySearchBX.Text = string.Empty;
                _extraQueryParams = string.Empty;
            }
            SGuardHistorySearchLine.Visible = true;
        }

        private void SGuardHistorySearchBX_Leave(object sender, EventArgs e) {
            if (SGuardHistorySearchBX.Text == string.Empty) {
                SGuardHistorySearchBX.Text = FilterText;
                _extraQueryParams = string.Empty;
            }
            SchedLoadGuardHistory();
            SGuardHistorySearchLine.Visible = false;
        }

        private void SGuardHistorySearchBX_TextChanged(object sender, EventArgs e) {
            var temp = SGuardHistorySearchBX.Text.Replace("'", string.Empty);
            var kazoo = "concat(ln,', ',fn,' ',mn)";

            if (SGuardHistorySearchBX.Text.Contains("\\")) temp = temp + "?";
            _extraQueryParams = " AND (" + kazoo + " like '" + temp + "%' OR " + kazoo + " like '%" + temp +
                                "%' OR " + kazoo + " LIKe '%" + temp + "')";
            SchedLoadGuardHistory();
        }

        private void SGuardHistoryViewBTN_Click(object sender, EventArgs e) {
            var view = new SchedViewAssHistory {
                Refer = _shadow,
                Gid = int.Parse(SGuardHistoryGRD.SelectedRows[0].Cells[0].Value.ToString()),
                GuardName = SGuardHistoryGRD.SelectedRows[0].Cells[3].Value.ToString()
            };
            _shadow.Transparent();
            _shadow.Form = view;
            _shadow.ShowDialog();
        }

        private void SGuardHistoryGRD_DoubleClick(object sender, EventArgs e) {
            SGuardHistoryViewBTN.PerformClick();
        }

        #endregion

        #region SMS - Reports

        public void SchedLoadReport() {
            try {
                SDutyReportPNL.Location = new Point(
                    SDutyDetailsPNL.Width / 2 - SDutyReportPNL.Size.Width / 2, SDutyReportPNL.Location.Y);

                var d = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                                          "\\MSAMIS Reports"); //Assuming Test is your Folder
                var files = d.GetFiles("SchedSummaryReport*.pdf")
                    .OrderByDescending(p => p.CreationTime); //Getting Text files]
                SSummaryFilesLST.Items.Clear();
                foreach (var file in files) {
                    var date = file.CreationTime.AddMonths(-1);
                    string[] row = {date.ToString("MMMM yyyy"), file.FullName};
                    var listViewItem = new ListViewItem(row) {ImageIndex = 0};
                    SSummaryFilesLST.Items.Add(listViewItem);
                }
                SSummaryErrorPNL.Visible = SSummaryFilesLST.Items.Count == 0;
                SSummaryDateLBL.Text = SSummaryFilesLST.Items.Count > 0
                    ? "for the month of " + SSummaryFilesLST.Items[0].Text
                    : "No reports available. This report is automatically generated.";
                SDutyDetailsExportBTN.Visible = SDutyDetailsPreviewBTN.Visible = SDutyDetailsPrintBTN.Visible = SSummaryFilesLST.Items.Count > 0;
            }
            catch (Exception ex) {
                ShowErrorBox("Duty Details Summary Report", ex.Message);
            }
        }

        private void SDutyDetailsPrintBTN_Click(object sender, EventArgs e) {
            if (SSummaryFilesLST.Items.Count > 0) {
                var FileName = SSummaryFilesLST.Items[0].SubItems[1].Text;
                try {
                    Reports.PrintPDF(FileName);
                }
                catch {
                    RylMessageBox.ShowDialog("File not found \nThe file must have been moved or corrupted",
                        "File Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SDutyDetailsPreviewBTN_Click(object sender, EventArgs e) {
            try {
                Process.Start(SSummaryFilesLST.Items[0].SubItems[1].Text);
            }
            catch {
                RylMessageBox.ShowDialog("File not found \nThe file must have been moved or corrupted",
                    "File Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SchedLoadReport();
            }
        }

        private void SDutyDetailsExportBTN_Click(object sender, EventArgs e) {
            try {
                var savefile = new SaveFileDialog {
                    FileName = "SchedSummaryReport_" + SSummaryFilesLST.Items[0].SubItems[0].Text,
                    Filter = "Portable Document Format (.pdf)|*.pdf"
                };
                if (savefile.ShowDialog() == DialogResult.OK)
                    File.Copy(SSummaryFilesLST.Items[0].SubItems[1].Text, savefile.FileName, true);
            }
            catch (Exception exception) {
                RylMessageBox.ShowDialog("File not found \nThe file must have been moved or corrupted",
                    "File Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(exception);
            }
        }


        private void SSummaryFilesLST_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right)
                if (SSummaryFilesLST.FocusedItem.Bounds.Contains(e.Location)) RightClickStrip.Show(Cursor.Position);
        }

        private void SchedSummaryRightClick(string text) {
            RightClickStrip.Hide();
            if (text.Equals("Open")) {
                try {
                    Process.Start(SSummaryFilesLST.SelectedItems[0].SubItems[1].Text);
                }
                catch {
                    RylMessageBox.ShowDialog("File not found \nThe file must have been moved or corrupted",
                        "File Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SchedLoadReport();
                }
            }
            else if (text.Equals("Save to...")) {
                var savefile = new SaveFileDialog {
                    FileName = "SchedSummaryReport_" + SSummaryFilesLST.SelectedItems[0].SubItems[0].Text,
                    Filter = "Portable Document Format (.pdf)|*.pdf"
                };
                if (savefile.ShowDialog() == DialogResult.OK)
                    try {
                        File.Copy(SSummaryFilesLST.SelectedItems[0].SubItems[1].Text, savefile.FileName, true);
                    }
                    catch {
                        RylMessageBox.ShowDialog("File not found \nThe file must have been moved or corrupted",
                            "File Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            } else if (text.Equals("Print")) {
                var FileName = SSummaryFilesLST.SelectedItems[0].SubItems[1].Text;
                try {
                    Reports.PrintPDF(FileName);
                }
                catch {
                    RylMessageBox.ShowDialog("File not found \nThe file must have been moved or corrupted",
                        "File Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else {
                if (RylMessageBox.ShowDialog(
                        "Are you sure you want to delete the report for this month? \nThis action cannot be undone.",
                        "Delete Report", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    try {
                        File.Delete(SSummaryFilesLST.SelectedItems[0].SubItems[1].Text);
                        SchedLoadReport();
                    }
                    catch {
                        RylMessageBox.ShowDialog("File not found \nThe file must have been moved or corrupted",
                            "File Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void SSummaryFilesLST_DoubleClick(object sender, EventArgs e) {
            try {
                Process.Start(SSummaryFilesLST.SelectedItems[0].SubItems[1].Text);
            }
            catch {
                RylMessageBox.ShowDialog("File not found \nThe file must have been moved or corrupted",
                    "File Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SchedLoadReport();
            }
        }
        #endregion

        #endregion

        #region Payroll Management System

        #region PMS - Load/Side Panel

        private void PayLoadPage() {
            try {
                PayrollHideBtn();
                PEmpListBTN.PerformClick();

                PPeriodLBL.Text = "Period: " + new DateTime(Attendance.GetCurrentPayPeriod().year,
                                          Attendance.GetCurrentPayPeriod().month,
                                          Attendance.GetCurrentPayPeriod().period)
                                      .ToString("MM/yyyy, ");
                PPeriodLBL.Text += Attendance.GetCurrentPayPeriod().period == 1 ? "First" : "Second";
                PPayLBL.Text = "Next Pay: " + Payroll.GetNextPayday().ToString("MM/dd/yyyy");
                _scurrentPanel = PEmpListPage;
                _scurrentBtn = PEmpListBTN;
            }
            catch (Exception ex) {
                ShowErrorBox("Payroll Module", ex.Message);
            }
        }

        private void PayrollHideBtn() {
            switch (Login.AccountType) {
                case 1:
                    PConfHoliday.Visible = true;
                    PConfigSSSBTN.Visible = true;
                    break;
                case 2:
                    PConfHoliday.Visible = false;
                    PConfigSSSBTN.Visible = false;
                    break;
                default:
                    PConfHoliday.Visible = true;
                    PConfigSSSBTN.Visible = true;
                    break;
            }
        }

        private void PConfHoliday_Click(object sender, EventArgs e) {
            try {
                var view = new PayrollConfHolidays {
                    Refer = _shadow
                };


                _shadow.Transparent();
                _shadow.Form = view;
                _shadow.ShowDialog();
            }
            catch (Exception exception) { Console.WriteLine(exception); }
        }

        private void PConfigSSSBTN_Click(object sender, EventArgs e) {
            try {
                var view = new PayrollConfigRates {
                    Refer = _shadow
                };
                _shadow.Transparent();
                _shadow.Form = view;
                _shadow.ShowDialog();
            }
            catch (Exception exception) { Console.WriteLine(exception); }
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

        private void PSalaryReportBTN_Click(object sender, EventArgs e) {
            PcHnagePanel(PSalaryReportPage, PSalaryReportBTN);
            PayLoadReport();
        }

        #endregion

        #region PMS - Employee List 

        public void PayLoadEmployeeList() {
            PEmpListSortCMBX.SelectedIndex = 0;
            PayLoadTable();
        }

        private void PayLoadTable() {
            try {
                PEmpListGRD.DataSource =
                    Payroll.GetGuardsPayrollMain(_extraQueryParams, PEmpListSortCMBX.SelectedIndex - 1);
                PEmpListGRD.Columns[0].Visible = false;
                PEmpListGRD.Columns[1].HeaderText = "GUARD'S NAME";
                PEmpListGRD.Columns[2].HeaderText = "ASSIGNED TO";
                PEmpListGRD.Columns[3].HeaderText = "ATTENDANCE";
                PEmpListGRD.Columns[4].HeaderText = "STATUS";

                PayChnageSize();

                PEmpListGRD.Sort(PEmpListGRD.Columns[1], ListSortDirection.Ascending);
                PEmpListViewBTN.Visible = false;
            }
            catch (Exception ex) {
                ShowErrorBox("Guards List", ex.Message);
            }
        }

        private void PayChnageSize() {
            PEmpListGRD.Columns[1].Width = (int)(PEmpListGRD.Size.Width * 0.30);
            PEmpListGRD.Columns[2].Width = (int)(PEmpListGRD.Size.Width * 0.275);
            PEmpListGRD.Columns[3].Width = (int)(PEmpListGRD.Size.Width * 0.198);
            PEmpListGRD.Columns[4].Width = (int)(PEmpListGRD.Size.Width * 0.137);
        }

        private void PEmpListSearchBX_TextChanged(object sender, EventArgs e) {
            var temp = PEmpListSearchBX.Text.Replace("'", string.Empty);
            var kazoo = "concat(ln,', ',fn,' ',mn)";

            if (PEmpListSearchBX.Text.Contains("\\")) temp = temp + "?";
            _extraQueryParams = " AND (" + kazoo + " like '" + temp + "%' OR " + kazoo + " like '%" + temp +
                                "%' OR " + kazoo + " LIKe '%" + temp + "')";
            PayLoadTable();
        }

        private void PEmpListGRD_CellEnter(object sender, DataGridViewCellEventArgs e) {
            if (PEmpListGRD.SelectedRows.Count == 1) {
                PEmpListViewBTN.Visible = true;
                PEmpListPrintBTN.Visible = PEmpListGRD.SelectedRows[0].Cells[4].Value.ToString().Equals("Approved");
            }
            else if (PayIsApproved() && PEmpListGRD.SelectedRows.Count > 1) {
                PEmpListViewBTN.Visible = false;
                PEmpListPrintBTN.Visible = true;
            }
            else {
                PEmpListViewBTN.Visible = false;
                PEmpListPrintBTN.Visible = false;
            }
        }

        private bool PayIsApproved() {
            var ret = true;
            foreach (DataGridViewRow row in PEmpListGRD.SelectedRows) {
                if (!row.Cells[4].Value.ToString().Equals("Approved")) ret = false;
            }
            return ret;
        }

        private void PEmpListGRD_DoubleClick(object sender, EventArgs e) {
            PEmpListViewBTN.PerformClick();
        }

        private void PEmpListViewBTN_Click(object sender, EventArgs e) {
            try {
                var view = new PayrollEmployeeView {
                    Reference = this,
                    Refer = _shadow,
                    Gid = int.Parse(PEmpListGRD.SelectedRows[0].Cells[0].Value.ToString())
                };
                _shadow.Transparent();
                _shadow.Form = view;
                _shadow.ShowDialog();
            }
            catch (Exception exception) { Console.WriteLine(exception); }
        }

        private void PEmpListSearchBX_Enter(object sender, EventArgs e) {
            if (PEmpListSearchBX.Text == FilterText) {
                PEmpListSearchBX.Text = string.Empty;
                _extraQueryParams = string.Empty;
            }
            PEmpListSearchLine.Visible = true;
        }

        private void PEmpListSearchBX_Leave(object sender, EventArgs e) {
            if (PEmpListSearchBX.Text == string.Empty) {
                PEmpListSearchBX.Text = FilterText;
                _extraQueryParams = string.Empty;
            }
            PayLoadTable();
            PEmpListSearchLine.Visible = false;
        }

        private void PEmpListSortCMBX_SelectedIndexChanged(object sender, EventArgs e) {
            PayLoadTable();
        }

        #endregion

        #region PMS - View Reports

        private void PSalaryReportsPreviewBTN_Click(object sender, EventArgs e) {
            try {
                Process.Start(PSummaryFilesLST.Items[0].SubItems[1].Text);
            }
            catch {
                RylMessageBox.ShowDialog("File not found \nThe file must have been moved or corrupted",
                    "File Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PayLoadReport();
            }
        }

        private void PSalaryReportsExportBTN_Click(object sender, EventArgs e) {
            try {
                var savefile = new SaveFileDialog {
                    FileName = "PaySummaryReport_" + PSummaryFilesLST.Items[0].SubItems[0].Text,
                    Filter = "Portable Document Format (.pdf)|*.pdf"
                };
                if (savefile.ShowDialog() == DialogResult.OK)
                    File.Copy(PSummaryFilesLST.Items[0].SubItems[1].Text, savefile.FileName, true);
            }
            catch (Exception exception) {
                RylMessageBox.ShowDialog("File not found \nThe file must have been moved or corrupted",
                    "File Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(exception);
            }
        }

        public void PayLoadReport() {
            try {
                PayLoadReportLayout();
                var d = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                                          "\\MSAMIS Reports"); //Assuming Test is your Folder
                var files = d.GetFiles("SalaryReport*.pdf")
                    .OrderByDescending(p => p.CreationTime); //Getting Text files]

                PSummaryFilesLST.Items.Clear();
                foreach (var file in files) {
                    var date = file.CreationTime.AddMonths(-1);
                    string[] row = {date.ToString("MMMM yyyy"), file.FullName};
                    var listViewItem = new ListViewItem(row) {ImageIndex = 0};
                    PSummaryFilesLST.Items.Add(listViewItem);
                }
                PSummaryFilesLST.Sorting = SortOrder.Descending;
                PSummaryErrorPNL.Visible = PSummaryFilesLST.Items.Count == 0;
                PSummaryDateLBL.Text = PSummaryFilesLST.Items.Count > 0
                    ? "for the month of " + PSummaryFilesLST.Items[0].Text
                    : "No reports available. This report is automatically generated.";
                  PSalaryReportsExportBTN.Visible = PSalaryReportsPreviewBTN.Visible = PSalaryReportsPrintBTN.Visible = PSummaryFilesLST.Items.Count > 0;
            }
            catch (Exception ex) {
                ShowErrorBox("Salary Report", ex.Message);
            }
        }

        private void PayLoadReportLayout() {
            PSalaryPanel.Location = new Point(
                PSalaryReportPage.Width / 2 - PSalaryPanel.Size.Width / 2, PSalaryPanel.Location.Y);

        }

        private void PSummaryFilesLST_DoubleClick(object sender, EventArgs e) {
            try {
                Process.Start(PSummaryFilesLST.SelectedItems[0].SubItems[1].Text);
            }
            catch {
                RylMessageBox.ShowDialog("File not found \nThe file must have been moved or corrupted",
                    "File Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PayLoadReport();
            }
        }

        private void PSummaryFilesLST_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right)
                if (PSummaryFilesLST.FocusedItem.Bounds.Contains(e.Location)) RightClickStrip.Show(Cursor.Position);
        }

        private void PSalaryReportsPrintBTN_Click(object sender, EventArgs e) {
            if (PSummaryFilesLST.Items.Count > 0) {
                var FileName = PSummaryFilesLST.Items[0].SubItems[1].Text;
                try {
                    Reports.PrintPDF(FileName);
                }
                catch {
                    RylMessageBox.ShowDialog("File not found \nThe file must have been moved or corrupted",
                        "File Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void PaySummaryRightClick(string text) {
            RightClickStrip.Hide();
            if (text.Equals("Open")) {
                try {
                    Process.Start(PSummaryFilesLST.SelectedItems[0].SubItems[1].Text);
                }
                catch {
                    RylMessageBox.ShowDialog("File not found \nThe file must have been moved or corrupted",
                        "File Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    PayLoadReport();
                }
            }
            else if (text.Equals("Save to...")) {
                var savefile = new SaveFileDialog {
                    FileName = "PaySummaryReport_" + PSummaryFilesLST.SelectedItems[0].SubItems[0].Text,
                    Filter = "Portable Document Format (.pdf)|*.pdf"
                };
                if (savefile.ShowDialog() == DialogResult.OK)
                    try {
                        File.Copy(PSummaryFilesLST.SelectedItems[0].SubItems[1].Text, savefile.FileName, true);
                    }
                    catch {
                        RylMessageBox.ShowDialog("File not found \nThe file must have been moved or corrupted",
                            "File Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            } else if (text.Equals("Print")) {
                var FileName = PSummaryFilesLST.SelectedItems[0].SubItems[1].Text;
                try {
                    Reports.PrintPDF(FileName);
                }
                catch {
                    RylMessageBox.ShowDialog("File not found \nThe file must have been moved or corrupted",
                        "File Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else {
                if (RylMessageBox.ShowDialog(
                        "Are you sure you want to delete the report for this month? \nThis action cannot be undone.",
                        "Delete Report", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    try {
                        File.Delete(PSummaryFilesLST.SelectedItems[0].SubItems[1].Text);
                        PayLoadReport();
                    }
                    catch {
                        RylMessageBox.ShowDialog("File not found \nThe file must have been moved or corrupted",
                            "File Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion

        #region PMS - Payslip Print
        private void PEmpListPrintBTN_Click(object sender, EventArgs e) {

        }
        #endregion

        #endregion


    }
}