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

        public static void AddClient(string name, string streetNo, string street, string brgy, string city, string contactPerson, string contactNo, string Manager) {
            String q =$@"INSERT INTO `msadb`.`Client` 
                        (`Name`, `ClientStreetNo`, `ClientStreet`,`ClientBrgy`,`ClientCity`,`ContactPerson`,`ContactNo`,`Manager`,`CStatus` ) 
                        VALUES ('{name}', '{streetNo}', '{street}', '{brgy}', '{city}', '{contactPerson}', '{contactNo}', '{Manager}', '{Enumeration.ClientStatus.Inactive}');";
            SQLTools.ExecuteNonQuery(q);
        }

        public static void UpdateClient(string Cid, string name, string streetNo, string street, string brgy,
            string city, string contactPerson, string contactNo, string Manager) {
            var q =  $@"UPDATE `msadb`.`Client` SET 
                                `Name` = '{name}', 
                                `ClientStreetNo` = '{streetNo}', 
                                `ClientStreet` = '{street}',
                                `ClientBrgy`= '{brgy}', 
                                `ClientCity`= '{city}',
                                `ContactPerson`= '{contactPerson}',
                                `ContactNo`= '{contactNo}',
                                `Manager`= '{Manager}'
                                WHERE CID = '{Cid}';";
            SQLTools.ExecuteNonQuery(q);
        }
    }
}
