using System.Data.SqlClient;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Reflection;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace MSAMISUserInterface
{
    public partial class ReportsForm : Form
    {
        public SqlConnection conn;
        public DateTime now = DateTime.Now;
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
            r.ExporttoExcel('g');
        }

        private void ExportClientsSummaryBTN_Click(object sender, EventArgs e)
        {
            Reports r = new Reports();
            r.ExporttoExcel('c');
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
            GSummaryDateLBL.Text = "Guards Summary as of " + now.ToString("MM/dd/yyyy");
            CSummaryDateLBL.Text = "Clients Summary as of " + now.ToString("MM/dd/yyyy");
            GTotalLBL.Text = "Total Guards: " + Reports.GetTotalGuards('g', 't');
            GTotalActiveLBL.Text = "Total Active Guards: " + Reports.GetTotalGuards('g', 'a');
            CTotalLBL.Text = "Total Clients: " + Reports.GetTotalGuards('c', 't');
            CTotalActiveLBL.Text = "Total Active Clients: " + Reports.GetTotalGuards('c', 'a');
        }

        #endregion

        private void CExportToPDFBTN_Click(object sender, EventArgs e)
        {
            PdfPTable pdfTable = new PdfPTable(ClientsSummaryTBL.ColumnCount);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 30;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            //Adding Header row
            /*
            foreach (DataGridViewColumn column in ClientsSummaryTBL.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                pdfTable.AddCell(cell);
            }
            */

            //Adding DataRow
            foreach (DataGridViewRow row in ClientsSummaryTBL.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdfTable.AddCell(cell.Value.ToString());
                }
            }

            //Exporting to PDF
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "MSAMIS Reports";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            if (File.Exists(folderPath + "\\" + "DataGridViewExport.pdf"))
            {
                DialogResult x = rylui.RylMessageBox.ShowDialog("DataGridViewExport.pdf" + " already exists.\nDo you want to replace it?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (x == DialogResult.Yes)
                {
                    File.Delete(folderPath + "\\" + "DataGridViewExport.pdf");
                }
            }
            using (FileStream stream = new FileStream(folderPath + "\\" + "DataGridViewExport.pdf", FileMode.Create))
                    {
                        Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                        PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();
                        pdfDoc.Add(pdfTable);
                        pdfDoc.Close();
                        stream.Close();
                    }
        }

    }
}