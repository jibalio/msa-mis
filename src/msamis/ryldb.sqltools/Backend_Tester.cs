using System;
using System.Windows.Forms;
using System.Data;

namespace MSAMISUserInterface {
    public partial class Backend_Tester : Form {


        public DataGridView dt;
        public Backend_Tester(DataGridView dt) {
            InitializeComponent();
            this.dt = dt;
            esrq.Text = "asd";
        }

        //String querydt = "select rid, name, dataentry, case requesttype when 1 then 'Assignment' when 2 then 'Dismissal' end as type from msadb.request inner join client on request.cid=client.cid where dataentry='{0}";
        //DataTable dt = SQLTools.ExecuteQuery(q, "", "", "dataentry desc", new String[] {date.ToString("yyyy-MM-dd") });


        private void Backend_Tester_Load(object sender, EventArgs e) {
            dgv.DataSource = dt;
        }
    }
}