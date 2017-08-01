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
            Payroll.rates.Add("nsu_proper_day_normal", 1);
            Payroll.rates.Add("nsu_proper_day_special", 1.3);
            Payroll.rates.Add("nsu_proper_day_regular", 2);
            Payroll.rates.Add("nsu_proper_night_normal", 1.1);
            Payroll.rates.Add("nsu_proper_night_special", 1.43);
            Payroll.rates.Add("nsu_proper_night_regular", 2.2);
            Payroll.rates.Add("nsu_overtime_day_normal", 1.25);
            Payroll.rates.Add("nsu_overtime_day_special", 1.69);
            Payroll.rates.Add("nsu_overtime_day_regular", 2.6);
            Payroll.rates.Add("nsu_overtime_night_normal", 1.375);
            Payroll.rates.Add("nsu_overtime_night_special", 1.859);
            Payroll.rates.Add("nsu_overtime_night_regular", 2.86);
            Payroll.rates.Add("sun_proper_day_normal", 1.3);
            Payroll.rates.Add("sun_proper_day_special", 1.5);
            Payroll.rates.Add("sun_proper_day_regular", 2.6);
            Payroll.rates.Add("sun_proper_night_normal", 1.43);
            Payroll.rates.Add("sun_proper_night_special", 1.65);
            Payroll.rates.Add("sun_proper_night_regular", 2.86);
            Payroll.rates.Add("sun_overtime_day_normal", 1.625);
            Payroll.rates.Add("sun_overtime_day_special", 1.95);
            Payroll.rates.Add("sun_overtime_day_regular", 3.38);
            Payroll.rates.Add("sun_overtime_night_normal", 1.859);
            Payroll.rates.Add("sun_overtime_night_special", 2.145);
            Payroll.rates.Add("sun_overtime_night_regular", 3.718);

        }

        public static void InitReportsFolder() {
            String filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "MSAMIS Reports";
            bool exists = Directory.Exists(filePath);
            if (!exists) {
                DirectoryInfo dir = Directory.CreateDirectory(filePath);
                dir.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
            }

        }
    }
}
