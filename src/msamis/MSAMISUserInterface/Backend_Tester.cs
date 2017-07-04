using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSAMISUserInterface {
    public partial class Backend_Tester : Form {
        public Backend_Tester() {
            InitializeComponent();
        }

        //String querydt = "select rid, name, dataentry, case requesttype when 1 then 'Assignment' when 2 then 'Dismissal' end as type from msadb.request inner join client on request.cid=client.cid where dataentry='{0}";
        //DataTable dt = SQLTools.ExecuteQuery(q, "", "", "dataentry desc", new String[] {date.ToString("yyyy-MM-dd") });


        private void Backend_Tester_Load(object sender, EventArgs e) {
            //  dtq.Text = ;
            Attendance a = new Attendance(1);
            dgv.DataSource = a.GetAttendance();
            //esrq.Text = SQLTools.ExecuteSingleResult(qor);

            // Scheduling.AddAssignmentRequest(2, "14-A", "Jacinto Extension", "Tibungco", "DavaoCity", DateTime.Now, DateTime.Now, 20);
        }
    }
}
