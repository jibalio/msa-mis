using System;
using System.IO;
using IniParser;
using IniParser.Model;

namespace MSAMISUserInterface {
    public class Data {

        public static FileIniDataParser iniparser = new FileIniDataParser();
        public static IniData PayrollIni;
        public static readonly string PayrollIniLocation = $@"Configuration\\payroll.ini";

        public static readonly string PayrollIniContent =
            #region + string definition
            $@"[Payroll]
DefaultCashAdvance = 0.00
DefaultPHIC = 100.00
DefaultHDMF = 100.00
DefaultCashBond = 150.00
DefaultCola = 100.00
DefaultEmer = 50.00";
        #endregion
        public static void InitData() {
            InitPayrollConfig();
            InitRates();
            InitReportsFolder();
            InitGuardStatusAndDutyAssignments();
        }

        public static void InitGuardStatusAndDutyAssignments() {
            // If duty starts now, and not yet activated..
            var w = $@"
               update
	                request_assign 
                    left join sduty_assignment on sduty_assignment.RAID=request_assign.RAID 
                    left join guards on guards.gid = sduty_assignment.GID
                set
	                gstatus=1,
                    astatus={Enumeration.AssignmentStatus.Active}
                where
	                contractstart<now() AND ContractEnd>now() and gstatus={Enumeration.GuardStatus.Inactive}";
            SQLTools.ExecuteQuery(w);
            w = $@"
            update
	            request_assign 
                left join sduty_assignment on sduty_assignment.RAID=request_assign.RAID 
                left join guards on guards.gid = sduty_assignment.GID
            set
	            gstatus=0,
                astatus={Enumeration.AssignmentStatus.Inactive}
            where
	            ContractEnd<now() and gstatus = {Enumeration.GuardStatus.Active}
            ";
            SQLTools.ExecuteQuery(w);
        }

        public static void InitPayrollConfig() {
            FileInfo fi = new FileInfo(PayrollIniLocation);
            if (!fi.Directory.Exists) {
                System.IO.Directory.CreateDirectory(fi.DirectoryName);
            }
            string initialini = Data.IniConntent;
            //Directory.CreateDirectory(Path.GetDirectoryName("Configuration"));
            if (!File.Exists(PayrollIniLocation)) {
                using (var writer = new StreamWriter(PayrollIniLocation)) {
                    writer.WriteLine(PayrollIniContent);
                }
            }
            PayrollIni = iniparser.ReadFile(PayrollIniLocation);
        }

        public static void InitRates () {
            // This checks for new and outdated rates.
            // (incl. basic pay)
            // Basic Pay Portion
            SQLTools.ExecuteNonQuery("call init_checkdate_basicpay()");

            // ContribID portions
            

        }

        public static void InitReportsFolder() {
            String filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "MSAMIS Reports";
            bool exists = Directory.Exists(filePath);
            if (!exists) {
                DirectoryInfo dir = Directory.CreateDirectory(filePath);
                dir.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
            }
        }


        public static string IniConntent =
            @";MSA-MIS Configuration file
[Debug]
EnableConsoleDebugging = false
AlwaysUpdateIni = true

[Reports]
DefaultDirectory = C:\Docs
";
    }
}
