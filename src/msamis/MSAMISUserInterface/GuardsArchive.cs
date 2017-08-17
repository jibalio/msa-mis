using System;
using System.Drawing;
using System.Windows.Forms;

namespace MSAMISUserInterface {
    public partial class GuardsArchive : Form {
        public Shadow Shadow;
        public int Gid;

        public GuardsArchive() {
            InitializeComponent();
            Opacity = 0;
        }

        private void FadeTMR_Tick(object sender, EventArgs e) {
            Opacity += 0.2;
            if (Opacity >= 1) FadeTMR.Stop();
        }

        private void GuardsArchive_Load(object sender, EventArgs e) {
            FadeTMR.Start();
            RefreshData();
        }

        private void RefreshData() {
            var dataTable = Archiver.GetGuardsBasicData(Gid);
            GIDLBL.Text = Gid.ToString();
            LNLBL.Text = dataTable.Rows[0]["fn"] + " " + dataTable.Rows[0]["mn"];
            LLBL.Text = dataTable.Rows[0]["ln"] + ", ";
            ContactNoLBL.Text = dataTable.Rows[0]["CellNo"].ToString();
            TelNoLBL.Text = dataTable.Rows[0]["TelNo"].ToString();
            ContactLBL.Text = dataTable.Rows[0]["EmergencyContact"].ToString();
            EmergencyLBL.Text = dataTable.Rows[0]["EmergencyNo"].ToString();
        }

        private void GuardsArchive_FormClosing(object sender, FormClosingEventArgs e) {
            Shadow.Close();
        }

        private void CloseBTN_MouseEnter(object sender, EventArgs e) {
            CloseBTN.ForeColor = Color.White;
        }

        private void CloseBTN_MouseLeave(object sender, EventArgs e) {
            CloseBTN.ForeColor = BackColor;
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            Close();
        }

        private void ViewInfoBTN_Click(object sender, EventArgs e) {
            var view = new GuardsView {
                Gid = Gid,
                Location = Location,
                Name = "Archived"
            };
            view.ShowDialog();
        }

        private void ViewAssBTN_Click(object sender, EventArgs e) {
            var view = new SchedViewDutyDetails {
                Gid = Gid,
                Location = Location,
                Name = "Archived"
            };
            view.ShowDialog();
        }

        private void ViewPayBTN_Click(object sender, EventArgs e) {
            var view = new PayrollEmployeeView {
                Gid = Gid,
                Location = Location,
                Name = "Archived"
            };
            view.ShowDialog();
        }
    }
}
