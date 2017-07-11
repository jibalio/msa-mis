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
    public partial class Sched_ConfHolidays : Form {
        public Sched_ViewDutyDetails reference;
        public MySqlConnection conn;

        #region Form Properties and Load
        public Sched_ConfHolidays() {
            InitializeComponent();
            this.Opacity = 0;
        }

        private void Sched_ConfHolidays_Load(object sender, EventArgs e) {
            LoadPage();
            FadeTMR.Start();


            DateTime[] dts = new DateTime[2];

            dts[0] = new DateTime(2017,07,12);
            dts[1] = new DateTime(2017, 07, 13);

            HoldaysCLNDR.BoldedDates = dts;
        }

        private void FadeTMR_Tick(object sender, EventArgs e) {
            this.Opacity += 0.2;
            if (this.Opacity >= 1) FadeTMR.Stop();
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            this.Close();
        }
        private void LoadPage() {
        }
        #endregion

        private void HoldaysCLNDR_DateSelected(object sender, DateRangeEventArgs e) {
            if (HoldaysCLNDR.SelectionRange.Start.Day - HoldaysCLNDR.SelectionRange.End.Day != 0) DateLBL.Text = HoldaysCLNDR.SelectionRange.Start.ToShortDateString() + " - " + HoldaysCLNDR.SelectionRange.End.ToShortDateString();
            else DateLBL.Text = HoldaysCLNDR.SelectionRange.Start.ToShortDateString();
        }
    }
}
