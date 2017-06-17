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

        #region View Client Request Methods
        public static DataTable GetRequests() {
            String query = "SELECT rid, name, rstatus FROM msadb.request_assign inner join client on request_assign.cid=client.cid;";
            return SQLTools.ExecuteQuery(query);
             
        }

        public static DataTable GetRequestsFromDate(DateTime date) {
            throw new NotImplementedException();
        }

        public static DataTable GetClients(DateTime date) {
           return  Client.GetClients();
        }

        public static DataTable GetGuardsAssigned(DateTime date) {
            throw new NotImplementedException();
        }


        //DONE
        public static void AddAssignmentRequest(int CID, string AssStreetNo, string AssStreetName, string AssBrgy, string AssCity, DateTime ContractStart, DateTime ContractEnd, int NoGuards) {
            // Universal Format: yyyy-MM-dd
            String madeon = DateTime.Now.ToString("yyyy-MM-dd");
            String query = String.Format("INSERT INTO `msadb`.`request_assign` "+
                " (`CID`, `DateEntry`, `ContractStart`, `ContractEnd`, `RStatus`, `streetno`, `streetname`, `brgy`, `city`)" +
                " VALUES ('{0}', '{1}', '{2}', '2017-10-13', '1', '2', 'Kalamansi St.', 'Brgy. 4A', 'Davao City');",
                CID, madeon, ContractStart.ToString("yyyy-MM-dd"), ContractEnd.ToString("yyyy-MM-dd"),
                1, // 1 means pending request.
                AssStreetNo,AssStreetName, AssBrgy,AssCity);
            Console.WriteLine("AddAssignmentRequest: \n" + query);
            SQLTools.ExecuteNonQuery(query);
        }

        public static void AddDismissalRequest (int gid) {
            throw new NotImplementedException();
        }

        public static DataTable GetAllAssignmentRequestDetails() {
            throw new NotImplementedException();
        }

        public static DataTable GetAllDismissalRequestDetails() {
            throw new NotImplementedException();
        }

        #endregion

        #region View Assignments

        public static DataTable GetAssignmentsByClient (int cid, string filter) {
            // Note: Filter can be EMPTY but NOT null.
            throw new NotImplementedException();
        }

        public static DataTable GetDutyDays (int did) {
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
