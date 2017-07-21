using System;
using System.Drawing;
using System.Windows.Forms;

namespace MSAMISUserInterface {
    public partial class LoginForm : Form {

        public LoginForm() {
            InitializeComponent();
            Opacity = 0;
            FadeTMR.Start();
        }

        #region Form Properties
        private void FadeTMR_Tick(object sender, EventArgs e) {
            Opacity += 0.2;
        }
        private void CloseBTN_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private bool _mouseDown;
        private Point _lastLocation;
        private void Form_MouseUp(object sender, MouseEventArgs e) {
            _mouseDown = false;
        }
        private void Form_MouseDown(object sender, MouseEventArgs e) {
            _mouseDown = true;
            _lastLocation = e.Location;
        }
        private void Form_MouseMove(object sender, MouseEventArgs e) {
            if (_mouseDown) {
                Location = new Point(
                    (Location.X - _lastLocation.X) + e.X, (Location.Y - _lastLocation.Y) + e.Y
                    );
                Update();
            }
        }
        private void PassPic_MouseDown(object sender, MouseEventArgs e) {
            PasswordBX.PasswordChar = '\0';
        }
        private void PassPic_MouseUp(object sender, MouseEventArgs e) {
            PasswordBX.PasswordChar = '●';
        }
        private void UsernameBX_KeyDown(object sender, KeyEventArgs e) {
            PasswordTLTP.Hide(PasswordBX);
            UsernameTLTP.Hide(UsernameBX);
            if (e.KeyValue.ToString().Equals("13")) {
                Login();
            }
        }
        private void PasswordBX_KeyDown(object sender, KeyEventArgs e) {
            PasswordTLTP.Hide(PasswordBX);
            UsernameTLTP.Hide(UsernameBX);
            if (e.KeyValue.ToString().Equals("13")) {
                Login();
            }

        }
        #endregion

        #region Backend Tester

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            if (keyData == (Keys.Control | Keys.B)) {
                Backend_Tester bt = new Backend_Tester();
                bt.ShowDialog();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion


        private void GEditDetailsBTN_Click(object sender, EventArgs e) {
            Login();
        }
        private void Login() {
            if (PasswordBX.Text.Equals("")) {
                PasswordTLTP.ToolTipTitle = "Password";
                PasswordTLTP.Show("Please enter your password", PasswordBX);
            } else if (UsernameBX.Text.Equals("")) {
                UsernameTLTP.ToolTipTitle = "Username";
                UsernameTLTP.Show("Please enter your username", UsernameBX);
            } else {
                var mf = new MainForm
                {
                    Opacity = 0,
                    Lf = this,
                    Location = new Point(Location.X - 50, Location.Y - 66),
                    User = UsernameBX.Text,
                };
                mf.Show();
                Hide();
            }
        }

        private void LLBL_Click(object sender, EventArgs e) {

        }
    }
}
