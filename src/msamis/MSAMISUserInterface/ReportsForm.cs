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
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;

namespace MSAMISUserInterface {
    public partial class ReportsForm : Form {
        public MySqlConnection conn;
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
            String q = "SELECT concat(ln,', ',fn,' ',mn) AS fullname, GStatus, CellNo, LicenseNo, SSS, TIN, PhilHealth FROM msadb.guards" + ExtraQueryParams;
            return SQLTools.ExecuteQuery(q);
        }

        public void CLIENTSRefreshClientsList()
        {
            CClientListTBL.DataSource = GetClientList();
            CClientListTBL.Columns["fullname"].HeaderText = "NAME";
            CClientListTBL.Columns["Gstatus"].HeaderText = "STATUS";
            CClientListTBL.Columns["CellNo"].HeaderText = "CONTACT NUMBER";
            CClientListTBL.Columns["LicenseNo"].HeaderText = "LICENSE NO";
            CClientListTBL.Columns["SSS"].HeaderText = "SSS";
            CClientListTBL.Columns["TIN"].HeaderText = "TIN NO";
            CClientListTBL.Columns["PhilHealth"].HeaderText = "PHIC";

            #region Format Table
            CClientListTBL.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            CClientListTBL.Columns["fullname"].Width = 200;
            CClientListTBL.Columns["Gstatus"].Width = 70;
            CClientListTBL.Columns["CellNo"].Width = 140;

            CClientListTBL.Sort(CClientListTBL.Columns[1], ListSortDirection.Ascending);
            #endregion

        }
        #endregion
        #region Export

        private void PrintClientReportBTN_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            // set a default file name
            savefile.FileName = "Book1.xls";
            // set filters - this can be done in properties as well
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

            ExcelApp.Application.Workbooks.Add(Type.Missing);

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
            }
            ExcelApp.ActiveWorkbook.SaveAs(FilePath + "\\" + FileName);
            ExcelApp.ActiveWorkbook.Saved = true;
            ExcelApp.Quit();
        }
        #endregion

    }

}