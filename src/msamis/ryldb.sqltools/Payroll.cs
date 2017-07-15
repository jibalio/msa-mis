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


        public static Hours GetHoursInCurrentPeriod (int GID) {
            DataTable HourIterationDataTable = SQLTools.ExecuteQuery(
                String.Format(@"
                    select atid, date, timein, timeout from attendance 
                    left join period on period.pid = attendance.pid
                    left join dutydetails on attendance.did = dutydetails.did
                    left join sduty_assignment on sduty_assignment.aid = dutydetails.aid
                    left join guards on guards.gid=sduty_assignment.gid
                    where guards.gid={0}
                    and period={1} 
                    and year={2}
                    and month={3}
            ;",GID, period.period, period.year, period.month));
            Hours HourIterationTotal = new Hours();
            foreach (DataRow DataRowIteration in HourIterationDataTable.Rows) {
                string ti = DataRowIteration["date"].ToString().Substring(0, 11) + DataRowIteration["TimeIn"].ToString();
                string to = DataRowIteration["date"].ToString().Substring(0, 10) + " " + DataRowIteration["TimeOut"].ToString();
                DateTime TimeInDateTime = DateTime.Parse(ti);
                DateTime TimeOutDateTime = DateTime.Parse(to);
                Hours asx = new Hours (TimeInDateTime, TimeOutDateTime, TimeInDateTime);
                HourIterationTotal.normal_day+= asx.normal_day;
                HourIterationTotal.normal_night += asx.normal_night;
                HourIterationTotal.holiday_day += asx.holiday_day;
                HourIterationTotal.holiday_night += asx.holiday_night;
                HourIterationTotal.total += asx.total;
                HourIterationTotal.SundayTotal += asx.SundayTotal;
            }
            return HourIterationTotal;
        }

        public static DataTable GetGuardsPayrollMain() {
            return SQLTools.ExecuteQuery(@"     select guards.gid, concat(ln,', ',fn,' ',mn) as name, client.name, (
                                                        CASE 
                                                            WHEN period.pid IS NULL
                                                            THEN 'Yes'
                                                            ELSE 'No Attendance Details Found'
                                                        END
                                                      ) AS attendance
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

        #region Compuations
        public class HourCostPair {
            double hour;
            double cost;
            double total;
            public HourCostPair (double hours, double basicpay) {
                this.hour = hours;
                this.cost = basicpay;
                this.total = hours * basicpay;
            }
        }

        public static Hours hour;
        public static void LoadData(int GID) {
            hour = GetHoursInCurrentPeriod(GID);
        }
        public static HourCostPair ComputeGrossPay() {
            HourCostPair e = new HourCostPair(hour.total.TotalHours, BasicPay);
            return e;
        }


        /* The bonuses for hours
         * 
         * Here are the following bonussess
         * 
         */
        public static HourCostPair ComputeOrdinaryNightDifferential() {
            throw new NotImplementedException();
            //HourCostPair e = new HourCostPair(hour.ordinary_night.TotalHours, BasicPay * 0.10);
            //return e;
        }
        public static HourCostPair ComputeHolidayNightDifferential() {
            HourCostPair e = new HourCostPair(hour.holiday_night.TotalHours, BasicPay * 0.10);
            return e;
        }

        
        #endregion






        public class Data {
            // Personal Data
            int GID;
            int NumberOfDependents;
            // Monthly Base
            double BasePay;
            


            // Sunday Premium pay = *30%


        }

        public class Defaults {
            
        }

        
    }

}
