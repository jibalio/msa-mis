using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSAMISUserInterface {
    public class Client {

        public static DataTable GetClients() {
            DataTable dt = new DataTable();
            String query = "select cid, name from client;";
            return SQLTools.ExecuteQuery(query);
        }
    }
}
