using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSAMISUserInterface {
    class HourProcessor {

        #region Fields
        TimeSpan nsu_proper_day_normal, nsu_proper_day_special, nsu_proper_day_regular, nsu_proper_night_normal,
                nsu_proper_night_special, nsu_proper_night_regular, nsu_overtime_day_normal, nsu_overtime_day_special,
                nsu_overtime_day_regular, nsu_overtime_night_normal, nsu_overtime_night_special, nsu_overtime_night_regular,
                sun_proper_day_normal, sun_proper_day_special, sun_proper_day_regular, sun_proper_night_normal,
                sun_proper_night_special, sun_proper_night_regular, sun_overtime_day_normal, sun_overtime_day_special,
                sun_overtime_day_regular, sun_overtime_night_normal, sun_overtime_night_special, sun_overtime_night_regular;

        TimeSpan total, totalday, totalnight;

        #endregion

        public HourProcessor(DateTime ti, DateTime to) {
            DateTime NightStart = new DateTime(ti.Year, ti.Month, ti.Day, 22, 00, 00);
            DateTime NightEnd = new DateTime(ti.Year, ti.Month, ti.Day, 6, 00, 00);
            DateTime Midnight = new DateTime(ti.Year, ti.Month, ti.Day, 0, 0, 0).AddDays(1); DateTime maxStart; DateTime minEnd; DateTime minStart; DateTime maxEnd;


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





                Attendance.HE_internal o = Attendance.IsHolidayToday_(ti);
                // Check if today is holiday.
                if (o.isholiday) {
                    if (o.type == Enumeration.HolidayType.Regular) {
                        if (ti.DayOfWeek == DayOfWeek.Sunday) {
                            sun_proper_day_regular += d1_day;
                            sun_proper_night_regular += d1_night;
                        } else {
                            nsu_proper_day_regular += d1_day;
                            nsu_proper_night_regular += d1_night;
                        }
                    } else {
                        if (ti.DayOfWeek == DayOfWeek.Sunday) {
                            sun_proper_day_special += d1_day;
                            sun_proper_night_special += d1_night;
                        } else {
                            nsu_proper_day_special += d1_day;
                            nsu_proper_night_special += d1_night;
                        }
                    }
                } else {
                    if (ti.DayOfWeek == DayOfWeek.Sunday) {
                        sun_proper_day_normal += d1_day;
                        sun_proper_night_normal += d1_night;
                    } else {
                        nsu_proper_day_normal += d1_day;
                        nsu_proper_night_normal += d1_night;
                    }
                }



                //Check if tomorrow is holiday.
                if (Attendance.IsHolidayTomorrow(ti)) {
                    if (o.type == Enumeration.HolidayType.Regular) {
                        if (ti.DayOfWeek == DayOfWeek.Sunday) {
                            sun_proper_day_regular += d2_day;
                            sun_proper_night_regular += d2_night;
                        } else {
                            nsu_proper_day_regular += d2_day;
                            nsu_proper_night_regular += d2_night;
                        }
                    } else {
                        if (ti.DayOfWeek == DayOfWeek.Sunday) {
                            sun_proper_day_special += d2_day;
                            sun_proper_night_special += d2_night;
                        } else {
                            nsu_proper_day_special += d2_day;
                            nsu_proper_night_special += d2_night;
                        }
                    }
                } else {
                    if (ti.DayOfWeek == DayOfWeek.Sunday) {
                        sun_proper_day_normal += d2_day;
                        sun_proper_night_normal += d2_night;
                    } else {
                        nsu_proper_day_normal += d2_day;
                        nsu_proper_night_normal += d2_night;
                    }
                }

            } else {
                // if same day
                NightEnd = new DateTime(ti.Year, ti.Month, ti.Day, 6, 00, 00);
                maxStart = ti < NightStart ? ti : NightStart;
                minStart = ti > NightStart ? ti : NightStart;
                minEnd = to < NightEnd ? to : NightEnd;
                maxEnd = to > NightEnd ? to : NightEnd;

                Attendance.HE_internal o = Attendance.IsHolidayToday_(ti);
                // Check if today is holiday.
                if (o.isholiday) {
                    if (Attendance.IsHolidayToday(ti)) {
                        if (o.type == Enumeration.HolidayType.Regular) {
                            if (ti.DayOfWeek == DayOfWeek.Sunday) {
                                sun_proper_day_regular += (to - NightEnd) > TimeSpan.FromSeconds(0) ? to - NightEnd : new TimeSpan(0, 0, 0);
                                sun_proper_day_regular += (NightStart - minStart) > TimeSpan.FromSeconds(0) ? NightStart - minStart : new TimeSpan(0, 0, 0);
                                sun_proper_night_regular += (minEnd - maxStart) > TimeSpan.FromSeconds(0) ? minEnd - maxStart : new TimeSpan(0, 0, 0);
                            } else {
                                nsu_proper_day_regular += (to - NightEnd) > TimeSpan.FromSeconds(0) ? to - NightEnd : new TimeSpan(0, 0, 0);
                                nsu_proper_day_regular += (NightStart - minStart) > TimeSpan.FromSeconds(0) ? NightStart - minStart : new TimeSpan(0, 0, 0);
                                nsu_proper_night_regular += (minEnd - maxStart) > TimeSpan.FromSeconds(0) ? minEnd - maxStart : new TimeSpan(0, 0, 0);
                            }
                        } else {
                            if (ti.DayOfWeek == DayOfWeek.Sunday) {
                                sun_proper_day_special += (to - NightEnd) > TimeSpan.FromSeconds(0) ? to - NightEnd : new TimeSpan(0, 0, 0);
                                sun_proper_day_special += (NightStart - minStart) > TimeSpan.FromSeconds(0) ? NightStart - minStart : new TimeSpan(0, 0, 0);
                                sun_proper_night_special += (minEnd - maxStart) > TimeSpan.FromSeconds(0) ? minEnd - maxStart : new TimeSpan(0, 0, 0);
                            } else {
                                nsu_proper_day_special += (to - NightEnd) > TimeSpan.FromSeconds(0) ? to - NightEnd : new TimeSpan(0, 0, 0);
                                nsu_proper_day_special += (NightStart - minStart) > TimeSpan.FromSeconds(0) ? NightStart - minStart : new TimeSpan(0, 0, 0);
                                nsu_proper_night_special += (minEnd - maxStart) > TimeSpan.FromSeconds(0) ? minEnd - maxStart : new TimeSpan(0, 0, 0);
                            }
                        }
                    } else {
                        if (ti.DayOfWeek == DayOfWeek.Sunday) {
                            sun_proper_day_normal += (to - NightEnd) > TimeSpan.FromSeconds(0) ? to - NightEnd : new TimeSpan(0, 0, 0);
                            sun_proper_day_normal += (NightStart - minStart) > TimeSpan.FromSeconds(0) ? NightStart - minStart : new TimeSpan(0, 0, 0);
                            sun_proper_night_normal += (minEnd - maxStart) > TimeSpan.FromSeconds(0) ? minEnd - maxStart : new TimeSpan(0, 0, 0);
                        } else {
                            nsu_proper_day_normal += (to - NightEnd) > TimeSpan.FromSeconds(0) ? to - NightEnd : new TimeSpan(0, 0, 0);
                            nsu_proper_day_normal += (NightStart - minStart) > TimeSpan.FromSeconds(0) ? NightStart - minStart : new TimeSpan(0, 0, 0);
                            nsu_proper_night_normal += (minEnd - maxStart) > TimeSpan.FromSeconds(0) ? minEnd - maxStart : new TimeSpan(0, 0, 0);
                        }
                    }
                }
            }
        }
        public HourProcessor() {

        }
    }
}
