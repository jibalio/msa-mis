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


        static String empty = "Search or filter";

        #region Request Retrieval (DataTable)  -- General View    ✔Done


        

        /// <summary>
        /// Gets all requests made on a specific date.
        /// </summary>
        /// <param name="date">DateTime object.</param>
        /// <returns>DT columns: rid, name, dateentry, type</returns>
        ///
        public static DataTable GetRequests(String searchkeyword, int ClientFilter, int StatusFilter, String SearchColumn, String orderby, DateTime date) {
            String q = @"select rid, name, dateentry, 
                        case requesttype 
                        when 1 then 'Assignment'
                        when 2 then 'Dismissal' 
                        end as type
                        from msadb.request 
                        left join client on request.cid=client.cid 
                        where dateentry='{0}' ";
                        
            searchkeyword = cleansearch(searchkeyword);
            return SQLTools.ExecuteQuery(q,SearchColumn, searchkeyword, "dateentry desc", new String[] { date.ToString("yyyy-MM-dd")});
        }

        public static DataTable GetRequests(String searchkeyword, int ClientFilter, int TypeFilter, String ColumnToSortByAscDesc, String orderby) {
            String q = "select rid, name, dateentry, case requesttype when 1 then 'Assignment' when 2 then 'Dismissal' end as type from msadb.request inner join client on request.cid=client.cid ";
            if (ClientFilter !=-1 || TypeFilter!=-1) {
                q += " where 1=1 ";
                if (ClientFilter != -1) q += " and client.cid=" + ClientFilter;
                if (TypeFilter != 0) q += " and requesttype=" + TypeFilter;
            }
            searchkeyword = cleansearch(searchkeyword);
            return SQLTools.ExecuteQuery(q, ColumnToSortByAscDesc, searchkeyword, "dateentry desc");
        }


        public static DataTable GetUnassignedGuards(String searchkeyword, String orderbyColumnASCDESC) {
            String q = @"SELECT guards.gid, concat(ln,', ',fn,' ',mn) as name,
                         concat(streetno, ', ', street, ', ', brgy, ', ', city) as Location
                         from msadb.guards
                         left join address on address.gid = guards.gid
                         where gstatus = 2 ";
            return SQLTools.ExecuteQuery(q, "concat(ln,', ',fn,' ',mn)", searchkeyword, orderbyColumnASCDESC);
        }



        /// <summary>
        /// Returns a list of the Clients.
        /// </summary>
        /// <returns>DT Columns: cid, name</returns>
        public static DataTable GetClients() {
            return Client.GetClients();
        }
        /// <summary>
        /// Returns a list of guards assigned to a client.
        /// </summary>
        /// <param name="cid">Client ID</param>
        /// <param name="keyword">Keyword for search</param>
        /// <returns></returns>
        public static DataTable GetGuardsAssigned(int cid, String keyword) {
            String q = "select guards.gid, concat(ln,', ',fn,' ',mn) as Name, concat(streetno,', ',streetname,', ',brgy,', ',city) as Location,concat(timein, timeout, days) as schedule from sduty_assignment inner join request_assign on request_assign.RAID=sduty_assignment.RAID left join guards on guards.gid = sduty_assignment.gid left join dutydetails on dutydetails.aid = sduty_assignment.aid" +
                " where cid={0}"; //comment
            return SQLTools.ExecuteQuery(q, "name", keyword, "name asc", new String[] { cid.ToString() });
        }
        /// <summary>
        /// Gets the details of a specific ASSIGNMENT Request
        /// </summary>
        /// <param name="rid">Request ID.</param>
        /// <returns></returns>
        public static DataTable GetAssignmentRequestDetails(int rid) {
            String q = @"SELECT name, concat(streetno,', ',streetname,', ',brgy,', ',city) as Location, 
                        contractstart, contractend, noguards, request.rstatus
                        FROM request left join request_assign on request_assign.rid = request.rid left join client on request.cid = client.cid "
                 + " where request.rid={0}"; ;
            return SQLTools.ExecuteQuery(q, null, null, null, new String[] { rid.ToString() });
        }
        #endregion

        #region Request Operations (Add + Dismiss)       ✔Done
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
            String q1 = String.Format("INSERT INTO `msadb`.`request` (`RequestType`, `CID`, `DateEntry`,`rstatus`) VALUES ('{0}', '{1}', '{2}','{3}');",
                        Enumeration.RequestType.Assignment, CID, madeon, Enumeration.RequestStatus.Pending);
            SQLTools.ExecuteNonQuery(q1);
            String rid = SQLTools.getLastInsertedId("request", "rid");
            String query = String.Format("INSERT INTO `msadb`.`request_assign` " +
                " ( `ContractStart`, `ContractEnd`, `RStatus`, `streetno`, `streetname`, `brgy`, `city`,`noguards`,`rid`)" +
                " VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}','{8}');",
                 ContractStart.ToString("yyyy-MM-dd"), ContractEnd.ToString("yyyy-MM-dd"),
                Enumeration.RequestStatus.Pending,
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
        public static void AddDismissalRequest(int cid, int[] did, int ReportType, String pcompleting, DateTime EventDate,
            String location, String description) {
            // Add a request, specifying client.
            String q = "INSERT INTO `msadb`.`request` (`RequestType`, `CID`, `DateEntry`) VALUES ('{0}', '{1}', '{2}')";
            q = String.Format(q, Enumeration.RequestType.Dismissal, cid, SQLTools.getDateTime());
            SQLTools.ExecuteNonQuery(q);
            String lid = SQLTools.getLastInsertedId("request", "rid");
            for (int c = 0; c < did.Length; c++) {
                q = "INSERT INTO `msadb`.`request_dismiss` (`RID`, `did`) VALUES ('" + lid.ToString() + "', '" + did[c] + "');";
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







        public static void UnassignGuards(int[] gid) {
          //  foreach ()
        }

        #endregion

        #region Add Assignment / Dismissal (Actual)   ✔Done
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
        /// 2.) 
        /// </summary>
        /// <param name="rid">Request ID to approve dismissal.</param>
        public static void ApproveDismissal(int rid) {
            DataTable GuardsToBeDismissed = SQLTools.ExecuteQuery(@"select did from request_dismiss
                                            where rid = " + rid + ";");
            foreach (DataRow e in GuardsToBeDismissed.Rows) {
                String q = "UPDATE `msadb`.`dutydetails` SET `DStatus`='2' WHERE `DID`='" + e["did"] +"';";
            }
        }

        /// <summary>
        /// Declines a request. Does no further processes.
        /// </summary>
        /// <param name="rid">Request ID to decline</param>
        public static void DeclineRequest(int rid) {
            UpdateRequestStatus(rid, Enumeration.RequestStatus.Declined);
        }
        #endregion

        #region Sidepanel Methods  ✔Done
        public static int GetNumberOfUnscheduledAssignments() {
            return 1;
        }

        public static int GetNumberOfAssignedGuards() {
            return int.Parse(SQLTools.ExecuteSingleResult("select count(*) from sduty_assignment where astatus=1;"));
        }
        public static int GetNumberOfUnassignedGuards() {
            int ass = int.Parse(SQLTools.ExecuteSingleResult("select count(*) from guards"));
            return (ass - GetNumberOfAssignedGuards());
        }
        public static String GetNumberOfClientRequests() {
            return GetNumberOfClientRequests(Enumeration.RequestStatus.Pending);
        }
        public static String GetNumberOfClientRequests(int RequestStatusEnumeration) {
            String q = "select count(*) from request where rstatus="+RequestStatusEnumeration;
            return SQLTools.ExecuteSingleResult(q);
        }
        public static String GetNumberOfPendingClientRequests() {
            return GetNumberOfClientRequests(Enumeration.RequestStatus.Pending);
        }
        #endregion

        #region Guard Retrieval Funcs  ✔Done

        public static DataTable ViewGuardsFromClient(int cid) {
            String q = @"select did, concat(ln,', ',fn,' ',mn) as Name, concat(streetno, ', ', streetname, ', ', brgy, ', ', city) as Location,concat(timein, '-', timeout,' ', days) as Schedule from guards left join sduty_assignment on guards.gid = sduty_assignment.gid 
                        left join dutydetails on sduty_assignment.aid = dutydetails.AID
                        left join request_assign on sduty_assignment.raid = request_assign.raid 
                        left join request on request_assign.rid=request.rid
                        where cid = 1;";
            DataTable dt = SQLTools.ExecuteQuery(q);
            foreach (DataRow e in dt.Rows) {
                String[] x = e["Schedule"].ToString().Split(' ');
                e.SetField("Schedule", (x[0] + ParseDays(x[1])));
            }
            return dt;
        }
        /*old
        public static DataTable ViewGuardsFromClient(int cid) {
            String q = @"select did, concat(ln,', ',fn,' ',mn) as Name, concat(streetno, ', ', streetname, ', ', brgy, ', ', city) as Location,concat(timein, '-', timeout,' ', days) as Schedule from guards left join sduty_assignment on guards.gid = sduty_assignment.gid 
                        left join dutydetails on sduty_assignment.aid = dutydetails.AID
                        left join request_assign on sduty_assignment.raid = request_assign.raid 
                        left join request on request_assign.rid=request.rid
                        where cid = 1;";
            DataTable dt = SQLTools.ExecuteQuery(q);
            foreach (DataRow e in dt.Rows) {
                String[] x = e["Schedule"].ToString().Split(' ');
                e.SetField("Schedule", (x[0] + ParseDays(x[1])));
            }
            return dt;
        }
        */

        #endregion

        #region View Assignments    ✔Done

        public static DataTable GetAssignmentsByClient(int cid, int filter) {
            String q = @"select 
                        guards.gid, dutydetails.did, sduty_assignment.aid,
                        concat(ln,', ',fn,' ',mn) as name,
                        concat(streetno, ', ', streetname, ', ', brgy, ', ', city) as Location,
                        case 
	                        when concat(timein,'-', timeout,' ', days) is null then 'Unscheduled'
                            when concat(timein,'-', timeout,' ', days) is not null then 'Scheduled'
                            end as schedule
                         from guards 
                        left join sduty_assignment on sduty_assignment.gid=guards.gid
                        left join dutydetails on sduty_assignment.aid=dutydetails.aid
                        left join request_assign on request_assign.raid=sduty_assignment.raid
                        left join request on request_assign.rid=request.rid where 'a' ='a'" +
                        (cid == -1 ? "" : " AND cid = " + cid + "");
                        
            if (filter == Enumeration.ScheduleStatus.Scheduled) {
                q += " AND days is not null";
            } else if (filter == Enumeration.ScheduleStatus.Unscheduled)
                q += " AND days is null";
            q += "  group by guards.gid";
            

            DataTable dt = SQLTools.ExecuteQuery(q);
           // foreach (DataRow e in dt.Rows) {
            //    String[] x = e["Schedule"].ToString().Split(' ');
            //    if (x[0] != "Unscheduled") e.SetField("Schedule", (x[0] + " " + ParseDays(x[1])));
           // }
            return dt;
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

        #region DutyDetail Operations   ✔Done
        public class Days {
            public string Value = null;
            public Days(bool Mon, bool Tue, bool Wed, bool Thu, bool Fri, bool Sat, bool Sun) {
                Value = "";
                bool[] d = { Mon, Tue, Wed, Thu, Fri, Sat, Sun };
                for (int c = 0; c < d.Length; c++) {
                    if (d[c]) Value += "1:";
                    else Value += "0:";
                }
                Value = Value.Substring(0, Value.Length - 1);
            }
        }
        public static void AddDutyDetail(int aid, String TI_hr, String TI_min, String TI_ampm, String TO_hr, String TO_min, String TO_ampm, Days days) {
            // 1.) Save TimeIN / TimeOut Details
            String ti, to;
            ti = String.Format("{0}:{1}:{2}", TI_hr, TI_min, TI_ampm);
            to = String.Format("{0}:{1}:{2}", TO_hr, TO_min, TO_ampm);
            String q = "INSERT INTO `msadb`.`dutydetails` (`AID`, `TimeOut`, `TimeIn`, `Days`,`DStatus`) VALUES ('{0}', '{1}', '{2}', '{3}','{4}');";
            q = String.Format(q, aid, to, ti, days.Value, Enumeration.AssignmentStatus.Active);
            SQLTools.ExecuteNonQuery(q);
        }
        #endregion

        #region Non-Query Methods
        // public static void AddDutyDetails()

        // DismissGuard;    (change sduty_assignment to dismissed.
        public static void DismissDuty (int did) {
           // String q = "UPDATE `msadb`.`dutydetails` SET `DStatus`='"+Enumeration.DutyDetailStatus.Inactive"' WHERE `DID`='"+did+"';";

        }
        // 















        #region MISC

        public static String cleansearch(String x) {
            if (x == empty) return "";
            else return x;
        }
        public static void UpdateRequestStatus (int rid, int val) {
            String q = @"UPDATE `msadb`.`request` SET `RStatus`='"+val+"' WHERE `RID`='"+rid+"';";
            SQLTools.ExecuteNonQuery(q);
        }
        public static String ParseDays (String q) {
            String[] u = { "M", "T", "W", "Th", "F", "S", "Su" };
            String k = "";
            String[] w = q.Split(':');
            for (int c=0; c<w.Length; c++) {
                k += u[c];
            }
            return k;
        }

        
        #endregion



        public static DataTable GuardsToBeDismissed(int rid) {
            throw new NotImplementedException();
        }

    }
}
#endregion


