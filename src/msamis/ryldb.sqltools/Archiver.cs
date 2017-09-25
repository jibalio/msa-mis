 using System;
using System.Collections.Generic;
using System.Data;

namespace MSAMISUserInterface {
    public class Archiver {

        //=====================================================================
        // GUARD
        //=====================================================================
      
            

     
        //======================================================================
        //      PROCESS METHODS
        //======================================================================



        public static void ArchiveGuard(int GuardId) {
                    SQLTools.ExecuteNonQuery($"call archive_guard({GuardId});");
                    ComputeArchivedHours(GuardId);
            }


        public static void ComputeArchivedHours(int GuardId) {
            string q = $@"
                            select msadbarchive.period.pid, msadbarchive.attendance.atid, msadbarchive.dutydetails.did, DATE_FORMAT(msadbarchive.attendance.date, '%Y-%m-%d') as Date, SUBSTRING(DAYNAME(DATE_FORMAT(msadbarchive.attendance.date, '%Y-%m-%d')) FROM 1 FOR 3)  as day, 
							concat (msadbarchive.dutydetails.ti_hh,':',msadbarchive.dutydetails.ti_mm,' ',msadbarchive.dutydetails.ti_period, ' - ',msadbarchive.dutydetails.to_hh,':',msadbarchive.dutydetails.to_mm,' ',msadbarchive.dutydetails.to_period) as Schedule,
                            msadbarchive.attendance.timein,
                            msadbarchive.attendance.TimeOut
                            from msadbarchive.attendance
                            left join msadbarchive.dutydetails 
                            on msadbarchive.dutydetails.did=msadbarchive.attendance.did
                            left join msadbarchive.period 
                            on msadbarchive.period.pid=msadbarchive.attendance.pid
                            where msadbarchive.period.gid = '{GuardId}'
                            order by date asc;";
            DataTable dt = SQLTools.ExecuteQuery(q);
            var hourlist = new List<HourProcessor>();
            bool firstiter = true;
            int CurrentPid = 0;
            DataRow LastDataRow;
            foreach (DataRow dr in dt.Rows) {
                int ThisPid = int.Parse(dr["PID"].ToString());
                if (firstiter) {
                    CurrentPid = int.Parse(dr["PID"].ToString());
                    firstiter = false;
                }
                if (CurrentPid != ThisPid) {
                    Hours h = new Hours();
                    TimeSpan holiday_day, holiday_night, normal_day, normal_night, total;
                    holiday_day = holiday_night = normal_day = normal_night = total = new TimeSpan();
                    foreach (HourProcessor x in hourlist) {
                        h.holiday_day += x.GetHolidayDayTS();
                        h.holiday_night += x.GetHolidayNightTS();
                        h.normal_day += x.GetNormalDayTS();
                        h.normal_night += x.GetNormalNightTS(); ;
                        h.total += x.GetTotalTS();
                    }
                    SQLTools.ExecuteNonQuery($@"
                            UPDATE `msadbarchive`.`period` SET 
                            `holiday_day`='{h.GetHolidayDay()}', 
                            `holiday_night`='{h.GetHolidayNight()}', 
                            `normal_day`='{h.GetNormalDay()}', 
                            `normal_night`='{h.GetNormalNight()}' 
                            `total` = '{h.GetTotal()}'
                            WHERE `PID`='{CurrentPid}';
                            ");
                    CurrentPid = ThisPid;
                    hourlist.Clear();
                }

                DateTime ti = Attendance.GetDateTime_(dr["TimeIn"].ToString());
                DateTime to = Attendance.GetDateTime_(dr["TimeOut"].ToString());
                HourProcessor proc = new HourProcessor(ti, to, ti, to);
                hourlist.Add(proc);
                SQLTools.ExecuteNonQuery($@"
                    UPDATE `msadbarchive`.`attendance` SET 
                    `normal_day`='{proc.GetNormalDay()}', 
                    `normal_night`='{proc.GetNormalNight()}', 
                    `holiday_day`='{proc.GetHolidayDay()}', 
                    `holiday_night`='{proc.GetHolidayNight()}',
                    `total`='{proc.GetTotal()}'
                    WHERE `AtID`='{dr["atid"]}';
                    ");
                LastDataRow = dr;
            }


            // The General Attendance sumamry starts here.
            // i shoulve put more comments damn,
            // kani ang totalsummary, gi convert to hourprocessor for dat breakdonw,
            HourProcessor cumhours = new HourProcessor();
            Hours lh = new Hours();
            foreach (HourProcessor x in hourlist) {
                lh.holiday_day += x.GetHolidayDayTS();
                lh.holiday_night += x.GetHolidayNightTS();
                lh.normal_day += x.GetNormalDayTS();
                lh.normal_night += x.GetNormalNightTS(); ;
                lh.total += x.GetTotalTS();
                cumhours += x;
            }
            SQLTools.ExecuteNonQuery($@"
                            UPDATE `msadbarchive`.`period` SET 
                            `holiday_day`='{lh.GetHolidayDay()}', 
                            `holiday_night`='{lh.GetHolidayNight()}', 
                            `normal_day`='{lh.GetNormalDay()}', 
                            `normal_night`='{lh.GetNormalNight()}',
                            `hp`='{Data.SerializeHp(cumhours)}',
                            `total` = '{lh.GetTotal()}'
                            WHERE `PID`='{CurrentPid}';
                            ");
        }


        public static DataTable GetAttendanceSummary(int year, int month, int period, int gid) {
           return SQLTools.ExecuteQuery(
                $@"SELECT pid, certby, holiday_day, holiday_night, normal_day, normal_night, total FROM msadbarchive.period
                where month = {month}
                and period={period}
                and year = {year}
                and gid={gid};");
        }

        public static  string[] GetAttendanceTooltip(int aid, int period, int month, int year) {
            string hpblob =
                SQLTools.ExecuteSingleResult(
                    $@"SELECT hp FROM msadbarchive.period where aid={aid} and period={period} and month = {
                            month
                        } and year={year};");
            HourProcessor h = (HourProcessor)Payroll._DeserializeObject(hpblob);
            string[] a = new string[24];
            string[] b = {
                #region +Keys
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
                #endregion
            };

            for (int c = 0; c < b.Length; c++) {
                TimeSpan ts = h.hp[b[c]];
                a[c] = (b[c][4] == 'p' ? "Regular" : "Overtime") + ": " + (((int)(ts.TotalHours)).ToString("00") + ":" + ((int)ts.Minutes).ToString("00")).ToString() + " hrs.";
            }
            return a;
        }



        //======================================================================
        //      GETTER METHODS
        //======================================================================

        #region + Guard Details Getters
        public static DataTable GetAllGuards(string SearchFilter, string ColumnName_DescAsc) {

            var query = $@"Select guards.gid,concat(ln,', ',fn,' ',mn) as `name`,
                        case gender when 1 then 'Male' when 2 then 'Female' end as 'GENDER', 
                        concat(streetno, ', ', street, ', ', brgy, ', ', city) as Location,
                         cellno as 'CONTACTNO' 
                         FROM msadbarchive.Guards 
                         left join msadbarchive.address on msadbarchive.address.GID=msadbarchive.guards.gid 
                         where (concat(ln,', ',fn,' ',mn) like '{SearchFilter}%' OR concat(ln,', ',fn,' ',mn) like '%{SearchFilter}%' OR concat(ln,', ',fn,' ',mn) LIKe '%{SearchFilter}')
                         GROUP BY name ORDER BY {ColumnName_DescAsc} ;";
            return (SQLTools.ExecuteQuery(query));
        }

        public static DataTable GetGuardsBasicData(int GID) {
            return SQLTools.ExecuteQuery("SELECT * FROM msadbarchive.guards WHERE GID = " + GID);
        }

        public static DataTable GetGuardsAddresses(int GID) {
            return SQLTools.ExecuteQuery("SELECT * FROM msadbarchive.address WHERE GID=" + GID + " ORDER BY Atype ASC");
        }
        public static DataTable GetGuardsParents(int GID) {
            return SQLTools.ExecuteQuery("SELECT * FROM msadbarchive.dependents WHERE GID=" + GID + " AND (DRelationship = '4' OR DRelationship = '5' OR DRelationship = '6') ORDER BY DRelationship ASC");
        }
        public static DataTable GetGuardsDependents(int GID) {
            return SQLTools.ExecuteQuery("SELECT * FROM msadbarchive.dependents WHERE GID=" + GID + " AND (DRelationship = '1' OR DRelationship = '2' OR DRelationship = '3') ORDER BY DeID ASC");
        }

        public static DataTable GetGuardsDependentsView(int GID) {
            return SQLTools.ExecuteQuery("SELECT DeID, concat(ln,', ',fn,' ',mn), case DRelationship when '1' then 'Son' when '2' then 'Daughter' when '3' then 'Sibling' end as Relationship FROM msadbarchive.dependents WHERE GID=" + GID + " AND (DRelationship = '1' OR DRelationship = '2' OR DRelationship = '3') ORDER BY DeID ASC");
        }
        #endregion

        #region Duty Details Getters

        public static DataTable GetDutyDetailsSummary(int AID) {
            DataTable dt =
                SQLTools.ExecuteQuery(@"
                    select did, concat (ti_hh,':',ti_mm,' ',ti_period) as TimeIn,
                    concat (to_hh,':',to_mm,' ',to_period) as TimeOut,
                    'days_columnMTWThFSSu' as days from 
                    msadbarchive.dutydetails where AID=" + AID);
            foreach (DataRow e in dt.Rows) {
                e.SetField("days", GetDays(int.Parse(e["did"].ToString())).ToString());
            }
            return dt;
        }

        // meta function 
        private static Scheduling.Days GetDays(int DID) {
            String q = "select mon, tue, wed, thu, fri, sat, sun from dutydetails where DID=" + DID;
            DataTable dt = SQLTools.ExecuteQuery(q);
            return new Scheduling.Days(
                dt.Rows[0]["mon"].ToString() == "1",
                dt.Rows[0]["tue"].ToString() == "1",
                dt.Rows[0]["wed"].ToString() == "1",
                dt.Rows[0]["thu"].ToString() == "1",
                dt.Rows[0]["fri"].ToString() == "1",
                dt.Rows[0]["sat"].ToString() == "1",
                dt.Rows[0]["sun"].ToString() == "1"
            );
        }

        #endregion

        #region Period Operations

        public static DataTable GetPeriods(int GID) {
            return SQLTools.ExecuteQuery($@"SELECT month, period, year
                                        FROM msadbarchive.period 
                                       where GID='{GID}' 
                                        group by month,period,year order by year desc, month desc, period desc");
        }

        #endregion

        #region Attendance Retrieval
        public static DataTable GetAttendance(int GID, int month, int period, int year) {
            String q = $@"select msadbarchive.attendance.atid, msadbarchive.dutydetails.did, CONCAT ((DATE_FORMAT(msadbarchive.attendance.date, '%d')), ' / ', 
							(concat (msadbarchive.dutydetails.ti_hh,':',msadbarchive.dutydetails.ti_mm, SUBSTRING(msadbarchive.dutydetails.ti_period,1,1) , ' - ',msadbarchive.dutydetails.to_hh,':',msadbarchive.dutydetails.to_mm,SUBSTRING(msadbarchive.dutydetails.to_period,1,1)))) as Schedule,
                            (concat (SUBSTRING(msadbarchive.attendance.timein,1,7),' - ', SUBSTRING(msadbarchive.attendance.TimeOut,1,7))) as ti_to,
                            msadbarchive.attendance.normal_day as ND,
                            msadbarchive.attendance.normal_night as NN,
                            msadbarchive.attendance.holiday_day as HD,
                            msadbarchive.attendance.holiday_night as HN
                            from msadbarchive.attendance
                            left join msadbarchive.dutydetails 
                            on msadbarchive.dutydetails.did=msadbarchive.attendance.did
                            left join msadbarchive.period 
                            on msadbarchive.period.pid=msadbarchive.attendance.pid
                            where msadbarchive.period.period = '{period}'
                            and msadbarchive.period.month = '{month}'
                            and msadbarchive.period.year = '{year}'
                            and msadbarchive.period.gid = '{GID}'
                            order by date asc;
                            ";
            DataTable d = SQLTools.ExecuteQuery(q);
            return d;
        }


        #endregion



        public static DataTable GetAssignmentHistory(int GID) {
            return SQLTools.ExecuteQuery($@"select aid, DATE_FORMAT(assignedon, '%Y-%m-%d') as AssignedOn, DATE_FORMAT(unassignedon, '%Y-%m-%d') as UnassignedOn, 
                                            name
                                            from msadbarchive.sduty_assignment 
                                            left join msadb.client on msadb.client.cid = msadbarchive.sduty_assignment.cid
                                            where gid = {GID};");
        }

        public static Payroll GetPayroll(int GID, int month, int period, int year) {
            Payroll py = new Payroll(SQLTools.ExecuteQuery($@"select * from msadbarchive.payroll where
                                            gid = {GID}
                                            and period = {period}
                                            and year = {year}
                                            and month = {month} ").Rows[0]);
            return py;
        }

        public static DataTable GetAssignmentDetails(int aid) {
            // Location, ContractStart, ContractEnd
            String q = @"SELECT address as location,
                        AssignedOn as contractstart, UnassignedOn as contractend FROM msadbarchive.sduty_assignment
                        where msadbarchive.sduty_assignment.aid=" + aid + ";";
            return SQLTools.ExecuteQuery(q);
        }

        public static DataTable GetAllAssignmentDetails(int AID) {
            String q = @"/* return Gid, Name sa Guard, CID, name sa client, status */
                            select 
                            msadbarchive.guards.gid as gid,
                            msadb.client.cid as cid,
                            concat(ln,', ',fn,' ',mn) as guardname,
                            client.name as clientname
                             from msadbarchive.sduty_assignment
                            left join msadb.client on msadbarchive.sduty_assignment.cid = client.cid
                            left join msadbarchive.guards on guards.gid = sduty_assignment.GID
                            where sduty_assignment.AID = " + AID;
            return SQLTools.ExecuteQuery(q);
        }

    }
}
