using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MSAMISUserInterface;
using System.Windows.Forms;
using rylui;

namespace ryldb.sqltools {
    class Program {
        static void Main(string[] args) {

            SQLTools.EnableConsoleDebugging = true;



        }



        public static void Message(string q) {
            rylui.RylMessageBox.ShowDialog(q, @"Backend says", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

}
