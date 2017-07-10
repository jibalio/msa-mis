using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
