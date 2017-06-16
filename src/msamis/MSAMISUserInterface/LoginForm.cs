using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ryldb.sqltools;

namespace MSAMISUserInterface {
    public partial class LoginForm : Form {
        public LoginForm() {
            InitializeComponent();
            this.Opacity = 0;
            FadeTMR.Start();
        }

        private void GEditDetailsBTN_Click(object sender, EventArgs e) {
            MainForm mf = new MainForm();
            mf.Opacity = 0;
            mf.lf = this;
            mf.Show();

            this.Hide();
           
        }

        private void FadeTMR_Tick(object sender, EventArgs e) {
            this.Opacity += 0.2;
            TimeLBL.Text = DateTime.Now.ToString();
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        bool mouseDown;
        Point lastLocation;

        private void Form_MouseUp(object sender, MouseEventArgs e) {
            mouseDown = false;
        }
        private void Form_MouseDown(object sender, MouseEventArgs e) {
            mouseDown = true;
            lastLocation = e.Location;
        }
        private void Form_MouseMove(object sender, MouseEventArgs e) {
            if (mouseDown) {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y
                    );
                this.Update();
            }
        }



        /*
         * Important: Para mag coordinate atong db's.
         * Returns an error if database if not updated (if ever gi edit ni Ler).
         * Opens browser, to download updated sql file.
         */
        private void LoginForm_Load(object sender, EventArgs e) {
            try {
                SQLTools.VersionCheck();
            } catch (Exception) {
                DialogResult f = MessageBox.Show("Database has been edited by Leryc. Do not make changes to DB b4 downloading updated version. Do you want to download the sql file now?", "New Database Update!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (f == DialogResult.Yes) {
                    System.Diagnostics.Process.Start("http://www.leryc.droppages.com/ryldb");
                }
                Application.Exit();
            }
            
        }
    }
}
