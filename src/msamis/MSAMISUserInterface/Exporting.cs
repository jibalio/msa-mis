using System;
using System.Drawing;
using System.Windows.Forms;

namespace MSAMISUserInterface {
    public partial class Exporting : Form {
        public MainForm Main;
        public char Mode;
        public Shadow Refer;
        int i = 0;

        public Exporting() {
            InitializeComponent();
            Opacity = 0;
        }

        private void Exporting_Load(object sender, EventArgs e) {
            Location = new Point(Location.X + 430, Location.Y + 210);
            label69.Text = "Exporting to PDF";
            label68.Text = "Please wait...";
            FadeInTMR.Start();
        }

        private void FadeInTMR_Tick(object sender, EventArgs e)
        {
            Opacity += 0.2;
            if (Opacity >= 1)
            {
                FadeInTMR.Stop();
                Export();
            }
        }

        private void FadeOutTMR_Tick(object sender, EventArgs e)
        {
            i++;
            if (i >= 150)
            {
                Opacity -= 0.2;
                if (Opacity <= 0)
                {
                    FadeOutTMR.Stop();
                    Close();
                }
            }

        }

        private void Exporting_FormClosing(object sender, FormClosingEventArgs e) {
            Refer.Hide();
        }

        private void Exporting_Shown(object sender, EventArgs e) { }

        private void Export() {
            var rp = new ReportsPreview();
            String fullFilePath;
            rp.FormatPDF(Mode);

            if (Mode == 'g') Main.GuardsLoadReport();
            else if (Mode == 'c') Main.ClientsLoadSummary();
            else if (Mode == 'd') Main.SchedLoadReport();
            else if (Mode == 's') Main.PayLoadReport();

            if (Mode == 'g' || Mode == 'c')
            {
                fullFilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MSAMIS Reports\\" + Reports.GetFileName(Mode);
                if (!System.IO.File.Exists(fullFilePath))
                {
                    label69.Text = "Something went wrong!";
                    label68.Text = "The file was not created. Please try again.";
                }
                else
                {
                    label69.Text = "Exporting Success!";
                    label68.Text = "Your file has been successfuly exported.";
                }
                FadeOutTMR.Start();
            }
            else
            {
                FadeOutTMR.Start();
            }
        }
    }
}