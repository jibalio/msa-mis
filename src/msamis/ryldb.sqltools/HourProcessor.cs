using System;
using System.Linq;
using ryldb.sqltools;

namespace MSAMISUserInterface {

    [Serializable]
    public class HourProcessor {
        public SerializableDictionary <string, TimeSpan> hp = new SerializableDictionary<string, TimeSpan> { 
            #region + Keys Definition
            {"nsu_proper_day_normal", new TimeSpan(0,0,0)},
            {"nsu_proper_day_special", new TimeSpan(0,0,0)},
            {"nsu_proper_day_regular", new TimeSpan(0,0,0)},
            {"nsu_proper_night_normal", new TimeSpan(0,0,0)},
            {"nsu_proper_night_special", new TimeSpan(0,0,0)},
            {"nsu_proper_night_regular", new TimeSpan(0,0,0)},
            {"nsu_overtime_day_normal", new TimeSpan(0,0,0)},
            {"nsu_overtime_day_special", new TimeSpan(0,0,0)},
            {"nsu_overtime_day_regular", new TimeSpan(0,0,0)},
            {"nsu_overtime_night_normal", new TimeSpan(0,0,0)},
            {"nsu_overtime_night_special", new TimeSpan(0,0,0)},
            {"nsu_overtime_night_regular", new TimeSpan(0,0,0)},
            {"sun_proper_day_normal", new TimeSpan(0,0,0)},
            {"sun_proper_day_special", new TimeSpan(0,0,0)},
            {"sun_proper_day_regular", new TimeSpan(0,0,0)},
            {"sun_proper_night_normal", new TimeSpan(0,0,0)},
            {"sun_proper_night_special", new TimeSpan(0,0,0)},
            {"sun_proper_night_regular", new TimeSpan(0,0,0)},
            {"sun_overtime_day_normal", new TimeSpan(0,0,0)},
            {"sun_overtime_day_special", new TimeSpan(0,0,0)},
            {"sun_overtime_day_regular", new TimeSpan(0,0,0)},
            {"sun_overtime_night_normal", new TimeSpan(0,0,0)},
            {"sun_overtime_night_special", new TimeSpan(0,0,0)},
            {"sun_overtime_night_regular", new TimeSpan(0,0,0)},
            #endregion
        };
        TimeSpan total, totalday, totalnight;
        public SerializableDictionary<string, TimeSpan> GetHourDictionary() {
            return hp;
        }
        public HourProcessor(DateTime ti, DateTime to, DateTime startduty, DateTime endduty) {
            /*      HOUR PROCESSOR V2.0
                   DateTime start = new DateTime (4,1,1,2,30,00);
		            DateTime end = new DateTime (4,1,1,22,30,00);
		            int sm = start.Hour * 60 + start.Minute;
		            int em = end.Hour * 60 + end.Minute;
		            int duration = em - sm;
		            if (duration<0)
			            duration+=1440;
		            TimeSpan ti = new TimeSpan(0,duration, 0);
        */
            DateTime NightStart = new DateTime(ti.Year, ti.Month, ti.Day, 22, 00, 00);
            DateTime NightEnd = new DateTime(ti.Year, ti.Month, ti.Day, 6, 00, 00);
            DateTime Midnight = new DateTime(ti.Year, ti.Month, ti.Day, 0, 0, 0).AddDays(1); 
DateTime maxStart; DateTime minEnd; DateTime minStart; DateTime maxEnd;
            // if not same
            if (ti > to) {
                to = to.AddDays(1);
                NightEnd = NightEnd.AddDays(1);
                // First Half
                // 1: Max Selection, either nighstart or actuals
                maxStart = ti < NightStart ? NightStart : ti;
                minStart = ti < NightStart ? ti : NightStart;
                TimeSpan d1_night = Midnight - maxStart;
                TimeSpan d1_day = (NightStart - minStart > TimeSpan.FromSeconds(0)) ? NightStart - minStart : new TimeSpan(0, 0, 0);
                // Second Half
                minEnd = to < NightEnd ? to : NightEnd;
                maxEnd = to > NightEnd ? to : NightEnd;
                TimeSpan d2_night = minEnd - Midnight;
                TimeSpan d2_day = (maxEnd - NightEnd > TimeSpan.FromSeconds(0)) ? maxEnd - NightEnd : new TimeSpan(0, 0, 0);
                TimeSpan d2_overtime_day = new TimeSpan(0, 0, 0);
                TimeSpan d2_overtime_night = new TimeSpan(0, 0, 0);
                // Check for overtimes
                if (to > endduty) {
                    DateTime minEndOver_night = to < NightEnd ? to : NightEnd;
                    d2_overtime_night = (endduty - minEndOver_night> TimeSpan.FromSeconds(0)) ? endduty - minEndOver_night : new TimeSpan(0, 0, 0);
                    d2_overtime_day = to > NightEnd ? to - NightEnd : new TimeSpan(0, 0, 0);
                    d2_day -= d2_overtime_day;
                    d2_night -= d2_overtime_night;
                }

                Attendance.HE_internal o = Attendance.IsHolidayToday_(ti);
                // Check if today is holiday.
                if (o.isholiday) {
                    if (o.type == Enumeration.HolidayType.Regular) {
                        if (ti.DayOfWeek == DayOfWeek.Sunday) {
                            this.hp["sun_proper_day_regular"] += d1_day;
                            this.hp["sun_proper_night_regular"] += d1_night;
                        } else {
                            this.hp["nsu_proper_day_regular"] += d1_day;
                            this.hp["nsu_proper_night_regular"] += d1_night;
                        }
                    } else {
                        if (ti.DayOfWeek == DayOfWeek.Sunday) {
                            this.hp["sun_proper_day_special"] += d1_day;
                            this.hp["sun_proper_night_special"] += d1_night;
                        } else {
                            this.hp["nsu_proper_day_special"] += d1_day;
                            this.hp["nsu_proper_night_special"] += d1_night;
                        }
                    }
                } else {
                    if (ti.DayOfWeek == DayOfWeek.Sunday) {
                        this.hp["sun_proper_day_normal"] += d1_day;
                        this.hp["sun_proper_night_normal"] += d1_night;
                    } else {
                        this.hp["nsu_proper_day_normal"] += d1_day;
                        this.hp["nsu_proper_night_normal"] += d1_night;
                    }
                }
                //Check if tomorrow is holiday.
                o = Attendance.IsHolidayToday_(ti.AddDays(1));
                if (o.isholiday) {
                    if (o.type == Enumeration.HolidayType.Regular) {
                        if (ti.DayOfWeek == DayOfWeek.Sunday) {
                            this.hp["sun_proper_day_regular"] += d2_day;
                            this.hp["sun_proper_night_regular"] += d2_night;
                            this.hp["sun_overtime_day_regular"] += d2_overtime_day;
                            this.hp["sun_overtime_night_regular"] += d2_overtime_night;

                        } else {
                            this.hp["nsu_proper_day_regular"] += d2_day;
                            this.hp["nsu_proper_night_regular"] += d2_night;
                            this.hp["nsu_overtime_day_regular"] += d2_overtime_day;
                            this.hp["nsu_overtime_night_regular"] += d2_overtime_night;
                        }
                    } else {
                        if (ti.DayOfWeek == DayOfWeek.Sunday) {
                            this.hp["sun_proper_day_special"] += d2_day;
                            this.hp["sun_proper_night_special"] += d2_night;
                            this.hp["sun_overtime_day_special"] += d2_overtime_day;
                            this.hp["sun_overtime_night_special"] += d2_overtime_night;
                        } else {
                            this.hp["nsu_proper_day_special"] += d2_day;
                            this.hp["nsu_proper_night_special"] += d2_night;
                            this.hp["nsu_overtime_day_special"] += d2_overtime_day;
                            this.hp["nsu_overtime_night_special"] += d2_overtime_night;
                        }
                    }
                } else {
                    if (ti.DayOfWeek == DayOfWeek.Sunday) {
                        this.hp["sun_proper_day_normal"] += d2_day;
                        this.hp["sun_proper_night_normal"] += d2_night;
                        this.hp["sun_overtime_day_normal"] += d2_overtime_day;
                        this.hp["sun_overtime_night_normal"] += d2_overtime_night;
                    } else {
                        this.hp["nsu_proper_day_normal"] += d2_day;
                        this.hp["nsu_proper_night_normal"] += d2_night;
                        this.hp["nsu_overtime_day_normal"] += d2_overtime_day;
                        this.hp["nsu_overtime_night_normal"] += d2_overtime_night;
                    }
                }
            } else {
                // if same day
                NightEnd = new DateTime(ti.Year, ti.Month, ti.Day, 6, 00, 00);
                Midnight = new DateTime(ti.Year, ti.Month, ti.Day, 0, 0, 0);
                DateTime MidnightNext = Midnight.AddDays(1);
                TimeSpan day = new TimeSpan(0, 0, 0); TimeSpan night = new TimeSpan(0, 0, 0);

                night += GetOverlap(Midnight, NightEnd, ti, to);
                night += GetOverlap(NightStart, MidnightNext, ti, to);
                day += GetOverlap(NightEnd, NightStart, ti, to);
                   

                // Overtime Component
                    TimeSpan overtimeday, overtimenight;
                    overtimeday = overtimenight = new TimeSpan(0, 0, 0);
                    if (to > endduty) {
                        DateTime minEndOver_day = to < NightStart ? to : NightStart;
                        overtimeday = (minEndOver_day - endduty > TimeSpan.FromSeconds(0)) ? minEndOver_day - endduty : new TimeSpan(0, 0, 0);
                        overtimenight = to > NightStart ? to - NightStart : new TimeSpan(0, 0, 0);
                        day -= overtimeday;
                        night -= overtimenight;
                    }
               
                Attendance.HE_internal o = Attendance.IsHolidayToday_(ti);
                // Check if today is holiday.
                if (o.isholiday) {
                        if (o.type == Enumeration.HolidayType.Regular) {
                            if (ti.DayOfWeek == DayOfWeek.Sunday) {
                                this.hp["sun_proper_day_regular"] += day;
                                this.hp["sun_proper_night_regular"] += night;
                                this.hp["sun_overtime_day_regular"] += overtimeday;
                                this.hp["sun_overtime_night_regular"] += overtimenight;
                            } else {
                                this.hp["nsu_proper_day_regular"] += day;
                                this.hp["nsu_proper_night_regular"] += night;
                                this.hp["nsu_overtime_day_regular"] += overtimeday;
                                this.hp["nsu_overtime_night_regular"] += overtimenight;
                            }
                        } else {
                            if (ti.DayOfWeek == DayOfWeek.Sunday) {
                                this.hp["sun_proper_day_special"] += day;
                                this.hp["sun_proper_night_special"] += night;
                                this.hp["sun_overtime_day_special"] += overtimeday;
                                this.hp["sun_overtime_night_special"] += overtimenight;
                            } else { 
                                this.hp["nsu_proper_day_special"] += day;
                                this.hp["nsu_proper_night_special"] += night;
                                this.hp["nsu_overtime_day_special"] += overtimeday;
                                this.hp["nsu_overtime_night_special"] += overtimenight;
                            }
                        }
                    } else {
                        if (ti.DayOfWeek == DayOfWeek.Sunday) {
                            this.hp["sun_proper_day_normal"] += day;
                            this.hp["sun_proper_night_normal"] += night;
                            this.hp["sun_overtime_day_normal"] += overtimeday;
                            this.hp["sun_overtime_night_normal"] += overtimenight;
                        } else {
                           this.hp["nsu_proper_day_normal"] += day;
                           this.hp["nsu_proper_night_normal"] += night;
                           this.hp["nsu_overtime_day_normal"] += overtimeday;
                           this.hp["nsu_overtime_night_normal"] += overtimenight;
                        }
                    }
                }
            }
        
        public HourProcessor() { }

        public void Add (HourProcessor e) {
            this.hp["nsu_proper_day_normal"] += e.hp["nsu_proper_day_normal"];
            this.hp["nsu_proper_day_special"] += e.hp["nsu_proper_day_special"];
            this.hp["nsu_proper_day_regular"] += e.hp["nsu_proper_day_regular"];
            this.hp["nsu_proper_night_normal"] += e.hp["nsu_proper_night_normal"];
            this.hp["nsu_proper_night_special"] += e.hp["nsu_proper_night_special"];
            this.hp["nsu_proper_night_regular"] += e.hp["nsu_proper_night_regular"];
            this.hp["nsu_overtime_day_normal"] += e.hp["nsu_overtime_day_normal"];
            this.hp["nsu_overtime_day_special"] += e.hp["nsu_overtime_day_special"];
            this.hp["nsu_overtime_day_regular"] += e.hp["nsu_overtime_day_regular"];
            this.hp["nsu_overtime_night_normal"] += e.hp["nsu_overtime_night_normal"];
            this.hp["nsu_overtime_night_special"] += e.hp["nsu_overtime_night_special"];
            this.hp["nsu_overtime_night_regular"] += e.hp["nsu_overtime_night_regular"];
            this.hp["sun_proper_day_normal"] += e.hp["sun_proper_day_normal"];
            this.hp["sun_proper_day_special"] += e.hp["sun_proper_day_special"];
            this.hp["sun_proper_day_regular"] += e.hp["sun_proper_day_regular"];
            this.hp["sun_proper_night_normal"] += e.hp["sun_proper_night_normal"];
            this.hp["sun_proper_night_special"] += e.hp["sun_proper_night_special"];
            this.hp["sun_proper_night_regular"] += e.hp["sun_proper_night_regular"];
            this.hp["sun_overtime_day_normal"] += e.hp["sun_overtime_day_normal"];
            this.hp["sun_overtime_day_special"] += e.hp["sun_overtime_day_special"];
            this.hp["sun_overtime_day_regular"] += e.hp["sun_overtime_day_regular"];
            this.hp["sun_overtime_night_normal"] += e.hp["sun_overtime_night_normal"];
            this.hp["sun_overtime_night_special"] += e.hp["sun_overtime_night_special"];
            this.hp["sun_overtime_night_regular"] += e.hp["sun_overtime_night_regular"];
        }

        private static TimeSpan GetOverlap(DateTime firstStart, DateTime firstEnd, DateTime secondStart, DateTime secondEnd) {
            DateTime maxStart = firstStart > secondStart ? firstStart : secondStart;
            DateTime minEnd = firstEnd < secondEnd ? firstEnd : secondEnd;
            TimeSpan interval = minEnd - maxStart;
            TimeSpan returnValue = interval > TimeSpan.FromSeconds(0) ? interval : new TimeSpan(0,0,0);
            return returnValue;
        }

        public string GetNormalDay() {
            TimeSpan e =
                hp["nsu_proper_day_normal"] +
                hp["nsu_overtime_day_normal"];
            return e.ToString(@"hh\:mm");
        }
        public string GetNormalNight() {
            TimeSpan e =
                hp["nsu_proper_night_normal"] +
                hp["sun_proper_day_normal"];
            return e.ToString(@"hh\:mm");
        }
        public string GetHolidayDay() {
            TimeSpan e =
                hp["nsu_proper_day_special"] +
                hp["sun_proper_day_special"] +
                hp["nsu_proper_day_regular"] +
                hp["sun_proper_day_regular"]
                ;
            return e.ToString(@"hh\:mm");
        }
        public string GetHolidayNight() {
            TimeSpan e =
                    hp["nsu_proper_night_special"] +
                    hp["sun_proper_night_special"] +
                    hp["nsu_proper_night_regular"] +
                    hp["sun_proper_night_regular"]
                ;
            return e.ToString(@"hh\:mm");
        }


        public TimeSpan GetNormalDayTS() {
            TimeSpan e =
                hp["nsu_proper_day_normal"] +
                hp["nsu_overtime_day_normal"];
            return e;
        }
        public TimeSpan GetNormalNightTS() {
            TimeSpan e =
                hp["nsu_proper_night_normal"] +
                hp["sun_proper_day_normal"];
            return e;
        }
        public TimeSpan GetHolidayDayTS() {
            TimeSpan e =
                    hp["nsu_proper_day_special"] +
                    hp["sun_proper_day_special"] +
                    hp["nsu_proper_day_regular"] +
                    hp["sun_proper_day_regular"]
                ;
            return e;
        }
        public TimeSpan GetHolidayNightTS() {
            TimeSpan e =
                    hp["nsu_proper_night_special"] +
                    hp["sun_proper_night_special"] +
                    hp["nsu_proper_night_regular"] +
                    hp["sun_proper_night_regular"]
                ;
            return e;
        }
        public string GetTotal() {
            TimeSpan e =  GetNormalDayTS() + GetNormalNightTS() + GetHolidayDayTS() + GetHolidayNightTS();
            return e.ToString(@"hh\:mm");
        }
        public TimeSpan GetTotalTS() {
            TimeSpan e = GetNormalDayTS() + GetNormalNightTS() + GetHolidayDayTS() + GetHolidayNightTS();
            return e;
        }


        public static HourProcessor operator + (HourProcessor c1, HourProcessor c2) {
            HourProcessor f = new HourProcessor();
            string[] keys = f.hp.Keys.ToArray();
            foreach (string key in keys) { f.hp[key] = c1.hp[key] + c2.hp[key]; }
            f.total = c1.total + c2.total;
            f.totalday = c1.totalday + c2.totalday;
            f.totalnight = c1.totalnight + c2.totalnight;
            return f;
        }


    }
}
