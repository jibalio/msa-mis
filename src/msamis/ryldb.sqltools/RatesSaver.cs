using System;
using System.Windows.Forms;

namespace MSAMISUserInterface {
    public class RatesSaver {

        private static string withtaxquery = "";
        private static int contrib_id;
        public static void CreateWithTaxQuery(DateTime date_effective) {
            SingleTransactionQuery =
                "insert into `msadb`.`withtax_bracket` (`estatus`, `bracket`, `taxid`, `contrib_id`) VALUES ";
            var insert_contribdetail =
                $@"INSERT INTO `msadb`.`contribdetails` 
                    (`date_effective`, `date_dissolved`, `type`, `status`) 
                    VALUES ('{date_effective.ToString("yyyy-MM-dd")}', '{"9999-12-31"}', '{2}', '{2}');";
            SQLTools.ExecuteQuery(insert_contribdetail);
            contrib_id = SQLTools.GetInt("select last_insert_id()");
        }

        public static int CreateWithTaxBracket(double value, int excessmult) {
            var isnert_query = $@"INSERT INTO `msadb`.`withtax_value` (`value`, `excessmult`) VALUES ('{value}', '{excessmult}');";
            SQLTools.ExecuteQuery(isnert_query);
            return SQLTools.GetInt("select last_insert_id()");
        }

        private static string SingleTransactionQuery =
            "insert into `msadb`.`withtax_bracket` (`estatus`, `bracket`, `taxid`, `contrib_id`) VALUES ";

        
        public static void AddToWithTaxQuery(int bracket_id, string DependentsStatus, double BracketValue) {
            SingleTransactionQuery += $"('{DependentsStatus}', '{BracketValue}', '{bracket_id}', '{contrib_id}'),";
        }


        public static void ExecuteWithTaxQuery() {
            var query = SingleTransactionQuery.Substring(0, SingleTransactionQuery.Length - 1);
            SQLTools.ExecuteQuery(query);
        }


        /// <summary>
        /// Use only for pending dates. 
        /// </summary>
        public static void DeleteRate(int rates_id) {
            string checkifdeletable = $@"select (date_effective>NOW()) from rates where rates_id = {rates_id};";
            string deletequery = $@"delete FROM msadb.rates where rid = {rates_id};";
            int deletable = SQLTools.GetInt(checkifdeletable);
            if (deletable == 1) { SQLTools.ExecuteNonQuery(deletequery); }
            else { MessageBox.Show("Error", "Can't delete this rate"); }
        }

        public static void DeleteContrib(int contrib_id) {
            SQLTools.ExecuteNonQuery($@"DELETE FROM contribdetails where contrib_id={contrib_id}");
        }
        

    }
}
