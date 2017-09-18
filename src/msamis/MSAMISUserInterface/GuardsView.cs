using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using rylui;

namespace MSAMISUserInterface {
    public partial class GuardsView : Form {
        private readonly Color _dark = Color.FromArgb(53, 64, 82);
        private readonly Color _light = Color.DarkGray;

        private DataTable _dataTable = new DataTable();
        private Label _label;

        private Panel _panel;
        public int[] Dependents;
        public MainForm Reference;

        public Shadow Shadow;

        public GuardsView() {
            InitializeComponent();
            Opacity = 0;
        }

        public int Gid { get; set; }

        private const int CsDropshadow = 0x20000;

        protected override CreateParams CreateParams {
            get {
                var cp = base.CreateParams;
                cp.ClassStyle |= CsDropshadow;
                return cp;
            }
        }

        private void ChangePage(Panel newP, Label newB) {
            _panel.Visible = false;
            _label.ForeColor = _light;

            newP.Visible = true;
            newB.ForeColor = _dark;

            _panel = newP;
            _label = newB;
        }

        private void FamilyLBL_MouseEnter(object sender, EventArgs e) {
            FamilyLBL.ForeColor = _dark;
        }

        private void WorkLBL_MouseEnter(object sender, EventArgs e) {
            WorkLBL.ForeColor = _dark;
        }

        private void PersonalLBL_MouseEnter(object sender, EventArgs e) {
            PersonalLBL.ForeColor = _dark;
        }

        private void PersonalLBL_MouseLeave(object sender, EventArgs e) {
            if (PersonalLBL != _label) PersonalLBL.ForeColor = _light;
        }

        private void FamilyLBL_MouseLeave(object sender, EventArgs e) {
            if (FamilyLBL != _label) FamilyLBL.ForeColor = _light;
        }

        private void WorkLBL_MouseLeave(object sender, EventArgs e) {
            if (WorkLBL != _label) WorkLBL.ForeColor = _light;
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
            CloseBTN.ForeColor = _dark;
        }

        #region Form Properties and Features

        private void RViewEmployees_Load(object sender, EventArgs e) {
            RefreshData();
            FadeTMR.Start();
            if (Name.Equals("Archived")) GEditDetailsBTN.Visible = false;
            _panel = PersonalPNL;
            _label = PersonalLBL;

            PersonalPNL.Visible = true;
        }

        private void RViewEmployees_FormClosing(object sender, FormClosingEventArgs e) {
            if (!Name.Equals("Archived")) Shadow.Close();
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            Close();
            if (!Name.Equals("Archived"))
                Reference.GuardsRefreshGuardsList();
        }

        private void FadeTMR_Tick(object sender, EventArgs e) {
            Opacity += 0.2;
            if (Opacity >= 1) FadeTMR.Stop();
        }

        private void GEditDetailsBTN_Click(object sender, EventArgs e) {
            var view = new GuardsEdit {
                Gid = Gid,
                Button = "UPDATE",
                ViewRef = this,
                Reference = Reference,
                Location = Location
            };
            view.ShowDialog();
        }

        #endregion

        #region Refreshing Data

        public void RefreshData() {
            try {
                if (!Name.Equals("Archived")) {
                    try {
                        _dataTable = Guard.GetGuardsBasicData(Gid);
                        GIDLBL.Text = Gid.ToString();
                        LNLBL.Text = _dataTable.Rows[0]["fn"] + " " + _dataTable.Rows[0]["mn"];
                        LLBL.Text = _dataTable.Rows[0]["ln"] + ", ";
                        StatusLBL.Text = GetStatus(_dataTable);
                        BdateLBL.Text = _dataTable.Rows[0]["Bdate"].ToString();
                        GenderLBL.Text = GetGender(_dataTable);
                        HeightLBL.Text = _dataTable.Rows[0]["Height"].ToString();
                        WeightLBL.Text = _dataTable.Rows[0]["Weight"].ToString();
                        ReligionLBL.Text = _dataTable.Rows[0]["Religion"].ToString();
                        CivilStatusLBL.Text = GetCivilStatus(_dataTable);
                        ContactNoLBL.Text = _dataTable.Rows[0]["CellNo"].ToString();
                        TelNoLBL.Text = _dataTable.Rows[0]["TelNo"].ToString();
                        LicenseNoLBL.Text = _dataTable.Rows[0]["LicenseNo"].ToString();
                        SSSLBL.Text = _dataTable.Rows[0]["SSS"].ToString();
                        TINLBL.Text = _dataTable.Rows[0]["TIN"].ToString();
                        PhilHealthLBL.Text = _dataTable.Rows[0]["PhilHealth"].ToString();
                        PrevAgencyLBL.Text = _dataTable.Rows[0]["PrevAgency"].ToString();
                        PrevAssLVL.Text = _dataTable.Rows[0]["PrevAss"].ToString();
                        EdAtLBL.Text = GetEducationalAttainment(_dataTable);
                        CourseLBL.Text = _dataTable.Rows[0]["Course"].ToString();
                        TrainLBL.Text = _dataTable.Rows[0]["MilitaryTrainings"].ToString();
                        ContactLBL.Text = _dataTable.Rows[0]["EmergencyContact"].ToString();
                        EmergencyLBL.Text = _dataTable.Rows[0]["EmergencyNo"].ToString();
                    }
                    catch (Exception ex) { Console.WriteLine(ex); }

                    try {
                        _dataTable = Guard.GetGuardsAddresses(Gid);
                        BirthplaceLBL.Text = BuildStreet(_dataTable, 0);
                        PermAddLBL.Text = BuildStreet(_dataTable, 1);
                        TempAddLBL.Text = BuildStreet(_dataTable, 2);
                    }
                    catch (Exception ex) { Console.WriteLine(ex); }
                    try {
                        _dataTable = Guard.GetGuardsParents(Gid);
                        MotherLBL.Text = BuildName(_dataTable, 1);
                        FatherLBL.Text = BuildName(_dataTable, 0);
                        try {
                            SpouseLBL.Text = BuildName(_dataTable, 2);
                        }
                        catch (Exception ex) { Console.WriteLine(ex); }
                    }
                    catch (Exception ex) { Console.WriteLine(ex); }
                    try {
                       DependentsGRD.DataSource = Guard.GetGuardsDependentsView(Gid);
                       DependentsGRD.Columns[0].Visible = false;
                        DependentsGRD.Columns[1].Width = 250;
                        DependentsGRD.Columns[2].Width = 150;

                        if (DependentsGRD.Rows.Count == 0) {
                            ErrorPNL.BringToFront();
                            ErrorPNL.Visible = true;
                        }
                        else {
                            ErrorPNL.Visible = false;
                        }

                    }
                    catch (Exception ex) { Console.WriteLine(ex); }
                }
                else {
                    try {
                        _dataTable = Archiver.GetGuardsBasicData(Gid);
                        GIDLBL.Text = Gid.ToString();
                        LNLBL.Text = _dataTable.Rows[0]["fn"] + " " + _dataTable.Rows[0]["mn"];
                        LLBL.Text = _dataTable.Rows[0]["ln"] + ", ";
                        StatusLBL.Text = "Archived";
                        BdateLBL.Text = _dataTable.Rows[0]["Bdate"].ToString();
                        GenderLBL.Text = GetGender(_dataTable);
                        HeightLBL.Text = _dataTable.Rows[0]["Height"].ToString();
                        WeightLBL.Text = _dataTable.Rows[0]["Weight"].ToString();
                        ReligionLBL.Text = _dataTable.Rows[0]["Religion"].ToString();
                        CivilStatusLBL.Text = GetCivilStatus(_dataTable);
                        ContactNoLBL.Text = _dataTable.Rows[0]["CellNo"].ToString();
                        TelNoLBL.Text = _dataTable.Rows[0]["TelNo"].ToString();
                        LicenseNoLBL.Text = _dataTable.Rows[0]["LicenseNo"].ToString();
                        SSSLBL.Text = _dataTable.Rows[0]["SSS"].ToString();
                        TINLBL.Text = _dataTable.Rows[0]["TIN"].ToString();
                        PhilHealthLBL.Text = _dataTable.Rows[0]["PhilHealth"].ToString();
                        PrevAgencyLBL.Text = _dataTable.Rows[0]["PrevAgency"].ToString();
                        PrevAssLVL.Text = _dataTable.Rows[0]["PrevAss"].ToString();
                        EdAtLBL.Text = GetEducationalAttainment(_dataTable);
                        CourseLBL.Text = _dataTable.Rows[0]["Course"].ToString();
                        TrainLBL.Text = _dataTable.Rows[0]["MilitaryTrainings"].ToString();
                        ContactLBL.Text = _dataTable.Rows[0]["EmergencyContact"].ToString();
                        EmergencyLBL.Text = _dataTable.Rows[0]["EmergencyNo"].ToString();
                    }
                    catch (Exception ex) { Console.WriteLine(ex); }

                    try {
                        _dataTable = Archiver.GetGuardsAddresses(Gid);
                        BirthplaceLBL.Text = BuildStreet(_dataTable, 0);
                        PermAddLBL.Text = BuildStreet(_dataTable, 1);
                        TempAddLBL.Text = BuildStreet(_dataTable, 2);
                    }
                    catch (Exception ex) { Console.WriteLine(ex); }
                    try {
                        _dataTable = Archiver.GetGuardsParents(Gid);
                        MotherLBL.Text = BuildName(_dataTable, 1);
                        FatherLBL.Text = BuildName(_dataTable, 0);
                        try {
                            SpouseLBL.Text = BuildName(_dataTable, 2);
                        }
                        catch (Exception ex) { Console.WriteLine(ex); }
                    }
                    catch (Exception ex) { Console.WriteLine(ex); }
                    try {
                        DependentsGRD.DataSource = Archiver.GetGuardsDependentsView(Gid);
                        DependentsGRD.Columns[0].Visible = false;
                        DependentsGRD.Columns[1].Width = 250;
                        DependentsGRD.Columns[2].Width = 150;

                        if (DependentsGRD.Rows.Count == 0) {
                            ErrorPNL.BringToFront();
                            ErrorPNL.Visible = true;
                        } else {
                            ErrorPNL.Visible = false;
                        }
                    }
                    catch (Exception ex){ Console.WriteLine(ex);}
                }
            }
            catch (Exception ex) {
                ShowErrorBox("Laoding Guards", ex.Message);
            }
        }

        private static void ShowErrorBox(string name, string error) {
            RylMessageBox.ShowDialog("Please try again.\nIf the problem still persist, please contact your administrator. \n\n\nError Message: \n=============================\n" + error + "\n=============================\n", "Error Configuring " + name,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static string GetStatus(DataTable dt) {
            switch (int.Parse(dt.Rows[0]["gstatus"].ToString())) {
                case 0: return "Inactive";
                case 1: return "Active";
                case 2: return "Pending Payroll";
                case 3: return "Pending Assignment";
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

        private static string BuildName(DataTable dt, int row) {
            return dt.Rows[row]["ln"] + ", " + dt.Rows[row]["fn"] + " " + dt.Rows[row]["mn"];
        }

        private static string BuildStreet(DataTable dt, int row) {
            return dt.Rows[row]["streetno"] + ", " + dt.Rows[row]["street"] + ", " + dt.Rows[row]["brgy"] + ", " +
                   dt.Rows[row]["city"];
        }

        #endregion
    }
}