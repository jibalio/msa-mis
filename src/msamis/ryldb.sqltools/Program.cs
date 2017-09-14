using MSAMISUserInterface;
using System.Windows.Forms;

namespace ryldb.sqltools {
    class Program {
        static void Main(string[] args) {

 
           var q =  Payroll.GetNextPayday().ToString();
            MessageBox.Show(q, @"Backend says", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }



       
    }

}
