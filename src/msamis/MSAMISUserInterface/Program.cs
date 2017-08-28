using System;
using System.Windows.Forms;

namespace MSAMISUserInterface {
    // Peak: 30mbs - July 14, 2017

    internal static class Program {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main() {
            //RylMessageBox.ShowDialog("Could not connect to the specified hosts", "Message Title", MessageBoxButtons.RetryCancel, MessageBoxIcon.Asterisk);

            //var q = Payroll.GetNextPayday().ToString();
            //rylui.RylMessageBox.ShowDialog(q, @"Backend says", MessageBoxButtons.OK, MessageBoxIcon.Information);

            AutoLoader.AutoImportSql(false, false);

            Data.InitData();
            Application.EnableVisualStyles();
            try {
                Application.SetCompatibleTextRenderingDefault(false);
            }
            catch (Exception) { }
            // while (true)
            // MessageBox.Show(Payroll.GetPreviousPayDay().ToString(), "Backend Says", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            Application.Run(new LoginForm());
            //  Scheduling.AddUnassignmentRequest(1, new int[] { 342, 182, 33 }, Enumeration.ReportType.Accident, "k", DateTime.Now, "asd", "asd");
            //Scheduling.ApproveUnassignment(42);
            // Scheduling.AddAssignment(1, new int[] { 1 });
        }
    }


    internal class ComboBoxItem {
        private readonly string displayValue;

        //Constructor
        public ComboBoxItem(string d, string h) {
            displayValue = d;
            ItemID = h;
        }

        //Accessor
        public string ItemID { get; }

        //Override ToString method
        public override string ToString() {
            return displayValue;
        }
    }

    internal class ComboBoxDays {
        private readonly string displayValue;

        //Constructor
        public ComboBoxDays(int m, int p, int y) {
            Month = m;
            Period = p;
            Year = y;

            var d = new DateTime(y, m, 1);
            displayValue = d.ToString("MMMM yyyy") + ", ";
            if (p == 1) displayValue += "First Period";
            else if (p == 2) displayValue += "Second Period";
        }

        //Accessor
        public int Month { get; }

        public int Period { get; }

        public int Year { get; }

        //Override ToString method
        public override string ToString() {
            return displayValue;
        }
    }


    internal class ComboBoxSss {
        //Constructor
        public ComboBoxSss(int m, string p, string y) {
            Id = m;
            Effective = p;
            Dissolved = y;
        }

        //Accessor
        public int Id { get; }

        public string Effective { get; }

        public string Dissolved { get; }

        //Override ToString method
        public override string ToString() {
            return Effective + " - " + Dissolved;
        }
    }
}