using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ryldb.sqltools {
    public class Holiday : IEquatable<Holiday> {

        public int month;
        public int day;
        public bool recurring;
        public int type;

        public static int Default = 0;

        public Holiday(int month, int day) {
            this.month = month;
            this.day = day;
        }

        public bool Equals(Holiday other) {
            return this.month == other.month && this.day == other.day;
        }


        public static void AddHoliday(SelectionRange r, string name, string desc) {
            for (DateTime date = r.Start; date <= r.End; date = date.AddDays(1)){
                string q = @"INSERT INTO `msadb`.`holiday` (`date`, `name`, `desc`) VALUES ('{0}', '{1}', '{2}');";
                q = String.Format(q, date.ToString("MM/dd/yyyy"), name, desc);
                MSAMISUserInterface.SQLTools.ExecuteNonQuery(q);
            }
        }
        
        public static void EditHoliday (SelectionRange r, string name, string desc) {
            for (DateTime date = r.Start; date <= r.End; date = date.AddDays(1)){
                string q = @"UPDATE `msadb`.`holiday` SET `date`='{0}', `name`='{1}', `desc`='{2}';";
                q = String.Format(q, date.ToString("MM/dd/yyyy"), name, desc);
                MSAMISUserInterface.SQLTools.ExecuteNonQuery(q);
            }
        }

        public static void RemoveHoliday(SelectionRange r, string name, string desc) {
            for (DateTime date = r.Start; date <= r.End; date = date.AddDays(1)) {
                string q = @"delete from holiday where `date`='{0}' and `name`='{1}' and `desc`='{2}';";
                q = String.Format(q, date.ToString("MM/dd/yyyy"), name, desc);
                MSAMISUserInterface.SQLTools.ExecuteNonQuery(q);
            }
        }

        public static DataTable GetHolidays() {
            string q = "select * from holiday";
            return MSAMISUserInterface.SQLTools.ExecuteQuery(q);
        }

    }
}
