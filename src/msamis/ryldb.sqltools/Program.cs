using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSAMISUserInterface;

namespace ryldb.sqltools {
    class Program {
        static void Main(string[] args) {
            // Case 1: Pre TI / Pre TO 💯
            // Case 2: Pre TI / Exa TO
            // Case 3: Pre TI / Pos TO
            // Case 4: Exa TI / Pre TO
            // Case 5: Exa TI / Exa TO
            // Case 6: Exa TI / Pos TO
            // Case 7: Pos TI / Pre TO
            // Case 8: Pos TI / Exa TO
            // Case 9: Pos TI / Pos TO
            //string s = "01:00:00 AM";
            //string e = "05:00:00 AM";
            // Attendance.htod = true;
            //Attendance.htom = true;
            // DateTime start = Attendance.GetDateTime(s);
            //DateTime end = Attendance.GetDateTime(e);
            //Attendance.Hours x = Attendance.GetHours(start, end);
            //Holiday.InitHolidays();
            Payroll.GetGrossPay(306);
        }
    }
}
