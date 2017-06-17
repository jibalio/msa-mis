using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ryldb.sqltools {
    class Scheduling {

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

        public static void AddAssignmentRequest(DateTime date) {
            throw new NotImplementedException();
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
