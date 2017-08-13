using System;
using System.Windows.Forms;

namespace rylui
{
    public partial class Base : System.Windows.Forms.Form
    {

        


        
        







        public Base()
        {
            InitializeComponent();
            Opacity = 0;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            FadeTMR.Start();
            rt.BackColor = Property.Colors.BackColor;
           
        }

        

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void TitleBar_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        MessageBoxButtons DialogType;
        public DialogResult ShowDialog(MessageBoxButtons m)
        {
            DialogType = m;
            return ShowDialog();
        }

        private const int CS_DROPSHADOW = 0x20000;
        protected override CreateParams CreateParams {
            get {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }








        /* 
         * BTN PARAMS
         *      case MessageBoxButtons.AbortRetryIgnore:
                case MessageBoxButtons.OK:
                case MessageBoxButtons.OKCancel:
                case MessageBoxButtons.RetryCancel:
                case MessageBoxButtons.YesNo:
                case MessageBoxButtons.YesNoCancel:
         */

        private void btn1_Click(object sender, EventArgs e)
        {
            DialogResult rtype = DialogResult.OK;
            switch (DialogType)
            {
                case MessageBoxButtons.AbortRetryIgnore:
                    rtype = DialogResult.Ignore; break;
                case MessageBoxButtons.OK:
                    rtype = DialogResult.OK; break;
                case MessageBoxButtons.OKCancel:
                    rtype = DialogResult.Cancel; break;
                case MessageBoxButtons.RetryCancel:
                    rtype = DialogResult.Cancel; break;
                case MessageBoxButtons.YesNo:
                    rtype = DialogResult.No; break;
                case MessageBoxButtons.YesNoCancel:
                    rtype = DialogResult.Cancel; break;
            }
            DialogResult = rtype;
            Close();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            DialogResult rtype = DialogResult.OK;
            switch (DialogType)
            {
                case MessageBoxButtons.AbortRetryIgnore:
                    rtype = DialogResult.Retry; break;
                case MessageBoxButtons.OKCancel:
                    rtype = DialogResult.OK; break;
                case MessageBoxButtons.RetryCancel:
                    rtype = DialogResult.Retry; break;
                case MessageBoxButtons.YesNo:
                    rtype = DialogResult.Yes; break;
                case MessageBoxButtons.YesNoCancel:
                    rtype = DialogResult.No; break;
            }
            DialogResult = rtype;
            Close();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            DialogResult rtype = DialogResult.OK;
            switch (DialogType)
            {
                case MessageBoxButtons.AbortRetryIgnore:
                    rtype = DialogResult.Abort; break;
                case MessageBoxButtons.YesNoCancel:
                    rtype = DialogResult.Yes; break;
            }
            DialogResult = rtype;
            Close();
        }

        private void FadeTMR_Tick(object sender, EventArgs e) {
            Opacity += 0.2;
            if (Opacity >= 1) FadeTMR.Stop();
        }
    }
}
