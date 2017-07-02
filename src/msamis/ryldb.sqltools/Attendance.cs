﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSAMISUserInterface {
    public class Attendance {

        // =============================================================================================
        //          STATIC METHODS / VARIABLES
        // =============================================================================================
        #region Statics
        
        public class Period {
            public int month = 0;
            public int period = 0;
            public int year = 0;
            public List<int> Mon = new List<int>(),
                      Tue = new List<int>(),
                      Wed = new List<int>(),
                      Thu = new List<int>(),
                      Fri = new List<int>(),
                      Sat = new List<int>(),
                      Sun = new List<int>();
            public Period (int period, int month, int year) {
                this.month = month;
                this.year = year;
                this.period = period;
                int s = (period==1 ? 1 : 16), 
                    e = (period==1 ? 15 : DateTime.DaysInMonth(year,month));
                for (int c = s; c <= e; c++) {
                    switch (new DateTime(year, month, c).DayOfWeek) {
                        case DayOfWeek.Monday: Mon.Add(c); break;
                        case DayOfWeek.Tuesday: Tue.Add(c); break;
                        case DayOfWeek.Wednesday: Wed.Add(c); break;
                        case DayOfWeek.Thursday: Thu.Add(c); break;
                        case DayOfWeek.Friday: Fri.Add(c); break;
                        case DayOfWeek.Saturday: Sat.Add(c); break;
                        case DayOfWeek.Sunday: Sun.Add(c); break;
                    }
                }
            }
        }

        // This method gets the current pay period.
        public static Period GetCurrentPayPeriod() {
            int m = 0, y = 0, p = 0;
            #region + Dates Setting
            int date = int.Parse(DateTime.Now.ToString("dd"));
            if (date >= 5 && date <= 19) {
                p = 1;
                m = GetMonth();
               y = GetYear();
            } else if ((date >= 1 && date <= 4)) {
                p = 2;
                m = (GetMonth() == 1 ? 12 : GetMonth());  // if January, prev month December
                y = (GetMonth() == 1 ? GetYear() - 1 : GetYear());
            } else if (date >= 20 && date <= 31) {
                p = 2;
                m = GetMonth();
                y = GetYear();
            }
            #endregion
            return new Period(p,m,y); ;
        }
        public static int GetMonth() {
            return int.Parse(DateTime.Now.ToString("MM"));
        }
        public static int GetYear() {
            return int.Parse(DateTime.Now.ToString("yyyy"));
        }

        public static int isHoliday() {
            return 0;
        }

        public static int isNight() {
            return 0;
        }

        #endregion


        


        // =============================================================================================
        //          INSTANCE METHODS / VARIABLES (nonstatic)
        // =============================================================================================
        #region Non-Statics
        
        public Period period;
        public int AID;
        public Attendance (int AID) {
            this.AID = AID;
            period = GetCurrentPayPeriod();
            Console.Write(period.period);
            DataTable x = SQLTools.ExecuteQuery("select did, mon,tue,wed,thu,fri,sat,sun from dutydetails where AID =" + AID);
            foreach (DataRow duties in x.Rows) {
                int did = int.Parse(duties["did"].ToString());
                 List<int> dutydates = new List<int>();
                if (duties["mon"].ToString() == "1") dutydates.AddRange(period.Mon);
                if (duties["tue"].ToString() == "1") dutydates.AddRange(period.Tue);
                if (duties["wed"].ToString() == "1") dutydates.AddRange(period.Wed);
                if (duties["thu"].ToString() == "1") dutydates.AddRange(period.Thu);
                if (duties["fri"].ToString() == "1") dutydates.AddRange(period.Fri);
                if (duties["sat"].ToString() == "1") dutydates.AddRange(period.Sat);
                if (duties["sun"].ToString() == "1") dutydates.AddRange(period.Sun);
                Stopwatch sw = new Stopwatch();
                sw.Start();
                foreach (int date in dutydates) {
                    DateTime d = new DateTime(period.year, period.month, date);
                    String q = @"INSERT INTO `msadb`.`attendance` (
                            `DID`, `month`, `period`, `year`, `date`, `hours`, `holiday`, `night`
                            ) VALUES (
                           '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}'
                            );";
                    q = String.Format(q, did, period.month, period.period, period.year, d.ToString("yyyy-MM-dd HH:mm:ss"), 0, isHoliday(), isNight());

                    try {
                        SQLTools.ExecuteNonQuery(q, false);
                    } catch { Console.WriteLine("SQLTools.cs >>> Warning: this record was already inserted. Ignored error."); }
                    
                }
                sw.Stop();
                TimeSpan ts = sw.Elapsed;
                Console.WriteLine("Finished inserting in " + ts.ToString("ss\\.ff") + " seconds");
                Console.WriteLine("Yes!");
            }
        }


        public DataTable GetAttendanceDetails() {
            String q = @"
                            select atid, did, DATE_FORMAT(date, '%Y-%m-%d') as Date, SUBSTRING(DAYNAME(DATE_FORMAT(date, '%Y-%m-%d')) FROM 1 FOR 3)  as day, hours, 
                            case holiday when 1 then 'Yes' when 0 then 'No' end as Holiday,
                            night as NightHours,
                            case when timein is null then 'Not set' when timein is not null then timein end as TimeIn,
                            case when timeout is null then 'Not set' when timeout is not null then timeout end as TimeOut
                            from attendance order by date asc;
                            ";
            return SQLTools.ExecuteQuery(q);
        }


        public int GetTimeElapsed(int ti, int to) {
            return (to - ti > 0 ? (to-ti) : 24+(to-ti));
        }

        public void SetAttendance(int AtID, int ti_hh, String ti_ampm, int to_hh, String to_ampm) {
           
            DateTime ti = new DateTime(); 
            DateTime to = new DateTime();
            int TimeElapsed = GetTimeElapsed(ti_hh, to_hh);
            // Call GetAttendanceDetails() to refresh list after saving.
            String q = @"UPDATE `msadb`.`attendance` SET `TimeIn`='"+ti.ToString("yyyy-MM-dd HH:mm:ss")+ @"',
                `TimeOut`='" + ti.ToString("yyyy-MM-dd HH:mm:ss") + @"' WHERE `AtID`='"+AtID+@"';
            ";
        }
























        public static void AddAttendanceDetails(int AID) {
            /*
             * Algorithm:
             * 1.) Add `time` entities for each `dutydetail` of guard
             *      1a: Get current month, year, and period.
             *      1b: Foreach duty.detail.day, get dates of day occurrence.
             *      1c: Insert for each duty detail.
             *      1d: Order by dates.
             */

            DataTable dutydetails = SQLTools.ExecuteQuery("select * from dutydetails where AID =" + AID);

            foreach (DataRow dutyrow in dutydetails.Rows) {

                



            }
        }


     

        public static void GetDaysInPeriod() {
            int month = GetMonth();
            Period p = GetCurrentPayPeriod();
            #region helpinfo - Days
            /*
             * Why, yes, I use lists for the days.
             * B4 u say anything, there is only a small performance difference
             * between list<generic> and int[].
             * Sampled from 60k size input:
                    Memory usage for arrays and Lists:
                        List generic:  6.172 MB
                        Integer array: 5.554 MB
                    Lookup performance for arrays and Lists:
                        List generic:  1043.4 ms
                        Integer array:  980.2 ms
                So, yes, I'm definitely gonna use lists here.
                See more: https://www.dotnetperls.com/array-memory
             */
            #endregion
            

        }

        //public static DataTable GetNecessaryAttendance(int AID) {




        //    throw new NotImplementedException();
        //}





        #region OLD

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



        
        

        /*
         * For testing only, input custom date.
         
        public static Period GetCurrentPayPeriod(int mo, int d, int year) {
            Period p = new Period();
            int date = d;
            if (date >= 5 && date <= 19) {
                p.period = 1;
                p.month = mo;
                p.year = year;
            } else if ((date >= 1 && date <= 4)) {
                p.period = 2;
                p.month = (mo == 1 ? 12 :mo);  // if January, prev month December
                p.year = (mo == 1 ? year-1 : year);
            } else if (date >= 20 && date <= 31) {
                p.period = 2;
                p.month = mo;
                p.year = year;
            }
            return p;
        }*/

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
        public static void SaveAttendanceDetails(int aid, int month, int period, int year, int normal_day, int normal_night, int holiday_day, int holiday_night, string certby) {
            int numduties = int.Parse(SQLTools.ExecuteSingleResult("select count(*) from sduty_assignment where astatus=" + Enumeration.DutyDetailStatus.Active + " and AID=" + aid));
            if (numduties == 0) {
                throw new NotAssignedToClientException("Attempted to add attendance to a guard without any active assignment details.");
            }

            bool hasRecord = (int.Parse(SQLTools.ExecuteSingleResult("select count(*) from time where aid=" + aid + " and month=" + month + " and period = " + period)) == 0);
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
                            aid, month, year, period));
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


        public static DataTable GetHours(int aid, int month, int year, int period) {
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
        #endregion
    }



    #endregion
}

