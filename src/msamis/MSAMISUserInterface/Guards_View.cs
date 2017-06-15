using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSAMISUserInterface {
    public partial class Guards_View : Form {
        public int GID { get; set; }
        public MainForm reference;
        public int[] dependents;

        public MySqlConnection conn;
        MySqlCommand comm;
        MySqlDataAdapter adp = new MySqlDataAdapter();
        DataTable dt = new DataTable();

        public Guards_View() {
            InitializeComponent();
            this.Opacity = 0;
        }

        #region Form Properties and Features

        private void RViewEmployees_Load(object sender, EventArgs e) {
            RefreshData();
            FadeTMR.Start();
        }

        private void RViewEmployees_FormClosing(object sender, FormClosingEventArgs e) {
            reference.Opacity = 1;
            reference.Show();
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            this.Close();
            reference.GUARDSRefreshGuardsList();
        }

        private void FadeTMR_Tick(object sender, EventArgs e) {
            this.Opacity += 0.2;
            if (reference.Opacity == 0.6 || this.Opacity >= 1) { FadeTMR.Stop();}
            if (reference.Opacity > 0.7) { reference.Opacity -= 0.1; }
        }
        private void GEditDetailsBTN_Click(object sender, EventArgs e) {
            Guards_Edit view = new Guards_Edit();
            view.GID = this.GID;
            view.button = "UPDATE";
            view.conn = this.conn;
            view.viewref = this;
            view.reference = this.reference;
            view.dependents = this.dependents;
            view.Location = this.Location;
            view.ShowDialog();
        }

        #endregion

        #region Refreshing Data

        public void RefreshData() {       
            try {
                GetQueryReult("SELECT * FROM guards WHERE GID = " + GID);
                GIDLBL.Text = GID.ToString();
                LNLBL.Text = BuildName(dt, 0);
                StatusLBL.Text = GetStatus(dt);
                BdateLBL.Text = dt.Rows[0]["Bdate"].ToString();
                GenderLBL.Text = GetGender(dt);
                HeightLBL.Text = dt.Rows[0]["Height"].ToString();
                WeightLBL.Text = dt.Rows[0]["Weight"].ToString();
                ReligionLBL.Text = dt.Rows[0]["Religion"].ToString();
                CivilStatusLBL.Text = GetCivilStatus(dt);
                ContactNoLBL.Text = dt.Rows[0]["CellNo"].ToString();
                TelNoLBL.Text = dt.Rows[0]["TelNo"].ToString();
                LicenseNoLBL.Text = dt.Rows[0]["LicenseNo"].ToString();
                SSSLBL.Text = dt.Rows[0]["SSS"].ToString();
                TINLBL.Text = dt.Rows[0]["TIN"].ToString();
                PhilHealthLBL.Text = dt.Rows[0]["PhilHealth"].ToString();
                PrevAgencyLBL.Text = dt.Rows[0]["PrevAgency"].ToString();
                PrevAssLVL.Text = dt.Rows[0]["PrevAss"].ToString();
                EdAtLBL.Text = GetEducationalAttainment(dt);
                CourseLBL.Text = dt.Rows[0]["Course"].ToString();
                TrainLBL.Text = dt.Rows[0]["MilitaryTrainings"].ToString();
                ContactLBL.Text = dt.Rows[0]["EmergencyContact"].ToString();
                EmergencyLBL.Text = dt.Rows[0]["EmergencyNo"].ToString();
            } catch (System.IndexOutOfRangeException) {
                conn.Close();
            }
            catch (Exception ee) {
                conn.Close();
                MessageBox.Show(ee.Message);
            }
            
            try {
                GetQueryReult("SELECT * FROM address WHERE GID=" + GID + " ORDER BY Atype ASC");
                BirthplaceLBL.Text = BuildStreet(dt, 0);
                PermAddLBL.Text = BuildStreet(dt, 1);
                TempAddLBL.Text = BuildStreet(dt, 2);
            }
            catch (Exception ee) {
                conn.Close();
                MessageBox.Show(ee.Message);
            }
            try {
                GetQueryReult("SELECT * FROM dependents WHERE GID=" + GID + " AND (DRelationship = '4' OR DRelationship = '5' OR DRelationship = '6') ORDER BY DRelationship ASC");
                MotherLBL.Text = BuildName(dt, 1);
                FatherLBL.Text = BuildName(dt, 0);
                try { SpouseLBL.Text = BuildName(dt, 2); } catch { }
            }
            catch (Exception ee) {
                conn.Close();
                MessageBox.Show(ee.Message);
            }
            try {
                GetQueryReult("SELECT * FROM dependents WHERE GID=" + GID + " AND (DRelationship = '1' OR DRelationship = '2' OR DRelationship = '3') ORDER BY DeID ASC");
                try {
                    dependents = new int[dt.Rows.Count];
                    dependents[0] = int.Parse(dt.Rows[0]["DeID"].ToString());
                    Dependent1LBL.Text = AddRelationship(dt.Rows[0]["DRelationship"].ToString(), BuildName(dt, 0));
                    dependents[1] = int.Parse(dt.Rows[1]["DeID"].ToString());
                    Dependent2LBL.Text = AddRelationship(dt.Rows[1]["DRelationship"].ToString(), BuildName(dt, 1));
                    dependents[2] = int.Parse(dt.Rows[2]["DeID"].ToString());
                    Dependent3LBL.Text = AddRelationship(dt.Rows[2]["DRelationship"].ToString(), BuildName(dt, 2));
                    dependents[3] = int.Parse(dt.Rows[3]["DeID"].ToString());
                    Dependent4LBL.Text = AddRelationship(dt.Rows[3]["DRelationship"].ToString(), BuildName(dt, 3));
                    dependents[4] = int.Parse(dt.Rows[4]["DeID"].ToString());
                    Dependent5LBL.Text = AddRelationship(dt.Rows[4]["DRelationship"].ToString(), BuildName(dt, 4));
                }
                catch { }
                conn.Close();
            }
            catch (Exception ee) {
                conn.Close();
                MessageBox.Show(ee.Message);
            }
        }

        private void GetQueryReult(String query) {
            conn.Open();
            comm = new MySqlCommand(query, conn);
            adp = new MySqlDataAdapter(comm);
            dt = new DataTable();
            adp.Fill(dt);
            conn.Close();
        }

        private String GetStatus(DataTable dt) {
            switch (dt.Rows[0]["gstatus"].ToString()) {
                case "1": return "Active";
                case "2": return "Inactive";
                default: return "Unspecified";
            }
        }

        private String GetEducationalAttainment(DataTable dt) {
            switch (dt.Rows[0]["EdAtt"].ToString()) {
                case "1": return "None";
                case "2": return "Elementary";
                case "3": return "High School";
                case "4": return "College";
                default: return "Unspecified";
            }
        }

        private String GetGender(DataTable dt) {
            switch (dt.Rows[0]["gender"].ToString()) {
                case "1": return "Male";
                case "2": return "Female";
                default: return "Unspecified";
            }
        }

        private String GetCivilStatus(DataTable dt) {
            switch (dt.Rows[0]["CivilStatus"].ToString()) {
                case "1": return "Single";
                case "2": return "Married";
                case "3": return "Widowed";
                default: return "Unspecified";
            }
        }

        private String AddRelationship(String RelationshipType, String Lab) {
            switch (RelationshipType) {
                case "1":
                    return Lab + " - Son";
                case "2":
                    return Lab + " - Daughter";
                case "3":
                    return Lab + " - Sibling";
                default:
                    return Lab + " - Undpecified";
            }
        }

        private String BuildName(DataTable dt, int row) {
            return dt.Rows[row]["ln"].ToString() + ", " + dt.Rows[row]["fn"].ToString() + " " + dt.Rows[row]["mn"].ToString();
        }

        private String BuildStreet(DataTable dt, int row) {
            return dt.Rows[row]["streetno"].ToString() + ", " + dt.Rows[row]["street"].ToString() + ", " + dt.Rows[row]["brgy"].ToString() + ", " + dt.Rows[row]["city"].ToString();
        }

        #endregion

        private void DetailsPNL_Paint(object sender, PaintEventArgs e)
        {
            // AJ HI

            // HI BES XD
        }
    }


}
