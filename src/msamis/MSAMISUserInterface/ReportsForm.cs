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
        public LoginForm lf;
        Point newFormLocation;
        Shadow shadow = new Shadow();

        Font selectedFont = new Font("Segoe UI Semibold", 10);
        Font defaultFont = new Font("Segoe UI Semilight", 10);

        Panel ScurrentPanel;
        Button ScurrentBTN;

        String FilterText = "Search or filter";
        String EmptyText = "";
        String ExtraQueryParams = "";
        public String user;
        public ReportsForm()
        {
            InitializeComponent();
            RefreshGuardsSummaryList();
            RefreshClientsSummaryList();
        }

        #region SQL

        

        private DataTable GetGuardsList()
        {
            ExtraQueryParams = " ORDER BY ln asc";
            String q = "SELECT concat(ln,', ',fn,' ',mn) AS 'Full Name', CASE WHEN GStatus = 1 THEN 'Active' WHEN GStatus = 2 THEN 'Inactive' END as Status, CellNo as 'Cell Number', LicenseNo as 'License Number', SSS, TIN, PhilHealth as PHIC FROM msadb.guards" + ExtraQueryParams;
            return SQLTools.ExecuteQuery(q);
        }

        private DataTable GetClientsList()
        {
            ExtraQueryParams = " ORDER BY Name asc";
            String q = "SELECT Name as 'Name', CASE WHEN CStatus = 1 THEN 'Active' WHEN CStatus = 2 THEN 'Inactive' END as Status, concat(ClientStreetNo,' ', ClientStreet, ', ', ClientBrgy, ', ', ClientCity) as Address, Manager, ContactPerson as 'Contact Person', ContactNo as 'Contact Number' FROM msadb.client" + ExtraQueryParams;
            return SQLTools.ExecuteQuery(q);
        }

        private DataTable GetGuardsID()
        {
            String q = "SELECT gid FROM msadb.guards";
            return SQLTools.ExecuteQuery(q);
        }

        public void RefreshGuardsSummaryList()
        {
            GuardsSummaryTBL.DataSource = GetGuardsList();

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

        public void RefreshClientsSummaryList()
        {
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

        private void ExportGuardsSummaryBTN_Click(object sender, EventArgs e)
        {
            ShowExportDialog("g");
        }

        private void ExportClientsSummaryBTN_Click(object sender, EventArgs e)
        {
            ShowExportDialog("c");
        }


        private void ShowExportDialog(string formOrigin)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = "Book1";
            savefile.Filter = "Excel Workbook (.xlsx)|*.xlsx|Excel 97-2003 Template (.xls)|*.xls";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                string filePath = System.IO.Path.GetDirectoryName(savefile.FileName);
                string fileName = System.IO.Path.GetFileName(savefile.FileName);
                ExporttoExcel(filePath, fileName, formOrigin);
            }
        }

        private DataTable GetList(String formOrigin)
        {
            if (formOrigin == "g")
                return GetGuardsList();
            else if (formOrigin == "c")
                return GetClientsList();
            else {
                return null;
            }
        }

        private void ExporttoExcel(String FilePath, String FileName, String formOrigin)
        {
            DataTable dtMainSQLData = GetList(formOrigin);
            DataColumnCollection dcCollection = dtMainSQLData.Columns;

            Excel.Application ExcelApp = new Excel.Application();
            var ExcelWorkbook = ExcelApp.Application.Workbooks.Add(Type.Missing);
            var ExcelWorkSheet = (Excel.Worksheet)ExcelWorkbook.Worksheets.Item[1];


            for (int i = 1; i < dtMainSQLData.Rows.Count + 2; i++)
            {
                for (int j = 1; j < dtMainSQLData.Columns.Count + 1; j++)
                {
                    if (i == 1)
                    {
                        ExcelApp.Cells[i, j] = dcCollection[j - 1].ToString();
                    }
                    else
                        ExcelApp.Cells[i, j] = dtMainSQLData.Rows[i - 2][j - 1].ToString();
                }
                ExcelWorkSheet.Rows[i].rowheight = 19;
            }
            ExcelWorkSheet.Rows[1].rowheight = 23;
            ExcelWorkSheet.Cells[1, 1].EntireRow.Font.Size = 12;
            ExcelWorkSheet.Cells[1, 1].EntireRow.Font.Bold = true;
            ExcelWorkSheet.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            if (formOrigin == "g")
                FormatGuardsWorkSheet(ExcelWorkSheet);
            else if (formOrigin == "c")
                FormatClientsWorkSheet(ExcelWorkSheet);

            ExcelApp.ActiveWorkbook.SaveAs(FilePath + "\\" + FileName);
            ExcelApp.ActiveWorkbook.Saved = true;
            ExcelApp.Quit();
        }

        private void FormatGuardsWorkSheet(Excel.Worksheet ews)
        {
            ews.Columns[1].columnwidth = 35;
            ews.Columns[2].columnwidth = 10;
            ews.Columns[3].columnwidth = 18;
            ews.Columns[4].columnwidth = 17;
            ews.Columns[5].columnwidth = 14;
            ews.Columns[6].columnwidth = 13;
            ews.Columns[7].columnwidth = 16;
        }

        private void FormatClientsWorkSheet(Excel.Worksheet ews)
        {
            ews.Columns[1].columnwidth = 35;
            ews.Columns[2].columnwidth = 10;
            ews.Columns[3].columnwidth = 52;
            ews.Columns[4].columnwidth = 30;
            ews.Columns[5].columnwidth = 30;
            ews.Columns[6].columnwidth = 17;
        }

        #endregion



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
    }
}