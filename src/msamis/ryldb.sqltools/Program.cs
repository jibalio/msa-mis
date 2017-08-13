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

 
           var q =  Payroll.GetNextPayday().ToString();
            MessageBox.Show(q, @"Backend says", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }



       
    }

}
