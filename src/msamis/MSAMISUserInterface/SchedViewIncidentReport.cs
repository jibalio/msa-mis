using System;
using System.Windows.Forms;

namespace MSAMISUserInterface {
    public partial class SchedViewIncidentReport : Form {
        public string Client;
        public int Rid;

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

            CertifiersGRD.DataSource = Scheduling.GetIncidentInvolved(Rid);
            CertifiersGRD.Columns[0].Width = 270;
            CertifiersGRD.Columns[1].Width = 100;
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            Close();
        }
    }
}