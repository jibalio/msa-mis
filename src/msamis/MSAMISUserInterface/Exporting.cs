using System;
using System.Drawing;
using System.Windows.Forms;

namespace MSAMISUserInterface {
    public partial class Exporting : Form {
        public MainForm Main;
        public char Mode;
        public Shadow Refer;

        public Exporting() {
            InitializeComponent();
            Opacity = 0;
        }

        private void Exporting_Load(object sender, EventArgs e) {
            Location = new Point(Location.X + 430, Location.Y + 210);
            FadeTMR.Start();
        }

        private void Exporting_FormClosing(object sender, FormClosingEventArgs e) {
            Refer.Hide();
        }

        private void FadeTMR_Tick(object sender, EventArgs e) {
            Opacity += 0.2;
            if (Opacity >= 1) {
                FadeTMR.Stop();
                Export();
            }
        }

        private void Exporting_Shown(object sender, EventArgs e) { }

        private void Export() {
            var rp = new ReportsPreview();
            rp.FormatPDF(Mode);

            if (Mode == 'g') Main.GuardsLoadReport();
            else if (Mode == 'c') Main.ClientsLoadSummary();
            else if (Mode == 'd') Main.SchedLoadReport();
            else if (Mode == 's') Main.PayLoadReport();
            Close();
        }
    }
}