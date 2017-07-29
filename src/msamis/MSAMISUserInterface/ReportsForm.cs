using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;
using Button = System.Windows.Forms.Button;
using DataTable = System.Data.DataTable;
using Font = System.Drawing.Font;
using Point = System.Drawing.Point;

namespace MSAMISUserInterface {
    public partial class ReportsForm : Form {
        public SqlConnection conn;
        private Font defaultFont = new Font("Segoe UI Semilight", 10);
        private string EmptyText = "";
        private string ExtraQueryParams = "";

        private string FilterText = "Search or filter";
        public LoginForm lf;
        private Point newFormLocation;
        private Button ScurrentBTN;

        private Panel ScurrentPanel;

        private Font selectedFont = new Font("Segoe UI Semibold", 10);
        private Shadow shadow = new Shadow();
        public string user;

        public ReportsForm() {
            InitializeComponent();
            RefreshGuardsSummaryList();
            RefreshClientsSummaryList();
        }


        private void label43_Click(object sender, EventArgs e) {
            ClientsReportPNL.Hide();
            GuardsReportPNL.Show();
        }

        private void label2_Click(object sender, EventArgs e) {
            GuardsReportPNL.Hide();
            ClientsReportPNL.Show();
        }

        #region SQL

        private DataTable GetGuardsList() {
            ExtraQueryParams = " ORDER BY ln asc";
            var q =
                "SELECT gid, concat(ln,', ',fn,' ',mn) AS 'Full Name', CASE WHEN GStatus = 1 THEN 'Active' WHEN GStatus = 2 THEN 'Inactive' END as Status, ' ' as 'Total Hours',  CellNo as 'Cell Number', LicenseNo as 'License Number', SSS, TIN, PhilHealth as PHIC FROM msadb.guards" +
                ExtraQueryParams;
            var dt = SQLTools.ExecuteQuery(q);
            foreach (DataRow dr in dt.Rows) {
                var e = new Payroll(int.Parse(dr["gid"].ToString()));
                e.ComputeHours();
                dr["Total Hours"] = e.TotalSummary["total"].hour.ToString(@":hh\:mm");
            }
            return dt;
        }

        private DataTable GetClientsList() {
            ExtraQueryParams = " ORDER BY Name asc";
            var q =
                "SELECT Name as 'Name', CASE WHEN CStatus = 1 THEN 'Active' WHEN CStatus = 2 THEN 'Inactive' END as Status, concat(ClientStreetNo,' ', ClientStreet, ', ', ClientBrgy, ', ', ClientCity) as Address, Manager, ContactPerson as 'Contact Person', ContactNo as 'Contact Number' FROM msadb.client" +
                ExtraQueryParams;
            return SQLTools.ExecuteQuery(q);
        }

        public void RefreshGuardsSummaryList() {
            GuardsSummaryTBL.DataSource = GetGuardsList();
            GuardsSummaryTBL.Columns["Full Name"].HeaderText = "NAME";
            GuardsSummaryTBL.Columns["Status"].HeaderText = "STATUS";
            GuardsSummaryTBL.Columns["Total Hours"].HeaderText = "TOTAL HOURS";
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
            GuardsSummaryTBL.Columns["gid"].Visible = false;

            GuardsSummaryTBL.Sort(GuardsSummaryTBL.Columns[1], ListSortDirection.Ascending);

            #endregion
        }

        public void RefreshClientsSummaryList() {
            ClientsSummaryTBL.DataSource = GetClientsList();

            ClientsSummaryTBL.Columns["Name"].HeaderText = "NAME";
            ClientsSummaryTBL.Columns["Status"].HeaderText = "STATUS";
            ClientsSummaryTBL.Columns["Address"].HeaderText = "ADDRESS";
            ClientsSummaryTBL.Columns["Manager"].HeaderText = "MANAGER";
            ClientsSummaryTBL.Columns["Contact Person"].HeaderText = "CONTACT PERSON";
            ClientsSummaryTBL.Columns["Contact Number"].HeaderText = "CONTACT NUMBER";

            #region Format Table

            ClientsSummaryTBL.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ClientsSummaryTBL.Sort(ClientsSummaryTBL.Columns[1], ListSortDirection.Ascending);

            #endregion
        }

        #endregion


        #region Export

        private void ExportGuardsSummaryBTN_Click(object sender, EventArgs e) {
            ShowExportDialog("g");
        }

        private void ExportClientsSummaryBTN_Click(object sender, EventArgs e) {
            ShowExportDialog("c");
        }


        private void ShowExportDialog(string formOrigin) {
            var savefile = new SaveFileDialog();
            savefile.FileName = "Book1";
            savefile.Filter = "Excel Workbook (.xlsx)|*.xlsx|Excel 97-2003 Template (.xls)|*.xls";

            if (savefile.ShowDialog() == DialogResult.OK) {
                var filePath = Path.GetDirectoryName(savefile.FileName);
                var fileName = Path.GetFileName(savefile.FileName);
                ExporttoExcel(filePath, fileName, formOrigin);
            }
        }

        private DataTable GetList(string formOrigin) {
            if (formOrigin == "g")
                return GetGuardsList();
            if (formOrigin == "c")
                return GetClientsList();
            return null;
        }

        private void ExporttoExcel(string FilePath, string FileName, string formOrigin) {
            var dtMainSQLData = GetList(formOrigin);
            if (formOrigin == "g")
                dtMainSQLData.Columns.Remove("gid");
            var dcCollection = dtMainSQLData.Columns;
            var ExcelApp = new Application();
            var ExcelWorkbook = ExcelApp.Application.Workbooks.Add(Type.Missing);
            var ExcelWorkSheet = (Worksheet) ExcelWorkbook.Worksheets.Item[1];


            for (var i = 1; i < dtMainSQLData.Rows.Count + 2; i++) {
                for (var j = 1; j < dtMainSQLData.Columns.Count + 1; j++)
                    if (i == 1)
                        ExcelApp.Cells[i, j] = dcCollection[j - 1].ToString();
                    else
                        ExcelApp.Cells[i, j] = dtMainSQLData.Rows[i - 2][j - 1].ToString();
                ExcelWorkSheet.Rows[i].rowheight = 19;
            }
            ExcelWorkSheet.Rows[1].rowheight = 23;
            ExcelWorkSheet.Cells[1, 1].EntireRow.Font.Size = 12;
            ExcelWorkSheet.Cells[1, 1].EntireRow.Font.Bold = true;
            ExcelWorkSheet.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            if (formOrigin == "g")
                FormatGuardsWorkSheet(ExcelWorkSheet);
            else if (formOrigin == "c")
                FormatClientsWorkSheet(ExcelWorkSheet);

            ExcelApp.ActiveWorkbook.SaveAs(FilePath + "\\" + FileName);
            ExcelApp.ActiveWorkbook.Saved = true;
            ExcelApp.Quit();
        }

        private void FormatGuardsWorkSheet(Worksheet ews) {
            ews.Columns[1].columnwidth = 35;
            ews.Columns[2].columnwidth = 10;
            ews.Columns[3].columnwidth = 18;
            ews.Columns[4].columnwidth = 17;
            ews.Columns[5].columnwidth = 14;
            ews.Columns[6].columnwidth = 13;
            ews.Columns[7].columnwidth = 16;
        }

        private void FormatClientsWorkSheet(Worksheet ews) {
            ews.Columns[1].columnwidth = 35;
            ews.Columns[2].columnwidth = 10;
            ews.Columns[3].columnwidth = 52;
            ews.Columns[4].columnwidth = 30;
            ews.Columns[5].columnwidth = 30;
            ews.Columns[6].columnwidth = 17;
        }

        #endregion
    }
}