using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSAMISUserInterface {
   public class Attendance {
        /*
         *  Payrolls are calculated on the 16th-19th of the month (Period 2)
         *  and 1st-4th of the month (Period 1).
         *  Periods covered are the preceeding 15 days.
         *  So calculation dates are 
         *  (1-4) Period 2
         *  (16-19) Period 1
         *  Total 4 days of preparation.
         */

           

        public static string GetPayPeriodRange(int mo, int yyyy, int period) {
            DateTime Start = new DateTime(), End = new DateTime();
            if (period == 1) {
                Start = new DateTime(yyyy, mo, 1);
                End = new DateTime(yyyy, mo, 15);
            } else {
                Start = new DateTime(yyyy, mo, 16);
                End = new DateTime(yyyy, mo, DateTime.DaysInMonth(yyyy, mo));
            }
            return (Start.ToString("MMMM dd, yyyy") + " to " + End.ToString("MMMM dd, yyyy"));
        }

        public static int GetCurrentPayPeriod() {
            int date = int.Parse(DateTime.Now.ToString("dd"));
            if (date >= 5 && date <= 19) return 1;
            else if ((date>=1 && date<=4) || (date>=20 && date<=31)) return 2;
            else return 0;
        }

        /// <summary>
        /// Saves attendance details (hours worked) of a specific guard assignment. 
        /// If attendance details already exists, the record will be overwritten.
        /// </summary>
        /// <param name="aid">Assignment ID of Guard</param>
        /// <param name="normal_day">Hours worked (no occassion)</param>
        /// <param name="normal_night">Night hours worked (no occassion)</param>
        /// <param name="holiday_day">Hours worked (on holidays)</param>
        /// <param name="holiday_night">Hours worked night (on holidays)</param>
        /// <param name="certby">Client representative verification</param>
        public static void SaveAttendanceDetails (int aid, int month, int period, int year, int normal_day, int normal_night, int holiday_day, int holiday_night, string certby) {
            int numduties = int.Parse(SQLTools.ExecuteSingleResult("select count(*) from sduty_assignment where astatus="+Enumeration.DutyDetailStatus.Active+" and AID=" + aid));
            if (numduties==0) {
                throw new NotAssignedToClientException("Attempted to add attendance to a guard without any active assignment details.");
            }

            bool hasRecord = (int.Parse(SQLTools.ExecuteSingleResult("select count(*) from time where aid="+aid+" and month="+month+" and period = "+period))==0);
            String q = "";
            if (hasRecord) {
                q = @"
                        INSERT INTO `msadb`.`time` (
                        `AID`, `month`, `period`, `normal_day`, `normal_night`, `holiday_day`, `holiday_night`, `certifiedby`, `year`
                        ) VALUES (
                        '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}', '{8}'
                        );
                ";
                q = String.Format(q, aid, month, period, normal_day, normal_night, holiday_day, holiday_night, certby, year);
            } else {
                int tid = SQLTools.GetInt(String.Format(@"
                            select tid from time where AID = {0} AND month = {1} AND year = {2}  AND period = {3}",
                            aid,month,year,period));
                q = @"
                        UPDATE `msadb`.`time` SET 
                        `AID`='{0}', 
                        `month`='{1}', 
                        `period`='{2}', 
                        `normal_day`='{3}', 
                        `normal_night`='{4}', 
                        `holiday_day`='{5}', 
                        `holiday_night`='{6}', 
                        `certifiedby`='{7}' 
                        WHERE `TID`='{8}';
                        ";
                q = String.Format(q, aid, month, period, normal_day, normal_night, holiday_day, holiday_night, certby, tid);
            }
           
            
            SQLTools.ExecuteNonQuery(q);
        }


        public static DataTable GetHours (int aid, int month, int year, int period) {
            String q = @"select tid, normal_day, normal_night,holiday_day, holiday_night, certifiedby from time where 
                            AID = {0} 
                            AND month = {1} 
                            AND year = {2} 
                            AND period = {3}";
            return SQLTools.ExecuteQuery(String.Format(q, aid, month, year, period));
        }






        #region Exceptions
        public class NotAssignedToClientException : Exception {
            public NotAssignedToClientException(String message)
              : base(message) {
            }
        }
        #endregion


    }
}

