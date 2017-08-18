using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSAMISUserInterface;

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
                         ORDER BY {ColumnName_DescAsc};";
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
            String q = $@"
                        select msadbarchive.attendance.atid, msadbarchive.dutydetails.did, DATE_FORMAT(msadbarchive.attendance.date, '%Y-%m-%d') as Date, SUBSTRING(DAYNAME(DATE_FORMAT(msadbarchive.attendance.date, '%Y-%m-%d')) FROM 1 FOR 3)  as day, 
							concat (msadbarchive.dutydetails.ti_hh,':',msadbarchive.dutydetails.ti_mm,' ',msadbarchive.dutydetails.ti_period, ' - ',msadbarchive.dutydetails.to_hh,':',msadbarchive.dutydetails.to_mm,' ',msadbarchive.dutydetails.to_period) as Schedule,
                            msadbarchive.attendance.timein,
                           msadbarchive.attendance.TimeOut
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
    }
}
