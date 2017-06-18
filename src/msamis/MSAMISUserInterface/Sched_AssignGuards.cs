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
    public partial class Sched_AssignGuards : Form {
        public MySqlConnection conn;
        public int RID { get; set; }
        public Sched_AssignGuards() {
            InitializeComponent();
            this.Opacity = 0;
        }

        private void Sched_AssignGuards_Load(object sender, EventArgs e) {
            //LoadPage();
            FadeTMR.Start();
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void ConfirmBTN_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void FadeTMR_Tick(object sender, EventArgs e) {
            this.Opacity += 0.2;
            if (this.Opacity >= 1) { FadeTMR.Stop(); }
        }
    }
}
