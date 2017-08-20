using System;
using System.ComponentModel;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace MSAMISUserInterface {
    public partial class ReportsPreview : Form {
        public MainForm Main;
        public int Mode;
        public Shadow Refer;

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
            var myfont = FontFactory.GetFont("Arial", 10, BaseColor.BLACK);
            var pdfTable = new PdfPTable(GReportGRD.ColumnCount);
            pdfTable.SetWidths(Reports.GetPDFFormat(formOrigin));
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
            var headerfont = FontFactory.GetFont("Arial", 11, BaseColor.BLACK);
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
            return pdfTable;
        }

        #endregion
    }
}