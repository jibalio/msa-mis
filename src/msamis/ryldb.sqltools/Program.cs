using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSAMISUserInterface;

namespace ryldb.sqltools {
    class Program {
        static void Main(string[] args) {
            //Scheduling.AddAssignmentRequest(1, "s", "s", "c", "c", DateTime.Now, DateTime.Now, 2);
            //Scheduling.AddAssignment(int.Parse(SQLTools.getLastInsertedId("request","rid")), new int[] { 1, 2 });

            //Scheduling.AddDismissalRequest(2, new int[] { 1,2 }, Enumeration.ReportType.Complaint, "pc", DateTime.Now,"gmall", "Caught sneaking coffee to break room.");
            Scheduling.ApproveDismissal(27);
        }
    }
}
