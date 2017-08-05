using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Xml.Serialization;


/* Leryc*/
namespace MSAMISUserInterface {
    public static class SQLTools {
        public static string sqlversion = "5";
        public static String ArchiveName = "msadbarchive";
        public static MySqlConnection conn = new MySqlConnection("Server=localhost;Database=MSAdb;Uid=root;Pwd=root;");
        public static MySqlConnection archiveconn = new MySqlConnection("Server=localhost;Database=" + ArchiveName + ";Uid=root;Pwd=root;");
        public static MySqlConnection nodb = new MySqlConnection("Server=localhost;Uid=root;Pwd=root;");
        /* GENERIC METHODS
         * ExecuteQuery(query)      :   DataTable
         * ExecuteReader(query)     :   MySqlDataReader
         * ExecuteNonQuery(query)   :   void
         * ExecuteSingleResult(query)  :   String
         * ExecuteQuery (String query)
         * ExecuteQuery (String query, String ColumnToFilterByKeyword, String keyword)
         * ExecuteQuery (String query, String ColumnToFilterByKeyword, String keyword, String orderby)
         * ExecuteQuery(String query, String ColumnToFilterByKeyword, String keyword, String orderby, String[] filters)
         */

        /*
         *  HOW TO USE ExecuteQuery(String query, String ColumnToFilterByKeyword, String keyword, String orderby, String[] filters)
         *  
         *  Package:    ryldb.sqltools
         *  Class:      SQLTools
         *  Method:     ExecuteQuery(String query, String ColumnToFilterByKeyword, String keyword, String orderby, String[] filters)
         *  
         *  @return DataTable with specified filters applied
         *  @param query:     Base query
         *                   e.g. select * from clients
         *  @param ColumnToFilterByKeyword:    column to sortby
         *                  e.g. AssignmentID
         *  @param keyword: filter column with keyword
         *  @param orderby:  format:  "<ColumnToSort> <ASC/DESC>"
         *  
         *  @param filters[]: THE TRICKY PART: pay close attention boi 👀👀
         *  In order for this to work, query must be formatted such that it is compatible with
         *  C#'s String.format(). 
         *  TL;DR: Use placeholders {0} {1} .... {n}
         *  Example: 
         *      select * from guards where lastname='{0}' and firstname='{1}'
         *  then, in the filters[] parameter, create a string array containing the corresponding placeholder values.
         *  
         *  Example usage:
         *  String q = "select ln, fn, mn from guards where status={0} and birthyear={1}";
         *  ryldb.sqltools.SqlTools.ExecuteQuery( q, "ln", "Regodon", "ln asc", new String ("Active", "1998");
         * 
         * 
         *  OTHER VARIANTS THO
         *  ExecuteQuery (String query)
         *  ExecuteQuery (String query, String ColumnToFilterByKeyword, String keyword)
         *  ExecuteQuery (String query, String ColumnToFilterByKeyword, String keyword, String orderby)
         *  ExecuteQuery(String query, String ColumnToFilterByKeyword, String keyword, String orderby, String[] filters)
         */

        #region Generic Methods

        public static string SerializeMe<T>(this T toSerialize) {
            XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());
            using (StringWriter textWriter = new StringWriter()) {
                xmlSerializer.Serialize(textWriter, toSerialize);
                return textWriter.ToString();
            }
        }
        public static String RemoveSemicolon(String q) {
            if (q.EndsWith(";")) {                  // Removes semicolon if it has one, so 
                q = q.Substring(0, q.Length - 1);   // that filters can be added.
            } q += " ";
            return q;
        }
        
        public static String AppendType(String q, String[] filters) {
           
            q = RemoveSemicolon(q);
            if (filters != null) {
                return String.Format(q, filters);
            }
            else return q;      // if no specified filters, return original.
        }

        // Hi! This method is semicolon-ed query friendly 💯💯💯 🔥🔥
        public static String AppendFilters (String q, String ColumnToFilterByKeyword, String keyword, String orderby) {
            q = RemoveSemicolon(q);
            if (ColumnToFilterByKeyword!="" && ColumnToFilterByKeyword!=null) {
                if (!q.ToLower().Contains("where")) {
                    q += "      where ";
                } else q += " and ";
                q += "("+ColumnToFilterByKeyword + " LIKE '"+ 
                    (keyword==empty ? "%" : "%" + keyword + "%") 
                    +"')";
            }
            if (orderby!="" && orderby != null) {
                q += " order by " + orderby;
            }
            return q;
        }

        public static String empty = "";
        public static DataTable ExecuteQuery (String query) {
            return ExecuteQuery(query, "", "");
        }
        public static DataTable ExecuteQuery (String query, String ColumnToFilterByKeyword, String keyword) {
            return ExecuteQuery(query,ColumnToFilterByKeyword,keyword, "");
        }
        public static DataTable ExecuteQuery (String query, String ColumnToFilterByKeyword, String keyword, String orderby) {
            return ExecuteQuery(query, ColumnToFilterByKeyword, keyword, orderby, null);
        }
        public static DataTable ExecuteQuery(String query, String ColumnToFilterByKeyword, String keyword, String orderby, String[] filters) {
            query = AppendType(query, filters);
            query = AppendFilters(query, ColumnToFilterByKeyword, keyword, orderby);
            DataTable dt = new DataTable();
            message(query);
            try {
                MySqlCommand com = new MySqlCommand(query, SQLTools.conn);
                SQLTools.conn.Open();
                MySqlDataAdapter adp = new MySqlDataAdapter(com);
                adp.Fill(dt);
            } catch (Exception e) {
                MessageBox.Show(e.ToString());
            } finally {
                
                SQLTools.conn.Close();
            }
            return dt;
        }

        public static DataTable ExecuteQuery_ (String query) {
            message(query);
            DataTable dt = new DataTable();
                MySqlCommand com = new MySqlCommand(query, SQLTools.conn);
                SQLTools.conn.Open();
                MySqlDataAdapter adp = new MySqlDataAdapter(com);
                adp.Fill(dt);
            return dt;
        }

        public static void ExecuteNonQuery(string query) {
            ExecuteNonQuery(query, true);
        }

        public static void ExecuteNonQuery (string query, bool enablecheck) { 
            if (enablecheck) {
                try {
                    message(query);
                    MySqlCommand com = new MySqlCommand(query, conn);
                    SQLTools.conn.Open();
                    com.ExecuteNonQuery();
                } catch (Exception e) {
                    MessageBox.Show(e.ToString());
                } finally {
                    SQLTools.conn.Close();
                }
            } else {
                message(query);
                MySqlCommand com = new MySqlCommand(query, conn);
                SQLTools.conn.Open();
                try { com.ExecuteNonQuery(); } catch (Exception e) {
                    throw;
                } finally {
                    SQLTools.conn.Close();
                }
                
            }
           
        }

        public static bool EnableConsoleDebugging = false;
        public static void message (String query) {
            
            if (EnableConsoleDebugging) Console.WriteLine(query);
        }
        public static void ExecuteNonQueryNoDB(string query) {
            try {
                MySqlCommand com = new MySqlCommand(query, nodb);
                SQLTools.nodb.Open();
                com.ExecuteNonQuery();
            } catch (Exception e) {
                MessageBox.Show(e.ToString());
            } finally {
                SQLTools.nodb.Close();
            }
        }

        public static MySqlDataReader ExecuteReader(String query) {
            MySqlDataReader rdr = null;
            try {
                MySqlCommand com = new MySqlCommand(query, conn);
                conn.Open();
                rdr = com.ExecuteReader();
            } catch (Exception e) {
                MessageBox.Show(e.ToString());
            } finally {
                conn.Close();
            }
            return rdr;
        }

        public static String ExecuteSingleResult(String query) {
      
            DataTable dt = ExecuteQuery(query);
            string asc;
            try { asc = dt.Rows[0][0].ToString(); }
            catch (Exception sd) { return ""; }
            return asc;
        }
        
        public static int GetInt (String query) {
            return int.Parse(SQLTools.ExecuteSingleResult(query));
        }

        #endregion

        #region meta functions

        /* VersionChangeCheck : void
         * Checks if Leryc had edited MySQL database. Returns error 
         * if DB is not updated. Redirects to dropbox link to SQL file.
         */
        
        public static void VersionCheck() {
            MySqlCommand com = new MySqlCommand("select version from meta where meta_id=1", conn);
            conn.Open();
            try {
                MySqlDataAdapter adp = new MySqlDataAdapter(com);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows[0]["version"].ToString() != sqlversion) {
                    throw new Exception();
                } else { conn.Close(); return; }
            } catch (MySql.Data.MySqlClient.MySqlException) {
                conn.Close();
                throw new Exception();
            }


        }

        #endregion

        #region Guard Management

        public static int GetNumberOfGuards(String a) {
            int x = 99;
            try {
                conn.Open();
                MySqlCommand comm = new MySqlCommand("SELECT count(*) as c FROM guards WHERE gstatus = " + (a == "active" ? "'1'" : "'2'"), conn);
                MySqlDataReader rdr = comm.ExecuteReader();
                rdr.Read();
                x = int.Parse(rdr.GetString("c"));
            } catch (Exception ee) { MessageBox.Show(ee.ToString()); ; } finally {
                conn.Close();
            }
            return x;
        }





        public static void MoveRecordToArchive(string table, string idname, int id) {
            MySqlCommand com = new MySqlCommand("select * from " + table + " where " + idname + " =" + id, conn);
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
        public static void DeleteRecord(string table, string idname, int id) {
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



        #endregion



        public static String getDateTime() {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }

        public static DateTime GetDateTime(string e) {
            return DateTime.ParseExact(e, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        }

        public static String getLastInsertedId (String table, String idcolumn) {
            String q = "select max("+idcolumn+") from "+table;
            DataTable dt = ExecuteQuery(q);
            return dt.Rows[0][0].ToString();
        }
    }
}
