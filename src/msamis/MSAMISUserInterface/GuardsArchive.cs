using System;
using System.Drawing;
using System.Windows.Forms;

namespace MSAMISUserInterface {
    public partial class GuardsArchive : Form {
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
           // RefreshData();
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
            try {
                    var view = new GuardsView {
                        Gid = 0,
                        Location = Location,
                        Name = "Archived"
                    };
                view.ShowDialog();
            }
            catch (Exception) { }
        }

        private void ViewAssBTN_Click(object sender, EventArgs e) {
            var view = new SchedViewDutyDetails {
                Aid = 1,
                Gid = 1,
                Location = Location,
                Name = "Archived"
            };
            view.ShowDialog();
        }

        private void ViewPayBTN_Click(object sender, EventArgs e) {
            var view = new PayrollEmployeeView {
                Gid = 0,
                Location = Location,
                Name = "Archived"
            };
            view.ShowDialog();
        }
    }
}
