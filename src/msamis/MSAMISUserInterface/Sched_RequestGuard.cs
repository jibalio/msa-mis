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
    public partial class Sched_RequestGuard : Form {
        public MainForm reference;
        public MySqlConnection conn;


        public Sched_RequestGuard() {
            InitializeComponent();
            this.Opacity = 0;
        }

        private void Sched_RequestGuard_Load(object sender, EventArgs e) {
            LoadClients();
            FadeTMR.Start();
        }

        private void LoadClients() {

        }

        private void Sched_RequestGuard_FormClosing(object sender, FormClosingEventArgs e) {
            reference.Opacity = 1;
            reference.Show();
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void FadeTMR_Tick(object sender, EventArgs e) {
            this.Opacity += 0.2;
            if (reference.Opacity == 0.6 || this.Opacity >= 1) { FadeTMR.Stop(); }
            if (reference.Opacity > 0.7) { reference.Opacity -= 0.1; }
        }
    }
}
