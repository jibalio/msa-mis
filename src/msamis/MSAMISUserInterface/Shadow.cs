using System;
using System.Windows.Forms;

namespace MSAMISUserInterface {
    public partial class Shadow : Form {
        public Shadow() {
            InitializeComponent();
        }

        public Form Form { get; set; }

        private void FadeTMR_Tick(object sender, EventArgs e) {
            Opacity += 0.1;
            if (Opacity >= 0.6) {
                FadeTMR.Stop();
                Form.ShowDialog();
            }
        }

        public void Transparent() {
            Opacity = 0;
            FadeTMR.Start();
        }
    }
}