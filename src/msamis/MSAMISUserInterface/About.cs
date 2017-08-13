using System;
using System.Drawing;
using System.Windows.Forms;

namespace MSAMISUserInterface {
    public partial class About : Form {
        private readonly Color _chose = Color.FromArgb(53, 64, 82);
        private readonly Color _def = Color.Gray;
        private Label _currentLbl;
        private Panel _currentPnl;
        public Shadow Refer;

        public About() {
            InitializeComponent();
            Opacity = 0;
        }

        public string Username { get; set; }


        private void About_Load(object sender, EventArgs e) {
            Location = new Point(Location.X + 150, Location.Y);
            FadeTMR.Start();
            _currentLbl = AboutLBL;
            _currentPnl = AboutPNL;

            UsersPNL.Visible = false;
        }

        private void About_FormClosing(object sender, FormClosingEventArgs e) {
            Refer.Hide();
        }

        private void FadeTMR_Tick(object sender, EventArgs e) {
            Opacity += 0.2;
            if (Opacity >= 1) FadeTMR.Stop();
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            Close();
            Refer.Hide();
        }

        private void ChangePanel(Label newL, Panel newP) {
            _currentLbl.ForeColor = _def;
            _currentPnl.Visible = false;
            newL.ForeColor = _chose;
            newP.Visible = true;
            _currentLbl = newL;
            _currentPnl = newP;
        }

        private void AboutLBL_Click(object sender, EventArgs e) {
            ChangePanel(AboutLBL, AboutPNL);
        }

        private void UsersLBL_Click(object sender, EventArgs e) {
            ChangePanel(UsersLBL, UsersPNL);
            LoadUsers();
        }

        private void UsersLBL_MouseEnter(object sender, EventArgs e) {
            UsersLBL.ForeColor = _chose;
        }

        private void AboutLBL_MouseEnter(object sender, EventArgs e) {
            AboutLBL.ForeColor = _chose;
        }

        private void AboutLBL_MouseLeave(object sender, EventArgs e) {
            if (!AboutPNL.Visible) AboutLBL.ForeColor = _def;
        }

        private void UsersLBL_MouseLeave(object sender, EventArgs e) {
            if (!UsersPNL.Visible) UsersLBL.ForeColor = _def;
        }

        private void About_FormClosed(object sender, FormClosedEventArgs e) { }

        private void LoadUsers() {
            UsersGRDPNL.Visible = true;
            UsersGRDPNL.BringToFront();
            UsersGRD.DataSource = Account.GetAccounts();
            UsersGRD.Columns[0].Visible = false;
            UsersGRD.Columns[1].HeaderText = "USERNAME";
            UsersGRD.Columns[1].Width = 150;
            UsersGRD.Columns[2].HeaderText = "ACCOUNT TYPE";
            UsersGRD.Columns[2].Width = 150;

        }

        private void EditBTN_Click(object sender, EventArgs e) {
            UsernameBX.Text = UsersGRD.SelectedRows[0].Cells[1].Value.ToString();
            CurrentBX.Clear();
            NewBX.Clear();
            UsersGRDPNL.Visible = false;
            EditUserPNL.Visible = true;
            CloseBTN.Visible = false;
        }

        private void SaveBTN_Click(object sender, EventArgs e) {
            CancelBTN.PerformClick();
        }

        private void CancelBTN_Click(object sender, EventArgs e) {
            UsersGRDPNL.Visible = true;
            EditUserPNL.Visible = false;
            CloseBTN.Visible = true;
        }
    }
}