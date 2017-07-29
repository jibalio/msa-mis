using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;

namespace MSAMISUserInterface
{
    public partial class ReportsForm : Form
    {
        public SqlConnection conn;
         
        public ReportsForm()
        {
            InitializeComponent();
            RefreshGuardsSummaryList();
            RefreshClientsSummaryList();
        }

        #region Guards Summary

        public void RefreshGuardsSummaryList()
        {
            GuardsSummaryTBL.DataSource = Reports.GetGuardsList();
            GuardsSummaryTBL.Columns["Full Name"].HeaderText = "NAME";
            GuardsSummaryTBL.Columns["Status"].HeaderText = "STATUS";
            GuardsSummaryTBL.Columns["Cell Number"].HeaderText = "CONTACT NUMBER";
            GuardsSummaryTBL.Columns["License Number"].HeaderText = "LICENSE NUMBER";
            GuardsSummaryTBL.Columns["SSS"].HeaderText = "SSS";
            GuardsSummaryTBL.Columns["TIN"].HeaderText = "TIN NO";
            GuardsSummaryTBL.Columns["PHIC"].HeaderText = "PHIC";

            #region Format Table
            GuardsSummaryTBL.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            GuardsSummaryTBL.Columns["Full Name"].Width = 200;
            GuardsSummaryTBL.Columns["Status"].Width = 70;
            GuardsSummaryTBL.Columns["Cell Number"].Width = 140;

            GuardsSummaryTBL.Sort(GuardsSummaryTBL.Columns[1], ListSortDirection.Ascending);
            #endregion
        }
        #endregion

        #region Clients Summary

        public void RefreshClientsSummaryList()
        {
            ClientsSummaryTBL.DataSource = Reports.GetClientsList();

            ClientsSummaryTBL.Columns["Name"].HeaderText = "NAME";
            ClientsSummaryTBL.Columns["Status"].HeaderText = "STATUS";
            ClientsSummaryTBL.Columns["Address"].HeaderText = "ADDRESS";
            ClientsSummaryTBL.Columns["Manager"].HeaderText = "MANAGER";
           ClientsSummaryTBL.Columns["Contact Person"].HeaderText = "CONTACT PERSON";
            ClientsSummaryTBL.Columns["Contact Number"].HeaderText = "CONTACT NUMBER";

            #region Format Table
            ClientsSummaryTBL.Columns["Name"].Width = 200;
            ClientsSummaryTBL.Columns["Status"].Width = 70;
            ClientsSummaryTBL.Columns["Address"].Width = 250;
            ClientsSummaryTBL.Columns["Manager"].Width = 170;
            ClientsSummaryTBL.Columns["Contact Person"].Width = 170;
            ClientsSummaryTBL.Columns["Contact Number"].Width = 110;
            ClientsSummaryTBL.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ClientsSummaryTBL.Sort(ClientsSummaryTBL.Columns[1], ListSortDirection.Ascending);
            #endregion

        }

        #endregion

        #region FormEvents

        private void ExportGuardsSummaryBTN_Click(object sender, EventArgs e)
        {
            Reports r = new Reports();
            r.ShowExportDialog('g');
        }

        private void ExportClientsSummaryBTN_Click(object sender, EventArgs e)
        {
            Reports r = new Reports();
            r.ShowExportDialog('c');
        }

        private void label43_Click(object sender, EventArgs e)
        {
            this.ClientsReportPNL.Hide();
            this.GuardsReportPNL.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.GuardsReportPNL.Hide();
            this.ClientsReportPNL.Show();
        }

        private void ReportsForm_Load (object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            now.ToString("MM/dd/yyyy");

        }

        #endregion
    }
}