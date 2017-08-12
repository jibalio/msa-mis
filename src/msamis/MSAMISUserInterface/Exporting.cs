using System.Drawing;
using System.Windows.Forms;


namespace MSAMISUserInterface {
    public partial class Exporting : Form {
        public Shadow Refer;
        public char Mode;
        public MainForm Main;

        public Exporting() {
            InitializeComponent();
            Opacity = 0;
        }

        private void Exporting_Load(object sender, System.EventArgs e) {
            Location = new Point(Location.X + 430, Location.Y + 210);
            FadeTMR.Start();
        }

        private void Exporting_FormClosing(object sender, FormClosingEventArgs e) {
            Refer.Hide();
        }

        private void FadeTMR_Tick(object sender, System.EventArgs e) {
            Opacity += 0.2;
            if (Opacity >= 1) { FadeTMR.Stop(); Export(); }
        }

        private void Exporting_Shown(object sender, System.EventArgs e) {
            
        }

        private void Export() {
            var rp = new ReportsPreview();
            var r = new Reports();
            r.ExportToPDF(rp.FormatPDF(Mode, Mode), Mode);

            if (Mode == 'g') Main.GuardsLoadReport();
            else if (Mode == 'c') Main.ClientsLoadSummary();
            else if (Mode == 'd') Main.SchedLoadReport();
            else if (Mode == 's') Main.PayLoadReport();
            Close();
        }
    }
}
