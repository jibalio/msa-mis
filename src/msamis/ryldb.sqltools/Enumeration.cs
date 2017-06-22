using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSAMISUserInterface {
    public class Enumeration {

        public class Schedule {
            public static int Active = 1;
            public static int Dismissed = 2;
            public static int Inactive = 3;
        }

        public class RequestType {
            public static int Assignment = 1;
            public static int Dismissal = 2;
        }

    }
}
