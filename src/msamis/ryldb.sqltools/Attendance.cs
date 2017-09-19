
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using static System.String;

namespace MSAMISUserInterface {


    public class Attendance {

        private class ate_internal {
            int did = 0;
            int date = 0;
        }
        public int GID;
        public int CID;

        #region Constructors
        public Attendance(int AID, int month, int periodx, int year) {
            this.AID = AID;
            period = new Period(periodx, month, year);
            Console.Write(period.period);
            DataRow drSdutyAssign = SQLTools.ExecuteQuery($"select * from sduty_assignment where aid='{this.AID}'").Rows[0];
            GID = int.Parse(drSdutyAssign["gid"].ToString());
            CID = int.Parse(drSdutyAssign["cid"].ToString());
            // Only add attendance on months between contract start and contract end (inclusive)'.
            // So i need to retrieve ContractStart and ContractEnd of the request.
            int raid = int.Parse(drSdutyAssign["raid"].ToString());
            DataRow drra = SQLTools.ExecuteQuery($@"SELECT * FROM msadb.request_assign where raid='{raid}'").Rows[0];
            DateTime cs = DateTime.Parse(drra["contractstart"].ToString());
            DateTime ce = DateTime.Parse(drra["contractend"].ToString());
            // Insert new period
            String ax = $@"INSERT IGNORE INTO `msadb`.`period` 
                            (`GID`, `month`, `period`, `year`, `cid`) VALUES 
                            ('{GID}', '{month}', '{periodx}', '{year}', '{CID}')";
            SQLTools.ExecuteNonQuery(ax);
            string ifn = SQLTools.getLastInsertedId("period", "pid");

            DataTable x = SQLTools.ExecuteQuery("select did, mon,tue,wed,thu,fri,sat,sun from dutydetails where AID =" + AID);
            foreach (DataRow duties in x.Rows) {
                List<int> dutydates = new List<int>();
                int did = int.Parse(duties["did"].ToString());
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
                sw.Stop();
                TimeSpan ts = sw.Elapsed;
                SQLTools.message("Finished inserting in " + ts.ToString("ss\\.ff") + " seconds");
                SQLTools.message("Yes!");

               
                int count = 0;
                int max = dutydates.Count;
                int insertables = 0;
                String q = @"INSERT IGNORE INTO `msadb`.`attendance` (`DID`, `date`, `PID`) VALUES ";
                foreach (int date in dutydates) {
                    DateTime d = new DateTime(period.year, period.month, date);
                    count++;
                    if (cs <= d && d <= ce) {
                        q += @"('" + did + "','" + d.ToString("yyyy-MM-dd HH:mm:ss") + "','" + ifn + "')";
                        q += ",\n";
                        insertables++;
                    }
                    
                }

                // Do not execute INSERT if there is duty dates is empty.
                // Otherwise this will lead to a SQL syntax error.
                // Bc bulk insert.
                if (insertables != 0) SQLTools.ExecuteNonQuery(q.Substring(0,q.Length-2));

            }
            
        }

        
        #endregion

        #region Instance Fields

        public List<HourProcessor> hourlist = new List<HourProcessor>();
        public HourProcessor TotalHours = new HourProcessor();
        public int AID;
        public Period period;
        private DataTable attendance_cached;

        #endregion New Region

        #region Instance Methods

        #region MethodFamily: GetAttendance

        public DataTable GetAttendance() {
            return GetAttendance(period.month, period.period, period.year);
        }

        public DataTable GetAttendance(int month, int period, int year) {
            String q = $@"
                        select atid, dutydetails.did, DATE_FORMAT(date, '%Y-%m-%d') as Date, SUBSTRING(DAYNAME(DATE_FORMAT(date, '%Y-%m-%d')) FROM 1 FOR 3)  as day, 
							concat (ti_hh,':',ti_mm,' ',ti_period, ' - ',to_hh,':',to_mm,' ',to_period) as Schedule,
                            timein,
                           TimeOut, 
                            ' ' as normal_day, ' ' as normal_night, ' ' as holiday_day, ' ' as holiday_night, ' ' as total
                            from attendance
                            left join dutydetails 
                            on dutydetails.did=attendance.did
                            left join period 
                            on period.pid=attendance.pid
                            where period = '{period}'
                            and month = '{month}'
                            and year = '{year}'
                            and period.gid = '{this.GID}'
                            and aid='{AID}'
                            order by date asc
                            ";
            DataTable d = SQLTools.ExecuteQuery(q);
            return d;
        }

        public DataTable GetAttendance_View() {
            return GetAttendance_View(period.month, period.period, period.year);
        }

        public DataTable GetAttendance_View(int month, int period, int year) {
            String q = $@"
                        select atid, dutydetails.did, 
							CONCAT((DATE_FORMAT(date, '%d')), ' / ' ,
							(CONCAT (ti_hh,':',ti_mm,' ',SUBSTRING(ti_period,1,1), '-',to_hh,':',to_mm,SUBSTRING(to_period,1,1)))) as Schedule,
                            concat( SUBSTRING(timein,1,7), '-' ,SUBSTRING(timeout,1,7)) as ti_to,
                            
                            ' ' as normal_day, ' ' as normal_night, ' ' as holiday_day, ' ' as holiday_night, ' ' as total, timein, timeout, CONCAT(`year`, '-',period.month,'-', (DATE_FORMAT(date, '%d')), ' ') as Date
                            from attendance
                            left join dutydetails 
                            on dutydetails.did=attendance.did
                            left join period 
                            on period.pid=attendance.pid
                            where period = '{period}'
                            and month = '{month}'
                            and year = '{year}'    
                            and gid = '{GID}'
                            and aid='{AID}'
                            order by date asc
                            ";
            DataTable d = SQLTools.ExecuteQuery(q);
            foreach (DataRow f in d.Rows) {
                DateTime ti = DateTime.Parse(f["Date"].ToString()+f["TimeIn"].ToString());
                DateTime to = DateTime.Parse(f["Date"].ToString()+f["TimeOut"].ToString());
                HourProcessor proc = new HourProcessor(ti, to, ti, to);
                hourlist.Add(proc);
                f["normal_day"] = proc.GetNormalDay();
                f["normal_night"] = proc.GetNormalNight();
                f["holiday_day"] = proc.GetHolidayDay();
                f["holiday_night"] = proc.GetHolidayNight();
                f["total"] = proc.GetTotal();
            }
            Hours h = new Hours();
            attendance_cached = d;
            TimeSpan holiday_day, holiday_night, normal_day, normal_night, total;
            holiday_day = holiday_night = normal_day = normal_night = total = new TimeSpan();
            foreach (HourProcessor x in hourlist) {
                h.holiday_day += x.GetHolidayDayTS();
                h.holiday_night += x.GetHolidayNightTS();
                h.normal_day += x.GetNormalDayTS();
                h.normal_night += x.GetNormalNightTS(); ;
                h.total += x.GetTotalTS();
            }
            return d;
        }

        public Hours GetAttendanceSummary() {
            
            String q = $@"
                        select atid, dutydetails.did, DATE_FORMAT(date, '%Y-%m-%d') as Date, SUBSTRING(DAYNAME(DATE_FORMAT(date, '%Y-%m-%d')) FROM 1 FOR 3)  as day, 
							concat (ti_hh,':',ti_mm,' ',ti_period, ' - ',to_hh,':',to_mm,' ',to_period) as Schedule,
                            timein,
                           TimeOut, 
                            ' ' as normal_day, ' ' as normal_night, ' ' as holiday_day, ' ' as holiday_night, ' ' as total, CONCAT(`year`, '-',period.month,'-', (DATE_FORMAT(date, '%d')), '  ') as Datex
                            from attendance
                            left join dutydetails 
                            on dutydetails.did=attendance.did
                            left join period 
                            on period.pid=attendance.pid
                            where period = '{period.period}'
                            and month = '{period.month}'
                            and year = '{period.year}'
                            and period.gid = {this.GID}
                            and aid = {AID}
                            order by date asc
                            ";
            DataTable d = SQLTools.ExecuteQuery(q);
            foreach (DataRow f in d.Rows) {
                var sti = f["Datex"].ToString() + f["TimeIn"].ToString();
                var sto = f["Datex"].ToString() + f["TimeOut"].ToString();
                DateTime ti = DateTime.Parse(sti);
                DateTime to = DateTime.Parse(sto);
                HourProcessor proc = new HourProcessor(ti, to, ti, to);
                hourlist.Add(proc);
                f["normal_day"] = proc.GetNormalDay();
                f["normal_night"] = proc.GetNormalNight();
                f["holiday_day"] = proc.GetHolidayDay();
                f["holiday_night"] = proc.GetHolidayNight();
                f["total"] = proc.GetTotal();
            }
            Hours h = new Hours();
            attendance_cached = d;
            TimeSpan holiday_day, holiday_night, normal_day, normal_night, total;
            holiday_day = holiday_night = normal_day = normal_night = total = new TimeSpan();

            foreach (HourProcessor x in hourlist) {
                TotalHours += x;
                h.holiday_day += x.GetHolidayDayTS();
                h.holiday_night += x.GetHolidayNightTS();
                h.normal_day += x.GetNormalDayTS();
                h.normal_night += x.GetNormalNightTS(); ;
                h.total += x.GetTotalTS();
                int pc = 1 + 1;
            }
            return h;
        }

        public string[] GetAttendanceTooltip() {
            HourProcessor h = TotalHours;
            string[] a = new string [24];
            string[] b = {
                "nsu_proper_day_normal",
                "nsu_overtime_day_normal",
                "sun_proper_day_normal",
                "sun_overtime_day_normal",
                "nsu_proper_night_normal",
                "nsu_overtime_night_normal",
                "sun_proper_night_normal",
                "sun_overtime_night_normal",
                "nsu_proper_day_regular",
                "nsu_overtime_day_regular",
                "sun_proper_day_regular",
                "sun_overtime_day_regular",
                "nsu_proper_day_special",
                "nsu_overtime_day_special",
                "sun_proper_day_special",
                "sun_overtime_day_special",
                "nsu_proper_night_regular",
                "nsu_overtime_night_regular",
                "sun_proper_night_regular",
                "sun_overtime_night_regular",
                "nsu_proper_night_special",
                "nsu_overtime_night_special",
                "sun_proper_night_special",
                "sun_overtime_night_special"
            };
            for (int c = 0; c < b.Length; c++) {
                TimeSpan ts = h.hp[b[c]];
                a[c] = (((int) (ts.TotalHours)).ToString("00") + ":" + ((int) ts.Minutes).ToString("00")).ToString() + " hrs.";
            }
            return a;
        }

        public string GetCertifiedBy() {
            return SQLTools.ExecuteSingleResult($@"
                        select concat(ln,', ',fn,' ',mn) as certby from period
                        left join attendance on attendance.pid=period.pid
                        left join dutydetails on dutydetails.DID= attendance.DID
                        left join certifier on period.certby = certifier.ccid where month='{period.month}' and period = '{period.period}' and year='{period.year}' and aid='{AID}'");
        }
        #endregion New Region

        #region MethodFamily: SetAttendance
        public void SetAttendance(int AtID, int ti_hh, int ti_mm, String ti_ampm, int to_hh, int to_mm, String to_ampm) {
            int did = SQLTools.GetInt("select did from attendance where AtID=" + AtID);
            TimeSpan ts = GetTimeDiff(ti_hh, ti_mm, ti_ampm, to_hh, to_mm, to_ampm);
            DateTime ti = GetDateTime(ti_hh, ti_mm, ti_ampm);
            DateTime to = GetDateTime(to_hh, to_mm, to_ampm);
            //compare with tama na sched for overtime
            DataRow dt = SQLTools.ExecuteQuery("select * from dutydetails where DID=" + did).Rows[0];
            DateTime start_night = GetDateTime(10, 00, "PM");
            DateTime end_night = GetDateTime(6, 0, "AM").AddDays(1);
            String q = @"UPDATE `msadb`.`attendance` SET `TimeIn`='{1}', `TimeOut`='{2}'  WHERE `AtID`='{0}';";
            q = Format(q, AtID, ti.ToString("hh:mm tt"), to.ToString("hh:mm tt"));
            SQLTools.ExecuteNonQuery(q);
        }

        public void SetCertifiedBy(int AID, int cert) {
            Period p = GetCurrentPayPeriod();
            String q = @"UPDATE `msadb`.`period` SET `certby`='" + cert + "' WHERE `GID`='" + GID + "' AND month='" + p.month + "' AND period='" + p.period + "' AND year='" + p.year + "';";
            SQLTools.ExecuteNonQuery(q);
        }

       

        #endregion

        #endregion

        #region Statics
        #region MethodFamily: Period Operations
        public static int GetMonth() {
            return int.Parse(DateTime.Now.ToString("MM"));
        }

        public static int GetYear() {
            return int.Parse(DateTime.Now.ToString("yyyy"));
        }

        // This method gets the current pay period.
        public static Period GetCurrentPayPeriod() {
            /* Definitions are swapped. This returns 
             *      1 = 1-15
             *      2 = 16-31
             */
            #region + OLD DEFINTION
            /*
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
            return new Period(p, m, y);*/
            #endregion

            // Overriden definition starts here.
            int m = 0, y = 0, p = 0;
            #region + Dates Setting
            int date = int.Parse(DateTime.Now.ToString("dd"));
            if (date >= 1 && date <= 15) {
                p = 1;
                m = GetMonth();
                y = GetYear();
            } else if ((date >= 16 && date <= 31)) {
                p = 2;
                m = GetMonth();
                y = GetYear();
            }
            #endregion
            return new Period(p, m, y); ;
        }

        public static Period GetCurrentPeriod() {
            int m = 0, y = 0, p = 0;
            #region + Dates Setting
            int date = int.Parse(DateTime.Now.ToString("dd"));
            if (date >= 1 && date <= 15) {
                p = 1;
                m = GetMonth();
                y = GetYear();
            } else if ((date >= 16 && date <= 31)) {
                p = 2;
                m = GetMonth();
                y = GetYear();
            }
            #endregion
            return new Period(p, m, y); ;
        }



        public static DataTable GetPeriods(int GID) {
            return SQLTools.ExecuteQuery(@"SELECT month, period, year
                                        FROM msadb.period 
                                        where GID = " + GID + @"
                                        group by month,period,year order by year desc, month desc, period desc;");
        }
        #endregion

        #region MethodFamily: Holiday Operations

        public static bool IsHolidayToday(DateTime e) {
            List<Holiday> holidaylist = Holiday.InitHolidays(e.Year);
            if (holidaylist.Contains(new Holiday(e.Month, e.Day, 0))) {
                return true;
            } else return false;
        }

        public static bool IsHolidayTomorrow(DateTime e) {
            return IsHolidayToday(e.AddDays(1));
        }

        [Serializable]
        public class HE_internal {
            public bool isholiday;
            public int type;
            public HE_internal (bool isholiday, int type) { this.isholiday = isholiday; this.type = type; }
        }

        public static HE_internal IsHolidayToday_(DateTime e) {
            var holidaylist = Holiday.InitHolidays(e.Year);
            if (holidaylist.Contains(new Holiday(e.Month, e.Day, 0))) {
                Holiday value = holidaylist.First(item => item.month == e.Month && item.day==e.Day);
                return new HE_internal (true, value.type);
            } else return new HE_internal(false, 0);
        }

        public static bool IsHolidayTomorrow_(DateTime e) {
            return IsHolidayToday(e.AddDays(1));
        }

        #endregion MethodFamily: Holiday Operations

        #region MethodFamily: GetDateTime (static)

        public static DateTime GetDateTime_(String hhmmss_tt) {
            var t2 = "01/01/0001 " + hhmmss_tt;
            return DateTime.ParseExact(t2, "MM/dd/yyyy hh:mm tt", CultureInfo.InvariantCulture);
        }

        public static DateTime GetDateTime(int hh, int mm, string tt) {
            var t2 = "01/01/0001 " + hh.ToString("00") + ":" + mm.ToString("00") + ":00 " + tt;
            return DateTime.ParseExact(t2, "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
        }

        #endregion New Region

        #region MethodFamily: TimeSpan Operations

        public static TimeSpan GetTimeDiff(int StartHour, int StartMinute, String StartAmpm, int EndHour, int EndMinute, String EndAmpm) {
            var StartTimeString = "01/01/0001 " + StartHour.ToString("00") + ":" + StartMinute.ToString("00") + ":00 " + StartAmpm;
            var EndTimeString = "01/01/0001 " + EndHour.ToString("00") + ":" + EndMinute.ToString("00") + ":00 " + EndAmpm;
            var StartDateTime = DateTime.ParseExact(StartTimeString, "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
            var EndDateTime = DateTime.ParseExact(EndTimeString, "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
            if (EndDateTime < StartDateTime)
                EndDateTime = EndDateTime.AddDays(1);
            return EndDateTime - StartDateTime;
        }

        // =============================================================================================
        //          STATIC METHODS / VARIABLES
        // =============================================================================================
        public static Hours GetHours(DateTime TimeIn, DateTime TimeOut) {
            Hours h = new Hours();
            DateTime NightStart = new DateTime(1, 1, 1, 22, 00, 00);
            DateTime NightEnd = new DateTime(1, 1, 1, 6, 00, 00);
            DateTime Midnight = new DateTime(1, 1, 2, 0, 0, 0); DateTime maxStart; DateTime minEnd; DateTime minStart; DateTime maxEnd;
            // if not same
            if (TimeIn > TimeOut) {
                TimeOut = TimeOut.AddDays(1);
                NightEnd = NightEnd.AddDays(1);
                // First Half
                // 1: Max Selection, either nighstart or actuals
                maxStart = TimeIn < NightStart ? NightStart : TimeIn;
                minStart = TimeIn < NightStart ? TimeIn : NightStart;
                TimeSpan d1_night = Midnight - maxStart;
                TimeSpan d1_day = (NightStart - minStart > TimeSpan.FromSeconds(0)) ? NightStart - minStart : new TimeSpan(0, 0, 0);
                if (TimeIn.DayOfWeek==DayOfWeek.Sunday) {
                    h.SundayTotal += d1_day + d1_night;
                }
                // Second Half
                
                minEnd = TimeOut < NightEnd ? TimeOut : NightEnd;
                maxEnd = TimeOut > NightEnd ? TimeOut : NightEnd;
                TimeSpan d2_night = minEnd - Midnight;
                TimeSpan d2_day = (maxEnd - NightEnd > TimeSpan.FromSeconds(0)) ? maxEnd - NightEnd : new TimeSpan(0, 0, 0);
                if (TimeOut.DayOfWeek == DayOfWeek.Sunday) {
                    h.SundayTotal += d2_day + d2_night;
                }

                // Check if today is holiday.
                if (IsHolidayToday(TimeIn)) {
                    h.holiday_night += d1_night;
                    h.holiday_day += d1_day;
                } else {
                    h.normal_night += d1_night;
                    h.normal_day += d1_day;
                }
                //Check if tomorrow is holiday.
                if (IsHolidayTomorrow(TimeIn)) {
                    h.holiday_night += d2_night;
                    h.holiday_day += d2_day;
                } else {
                    h.normal_night += d2_night;
                    h.normal_day += d2_day;
                }
                

            } else {
                // if same day
                NightEnd = new DateTime(1, 1, 1, 6, 00, 00);
                maxStart = TimeIn < NightStart ? TimeIn : NightStart;
                minStart = TimeIn > NightStart ? TimeIn : NightStart;
                minEnd = TimeOut < NightEnd ? TimeOut : NightEnd;
                maxEnd = TimeOut > NightEnd ? TimeOut : NightEnd;
                if (IsHolidayToday(TimeIn)) {
                    h.holiday_night += (minEnd - maxStart) > TimeSpan.FromSeconds(0) ? minEnd - maxStart : new TimeSpan(0, 0, 0);
                    h.holiday_day += (TimeOut - NightEnd) > TimeSpan.FromSeconds(0) ? TimeOut - NightEnd : new TimeSpan(0, 0, 0);
                    h.holiday_day += (NightStart - minStart) > TimeSpan.FromSeconds(0) ? NightStart - minStart : new TimeSpan(0, 0, 0);
                    if (TimeIn.DayOfWeek==DayOfWeek.Sunday) h.SundayTotal += h.holiday_night + h.holiday_day;
                } else {
                    h.normal_night += (minEnd - maxStart) > TimeSpan.FromSeconds(0) ? minEnd - maxStart : new TimeSpan(0, 0, 0);
                    h.normal_day += (TimeOut - NightEnd) > TimeSpan.FromSeconds(0) ? TimeOut - NightEnd : new TimeSpan(0, 0, 0);
                    h.normal_day += (NightStart - minStart) > TimeSpan.FromSeconds(0) ? NightStart - minStart : new TimeSpan(0, 0, 0);
                    if (TimeIn.DayOfWeek == DayOfWeek.Sunday) h.SundayTotal += h.normal_night + h.normal_day;
                }
            }
            h.total = h.normal_day + h.normal_night + h.holiday_day + h.holiday_night;
            return h;
        }

        public static Hours GetHours(DateTime TimeIn, DateTime TimeOut, DateTime f) {
            Hours h = new Hours();
            DateTime NightStart = new DateTime(f.Year, f.Month, f.Day, 22, 00, 00);
            DateTime NightEnd = new DateTime(f.Year, f.Month, f.Day, 6, 00, 00);
            DateTime Midnight = new DateTime(f.Year, f.Month, f.Day, 0, 0, 0).AddDays(1); DateTime maxStart; DateTime minEnd; DateTime minStart; DateTime maxEnd;
            // if not same
            if (TimeIn > TimeOut) {
                TimeOut = TimeOut.AddDays(1);
                NightEnd = NightEnd.AddDays(1);
                // First Half
                // 1: Max Selection, either nighstart or actuals
                maxStart = TimeIn < NightStart ? NightStart : TimeIn;
                minStart = TimeIn < NightStart ? TimeIn : NightStart;
                TimeSpan d1_night = Midnight - maxStart;
                TimeSpan d1_day = (NightStart - minStart > TimeSpan.FromSeconds(0)) ? NightStart - minStart : new TimeSpan(0, 0, 0);
                if (TimeIn.DayOfWeek == DayOfWeek.Sunday) {
                    h.SundayTotal += d1_day + d1_night;
                }
                // Second Half

                minEnd = TimeOut < NightEnd ? TimeOut : NightEnd;
                maxEnd = TimeOut > NightEnd ? TimeOut : NightEnd;
                TimeSpan d2_night = minEnd - Midnight;
                TimeSpan d2_day = (maxEnd - NightEnd > TimeSpan.FromSeconds(0)) ? maxEnd - NightEnd : new TimeSpan(0, 0, 0);
               

                // Check if today is holiday.
                if (IsHolidayToday(TimeIn)) {
                    h.holiday_night += d1_night;
                    h.holiday_day += d1_day;
                } else {
                    h.normal_night += d1_night;
                    h.normal_day += d1_day;
                    if (TimeIn.DayOfWeek == DayOfWeek.Sunday) {
                        h.Sunday_normal_day += d1_day;
                        h.Sunday_normal_night += d1_night;
                    }
                }
                //Check if tomorrow is holiday.
                if (IsHolidayTomorrow(TimeIn)) {
                    h.holiday_night += d2_night;
                    h.holiday_day += d2_day;
                } else {
                    h.normal_night += d2_night;
                    h.normal_day += d2_day;
                    
                }


            } else {
                // if same day
                NightEnd = new DateTime(f.Year, f.Month, f.Day, 6, 00, 00);
                maxStart = TimeIn < NightStart ? TimeIn : NightStart;
                minStart = TimeIn > NightStart ? TimeIn : NightStart;
                minEnd = TimeOut < NightEnd ? TimeOut : NightEnd;
                maxEnd = TimeOut > NightEnd ? TimeOut : NightEnd;
                if (IsHolidayToday(TimeIn)) {
                    h.holiday_night += (minEnd - maxStart) > TimeSpan.FromSeconds(0) ? minEnd - maxStart : new TimeSpan(0, 0, 0);
                    h.holiday_day += (TimeOut - NightEnd) > TimeSpan.FromSeconds(0) ? TimeOut - NightEnd : new TimeSpan(0, 0, 0);
                    h.holiday_day += (NightStart - minStart) > TimeSpan.FromSeconds(0) ? NightStart - minStart : new TimeSpan(0, 0, 0);
                    

                } else {
                    h.normal_night += (minEnd - maxStart) > TimeSpan.FromSeconds(0) ? minEnd - maxStart : new TimeSpan(0, 0, 0);
                    h.normal_day += (TimeOut - NightEnd) > TimeSpan.FromSeconds(0) ? TimeOut - NightEnd : new TimeSpan(0, 0, 0);
                    h.normal_day += (NightStart - minStart) > TimeSpan.FromSeconds(0) ? NightStart - minStart : new TimeSpan(0, 0, 0);
                    if (TimeIn.DayOfWeek == DayOfWeek.Sunday) {
                        h.SundayTotal += h.normal_night + h.normal_day;
                        h.Sunday_normal_day += h.normal_day;
                        h.Sunday_normal_night += h.normal_night;
                    }
                }
            }
            h.total = h.normal_day + h.normal_night + h.holiday_day + h.holiday_night;
            
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

        #endregion New Region

       
      
     
        #endregion

        #region Subclasses

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

            public Period(int period, int month, int year) {
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

        

#endregion New Region

        /*
         *  Payrolls are calculated on the 16th-19th of the month (Period 2)
         *  and 1st-4th of the month (Period 1).
         *  Periods covered are the preceeding 15 days.
         *  So calculation dates are 
         *  (1-4) Period 2
         *  (16-19) Period 1
         *  Total 4 days of preparation.
         */

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

    }
}


    

