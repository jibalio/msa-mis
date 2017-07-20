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

        public Holiday(int month, int day, int type) {
            this.month = month;
            this.day = day;
            this.type = type;
        }

        public bool Equals(Holiday other) {
            return this.month == other.month && this.day == other.day;
        }


        public static void AddHoliday(SelectionRange r, string desc, int type) {
                string q = @"INSERT INTO `msadb`.`holiday` (`datestart`, `dateend`, `desc`,`type`) VALUES ('{0}', '{1}', '{2}', '{3}');";
                q = String.Format(q, r.Start.ToString("MM/dd/yyyy"), r.End.ToString("MM/dd/yyyy"), desc, type);
                SQLTools.ExecuteNonQuery(q);
            InitHolidays();
            
        }
            
        public static void EditHoliday (int hid, string desc, int type) {
                string q = @"UPDATE `msadb`.`holiday` SET `desc`='{0}', type='{2}' where hid='{1}';";
                q = String.Format(q,  desc, hid, type);
                SQLTools.ExecuteNonQuery(q);
            InitHolidays();
        }

        public static void RemoveHoliday(int hid) {
            SQLTools.ExecuteNonQuery("delete from holiday where hid=" + hid);
            InitHolidays();
        }

        public static DataTable GetHolidays() {
            string q = @"SELECT hid, datestart, dateend, `desc`, 
                        case type
                        when 1 then 'Regular'
                        when 2 then 'Special'
                        end as type
                        FROM msadb.holiday; ";
            return SQLTools.ExecuteQuery(q);
        }

        public static void InitHolidays() {
            holidaylist.Clear();
            // datestart, dateend, desc
            string q = "select * from holiday";
            DataTable dt = SQLTools.ExecuteQuery(q);
            foreach (DataRow e in dt.Rows) {
                DateTime start = DateTime.ParseExact(e["datestart"].ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                DateTime end = DateTime.ParseExact(e["dateend"].ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                for (DateTime c = start; c <= end; c=c.AddDays(1)) {
                    holidaylist.Add(new Holiday(c.Month,c.Day, int.Parse(e["type"].ToString())));
                }
            }
        }
        
    }
}
