using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rylui
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DialogResult a = RylMessageBox.ShowDialog("An error occurred", "Error", MessageBoxButtons.AbortRetryIgnore);

            
            MessageBox.Show("You pressed \"" + a.ToString() + "\"");
        }
    }
}
