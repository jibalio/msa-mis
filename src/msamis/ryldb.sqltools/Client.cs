using System;
using System.Data;

namespace MSAMISUserInterface {
    public class Client {
        static String empty = "Search or filter";

        public static DataTable GetClients() {
            DataTable dt = new DataTable();
            String query = "select cid, name from client;";
            return SQLTools.ExecuteQuery(query);
        }

        public static DataTable GetAllClientDetails(String searchKeyWords) {
            searchKeyWords = CleanSearch(searchKeyWords);
            var q = "SELECT cid, name, CONCAT(Clientstreetno,' ',Clientstreet,', ', Clientbrgy,', ',Clientcity) AS contactno, case cstatus when 1 then 'Active' when 2 then 'Inactive' end as status FROM client" + searchKeyWords;
            return SQLTools.ExecuteQuery(q);
        }

        public static String CleanSearch(String x) {
            if (x == empty) return "";
            else return x;
        }

        public static int GetNumberOfActiveClients() {
            return int.Parse(SQLTools.ExecuteSingleResult("SELECT count(*) FROM client WHERE cstatus = 1;"));
        }
        public static int GetNumberOfTotalClients() {
            return int.Parse(SQLTools.ExecuteSingleResult("SELECT count(*) FROM client;"));
        }

        public static DataTable GetClientDetails(int CID) {
            var q = "SELECT * FROM client WHERE CID = " + CID;
            return SQLTools.ExecuteQuery(q);
        }

        public static void AddClient(string name, string streetNo, string street, string brgy, string city, string contactPerson, string contactNo, string Manager) {
            String q = String.Format("INSERT INTO `msadb`.`Client` (`Name`, `ClientStreetNo`, `ClientStreet`,`ClientBrgy`,`ClientCity`,`ContactPerson`,`ContactNo`,`Manager`,`CStatus` ) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '2');", name, streetNo, street, brgy, city, contactPerson, contactNo, Manager);
            SQLTools.ExecuteNonQuery(q);
        }

        public static void UpdateClient(string Cid, string name, string streetNo, string street, string brgy,
            string city, string contactPerson, string contactNo, string Manager) {
            var q = String.Format("UPDATE `msadb`.`Client` SET `Name` = '{1}', `ClientStreetNo` = '{2}', `ClientStreet` = '{3}',`ClientBrgy`= '{4}', `ClientCity`= '{5}',`ContactPerson`= '{6}',`ContactNo`= '{7}',`Manager`= '{8}' WHERE CID = '{0}';", Cid, name, streetNo, street, brgy, city, contactPerson, contactNo, Manager);
            SQLTools.ExecuteNonQuery(q);
        }
    }
}
