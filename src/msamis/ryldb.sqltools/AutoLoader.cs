using System.IO;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ryldb.sqltools;
using IniParser;
using IniParser.Model;
using rylui;

namespace MSAMISUserInterface {

    public class AutoLoader {
        static String msadb = "../../../../../sql/msadb.sql";
        static String msadbarchive = "../../../../../sql/msadbarchive.sql";
        static String checksumfile = "../../../../../sql/checksum.txt";
        public static string checkMD5(string filename) {
            using (var md5 = MD5.Create()) {
                using (var stream = File.OpenRead(filename)) {
                    return BitConverter.ToString(md5.ComputeHash(stream)).ToLower().Replace("-", "");
                }
            }
        }



        static String[] checksum = new String[2];
        static bool[] hasNewVersion = new bool[2];


        
        public static void Do_Check() {
            string initialini = Data.IniConntent;
            if (!File.Exists(@"msamis.ini")) {
                using (var writer = new StreamWriter(@"msamis.ini")) {
                    writer.WriteLine(initialini);
                }
                
            }


            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("msamis.ini");
            string useFullScreenStr = data["Debug"]["EnableConsoleDebugging"];
            SQLTools.EnableConsoleDebugging = bool.Parse(useFullScreenStr);
            string aui = data["Debug"]["AlwaysUpdateIni"];
            if (bool.Parse(aui)) {
                using (var writer = new StreamWriter(@"msamis.ini")) {
                    writer.WriteLine(initialini);
                }
            }
            data = parser.ReadFile("msamis.ini");



        }

        public static void AutoImportSql(bool db, bool dbarchive) {
            try { SQLTools.conn.Open(); }
            catch (Exception) {
                RylMessageBox.ShowDialog("Server is offline.", "Connection Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            } finally {SQLTools.conn.Close();}
            Do_Check();
            if (!File.Exists(checksumfile)) {
                using (var writer = new StreamWriter(@checksumfile)) {
                    writer.WriteLine("0");
                    writer.WriteLine("0");
                }
            }
            using (StreamReader reader = new StreamReader(checksumfile)) {
                string line;
                int x = 0;
                while ((line = reader.ReadLine()) != null) {
                    checksum[x] = line;
                    x++;
                }
            }

            if (checkMD5(msadb) == checksum[0])
                hasNewVersion[0] = false;
            else hasNewVersion[0] = true;
            if (checkMD5(msadbarchive) == checksum[1])
                hasNewVersion[1] = false;
            else hasNewVersion[1] = true;

            Console.WriteLine(">>>>> AutoLoader.cs: Current `msadb` checksum: " + checksum[0]);
            Console.WriteLine(">>>>> AutoLoader.cs: SqlDump `msadb` checksum: " + checkMD5(msadb));
            if (hasNewVersion[0]) Console.WriteLine(">>>>> MSADB: Hooray! A new version is being downloaded ryt now.");

            Console.WriteLine(">>>>> AutoLoader.cs: Current `msadb` checksum: " + checksum[1]);
            Console.WriteLine(">>>>> AutoLoader.cs: SqlDump `msadb` checksum: " + checkMD5(msadbarchive));
            if (hasNewVersion[0]) Console.WriteLine(">>>>> MSADBARCHIVE: Hooray! A new version is being downloaded ryt now.");

            using (var writer = new StreamWriter(@checksumfile)) {
                writer.WriteLine(checkMD5(msadb));
                writer.WriteLine(checkMD5(msadbarchive));
            }


            if (hasNewVersion[0] || hasNewVersion[1]) {
                LoaderGUI e = new LoaderGUI();
                e.Show();

                if (hasNewVersion[0]) {

                    using (MySqlConnection conn = SQLTools.nodb) {
                        using (MySqlCommand cmd = new MySqlCommand()) {
                            using (MySqlBackup mb = new MySqlBackup(cmd)) {
                                cmd.Connection = conn;
                                conn.Open();
                                mb.ImportFromFile(msadb);
                                conn.Close();
                            }
                        }
                    }
                }

                if (hasNewVersion[1]) {
                    using (MySqlConnection conn = SQLTools.nodb) {
                        using (MySqlCommand cmd = new MySqlCommand()) {
                            using (MySqlBackup mb = new MySqlBackup(cmd)) {
                                cmd.Connection = conn;
                                conn.Open();
                                mb.ImportFromFile(msadbarchive);
                                conn.Close();
                            }
                        }
                    }
                }
                //e.Close();
                e.Close();

            }

        }

    }
}