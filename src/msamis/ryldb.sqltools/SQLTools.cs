using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

/* Leryc*/
namespace MSAMISUserInterface {
    public class SQLTools {
        
        /* VersionChangeCheck : void
         * Checks if Leryc had edited MySQL database. Returns error 
         * if DB is not updated. Redirects to dropbox link to SQL file.
         */
        public static string sqlversion = "1";
        public static void VersionCheck() {
            MySqlCommand com = new MySqlCommand("select version from meta where meta_id=1", conn);
            conn.Open();
            try {
                MySqlDataAdapter adp = new MySqlDataAdapter(com);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows[0]["version"].ToString()!=sqlversion) {
                    throw new Exception();
                } else { conn.Close(); return; }
            } catch (MySql.Data.MySqlClient.MySqlException) {
                conn.Close();
                throw new Exception();
            }
            
            
        }
        
        public static String ArchiveName = "msadbarchive";
        public static MySqlConnection conn = new MySqlConnection("Server=localhost;Database=MSAdb;Uid=root;Pwd=root;");
        public static MySqlConnection archiveconn = new MySqlConnection("Server=localhost;Database=" + ArchiveName + ";Uid=root;Pwd=root;");



        #region Guard Management

        public static int GetNumberOfGuards(String a) {
            int x = 99;
            try {
                conn.Open();
                MySqlCommand comm = new MySqlCommand("SELECT count(*) as c FROM guards WHERE gstatus = " + (a=="active"?"'1'":"'2'"), conn);
                MySqlDataReader rdr = comm.ExecuteReader();
                x = int.Parse(rdr.GetString("c"));
            } catch (Exception ee) { MessageBox.Show(ee.ToString()); ; } 
            finally {
                conn.Close();
            }
            return x;
        }

        #endregion

        public static void MoveRecordToArchive(string table, string idname, int id) {
            MySqlCommand com = new MySqlCommand("select * from "+table+" where "+idname+" =" + id, conn);
            conn.Open();
            MySqlDataAdapter adp = new MySqlDataAdapter(com);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            conn.Close();
            
            foreach (DataRow row in dt.Rows) {
                String InsertionQuery = "insert ignore into " + table + " (";

                foreach (DataColumn column in dt.Columns) {
                    InsertionQuery += (column.ColumnName + ",");
                }
                InsertionQuery = InsertionQuery.Substring(0, InsertionQuery.Length - 1);

                InsertionQuery += ") values (";

                foreach (var i in row.ItemArray) {
                    InsertionQuery += ("'" + i.ToString() + "'" + ",");
                }
                InsertionQuery = InsertionQuery.Substring(0, InsertionQuery.Length - 1);
                InsertionQuery += ");";

                MySqlCommand com2 = new MySqlCommand(InsertionQuery, archiveconn);
                archiveconn.Open();
                com2.ExecuteNonQuery();
                archiveconn.Close();
            }

            
        }
        public static void DeleteRecord (string table, string idname, int id) {
            conn.Open();
            MySqlCommand com = new MySqlCommand("delete from " + table + " where " + idname + "=" + id, conn);
            com.ExecuteNonQuery();
            conn.Close();
        }
        public static void DeleteRecordFromArchive(string table, string idname, int id) {
            archiveconn.Open();
            MySqlCommand com = new MySqlCommand("delete from " + table + " where " + idname + "=" + id);
            com.ExecuteNonQuery();
            archiveconn.Close();
        }
    }
}
