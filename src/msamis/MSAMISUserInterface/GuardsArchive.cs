using System;
using System.Drawing;
using System.Windows.Forms;
using rylui;

namespace MSAMISUserInterface {
    public partial class GuardsArchive : Form {
        public int Gid;
        public Shadow Shadow;

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

        private const int CsDropshadow = 0x20000;

        protected override CreateParams CreateParams {
            get {
                var cp = base.CreateParams;
                cp.ClassStyle |= CsDropshadow;
                return cp;
            }
        }

        private static void ShowErrorBox(string name, string error) {
            RylMessageBox.ShowDialog("Please try again.\nIf the problem still persist, please contact your administrator. \n\n\nError Message: \n=============================\n" + error + "\n=============================\n", "Error Configuring " + name,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void RefreshData() {
            try {
                var dataTable = Archiver.GetGuardsBasicData(Gid);
                GIDLBL.Text = Gid.ToString();
                LNLBL.Text = dataTable.Rows[0]["fn"] + " " + dataTable.Rows[0]["mn"];
                LLBL.Text = dataTable.Rows[0]["ln"] + ", ";
                ContactNoLBL.Text = dataTable.Rows[0]["CellNo"].ToString();
                TelNoLBL.Text = dataTable.Rows[0]["TelNo"].ToString();
                ContactLBL.Text = dataTable.Rows[0]["EmergencyContact"].ToString();
                EmergencyLBL.Text = dataTable.Rows[0]["EmergencyNo"].ToString();
            }
            catch (Exception ex) {
                ShowErrorBox("Archive Guard - Loading", ex.Message);
            }
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
            var shadow = new Shadow {
                Size = new Size(900, 600),
                Location = Location,
                Transparency = 0.4
            };
            var view = new SchedViewAssHistory {
                Gid = Gid,
                Location = Location,
                Name = "Archived",
                GuardName = LLBL.Text + LNLBL.Text,
                Refer = shadow
            };
            shadow.Transparent();
            shadow.Form = view;
            shadow.ShowDialog();
        }

        private void ViewPayBTN_Click(object sender, EventArgs e) {
            var view = new PayrollEmployeeView {
                Gid = Gid,
                Location = Location,
                Name = "Archived",
                GuardName = LLBL.Text + LNLBL.Text
            };
            view.ShowDialog();
        }
    }
}