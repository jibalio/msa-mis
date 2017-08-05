using System;
using System.IO;

namespace MSAMISUserInterface {
    public class Data {

        
        
        public static void InitData() {
            
            initRates();
            InitReportsFolder();
        }

        private static void initHourCosts() {
           
        }

        public static void UpdateExipiry() {

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

[Payroll]
DefaultCashAdvance = 0.00
DefaultPHIC = 100.00
DefaultHDMF = 100.00
DefaultCashBond = 150.00
DefaultCola = 100.00
DefaultEmer = 50.00
";
    }
}
