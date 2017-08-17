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


   

        public static DataTable GetAssignmentHistory(int GuardId) {
            throw  new NotImplementedException();
        }
    }
}
