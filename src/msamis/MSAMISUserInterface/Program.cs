using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using rylui;
using ryldb.sqltools;

namespace MSAMISUserInterface {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            //RylMessageBox.ShowDialog("Could not connect to the specified hosts", "Message Title", MessageBoxButtons.RetryCancel, MessageBoxIcon.Asterisk);


             Application.EnableVisualStyles();
               Application.SetCompatibleTextRenderingDefault(false);
             AutoLoader.AutoImportSql(true, true);
            Application.Run(new LoginForm());
            //  Scheduling.AddUnassignmentRequest(1, new int[] { 342, 182, 33 }, Enumeration.ReportType.Accident, "k", DateTime.Now, "asd", "asd");
            //Scheduling.ApproveUnassignment(42);
            // Scheduling.AddAssignment(1, new int[] { 1 });






        }
    }
    class ComboBoxItem {
        String displayValue;
        string itemID;

        //Constructor
        public ComboBoxItem(string d, string h) {
            displayValue = d;
            itemID = h;
        }

        //Accessor
        public string ItemID {
            get {
                return itemID;
            }
        }

        //Override ToString method
        public override string ToString() {
            return displayValue;
        }
    }

    class ComboBoxDays {
        String displayValue;
        int month;
        int period;
        int year;

        //Constructor
        public ComboBoxDays(int m, int p, int y) {
            month = m;
            period = p;
            year = y;
            
            DateTime d = new DateTime(y, m, 1);
            displayValue = d.ToString("MMMM yyyy") + ", ";
            if (p == 1) displayValue += "First Period";
            else if (p == 2) displayValue += "Second Period";
        }

        //Accessor
        public int Month {
            get {
                return month;
            }
        }

        public int Period {
            get {
                return period;
            }
        }

        public int Year {
            get {
                return year;
            }
        }

        //Override ToString method
        public override string ToString() {
            return displayValue;
        }
    }
}
