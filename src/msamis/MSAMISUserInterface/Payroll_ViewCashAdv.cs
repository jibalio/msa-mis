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
    public partial class Payroll_ViewCashAdv : Form {
        public int ARID { get; set; }
        public MainForm reference;
        public MySqlConnection conn;

        public Shadow refer;

        public Payroll_ViewCashAdv() {
            InitializeComponent();
            this.Opacity = 0;
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void Payroll_ViewCashAdv_Load(object sender, EventArgs e) {
            this.Location = new Point(this.Location.X + 175, this.Location.Y);
            FadeTMR.Start();
        }

        private void Payroll_ViewCashAdv_FormClosing(object sender, FormClosingEventArgs e) {
            refer.Hide();
        }

        private void FadeTMR_Tick(object sender, EventArgs e) {
            this.Opacity += 0.2;
            if (this.Opacity >= 1) { FadeTMR.Stop(); }
        }
    }
}
