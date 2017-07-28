using System;
using System.Drawing;
using System.Windows.Forms;

namespace MSAMISUserInterface {
    public partial class LoginForm : Form {

        public LoginForm() {
            InitializeComponent();
            Opacity = 0;
            ErrorLBL.Visible = false;
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
                Logins();
            }
        }
        private void PasswordBX_KeyDown(object sender, KeyEventArgs e) {
            PasswordTLTP.Hide(PasswordBX);
            UsernameTLTP.Hide(UsernameBX);
            if (e.KeyValue.ToString().Equals("13")) {
                Logins();
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
            Logins();
        }
        private void Logins() {
            if (PasswordBX.Text.Equals("")) {
                PasswordTLTP.ToolTipTitle = "Password";
                PasswordTLTP.Show("Please enter your password", PasswordBX);
            } else if (UsernameBX.Text.Equals("")) {
                UsernameTLTP.ToolTipTitle = "Username";
                UsernameTLTP.Show("Please enter your username", UsernameBX);
            } else {
                if (Login.Authenticate(UsernameBX.Text, PasswordBX.Text)) {
                    ErrorLBL.Visible = false;
                    PasswordBX.Clear();
                    UsernameBX.SelectAll();
                    var mf = new MainForm {
                        Opacity = 0,
                        Lf = this,
                        Location = new Point(Location.X - 50, Location.Y - 66),
                        User = UsernameBX.Text[0].ToString().ToUpper() + UsernameBX.Text.Substring(1).ToLower(),
                    };
                    mf.Show();
                    Hide();
                }
                else {
                    ErrorLBL.Visible = true;
                }
            }
        }

        private void LLBL_Click(object sender, EventArgs e) {

        }

        private void UsernameBX_Enter(object sender, EventArgs e) {
            UsernameBX.SelectAll();
        }

        private void PasswordBX_Enter(object sender, EventArgs e) {
            PasswordBX.SelectAll();
        }

        private void CloseBTN_MouseEnter(object sender, EventArgs e) {
            CloseBTN.ForeColor = Color.White;
        }

        private void CloseBTN_MouseLeave(object sender, EventArgs e) {
            CloseBTN.ForeColor = InfoPNL.BackColor;
        }
    }
}
