using System;
using System.Data;

namespace MSAMISUserInterface {
    public class Client {

        static String empty = "Search or filter";

        public static DataTable GetClients() {
            SQLTools.ExecuteQuery("call init_status_clientstatus()");
            DataTable dt = new DataTable();
            String query = "select cid, name from client;";
            return SQLTools.ExecuteQuery(query);
        }

        #region Certifier Region
        public static void AddCertifier(int cid, string fn, string mn, string ln, string contactno) {
            var q =
                $@"INSERT INTO `msadb`.`certifier` (`cid`, `fn`, `ln`, `mn`,`contactno`) VALUES ('{cid}', '{fn}', '{ln}', '{mn}', '{contactno}');";
            SQLTools.ExecuteNonQuery(q);
        }

        public static DataTable GetCertifiers(int cid) {
            var q = $@"SELECT ccid, cid, fn, mn, ln, contactno FROM msadb.certifier WHERE cid = {cid} and status=1;";
            return SQLTools.ExecuteQuery(q);
        }

        public static DataTable GetCertifiersView(int cid) {
            var q = $@"SELECT ccid, cid, concat(ln,', ',fn,' ',mn), contactno FROM msadb.certifier WHERE cid = {cid} and status=1;";
            return SQLTools.ExecuteQuery(q);
        }

        public static void UpdateCertifier(int ccid, string fn, string mn,string ln, string contactno) {
            var q =
                $@"UPDATE `msadb`.`certifier` SET `fn`='{fn}', `mn`='{mn}', `ln`='{ln}', `contactno`='{contactno}' WHERE `ccid`='{ccid}';";
            SQLTools.ExecuteNonQuery(q);
        }

        public static void RemoveCertifier(int ccid) {
            var q = $@"UPDATE `msadb`.`certifier` SET `status`='0' WHERE `ccid`='{ccid}';";
            SQLTools.ExecuteNonQuery(q);
        }
        #endregion

        public static DataTable GetAllClientDetails(String searchKeyWords) {
            searchKeyWords = CleanSearch(searchKeyWords);
            var q = $@"SELECT cid, name, CONCAT(Clientstreetno,' ',Clientstreet,', ', Clientbrgy,', ',Clientcity) AS contactno, 
                    case cstatus when {Enumeration.ClientStatus.Active} then 'Active' when {Enumeration.ClientStatus.Inactive} then 'Inactive' 
                    end as status FROM client" + searchKeyWords;
            return SQLTools.ExecuteQuery(q);
        }

        public static String CleanSearch(String x) {
            if (x == empty) return "";
            else return x;
        }

        public static int GetNumberOfActiveClients() {
            return int.Parse(SQLTools.ExecuteSingleResult($@"SELECT count(*) FROM client WHERE cstatus = {Enumeration.ClientStatus.Active};"));
        }
        public static int GetNumberOfTotalClients() {
            return int.Parse(SQLTools.ExecuteSingleResult("SELECT count(*) FROM client;"));
        }

        public static DataTable GetClientDetails(int CID) {
            var q = $"SELECT * FROM client WHERE CID = {CID};";
            return SQLTools.ExecuteQuery(q);
        }

        public static void AddClient(string name, string streetNo, string street, string brgy, string city, string contactPerson, string contactNo, string Manager, double OfficerRate) {
            String q =$@"INSERT INTO `msadb`.`Client` 
                        (`Name`, `ClientStreetNo`, `ClientStreet`,`ClientBrgy`,`ClientCity`,`ContactPerson`,`ContactNo`,`Manager`,`CStatus` ,`ofcrate` ) 
                        VALUES ('{name}', '{streetNo}', '{street}', '{brgy}', '{city}', '{contactPerson}', '{contactNo}', '{Manager}', '{Enumeration.ClientStatus.Inactive}', '{OfficerRate}');";
            SQLTools.ExecuteNonQuery(q);
        }

        public static void UpdateClient(string Cid, string name, string streetNo, string street, string brgy,
            string city, string contactPerson, string contactNo, string Manager, double OfficerRate) {
            var q =  $@"UPDATE `msadb`.`Client` SET 
                                `Name` = '{name}', 
                                `ClientStreetNo` = '{streetNo}', 
                                `ClientStreet` = '{street}',
                                `ClientBrgy`= '{brgy}', 
                                `ClientCity`= '{city}',
                                `ContactPerson`= '{contactPerson}',
                                `ContactNo`= '{contactNo}',
                                `Manager`= '{Manager}',
                                `OfcRate`={OfficerRate}
                                WHERE CID = '{Cid}';";
            SQLTools.ExecuteNonQuery(q);
        }
    }
}
