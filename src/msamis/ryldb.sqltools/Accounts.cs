using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSAMISUserInterface {
    public class Account {
        private int accid;
        private string uname;
        private string hash;

        public string Username {
            get { return uname; }
            set {
                uname = value;
                SQLTools.ExecuteNonQuery($@"UPDATE `msadb`.`account` SET `uname`='{value}' WHERE `accid`='{accid}';");
            }
        }

        public bool ChangePassword(string NewPassword, string OldPassword) {
            /*try {
                String q = @"select * from account where uname='" + uname + "'";
                DataTable dt = SQLTools.ExecuteQuery_(q);
                Console.WriteLine(Crypt.HashPassword("clerk"));
                string db_hash = dt.Rows[0]["hash"].ToString();
                if (BCrypt.Verify(pword, db_hash)) {
                    UserName = dt.Rows[0]["uname"].ToString();
                    AccountType = int.Parse(dt.Rows[0]["type"].ToString());
                    uid = int.Parse(dt.Rows[0]["accid"].ToString());
                    SQLTools.conn.Close();
                    return true;
                } else return false;
            } catch (Exception) {
                SQLTools.conn.Close();
                return false;
            }*/
            return false;
        }

        public Account (int accid) {
            DataRow dt = SQLTools.ExecuteQuery($"SELECT * FROM msadb.account where accid={accid}").Rows[0];
            this.accid = accid;
            this.uname = dt["uname"].ToString();
            this.hash = dt["hash"].ToString();
        }

        public static Account GetAccountDetails(int accid) {
            return new Account(accid);
        }





        public static DataTable GetAccounts() {
            return SQLTools.ExecuteQuery(@"SELECT accid, uname, case type
            when 1 then 'Manager' when 2 then 'Clerk' when 0 then 'Superuser' end as type FROM msadb.account;");
        }
        


    }
}
