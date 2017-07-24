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
                String q = @"select hash from account where uname='" + uname + "'";
                DataTable dt = SQLTools.ExecuteQuery_(q);
                string db_hash = dt.Rows[0]["pword"].ToString();
                if (this_hash.Equals(db_hash)) { return true; }
                else return false;
            } 
            catch (Exception) { return false; }
        }
    }
}
