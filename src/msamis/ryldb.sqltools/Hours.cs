
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MSAMISUserInterface {
    public class Hours {
        public TimeSpan total = new TimeSpan(0, 0, 0);
        public TimeSpan normal_day = new TimeSpan(0, 0, 0);
        public TimeSpan normal_night = new TimeSpan(0, 0, 0);
        public TimeSpan holiday_day = new TimeSpan(0, 0, 0);
        public TimeSpan holiday_night = new TimeSpan(0, 0, 0);
        public TimeSpan SundayTotal = new TimeSpan(0, 0, 0);
        // Divided into 2
        public TimeSpan holiday_day_special = new TimeSpan(0, 0, 0);
        public TimeSpan holiday_day_regular = new TimeSpan(0, 0, 0);
        public TimeSpan holiday_night_special = new TimeSpan(0, 0, 0);
        public TimeSpan holiday_night_regular = new TimeSpan(0, 0, 0);



        public TimeSpan Sunday_special_day = new TimeSpan(0, 0, 0);
        public TimeSpan Sunday_special_night = new TimeSpan(0, 0, 0);
        public TimeSpan holiday_regular_day_sunday = new TimeSpan(0, 0, 0);
        public TimeSpan holiday_sunday_regular_night = new TimeSpan(0, 0, 0);
        public TimeSpan Sunday_normal_day = new TimeSpan(0, 0, 0);
        public TimeSpan Sunday_normal_night = new TimeSpan(0, 0, 0);




        public TimeSpan holiday_regular_day = new TimeSpan(0, 0, 0);
        public TimeSpan holiday_special_day = new TimeSpan(0, 0, 0);

        public Hours(DateTime TimeIn, DateTime TimeOut, DateTime f) {
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
                    SundayTotal += d1_day + d1_night;
                }
                // Second Half
                minEnd = TimeOut < NightEnd ? TimeOut : NightEnd;
                maxEnd = TimeOut > NightEnd ? TimeOut : NightEnd;
                TimeSpan d2_night = minEnd - Midnight;
                TimeSpan d2_day = (maxEnd - NightEnd > TimeSpan.FromSeconds(0)) ? maxEnd - NightEnd : new TimeSpan(0, 0, 0);
                if (TimeOut.DayOfWeek == DayOfWeek.Sunday) {
                    SundayTotal += d2_day + d2_night;
                }




                Attendance.HE_internal o = Attendance.IsHolidayToday_(TimeIn);
                // Check if today is holiday.
                if (Attendance.IsHolidayToday(TimeIn)) {
                    holiday_night += d1_night;
                    holiday_day += d1_day;
                    if (o.type == Enumeration.HolidayType.Regular) {
                        if (TimeIn.DayOfWeek == DayOfWeek.Sunday) {
                            holiday_regular_day_sunday += d1_day;
                            holiday_sunday_regular_night += d1_night;
                        } else {
                        }
                    } else {
                        Sunday_special_day += d1_day;
                        Sunday_special_night += d1_night;
                    }


                } else {
                    normal_night += d1_night;
                    normal_day += d1_day;
                    if (TimeIn.DayOfWeek == DayOfWeek.Sunday) {
                        Sunday_normal_day += d1_day;
                        Sunday_normal_night += d1_night;
                    }
                }
                //Check if tomorrow is holiday.
                if (Attendance.IsHolidayTomorrow(TimeIn)) {
                    holiday_night += d2_night;
                    holiday_day += d2_day;
                    if (TimeOut.DayOfWeek == DayOfWeek.Sunday) {
                        // Sunday_holiday_day += d2_day;
                        // Sunday_holiday_night += d2_night;
                    }
                } else {
                    normal_night += d2_night;
                    normal_day += d2_day;
                    if (TimeOut.DayOfWeek == DayOfWeek.Sunday) {
                        Sunday_normal_day += d2_day;
                        Sunday_normal_night += d2_night;
                    }
                }
            } else {
                // if same day
                NightEnd = new DateTime(f.Year, f.Month, f.Day, 6, 00, 00);
                maxStart = TimeIn < NightStart ? TimeIn : NightStart;
                minStart = TimeIn > NightStart ? TimeIn : NightStart;
                minEnd = TimeOut < NightEnd ? TimeOut : NightEnd;
                maxEnd = TimeOut > NightEnd ? TimeOut : NightEnd;
                if (Attendance.IsHolidayToday(TimeIn)) {
                    holiday_night += (minEnd - maxStart) > TimeSpan.FromSeconds(0) ? minEnd - maxStart : new TimeSpan(0, 0, 0);
                    holiday_day += (TimeOut - NightEnd) > TimeSpan.FromSeconds(0) ? TimeOut - NightEnd : new TimeSpan(0, 0, 0);
                    holiday_day += (NightStart - minStart) > TimeSpan.FromSeconds(0) ? NightStart - minStart : new TimeSpan(0, 0, 0);
                    if (TimeIn.DayOfWeek == DayOfWeek.Sunday) {
                        SundayTotal += holiday_night + holiday_day;
                        // Sunday_holiday_day += holiday_day;
                        // Sunday_holiday_night += holiday_night;
                    }
                } else {
                    normal_night += (minEnd - maxStart) > TimeSpan.FromSeconds(0) ? minEnd - maxStart : new TimeSpan(0, 0, 0);
                    normal_day += (TimeOut - NightEnd) > TimeSpan.FromSeconds(0) ? TimeOut - NightEnd : new TimeSpan(0, 0, 0);
                    normal_day += (NightStart - minStart) > TimeSpan.FromSeconds(0) ? NightStart - minStart : new TimeSpan(0, 0, 0);
                    if (TimeIn.DayOfWeek == DayOfWeek.Sunday) {
                        SundayTotal += normal_night + normal_day;
                        Sunday_normal_day += normal_day;
                        Sunday_normal_night += normal_night;
                    }
                }
            }
            total = normal_day + normal_night + holiday_day + holiday_night;
        }
        public Hours() {

        }

        public string GetHolidayDay() {
            return ((int)holiday_day.TotalMinutes / 60).ToString("00") + ":" + (holiday_day.TotalMinutes % 60).ToString("00");
        }
        public string GetHolidayNight() {
            return ((int)holiday_night.TotalMinutes / 60).ToString("00") + ":" + (holiday_night.TotalMinutes % 60).ToString("00");
        }
        public string GetNormalDay() {
            return ((int)normal_day.TotalMinutes / 60).ToString("00") + ":" + (normal_day.TotalMinutes % 60).ToString("00");
        }
        public string GetNormalNight() {
            return ((int)normal_night.TotalMinutes / 60).ToString("00") + ":" + (normal_night.TotalMinutes % 60).ToString("00");
        }
        public string GetTotal() {
            return ((int)total.TotalMinutes / 60).ToString("00") + ":" + (total.TotalMinutes % 60).ToString("00");
        }
        public string GetSunday() {
            return ((int)SundayTotal.TotalMinutes / 60).ToString("00") + ":" + (SundayTotal.TotalMinutes % 60).ToString("00");
        }
    }
}
