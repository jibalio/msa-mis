using System.Data.SqlClient;
using System;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Printing;


namespace MSAMISUserInterface
{
    public class Reports
    {
        public SqlConnection conn;
        public String FilterText = "Search or filter";
        public String EmptyText = "";
        public static String ExtraQueryParams = "";
        public string summaryDate = "";

        #region Guards Report

        public static DataTable GetGuardsList()
        {
            ExtraQueryParams = " ";
            String q = "SELECT concat(ln,', ',fn,' ',mn) AS 'Full Name', CASE WHEN GStatus = 1 THEN 'Active' WHEN GStatus = 2 THEN 'Inactive' END as Status,  CellNo as 'Cell Number', LicenseNo as 'License Number', SSS, TIN, PhilHealth as PHIC FROM msadb.guards" + ExtraQueryParams;
            return SQLTools.ExecuteQuery(q);
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

        #region Clients Export
        public static DataTable GetClientsList()
        {
            ExtraQueryParams = " ORDER BY Name asc";
            String q = "SELECT Name as 'Name', CASE WHEN CStatus = 1 THEN 'Active' WHEN CStatus = 2 THEN 'Inactive' END as Status, concat(ClientStreetNo,' ', ClientStreet, ', ', ClientBrgy, ', ', ClientCity) as Address, Manager, ContactPerson as 'Contact Person', ContactNo as 'Contact Number' FROM msadb.client" + ExtraQueryParams;
            return SQLTools.ExecuteQuery(q);
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

        #region Duty Detail Export
        public static DataTable GetDutyDetailList()
        {
            ExtraQueryParams = "GROUP BY concat(guards.ln, ', ', guards.fn, ' ', guards.mn) ORDER BY client.Name asc; ";
            String q = "SELECT  client.Name as 'Client Name' , concat(guards.ln,', ',guards.fn,' ',guards.mn) AS 'Guards Assigned', guards.LicenseNo as 'License Number', concat(request_assign.streetno, ' ', request_assign.streetname, ', ', request_assign.brgy, ', ', request_assign.city) as 'Assignment Address', concat(dutydetails.TI_hh, ':', dutydetails.TI_mm, ' ', dutydetails.TI_period) AS 'Shift Start', concat(dutydetails.TO_hh, ':', dutydetails.TO_mm, ' ', dutydetails.TO_period) AS 'Shift End', concat(dutydetails.Mon, dutydetails.Tue, dutydetails.Wed, dutydetails.Thu, dutydetails.Fri, dutydetails.Sat, dutydetails.Sun) AS 'Shift Days', request_assign.ContractStart AS 'Contract Start', request_assign.ContractEnd AS 'Contract End' FROM sduty_assignment JOIN guards ON sduty_assignment.GID = guards.GID JOIN request_assign ON sduty_assignment.RAID = request_assign.RAID JOIN request ON request_assign.RID = request.RID JOIN client ON request.CID = client.CID LEFT JOIN dutydetails ON sduty_assignment.AID = dutydetails.AID " + ExtraQueryParams;
            return SQLTools.ExecuteQuery(q);
        }

        #endregion

        #region Salary Export
        public static DataTable GetSalaryList()
        {
            var dt = new DataTable();
            var approvedlist = Payroll.GetApprovedPayrollsList();
            int gid, month, period, year;
            int i;

            for (i = 0; i <= 19; i++)
            dt.Columns.Add();

            for (i = 0; i < Payroll.GetApprovedPayrollsList().Rows.Count; i++)
            {
                gid = Convert.ToInt32(approvedlist.Rows[i][0]);
                month = Convert.ToInt32(approvedlist.Rows[i][1]);
                period = Convert.ToInt32(approvedlist.Rows[i][2]);
                year = Convert.ToInt32(approvedlist.Rows[i][3]);
                PayrollReport pr = new PayrollReport(gid, year, month, period);

                DataRow dr = dt.NewRow();
                dr[0] = pr.LN + ", " + pr.FN + pr.MN;
                dr[1] = pr.DaysOfWork;
                dr[2] = "₱" + pr.Rate.ToString("0.00");
                dr[3] = "₱" + pr.TotalRegularWage.ToString("0.00");
                dr[4] = pr.overtime.RegularDay.hour;
                dr[5] = "₱" + pr.overtime.RegularDay.total.ToString("0.00");
                dr[6] = pr.overtime.SundayAndHoliday.hour;
                dr[7] = "₱" + pr.overtime.SundayAndHoliday.total.ToString("0.00");
                dr[8] = "₱" + pr.TotalAmount.ToString("0.00");
                dr[9] = "₱" + pr.Sss.ToString("0.00");
                dr[10] = "₱" + pr.PHIC.ToString("0.00");
                dr[11] = "₱" + pr.Withtax.ToString("0.00");
                dr[12] = "₱" + pr.HDMF.ToString("0.00");
                dr[13] = "₱" + pr.CashAdvance.ToString("0.00");
                dr[14] = "₱" + pr.ThirteenthMonthPay.ToString("0.00");
                dr[15] = "₱" + pr.Cola.ToString("0.00");
                dr[16] = "₱" + pr.CashBond.ToString("0.00");
                dr[17] = "₱" + pr.EmergencyAllowance.ToString("0.00");
                dr[18] = "₱" + pr.NetAmountPaid.ToString("0.00");
               dr[19] = "";

                dt.Rows.InsertAt(dr, i);
            }
            return dt;
        }

        #endregion

        #region Export

        public static DataTable GetList(char formOrigin)
        {
            if (formOrigin == 'g')
                return GetGuardsList();
            else if (formOrigin == 'c')
                return GetClientsList();
            else if (formOrigin == 'd')
                return GetDutyDetailList();
            else if (formOrigin == 's')
                return GetSalaryList();
            else return null;
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

            public void ExportToPDF(PdfPTable pdfTable, char formOrigin)
            {

                //Exporting to PDF
                String fileName = GetFileName(formOrigin);
                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "MSAMIS Reports";
                if (!Directory.Exists(filePath))
                    Directory.CreateDirectory(filePath);

                if (File.Exists(filePath + "\\" + fileName)) {
                    if (formOrigin == 'g' || formOrigin == 'c') { 
                        DialogResult x = rylui.RylMessageBox.ShowDialog(fileName + " already exists.\nDo you want to replace it?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (x == DialogResult.Yes)
                        {
                            File.Delete(filePath + "\\" + fileName);
                        }
                    } else File.Delete(filePath + "\\" + fileName);
            }

                using (FileStream stream = new FileStream(filePath + "\\" + fileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.LEGAL.Rotate(), 10f, 10f, 10f, 0f);
                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(pdfTable);
                    pdfDoc.Close();
                    stream.Close();
                }
            PrintPDF(filePath, fileName);
            }

        public void ExportPayslipPDF(int gid, int year, int month, int period)
        {
            var newLine = Environment.NewLine;
            PayrollReport pr = new PayrollReport(gid, year, month, period);
            var myfont = FontFactory.GetFont("Arial", 10, BaseColor.BLACK);
            var boldfont = FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK);
            var boldunderfont = FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK);
            boldunderfont.SetStyle(Font.UNDERLINE);
            //Content
            //Name
            String GuardFullName = pr.LN.ToUpper() + ", " + pr.FN.ToUpper() + " " + pr.MN[0].ToString().ToUpper() + "."; 
            Phrase Name = new Phrase(GuardFullName + newLine,boldfont);

            Chunk ChunkHeader1 = new Chunk("THIS IS TO CERTIFY THAT I'VE RECEIVED THE FULL AMOUNT OF MY SALARY FOR THE PERIOD OF ", myfont);
            Chunk ChunkHeader2 = new Chunk(Attendance.GetCurrentPayPeriod().ToString() + newLine, boldunderfont);
            Phrase Header = new Phrase();
            Header.Add(ChunkHeader1);
            Header.Add(ChunkHeader2);

            //deductions
            Phrase Ded = new Phrase("DEDUCTIONS:" + newLine, boldfont);
            Phrase SSS = new Phrase("SSS: ", myfont);
            Chunk ChunkSSS = new Chunk("₱" + pr.Sss + newLine);
            SSS.Add(ChunkSSS);
            Phrase PHIC = new Phrase("PHIC: ", myfont);
            Chunk ChunkPHIC = new Chunk("₱" + pr.PHIC + newLine);
            PHIC.Add(ChunkPHIC);
            Phrase TaxWith = new Phrase("Tax Withhold: ", myfont);
            Chunk ChunkTaxWith = new Chunk("₱" + pr.Withtax + newLine);
            TaxWith.Add(ChunkTaxWith);
            Phrase PagIbig = new Phrase("Pag-Ibig: ", myfont);
            Chunk ChunkPagIbig = new Chunk("₱" + pr.HDMF + newLine);
            PagIbig.Add(ChunkPagIbig);
            Phrase CashAdv = new Phrase("Cash Advance: ", myfont);
            Chunk ChunkCashAdv = new Chunk("₱" + pr.CashAdvance + newLine);
            CashAdv.Add(ChunkCashAdv);

            double TotalDedVal = pr.Sss + pr.PHIC + pr.Withtax + pr.HDMF + pr.CashAdvance; 
            Phrase TotalDed = new Phrase("Total Deductions: ", boldfont);
            Chunk ChunkTotalDed = new Chunk("₱" + TotalDedVal + newLine);
            TotalDed.Add(ChunkTotalDed);

            //Bonuses
            Phrase Bon = new Phrase("Bonuses:" + newLine, boldfont);
            Phrase ThirteenthMon = new Phrase("Thirteenth Month: ", myfont);
            Chunk Chunk13Mon = new Chunk("₱" + pr.ThirteenthMonthPay + newLine);
            ThirteenthMon.Add(Chunk13Mon);
            Phrase Cola = new Phrase("Cola: ", myfont);
            Chunk ChunkCola = new Chunk("₱" + pr.Cola + newLine);
            Cola.Add(ChunkCola);
            Phrase CashBond = new Phrase("Cash Bond: ", myfont);
            Chunk ChunkCashBond = new Chunk("₱" + pr.CashBond + newLine);
            CashBond.Add(ChunkCashBond);
            Phrase EmergencyAllow = new Phrase("Emergency Allowance: ", myfont);
            Chunk ChunkEmergencyAllow = new Chunk("₱" + pr.EmergencyAllowance + newLine);
            EmergencyAllow.Add(ChunkEmergencyAllow);

            double TotalBonVal = pr.ThirteenthMonthPay + pr.Cola + pr.CashBond + pr.EmergencyAllowance;
            Phrase TotalBon = new Phrase("Total Bonuses: ", boldfont);
            Chunk ChunkTotalBon = new Chunk("₱" + TotalBonVal + newLine);
            TotalBon.Add(ChunkTotalBon);

            Phrase Footer = new Phrase("COUNT YOUR MONEY BEFORE LEAVING" + newLine, boldfont);

            Phrase Total = new Phrase("Total Pay:" + newLine, boldfont);
            Chunk ChunkTotal = new Chunk("₱" + pr.NetAmountPaid + newLine);
            Total.Add(ChunkTotal);

            //Export Content

            String fileName = "Payslip" + pr.LN + pr.FN + pr.FN + Attendance.GetCurrentPayPeriod();
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "MSAMIS Reports";
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);

            if (File.Exists(filePath + "\\" + fileName))
            {
                DialogResult x = rylui.RylMessageBox.ShowDialog(fileName + " already exists.\nDo you want to replace it?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (x == DialogResult.Yes)
                {
                    File.Delete(filePath + "\\" + fileName);
                }
            }
            using (FileStream stream = new FileStream(filePath + "\\" + fileName, FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A8, 10f, 10f, 10f, 10f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(Name);
                pdfDoc.Add(Header);

                pdfDoc.Add(Ded);
                pdfDoc.Add(SSS);
                pdfDoc.Add(PHIC);
                pdfDoc.Add(TaxWith);
                pdfDoc.Add(PagIbig);
                pdfDoc.Add(CashAdv);
                pdfDoc.Add(TotalDed);

                pdfDoc.Add(Bon);
                pdfDoc.Add(ThirteenthMon);
                pdfDoc.Add(Cola);
                pdfDoc.Add(CashBond);
                pdfDoc.Add(EmergencyAllow);
                pdfDoc.Add(TotalBon);

                pdfDoc.Add(Footer);
                pdfDoc.Add(Total);
                pdfDoc.Close();
                stream.Close();
            }
        }
        
        public void PrintPDF(String filePath, String fileName)
        {
            String fileDir = filePath + "\\" + fileName; 
            foreach (string printer in PrinterSettings.InstalledPrinters)
                Console.WriteLine(printer);
            var printerSettings = new PrinterSettings();
            Console.WriteLine(string.Format("The default printer is: {0}", printerSettings.PrinterName));

            Console.WriteLine(printerSettings.PrintFileName);
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Open File Dialog";
            fdlg.InitialDirectory = fileDir;
            fdlg.RestoreDirectory = true;
            fdlg.ShowDialog();
            Console.WriteLine(fdlg.Title);
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                fileName = String.Copy(fdlg.FileName);
            }
            Console.WriteLine(fileName);

            PrintDialog printdg = new PrintDialog();
            PrintDocument pd_doc = new PrintDocument();
            printdg.ShowDialog();
            if (printdg.ShowDialog() == DialogResult.OK)
                pd_doc.Print();
        }

        public static String GetFileName(char o)
            {
                if (o == 'c')
                    return "ClientsSummaryReport_" + DateTime.Now.ToString("MMM-dd-yyyy") + ".pdf";
                else if (o == 'g')
                    return "GuardsSummaryReport_" + DateTime.Now.ToString("MMM-dd-yyyy") + ".pdf";
                else if (o == 'd')
                    return "SchedSummaryReport_" + DateTime.Now.ToString("MMM-dd-yyyy") + ".pdf";
                else if (o == 's')
                    return "SalaryReport_" + DateTime.Now.ToString("MMM-dd-yyyy") + ".pdf";
            return null;
            }

            public static float[] GetPDFFormat(char formOrigin)
            {
                if (formOrigin == 'c')
                    return new float[] { 120f, 50f, 250f, 135f, 135f, 80f };
                else if (formOrigin == 'g')
                    return new float[] { 120f, 50f, 90f, 80f, 90f, 90f, 90f };
                else if (formOrigin == 'd')
                    return new float[] { 130f, 130f, 80f, 230f, 60f, 60f, 60f, 120f, 120f };
            else if (formOrigin == 's')
                return new float[] { 30f, 10f, 10f, 10f, 8f,/*5*/ 8f, 8f, 8f, 10f, 8f,/*5*/  8f, 8f, 8f, 8f, 10f,/*5*/ 10f, 10f, 10f, 10f, 20f /*5*/ };
            return null;
        }
    }
}

