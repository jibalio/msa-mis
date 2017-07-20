﻿using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
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

        private readonly Color dark = Color.FromArgb(53, 64, 82);
        private readonly Color light = Color.DarkGray;

        private Panel PNL;
        private Label LBL;

        public Shadow refer;

        public Guards_View() {
            InitializeComponent();
            Opacity = 0;
        }

        #region Form Properties and Features

        private void RViewEmployees_Load(object sender, EventArgs e) {
            RefreshData();
            FadeTMR.Start();
            PNL = PersonalPNL;
            LBL = PersonalLBL;
            PersonalPNL.Visible = true;
        }

        private void RViewEmployees_FormClosing(object sender, FormClosingEventArgs e) {
            refer.Close();
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            Close();
            reference.GUARDSRefreshGuardsList();
        }

        private void FadeTMR_Tick(object sender, EventArgs e) {
            Opacity += 0.2;
            if (Opacity >= 1) { FadeTMR.Stop();}
        }
        private void GEditDetailsBTN_Click(object sender, EventArgs e) {
            var view = new Guards_Edit
            {
                GID = GID,
                button = "UPDATE",
                conn = conn,
                viewref = this,
                reference = reference,
                dependents = dependents,
                Location = Location
            };
            view.ShowDialog();
        }

        #endregion

        #region Refreshing Data

        public void RefreshData() {       
            try {
                GetQueryReult("SELECT * FROM guards WHERE GID = " + GID);
                GIDLBL.Text = GID.ToString();
                LNLBL.Text = dt.Rows[0]["fn"] + " " + dt.Rows[0]["mn"];
                LLBL.Text = dt.Rows[0]["ln"] + ", ";
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
            } catch (IndexOutOfRangeException) {
                conn.Close();
            }
            catch {
            }
            
            try {
                GetQueryReult("SELECT * FROM address WHERE GID=" + GID + " ORDER BY Atype ASC");
                BirthplaceLBL.Text = BuildStreet(dt, 0);
                PermAddLBL.Text = BuildStreet(dt, 1);
                TempAddLBL.Text = BuildStreet(dt, 2);
            }
            catch {
            }
            try {
                GetQueryReult("SELECT * FROM dependents WHERE GID=" + GID + " AND (DRelationship = '4' OR DRelationship = '5' OR DRelationship = '6') ORDER BY DRelationship ASC");
                MotherLBL.Text = BuildName(dt, 1);
                FatherLBL.Text = BuildName(dt, 0);
                try { SpouseLBL.Text = BuildName(dt, 2); } catch { }
            }
            catch {
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
            catch {
                conn.Close();
            }
        }

        private void GetQueryReult(string query) {
            conn.Open();
            comm = new MySqlCommand(query, conn);
            adp = new MySqlDataAdapter(comm);
            dt = new DataTable();
            adp.Fill(dt);
            conn.Close();
        }

        private static string GetStatus(DataTable dt) {
            switch (dt.Rows[0]["gstatus"].ToString()) {
                case "1": return "Active";
                case "2": return "Inactive";
                default: return "Unspecified";
            }
        }

        private static string GetEducationalAttainment(DataTable dt) {
            switch (dt.Rows[0]["EdAtt"].ToString()) {
                case "1": return "None";
                case "2": return "Elementary";
                case "3": return "High School";
                case "4": return "College";
                default: return "Unspecified";
            }
        }

        private static string GetGender(DataTable dt) {
            switch (dt.Rows[0]["gender"].ToString()) {
                case "1": return "Male";
                case "2": return "Female";
                default: return "Unspecified";
            }
        }

        private static string GetCivilStatus(DataTable dt) {
            switch (dt.Rows[0]["CivilStatus"].ToString()) {
                case "1": return "Single";
                case "2": return "Married";
                case "3": return "Widowed";
                default: return "Unspecified";
            }
        }

        private static string AddRelationship(String RelationshipType, String Lab) {
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

        private static string BuildName(DataTable dt, int row) {
            return dt.Rows[row]["ln"] + ", " + dt.Rows[row]["fn"] + " " + dt.Rows[row]["mn"];
        }

        private static string BuildStreet(DataTable dt, int row) {
            return dt.Rows[row]["streetno"] + ", " + dt.Rows[row]["street"] + ", " + dt.Rows[row]["brgy"] + ", " + dt.Rows[row]["city"];
        }

        #endregion

        private void ChangePage(Panel NewP, Label newB) {
            PNL.Visible = false;
            LBL.ForeColor = light;

            NewP.Visible = true;
            newB.ForeColor = dark;

            PNL = NewP;
            LBL = newB;
        }

        private void FamilyLBL_MouseEnter(object sender, EventArgs e) {
            FamilyLBL.ForeColor = dark;
        }

        private void WorkLBL_MouseEnter(object sender, EventArgs e) {
            WorkLBL.ForeColor = dark;
        }

        private void PersonalLBL_MouseEnter(object sender, EventArgs e) {
            PersonalLBL.ForeColor = dark;
        }

        private void PersonalLBL_MouseLeave(object sender, EventArgs e) {
            if(PersonalLBL != LBL) PersonalLBL.ForeColor = light;
        }

        private void FamilyLBL_MouseLeave(object sender, EventArgs e) {
            if (FamilyLBL != LBL) FamilyLBL.ForeColor = light;
        }

        private void WorkLBL_MouseLeave(object sender, EventArgs e) {
            if (WorkLBL != LBL) WorkLBL.ForeColor = light;
        }

        private void PersonalLBL_Click(object sender, EventArgs e) {
            ChangePage(PersonalPNL, PersonalLBL);
        }

        private void FamilyLBL_Click(object sender, EventArgs e) {
            ChangePage(FamilyPNL, FamilyLBL);
        }

        private void WorkLBL_MouseClick(object sender, MouseEventArgs e) {
            ChangePage(WorkPNL, WorkLBL);
        }

        private void CloseBTN_MouseEnter(object sender, EventArgs e) {
            CloseBTN.ForeColor = Color.White;
        }

        private void CloseBTN_MouseLeave(object sender, EventArgs e) {
            CloseBTN.ForeColor = dark;
        }
    }


}
