using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSAMISUserInterface;
using System.Globalization;

namespace ryldb.sqltools {
    public class Holiday : IEquatable<Holiday> {

        public int month;
        public int day;
        public bool recurring;
        public int type;
        public static List<Holiday> holidaylist = new List<Holiday>();
        public static int Default = 0;

        public Holiday(int month, int day) {
            this.month = month;
            this.day = day;
        }

        public bool Equals(Holiday other) {
            return this.month == other.month && this.day == other.day;
        }


        public static void AddHoliday(SelectionRange r, string desc) {
                string q = @"INSERT INTO `msadb`.`holiday` (`datestart`, `dateend`, `desc`) VALUES ('{0}', '{1}', '{2}');";
                q = String.Format(q, r.Start.ToString("MM/dd/yyyy"), r.End.ToString("MM/dd/yyyy"), desc);
                SQLTools.ExecuteNonQuery(q);
            
        }
            
        public static void EditHoliday (SelectionRange r, string desc) {
                string q = @"UPDATE `msadb`.`holiday` SET `datestart`='{0}', `dateend`='{1}', `desc`='{2}';";
                q = String.Format(q, r.Start.ToString("MM/dd/yyyy"), r.End.ToString("MM/dd/yyyy"), desc);
                SQLTools.ExecuteNonQuery(q);
        }

        public static void RemoveHoliday(int hid) {
            SQLTools.ExecuteNonQuery("delete from hid where hid=" + hid);
        }

        public static DataTable GetHolidays() {
            string q = "select * from holiday";
            return SQLTools.ExecuteQuery(q);
        }

        public static void InitHolidays() {
            // datestart, dateend, desc
            string q = "select * from holiday";
            DataTable dt = SQLTools.ExecuteQuery(q);
            foreach (DataRow e in dt.Rows) {
                DateTime start = DateTime.ParseExact(e["datestart"].ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                DateTime end = DateTime.ParseExact(e["dateend"].ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                for (DateTime c = start; c <= end; c=c.AddDays(1)) {
                    holidaylist.Add(new Holiday(c.Month,c.Day));
                }
            }
        }
        
    }
}
