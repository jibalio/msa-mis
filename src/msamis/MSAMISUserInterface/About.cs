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
    public partial class About : Form {
        public String UN { get; set; }
        public MainForm reference;
        public MySqlConnection conn;
        public Shadow refer;

        Color chose = Color.FromArgb(53, 64, 82);
        Color def = Color.Gray;
        public About() {
            InitializeComponent();
            this.Opacity = 0;
        }

        Label currentLBL;
        Panel currentPNL;
        private void About_Load(object sender, EventArgs e) {
            FadeTMR.Start();
            currentLBL = AboutLBL;
            currentPNL = AboutPNL;
            
            UsersPNL.Visible = false;
        }

        private void About_FormClosing(object sender, FormClosingEventArgs e) {
            refer.Hide();
        }

        private void FadeTMR_Tick(object sender, EventArgs e) {
            this.Opacity += 0.2;
            if (this.Opacity >= 1) { FadeTMR.Stop(); }
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            this.Close();
            refer.Hide();
        }

        private void ChangePanel(Label newL, Panel newP) {
            currentLBL.ForeColor = def;
            currentPNL.Visible = false;
            newL.ForeColor = chose;
            newP.Visible = true;
            currentLBL = newL;
            currentPNL = newP;
        }

        private void AboutLBL_Click(object sender, EventArgs e) {
            ChangePanel(AboutLBL, AboutPNL);
        }

        private void UsersLBL_Click(object sender, EventArgs e) {
            ChangePanel(UsersLBL, UsersPNL);
        }

        private void UsersLBL_MouseEnter(object sender, EventArgs e) {
            UsersLBL.ForeColor = chose;
        }

        private void AboutLBL_MouseEnter(object sender, EventArgs e) {
            AboutLBL.ForeColor = chose;
        }

        private void AboutLBL_MouseLeave(object sender, EventArgs e) {
            if (!AboutPNL.Visible) AboutLBL.ForeColor = def;
        }

        private void UsersLBL_MouseLeave(object sender, EventArgs e) {
            if (!UsersPNL.Visible) UsersLBL.ForeColor = def;
        }

        private void About_FormClosed(object sender, FormClosedEventArgs e) {
            
        }
    }
}
