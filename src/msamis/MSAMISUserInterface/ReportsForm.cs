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
            CLIENTSRefreshClientsList();
        }

        #region SQL

        private DataTable GetClientList()
        {
            ExtraQueryParams = " ORDER BY ln asc";
            String q = "SELECT concat(ln,', ',fn,' ',mn) AS 'Full Name', CASE WHEN GStatus = 1 THEN 'Active' WHEN GStatus = 2 THEN 'Inactive' END as Status, CellNo as 'Cell Number', LicenseNo as 'License Number', SSS, TIN, PhilHealth as PHIC FROM msadb.guards" + ExtraQueryParams;
            return SQLTools.ExecuteQuery(q);
        }

        public void CLIENTSRefreshClientsList()
        {
            CClientListTBL.DataSource = GetClientList();

            CClientListTBL.Columns["Full Name"].HeaderText = "NAME";
            CClientListTBL.Columns["Status"].HeaderText = "STATUS";
            CClientListTBL.Columns["Cell Number"].HeaderText = "CONTACT NUMBER";
            CClientListTBL.Columns["License Number"].HeaderText = "LICENSE NUMBER";
            CClientListTBL.Columns["SSS"].HeaderText = "SSS";
            CClientListTBL.Columns["TIN"].HeaderText = "TIN NO";
            CClientListTBL.Columns["PHIC"].HeaderText = "PHIC";

            #region Format Table
            CClientListTBL.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            CClientListTBL.Columns["Full Name"].Width = 200;
            CClientListTBL.Columns["Status"].Width = 70;
            CClientListTBL.Columns["Cell Number"].Width = 140;

            CClientListTBL.Sort(CClientListTBL.Columns[1], ListSortDirection.Ascending);
            #endregion

        }
        #endregion
        #region Export

        private void PrintClientReportBTN_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = "Book1";
            savefile.Filter = "Excel Workbook (.xlsx)|*.xlsx|Excel 97-2003 Template (.xls)|*.xls";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                string filePath = System.IO.Path.GetDirectoryName(savefile.FileName);
                string fileName = System.IO.Path.GetFileName(savefile.FileName);
                ExporttoExcel(filePath, fileName);
            }
        }

        private void ExporttoExcel(String FilePath, String FileName)
        {

            DataTable dtMainSQLData = GetClientList();
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
            FormatClientWorkSheet(ExcelWorkSheet);

            ExcelApp.ActiveWorkbook.SaveAs(FilePath + "\\" + FileName);
            ExcelApp.ActiveWorkbook.Saved = true;
            ExcelApp.Quit();
        }

        private void FormatClientWorkSheet(Excel.Worksheet ews)
        {
            ews.Columns[1].columnwidth = 35;
            ews.Columns[2].columnwidth = 10;
            ews.Columns[3].columnwidth = 18;
            ews.Columns[4].columnwidth = 17;
            ews.Columns[5].columnwidth = 14;
            ews.Columns[6].columnwidth = 13;
            ews.Columns[7].columnwidth = 16;
        }
        #endregion

    }

}