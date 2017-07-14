using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSAMISUserInterface {

    public class Payroll {

        

        public static double BasicPay = 340.00;
        public static Attendance.Period period = Attendance.GetCurrentPayPeriod();
        


        #region Basic Pay Operations

        public static string GetCurrentBasicPay() {
            return SQLTools.ExecuteSingleResult("select amount from basicpay where status = 1");
           
        }

        public static void AddBasicPay(DateTime start, double pay) {
            String paystring = pay.ToString("0000.##");
            String q;
            q = @"INSERT INTO `msadb`.`basicpay` (`amount`, `start`, `end`, `status`) VALUES ('{0}', '{1}', '{2}', '{3}');";
            string status;
            DateTime sta = new DateTime(start.Year, start.Month, start.Day);
            DateTime end = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            // Case 1: If karon gamiton
            if (sta < end) status = "0";
            else status = "1";
            q = String.Format(q, paystring, sta.ToString("yyyy-MM-dd"), "", status);
            SQLTools.ExecuteNonQuery(q);
        }

        public static DataTable GetBasicPayHistory () {
            String q = @"select * from basicpay order by status desc";
            return SQLTools.ExecuteQuery(q);
        }

        #endregion


        public static Attendance.Hours GetHoursForThisPeriod (int GID) {
            DataTable aid_dt = SQLTools.ExecuteQuery(
                String.Format(@"
                    select atid, timein, timeout from attendance 
                    left join period on period.pid = attendance.pid
                    left join dutydetails on attendance.did = dutydetails.did
                    left join sduty_assignment on sduty_assignment.aid = dutydetails.aid
                    left join guards on guards.gid=sduty_assignment.gid
                    where guards.gid={0}
                    and period={1} 
                    and year={2}
                    and month={3}
            ;",GID, period.period, period.year, period.month));
            Attendance.Hours HourIterationTotal = new Attendance.Hours();
            foreach (DataRow DataRowIteration in aid_dt.Rows) {
                DateTime TimeInDateTime = Attendance.GetDateTime_(DataRowIteration["TimeIn"].ToString());
                DateTime TimeOutDateTime = Attendance.GetDateTime_(DataRowIteration["TimeOut"].ToString());
                Attendance.Hours asx = Attendance.GetHours(TimeInDateTime, TimeOutDateTime);
                HourIterationTotal.normal_day+= asx.normal_day;
                HourIterationTotal.normal_night += asx.normal_night;
                HourIterationTotal.holiday_day += asx.holiday_day;
                HourIterationTotal.holiday_night += asx.holiday_night;
                HourIterationTotal.total += asx.total;
            }
            return HourIterationTotal;
        }

        

        
        



        public class PayrollData {


        }

        
    }

}
