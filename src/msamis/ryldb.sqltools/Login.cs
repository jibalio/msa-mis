using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSAMISUserInterface {
    public class Login {
        public static bool Authenticate(string uname, string pword) {
            try {
                string this_hash = pword;
                String q = @"select * from account where uname='" + uname + "'";
                DataTable dt = SQLTools.ExecuteQuery_(q);
                string db_hash = dt.Rows[0]["hash"].ToString();
                if (this_hash.Equals(db_hash)) {
                    UserName = dt.Rows[0]["uname"].ToString();
                    AccountType = int.Parse(dt.Rows[0]["type"].ToString());
                    SQLTools.conn.Close();
                    return true;
                }

                else return false;
            } 
            catch (Exception) {
                SQLTools.conn.Close();
                return false;
            }
        }

        public static int AccountType;
        public static string UserName;
    }
}
