using System;
using System.ComponentModel;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using rylui;

namespace MSAMISUserInterface {
    public partial class ReportsPreview : Form {
        public MainForm Main;
        public int Mode;
        public Shadow Refer;
        public string Names;
        public Payroll Pay;

        public ReportsPreview() {
            InitializeComponent();
            Opacity = 0;
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            Close();
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
                case 5:
                    NameLBL.Text = "Payslip Details";
                    PayslipSaveTo.Visible = true;
                    ApproveLBL.Visible = true;
                    ApproveLBL.Text = "Approved by: " + Pay.ApprovedBy;
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
            if (Mode !=5 ) Refer.Close();
        }

        private void LoadTable() {
            if (Mode != 5) TimeLBL.Text = DateTime.Now.ToString("dddd, MMMM dd yyyy");
            else TimeLBL.Text = "for " + Names;
            if (Mode == 1) {
                GReportGRD.DataSource = Reports.GetGuardsList();
                GReportGRD.Columns[0].HeaderText = "Name";
                GReportGRD.Columns[1].HeaderText = "Status";
                GReportGRD.Columns[2].HeaderText = "Contact Number";
                GReportGRD.Columns[3].HeaderText = "License Number";
                GReportGRD.Columns[4].HeaderText = "SSS";
                GReportGRD.Columns[5].HeaderText = "TIN Number";
                GReportGRD.Columns[6].HeaderText = "PHIC";

                #region Format Table

                GReportGRD.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GReportGRD.Columns[0].Width = 260;
                GReportGRD.Columns[1].Width = 70;
                GReportGRD.Columns[2].Width = 140;

                GReportGRD.Sort(GReportGRD.Columns[1], ListSortDirection.Ascending);

                #endregion
            }
            else if (Mode == 2) {
                GReportGRD.DataSource = Reports.GetClientsList();

                GReportGRD.Columns[0].HeaderText = "Client Name";
                GReportGRD.Columns[1].HeaderText = "Status";
                GReportGRD.Columns[2].HeaderText = "Address";
                GReportGRD.Columns[3].HeaderText = "Manager";
                GReportGRD.Columns[4].HeaderText = "Contact Person";
                GReportGRD.Columns[5].HeaderText = "Contact Number";

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


        #region RylBlock

        public void FormatPDF(char formOrigin) {
            //Default PDF Format
            GReportGRD.DataSource = Reports.GetList(formOrigin);
            String strcheck = "";
            if (formOrigin == 'd') 
            {
                for(int x = 0; x < GReportGRD.RowCount; x++)
                {
                    if (GReportGRD.Rows[x].Cells[0].Value.ToString() != strcheck)
                        strcheck = GReportGRD.Rows[x].Cells[0].Value.ToString();
                    else
                        GReportGRD.Rows[x].Cells[0].Value = "";
                }
            }
            var myfont = FontFactory.GetFont("Arial", 8, BaseColor.BLACK);
            var pdfTable = new PdfPTable(GReportGRD.ColumnCount);
            pdfTable.SetWidths(Reports.GetPDFFormat(formOrigin));
            pdfTable.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfTable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 30;
            pdfTable.DefaultCell.BorderWidth = 1;
            pdfTable.HorizontalAlignment = 1;
            pdfTable.TotalWidth = 1000f;
            pdfTable.LockedWidth = true;

            //Add Headers Here
            pdfTable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfTable = AddHeaders(pdfTable, formOrigin);
            var i = 0;
            //Add Data to PDF
            foreach (DataGridViewRow row in GReportGRD.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    var newcell = new PdfPCell(new Phrase(cell.Value.ToString(), myfont))
                    {
                        PaddingTop = 5f,
                        PaddingBottom = 8f
                    };
                    pdfTable.AddCell(newcell);
                }
            }
            var r = new Reports();
            r.ExportToPDF(pdfTable, formOrigin);
        }

        public PdfPTable AddHeaders(PdfPTable pdfTable, char o) {
            var headerfont = FontFactory.GetFont("Arial", 9, BaseColor.BLACK);
            if (o == 'g') {
                pdfTable.AddCell(new Phrase("Name", headerfont));
                pdfTable.AddCell(new Phrase("Status", headerfont));
                pdfTable.AddCell(new Phrase("Contact Number", headerfont));
                pdfTable.AddCell(new Phrase("License Number", headerfont));
                pdfTable.AddCell(new Phrase("SSS", headerfont));
                pdfTable.AddCell(new Phrase("TIN Number", headerfont));
                pdfTable.AddCell(new Phrase("PHIC", headerfont));
            }

            else if (o == 'c') {
                pdfTable.AddCell(new Phrase("Client Name", headerfont));
                pdfTable.AddCell(new Phrase("Status", headerfont));
                pdfTable.AddCell(new Phrase("Client Address", headerfont));
                pdfTable.AddCell(new Phrase("Manager", headerfont));
                pdfTable.AddCell(new Phrase("Contact Person", headerfont));
                pdfTable.AddCell(new Phrase("Contact Number", headerfont));
            }

            else if (o == 'd') {
                pdfTable.AddCell(new Phrase("Client Name", headerfont));
                pdfTable.AddCell(new Phrase("Guards Assigned", headerfont));
                pdfTable.AddCell(new Phrase("License Number", headerfont));
                pdfTable.AddCell(new Phrase("Deployment Address", headerfont));
                pdfTable.AddCell(new Phrase("Shift Start", headerfont));
                pdfTable.AddCell(new Phrase("Shift End", headerfont));
                pdfTable.AddCell(new Phrase("Shift Days", headerfont));
                pdfTable.AddCell(new Phrase("Contract Start", headerfont));
                pdfTable.AddCell(new Phrase("Contract End", headerfont));
            }
            else if (o == 's') {
                PdfPCell cell = new PdfPCell();
                cell.Rowspan = 3;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;

                cell.Phrase = (new Phrase("Employee", headerfont));
                pdfTable.AddCell(cell);
                cell.Phrase = (new Phrase("Days of Work", headerfont));
                pdfTable.AddCell(cell);
                cell.Phrase = (new Phrase("Rate", headerfont));
                pdfTable.AddCell(cell);
                cell.Phrase = (new Phrase("Total Regular Wage", headerfont));
                pdfTable.AddCell(cell);

                cell.Rowspan = 1;
                cell.Colspan = 4;

                cell.Phrase = (new Phrase("Overtime", headerfont));
                pdfTable.AddCell(cell);

                cell.Rowspan = 3;
                cell.Colspan = 1;

                cell.Phrase = (new Phrase("Total Amount", headerfont));
                pdfTable.AddCell(cell);

                cell.Rowspan = 1;
                cell.Colspan = 4;

                cell.Phrase = (new Phrase("DEDUCTIONS", headerfont));
                pdfTable.AddCell(cell);

                cell.Rowspan = 3;
                cell.Colspan = 1;

                cell.Phrase = (new Phrase("13th Month", headerfont));
                pdfTable.AddCell(cell);

                cell.Phrase = (new Phrase("Cola", headerfont));
                pdfTable.AddCell(cell);

                cell.Phrase = (new Phrase("Emergency Allow.", headerfont));
                pdfTable.AddCell(cell);

                cell.Phrase = (new Phrase("Net Amount Paid", headerfont));
                pdfTable.AddCell(cell);

                cell.Phrase = (new Phrase("Signature of Payee", headerfont));
                pdfTable.AddCell(cell);

                //Second Row
                cell.Colspan = 2;
                cell.Rowspan = 1;

                cell.Phrase = (new Phrase("Regular Day", headerfont));
                pdfTable.AddCell(cell);

                cell.Phrase = (new Phrase("Sunday & Holiday", headerfont));
                pdfTable.AddCell(cell);

                cell.Colspan = 1;
                cell.Rowspan = 2;

                cell.Phrase = (new Phrase("SSS", headerfont));
                pdfTable.AddCell(cell);

                cell.Phrase = (new Phrase("PHIC", headerfont));
                pdfTable.AddCell(cell);

                cell.Phrase = (new Phrase("Tax Withhold", headerfont));
                pdfTable.AddCell(cell);

                cell.Phrase = (new Phrase("HDMF", headerfont));
                pdfTable.AddCell(cell);

                //Third Row
                cell.Colspan = 1;
                cell.Rowspan = 1;

                cell.Phrase = (new Phrase("Hrs", headerfont));
                pdfTable.AddCell(cell);

                cell.Phrase = (new Phrase("Amt", headerfont));
                pdfTable.AddCell(cell);

                cell.Phrase = (new Phrase("Hrs", headerfont));
                pdfTable.AddCell(cell);

                cell.Phrase = (new Phrase("Amt", headerfont));
                pdfTable.AddCell(cell);

                //test if it loops after the edge column of the table
            }
            return pdfTable;
        }

        #endregion

        private void PayslipSaveTo_Click(object sender, EventArgs e) {
            var savefile = new SaveFileDialog {
                FileName = "Payslip for "+ Names ,
                Filter = "Portable Document Format (.pdf)|*.pdf"
            };
            if (savefile.ShowDialog() == DialogResult.OK)
                RylMessageBox.ShowDialog("Saved");
            //  File.Copy(SSummaryFilesLST.Items[0].SubItems[1].Text, savefile.FileName, true);
        }
    }
}