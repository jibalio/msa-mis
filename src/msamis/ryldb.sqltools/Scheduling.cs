using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
        public static DataGrid GetRequests() {
            throw new NotImplementedException();
        }

        public static DataGrid GetRequestsFromDate(DateTime date) {
            throw new NotImplementedException();
        }

        public static DataGrid GetClients(DateTime date) {
            throw new NotImplementedException();
        }

        public static DataGrid GetGuardsAssigned(DateTime date) {
            throw new NotImplementedException();
        }

        public static void AddAssignmentRequest(int CID, string AssStreetNo, string AssStreetName, 
            string AssBrgy, string AssCity, DateTime ContractStart, DateTime ContractEnd, int NoGuards) {
            // Universal Format: yyyy-MM-dd
            String madeon = DateTime.Now.ToString("yyyy-MM-dd");
            String query = String.Format("INSERT INTO `msadb`.`request_assign` "+
                " (`CID`, `DateEntry`, `ContractStart`, `ContractEnd`, `RStatus`, `streetno`, `streetname`, `brgy`, `city`)" +
                " VALUES ('{0}', '{1}', '{2}', '2017-10-13', '1', '2', 'Kalamansi St.', 'Brgy. 4A', 'Davao City');",
                CID, madeon, ContractStart.ToString("yyyy-MM-dd"), ContractEnd.ToString("yyyy-MM-dd"),
                1, // 1 means pending request.
                AssStreetNo,AssStreetName, AssBrgy,AssCity);
            Console.WriteLine("AddAssignmentRequest: \n" + query);
            
                MySqlCommand com = new MySqlCommand(query, SQLTools.conn);
                SQLTools.conn.Open();
                com.ExecuteNonQuery();
            
           
            
        }

        public static void AddDismissalRequest (int gid) {
            throw new NotImplementedException();
        }

        public static DataGrid GetAllAssignmentRequestDetails() {
            throw new NotImplementedException();
        }

        public static DataGrid GetAllDismissalRequestDetails() {
            throw new NotImplementedException();
        }

        #endregion

        #region View Assignments

        public static DataGrid GetAssignmentsByClient (int cid, string filter) {
            // Note: Filter can be EMPTY but NOT null.
            throw new NotImplementedException();
        }

        public static DataGrid GetDutyDays (int did) {
            // Return all attendance details. Columns: Date - Status
            throw new NotImplementedException();
        }

        public static DataGrid GetAllDutyDetails() {
            //Paki take note please sa mga index sa columns and paki convert sa mga ID 
            //(pero ayaw kuhaa) into values please like name sa client instead of CID
            throw new NotImplementedException();
        }

        #endregion
        















    }
}
