using System;
using System.Data;

namespace MSAMISUserInterface {
    public class Guard {

        public static DataTable GetAssignmentHistory(int GuardId) {
            throw new NotImplementedException();
        }

        public static int GetNumberOfDependents(int GID) {
            String q = @"SELECT count(DeID) FROM msadb.dependents where GID={0};";
            q = string.Format(q, GID);
            return SQLTools.GetInt(q)-2;
        }

        public static int GetCivilStatus(int GID) {
            string q = @"SELECT CivilStatus from msadb.guards where GID=" + GID;
            return SQLTools.GetInt(q);
        }

        public static DataTable GetAllGuards(string searchKeyWords, int mode) {
            string query;
            string orderbyclause;
            if (mode == 0) {
                query = "Select gid,concat(ln,', ',fn,' ',mn) as NAME, " +
                        "case gstatus when 1 then 'Active' when 2 then 'Inactive' end as 'STATUS', " +
                        "bdate as BIRTHDATE, case gender when 1 then 'Male' when 2 then 'Female' end as 'GENDER', " +
                        "cellno as 'CONTACTNO' " +
                        "FROM Guards ";
                orderbyclause = "ORDER BY NAME ASC;";
            } else {
                query = "Select Guards.gid,concat(ln,', ',fn,' ',mn) as NAME, " +
                        "concat(StreetNo,', ', Brgy,', ',Street, ', ', City) As LOCATION, case gstatus when 1 then 'Active' when 2 then 'Inactive' end as 'STATUS' " +
                        "FROM Guards LEFT JOIN Address ON Address.GID = Guards.GID ";
                orderbyclause = "AND Atype = 2 ORDER BY NAME ASC;";
            }
            return (SQLTools.ExecuteQuery(query + searchKeyWords + orderbyclause));
        }

        public static DataTable GetGuardsBasicData(int GID) {
            return SQLTools.ExecuteQuery("SELECT * FROM guards WHERE GID = " + GID);
        }

        public static DataTable GetGuardsAddresses(int GID) {
            return SQLTools.ExecuteQuery("SELECT * FROM address WHERE GID=" + GID + " ORDER BY Atype ASC");
        }
        public static DataTable GetGuardsParents(int GID) {
            return SQLTools.ExecuteQuery("SELECT * FROM dependents WHERE GID=" + GID + " AND (DRelationship = '4' OR DRelationship = '5' OR DRelationship = '6') ORDER BY DRelationship ASC");
        }
        public static DataTable GetGuardsDependents(int GID) {
            return SQLTools.ExecuteQuery("SELECT * FROM dependents WHERE GID=" + GID + " AND (DRelationship = '1' OR DRelationship = '2' OR DRelationship = '3') ORDER BY DeID ASC");
        }

        public static void AddGuardBasicInfo(string FirstNameBX,string MiddleNameBX, string LastNameBX, DateTime BirthdateBX, int gender, string HeightBX,string WeightBX,string ReligionBX,int CVStatusBX,string CellNoBX,string TellNoBX,string LicenseNoBX,string SSSNoBX,string TINNoBX,string PhilHealthBX,string PrevAgencyBX,string PrevAssBX,int EdAttBX,string CourseBX,string MilTrainBX,string EmergBX,string EmergencyNoBX) {
            SQLTools.ExecuteNonQuery("INSERT INTO Guards(FN, MN, LN, GStatus, BDate, Gender, Height, Weight, Religion, CivilStatus, CellNo, TelNo, LicenseNo, SSS, TIN, PhilHealth, PrevAgency, PrevAss, EdAtt, Course, MilitaryTrainings, EmergencyContact, EmergencyNo) VALUES ('" + FirstNameBX + "','" + MiddleNameBX + "','" + LastNameBX + "','" + 0 + "','" + BirthdateBX.Month + "/" + BirthdateBX.Day + "/" + BirthdateBX.Year + "','" + gender + "','" + HeightBX + "','" + WeightBX + "','" + ReligionBX + "','" + CVStatusBX + "','" + CellNoBX + "','" + TellNoBX + "','" + LicenseNoBX + "','" + SSSNoBX + "','" + TINNoBX + "','" + PhilHealthBX + "','" + PrevAgencyBX + "','" + PrevAssBX + "','" + EdAttBX + "','" + CourseBX + "','" + MilTrainBX + "','" + EmergBX + "','" + EmergencyNoBX + "')");
        }

        public static void AddGuardsDependent(int Gid, int Rel, string First, string Middle, string Last) {
            SQLTools.ExecuteNonQuery("INSERT INTO Dependents(DRelationship, GID, FN, MN, LN) VALUES ('" + Rel + "','" + Gid + "','" + First + "','" + Middle + "','" + Last + "')");
        }

        public static void AddGuardAddress(int Gid, int type, String StreetNo, String Street, String City, String Brgy) {
            SQLTools.ExecuteNonQuery("INSERT INTO Address(GID, AType, StreetNo, Street, City, Brgy) VALUES ('" + Gid + "','" + type + "','" + StreetNo + "','" + Street + "','" + City + "','" + Brgy + "')");
        }

        public static void UpdateGuardAddress(int Gid, String StreetNo, String Street, String City, String Brgy, int typ) {
            SQLTools.ExecuteNonQuery("UPDATE Address SET StreetNo = '" + StreetNo + "', Street = '" + Street + "', City = '" + City + "', Brgy = '" + Brgy + "' WHERE Atype = '" + typ + "' AND GID=" + Gid);

        }

        public static void UpdateGuardsDependent(int Gid, int Rel, string First, string Middle, string Last) {
            SQLTools.ExecuteNonQuery("UPDATE Dependents SET FN = '" + First + "', MN = '" + Middle + "', LN = '" + Last + "' WHERE DRelationship = '" + Rel + "' AND GID=" + Gid);
        }

        public static void UpdateGuardsDependent(int Gid, String First, String Middle, String Last, int Rel, int ID) {
            SQLTools.ExecuteNonQuery("UPDATE Dependents SET FN = '" + First + "', MN = '" + Middle + "', LN = '" + Last + "', DRelationship = '" + Rel + "' WHERE GID=" + Gid + " AND DeID = " + ID);
        }

        public static void UpdateGuardBasicInfo(int Gid, string FirstNameBX, string MiddleNameBX, string LastNameBX, DateTime BirthdateBX, int gender, string HeightBX, string WeightBX, string ReligionBX, int CVStatusBX, string CellNoBX, string TellNoBX, string LicenseNoBX, string SSSNoBX, string TINNoBX, string PhilHealthBX, string PrevAgencyBX, string PrevAssBX, int EdAttBX, string CourseBX, string MilTrainBX, string EmergBX, string EmergencyNoBX) {
            SQLTools.ExecuteNonQuery("UPDATE Guards SET FN = '" + FirstNameBX + "', MN = '" + MiddleNameBX + "', LN = '" + LastNameBX + "', BDate = '" + BirthdateBX.Month + "/" + BirthdateBX.Day + "/" + BirthdateBX.Year + "', Gender =  '" + gender + "', Height = '" + HeightBX + "', Weight = '" + WeightBX + "', Religion = '" + ReligionBX + "', CivilStatus = '" + CVStatusBX + "', CellNo = '" + CellNoBX + "', TelNo = '" + TellNoBX + "', LicenseNo = '" + LicenseNoBX + "', SSS = '" + SSSNoBX + "', TIN = '" + TINNoBX + "', PhilHealth = '" + PhilHealthBX + "', PrevAgency = '" + PrevAgencyBX + "', PrevAss = '" + PrevAssBX + "', EdAtt = '" + EdAttBX + "', Course = '" + CourseBX + "', MilitaryTrainings = '" + MilTrainBX + "', EmergencyContact = '" + EmergBX + "', EmergencyNo = '" + EmergencyNoBX + "' WHERE GID=" + Gid);
        }
    }
}
