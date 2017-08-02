using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSAMISUserInterface;
using System.Windows.Forms;

namespace ryldb.sqltools {
    class Program {
        static void Main(string[] args) {
            SQLTools.EnableConsoleDebugging = true;
            Payroll.AddBasicPay(new DateTime(1970, 01, 01), new DateTime(1989, 07, 01), 89.00);
            Payroll.AddBasicPay(new DateTime(1989, 07, 01), new DateTime(1990, 11, 21), 89.00);
        }
    }
}
