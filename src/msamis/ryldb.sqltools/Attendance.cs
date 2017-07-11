﻿using ryldb.sqltools;
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

        public List<Hours> hourlist = new List<Hours>();
        public class Hours {
            public TimeSpan total = new TimeSpan(0, 0, 0);
            public TimeSpan holiday_day = new TimeSpan(0, 0, 0);
            public TimeSpan holiday_night = new TimeSpan(0, 0, 0);
            public TimeSpan normal_day = new TimeSpan(0, 0, 0);
            public TimeSpan normal_night = new TimeSpan(0, 0, 0);
            public string GetHolidayDay() {
                return ((int)holiday_day.TotalMinutes / 60).ToString("00") + ":" + (holiday_day.TotalMinutes % 60).ToString("00");
            }
            public string GetHolidayNight() {
                return ((int)holiday_night.TotalMinutes / 60).ToString("00") + ":" + (holiday_night.TotalMinutes % 60).ToString("00");
            }
            public string GetNormalDay() {
                return ((int)normal_night.TotalMinutes / 60).ToString("00") + ":" + (normal_night.TotalMinutes % 60).ToString("00");
            }
            public string GetNormalNight() {
                return ((int)normal_night.TotalMinutes / 60).ToString("00") + ":" + (normal_night.TotalMinutes % 60).ToString("00");
            }
            public string GetTotal() {
                return ((int)total.TotalMinutes / 60).ToString("00") + ":" + (total.TotalMinutes % 60).ToString("00");
            }
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
                                        FROM msadb.period 
                                        where AID = " + AID + @"
                                        group by month,period,year order by year desc, month desc, period desc;");
        }




        // =============================================================================================
        //          INSTANCE METHODS / VARIABLES (nonstatic)
        // =============================================================================================
        #region Non-Statics

        public Period period;
        public int AID;

        public Hours GetAttendanceSummary() {
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
                            left join period 
                            on period.pid=attendance.pid
                            where period = '{0}'
                            and month = '{1}'
                            and year = '{2}'
                            order by date asc
                            ";
            q = String.Format(q, period.period, period.month, period.year);
            DataTable d = SQLTools.ExecuteQuery(q);
            foreach (DataRow f in d.Rows) {
                DateTime ti = GetDateTime_(f["TimeIn"].ToString());
                DateTime to = GetDateTime_(f["TimeOut"].ToString());
                hourlist.Add(GetHours(ti, to));
            }
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

        public Attendance(int AID, int month, int periodx, int year) {
            this.AID = AID;
            period = new Period(AID, periodx, month, year);
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
                String ax = "INSERT IGNORE INTO `msadb`.`period` (`AID`, `month`, `period`, `year`) VALUES ('{0}', '{1}', '{2}', '{3}');";
                ax = String.Format(ax, AID, month, periodx, year);
                SQLTools.ExecuteNonQuery(ax);

                string ifn = SQLTools.getLastInsertedId("period", "pid");
                foreach (int date in dutydates) {

                    DateTime d = new DateTime(period.year, period.month, date);
                    String q = @"INSERT IGNORE INTO `msadb`.`attendance` (
                            `DID`, `date`, `hours`, `holiday`, `night`,`overtime`, `PID`
                            ) VALUES (
                           '{0}','{1}','{2}','{3}','{4}','{5}', '{6}'
                            );";
                    q = String.Format(q, did, d.ToString("yyyy-MM-dd HH:mm:ss"), "00:00", "00:00", "00:00", "00:00", ifn);
                    SQLTools.ExecuteNonQuery(q);
                }
                sw.Stop();
                TimeSpan ts = sw.Elapsed;
                Console.WriteLine("Finished inserting in " + ts.ToString("ss\\.ff") + " seconds");
                Console.WriteLine("Yes!");
            }
        }


        public DataTable GetAttendance() {
            Period p = GetCurrentPayPeriod(0);

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
                            left join period on period.pid = attendance.pid
                             where period = '{0}'
                            and month = '{1}'
                            and year = '{2}'
                            order by date asc;
                            ";
            DataTable d = SQLTools.ExecuteQuery(String.Format(q, p.period, p.month, p.year));
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
                            left join period 
                            on period.pid=attendance.pid
                            where month='{0}' and period = '{1}' and year = '{2}'
                            order by date asc;
                            ";
            q = String.Format(q, month, period, year);
            return SQLTools.ExecuteQuery(q);
        }

        public int GetTimeElapsed(int ti, int to) {
            return (to - ti > 0 ? (to - ti) : 24 + (to - ti));
        }

        #region CertBys
        public void SetCertifiedBy(int AID, String cert) {
            Period p = GetCurrentPayPeriod(0);
            String q = @"UPDATE `msadb`.`period` SET `certby`='" + cert + "' WHERE `AID`='" + AID + "' AND month='"+p.month+"' AND period='"+p.period+"' AND year='"+p.year+"';";
            SQLTools.ExecuteNonQuery(q);
        }
        public string GetCertifiedBy() {
            return SQLTools.ExecuteSingleResult(String.Format("select certby from period where month='{0}' and period = '{1}' and year='{2}'", period.month, period.period, period.year));
        }
        #endregion

        #region SetAttendacen
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
        #endregion



        //==================================================================================
        //          DATA TESTING
        //==================================================================================
        // Dont forget to change 
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
            DateTime Midnight = new DateTime(1, 1, 2, 0, 0, 0); DateTime maxStart; DateTime minEnd; DateTime minStart; DateTime maxEnd;
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
                TimeSpan d1_day = (NightStart - minStart > TimeSpan.FromSeconds(0)) ? NightStart - minStart : new TimeSpan(0, 0, 0);
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

        public static DateTime GetDateTime_(String hhmmss_tt) {
            var t2 = "01/01/0001 " + hhmmss_tt;
            return DateTime.ParseExact(t2, "MM/dd/yyyy hh:mm tt", CultureInfo.InvariantCulture);
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

