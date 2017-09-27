using System;
using System.ComponentModel;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text;
using rylui;


namespace MSAMISUserInterface {
    public partial class ReportsPreview : Form {
        public MainForm Main;
        public int Mode;
        public Shadow Refer;
        public string Names;
        public string PayrollPeriod;
        public Payroll Pay;
        Font boldfont = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
        Font myfont = FontFactory.GetFont("Consolas", 8, BaseColor.BLACK);

        public ReportsPreview() {
            InitializeComponent();
            Opacity = 0;
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            Close();
        }

        private const int CsDropshadow = 0x20000;

        protected override CreateParams CreateParams {
            get {
                var cp = base.CreateParams;
                cp.ClassStyle |= CsDropshadow;
                return cp;
            }
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
                    PayslipPrint.Visible = true;
                    ApproveLBL.Visible = true;
                    ApproveLBL.Text = "Approved by: " + Pay.ApprovedBy;
                    PayslipPanel.Visible = true;
                    PayslipPreview();
                    break;
                default:
                    NameLBL.Text = "Summary Report";
                    break;
            }
        }

        private void PayslipPreview() {
            DCashAdvanceLBL.Text = CurrencyFormatNegative(Pay.CashAdvance);
            DPagIbigLBL.Text = CurrencyFormatNegative(Pay.PagIbig);
            DPhilHealthLBL.Text = CurrencyFormatNegative(Pay.PhilHealth);
            DSSSLBL.Text = CurrencyFormatNegative(Pay.Sss);
            DTotalLBL.Text = CurrencyFormatNegative(Pay.Deductions);

            var wt = Pay.GetWithholdingTax();
            DWithLBL.Text = CurrencyFormatNegative(wt.total);

            B13LBL.Text = CurrencyFormat(Pay.ThirteenthMonthPay);
            BAllowanceLBL.Text = CurrencyFormat(Pay.EmergencyAllowance);
            BBondsLBL.Text = CurrencyFormat(Pay.CashBond);
            BColaLBL.Text = CurrencyFormat(Pay.Cola);
            BTotalLBL.Text = CurrencyFormat(Pay.Bonuses);

            NetPayLBL.Text = "TOTAL PAY: " + CurrencyFormat(Pay.NetPay);

            PayslipNameLBL.Text = Names.ToUpper();
            PayslipPeriodLBL.Text = PayrollPeriod;

        }

        private static string CurrencyFormat(double money) {
            return "₱ " + money.ToString("N2");
        }

        private static string CurrencyFormatNegative(double money) {
            return "₱ -" + money.ToString("N2");
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
        /*
        public DataTable formatSalaryReportTable()
        {
             dt;
            var approvedlist = Payroll.GetApprovedPayrollsList();
            int gid, month, period, year;
            int i;
            for (i = 0; i < Payroll.GetApprovedPayrollsList().Rows.Count; i++)
            {
                gid = Convert.ToInt32(approvedlist.Rows[i][0]);
                month = Convert.ToInt32(approvedlist.Rows[i][1]);
                period = Convert.ToInt32(approvedlist.Rows[i][2]);
                year = Convert.ToInt32(approvedlist.Rows[i][3]);
                PayrollReport pr = new PayrollReport(gid, year, month, period);


                DataRow dr = dt.NewRow(pr.LN + ", " + pr.FN + pr.MN, pr.DaysOfWork, pr.Rate, pr.TotalRegularWage, pr.overtime.RegularDay.hour, pr.overtime.RegularDay.total, pr.overtime.SundayAndHoliday.hour, pr.overtime.SundayAndHoliday, pr.TotalAmount, pr.Sss, pr.PHIC, pr.Withtax, pr.HDMF, pr.CashAdvance, pr.ThirteenthMonthPay, pr.Cola, pr.CashBond, pr.EmergencyAllowance, pr.NetAmountPaid, "");
                dt.Rows.InsertAt(dr, i);
                //add data
                //GReportGRD.Rows.Add(pr.LN + ", " + pr.FN + pr.MN, pr.DaysOfWork, pr.Rate, pr.TotalRegularWage, pr.overtime.RegularDay.hour, pr.overtime.RegularDay.total, pr.overtime.SundayAndHoliday.hour, pr.overtime.SundayAndHoliday, pr.TotalAmount, pr.Sss, pr.PHIC, pr.Withtax, pr.HDMF, pr.CashAdvance, pr.ThirteenthMonthPay, pr.Cola, pr.CashBond, pr.EmergencyAllowance, pr.NetAmountPaid, "");
                [i].Cells[0].Value = pr.LN + ", " + pr.FN + pr.MN;
                GReportGRD.Rows[i].Cells[1].Value = pr.DaysOfWork;
                GReportGRD.Rows[i].Cells[2].Value = pr.Rate;
                GReportGRD.Rows[i].Cells[3].Value = pr.TotalRegularWage;
                GReportGRD.Rows[i].Cells[4].Value = pr.overtime.RegularDay.hour;
                GReportGRD.Rows[i].Cells[5].Value = pr.overtime.RegularDay.total;
                GReportGRD.Rows[i].Cells[6].Value = pr.overtime.SundayAndHoliday.hour;
                GReportGRD.Rows[i].Cells[7].Value = pr.overtime.SundayAndHoliday;
                GReportGRD.Rows[i].Cells[8].Value = pr.TotalAmount;
                GReportGRD.Rows[i].Cells[9].Value = pr.Sss;
                GReportGRD.Rows[i].Cells[10].Value = pr.PHIC;
                GReportGRD.Rows[i].Cells[11].Value = pr.Withtax;
                GReportGRD.Rows[i].Cells[12].Value = pr.HDMF;
                GReportGRD.Rows[i].Cells[13].Value = pr.CashAdvance;
                GReportGRD.Rows[i].Cells[14].Value = pr.ThirteenthMonthPay;
                GReportGRD.Rows[i].Cells[15].Value = pr.Cola;
                GReportGRD.Rows[i].Cells[16].Value = pr.CashBond;
                GReportGRD.Rows[i].Cells[17].Value = pr.EmergencyAllowance;
                GReportGRD.Rows[i].Cells[18].Value = pr.NetAmountPaid;
                GReportGRD.Rows[i].Cells[19].Value = "";
                
            }
            return dt;
        }
        */

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

            //
            var myfont = FontFactory.GetFont("Arial", 8, BaseColor.BLACK);
            var pdfTable = new PdfPTable(GReportGRD.ColumnCount);
            pdfTable.SetWidths(Reports.GetPDFFormat(formOrigin));
            pdfTable.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            //pdfTable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 30;
            pdfTable.DefaultCell.BorderWidth = 1;
            pdfTable.HorizontalAlignment = 1;
            pdfTable.TotalWidth = 1000f;
            pdfTable.LockedWidth = true;

            //Add Headers Here
            pdfTable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfTable = AddHeaders(pdfTable, formOrigin);
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
                    if (cell.ColumnIndex != 0 && formOrigin == 's')
                    {

                        newcell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        pdfTable.AddCell(newcell);
                    }
                    else if (formOrigin == 'g')
                    {
                        if (!(cell.ColumnIndex == 0 || cell.ColumnIndex == 1))
                        {
                            newcell.HorizontalAlignment = Element.ALIGN_RIGHT;
                            pdfTable.AddCell(newcell);
                        } else pdfTable.AddCell(newcell);
                    }
                    else
                    {
                        newcell.HorizontalAlignment = Element.ALIGN_LEFT;
                        pdfTable.AddCell(newcell);
                    }
                }
            }
                var r = new Reports();
                r.ExportToPDF(pdfTable, formOrigin);
        }

        public PdfPTable AddHeaders(PdfPTable pdfTable, char o) {
            
            if (o == 'g') {

                
                pdfTable.AddCell(new Phrase("Name", boldfont));
                pdfTable.AddCell(new Phrase("Status", boldfont));
                pdfTable.AddCell(new Phrase("Contact Number", boldfont));
                pdfTable.AddCell(new Phrase("License Number", boldfont));
                pdfTable.AddCell(new Phrase("SSS", boldfont));
                pdfTable.AddCell(new Phrase("TIN Number", boldfont));
                pdfTable.AddCell(new Phrase("PHIC", boldfont));
            }

            else if (o == 'c') {
                
                pdfTable.AddCell(new Phrase("Client Name", boldfont));
                pdfTable.AddCell(new Phrase("Status", boldfont));
                pdfTable.AddCell(new Phrase("Client Address", boldfont));
                pdfTable.AddCell(new Phrase("Manager", boldfont));
                pdfTable.AddCell(new Phrase("Contact Person", boldfont));
                pdfTable.AddCell(new Phrase("Contact Number", boldfont));
            }

            else if (o == 'd') {
                pdfTable.AddCell(new Phrase("Client Name", boldfont));
                pdfTable.AddCell(new Phrase("Guards Assigned", boldfont));
                pdfTable.AddCell(new Phrase("License Number", boldfont));
                pdfTable.AddCell(new Phrase("Deployment Address", boldfont));
                pdfTable.AddCell(new Phrase("Shift Start", boldfont));
                pdfTable.AddCell(new Phrase("Shift End", boldfont));
                pdfTable.AddCell(new Phrase("Shift Days", boldfont));
                pdfTable.AddCell(new Phrase("Contract Start", boldfont));
                pdfTable.AddCell(new Phrase("Contract End", boldfont));
            }
            else if (o == 's') {
                PdfPCell cell = new PdfPCell();
                cell.Rowspan = 3;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;

                cell.Phrase = (new Phrase("Employee", boldfont));
                pdfTable.AddCell(cell);
                cell.Phrase = (new Phrase("Days of Work", boldfont));
                pdfTable.AddCell(cell);
                cell.Phrase = (new Phrase("Rate", boldfont));
                pdfTable.AddCell(cell);
                cell.Phrase = (new Phrase("Total Regular Wage", boldfont));
                pdfTable.AddCell(cell);

                cell.Rowspan = 1;
                cell.Colspan = 4;

                cell.Phrase = (new Phrase("Overtime", boldfont));
                pdfTable.AddCell(cell);

                cell.Rowspan = 3;
                cell.Colspan = 1;

                cell.Phrase = (new Phrase("Total Amount", boldfont));
                pdfTable.AddCell(cell);

                cell.Rowspan = 1;
                cell.Colspan = 5;

                cell.Phrase = (new Phrase("DEDUCTIONS", boldfont));
                pdfTable.AddCell(cell);

                cell.Rowspan = 3;
                cell.Colspan = 1;

                cell.Phrase = (new Phrase("13th Month", boldfont));
                pdfTable.AddCell(cell);

                cell.Phrase = (new Phrase("Cola", boldfont));
                pdfTable.AddCell(cell);

                cell.Phrase = (new Phrase("Cash Bond", boldfont));
                pdfTable.AddCell(cell);

                cell.Phrase = (new Phrase("Emergency Allow.", boldfont));
                pdfTable.AddCell(cell);

                cell.Phrase = (new Phrase("Net Amount Paid", boldfont));
                pdfTable.AddCell(cell);

                cell.Phrase = (new Phrase("Signature of Payee", boldfont));
                pdfTable.AddCell(cell);

                //Second Row
                cell.Colspan = 2;
                cell.Rowspan = 1;

                cell.Phrase = (new Phrase("Regular Day", boldfont));
                pdfTable.AddCell(cell);

                cell.Phrase = (new Phrase("Sunday & Holiday", boldfont));
                pdfTable.AddCell(cell);

                cell.Colspan = 1;
                cell.Rowspan = 2;

                cell.Phrase = (new Phrase("SSS", boldfont));
                pdfTable.AddCell(cell);

                cell.Phrase = (new Phrase("PHIC", boldfont));
                pdfTable.AddCell(cell);

                cell.Phrase = (new Phrase("Tax Withhold", boldfont));
                pdfTable.AddCell(cell);

                cell.Phrase = (new Phrase("HDMF", boldfont));
                pdfTable.AddCell(cell);

                cell.Phrase = (new Phrase("Cash Advance", boldfont));
                pdfTable.AddCell(cell);

                //Third Row
                cell.Colspan = 1;
                cell.Rowspan = 1;

                cell.Phrase = (new Phrase("Hrs", boldfont));
                pdfTable.AddCell(cell);

                cell.Phrase = (new Phrase("Amt", boldfont));
                pdfTable.AddCell(cell);

                cell.Phrase = (new Phrase("Hrs", boldfont));
                pdfTable.AddCell(cell);

                cell.Phrase = (new Phrase("Amt", boldfont));
                pdfTable.AddCell(cell);

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