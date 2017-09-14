using System;
using System.IO;
using IniParser;
using IniParser.Model;

namespace MSAMISUserInterface {
    public class Data {

        public static FileIniDataParser iniparser = new FileIniDataParser();
        public static IniData PayrollIni;
        public static readonly string PayrollIniLocation = $@"Configuration\\payroll.ini";
        
        public static void InitData() {
            InitPayrollConfig();
            InitRates();
            InitReportsFolder();
            InitGuardStatusAndDutyAssignments();


        }

        public static void InitGuardStatusAndDutyAssignments() {
            // If duty starts now, and not yet activated..
            var w = $@"call init_checkdate_guardstatus()";
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
            SQLTools.ExecuteNonQuery("call init_checkdate_all()");
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
    }
}
