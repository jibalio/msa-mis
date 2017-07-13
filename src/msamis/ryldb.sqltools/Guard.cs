using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSAMISUserInterface {
    class Guard {
        public static int GetNumberOfDependents(int GID) {
            String q = @"SELECT count(DeID) FROM msadb.dependents where GID={0};";
            q = String.Format(q, GID);
            return SQLTools.GetInt(q);
        }
    }
}
