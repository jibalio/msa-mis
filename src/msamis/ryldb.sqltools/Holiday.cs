using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSAMISUserInterface;
using System.Globalization;

namespace MSAMISUserInterface {
    public class Holiday : IEquatable<Holiday> {

        public int month;
        public int day;
        public bool recurring;
        public int type;
        
        public static int Default = 0;

        public Holiday(int month, int day, int type) {
            this.month = month;
            this.day = day;
            this.type = type;
        }

        public bool Equals(Holiday other) {
            return this.month == other.month && this.day == other.day;
        }


        public static void AddHoliday(SelectionRange r, string desc, int type, int trans) {
                string q =
                    $@"INSERT INTO `msadb`.`holiday` (`type`, `ds_MM`, `ds_dd`, `ds_yyyy`, `de_MM`, `de_dd`, `de_yyyy`, `desc`, `status`, `datestart`, `dateend`) 
                            VALUES ('{type}','{r.Start.Month}','{r.Start.Day}','{r.Start.Year}','{r.End.Month}','{
                        r.End.Day}','{r.Start.Year}','{desc}','{1}', '{r.Start.ToString("yyyy-MM-dd")}', '{r.End.ToString("yyyy-MM-dd")}')";
                SQLTools.ExecuteNonQuery(q);
        }
            
        public static void EditHoliday (int hid, string desc, int type, int trans) {
                string q = @"UPDATE `msadb`.`holiday` SET `desc`='{0}', type='{2}' where hid='{1}';";
                q = String.Format(q,  desc, hid, type);
                SQLTools.ExecuteNonQuery(q);
        }

        public static void RemoveHoliday(int hid) {
            SQLTools.ExecuteNonQuery("delete from holiday where hid=" + hid);
          
        }

        public static DataTable GetHolidays() {
            string q = @"SELECT hid, datestart, dateend, `desc`, 
                        case type
                        when 1 then 'Regular'
                        when 2 then 'Special'
                        end as type,
                        'Fixed' as trans
                        FROM msadb.holiday; ";
            return SQLTools.ExecuteQuery(q);
        }

        public static List<Holiday> InitHolidays(int year) {
            List<Holiday> holidaylist = new List<Holiday>();
            // datestart, dateend, desc
            string q = "select * from holiday where ds_yyyy="+year;
            DataTable dt = SQLTools.ExecuteQuery(q);
            foreach (DataRow e in dt.Rows) {
                var x = e["datestart"].ToString();
                var f = e["dateend"].ToString();
                DateTime start = DateTime.Parse(x);
                DateTime end = DateTime.Parse(f);
                for (DateTime c = start; c <= end; c=c.AddDays(1)) {
                    holidaylist.Add(new Holiday(c.Month,c.Day, int.Parse(e["type"].ToString())));
                }
            }
            return holidaylist;
        }
        
    }
}
