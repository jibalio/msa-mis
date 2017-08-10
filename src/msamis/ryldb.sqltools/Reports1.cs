using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using System.Windows.Forms;

namespace MSAMISUserInterface
{
    public class Reports1
    {
        public SqlConnection conn;
        public String FilterText = "Search or filter";
        public String EmptyText = "";
        public static String ExtraQueryParams = "";
        public string summaryDate = "";


        public static void ExportToPDF(PdfPTable pdfTable, char formOrigin)
        {

            //Exporting to PDF
            String fileName = GetFileName(formOrigin);
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
                Document pdfDoc = new Document(PageSize.LEGAL.Rotate(), 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();
            }
        }


        public static String GetFileName(char o)
        {
            if (o == 'c')
                return "ClientsSummaryReport_" + DateTime.Now.ToString("MMM-dd-yyyy") + ".pdf";
            if (o == 'g')
                return "GuardsSummaryReport_" + DateTime.Now.ToString("MMM-dd-yyyy") + ".pdf";
            return null;
        }

        public static float[] GetPDFFormat(char formOrigin)
        {
            if (formOrigin == 'c')
                return new float[] { 120f, 50f, 250f, 135f, 135f, 80f };
            else if (formOrigin == 'g')
                //return guards format
                return null;
            return null;
        }

    }
}
