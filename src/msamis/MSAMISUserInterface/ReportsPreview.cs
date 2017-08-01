using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace MSAMISUserInterface {
    public partial class ReportsPreview : Form {
        public Shadow Refer;
        public MainForm Main;
        public int Mode;

        public ReportsPreview() {
            InitializeComponent();
            Opacity = 0;
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            Close();
            Refer.Hide();
        }

        private void GuardsReport_Load(object sender, EventArgs e) {
            FadeTMR.Start();
            LoadTable();

            NameLBL.Text = Mode == 1 ? "Guards Summary" : "Client Summary";
        }

        private void FadeTMR_Tick(object sender, EventArgs e) {
            Opacity += 0.2;
            if (Opacity >= 1) FadeTMR.Stop();
        }

        private void GuardsReport_FormClosing(object sender, FormClosingEventArgs e) {
            Refer.Hide();
        }

        private void LoadTable() {
            TimeLBL.Text = DateTime.Now.ToString("dddd, MMMM dd yyyy");
            if (Mode == 1) {
                GReportGRD.DataSource = Reports.GetGuardsList();
                GReportGRD.Columns[0].HeaderText = "NAME";
                GReportGRD.Columns[1].HeaderText = "STATUS";
                GReportGRD.Columns[2].HeaderText = "CONTACT NUMBER";
                GReportGRD.Columns[3].HeaderText = "LICENSE NUMBER";
                GReportGRD.Columns[4].HeaderText = "SSS";
                GReportGRD.Columns[5].HeaderText = "TIN NO";
                GReportGRD.Columns[6].HeaderText = "PHIC";

                #region Format Table

                GReportGRD.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GReportGRD.Columns[0].Width = 260;
                GReportGRD.Columns[1].Width = 70;
                GReportGRD.Columns[2].Width = 140;

                GReportGRD.Sort(GReportGRD.Columns[1], ListSortDirection.Ascending);

                #endregion
            }
            else {
                GReportGRD.DataSource = Reports.GetClientsList();

                GReportGRD.Columns[0].HeaderText = "NAME";
                GReportGRD.Columns[1].HeaderText = "STATUS";
                GReportGRD.Columns[2].HeaderText = "ADDRESS";
                GReportGRD.Columns[3].HeaderText = "MANAGER";
                GReportGRD.Columns[4].HeaderText = "CONTACT PERSON";
                GReportGRD.Columns[5].HeaderText = "CONTACT NUMBER";

                #region Format Table
                GReportGRD.Columns[0].Width = 200;
                GReportGRD.Columns[1].Width = 70;
                GReportGRD.Columns[2].Width = 250;
                GReportGRD.Columns[3].Width = 170;
                GReportGRD.Columns[4].Width = 170;
                GReportGRD.Columns[5].Width = 110;
                GReportGRD.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GReportGRD.Sort(GReportGRD.Columns[1], ListSortDirection.Ascending);
                #endregion
            }

        }

        private void button1_Click(object sender, EventArgs e) {
            if (Mode == 1) {
                var r = new Reports();
                r.ExporttoExcel('g');
                Main.GuardsLoadReport();
            }
            else {
                var r = new Reports();
                r.ExporttoExcel('c');
                Main.ClientsLoadSummary();
            }
        }
    }
}
