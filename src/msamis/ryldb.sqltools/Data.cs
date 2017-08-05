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
    }
}
