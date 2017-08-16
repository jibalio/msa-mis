using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSAMISUserInterface;

namespace ryldb.sqltools {
    public class Archiver {

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
            string query;
            string orderbyclause;
            query = $@"Select guards.gid,concat(ln,', ',fn,' ',mn) as NAME,
                        case gender when 1 then 'Male' when 2 then 'Female' end as 'GENDER', 
                        concat(streetno, ', ', street, ', ', brgy, ', ', city) as Location,
                         cellno as 'CONTACTNO' 
                         FROM msadbarchive.Guards 
                         left join msadbarchive.address on msadbarchive.address.GID=msadbarchive.guards.gid 
                         where (name like '{SearchFilter}%' OR name like '%{SearchFilter}%' OR name LIKe '%{SearchFilter}')
                         ORDER BY NAME ASC;";
            return (SQLTools.ExecuteQuery(query));
        }

    }
}
