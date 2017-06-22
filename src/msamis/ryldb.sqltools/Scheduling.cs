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


        #region Add Requests (Assignment + Dismissal)       ✔Done
        /// <summary>
        /// Adds an assignment request. Note: This isn't an actual assignment yet.
        /// </summary>
        /// <param name="CID">Client ID (the requester)</param>
        /// <param name="AssStreetNo"></param>
        /// <param name="AssStreetName"></param>
        /// <param name="AssBrgy"></param>
        /// <param name="AssCity"></param>
        /// <param name="ContractStart"></param>
        /// <param name="ContractEnd">DateTime ang ipass diri</param>
        /// <param name="NoGuards">Number of Guards</param>
        public static void AddAssignmentRequest(int CID, string AssStreetNo, string AssStreetName, string AssBrgy, string AssCity, DateTime ContractStart, DateTime ContractEnd, int NoGuards) {
            String madeon = DateTime.Now.ToString("yyyy-MM-dd");
            String q1 = String.Format("INSERT INTO `msadb`.`request` (`RequestType`, `CID`, `DateEntry`) VALUES ('{0}', '{1}', '{2}');",
                        Scheduling.Property.Assignment, CID, madeon);
            SQLTools.ExecuteNonQuery(q1);
            String rid = SQLTools.getLastInsertedId("request", "rid");
            String query = String.Format("INSERT INTO `msadb`.`request_assign` " +
                " ( `ContractStart`, `ContractEnd`, `RStatus`, `streetno`, `streetname`, `brgy`, `city`,`noguards`,`rid`)" +
                " VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}','{8}');",
                 ContractStart.ToString("yyyy-MM-dd"), ContractEnd.ToString("yyyy-MM-dd"),
                Scheduling.Property.Pending,
                AssStreetNo, AssStreetName, AssBrgy, AssCity, NoGuards, rid);
            Console.WriteLine("AddAssignmentRequest: \n" + query);
            SQLTools.ExecuteNonQuery(query);
        }

        /// <summary>
        /// Adds a dismissal request
        /// </summary>
        /// <param name="cid">ClientID of requester</param>
        /// <param name="did">Duty Detail ID of guard. DID can be found in the DataTable 'select guards to dismiss'.</param>
        /// <param name="ReportType">Report Type. DO NOT HARDCODE. Possible Values:
        /// Enumeration.ReportType.Injury
        /// Enumeration.ReportType.Complaint
        /// Enumeration.ReportType.Accident
        /// </param>
        /// <param name="pcompleting">Idk what this field is. Naa ni sa IncidentReport table.</param>
        /// <param name="EventDate">Date of incident.</param>
        /// <param name="location">Location of incident</param>
        /// <param name="description">Description</param>
        public static void AddDismissalRequest(int cid, int[] gid, int ReportType, String pcompleting, DateTime EventDate,
            String location, String description) {
            // Add a request, specifying client.
            String q = "INSERT INTO `msadb`.`request` (`RequestType`, `CID`, `DateEntry`) VALUES ('{0}', '{1}', '{2}')";
            q = String.Format(q, Enumeration.RequestType.Dismissal, cid, SQLTools.getDateTime());
            SQLTools.ExecuteNonQuery(q);
            String lid = SQLTools.getLastInsertedId("request", "rid");
            for (int c = 0; c < gid.Length; c++) {
                q = "INSERT INTO `msadb`.`request_dismiss` (`RID`, `gid`) VALUES ('" + lid.ToString() + "', '" + gid[c] + "');";
                SQLTools.ExecuteNonQuery(q);
            }
            String RDID = SQLTools.getLastInsertedId("request_dismiss", "rdid");
            q = String.Format(@"INSERT INTO `msadb`.`incidentreport` 
                         (`RDID`, `ReportType`, `DateEntry`, `PCompleting`, `EventDate`, `EventLocation`, `Description`) 
                         VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');",
                        RDID, ReportType, SQLTools.getDateTime(), pcompleting, EventDate.ToString("yyyy-MM-dd"),location, description
                        );
            SQLTools.ExecuteNonQuery(q);
        }

        #endregion

        
        #region Add Assignment / Dismissal
        public static void AddAssignment(int rid, int[] gid) {
            // First check if rid is type assignment.
            if (SQLTools.ExecuteSingleResult("select requesttype from request where rid=" + rid) == Enumeration.RequestType.Assignment.ToString()) {
                String raid = SQLTools.ExecuteSingleResult("select raid from request_assign where rid=" + rid);
                foreach (int g in gid) {
                    // Add assignment in assignment table/
                   String q = String.Format("INSERT INTO `msadb`.`sduty_assignment` (`GID`, `RAID`, `AStatus`) VALUES ('{0}', '{1}', '{2}');",
                   g, raid, Enumeration.Schedule.Active);
                    SQLTools.ExecuteNonQuery(q);
                    // Update guard status.
                    //q = "UPDATE `msadb`.`guards` SET `GStatus`='"+Enumeration.GuardStatus.Active+"' WHERE `GID`='"+g+"';";
                   // SQLTools.ExecuteNonQuery(q);
                }
            } else
                MessageBox.Show("Request is not an assignment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }


        /// <summary>
        /// Steps:
        /// 1.) Get Guards to be dismissed (based on RID)
        /// 2.) Set Guard's assignment to "Dismissed"
        /// 3.) Set Guard's status to "Inactive"
        /// 4.) Set Request's status to "Approved"
        /// </summary>
        /// <param name="rid">Request ID to approve dismissal.</param>
        public static void ApproveDismissal(int rid) {
            // Step 1;
            DataTable GuardsToBeDismissed = SQLTools.ExecuteQuery(@"select guards.gid from guards 
                                            left join sduty_assignment on sduty_assignment.GID = guards.gid
                                            left join request_dismiss on request_dismiss.gid = guards.gid
                                            where rid = 27;");
            //Step 2:
            foreach (DataRow e in GuardsToBeDismissed.Rows) {
                String q = @"UPDATE `msadb`.`sduty_assignment` SET `AStatus`='2' WHERE `gid`='"+e[0]+"';";
                SQLTools.ExecuteNonQuery(q);
                // Step 3;
                q = @"UPDATE `msadb`.`guards` SET `GStatus`='2' WHERE `GID`='"+e[0]+"'";
                SQLTools.ExecuteNonQuery(q);
            }
            // Step 4
            UpdateRequestStatus(rid, Enumeration.RequestStatus.Approved);
        }
        #endregion

        /// <summary>
        /// Declines a request. Does no further processes.
        /// </summary>
        /// <param name="rid">Request ID to decline</param>
        public static void DeclineRequest(int rid) {
            UpdateRequestStatus(rid, Enumeration.RequestStatus.Declined);
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

        public static String GetNumberOfPendingClientRequests() {
            throw new NotImplementedException();
        }
        #endregion


        #region Non-Query Methods
        // public static void AddDutyDetails()




        #region View Client Request Methods
        public static DataTable GetRequests() {
            String query = "SELECT rid, name, dateentry, case requesttype when 1 then 'Assignment' when 2 then 'Dismissal' end as type FROM msadb.request inner join client on request.cid=client.cid;";
            return SQLTools.ExecuteQuery(query);
        }


        public static DataTable GetRequests(DateTime date) {
            String q = "select rid, name, dateentry, case requesttype when 1 then 'Assignment' when 2 then 'Dismissal' end as type from msadb.request inner join client on request.cid=client.cid where dateentry='{0}'";
            return SQLTools.ExecuteQuery(q, "", "", "dateentry desc", new String[] { date.ToString("yyyy-MM-dd") });
        }

        public static DataTable GetClients() {
            return Client.GetClients();
        }

        public static DataTable GetGuardsAssigned(int cid, String keyword) {
            String q = "select guards.gid, concat(ln,', ',fn,' ',mn) as Name, concat(streetno,', ',streetname,', ',brgy,', ',city) as Location,concat(timein, timeout, days) as schedule from sduty_assignment inner join request_assign on request_assign.RAID=sduty_assignment.RAID left join guards on guards.gid = sduty_assignment.gid left join dutydetails on dutydetails.aid = sduty_assignment.aid" +
                " where cid={0}"; //comment
            return SQLTools.ExecuteQuery(q, "name", keyword, "name asc", new String[] { cid.ToString() });
        }
        #endregion

        public static DataTable GetAssignmentRequestDetails(int rid) {
            String q = "SELECT name, concat(streetno,', ',streetname,', ',brgy,', ',city) as Location, contractstart, contractend, noguards FROM request left join request_assign on request_assign.rid = request.rid left join client on request.cid = client.cid "
                 + " where request.rid={0}"; ;
            return SQLTools.ExecuteQuery(q, null, null, null, new String[] { rid.ToString() });
        }

        //  public static DataTable GetDismissalRequestDetails (int rid) {
        //    String q = ""
        // }







        public static DataTable ViewGuardsFromClient(int cid) {
            String q = @"select did, concat(ln,', ',fn,' ',mn) as Name, concat(streetno, ', ', streetname, ', ', brgy, ', ', city) as Location,concat(timein, '-', timeout, ' ', days) as Schedule from guards left join sduty_assignment on guards.gid = sduty_assignment.gid 
                        left join dutydetails on sduty_assignment.aid = dutydetails.AID
                        left
                        join request_assign on sduty_assignment.raid = request_assign.raid; ";
            return SQLTools.ExecuteQuery(q);
        }






        #region View Assignments

        public static DataTable GetAssignmentsByClient(int cid, string filter) {
            String q = @"select 
                        guards.gid, dutydetails.did, sduty_assignment.aid,
                        concat(ln,', ',fn,' ',mn) as name,
                        concat(streetno, ', ', streetname, ', ', brgy, ', ', city) as Location,
                        case 
	                        when concat(timein, timeout, days)  is null then 'Unscheduled'
                            else concat(timein, timeout, days) 
                            end as schedule
                         from guards 
                        left join sduty_assignment on sduty_assignment.gid=guards.gid
                        left join dutydetails on sduty_assignment.aid=dutydetails.aid
                        left join request_assign on request_assign.raid=sduty_assignment.raid";
            return SQLTools.ExecuteQuery(q);
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









        public static void UpdateRequestStatus (int rid, int val) {
            String q = @"UPDATE `msadb`.`request` SET `RStatus`='"+val+"' WHERE `RID`='"+rid+"';";
            SQLTools.ExecuteNonQuery(q);
        }






    }
}
#endregion
