using ryldb.sqltools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSAMISUserInterface {
    public class Attendance {

        public static List<Holiday> holly = new List<Holiday>();
        private void init() {
            holly.Add(new Holiday(7, 11));
        }


        // =============================================================================================
        //          STATIC METHODS / VARIABLES
        // =============================================================================================
        #region Statics

        public class Period {
            public List<int> Mon = new List<int>(),
                     Tue = new List<int>(),
                     Wed = new List<int>(),
                     Thu = new List<int>(),
                     Fri = new List<int>(),
                     Sat = new List<int>(),
                     Sun = new List<int>();
            public int month = 0;
            public int period = 0;
            public int year = 0;

            public Period(int AID, int period, int month, int year) {
                this.period = period;
                this.month = month;
                this.year = year;
                
                
                int s = (period == 1 ? 1 : 16),
                    e = (period == 1 ? 15 : DateTime.DaysInMonth(year, month));
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
        public static Period GetCurrentPayPeriod(int AID) {
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
            return new Period(AID, p, m, y); ;
        }
        public static int GetMonth() {
            return int.Parse(DateTime.Now.ToString("MM"));
        }
        public static int GetYear() {
            return int.Parse(DateTime.Now.ToString("yyyy"));
        }

        

        public static int isNight() {
            return 0;
        }

        #endregion

        public static DataTable GetPeriods(int AID) {
            return SQLTools.ExecuteQuery(@"SELECT month, period, year
                                        FROM msadb.attendance 
                                        left join dutydetails
                                        on attendance.did=dutydetails.did 
                                        where AID = "+AID+@"
                                        group by month,period,year order by year desc, month desc, period desc;");
        }

        public class Hours {
            public TimeSpan total = new TimeSpan(0,0,0);
            public TimeSpan holiday_day = new TimeSpan(0, 0, 0);
            public TimeSpan holiday_night = new TimeSpan(0, 0, 0);
            public TimeSpan normal_day = new TimeSpan(0, 0, 0);
            public TimeSpan normal_night = new TimeSpan(0, 0, 0);
            public string GetHolidayDay() {
                return holiday_day.ToString(@"hh\:mm");
            }
            public string GetHolidayNight() {
                return holiday_night.ToString(@"hh\:mm");
            }
            public string GetNormalDay() {
                return normal_day.ToString(@"hh\:mm");
            }
            public string GetNormalNight() {
                return normal_night.ToString(@"hh\:mm");
            }
            public string GetTotal() {
                return total.ToString(@"hh\:mm");
            }
        }
        public Hours GetAttendanceSummary() {
            Hours h = new Hours();
            foreach (Hours x in hourlist) {
                h.holiday_day += x.holiday_day;
                h.holiday_night += x.holiday_night;
                h.normal_day += x.normal_day;
                h.normal_night += x.normal_night;
                h.total += x.total;
            }
            return h;

            
        }



        // =============================================================================================
        //          INSTANCE METHODS / VARIABLES (nonstatic)
        // =============================================================================================
        #region Non-Statics

        public Period period;
        public int AID;
        public Attendance(int AID) {
            this.AID = AID;
            period = GetCurrentPayPeriod(AID);
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
                DateTime zero = new DateTime(1, 1, 1, 0, 0, 0);
                foreach (int date in dutydates) {
                    DateTime d = new DateTime(period.year, period.month, date);
                    String q = @"INSERT IGNORE INTO `msadb`.`attendance` (
                            `DID`, `month`, `period`, `year`, `date`, `hours`, `holiday`, `night`,`overtime`
                            ) VALUES (
                           '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}'
                            );";
                    q = String.Format(q, did, period.month, period.period, period.year, d.ToString("yyyy-MM-dd HH:mm:ss"), "00:00", "00:00", "00:00", "00:00");

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


        public DataTable GetAttendance() {
            String q = @"
                        select atid, dutydetails.did, DATE_FORMAT(date, '%Y-%m-%d') as Date, SUBSTRING(DAYNAME(DATE_FORMAT(date, '%Y-%m-%d')) FROM 1 FOR 3)  as day, 
							concat (ti_hh,':',ti_mm,' ',ti_period, ' - ',to_hh,':',to_mm,' ',to_period) as Schedule,
                            timein,
                           TimeOut, hours, 
                            night as NightHours, overtime,
                            case holiday when 1 then 'Yes' when 0 then 'No' end as Holiday
                            from attendance
                            left join dutydetails 
                            on dutydetails.did=attendance.did
                            order by date asc;
                            ";
            DataTable d =  SQLTools.ExecuteQuery(q);
            foreach  (DataRow f in d.Rows) {
                hourlist.Add(GetHours(DateTime.Parse(f["TimeIn"].ToString()), DateTime.Parse(f["TimeOut"].ToString())));
            }
            return d;
        }

        public DataTable GetAttendance(int month, int period, int year) {
            String q = @"
                           select atid, dutydetails.did, 
							CONCAT((DATE_FORMAT(date, '%d')), ' / ' ,
							(CONCAT (ti_hh,':',ti_mm,' ',SUBSTRING(ti_period,1,1), '-',to_hh,':',to_mm,SUBSTRING(to_period,1,1)))) as Schedule,
                            concat( SUBSTRING(timein,1,7), '-' ,SUBSTRING(timeout,1,7)) as timein,  hours, 
                            night as NightHours, overtime,
                            case holiday when 1 then 'Yes' when 0 then 'No' end as Holiday
                            from attendance
                            left join dutydetails 
                            on dutydetails.did=attendance.did
                            where month='{0}' and period = '{1}' and year = '{2}'
                            order by date asc;
                            ";
            q = String.Format(q, month, period, year);
            return SQLTools.ExecuteQuery(q);
        }


        public int GetTimeElapsed(int ti, int to) {
            return (to - ti > 0 ? (to - ti) : 24 + (to - ti));
        }

        public void SetCertifiedBy(int DID, String cert) {
            String q = @"UPDATE `msadb`.`attendance` SET `certby`='" + cert + "' WHERE `DID`='" + DID + "';";
            SQLTools.ExecuteNonQuery(q);
        }

        public void SetAttendance(int AtID, int ti_hh, int ti_mm, String ti_ampm, int to_hh, int to_mm, String to_ampm) {
            int did = SQLTools.GetInt("select did from attendance where AtID=" + AtID);
            TimeSpan ts = GetTimeDiff(ti_hh, ti_mm, ti_ampm, to_hh, to_mm, to_ampm);
            DateTime ti = GetDateTime(ti_hh, ti_mm, ti_ampm);
            DateTime to = GetDateTime(to_hh, to_mm, to_ampm);

            //compare with tama na sched for overtime
            DataRow dt = SQLTools.ExecuteQuery("select * from dutydetails where DID=" + did).Rows[0];
            TimeSpan overtime = GetOvertime(int.Parse(dt["to_hh"].ToString()), int.Parse(dt["to_mm"].ToString()), dt["to_period"].ToString(), to_hh, to_mm, to_ampm);
            DateTime start_night = GetDateTime(10, 00, "PM");
            DateTime end_night = GetDateTime(6, 0, "AM").AddDays(1);
            Hours nhe = GetHours(ti, to);
            hourlist.Add(nhe);
            double nh = nhe.normal_night.TotalMinutes;
            String nhs = ((int)nh / 60).ToString("00") + ":" + ((int)nh % 60).ToString("00");
            String q = @"
                        UPDATE `msadb`.`attendance` SET `TimeIn`='{1}', `TimeOut`='{2}', `hours`='{3}', `overtime`='{4}', `night`='{5}' WHERE `AtID`='{0}';";
            q = String.Format(q, AtID, ti.ToString("hh:mm tt"), to.ToString("hh:mm tt"), ts.ToString(@"hh\:mm"), overtime.ToString(@"hh\:mm"), nhs);
            SQLTools.ExecuteNonQuery(q);
        }

        public List<Hours> hourlist = new List<Hours>();

        

        //==================================================================================
        //          DATA TESTING
        //==================================================================================

        public static bool htod = false;
        public static bool htom = false;
        public static bool IsHolidayToday(DateTime e) {
            return htod;
            if (holly.Contains(new Holiday(e.Month, e.Day))) {
                return true;
            } else return false;
        }
        public static bool IsHolidayTomorrow(DateTime e) {
            return htom;
            if (holly.Contains(new Holiday(e.Month, e.Day))) {
                return true;
            } else return false;
        }

        public static Hours GetHours(DateTime actuals, DateTime actuale) {
            Hours h = new Hours();
            DateTime NightStart = new DateTime(1, 1, 1, 22, 00, 00);
            DateTime NightEnd = new DateTime(1, 1, 1, 6, 00, 00);
            DateTime Midnight = new DateTime(1,1,2,0,0,0); DateTime maxStart; DateTime minEnd; DateTime minStart; DateTime maxEnd;
            // if not same
            if (actuals > actuale) {
                #region + OLD
                /*actuale = actuale.AddDays(1);
                NightEnd = NightEnd.AddDays(1);
                DateTime maxStart = actuals < NightStart ? NightStart : actuals;
                DateTime minEnd = actuale < NightEnd ? actuale : NightEnd;
                TimeSpan interval = minEnd - maxStart;
                double nh = interval > TimeSpan.FromSeconds(0) ? interval.TotalMinutes : 0;
                // return nh;*/
                #endregion
                actuale = actuale.AddDays(1);
                NightEnd = NightEnd.AddDays(1);
                // First Half
                // 1: Max Selection, either nighstart or actuals
                    maxStart = actuals < NightStart ? NightStart : actuals;
                    minStart = actuals < NightStart ? actuals : NightStart;
                    TimeSpan d1_night = Midnight - maxStart;
                    TimeSpan d1_day = (NightStart - minStart > TimeSpan.FromSeconds(0)) ? NightStart-minStart : new TimeSpan(0,0,0);
                // Second Half
                    minEnd = actuale < NightEnd ? actuale : NightEnd;
                    maxEnd = actuale > NightEnd ? actuale : NightEnd;
                    TimeSpan d2_night = minEnd - Midnight;
                    TimeSpan d2_day = (maxEnd - NightEnd > TimeSpan.FromSeconds(0)) ? maxEnd - NightEnd : new TimeSpan(0, 0, 0);
                // Check if today is holiday.
                if (IsHolidayToday(actuals)) {
                    h.holiday_night += d1_night;
                    h.holiday_day += d1_day;
                } else {
                    h.normal_night += d1_night;
                    h.normal_day += d1_day;
                }
                //Check if tomorrow is holiday.
                if (IsHolidayTomorrow(actuals)) {
                    h.holiday_night += d2_night;
                    h.holiday_day += d2_day;
                } else {
                    h.normal_night += d2_night;
                    h.normal_day += d2_day;
                }
            } else {
                // if same day
                NightEnd = new DateTime(1, 1, 1, 6, 00, 00);
                maxStart = actuals < NightStart ? actuals : NightStart;
                minStart = actuals > NightStart ? actuals : NightStart;
                minEnd = actuale < NightEnd ? actuale : NightEnd;
                maxEnd = actuale > NightEnd ? actuale : NightEnd;
                if (IsHolidayToday(actuals)) {
                    h.holiday_night = (minEnd - maxStart) > TimeSpan.FromSeconds(0) ? minEnd - maxStart : new TimeSpan(0, 0, 0);
                    h.holiday_day = (maxEnd - actuals) > TimeSpan.FromSeconds(0) ? maxEnd - actuals : new TimeSpan(0, 0, 0);
                    h.holiday_day = (NightStart - minStart) > TimeSpan.FromSeconds(0) ? maxEnd - actuals : new TimeSpan(0, 0, 0);
                } else {
                    h.normal_night = (minEnd - maxStart) > TimeSpan.FromSeconds(0) ? minEnd - maxStart : new TimeSpan(0, 0, 0);
                    h.normal_day = (maxEnd - actuals) > TimeSpan.FromSeconds(0) ? maxEnd - actuals : new TimeSpan(0, 0, 0);
                    h.normal_day = (NightStart - minStart) > TimeSpan.FromSeconds(0) ? maxEnd - actuals : new TimeSpan(0, 0, 0);
                }
            }
            return h;
        }

        


        public static TimeSpan GetOvertime(int dbhour, int dbmin, String dbampm, int actualo, int actualomin, String actualoampm) {
            // TO DO: if early, no overtime.
            var t1 = "01/01/0001 " + dbhour.ToString("00") + ":" + dbmin.ToString("00") + ":00 " + dbampm;
            var t2 = "01/01/0001 " + actualo.ToString("00") + ":" + actualomin.ToString("00") + ":00 " + actualoampm;
            var time1 = DateTime.ParseExact(t1, "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
            var time2 = DateTime.ParseExact(t2, "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
            if (time2 < time1) {
                Console.WriteLine("Date is on Next Day!");
                time2 = time2.AddDays(1);
            } else {
                Console.WriteLine("same day");
            }
            TimeSpan ts = time2 - time1;
            if (ts.TotalHours > 8) {
                return new TimeSpan(0, 0, 0);
            } else {
                return ts;
            }
        }
        public static TimeSpan GetTimeDiff(int t1hour, int t1min, String t1ampm, int t2hour, int t2min, String t2ampm) {

            var t1 = "01/01/0001 " + t1hour.ToString("00") + ":" + t1min.ToString("00") + ":00 " + t1ampm;
            var t2 = "01/01/0001 " + t2hour.ToString("00") + ":" + t2min.ToString("00") + ":00 " + t2ampm;
            var time1 = DateTime.ParseExact(t1, "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
            var time2 = DateTime.ParseExact(t2, "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
            if (time2 < time1) {
                Console.WriteLine("Date is on Next Day!");
                time2 = time2.AddDays(1);
            } else {
                Console.WriteLine("same day");
            }
            return time2 - time1;
        }

        public static DateTime GetDateTime(int hh, int mm, string tt) {
            var t2 = "01/01/0001 " + hh.ToString("00") + ":" + mm.ToString("00") + ":00 " + tt;
            return DateTime.ParseExact(t2, "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
        }
        public static DateTime GetDateTime(String hhmmss_tt) {
            var t2 = "01/01/0001 " + hhmmss_tt;
            return DateTime.ParseExact(t2, "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
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




        public static void GetDaysInPeriod(int AID) {
            int month = GetMonth();
            Period p = GetCurrentPayPeriod(AID);
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

