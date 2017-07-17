using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*TODO: Fill hourcosts dictionary with basicpay * rates (stored in rates dictionary)
 * ComputeGrossPay ni na func.
 */
namespace MSAMISUserInterface {

    public class Payroll {

        public int GID;

        public static Dictionary<string, HourCostPair> hourcosts = new Dictionary<string, HourCostPair>();
        public static Dictionary<string, double> rates = new Dictionary<string, double>();
        public HourProcessor totalhours = new HourProcessor();
        public static double BasicPay = 340.00;
        public static Attendance.Period period = Attendance.GetCurrentPayPeriod();
        public static Hours total_old;
        
        #region Compuations

        public void ComputeGrossPay() {
            int gid = GID;
            HourCostPair hcp;
            foreach (string key in hourcosts.Keys) {
                hcp = new HourCostPair();
            }
        }

        public class HourCostPair {
            double hour;
            double cost;
            double total;
            public HourCostPair (double hours, double basicpay) {
                this.hour = hours;
                this.cost = basicpay;
                this.total = hours * basicpay;
            }
            public HourCostPair () {
                this.hour = 0;
                this.cost = 0;
                this.total = 0;
            }
        }

        

        public Payroll (int GID) {
            this.GID = GID;
            //Total = GetHoursInCurrentPeriod();
        }

        
        
        #endregion
       



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

        #region GetGuardsList Operations

        public void ComputeHours () {
            DataTable HourIterationDataTable = SQLTools.ExecuteQuery(
                String.Format(@"
                    select dutydetails.did, atid, date, timein, timeout, 
                    ti_hh, ti_mm, ti_period, to_hh, to_mm, to_period
                    from attendance 
                    left join period on period.pid = attendance.pid
                    left join dutydetails on attendance.did = dutydetails.did
                    left join sduty_assignment on sduty_assignment.aid = dutydetails.aid
                    left join guards on guards.gid=sduty_assignment.gid 
                    where period.period = "+period.period+" and month="+period.month+" and year="+period.year+@" 
            ;", GID, period.period, period.year, period.month));
            Hours HourIterationTotal = new Hours();
            foreach (DataRow dr in HourIterationDataTable.Rows) {
                

                string ti = dr["date"].ToString().Substring(0, 11) + dr["TimeIn"].ToString();
                string to = dr["date"].ToString().Substring(0, 10) + " " + dr["TimeOut"].ToString();
                DateTime TimeInDateTime = DateTime.Parse(ti);
                DateTime TimeOutDateTime = DateTime.Parse(to);

                string StartDutyString = dr["date"].ToString().Substring(0, 11) + " " + dr["ti_hh"] + ":" + dr["ti_mm"] + " " + dr["ti_period"];
                string EndDutyString = dr["date"].ToString().Substring(0, 11) + " " + dr["to_hh"] + ":" + dr["to_mm"] + " " + dr["to_period"];
                DateTime DutyStart = DateTime.Parse(StartDutyString);
                DateTime DutyEnd = DateTime.Parse(EndDutyString);
                HourProcessor hp = new HourProcessor(TimeInDateTime, TimeOutDateTime, DutyStart, DutyEnd);
                totalhours.Add(hp);
            }
        }
        public HourProcessor GetHours() {
            return totalhours;
        }
       

        public static DataTable GetGuardsPayrollMain() {
            return SQLTools.ExecuteQuery(@"     
                                                select guards.gid, concat(ln,', ',fn,' ',mn) as name, client.name, (
                                                        CASE 
                                                            WHEN (period.pid IS NOT NULL AND dutydetails.did IS NOT NULL)
                                                            THEN 'Yes'
                                                            ELSE 'No Attendance Details Found'
                                                        END
                                                      ) AS attendance, pstatus
                                                 from request
                                                left join client on client.cid=request.cid
                                                left join request_assign on request_assign.rid=request.rid
                                                left join sduty_assignment on sduty_assignment.raid=request_assign.raid
                                                left join guards on guards.gid=sduty_assignment.gid
                                                left join period on guards.gid=period.gid
												left join dutydetails on dutydetails.aid=sduty_assignment.aid
												left join payroll on guards.gid=payroll.gid
                                                where RequestType = 1 and
                                                ((period=1
                                                and month = 7
                                                and year = 2017) OR
                                                (period.pid is null))
                                                group by guards.gid
                                                ");
        }
        public static DataTable GetGuardsPayrollMinimal() {
            return SQLTools.ExecuteQuery(@"     select guards.gid, concat(ln,', ',fn,' ',mn) as name
                                                from request
                                                left join client on client.cid=request.cid
                                                left join request_assign on request_assign.rid=request.rid
                                                left join sduty_assignment on sduty_assignment.raid=request_assign.raid
                                                left join guards on guards.gid=sduty_assignment.gid
                                                left join period on guards.gid=period.gid
                                                where RequestType = 1 and
                                                ((period=1
                                                and month = 7
                                                and year = 2017) OR
                                                (pid is null))
                                                group by guards.gid
                                                ");
        }

#endregion New Region
      
        

        public class Defaults {
            
        }

        
    }

}
