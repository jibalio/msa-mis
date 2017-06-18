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
    public partial class Sched_ViewAssReq : Form {
        public int RID { get; set; }
        public MainForm reference;
        public MySqlConnection conn;

        public Sched_ViewAssReq() {
            InitializeComponent();
            this.Opacity = 0;
        }

        private void FadeTMR_Tick(object sender, EventArgs e) {
            this.Opacity += 0.2;
            if (reference.Opacity == 0.6 || this.Opacity >= 1) { FadeTMR.Stop(); }
            if (reference.Opacity > 0.7) { reference.Opacity -= 0.1; }
        }

        private void Sched_ViewAssReq_Load(object sender, EventArgs e) {
            //RefreshData();
            FadeTMR.Start();
        }

        private void Sched_ViewAssReq_FormClosing(object sender, FormClosingEventArgs e) {
            reference.Opacity = 1;
            reference.Show();
        }

        private void button1_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void AssignBTN_Click(object sender, EventArgs e) {
            if (AssignBTN.Text.Equals("ASSIGN")) {
                try {
                    Sched_AssignGuards view = new Sched_AssignGuards();
                    view.conn = this.conn;
                    view.Location = this.Location;
                    view.ShowDialog();
                }
                catch (Exception) { }
            }
        }
    }
}
