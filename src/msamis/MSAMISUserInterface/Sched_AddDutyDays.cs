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
    public partial class Sched_AddDutyDays : Form {
        public MainForm reference;
        public MySqlConnection conn;
        public String button = "ADD";
        public int AID { get; set; }
        public String GName;
        public String Client;

        public Sched_AddDutyDays() {
            InitializeComponent();
            this.Opacity = 0;
        }

        private void SAddDutyDays_Load(object sender, EventArgs e) {
            LoadPage();
            FadeTMR.Start();
        }

        private void LoadPage() {
            NameLBL.Text = Name;
            ClientLBL.Text = Client;

        }

        private void SAddDutyDays_FormClosing(object sender, FormClosingEventArgs e) {
        }

        private void FadeTMR_Tick(object sender, EventArgs e) {
            this.Opacity += 0.2;
            if (reference.Opacity == 0.6 || this.Opacity >= 1) { FadeTMR.Stop(); }
            if (reference.Opacity > 0.7) { reference.Opacity -= 0.1; }
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
