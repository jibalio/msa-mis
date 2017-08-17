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

        public static int GetNumberOfDependents(int GID) {
            String q = @"SELECT count(DeID) FROM msadbarchive.dependents where GID={0};";
            q = string.Format(q, GID);
            return SQLTools.GetInt(q) - 2;
        }

        public static int GetCivilStatus(int GID) {
            string q = @"SELECT CivilStatus from msadbarchive.guards where GID=" + GID;
            return SQLTools.GetInt(q);
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
        

        //======================================================================
        //      PROCESS METHODS
        //======================================================================



        public static void ArchiveGuard(int GuardId) {
                SQLTools.ExecuteNonQuery($"call archive_guard({GuardId});");
        }

        public static DataTable GetAssignmentHistory(int GID) {
            return SQLTools.ExecuteQuery($@"select * from msadbarchive.sduty_assignment 
                                            left join msadb.client on msadb.client.cid = msadbarchive.sduty_assignment.cid
                                            where gid = {GID};");
        }
        




        //======================================================================
        //      GETTER METHODS
        //======================================================================

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

        public static Scheduling.Days GetDays(int DID) {
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

    }
}
