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
            String q = "select guards.gid, concat(ln,', ',fn,' ',mn) as Name, concat(streetno,', ',streetname,', ',brgy,', ',city) as Location,concat(timein, timeout, days) as schedule from sduty_assignment inner join request_assign on request_assign.RAID=sduty_assignment.RAID left join guards on guards.gid = sduty_assignment.gid left join dutydetails on dutydetails.aid = sduty_assignment.aid" +
               " where cid={0}";
             
            dgv.DataSource = SQLTools.ExecuteQuery(q, "name", "", "name asc", new String[] { "1" });
            //esrq.Text = SQLTools.ExecuteSingleResult(qor);

            // Scheduling.AddAssignmentRequest(2, "14-A", "Jacinto Extension", "Tibungco", "DavaoCity", DateTime.Now, DateTime.Now, 20);
        }
    }
}
