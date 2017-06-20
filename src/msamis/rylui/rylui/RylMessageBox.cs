using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rylui
{
    public class RylMessageBox
    {
        
        public static DialogResult ShowDialog (String text)
        {
            Base form = new Base();
            form.iconbox.Visible = false;
            form.btn1.Text = Property.ButtonText.OK;
            form.rt.Text = text;
            form.btn2.Visible = false;
            form.btn3.Visible = false;
            form.rt.Size = Property.TextProperties.SizeNoIcon;
            form.rt.Location = Property.TextProperties.LocationNoIcon;
            form.btn1.BackColor = Property.Colors.ButtonBlue;
            return form.ShowDialog();
        }
        public static DialogResult ShowDialog(String text, String title)
        {
            Base form = new Base();
            form.btn1.Text = Property.ButtonText.OK;
            form.rt.Text = text;
            form.iconbox.Visible = false;
            form.btn2.Visible = false;
            form.btn3.Visible = false;
            form.Title.Text = title;
            form.iconbox.Visible = false;
            form.rt.Size = Property.TextProperties.SizeNoIcon;
            form.rt.Location = Property.TextProperties.LocationNoIcon;
            form.btn1.BackColor = Property.Colors.ButtonBlue;
            return form.ShowDialog(); 
        }

        public static DialogResult ShowDialog(String text, String title, MessageBoxButtons mbutton)
        {
            Base form = new Base();
            form.iconbox.Visible = false;
            form.btn1.Text = Property.ButtonText.OK;
            form.rt.Text = text;
            form.iconbox.Visible = false;
            form.Title.Text = title;
            form.rt.Size = Property.TextProperties.SizeNoIcon;
            form.rt.Location = Property.TextProperties.LocationNoIcon;
            form.btn1.BackColor = Property.Colors.ButtonRed;
            switch (mbutton)
            {
                case MessageBoxButtons.AbortRetryIgnore:
                    form.btn1.Text = "Ignore";
                    form.btn2.Text = "Retry";
                    form.btn3.Text = "Abort";
                    break;
                case MessageBoxButtons.OK:
                    form.btn3.Text = "OK";
                    form.btn2.Visible = false;
                    form.btn1.Visible = false;
                    break;
                case MessageBoxButtons.OKCancel:
                    form.btn1.Text = "Cancel";
                    form.btn2.Text = "OK";
                    form.btn2.Visible = false;
                    break;
                case MessageBoxButtons.RetryCancel:
                    form.btn1.Text = "Cancel";
                    form.btn3.Text = "Retry";
                    form.btn2.Visible = false;
                    break;
                case MessageBoxButtons.YesNo:
                    form.btn1.Text = "No";
                    form.btn3.Text = "Yes";
                    form.btn2.Visible = false;
                    break;
                case MessageBoxButtons.YesNoCancel:
                    form.btn1.Text = "Cancel";
                    form.btn2.Text = "No";
                    form.btn3.Text = "Yes";
                    break;

            }
            return form.ShowDialog(mbutton);
        }


        public static DialogResult ShowDialog(String text, String title, MessageBoxButtons mbutton, MessageBoxIcon micon)
        {
            
            Base form = new Base();
            form.rt.Text = text;
            form.Title.Text = title;
            
            form.btn1.BackColor = Property.Colors.ButtonRed;
            #region + MessageButtonParsers
            switch (mbutton)
            {
                case MessageBoxButtons.AbortRetryIgnore:
                    form.btn1.Text = "Ignore";
                    form.btn2.Text = "Retry";
                    form.btn3.Text = "Abort";
                    form.btn3.BackColor = Property.Colors.ButtonRed;
                    break;
                case MessageBoxButtons.OK:
                    form.btn3.Text = "OK";
                    form.btn2.Visible = false;
                    form.btn3.Visible = false;
                    break;
                case MessageBoxButtons.OKCancel:
                    form.btn1.Text = "Cancel";
                    form.btn2.Text = "OK";
                    form.btn3.Visible = false;
                    form.btn1.BackColor = Property.Colors.ButtonRed;
                    break;
                case MessageBoxButtons.RetryCancel:
                    form.btn1.Text = "Cancel";
                    form.btn2.Text = "Retry";
                    form.btn3.Visible = false;
                    form.btn1.BackColor = Property.Colors.ButtonRed;
                    break;
                case MessageBoxButtons.YesNo:
                    form.btn1.Text = "No";
                    form.btn2.Text = "Yes";
                    form.btn3.Visible = false;
                    break;
                case MessageBoxButtons.YesNoCancel:
                    form.btn2.Text = "Cancel";
                    form.btn1.Text = "No";
                    form.btn3.Text = "Yes";
                    form.btn1.BackColor = Property.Colors.ButtonRed;
                    break;

            }
            #endregion
            
            
            #region + MessageIconParsers
            switch (micon)
            {
                case MessageBoxIcon.Asterisk:
                    form.iconbox.BackgroundImage = Properties.Resources.asterisk;
                    break;
                case MessageBoxIcon.Error:
                    form.iconbox.BackgroundImage = Properties.Resources.Error;
                    break;
                case MessageBoxIcon.Exclamation:
                    form.iconbox.BackgroundImage = Properties.Resources.Exclamation;
                    break;
                case MessageBoxIcon.Question:
                    form.iconbox.BackgroundImage = Properties.Resources.Question;
                    break;
                // Add for other icons
                default:
                    form.iconbox.BackgroundImage = Properties.Resources.Question;
                    break;
            }
            #endregion
            return form.ShowDialog(mbutton);
        }

        
    }


   
}
