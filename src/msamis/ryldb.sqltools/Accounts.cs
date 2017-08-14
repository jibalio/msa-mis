using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crypt = BCrypt.Net.BCrypt;

namespace MSAMISUserInterface {
    public class Account {

        public static void CreateUser(string Uname, string Pword, int AccountType) {
            SQLTools.ExecuteNonQuery($@"INSERT INTO `msadb`.`account` 
                                        (`uname`, `hash`, `type`) 
                                        VALUES ('{Uname}', '{Crypt.HashPassword(Pword)}', '{AccountType}');");
        }

        public static void ChangeUsername(int accid, string NewUname) {
            var q = $@"
                            UPDATE `msadb`.`account` SET 
                            `uname`='{NewUname}' 
                            WHERE `accid`='{accid}';
                    ";
            SQLTools.ExecuteNonQuery(q);
        }

        public static bool ChangePassword(int accid, string NewPassword, string OldPassword) {
            String x = @"select hash from account where accid='" + accid + "'";
            DataTable dt = SQLTools.ExecuteQuery(x);
            if (Crypt.Verify(OldPassword, dt.Rows[0]["hash"].ToString())) {
                    var q = $@"
                            UPDATE `msadb`.`account` SET 
                            `hash`='{Crypt.HashPassword(NewPassword)}' 
                            WHERE `accid`='3';
                    ";
                    SQLTools.ExecuteNonQuery(q);
                    return true;
                } else return false;
        }



        public static DataTable GetAccounts() {
            return SQLTools.ExecuteQuery(@"SELECT accid, uname, case type
            when 1 then 'Manager' when 2 then 'Clerk' when 0 then 'Superuser' end as type FROM msadb.account;");
        }
        


    }
}
