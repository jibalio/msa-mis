using System.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;



namespace MSAMISUserInterface
{
    public class Reports
    {
        public SqlConnection conn;
        public String FilterText = "Search or filter";
        public String EmptyText = "";
        public static String ExtraQueryParams = "";
        public string summaryDate = "";
        public DateTime now = DateTime.Now;

        #region Guards Report

        public static DataTable GetGuardsList()
        {
            ExtraQueryParams = " ";
            String q = "SELECT concat(ln,', ',fn,' ',mn) AS 'Full Name', CASE WHEN GStatus = 1 THEN 'Active' WHEN GStatus = 2 THEN 'Inactive' END as Status,  CellNo as 'Cell Number', LicenseNo as 'License Number', SSS, TIN, PhilHealth as PHIC FROM msadb.guards" + ExtraQueryParams;
            return SQLTools.ExecuteQuery(q);
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

        private static String getGuardsQuery(char id)
        {
            if (id == 't')
                return "SELECT COUNT(GStatus) FROM msadb.guards";
            else if (id == 'a')
                return "SELECT COUNT(GStatus) FROM msadb.guards WHERE GStatus = 1";
            return "";
        }

        #endregion

        #region Client Report

        public static DataTable GetClientsList()
        {
            ExtraQueryParams = " ORDER BY Name asc";
            String q = "SELECT Name as 'Name', CASE WHEN CStatus = 1 THEN 'Active' WHEN CStatus = 2 THEN 'Inactive' END as Status, concat(ClientStreetNo,' ', ClientStreet, ', ', ClientBrgy, ', ', ClientCity) as Address, Manager, ContactPerson as 'Contact Person', ContactNo as 'Contact Number' FROM msadb.client" + ExtraQueryParams;
            return SQLTools.ExecuteQuery(q);
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

        private static String getClientsQuery(char id)
        {
            if (id == 't')
                return "SELECT COUNT(CStatus) FROM msadb.client";
            else if (id == 'a')
                return "SELECT COUNT(CStatus) FROM msadb.client WHERE CStatus = 1";
            return "";
        }

        #endregion

        #region Export

        public void ShowExportDialog(char formOrigin)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = formatFileName(formOrigin);
            savefile.Filter = "Excel Workbook (.xlsx)|*.xlsx|Excel 97-2003 Template (.xls)|*.xls";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                string filePath = System.IO.Path.GetDirectoryName(savefile.FileName);
                string fileName = System.IO.Path.GetFileName(savefile.FileName);
                ExporttoExcel(filePath, fileName, formOrigin);
            }
        }

        public DataTable GetList(char formOrigin)
        {
            if (formOrigin == 'g')
                return GetGuardsList();
            else if (formOrigin == 'c')
                return GetClientsList();
            else
                return null;
        }

        public void ExporttoExcel(String FilePath, String FileName, char formOrigin)
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
            if (formOrigin == 'g')
                FormatGuardsWorkSheet(ExcelWorkSheet);
            else if (formOrigin == 'c')
                FormatClientsWorkSheet(ExcelWorkSheet);

            ExcelApp.ActiveWorkbook.SaveAs(FilePath + "\\" + FileName);
            ExcelApp.ActiveWorkbook.Saved = true;
            ExcelApp.Quit();
        }

        #endregion

        public static int GetTotalGuards(char origin, char id)
        {
            if (origin == 'g')
            {
                DataTable dt = SQLTools.ExecuteQuery(getGuardsQuery(id));
                return int.Parse(dt.Rows[0][0].ToString());
            }
            else if (origin == 'c')
            {
                DataTable dt = SQLTools.ExecuteQuery(getClientsQuery(id));
                return int.Parse(dt.Rows[0][0].ToString());
            }
            return 0;
        }

        private String formatFileName(char origin)
        {
            if (origin == 'g')
                return "GuardsSummaryReport_" + now.ToString("MMM-dd-yyyy");
            else if (origin == 'c')
                return "ClientSummaryReport_" + now.ToString("MMM-dd-yyyy");
            return "";
        }


    }
}

