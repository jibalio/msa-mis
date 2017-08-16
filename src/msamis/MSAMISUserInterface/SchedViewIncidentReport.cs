using System;
using System.Windows.Forms;

namespace MSAMISUserInterface {
    public partial class SchedViewIncidentReport : Form {
        public int Rid;
        public string Client;

        public SchedViewIncidentReport() {
            InitializeComponent();
            Opacity = 0;
        }

        private void FadeTMR_Tick(object sender, EventArgs e) {
            Opacity += 0.2;
            if (Opacity >= 1) FadeTMR.Stop();
        }

        private void SchedViewIncidentReport_Load(object sender, EventArgs e) {
            ClientLBL.Text = Client;
            LoadData();
            FadeTMR.Start();
        }

        private void LoadData() {
            var data = Scheduling.GetIncidentReport(Rid);

            TypeDateLBL.Text = "Type: " + data.Rows[0][0] + "          Event Date: " + data.Rows[0][1];
            LocationLBL.Text = data.Rows[0][2].ToString();
            DescriptionBX.Text = data.Rows[0][3].ToString();

            try {
                try {
                    if (!data.Rows[0][5].ToString().Equals("")) { 
                    Dependent1LBL.Text = AddRelationship(data.Rows[0][5].ToString(),
                        data.Rows[0][4].ToString());
                    Dependent2LBL.Text = AddRelationship(data.Rows[1][5].ToString(),
                        data.Rows[1][4].ToString());
                    Dependent3LBL.Text = AddRelationship(data.Rows[2][5].ToString(),
                        data.Rows[2][4].ToString());
                    Dependent4LBL.Text = AddRelationship(data.Rows[3][5].ToString(),
                        data.Rows[3][4].ToString());
                    Dependent5LBL.Text = AddRelationship(data.Rows[4][5].ToString(),
                        data.Rows[4][4].ToString());
                    }
                }
                catch { }
            }
            catch { }
        }

        private static string AddRelationship(string relationshipType, string lab) {
            return lab + " - "+relationshipType;
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
