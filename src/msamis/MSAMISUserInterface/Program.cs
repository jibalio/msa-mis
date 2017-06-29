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
            //Scheduling.AddUnassignmentRequest(1, new int[] { 342, 182, 33 }, Enumeration.ReportType.Accident, "k", DateTime.Now, "asd", "asd");
            //Scheduling.ApproveUnassignment(42);

           // Attendance.SaveAttendanceDetails(115,2,2,2017,123,999,123,123,"Holly");




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
}
