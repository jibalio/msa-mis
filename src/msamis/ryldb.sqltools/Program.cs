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
            //Scheduling.AddAssignment(int.Parse(SQLTools.getLastInsertedId("request","rid")), new int[] { 1, 2,3,4,5,6,7,8,9,10 });
            //Scheduling.AddDutyDetail(61, "09", "23", "PM", "10", "30", "PM", new Scheduling.Days(true, true, true, true, true, false, false));
            //Scheduling.AddDismissalRequest(2, new int[] { 1,2 }, Enumeration.ReportType.Complaint, "pc", DateTime.Now,"gmall", "Caught sneaking coffee to break room.");
            //Scheduling.ApproveDismissal(27);
            //Scheduling.AddDismissalRequest(13, new int[] { 8 }, 1,"",DateTime.Now,"gmall","awd");
            //Scheduling.ApproveDismissal(30);
            //Scheduling.AddDutyDetail(71, "10", "30", "PM", "11", "30", "PM", new Scheduling.Days(true, true, true, false, true, true, true));
            Scheduling.AddUnassignmentRequest(2,new int[] { 146}, Enumeration.ReportType.Complaint, "pc", DateTime.Now, "gmall", "Caught sneaking coffee to break room.");
        }
    }
}
