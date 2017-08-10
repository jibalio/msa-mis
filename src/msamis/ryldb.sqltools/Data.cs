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
            initRates();
            InitReportsFolder();
            //InitGuardStatuses();
        }

        public static void InitGuardStatuses() {
            var w = $@"
               update
	                request_assign 
                    left join sduty_assignment on sduty_assignment.RAID=request_assign.RAID 
                    left join guards on guards.gid = sduty_assignment.GID
                set
	                gstatus=1
                where
	                contractstart<now() AND ContractEnd>now() and gstatus=0";
            SQLTools.ExecuteQuery(w);
            w = $@"
            update
	            request_assign 
                left join sduty_assignment on sduty_assignment.RAID=request_assign.RAID 
                left join guards on guards.gid = sduty_assignment.GID
            set
	            gstatus=0
            where
	            ContractEnd<now() and gstatus = 1
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

        public static void initRates () {
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
