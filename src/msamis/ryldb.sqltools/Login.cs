using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using Crypt = BCrypt.Net.BCrypt;

namespace MSAMISUserInterface {
    public class Login {
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
                    SQLTools.conn.Close();

                    SQLTools.ExecuteNonQuery($@"
                    INSERT INTO `msadb`.`loginhistory` 
                    (`uid`, `logintime`) 
                    VALUES ('{uid}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}');
                    ");
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
