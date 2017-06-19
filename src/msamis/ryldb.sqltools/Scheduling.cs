using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSAMISUserInterface {



    public class Scheduling {
        private class Property {
            public const int Assignment = 1;
            public const int Dismissal = 2;
            public const int Pending = 1;
            public const int Approved = 2;
            public const int Denied = 3;
        }

        #region Sidepanel Methods
        public static String GetNumberOfUnscheduledAssignments() {
            throw new NotImplementedException();
        }

        public static String GetNumberOfUnassignedGuards() {
            throw new NotImplementedException();
        }

        public static String GetNumberOfClientRequest() {
            throw new NotImplementedException();
        }
        #endregion


        #region Non-Query Methods
       // public static void AddDutyDetails()

        #endregion








        #region View Client Request Methods
        public static DataTable GetRequests() {
            String query = "SELECT rid, name, dateentry, case requesttype when 1 then 'Assignment' when 2 then 'Dismissal' end as type FROM msadb.request inner join client on request.cid=client.cid;";
            return SQLTools.ExecuteQuery(query);
        }

        //public static DataTable GetAssignedGuards

        public static DataTable GetRequests(DateTime date) {
            String q = "select rid, name, dateentry, case requesttype when 1 then 'Assignment' when 2 then 'Dismissal' end as type from msadb.request inner join client on request.cid=client.cid where dateentry='{0}'";
            return SQLTools.ExecuteQuery(q,"","","dateentry desc",new String[] { date.ToString("yyyy-MM-dd") });
        }

        public static DataTable GetClients() {
            return Client.GetClients();
        }

        public static DataTable GetGuardsAssigned(DateTime date) {
            throw new NotImplementedException();
        }


        //DONE
        public static void AddAssignmentRequest(int CID, string AssStreetNo, string AssStreetName, string AssBrgy, string AssCity, DateTime ContractStart, DateTime ContractEnd, int NoGuards) {
            String madeon = DateTime.Now.ToString("yyyy-MM-dd");
            String q1 = String.Format("INSERT INTO `msadb`.`request` (`RequestType`, `CID`, `DateEntry`) VALUES ('{0}', '{1}', '{2}');",
                        Scheduling.Property.Assignment, CID, madeon);
            SQLTools.ExecuteNonQuery(q1);
            String query = String.Format("INSERT INTO `msadb`.`request_assign` " +
                " ( `ContractStart`, `ContractEnd`, `RStatus`, `streetno`, `streetname`, `brgy`, `city`)" +
                " VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');",
                 ContractStart.ToString("yyyy-MM-dd"), ContractEnd.ToString("yyyy-MM-dd"),
                Scheduling.Property.Pending,
                AssStreetNo, AssStreetName, AssBrgy, AssCity);
            Console.WriteLine("AddAssignmentRequest: \n" + query);

            SQLTools.ExecuteNonQuery(query);

        }

        public static void AddDismissalRequest(int gid) {
            String madeon = DateTime.Now.ToString("yyyy-MM-dd");
            String q1 = "INSERT INTO `msadb`.`request` (`RequestType`, `CID`, `DateEntry`) VALUES ('2', '1', '2017-06-18');";
        }

        public static DataTable GetAllAssignmentRequestDetails() {
            throw new NotImplementedException();
        }

        public static DataTable GetAllDismissalRequestDetails() {
            throw new NotImplementedException();
        }

        #endregion

        #region View Assignments

        public static DataTable GetAssignmentsByClient(int cid, string filter) {
            // Note: Filter can be EMPTY but NOT null.
            throw new NotImplementedException();
        }

        public static DataTable GetDutyDays(int did) {
            // Return all attendance details. Columns: Date - Status
            throw new NotImplementedException();
        }

        public static DataTable GetAllDutyDetails() {
            //Paki take note please sa mga index sa columns and paki convert sa mga ID 
            //(pero ayaw kuhaa) into values please like name sa client instead of CID
            throw new NotImplementedException();
        }

        #endregion















    }
}
