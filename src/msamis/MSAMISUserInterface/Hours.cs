using System;

namespace ryldb.sqltools {
    public class Hours {
        public TimeSpan holiday_day = new TimeSpan(0, 0, 0);
        public TimeSpan holiday_day_regular = new TimeSpan(0, 0, 0);
        public TimeSpan holiday_day_special = new TimeSpan(0, 0, 0);
        public TimeSpan holiday_night = new TimeSpan(0, 0, 0);
        public TimeSpan normal_day = new TimeSpan(0, 0, 0);
        public TimeSpan normal_night = new TimeSpan(0, 0, 0);
        public TimeSpan Sunday_holiday_day = new TimeSpan(0, 0, 0);
        public TimeSpan Sunday_holiday_night = new TimeSpan(0, 0, 0);
        public TimeSpan Sunday_normal_day = new TimeSpan(0, 0, 0);
        public TimeSpan Sunday_normal_night = new TimeSpan(0, 0, 0);


        public TimeSpan SundayTotal = new TimeSpan(0, 0, 0);
        public TimeSpan total = new TimeSpan(0, 0, 0);

        public string GetHolidayDay() {
            return ((int) holiday_day.TotalMinutes / 60).ToString("00") + ":" +
                   (holiday_day.TotalMinutes % 60).ToString("00");
        }

        public string GetHolidayNight() {
            return ((int) holiday_night.TotalMinutes / 60).ToString("00") + ":" +
                   (holiday_night.TotalMinutes % 60).ToString("00");
        }

        public string GetNormalDay() {
            return ((int) normal_day.TotalMinutes / 60).ToString("00") + ":" +
                   (normal_day.TotalMinutes % 60).ToString("00");
        }

        public string GetNormalNight() {
            return ((int) normal_night.TotalMinutes / 60).ToString("00") + ":" +
                   (normal_night.TotalMinutes % 60).ToString("00");
        }

        public string GetTotal() {
            return ((int) total.TotalMinutes / 60).ToString("00") + ":" + (total.TotalMinutes % 60).ToString("00");
        }

        public string GetSunday() {
            return ((int) SundayTotal.TotalMinutes / 60).ToString("00") + ":" +
                   (SundayTotal.TotalMinutes % 60).ToString("00");
        }
    }
}