using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSAMISUserInterface {
    public partial class Guards_Edit : Form {
        public int GID;
        public MainForm reference;
        public Guards_View viewref;
        public String button = "ADD";
        public MySqlConnection conn;
        public int[] dependents;

        MySqlCommand comm;
        MySqlDataAdapter adp = new MySqlDataAdapter();
        DataTable dt = new DataTable();
        
        private int gender;

        private Color dark = Color.FromArgb(53, 64, 82);
        private Color light = Color.DarkGray;

        private Panel PNL;
        private Label LBL;

        public Guards_Edit() {
            InitializeComponent();
            this.Opacity = 0;
        }

        #region Form Props
        private void FadeTMR_Tick(object sender, EventArgs e) {
            if (button.Equals("ADD")) {
                if (reference.Opacity > 0.7) reference.Opacity -= 0.1;
                this.Opacity += 0.2;
                if (reference.Opacity <= 0.7 && this.Opacity == 1) FadeTMR.Stop();
            } else {
                this.Opacity += 0.2;
                if (this.Opacity == 1) FadeTMR.Stop();
            }
        }
        private void CloseBTN_Click(object sender, EventArgs e) {
            DialogResult rs = rylui.RylMessageBox.ShowDialog("Cancel Chnages? \nAny unsaved changes will be lost.", "Stop Editing?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes) this.Close();
        }
        private void Guards_EditEmployees_Load(object sender, EventArgs e) {
            GEditDetailsBTN.Text = button;
            if (button.Equals("UPDATE")) {
                PopulateEdit();
                AddLBL.Text = "Edit details";
            }
            FadeTMR.Start();
            PNL = PersonalPNL;
            LBL = PersonalLBL;
            PersonalPNL.Visible = true;
            BirthdateBX.MaxDate = new DateTime(DateTime.Now.Year - 18, DateTime.Now.Month, DateTime.Now.Day);
        }
        private void Guards_EditEmployees_FormClosing(object sender, FormClosingEventArgs e) {
            if (button.Equals("ADD")) {
                Console.WriteLine("[Guard_Edit] Closing Event");
                reference.Opacity = 1;
                Console.WriteLine("[Guard_Edit] Setting Opacity to 100");
                reference.Enabled = true;
                Console.WriteLine("[Guard_Edit] Setting reference.Enable to true");
            }
        }
        #endregion

        #region Clearing of TextBoxes While Editing
        private void ClearBox(TextBox TX) {
            if (TX.Text.Equals("Last")) TX.Clear();
            else if (TX.Text.Equals("Middle")) TX.Clear();
            else if (TX.Text.Equals("First")) TX.Clear();
        }
        private void ClearAddressBox(TextBox TX) {
            if (TX.Text.Equals("No.")) TX.Clear();
            else if (TX.Text.Equals("Street Name")) TX.Clear();
            else if (TX.Text.Equals("Brgy")) TX.Clear();
            else if (TX.Text.Equals("City")) TX.Clear();
        }
        private void FirstNameBX_Enter(object sender, EventArgs e) {
            ClearBox(FirstNameBX);
        }

        private void LastNameBX_Enter(object sender, EventArgs e) {
            ClearBox(LastNameBX);
        }

        private void MiddleNameBX_TextChanged(object sender, EventArgs e) {
            ClearBox(MiddleNameBX);
        }

        private void FatherFirstBX_Enter(object sender, EventArgs e) {
            ClearBox(FatherFirstBX);
        }

        private void FatherMiddleBX_Enter(object sender, EventArgs e) {
            ClearBox(FatherMiddleBX);
        }

        private void FatherLastBX_Enter(object sender, EventArgs e) {
            ClearBox(FatherLastBX);
        }

        private void MotherFirstBX_Enter(object sender, EventArgs e) {
            ClearBox(MotherFirstBX);
        }

        private void MotherMiddleBX_Enter(object sender, EventArgs e) {
            ClearBox(MotherMiddleBX);
        }

        private void MotherLastBX_Enter(object sender, EventArgs e) {
            ClearBox(MotherLastBX);
        }

        private void MiddleNameBX_Enter(object sender, EventArgs e) {
            ClearBox(MiddleNameBX);
        }

        private void Dependent1FirstBX_Enter(object sender, EventArgs e) {
            ClearBox(Dependent1FirstBX);
        }

        private void Dependent1MiddleBX_Enter(object sender, EventArgs e) {
            ClearBox(Dependent1MiddleBX);
        }

        private void Dependent1LastBX_Enter(object sender, EventArgs e) {
            ClearBox(Dependent1LastBX);
        }

        private void Dependent2FirstBX_Enter(object sender, EventArgs e) {
            ClearBox(Dependent2FirstBX);
        }

        private void Dependent2MiddleBX_Enter(object sender, EventArgs e) {
            ClearBox(Dependent2MiddleBX);
        }

        private void Dependent2LastBX_Enter(object sender, EventArgs e) {
            ClearBox(Dependent2LastBX);
        }

        private void Dependent3FirstBX_Enter(object sender, EventArgs e) {
            ClearBox(Dependent3FirstBX);
        }

        private void Dependent3MiddleBX_Enter(object sender, EventArgs e) {
            ClearBox(Dependent3MiddleBX);
        }

        private void Dependent3LastBX_Enter(object sender, EventArgs e) {
            ClearBox(Dependent3LastBX);
        }

        private void Dependent4FirstBX_Enter(object sender, EventArgs e) {
            ClearBox(Dependent4FirstBX);
        }

        private void Dependent4MiddleBX_Enter(object sender, EventArgs e) {
            ClearBox(Dependent4MiddleBX);
        }

        private void Dependent4LastBX_Enter(object sender, EventArgs e) {
            ClearBox(Dependent4LastBX);
        }

        private void Dependent5FirstBX_Enter(object sender, EventArgs e) {
            ClearBox(Dependent5FirstBX);
        }

        private void Dependent5MiddleBX_Enter(object sender, EventArgs e) {
            ClearBox(Dependent5MiddleBX);
        }

        private void Dependent5LastBX_Enter(object sender, EventArgs e) {
            ClearBox(Dependent5LastBX);
        }

        private void BirthplaceStreetNoBX_Enter(object sender, EventArgs e) {
            ClearAddressBox(BirthplaceStreetNoBX);
        }

        private void BirthplaceBrgyBX_Enter(object sender, EventArgs e) {
            ClearAddressBox(BirthplaceBrgyBX);
        }

        private void BirthplaceCityBX_Enter(object sender, EventArgs e) {
            ClearAddressBox(BirthplaceCityBX);
        }

        private void BirthplaceStreetNameBX_Enter(object sender, EventArgs e) {
            ClearAddressBox(BirthplaceStreetNameBX);
        }

        private void PermStreetNoBX_Enter(object sender, EventArgs e) {
            ClearAddressBox(PermStreetNoBX);
        }

        private void PermStreetNameBX_Enter(object sender, EventArgs e) {
            ClearAddressBox(PermStreetNameBX);
        }

        private void PermBrgyBX_Enter(object sender, EventArgs e) {
            ClearAddressBox(PermBrgyBX);
        }

        private void PermCityBX_Enter(object sender, EventArgs e) {
            ClearAddressBox(PermCityBX);
        }

        private void TempStreetNoBX_Enter(object sender, EventArgs e) {
            ClearAddressBox(TempStreetNoBX);
        }

        private void TempStreetNameBX_Enter(object sender, EventArgs e) {
            ClearAddressBox(TempStreetNameBX);
        }

        private void TempBrgyBX_Enter(object sender, EventArgs e) {
            ClearAddressBox(TempBrgyBX);
        }

        private void TempCityBX_Enter(object sender, EventArgs e) {
            ClearAddressBox(TempCityBX);
        }

        private void SpouseFirstBX_Enter(object sender, EventArgs e) {
            ClearBox(SpouseFirstBX);
        }

        private void SpouseMiddleBX_Enter(object sender, EventArgs e) {
            ClearBox(SpouseMiddleBX);
        }

        private void SpouseLastBX_Enter(object sender, EventArgs e) {
            ClearBox(SpouseLastBX);
        }
        #endregion

        #region Other Textbox Props While Editing
        private void MaleRDBTN_CheckedChanged(object sender, EventArgs e) {
            if (MaleRDBTN.Checked) gender = 1;
        }
        private void FemaleRDBTN_CheckedChanged(object sender, EventArgs e) {
            if (FemaleRDBTN.Checked) gender = 2;
        }

        private void LastNameBX_Leave(object sender, EventArgs e) {
            TextBox lastbx = sender as TextBox;
            if (lastbx.Text == "") {
                lastbx.Text = "Last";
            }
        }
        private void FirstNameBX_Leave(object sender, EventArgs e) {
            TextBox firstbx = sender as TextBox;
            if (firstbx.Text == "") {
                firstbx.Text = "First";
            }
        }
        private void MiddleNameBX_Leave(object sender, EventArgs e) {
            TextBox middlebx = sender as TextBox;
            if (middlebx.Text == "") {
                middlebx.Text = "Middle";
            }
        }

        private void StreetNoBX_Leave(object sender, EventArgs e) {
            TextBox streetnobx = sender as TextBox;
            if (streetnobx.Text == "") {
                streetnobx.Text = "No.";
            }
        }
        private void StreetNameBX_Leave(object sender, EventArgs e) {
            TextBox streetnamebx = sender as TextBox;
            if (streetnamebx.Text == "") {
                streetnamebx.Text = "Street Name";
            }
        }

        private void BrgyBX_Leave(object sender, EventArgs e) {
            TextBox brgybx = sender as TextBox;
            if (brgybx.Text == "") {
                brgybx.Text = "Brgy";
            }
        }

        private void CityBX_Leave(object sender, EventArgs e) {
            TextBox citybx = sender as TextBox;
            if (citybx.Text == "") {
                citybx.Text = "City";
            }
        }


        //Realtime Tooltips
        private void BirthplaceStreetNoBX_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) {
                e.Handled = true;
                ToolTip.ToolTipTitle = "Street No.";
                ToolTip.Show("Can only accept numbers", BirthplaceStreetNoBX);
            }
        }
        private void PermStreetNoBX_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) {
                e.Handled = true;
                ToolTip.ToolTipTitle = "Street No.";
                ToolTip.Show("Can only accept numbers", PermStreetNoBX);
            }
        }
        private void TempStreetNoBX_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) {
                e.Handled = true;
                ToolTip.ToolTipTitle = "Street No.";
                ToolTip.Show("Can only accept numbers", TempStreetNoBX);
            }
        }
        private void EmergencyNoBX_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) {
                e.Handled = true;
                ToolTip.ToolTipTitle = "Please enter mobile/telephone no";
                ToolTip.Show("Can only accept numbers", EmergencyNoBX);
            }
        }
        private void BirthdateBX_ValueChanged(object sender, EventArgs e) {
            if (DateTime.Now.Year - BirthdateBX.Value.Year < 18) {
                ToolTip.ToolTipTitle = "Guard Birthdate";
                ToolTip.Show("Must be more than 18.", BirthdateBX);
            }
        }

        //For Resetting cursor position
        private void WeightBX_Enter(object sender, EventArgs e) {
            this.BeginInvoke((MethodInvoker)delegate () {
                WeightBX.Select(0, 0);
            });
        }
        private void HeightBX_Enter(object sender, EventArgs e) {
            this.BeginInvoke((MethodInvoker)delegate () {
                HeightBX.Select(0, 0);
            });
        }
        private void CellNoBX_Enter(object sender, EventArgs e) {
            this.BeginInvoke((MethodInvoker)delegate () {
                CellNoBX.Select(0, 0);
            });
        }
        private void TellNoBX_Enter(object sender, EventArgs e) {
            this.BeginInvoke((MethodInvoker)delegate () {
                TellNoBX.Select(0, 0);
            });
        }
        private void LicenseNoBX_Enter(object sender, EventArgs e) {
            this.BeginInvoke((MethodInvoker)delegate () {
                LicenseNoBX.Select(0, 0);
            });
        }
        private void SSSNoBX_Enter(object sender, EventArgs e) {
            this.BeginInvoke((MethodInvoker)delegate () {
                SSSNoBX.Select(0, 0);
            });
        }
        private void TINNoBX_Enter(object sender, EventArgs e) {
            this.BeginInvoke((MethodInvoker)delegate () {
                TINNoBX.Select(0, 0);
            });
        }
        private void PhilHealthBX_Enter(object sender, EventArgs e) {
            this.BeginInvoke((MethodInvoker)delegate () {
                PhilHealthBX.Select(0, 0);
            });
        }

        //For Hiding Tooltips
        private void Textbox_TextChanged(object sender, EventArgs e) {
            HideTooltip();
        }
        private void HideTooltip() {
            ToolTip.Hide(BirthplaceStreetNoBX);
            ToolTip.Hide(PermStreetNoBX);
            ToolTip.Hide(TempStreetNoBX);
            WeightWarn.Hide(WeightBX);
            EmergencyWarn.Hide(EmerLBL);
            CourseWarn.Hide(CourseBX);
            EdAtWarn.Hide(EdAtLBL);
            PhilHealthWarn.Hide(PhilHealthBX);
            TINWarn.Hide(TINNoBX);
            SSSWarn.Hide(SSSNoBX);
            LicenseWarn.Hide(LicenseNoBX);
            ContactWarn.Hide(ContactLBL);
            Dep1Warn.Hide(Dependent1FirstBX);
            Dep2Warn.Hide(Dependent2FirstBX);
            Dep3Warn.Hide(Dependent3FirstBX);
            Dep4Warn.Hide(Dependent4FirstBX);
            Dep5Warn.Hide(Dependent5FirstBX);
            ReligionWarn.Hide(ReligionBX);
            SpouseWarn.Hide(SpouseFirstBX);
            FatherWarn.Hide(FatherFirstBX);
            MotherWarn.Hide(MotherFirstBX);
            PermAdWarn.Hide(PermStreetNoBX);
            TempAddWarn.Hide(TempStreetNoBX);
            BirthPlaceWarn.Hide(BirthplaceStreetNoBX);
            CVWarn.Hide(CVLBL);
            HeightWarn.Hide(HeightBX);
            GenderWarn.Hide(GenderLBL);
            BirthWarn.Hide(BdayLBL);
            FirstNameWarn.Hide(FirstNameBX);
            MiddleNameWarn.Hide(MiddleNameBX);
            LastNameWarn.Hide(LastNameBX);
        }
        #endregion

        #region Populate Form (for Updating)
        private void PopulateEdit() {
            try {
                GetResultQuery("SELECT * FROM guards WHERE GID = " + GID);
                LastNameBX.Text = dt.Rows[0]["ln"].ToString();
                FirstNameBX.Text = dt.Rows[0]["fn"].ToString();
                MiddleNameBX.Text = dt.Rows[0]["mn"].ToString();
                if (dt.Rows[0]["gstatus"].ToString().Equals("1")) StatusLBL.Text = "Status: Active";
                else StatusLBL.Text = "Status: Inactive";
                String[] date = dt.Rows[0]["Bdate"].ToString().Split('/');
                BirthdateBX.Value = new DateTime(int.Parse(date[2]), int.Parse(date[0]), int.Parse(date[1]));
                if (dt.Rows[0]["gender"].ToString().Equals("1")) MaleRDBTN.Checked = true;
                else FemaleRDBTN.Checked = true;
                HeightBX.Text = dt.Rows[0]["Height"].ToString();
                WeightBX.Text = dt.Rows[0]["Weight"].ToString();
                ReligionBX.Text = dt.Rows[0]["Religion"].ToString();
                CVStatusBX.SelectedIndex = int.Parse(dt.Rows[0]["CivilStatus"].ToString());
                CellNoBX.Text = dt.Rows[0]["CellNo"].ToString();
                TellNoBX.Text = dt.Rows[0]["TelNo"].ToString();
                LicenseNoBX.Text = dt.Rows[0]["LicenseNo"].ToString();
                SSSNoBX.Text = dt.Rows[0]["SSS"].ToString();
                TINNoBX.Text = dt.Rows[0]["TIN"].ToString();
                PhilHealthBX.Text = dt.Rows[0]["PhilHealth"].ToString();
                PrevAgencyBX.Text = dt.Rows[0]["PrevAgency"].ToString();
                PrevAssBX.Text = dt.Rows[0]["PrevAss"].ToString();
                EdAttBX.SelectedIndex = int.Parse(dt.Rows[0]["EdAtt"].ToString());
                CourseBX.Text = dt.Rows[0]["Course"].ToString();
                MilTrainBX.Text = dt.Rows[0]["MilitaryTrainings"].ToString();
                EmergBX.Text = dt.Rows[0]["EmergencyContact"].ToString();
                EmergencyNoBX.Text = dt.Rows[0]["EmergencyNo"].ToString();
            }
            catch (Exception ee) {
            }
            try {
                GetResultQuery("SELECT * FROM address WHERE GID=" + GID + " ORDER BY Atype ASC");
                BirthplaceStreetNoBX.Text = dt.Rows[0]["streetno"].ToString();
                BirthplaceStreetNameBX.Text = dt.Rows[0]["street"].ToString();
                BirthplaceBrgyBX.Text = dt.Rows[0]["brgy"].ToString();
                BirthplaceCityBX.Text = dt.Rows[0]["city"].ToString();

                PermStreetNoBX.Text = dt.Rows[1]["streetno"].ToString();
                PermStreetNameBX.Text = dt.Rows[1]["street"].ToString();
                PermBrgyBX.Text = dt.Rows[1]["brgy"].ToString();
                PermCityBX.Text = dt.Rows[1]["city"].ToString();

                TempStreetNoBX.Text = dt.Rows[2]["streetno"].ToString();
                TempStreetNameBX.Text = dt.Rows[2]["street"].ToString();
                TempBrgyBX.Text = dt.Rows[2]["brgy"].ToString();
                TempCityBX.Text = dt.Rows[2]["city"].ToString();

                conn.Close();
            }
            catch (Exception ee) {
            }
            try {
                GetResultQuery("SELECT * FROM dependents WHERE GID=" + GID + " AND (DRelationship = '4' OR DRelationship = '5' OR DRelationship = '6') ORDER BY DRelationship ASC");
                try {
                    MotherFirstBX.Text = dt.Rows[1]["fn"].ToString();
                    MotherMiddleBX.Text = dt.Rows[1]["mn"].ToString();
                    MotherLastBX.Text = dt.Rows[1]["ln"].ToString();
                    FatherFirstBX.Text = dt.Rows[0]["fn"].ToString();
                    FatherMiddleBX.Text = dt.Rows[0]["mn"].ToString();
                    FatherLastBX.Text = dt.Rows[0]["ln"].ToString();
                    SpouseFirstBX.Text = dt.Rows[2]["fn"].ToString();
                    SpouseMiddleBX.Text = dt.Rows[2]["mn"].ToString();
                    SpouseLastBX.Text = dt.Rows[2]["ln"].ToString();
                }
                catch { }
                conn.Close();
            }
            catch (Exception ee) {
                conn.Close();
                MessageBox.Show(ee.Message);
            }
            try {
                GetResultQuery("SELECT * FROM dependents WHERE GID=" + GID + " AND (DRelationship = '1' OR DRelationship = '2' OR DRelationship = '3') ORDER BY DeID ASC");
                try {
                    Dependent1FirstBX.Text = dt.Rows[0]["fn"].ToString();
                    Dependent1MiddleBX.Text = dt.Rows[0]["mn"].ToString();
                    Dependent1LastBX.Text = dt.Rows[0]["ln"].ToString();
                    Dependent1RBX.SelectedIndex = int.Parse(dt.Rows[0]["DRelationship"].ToString());

                    Dependent2FirstBX.Text = dt.Rows[1]["fn"].ToString();
                    Dependent2MiddleBX.Text = dt.Rows[1]["mn"].ToString();
                    Dependent2LastBX.Text = dt.Rows[1]["ln"].ToString();
                    Dependent2RBX.SelectedIndex = int.Parse(dt.Rows[1]["DRelationship"].ToString());

                    Dependent3FirstBX.Text = dt.Rows[2]["fn"].ToString();
                    Dependent3MiddleBX.Text = dt.Rows[2]["mn"].ToString();
                    Dependent3LastBX.Text = dt.Rows[2]["ln"].ToString();
                    Dependent3RBX.SelectedIndex = int.Parse(dt.Rows[2]["DRelationship"].ToString());

                    Dependent4FirstBX.Text = dt.Rows[3]["fn"].ToString();
                    Dependent4MiddleBX.Text = dt.Rows[3]["mn"].ToString();
                    Dependent4LastBX.Text = dt.Rows[3]["ln"].ToString();
                    Dependent4RBX.SelectedIndex = int.Parse(dt.Rows[3]["DRelationship"].ToString());

                    Dependent5FirstBX.Text = dt.Rows[4]["fn"].ToString();
                    Dependent5MiddleBX.Text = dt.Rows[4]["mn"].ToString();
                    Dependent5LastBX.Text = dt.Rows[4]["ln"].ToString();
                    Dependent5RBX.SelectedIndex = int.Parse(dt.Rows[4]["DRelationship"].ToString());
                }
                catch { }
                conn.Close();
            }
            catch (Exception ee) {
                conn.Close();
                MessageBox.Show(ee.Message);
            }
        }
        private void GetResultQuery(String query) {
            conn.Open();
            comm = new MySqlCommand(query, conn);
            adp = new MySqlDataAdapter(comm);
            dt = new DataTable();
            adp.Fill(dt);
            conn.Close();
        }
        #endregion

        #region Adding and Editing
        private void GEditDetailsBTN_Click(object sender, EventArgs e) {
            if (CheckInput())  {
                #region Adding
                if (GEditDetailsBTN.Text.Equals("ADD")) {
                    try {
                        conn.Open();
                        comm = new MySqlCommand("INSERT INTO Guards(FN, MN, LN, GStatus, BDate, Gender, Height, Weight, Religion, CivilStatus, CellNo, TelNo, LicenseNo, SSS, TIN, PhilHealth, PrevAgency, PrevAss, EdAtt, Course, MilitaryTrainings, EmergencyContact, EmergencyNo) VALUES ('" + FirstNameBX.Text + "','" + MiddleNameBX.Text + "','" + LastNameBX.Text + "','" + 0 + "','" + BirthdateBX.Value.Month + "/" + BirthdateBX.Value.Day + "/" + BirthdateBX.Value.Year + "','" + gender + "','" + HeightBX.Text + "','" + WeightBX.Text + "','" + ReligionBX.Text + "','" + CVStatusBX.SelectedIndex + "','" + CellNoBX.Text + "','" + TellNoBX.Text + "','" + LicenseNoBX.Text + "','" + SSSNoBX.Text + "','" + TINNoBX.Text + "','" + PhilHealthBX.Text + "','" + PrevAgencyBX.Text + "','" + PrevAssBX.Text + "','" + EdAttBX.SelectedIndex + "','" + CourseBX.Text + "','" + MilTrainBX.Text + "','" + EmergBX.Text + "','" + EmergencyNoBX.Text + "')", conn);
                        comm.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch (Exception ee) {
                        conn.Close();
                        rylui.RylMessageBox.ShowDialog(ee.Message);
                    }
                    try {
                        GetResultQuery("SELECT gid FROM guards ORDER BY gid DESC");
                        GID = int.Parse(dt.Rows[0][0].ToString());
                    }
                    catch (Exception ee) {
                        conn.Close();
                        rylui.RylMessageBox.ShowDialog(ee.Message);
                    }
                    try {
                        conn.Open();
                        InsertAdd(1, BirthplaceStreetNoBX.Text, BirthplaceStreetNameBX.Text, BirthplaceCityBX.Text, BirthplaceBrgyBX.Text);
                        InsertAdd(2, PermStreetNoBX.Text, PermStreetNameBX.Text, PermCityBX.Text, PermBrgyBX.Text);
                        InsertAdd(3, TempStreetNoBX.Text, TempStreetNameBX.Text, TempCityBX.Text, TempBrgyBX.Text);
                        conn.Close();
                    }
                    catch (Exception ee) {
                        conn.Close();
                        rylui.RylMessageBox.ShowDialog(ee.Message);

                    }
                    try {
                        conn.Open();
                        InsertDependent(4, FatherFirstBX.Text, FatherMiddleBX.Text, FatherLastBX.Text);
                        InsertDependent(5, MotherFirstBX.Text, MotherMiddleBX.Text, MotherLastBX.Text);
                        if (!CheckName(SpouseFirstBX, SpouseMiddleBX, SpouseLastBX)) {
                            InsertDependent(6, SpouseFirstBX.Text, SpouseMiddleBX.Text, SpouseLastBX.Text);
                        }
                        if (!CheckName(Dependent1FirstBX, Dependent1MiddleBX, Dependent1LastBX)) {
                            InsertDependent(Dependent1RBX.SelectedIndex, Dependent1FirstBX.Text, Dependent1MiddleBX.Text, Dependent1LastBX.Text);
                        }
                        if (!CheckName(Dependent2FirstBX, Dependent2MiddleBX, Dependent2LastBX)) {
                            InsertDependent(Dependent2RBX.SelectedIndex, Dependent2FirstBX.Text, Dependent2MiddleBX.Text, Dependent2LastBX.Text);
                        }
                        if (!CheckName(Dependent3FirstBX, Dependent3MiddleBX, Dependent3LastBX)) {
                            InsertDependent(Dependent3RBX.SelectedIndex, Dependent3FirstBX.Text, Dependent3MiddleBX.Text, Dependent3LastBX.Text);
                        }
                        if (!CheckName(Dependent4FirstBX, Dependent4MiddleBX, Dependent4LastBX)) {
                            InsertDependent(Dependent4RBX.SelectedIndex, Dependent4FirstBX.Text, Dependent4MiddleBX.Text, Dependent4LastBX.Text);
                        }
                        if (!CheckName(Dependent5FirstBX, Dependent5MiddleBX, Dependent5LastBX)) {
                            InsertDependent(Dependent5RBX.SelectedIndex, Dependent5FirstBX.Text, Dependent5MiddleBX.Text, Dependent5LastBX.Text);
                        }
                        conn.Close();
                    }
                    catch (Exception ee) {
                        conn.Close();
                        rylui.RylMessageBox.ShowDialog(ee.Message);
                    }
                }
                #endregion

                #region Updating
                else if (GEditDetailsBTN.Text.Equals("UPDATE")) {
                    try {
                        conn.Open();
                        MySqlCommand comm = new MySqlCommand("UPDATE Guards SET FN = '" + FirstNameBX.Text + "', MN = '" + MiddleNameBX.Text + "', LN = '" + LastNameBX.Text + "', BDate = '" + BirthdateBX.Value.Month + "/" + BirthdateBX.Value.Day + "/" + BirthdateBX.Value.Year + "', Gender =  '" + gender + "', Height = '" + HeightBX.Text + "', Weight = '" + WeightBX.Text + "', Religion = '" + ReligionBX.Text + "', CivilStatus = '" + CVStatusBX.SelectedIndex + "', CellNo = '" + CellNoBX.Text + "', TelNo = '" + TellNoBX.Text + "', LicenseNo = '" + LicenseNoBX.Text + "', SSS = '" + SSSNoBX.Text + "', TIN = '" + TINNoBX.Text + "', PhilHealth = '" + PhilHealthBX.Text + "', PrevAgency = '" + PrevAgencyBX.Text + "', PrevAss = '" + PrevAssBX.Text + "', EdAtt = '" + EdAttBX.SelectedIndex + "', Course = '" + CourseBX.Text + "', MilitaryTrainings = '" + MilTrainBX.Text + "', EmergencyContact = '" + EmergBX.Text + "', EmergencyNo = '" + EmergencyNoBX.Text + "' WHERE GID=" + GID, conn);
                        comm.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch (Exception ee) {
                        conn.Close();
                        rylui.RylMessageBox.ShowDialog(ee.Message);
                    }
                    try {
                        conn.Open();
                        UpdateAdd(BirthplaceStreetNoBX.Text, BirthplaceStreetNameBX.Text, BirthplaceCityBX.Text, BirthplaceBrgyBX.Text, 1);
                        UpdateAdd(PermStreetNoBX.Text, PermStreetNameBX.Text, PermCityBX.Text, PermBrgyBX.Text, 2);
                        UpdateAdd(TempStreetNoBX.Text, TempStreetNameBX.Text, TempCityBX.Text, TempBrgyBX.Text, 3);
                        conn.Close();
                    }
                    catch (Exception ee) {
                        conn.Close();
                        rylui.RylMessageBox.ShowDialog(ee.Message);
                    }
                    try {
                        conn.Open();
                        UpdateDependent(FatherFirstBX.Text, FatherMiddleBX.Text, FatherLastBX.Text, 4);
                        UpdateDependent(MotherFirstBX.Text, MotherMiddleBX.Text, MotherLastBX.Text, 5);
                        if (!CheckName(SpouseFirstBX, SpouseMiddleBX, SpouseLastBX)) UpdateDependent(SpouseFirstBX.Text, SpouseMiddleBX.Text, SpouseLastBX.Text, 6);
                        if (CheckName(Dependent1FirstBX, Dependent1MiddleBX, Dependent1LastBX)) {
                            if (dependents.Length > 0) UpdateDependent(Dependent1FirstBX.Text, Dependent1MiddleBX.Text, Dependent1LastBX.Text, Dependent1RBX.SelectedIndex, dependents[0]);
                            else InsertDependent(Dependent1RBX.SelectedIndex, Dependent1FirstBX.Text, Dependent1MiddleBX.Text, Dependent1LastBX.Text);
                        }
                        if (!CheckName(Dependent2FirstBX, Dependent2MiddleBX, Dependent2LastBX)) {
                            if (dependents.Length > 1) UpdateDependent(Dependent2FirstBX.Text, Dependent2MiddleBX.Text, Dependent2LastBX.Text, Dependent2RBX.SelectedIndex, dependents[1]);
                            else InsertDependent(Dependent2RBX.SelectedIndex, Dependent2FirstBX.Text, Dependent2MiddleBX.Text, Dependent2LastBX.Text);
                        }
                        if (!CheckName(Dependent3FirstBX, Dependent3MiddleBX, Dependent3LastBX)) {
                            if (dependents.Length > 2) UpdateDependent(Dependent3FirstBX.Text, Dependent3MiddleBX.Text, Dependent3LastBX.Text, Dependent3RBX.SelectedIndex, dependents[2]);
                            else InsertDependent(Dependent3RBX.SelectedIndex, Dependent3FirstBX.Text, Dependent3MiddleBX.Text, Dependent3LastBX.Text);
                        }
                        if (!CheckName(Dependent4FirstBX, Dependent4MiddleBX, Dependent4LastBX)) {
                            if (dependents.Length > 3) UpdateDependent(Dependent4FirstBX.Text, Dependent4MiddleBX.Text, Dependent4LastBX.Text, Dependent4RBX.SelectedIndex, dependents[3]);
                            else InsertDependent(Dependent4RBX.SelectedIndex, Dependent4FirstBX.Text, Dependent4MiddleBX.Text, Dependent4LastBX.Text);
                        }
                        if (!CheckName(Dependent5FirstBX, Dependent5MiddleBX, Dependent5LastBX)){
                            if (dependents.Length > 4) UpdateDependent(Dependent5FirstBX.Text, Dependent5MiddleBX.Text, Dependent5LastBX.Text, Dependent5RBX.SelectedIndex, dependents[5]);
                            else InsertDependent(Dependent5RBX.SelectedIndex, Dependent5FirstBX.Text, Dependent5MiddleBX.Text, Dependent5LastBX.Text);
                        }                       
                        conn.Close();
                        viewref.RefreshData();
                    }
                    catch (Exception ee) {
                        conn.Close();
                        MessageBox.Show(ee.Message);
                    } 
                }
                #endregion
                reference.GUARDSRefreshGuardsList();
                this.Close();
            }
        }
        private void InsertDependent(int Rel, String First, String Middle, String Last) {
            comm = new MySqlCommand("INSERT INTO Dependents(DRelationship, GID, FN, MN, LN) VALUES ('" + Rel + "','" + GID + "','" + First + "','" + Middle + "','" + Last + "')", conn);
            comm.ExecuteNonQuery();
        }
        private void InsertAdd(int type, String StreetNo, String Street, String City, String Brgy) {
            comm = new MySqlCommand("INSERT INTO Address(GID, AType, StreetNo, Street, City, Brgy) VALUES ('" + GID + "','" + type + "','" + StreetNo + "','" + Street + "','" + City + "','" + Brgy + "')", conn);
            comm.ExecuteNonQuery();
        }

        private void UpdateAdd(String StreetNo, String Street, String City, String Brgy, int type) {
            comm = new MySqlCommand("UPDATE Address SET StreetNo = '" + StreetNo + "', Street = '" + Street + "', City = '" + City + "', Brgy = '" + Brgy + "' WHERE Atype = '" + type + "' AND GID=" + GID, conn);
            comm.ExecuteNonQuery();
        }

        private void UpdateDependent(String First, String Middle, String Last, int Rel) {
            comm = new MySqlCommand("UPDATE Dependents SET FN = '" + First + "', MN = '" + Middle + "', LN = '" + Last + "' WHERE DRelationship = '" + Rel + "' AND GID=" + GID, conn);
            comm.ExecuteNonQuery();
        }
        private void UpdateDependent(String First, String Middle, String Last, int Rel, int ID) {
            comm = new MySqlCommand("UPDATE Dependents SET FN = '" + First + "', MN = '" + Middle + "', LN = '" + Last + "', DRelationship = '" + Rel + "' WHERE GID=" + GID + " AND DeID = " + ID, conn);
            comm.ExecuteNonQuery();
        }
        #endregion

        #region DataValidation
        private bool CheckInput() {
            bool check = true;

            if (CheckName(LastNameBX, "Last")) {
                ScrollDetailsPanelTo(0);
                ShowToolTipOnBX(LastNameWarn, "Last Name", "Please enter last name", LastNameBX);
                check = false;
            }
            if (CheckName(MiddleNameBX, "Middle")) {
                ScrollDetailsPanelTo(0);
                ShowToolTipOnBX(MiddleNameWarn, "Middle Name", "Please enter middle name", MiddleNameBX);
                check = false;
            }
            if (CheckName(FirstNameBX, "First")) {
                ScrollDetailsPanelTo(0);
                ShowToolTipOnBX(FirstNameWarn, "First Name", "Please enter first name", FirstNameBX);
                check = false;
            }
            if (DateTime.Now.Year - BirthdateBX.Value.Year < 18) {
                ScrollDetailsPanelTo(0);
                ShowToolTipOnLBL(BirthWarn, "Birthdate", "Must be more than 18", BdayLBL);
                check = false;
            }
            if (!MaleRDBTN.Checked && !FemaleRDBTN.Checked) {
                ScrollDetailsPanelTo(0);
                ShowToolTipOnLBL(GenderWarn, "Gender", "Please specify gender", GenderLBL);
                check = false;
            }
            if (HeightBX.Text.Equals("    .")) {
                ScrollDetailsPanelTo(0);
                ShowToolTipOnMBX(HeightWarn, "Height", "Please specify height", HeightBX);
                check = false;
            }
            if (WeightBX.Text.Equals("    kg.")) {
                ScrollDetailsPanelTo(0);
                ShowToolTipOnMBX(WeightWarn, "Weight", "Please specify weight", WeightBX);
                check = false;
            }
            if (CVStatusBX.SelectedIndex == 0 || CVStatusBX.Text.Equals("")) {
                ScrollDetailsPanelTo(0);
                ShowToolTipOnLBL(CVWarn, "Civil Status", "Please specify civil status", CVLBL);
                check = false;
            }
            if (CheckAdd(BirthplaceBrgyBX, BirthplaceCityBX, BirthplaceStreetNameBX, BirthplaceStreetNoBX)) {
                ScrollDetailsPanelTo(0);
                ShowToolTipOnBX(BirthPlaceWarn, "Birthplace", "Please specify or complete the fields", BirthplaceStreetNoBX);
                check = false;
            }
            if (CheckAdd(TempBrgyBX, TempCityBX, TempStreetNameBX, TempStreetNoBX)) {
                ScrollDetailsPanelTo(0);
                ShowToolTipOnBX(TempAddWarn, "Temporary Address", "Please specify or complete the fields", TempStreetNoBX);
                check = false;
            }
            if (CheckAdd(PermBrgyBX, PermCityBX, PermStreetNameBX, PermStreetNoBX)) {
                ScrollDetailsPanelTo(0);
                ShowToolTipOnBX(PermAdWarn, "Permanent Address", "Please specify or complete the fields", PermStreetNoBX);
                check = false;
            }
            if (ReligionBX.Text.Equals("")) {
                ScrollDetailsPanelTo(0);
                ShowToolTipOnBX(ReligionWarn,"Religion", "Please specify religion", ReligionBX);
                check = false;
            }
            if (CellNoBX.Text.Equals("+63             .") && TellNoBX.Text.Equals("   -    .")) {
                ScrollDetailsPanelTo(580);
                ShowToolTipOnLBL(ContactWarn, "Contact Details", "Please specify at least one contact information", ContactLBL);
                check = false;
            }
            if (EmergBX.Text.Equals("") || EmergencyNoBX.Text.Equals("")) {
                ScrollDetailsPanelTo(800);
                ShowToolTipOnLBL(EmergencyWarn, "Emergency Contact Information", "Please complete the fields", EmerLBL);
                check = false;
            }
            if (check) {
                ChangePage(FamilyPNL, FamilyLBL);
                if (CheckName(MotherFirstBX, MotherMiddleBX, MotherLastBX)) {
                    ScrollDetailsPanelTo(0);
                    ShowToolTipOnBX(MotherWarn, "Mother's Name", "Please specify or complete the fields", MotherFirstBX);
                    check = false;
                }
                if (CheckName(FatherFirstBX, FatherMiddleBX, FatherLastBX)) {
                    ScrollDetailsPanelTo(0);
                    ShowToolTipOnBX(FatherWarn, "Father's Name", "Please specify or complete the fields", FatherFirstBX);
                    check = false;
                }
                if (CheckNameNotRequired(SpouseFirstBX, SpouseMiddleBX, SpouseLastBX) && CVStatusBX.SelectedIndex > 0) {
                    ScrollDetailsPanelTo(0);
                    ShowToolTipOnBX(SpouseWarn, "Spouse's Name", "Please specify or complete the fields", SpouseFirstBX);
                    check = false;
                }
                if (CheckNameNotRequired(Dependent1FirstBX, Dependent1MiddleBX, Dependent1LastBX, Dependent1RBX)) {
                    ScrollDetailsPanelTo(350);
                    ShowToolTipOnBX(Dep1Warn, "Dependent's Name", "Please complete the fields", Dependent1FirstBX);
                    check = false;
                }
                if (CheckNameNotRequired(Dependent2FirstBX, Dependent2MiddleBX, Dependent2LastBX, Dependent2RBX)) {
                    ScrollDetailsPanelTo(350);
                    ShowToolTipOnBX(Dep2Warn, "Dependent's Name", "Please complete the fields", Dependent2FirstBX);
                    check = false;
                }
                if (CheckNameNotRequired(Dependent3FirstBX, Dependent3MiddleBX, Dependent3LastBX, Dependent3RBX)) {
                    ScrollDetailsPanelTo(350);
                    ShowToolTipOnBX(Dep3Warn, "Dependent's Name", "Please complete the fields", Dependent3FirstBX);
                    check = false;
                }
                if (CheckNameNotRequired(Dependent4FirstBX, Dependent4MiddleBX, Dependent4LastBX, Dependent4RBX)) {
                    ScrollDetailsPanelTo(350);
                    ShowToolTipOnBX(Dep4Warn, "Dependent's Name", "Please complete the fields", Dependent4FirstBX);
                    check = false;
                }
                if (CheckNameNotRequired(Dependent5FirstBX, Dependent5MiddleBX, Dependent5LastBX, Dependent5RBX)) {
                    ScrollDetailsPanelTo(350);
                    ShowToolTipOnBX(Dep5Warn, "Dependent's Name", "Please complete the fields", Dependent5FirstBX);
                    check = false;
                }
                if (check) {
                    if (check) {
                        ChangePage(WorkPNL, WorkLBL);
                        if (LicenseNoBX.Text.Equals("           .")) {
                            ScrollDetailsPanelTo(800);
                            ShowToolTipOnMBX(LicenseWarn, "License Details", "Please specify license number", LicenseNoBX);
                            check = false;
                        }
                        if (SSSNoBX.Text.Equals("           .")) {
                            ScrollDetailsPanelTo(800);
                            ShowToolTipOnMBX(SSSWarn, "SSS Details", "Please specify SSS number", SSSNoBX);
                            check = false;
                        }
                        if (TINNoBX.Text.Equals("           .")) {
                            ScrollDetailsPanelTo(800);
                            ShowToolTipOnMBX(TINWarn, "TIN Details", "Please specify TIN number", TINNoBX);
                            check = false;
                        }
                        if (PhilHealthBX.Text.Equals("  -         - .")) {
                            ScrollDetailsPanelTo(800);
                            ShowToolTipOnMBX(PhilHealthWarn, "Insurance Details", "Please specify PhilHealth number", PhilHealthBX);
                            check = false;
                        }
                        if (EdAttBX.Text.Equals("")) {
                            ScrollDetailsPanelTo(800);
                            ShowToolTipOnLBL(EdAtWarn, "Highest Educational Attainment", "Please specify highest educational attainment", EdAtLBL);
                            check = false;
                        }
                        if (CourseBX.Text.Equals("") && EdAttBX.SelectedIndex == 4) {
                            ScrollDetailsPanelTo(800);
                            ShowToolTipOnBX(CourseWarn, "Course Details", "Please specify the course in college", CourseBX);
                            check = false;
                        }
                    }
                }
            }
            return check;
        }

        private void ScrollDetailsPanelTo(int y) {
            PersonalPNL.AutoScrollPosition = new Point(PersonalPNL.AutoScrollPosition.X, y);
        }

        private void ShowToolTipOnLBL(ToolTip ttp, String title, String message, Label lb) {
            ttp.ToolTipTitle = title;
            ttp.Show(message, lb);
        }

        private void ShowToolTipOnBX(ToolTip ttp, String title, String message, TextBox lb) {
            ttp.ToolTipTitle = title;
            ttp.Show(message, lb);
        }

        private void ShowToolTipOnMBX(ToolTip ttp, String title, String message, MaskedTextBox lb) {
            ttp.ToolTipTitle = title;
            ttp.Show(message, lb);
        }

        private bool CheckName(TextBox tb, String arg1) {
            return (tb.Text.Equals(arg1) || LastNameBX.Text.Equals(""));
        }
        private bool CheckAdd(TextBox BrgyBX, TextBox CityBX, TextBox StreetNameBX, TextBox StreetNoBX) {
            return (BrgyBX.Text.Equals("Brgy") || CityBX.Text.Equals("City") || StreetNameBX.Text.Equals("Street Name") || StreetNoBX.Text.Equals("No.") ||
                BrgyBX.Text.Equals("") || CityBX.Text.Equals("") || StreetNameBX.Text.Equals("") || StreetNoBX.Text.Equals(""));
        }

        private bool CheckName(TextBox FirstBX, TextBox MiddleBX, TextBox LastBX) {
            return (FirstBX.Text.Equals("First") || MiddleBX.Text.Equals("Middle") || LastBX.Text.Equals("Last") ||
                FirstBX.Text.Equals("") || MiddleBX.Text.Equals("") || LastBX.Text.Equals(""));
        }

        private bool CheckNameNotRequired(TextBox FirstBX, TextBox MiddleBX, TextBox LastBX, ComboBox RBX) {
            return (CheckNameNotRequired(FirstBX, MiddleBX, LastBX) && CheckForInput(FirstBX, MiddleBX, LastBX, RBX));
        }

        private bool CheckNameNotRequired(TextBox FirstBX, TextBox MiddleBX, TextBox LastBX) {
            return (CheckForInput(FirstBX, MiddleBX, LastBX) && CheckName(FirstBX, MiddleBX, LastBX));
        }

        private bool CheckForInput(TextBox FirstBX, TextBox MiddleBX, TextBox LastBX) {
            return (!(FirstBX.Text.Equals("First") || FirstBX.Text.Equals("")) || !(MiddleBX.Text.Equals("Middle") || MiddleBX.Text.Equals("")) ||
               !(LastBX.Text.Equals("Last") || LastBX.Text.Equals("")));
        }

        private bool CheckForInput(TextBox FirstBX, TextBox MiddleBX, TextBox LastBX, ComboBox RBX) {
            return (!(FirstBX.Text.Equals("First") || FirstBX.Text.Equals("")) || !(MiddleBX.Text.Equals("Middle") || MiddleBX.Text.Equals("")) ||
               !(LastBX.Text.Equals("Last") || LastBX.Text.Equals("")) || RBX.SelectedIndex>0);
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

        private void FamilyLBL_MouseLeave(object sender, EventArgs e) {
            if (LBL != FamilyLBL) FamilyLBL.ForeColor = light;
        }

        private void WorkLBL_MouseLeave(object sender, EventArgs e) {
            if (LBL != WorkLBL) WorkLBL.ForeColor = light;
        }


        private void PersonalLBL_MouseLeave(object sender, EventArgs e) {
            if (LBL != PersonalLBL) PersonalLBL.ForeColor = light;
        }
        
        private void PersonalLBL_Click(object sender, EventArgs e) {
            ChangePage(PersonalPNL, PersonalLBL);
        }

        private void FamilyLBL_Click(object sender, EventArgs e) {
            ChangePage(FamilyPNL, FamilyLBL);
        }

        private void WorkLBL_Click(object sender, EventArgs e) {
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
