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
            Application.Run(new LoginForm());

            //Scheduling.AddAssignmentRequest(1, "StreetNo", "SteetName", "Brgy", "city", DateTime.Now, DateTime.Now, 23);
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
