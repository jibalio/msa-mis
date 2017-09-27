using System;
using System.Data;
using Crypt = BCrypt.Net.BCrypt;

namespace MSAMISUserInterface {
    public class Login {

        public static int LoggedInUser;
        public static int SessionId;

        public static void EndSession() {
                
        }

        
        public static bool Authenticate(string uname, string pword) {
            int uid;
            try {
                String q = @"select * from account where uname='" + uname + "'";
                DataTable dt = SQLTools.ExecuteQuery_(q);
                //Console.WriteLine(Crypt.HashPassword("clerk"));
                string db_hash = dt.Rows[0]["hash"].ToString();
                if (Crypt.Verify(pword, db_hash)) {
                    UserName = dt.Rows[0]["uname"].ToString();
                    AccountType = int.Parse(dt.Rows[0]["type"].ToString());
                    uid = int.Parse(dt.Rows[0]["accid"].ToString());
                    LoggedInUser = uid;
                    SQLTools.conn.Close();
                    SQLTools.ExecuteNonQuery($@"
                    INSERT INTO `msadb`.`loginhistory` 
                    (`uid`, `session_start`) 
                    VALUES ('{uid}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}');
                    ");
                    SessionId = SQLTools.GetInt("select last_insert_id()");
                    SQLTools.ExecuteNonQuery($@"SET @cuser={SessionId};");
                    SQLTools.ExecuteNonQuery($@"call init_checkdate_all");
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
