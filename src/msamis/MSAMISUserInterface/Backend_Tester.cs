using System;
using System.Windows.Forms;

namespace MSAMISUserInterface {
    public partial class Backend_Tester : Form {
        public Backend_Tester() {
            InitializeComponent();
        }

        //String querydt = "select rid, name, dataentry, case requesttype when 1 then 'Assignment' when 2 then 'Dismissal' end as type from msadb.request inner join client on request.cid=client.cid where dataentry='{0}";
        //DataTable dt = SQLTools.ExecuteQuery(q, "", "", "dataentry desc", new String[] {date.ToString("yyyy-MM-dd") });

        public DataGridView dv;
        private void Backend_Tester_Load(object sender, EventArgs e) {

            dgv.DataSource = dv.DataSource;
            //  dtq.Text = ;
            var p = Attendance.GetCurrentPayPeriod();

            var a = new Attendance(1, p.month, p.period, p.year);
            // dgv.DataSource = a.GetAttendance();
            // Attendance.Hours asd = a.GetAttendanceSummary();
            //  asd = asd;
            //esrq.Text = SQLTools.ExecuteSingleResult

            // Scheduling.AddAssignmentRequest(2, "14-A", "Jacinto Extension", "Tibungco", "DavaoCity", DateTime.Now, DateTime.Now, 20);
        }
    }
}