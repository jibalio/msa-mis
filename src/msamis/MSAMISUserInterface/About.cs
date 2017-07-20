using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MSAMISUserInterface {
    public partial class About : Form {
        public string Username { get; set; }
        public MainForm Reference;
        public MySqlConnection Connection;
        public Shadow Refer;

        private readonly Color _chose = Color.FromArgb(53, 64, 82);
        private readonly Color _def = Color.Gray;
        private Label _currentLbl;
        private Panel _currentPnl;

        public About() {
            InitializeComponent();
            Opacity = 0;
        }


        private void About_Load(object sender, EventArgs e) {
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
            if (Opacity >= 1) { FadeTMR.Stop(); }
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

        private void About_FormClosed(object sender, FormClosedEventArgs e) {
            
        }
    }
}
