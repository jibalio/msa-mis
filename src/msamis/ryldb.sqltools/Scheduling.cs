using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace MSAMISUserInterface {
    public class Scheduling {

        public static DataTable GetAssignmentHistory(int gid) {
            return SQLTools.ExecuteQuery($@"select aid, client.name, assignedon, unassignedon from sduty_assignment
            left join request_assign on request_assign.raid = sduty_assignment.raid
            left join request on request.rid = request_assign.rid
            left join client on client.cid = request.cid where gid={gid}");
        }

        static String empty = "Search or filter";
        #region Request Retrieval (DataTable)  -- General View    ✔Done

        

        /// <summary>
        /// Gets all requests made on a specific date.
        /// </summary>
        /// <param name="date">DateTime object.</param>
        /// <returns>DT columns: rid, name, dateentry, type</returns>
        ///
        public static DataTable GetRequests(String searchkeyword, int ClientFilter, int TypeFilter, String SearchColumn, String orderby, DateTime date) {
            String q = @"select rid, name, dateentry, 
                        case requesttype 
                        when 1 then 'Assignment'
                        when 2 then 'Unassignment' 
                        end as type,
                        case rstatus
                        when 1 then 'Pending'
                        when 2 then 'Approved'
                        when 3 then 'Active'
                        when 4 then 'Inactive'
                        when 5 then 'Declined'
                        end as status
                        from msadb.request 
                        left join client on request.cid=client.cid 
                        where dateentry='{0}' ";
            if (ClientFilter != -1) q += " and client.cid=" + ClientFilter;
            if (TypeFilter != 0) q += " and requesttype=" + TypeFilter;
            searchkeyword = cleansearch(searchkeyword);
            return SQLTools.ExecuteQuery(q,SearchColumn, searchkeyword, "dateentry desc", new String[] { date.ToString("yyyy-MM-dd")});
        }

        public static DataTable GetRequests(String searchkeyword, int ClientFilter, int TypeFilter, String ColumnToSortByAscDesc, String orderby) {
            String q = @"select rid, name, dateentry, 
                        case requesttype when 1 then 'Assignment' when 2 then 'Unassignment' end as type,
                        case rstatus
                        when 1 then 'Pending'
                        when 2 then 'Approved'
                        when 3 then 'Active'
                        when 4 then 'Inactive'
                        when 5 then 'Declined'
                        end as status from msadb.request inner join client on request.cid=client.cid ";
            q += " where 1=1 ";
            if (ClientFilter != -1) q += " and client.cid=" + ClientFilter;
            if (TypeFilter != 0) q += " and requesttype=" + TypeFilter;
            
            searchkeyword = cleansearch(searchkeyword);
            return SQLTools.ExecuteQuery(q, ColumnToSortByAscDesc, searchkeyword, "dateentry desc");
        }


        public static DataTable GetUnassignedGuards(String searchkeyword) {
            String q = @"SELECT guards.gid, concat(ln,', ',fn,' ',mn) as name,
                         concat(streetno, ', ', street, ', ', brgy, ', ', city) as Location
                         from msadb.guards
                         left join address on address.gid = guards.gid
                         where gstatus = 2 and atype=2";
            return SQLTools.ExecuteQuery(q, "concat(ln,', ',fn,' ',mn)", searchkeyword, orderbyColumnASCDESC);
        }



       
        /// <summary>
        /// Returns a list of guards assigned to a client.
        /// </summary>
        /// <param name="cid">Client ID</param>
        /// <param name="keyword">Keyword for search</param>
        /// <returns></returns>
        public static DataTable GetGuardsAssigned(int cid, String keyword) {
            String q = @"select guards.gid, concat(ln,', ',fn,' ',mn) as Name, concat(streetno,', ',streetname,', ',brgy,', ',city) as Location,concat (ti_hh,':',ti_mm,' ',ti_period, '-',
                   to_hh,':',to_mm,' ',to_period, ' ') as schedule, 'null' as days
                from sduty_assignment inner join request_assign on request_assign.RAID=sduty_assignment.RAID left join guards on guards.gid = sduty_assignment.gid left join dutydetails on dutydetails.aid = sduty_assignment.aid" +
                " where cid={0}"; //comment
            DataTable dt = SQLTools.ExecuteQuery(q, "name", keyword, "name asc", new String[] { cid.ToString() });
            foreach (DataRow e in dt.Rows) {
                e.SetField("days", GetDays(int.Parse(e["did"].ToString())).ToString());
            }
            return dt;
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
                " ( `ContractStart`, `ContractEnd`, `streetno`, `streetname`, `brgy`, `city`,`noguards`,`rid`)" +
                " VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');",
                 ContractStart.ToString("yyyy-MM-dd"), ContractEnd.ToString("yyyy-MM-dd"),
                AssStreetNo, AssStreetName, AssBrgy, AssCity, NoGuards, rid);
            Console.WriteLine("AddAssignmentRequest: \n" + query);
            SQLTools.ExecuteNonQuery(query);
        }

        /// <summary>
        /// Adds an unassignment request for the specified guards.
        /// </summary>
        /// <param name="cid">Client ID</param>
        /// <param name="gid">An array of Guard ID's to be dismissed</param>
        /// <param name="ReportType">Enumeration.ReportType (Incident)</param>
        /// <param name="pcompleting">Idk unsa ni na field.</param>
        /// <param name="EventDate">Date of event.</param>
        /// <param name="location">Brief location description</param>
        /// <param name="description">Brief description of incident.</param>
        public static void AddUnassignmentRequest(int cid, int[] gid, int ReportType, String pcompleting, DateTime EventDate,
            String location, String description, DateTime DateEffective) {

            // 1.) Add Incident Report
            String q = String.Format(@"INSERT INTO `msadb`.`incidentreport` 
                         (`ReportType`, `DateEntry`, `PCompleting`, `EventDate`, `EventLocation`, `Description`) 
                         VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');",
                          ReportType, SQLTools.getDateTime(), pcompleting, EventDate.ToString("yyyy-MM-dd"), location, description
                        );
            SQLTools.ExecuteNonQuery(q);
            // 2.) Insert a dismissal request.\
            // 2a: Get last inserted Incident Report (link this)
            int ernational_love = int.Parse(SQLTools.getLastInsertedId("IncidentReport", "iid"));
            // 2b: Insert request
            q = "INSERT INTO `msadb`.`request` (`RequestType`, `CID`, `DateEntry`,`rstatus`, `dateeffective`) VALUES ('{0}', '{1}', '{2}','{3}', '{4}')";
            q = String.Format(q, Enumeration.RequestType.Dismissal, cid, SQLTools.getDateTime(),Enumeration.RequestStatus.Pending, ernational_love, DateEffective.ToString("yyyy-MM-dd"));
            SQLTools.ExecuteNonQuery(q);
            String lid = SQLTools.getLastInsertedId("request", "rid");
            for (int c = 0; c < gid.Length; c++) {  
                q = $@"INSERT INTO `msadb`.`request_unassign` (`RID`, `gid`, `iid`, `DateEffective') VALUES ('{lid.ToString()}', '{ gid[c]}', '{ernational_love}', '{DateEffective:yyyy-MM-dd}');";
                SQLTools.ExecuteNonQuery(q);
            }
            
        }


        public static DataTable GetIncidentReport(int rid) {
            var q = @"select case  incidentreport.ReportType when 1 then 'Injury' when 2 then 'Accident' when 3 then 'Complaint' end as Type, 
                        incidentreport.EventDate as EventDate, incidentreport.EventLocation as Location, 
                        incidentreport.Description as Description, 
                        concat (ln, ', ',  fn, ' ', mn) as name, 
                        case InvolvementType when 1 then 'Involved' when 2 then 'Witness' end as InvType from request_unassign
                        left join request on request_unassign.RID = request.RID
                        left join incidentreport on request_unassign.IID = incidentreport.IID 
                        left join personsinvolved on incidentreport.IID = personsinvolved.IID where request.RID = " + rid + " group by name";
            return SQLTools.ExecuteQuery(q);
        }

        public static void AddIncidentReportInvolvement(int Iid, int type, string First, string Middle, string Last) {
            SQLTools.ExecuteNonQuery("INSERT INTO PersonsInvolved (InvolvementType, IID, FN, MN, LN) VALUES ('" + type + "','" + Iid + "','" + First + "','" + Middle + "','" + Last + "')");
        }


        public static void ApproveUnassignment(int RequestId) {
            DataTable de = SQLTools.ExecuteQuery($@"select * from request
                                                        left join request_unassign on request_unassign.RID = request.RID
                                                        where request.rid={RequestId};");
            DateTime DateEffective = DateTime.Parse(de.Rows[0]["dateeffective"].ToString());
            // 1.) Get all GIDs of guards in RID
            DataTable GuardsToBeDismissed = SQLTools.ExecuteQuery(@"select guards.gid as gid, sduty_assignment.aid as aid from guards 
                                            left join sduty_assignment on sduty_assignment.GID = guards.gid
                                            left join request_unassign on request_unassign.gid = guards.gid
                                            where rid = " + RequestId + ";");
            foreach (DataRow e in GuardsToBeDismissed.Rows) {
                // 1A) Set scheds to inactive
                String q = @"UPDATE `msadb`.`dutydetails` SET `DStatus`='" + Enumeration.DutyDetailStatus.Inactive + "' WHERE `AID`='" + e["aid"] + "';";
                SQLTools.ExecuteNonQuery(q);
                // 2.) Set assignment to dismissed (IF they have schedules active)
                q = $@"UPDATE `msadb`.`sduty_assignment` SET `AStatus`='{
                        Enumeration.AssignmentStatus.Inactive
                    }', UnassignedOn='{DateEffective:yyyy-MM-dd}' WHERE `gid`='{e["gid"]}';";
                SQLTools.ExecuteNonQuery(q);
                // 3.) Set guard to Inactive (BUT NOT DISMISSED)
                q = @"UPDATE `msadb`.`guards` SET `GStatus`='" + Enumeration.GuardStatus.Inactive + "' WHERE `GID`='" + e[0] + "'";
                SQLTools.ExecuteNonQuery(q);
            }
            // Step 4
            UpdateRequestStatus(RequestId, Enumeration.RequestStatus.Approved);
        }


        

        #endregion

        #region Add Assignment / Dismissal (Actual)   ✔Done
        public static void AddAssignment(int rid, int[] gid) {
            DataRow df = SQLTools.ExecuteQuery($@"select * from request where rid='{rid}'").Rows[0];
            // First check if rid is type assignment.
            if (df["requesttype"].ToString() == Enumeration.RequestType.Assignment.ToString()) {
                // FUNCTION BODY
                DataRow dtl = SQLTools.ExecuteQuery($@"
                    select * from request 
				    left join request_assign on request_assign.RID = request.RID
				    left join sduty_assignment on sduty_assignment.RAID=request_assign.RAID where request_assign.rid={rid};
                ").Rows[0];
                
                // Get RID of guard.
                String raid = dtl["RAID"].ToString();
                foreach (int g in gid) {
                    DateTime consta = DateTime.Parse(dtl["contractstart"].ToString());
                    DateTime conend = DateTime.Parse(dtl["contractend"].ToString());
                    // Add assignment in assignment table
                    String q =$@"INSERT INTO `msadb`.`sduty_assignment` (`GID`, `RAID`, `AStatus`, `AssignedOn`, `cid`) VALUES ('{g}', '{raid}', '{Enumeration.Schedule.Pending}', 
                                '{consta.ToString("yyyy-MM-dd")}', '{df["cid"].ToString()}');";
                    SQLTools.ExecuteNonQuery(q);
                   // SQLTools.ExecuteNonQuery(eventddl_cs);      // contract start trigger
                   // SQLTools.ExecuteNonQuery(eventddl_ce);      // contract end trigger
                }
                UpdateRequestStatus(rid, Enumeration.RequestStatus.Active);
                Data.InitGuardStatusAndDutyAssignments();
            } else MessageBox.Show("Request is not an assignment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            SQLTools.ExecuteQuery("call init_status_clientstatus()");
            SQLTools.ExecuteNonQuery("call msadb.init_checkdate_assignmentstatus();");
        }


        /// <summary>
        /// Steps:
        /// 1.) Get Guards to be dismissed (based on RID)
        /// 2.) 
        /// </summary>
        /// <param name="rid">Request ID to approve dismissal.</param>
       

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
            String q = @"select did, concat(ln,', ',fn,' ',mn) as Name, concat(streetno, ', ', streetname, ', ', brgy, ', ', city) as Location,concat (ti_hh,':',ti_mm,' ',ti_period, '-',
		to_hh,':',to_mm,' ',to_period, ' ') as Schedule,
        'null' as days
from guards left join sduty_assignment on guards.gid = sduty_assignment.gid 
                        left join dutydetails on sduty_assignment.aid = dutydetails.AID
                        left join request_assign on sduty_assignment.raid = request_assign.raid 
                        left join request on request_assign.rid=request.rid
                        where cid = 1;";
            DataTable dt = SQLTools.ExecuteQuery(q);
            foreach (DataRow e in dt.Rows) {
                e.SetField("days", GetDays(int.Parse(e["did"].ToString())).ToString());
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

        public static DataTable GetAssignmentsByClient(int cid, int filter, string searchkeyword) {
            String q = @"select 
                        guards.gid, d.did, sduty_assignment.aid,
                        concat(ln,', ',fn,' ',mn) as name,
                        concat(streetno, ', ', streetname, ', ', brgy, ', ', city) as Location,
                        case 
	                        when ti_hh is null then 'Unscheduled'
                            when ti_hh is not null then 'Scheduled'
                            end as schedule,
						case astatus
                        when 1 then 'Active' when 2 then 'Inactive' when 3 then 'Approved' end as Status
                         from guards 
                        left join sduty_assignment on sduty_assignment.gid=guards.gid
                        left join (select * from dutydetails where dstatus=1) as d on sduty_assignment.aid=d.aid
                        left join request_assign on request_assign.raid=sduty_assignment.raid
                        left join request on request_assign.rid=request.rid
                        where  city is not null AND astatus<>2 " +
                        (cid == -1 ? "" : " AND sduty_assignment.cid = " + cid + "");
            if (filter == Enumeration.ScheduleStatus.Scheduled) {
                q += " AND ti_hh is not null";
            } else if (filter == Enumeration.ScheduleStatus.Unscheduled)
                q += " AND ti_hh is null ";
            DataTable dt = SQLTools.ExecuteQuery(q + searchkeyword + " order by name asc");
            // foreach (DataRow e in dt.Rows) {
            //    String[] x = e["Schedule"].ToString().Split(' ');
            //    if (x[0] != "Unscheduled") e.SetField("Schedule", (x[0] + " " + ParseDays(x[1])));
            // }
            return dt;
        }

        public static DataTable GetGuardsWithAssignment(string searchkeyword) {
            String q = @"select 
                        guards.gid, d.did, sduty_assignment.aid,
                        concat(ln,', ',fn,' ',mn) as name,
                        concat(streetno, ', ', streetname, ', ', brgy, ', ', city) as Location,
                        case 
	                        when ti_hh is null then 'Unscheduled'
                            when ti_hh is not null then 'Scheduled'
                            end as schedule,
						case astatus
                        when 1 then 'Active' when 2 then 'Inactive' when 3 then 'Approved' end as Status,
                        case gender when 1 then 'Male' when 2 then 'Female' end as 'GENDER', 
                        cellno as 'CONTACTNO',
                        case gstatus when 1 then 'Active' when 2 then 'Inactive' end as 'STATUS'
                         from guards 
                        left join sduty_assignment on sduty_assignment.gid=guards.gid
                        left join (select * from dutydetails where dstatus=1) as d on sduty_assignment.aid=d.aid
                        left join request_assign on request_assign.raid=sduty_assignment.raid
                        left join request on request_assign.rid=request.rid
                        where  city is not null ";
            DataTable dt = SQLTools.ExecuteQuery(q + searchkeyword + " group by guards.gid order by name asc");
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

        #region DutyDetail Operations  (Add + Dismiss)  ✔Done
       
        public static void AddDutyDetail(int aid, String TI_hr, String TI_min, String TI_ampm, String TO_hr, String TO_min, String TO_ampm, Days days) {
            String q = @"
                        INSERT INTO `msadb`.`dutydetails` 
                        (`AID`, 
                        `TI_hh`, `TI_mm`, `TI_period`, 
                        `TO_hh`, `TO_mm`, `TO_period`,
                        `Mon`, `Tue`, `Wed`, `Thu`, `Fri`, `Sat`, `Sun`, 
                        `DStatus`) 
                        VALUES 
                        ('{0}',
                        '{1}','{2}','{3}',
                        '{4}','{5}','{6}',
                        '{7}','{8}','{9}','{10}','{11}','{12}','{13}',
                        '{14}');
                        ";
            q = String.Format(q, aid,
                        TI_hr, TI_min, TI_ampm,
                        TO_hr, TO_min, TO_ampm,
                        Convert.ToInt32(days.Mon), Convert.ToInt32(days.Tue), 
                        Convert.ToInt32(days.Wed), Convert.ToInt32(days.Thu), 
                        Convert.ToInt32(days.Fri), Convert.ToInt32(days.Sat), 
                        Convert.ToInt32(days.Sun),
                        Enumeration.DutyDetailStatus.Active
                );
            SQLTools.ExecuteNonQuery(q);
        }

        public static void DismissDuty (int did) {
            // Set duty detail to inactive.
            // Previous duty na ni niya.
            String q = "UPDATE `msadb`.`dutydetails` SET `DStatus`="+Enumeration.DutyDetailStatus.Inactive+" WHERE `DID`={0}";
            q = String.Format(q, did);
            SQLTools.ExecuteNonQuery(q);
        }
        #endregion

        /// <summary>
        /// Returns DataTable: Location, ContractStart, ContractEnd
        /// of guard with corresponding AID number.
        /// </summary>
        /// <param name="aid"></param>
        /// <returns></returns>
        public static DataTable GetAssignmentDetails (int aid) {
            // Location, ContractStart, ContractEnd
            String q = @"SELECT concat(streetno, ', ', streetname, ', ', brgy, ', ', city) as Location, ContractStart, ContractEnd FROM msadb.sduty_assignment
                        left join request_assign on request_assign.raid=sduty_assignment.raid
                        left join request on request.rid=request_assign.rid
                        where sduty_assignment.aid="+aid+";";
                        return SQLTools.ExecuteQuery(q);
        }

        #region View Request Methods

        /// <summary>
        /// Returns Columns ["name", "status"]
        /// </summary>
        /// <param name="RID"></param>
        /// <returns></returns>
        public static DataTable GetUnassignmentRequestDetails (int RID) {
            String q = @"select name,
                         case rstatus
                                                when 1 then 'Pending'
                                                when 2 then 'Approved'
                                                when 3 then 'Active'
                                                when 4 then 'Declined'
                                                end as status from request_unassign
                        left join request on request_unassign.RID = request.RID
                        left join client on request.CID=client.CID where request.RID = " + RID;
            return SQLTools.ExecuteQuery(q);
        }

        public static DataTable GetGuardsToBeUnassigned(int RID) {
            String q = @"select guards.gid, concat(ln,', ',fn,' ',mn) as name from request_unassign 
                        left join guards on guards.gid = request_unassign.gid
                        left join request on request.RID = request_unassign.RID
                        where request.RID = " +RID;
            return SQLTools.ExecuteQuery(q);
        }



        #endregion

        #region Assignment Requests
        public static DataTable GetAllAssignmentDetails(int AID) {
            SQLTools.ExecuteNonQuery("call msadb.init_checkdate_assignmentstatus();");
            /*
             * On Status:  What status? Assignment status?
             * NTS: Is status supposed to be active when guard has duty? Or when guard has assignment?
             */
            //return Gid, Name sa Guard, CID, name sa client, status
            String q = @"/* return Gid, Name sa Guard, CID, name sa client, status */
                            select 
                            guards.gid as gid,
                            client.cid as cid,
                            concat(ln,', ',fn,' ',mn) as guardname,
                            client.name as clientname,
                            case astatus when 1 then 'Active' when 2 then 'Inactive' end as assignmentstatus
                             from sduty_assignment
                            left join request_assign on sduty_assignment.RAID=request_assign.RAID
                            left join request on request.RID = request_assign.RID
                            left join client on request.cid = client.cid
                            left join guards on guards.gid = sduty_assignment.GID
                            where sduty_assignment.AID = " + AID;
            return SQLTools.ExecuteQuery(q);
        }


        #endregion

        /// <summary>
        /// Returns a DataTable listing the Summary of Duty Details of a specific assignment.
        /// </summary>
        /// <param name="AID">Assignment ID</param>
        /// <returns>Columns: ["did", "TimeIn", "TimeOut", "Days"]</returns>
        public static DataTable GetDutyDetailsSummary (int AID) {
            DataTable dt = 
                SQLTools.ExecuteQuery(@"
                    select did, concat (ti_hh,':',ti_mm,' ',ti_period) as TimeIn,
                    concat (to_hh,':',to_mm,' ',to_period) as TimeOut,
                    'days_columnMTWThFSSu' as days from 
                    dutydetails where DStatus=1 and AID=" + AID);
            foreach (DataRow e in dt.Rows) {
                e.SetField("days", GetDays(int.Parse(e["did"].ToString())).ToString());
            }
            return dt;
        }

        /// <summary>
        /// Returns Individual Time elements of DutyDetail.
        /// </summary>
        /// <param name="DID">Duty Detail ID</param>
        /// <returns>Columns: ["ti_hh" , "ti_mm" , "ti_period" , "to_hh" , "to_mm" , "to_period"]</returns>
        public static DataTable GetDutyDetailsDetails(int DID) {
            String q = @"select ti_hh, ti_mm, ti_period,
		                to_hh, to_mm, to_period
                        from dutydetails  where DStatus=1 and did=" + DID;
            return SQLTools.ExecuteQuery(q);
        }
        /// <summary>
        /// Gets the Duty Days of specific duty detail
        /// </summary>
        /// <param name="DID">Duty detail ID</param>
        /// <returns>Returns Scheduling.Days object</returns>
        public static Days GetDays(int DID) {
            String q = "select mon, tue, wed, thu, fri, sat, sun from dutydetails where DID=" + DID;
            DataTable dt = SQLTools.ExecuteQuery(q);
            return new Days(
                dt.Rows[0]["mon"].ToString() == "1",
                dt.Rows[0]["tue"].ToString() == "1",
                dt.Rows[0]["wed"].ToString() == "1",
                dt.Rows[0]["thu"].ToString() == "1",
                dt.Rows[0]["fri"].ToString() == "1",
                dt.Rows[0]["sat"].ToString() == "1",
                dt.Rows[0]["sun"].ToString() == "1"
                );
        }

        public static void UpdateDutyDetail(int did, String TI_hr, String TI_min, String TI_ampm, String TO_hr, String TO_min, String TO_ampm, Days days) {
            String q = @"
                        UPDATE `msadb`.`dutydetails` SET 
                        `TI_hh`='{0}', `TI_mm`='{1}', `TI_period`='{2}', 
                        `TO_hh`='{3}', `TO_mm`='{4}', `TO_period`='{5}',
                        `Mon`='{6}', `Tue`='{7}', 
                        `Wed`='{8}', `Thu`='{9}', 
                        `Fri`='{10}', `Sat`='{11}', 
                        `Sun`='{12}'
                        WHERE `DID`='{13}';
                         ";
            q = String.Format(q,
                 TI_hr, TI_min, TI_ampm,
                        TO_hr, TO_min, TO_ampm,
                        Convert.ToInt32(days.Mon), Convert.ToInt32(days.Tue),
                        Convert.ToInt32(days.Wed), Convert.ToInt32(days.Thu),
                        Convert.ToInt32(days.Fri), Convert.ToInt32(days.Sat),
                        Convert.ToInt32(days.Sun), did);
            SQLTools.ExecuteNonQuery(q);
        }



















        #region MISC

        public class Days {
            public string deendracht = null;
            public bool[] Value = new bool[7];
            public bool Mon, Tue, Wed, Thu, Fri, Sat, Sun;
            public Days(bool Mon, bool Tue, bool Wed, bool Thu, bool Fri, bool Sat, bool Sun) {
                deendracht = "";
                bool[] d = { Mon, Tue, Wed, Thu, Fri, Sat, Sun };
                string[] f = { "M", "T", "W", "Th", "F", "S", "Su" };
                for (int c = 0; c < d.Length; c++) {
                    if (d[c]) {
                        deendracht += f[c];
                        Value[c] = true;
                    } else {
                        Value[c] = false;
                    }
                }
                this.Mon = Value[0]; this.Tue = Value[1]; this.Wed = Value[2]; this.Thu = Value[3]; this.Fri = Value[4]; this.Sat = Value[5]; this.Sun = Value[6];
            }
            public override string ToString() {
                return deendracht;
            }
        }


        public static String cleansearch(String x) {
            if (x == empty) return "";
            else return x;
        }
        public static void UpdateRequestStatus (int rid, int val) {
            String q = @"UPDATE `msadb`.`request` SET `RStatus`='"+val+"' WHERE `RID`='"+rid+"';";
            SQLTools.ExecuteNonQuery(q);
        }

        /// <summary>
        /// (Backend) Gets a Scheduling.Days object and returns a string format: MTWThFSSu
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        public static String ParseDays (String q) {
            String[] u = { "M", "T", "W", "Th", "F", "S", "Su" };
            String k = "";
            String[] w = q.Split(':');
            for (int c=0; c<w.Length; c++) {
                if (w[c] == "1" ) k += u[c];
            }
            return k;
        }
        public static DataTable GuardsToBeDismissed(int rid) {
            throw new NotImplementedException();
        }
        #endregion

       
    }
}



