using System.Data.SqlClient;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Reflection;
using iTextSharp.text.pdf;
using iTextSharp.text;


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

            switch (Mode) {
                case 1:
                    NameLBL.Text = "Guards Summary";
                    break;
                case 2:
                    NameLBL.Text = "Clients Summary";
                    break;
                case 3:
                    NameLBL.Text = "Duty Details Summary";
                    break;
                case 4:
                    NameLBL.Text = "Salary Report";
                    break;
                default:
                    NameLBL.Text = "Summary Report";
                    break;
            }
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
            } else if (Mode == 2) {
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
                FormatPDF('g');
                Main.GuardsLoadReport();
            } else if (Mode == 2) {
                var r = new Reports();
                FormatPDF('c');
                Main.ClientsLoadSummary();
            }
        }


        #region RylBlock

        private void CExportToPDFBTN_Click(object sender, EventArgs e)
        {
            Reports1.ExportToPDF(FormatPDF('c'), 'c');
        }


        private PdfPTable FormatPDF(char formOrigin)
        {
            //Default PDF Format
            Font myfont = FontFactory.GetFont("Arial", 10, BaseColor.BLACK);
            Font headerfont = FontFactory.GetFont("Arial", 11, BaseColor.BLACK);
            PdfPTable pdfTable = new PdfPTable(GReportGRD.ColumnCount);
            pdfTable.SetWidths(Reports1.GetPDFFormat(formOrigin));
            pdfTable.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfTable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 30;
            pdfTable.DefaultCell.BorderWidth = 1;
            pdfTable.HorizontalAlignment = 1;
            pdfTable.TotalWidth = 900f;
            pdfTable.LockedWidth = true;

            //Add Headers Here
            pdfTable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfTable.AddCell(new Phrase("Client Name", headerfont));
            pdfTable.AddCell(new Phrase("Status", headerfont));
            pdfTable.AddCell(new Phrase("Client Address", headerfont));
            pdfTable.AddCell(new Phrase("Manager", headerfont));
            pdfTable.AddCell(new Phrase("Contact Person", headerfont));
            pdfTable.AddCell(new Phrase("Contact Number", headerfont));


            //Add Data to PDF
            foreach (DataGridViewRow row in GReportGRD.Rows)
            {

                foreach (DataGridViewCell cell in row.Cells)
                {
                    PdfPCell newcell = new PdfPCell(new Phrase(cell.Value.ToString(), myfont));
                    newcell.PaddingTop = 5f;
                    newcell.PaddingBottom = 8f;
                    pdfTable.AddCell(newcell);
                }
            }
            return pdfTable;
        }


        #endregion





    }
}
