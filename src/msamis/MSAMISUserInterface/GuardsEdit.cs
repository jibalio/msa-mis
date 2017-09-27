using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using rylui;

namespace MSAMISUserInterface {
    public partial class GuardsEdit : Form {
        private readonly Color _dark = Color.FromArgb(53, 64, 82);
        private readonly Color _light = Color.DarkGray;

        private DataTable _dataTable = new DataTable();

        private int _gender;
        private Label _label;
        private int _guardType = 0;

        private Panel _panel;
        public string Button = "ADD";
        public int Gid;

        public Shadow Refer;
        public MainForm Reference;
        public GuardsView ViewRef;

        public GuardsEdit() {
            InitializeComponent();
            Opacity = 0;
        }

        #region Populate Form (for Updating)

        private void PopulateEdit() {
            try {
                _dataTable = Guard.GetGuardsBasicData(Gid);
                LastNameBX.Text = _dataTable.Rows[0]["ln"].ToString();
                FirstNameBX.Text = _dataTable.Rows[0]["fn"].ToString();
                MiddleNameBX.Text = _dataTable.Rows[0]["mn"].ToString();

                StatusLBL.Text = _dataTable.Rows[0]["gstatus"].ToString().Equals("1")
                    ? "Status: Active"
                    : "Status: Inactive";

                var date = _dataTable.Rows[0]["Bdate"].ToString().Split('/');
                BirthdateBX.Value = new DateTime(int.Parse(date[2]), int.Parse(date[0]), int.Parse(date[1]));
                if (_dataTable.Rows[0]["gender"].ToString().Equals("1")) MaleRDBTN.Checked = true;
                else FemaleRDBTN.Checked = true;
                HeightBX.Text = _dataTable.Rows[0]["Height"].ToString();
                WeightBX.Text = _dataTable.Rows[0]["Weight"].ToString();
                ReligionBX.Text = _dataTable.Rows[0]["Religion"].ToString();
                CVStatusBX.SelectedIndex = int.Parse(_dataTable.Rows[0]["CivilStatus"].ToString());
                CellNoBX.Text = _dataTable.Rows[0]["CellNo"].ToString();
                TellNoBX.Text = _dataTable.Rows[0]["TelNo"].ToString();
                LicenseNoBX.Text = _dataTable.Rows[0]["LicenseNo"].ToString();
                SSSNoBX.Text = _dataTable.Rows[0]["SSS"].ToString();
                TINNoBX.Text = _dataTable.Rows[0]["TIN"].ToString();
                PhilHealthBX.Text = _dataTable.Rows[0]["PhilHealth"].ToString();
                PrevAgencyBX.Text = _dataTable.Rows[0]["PrevAgency"].ToString();
                PrevAssBX.Text = _dataTable.Rows[0]["PrevAss"].ToString();
                EdAttBX.SelectedIndex = int.Parse(_dataTable.Rows[0]["EdAtt"].ToString());
                CourseBX.Text = _dataTable.Rows[0]["Course"].ToString();
                MilTrainBX.Text = _dataTable.Rows[0]["MilitaryTrainings"].ToString();
                EmergBX.Text = _dataTable.Rows[0]["EmergencyContact"].ToString();
                EmergencyNoBX.Text = _dataTable.Rows[0]["EmergencyNo"].ToString();
            }
            catch (Exception ex) {
                ShowErrorBox("Loading Guards", ex.Message);
            }
            try {
                _dataTable = Guard.GetGuardsAddresses(Gid);
                BirthplaceStreetNoBX.Text = _dataTable.Rows[0]["streetno"].ToString();
                BirthplaceStreetNameBX.Text = _dataTable.Rows[0]["street"].ToString();
                BirthplaceBrgyBX.Text = _dataTable.Rows[0]["brgy"].ToString();
                BirthplaceCityBX.Text = _dataTable.Rows[0]["city"].ToString();

                PermStreetNoBX.Text = _dataTable.Rows[1]["streetno"].ToString();
                PermStreetNameBX.Text = _dataTable.Rows[1]["street"].ToString();
                PermBrgyBX.Text = _dataTable.Rows[1]["brgy"].ToString();
                PermCityBX.Text = _dataTable.Rows[1]["city"].ToString();

                TempStreetNoBX.Text = _dataTable.Rows[2]["streetno"].ToString();
                TempStreetNameBX.Text = _dataTable.Rows[2]["street"].ToString();
                TempBrgyBX.Text = _dataTable.Rows[2]["brgy"].ToString();
                TempCityBX.Text = _dataTable.Rows[2]["city"].ToString();
            }
            catch (Exception ex) {
                ShowErrorBox("Loading Guards", ex.Message);
            }
            try {
                _dataTable = Guard.GetGuardsParents(Gid);
                try {
                    MotherFirstBX.Text = _dataTable.Rows[1]["fn"].ToString();
                    MotherMiddleBX.Text = _dataTable.Rows[1]["mn"].ToString();
                    MotherLastBX.Text = _dataTable.Rows[1]["ln"].ToString();
                    FatherFirstBX.Text = _dataTable.Rows[0]["fn"].ToString();
                    FatherMiddleBX.Text = _dataTable.Rows[0]["mn"].ToString();
                    FatherLastBX.Text = _dataTable.Rows[0]["ln"].ToString();
                    if (_dataTable.Rows.Count > 2) { 
                        SpouseFirstBX.Text = _dataTable.Rows[2]["fn"].ToString();
                        SpouseMiddleBX.Text = _dataTable.Rows[2]["mn"].ToString();
                        SpouseLastBX.Text = _dataTable.Rows[2]["ln"].ToString();
                    }
                }
                catch (Exception ex) {
                    ShowErrorBox("Loading Guards", ex.Message);
                }
            }
            catch (Exception ex) {
                ShowErrorBox("Loading Guards", ex.Message);
            }
            try {
                foreach (DataRow row in Guard.GetGuardsDependents(Gid).Rows) {
                    DepGRD.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString());
                    
                }

                
            }
            catch (Exception ex) {
                ShowErrorBox("Loading Guards", ex.Message);
            }
        }

        #endregion

        #region Form Props

        private const int CsDropshadow = 0x20000;

        protected override CreateParams CreateParams {
            get {
                var cp = base.CreateParams;
                cp.ClassStyle |= CsDropshadow;
                return cp;
            }
        }

        private static void ShowErrorBox(string name, string error) {
            RylMessageBox.ShowDialog("Please try again.\nIf the problem still persist, please contact your administrator. \n\n\nError Message: \n=============================\n" + error + "\n=============================\n", "Error Configuring " + name,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void FadeTMR_Tick(object sender, EventArgs e) {
            Opacity += 0.2;
            if (Opacity.Equals(1)) FadeTMR.Stop();
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            if (RylMessageBox.ShowDialog("Are you sure you want to stop editing? Unsaved changes will be lost.", "Stop Editing?",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Close();
        }

        private void Guards_EditEmployees_Load(object sender, EventArgs e) {
            GEditDetailsBTN.Text = Button;
            if (Button.Equals("UPDATE")) {
                PopulateEdit();
                AddLBL.Text = "Edit details";
            }
            FadeTMR.Start();
            _panel = PersonalPNL;
            _label = PersonalLBL;
            PersonalPNL.Visible = true;
            BirthdateBX.MaxDate = new DateTime(DateTime.Now.Year - 18, DateTime.Now.Month, DateTime.Now.Day);
        }

        private void Guards_EditEmployees_FormClosing(object sender, FormClosingEventArgs e) {
            if (Button.Equals("ADD")) Refer.Close();
        }

        private void CloseBTN_MouseEnter(object sender, EventArgs e) {
            CloseBTN.ForeColor = Color.White;
        }

        private void CloseBTN_MouseLeave(object sender, EventArgs e) {
            CloseBTN.ForeColor = _dark;
        }

        #endregion

        #region Clearing of TextBoxes While Editing

        private static void ClearBox(TextBoxBase textBoxBase) {
            if (textBoxBase.Text.Equals("Last")) textBoxBase.Clear();
            else if (textBoxBase.Text.Equals("Middle")) textBoxBase.Clear();
            else if (textBoxBase.Text.Equals("First")) textBoxBase.Clear();
        }

        private static void ClearAddressBox(TextBoxBase textBoxBase) {
            if (textBoxBase.Text.Equals("No.")) textBoxBase.Clear();
            else if (textBoxBase.Text.Equals("Street Name")) textBoxBase.Clear();
            else if (textBoxBase.Text.Equals("Brgy")) textBoxBase.Clear();
            else if (textBoxBase.Text.Equals("City")) textBoxBase.Clear();
        }

        private void FirstNameBX_Enter(object sender, EventArgs e) {
            ClearBox(FirstNameBX);
        }

        private void LastNameBX_Enter(object sender, EventArgs e) {
            ClearBox(LastNameBX);
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

        private void CVStatusBX_SelectedIndexChanged(object sender, EventArgs e) {
            SpouseFirstBX.Enabled = SpouseMiddleBX.Enabled = SpouseLastBX.Enabled = CVStatusBX.SelectedIndex != 1;
        }

        private void EdAttBX_SelectedIndexChanged(object sender, EventArgs e) {
            CourseBX.Enabled = EdAttBX.SelectedIndex == 4;
        }

        private void MaleRDBTN_CheckedChanged(object sender, EventArgs e) {
            if (MaleRDBTN.Checked) _gender = 1;
        }

        private void FemaleRDBTN_CheckedChanged(object sender, EventArgs e) {
            if (FemaleRDBTN.Checked) _gender = 2;
        }

        private void LastNameBX_Leave(object sender, EventArgs e) {
            var lastbx = sender as TextBox;
            if (lastbx.Text.Trim(' ').Length == 0) lastbx.Text = "Last";
        }

        private void FirstNameBX_Leave(object sender, EventArgs e) {
            var lastbx = sender as TextBox;
            if (lastbx.Text.Trim(' ').Length == 0) lastbx.Text = "First";
        }

        private void MiddleNameBX_Leave(object sender, EventArgs e) {
            var lastbx = sender as TextBox;
            if (lastbx.Text.Trim(' ').Length == 0) lastbx.Text = "Middle";
        }

        private void StreetNoBX_Leave(object sender, EventArgs e) {
            var streetnobx = sender as TextBox;
            if (streetnobx.Text.Trim(' ').Length == 0) streetnobx.Text = "No.";
        }

        private void StreetNameBX_Leave(object sender, EventArgs e) {
            var streetnamebx = sender as TextBox;
            if (streetnamebx.Text.Trim(' ').Length == 0) streetnamebx.Text = "Street Name";
        }

        private void BrgyBX_Leave(object sender, EventArgs e) {
            var brgybx = sender as TextBox;
            if (brgybx.Text.Trim(' ').Length == 0) brgybx.Text = "Brgy";
        }

        private void CityBX_Leave(object sender, EventArgs e) {
            var citybx = sender as TextBox;
            if (citybx.Text.Trim(' ').Length == 0) citybx.Text = "City";
        }


        //Realtime Tooltips
        private void BirthplaceStreetNoBX_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.') {
                e.Handled = true;
                ToolTip.ToolTipTitle = "Street No.";
                ToolTip.Show("Can only accept numbers", BirthplaceStreetNoBX);
            }
        }

        private void PermStreetNoBX_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.') {
                e.Handled = true;
                ToolTip.ToolTipTitle = "Street No.";
                ToolTip.Show("Can only accept numbers", PermStreetNoBX);
            }
        }

        private void TempStreetNoBX_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.') {
                e.Handled = true;
                ToolTip.ToolTipTitle = "Street No.";
                ToolTip.Show("Can only accept numbers", TempStreetNoBX);
            }
        }

        private void EmergencyNoBX_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.') {
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
            BeginInvoke((MethodInvoker) delegate { WeightBX.Select(0, 0); });
        }

        private void HeightBX_Enter(object sender, EventArgs e) {
            BeginInvoke((MethodInvoker) delegate { HeightBX.Select(0, 0); });
        }

        private void CellNoBX_Enter(object sender, EventArgs e) {
            BeginInvoke((MethodInvoker) delegate { CellNoBX.Select(0, 0); });
        }

        private void TellNoBX_Enter(object sender, EventArgs e) {
            BeginInvoke((MethodInvoker) delegate { TellNoBX.Select(0, 0); });
        }

        private void LicenseNoBX_Enter(object sender, EventArgs e) {
            BeginInvoke((MethodInvoker) delegate { LicenseNoBX.Select(0, 0); });
        }

        private void SSSNoBX_Enter(object sender, EventArgs e) {
            BeginInvoke((MethodInvoker) delegate { SSSNoBX.Select(0, 0); });
        }

        private void TINNoBX_Enter(object sender, EventArgs e) {
            BeginInvoke((MethodInvoker) delegate { TINNoBX.Select(0, 0); });
        }

        private void PhilHealthBX_Enter(object sender, EventArgs e) {
            BeginInvoke((MethodInvoker) delegate { PhilHealthBX.Select(0, 0); });
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

        #region Adding and Editing

        private static int GetRelationshipIndex(string rep) {
            switch (rep) {
                case "Son":
                    return 1;
                case "Daughter":
                    return 2;
                case "Sibling":
                    return 3;
                default:
                    return 0;
            }
        }

        private void GEditDetailsBTN_Click(object sender, EventArgs e) {
            if (CheckInput()) {
                #region Adding

                if (GEditDetailsBTN.Text.Equals("ADD")) {
                    try {
                        Guard.AddGuardBasicInfo(FirstNameBX.Text.Replace("'", string.Empty), MiddleNameBX.Text.Replace("'", string.Empty), LastNameBX.Text.Replace("'", string.Empty), BirthdateBX.Value,
                            _gender, HeightBX.Text.Replace(".", string.Empty), WeightBX.Text.Replace(".", string.Empty), ReligionBX.Text.Replace("'", string.Empty), CVStatusBX.SelectedIndex,
                            CellNoBX.Text.Replace(".", string.Empty), TellNoBX.Text.Replace(".", string.Empty), LicenseNoBX.Text, SSSNoBX.Text, TINNoBX.Text,
                            PhilHealthBX.Text, PrevAgencyBX.Text.Replace("'", string.Empty), PrevAssBX.Text.Replace("'", string.Empty), EdAttBX.SelectedIndex, CourseBX.Text,
                            MilTrainBX.Text.Replace("'", string.Empty), EmergBX.Text.Replace("'", string.Empty), EmergencyNoBX.Text.Replace("'", string.Empty));
                    }
                    catch (Exception ex) {
                        ShowErrorBox("Saving Guards", ex.Message);
                    }
                    try {
                        Gid = int.Parse(SQLTools.getLastInsertedId("Guards", "GID"));
                    }
                    catch (Exception ex) {
                        ShowErrorBox("Saving Guards", ex.Message);
                    }
                    try {
                        InsertAdd(1, BirthplaceStreetNoBX.Text, BirthplaceStreetNameBX.Text, BirthplaceCityBX.Text,
                            BirthplaceBrgyBX.Text);
                        InsertAdd(2, PermStreetNoBX.Text, PermStreetNameBX.Text, PermCityBX.Text, PermBrgyBX.Text);
                        InsertAdd(3, TempStreetNoBX.Text, TempStreetNameBX.Text, TempCityBX.Text, TempBrgyBX.Text);
                    }
                    catch (Exception ex) {
                        ShowErrorBox("Saving Guards", ex.Message);
                    }
                    try {
                        InsertDependent(4, FatherFirstBX.Text.Replace("'", string.Empty), FatherMiddleBX.Text.Replace("'", string.Empty), FatherLastBX.Text.Replace("'", string.Empty));
                        InsertDependent(5, MotherFirstBX.Text.Replace("'", string.Empty), MotherMiddleBX.Text.Replace("'", string.Empty), MotherLastBX.Text.Replace("'", string.Empty));
                        if (!CheckName(SpouseFirstBX, SpouseMiddleBX, SpouseLastBX) && CVStatusBX.SelectedIndex != 1)
                            InsertDependent(6, SpouseFirstBX.Text.Replace("'", string.Empty), SpouseMiddleBX.Text.Replace("'", string.Empty), SpouseLastBX.Text.Replace("'", string.Empty));

                        foreach (DataGridViewRow row in DepGRD.Rows) {
                            InsertDependent(GetRelationshipIndex(row.Cells[4].Value.ToString()) , row.Cells[1].Value.ToString().Replace("'", string.Empty),
                            row.Cells[2].Value.ToString().Replace("'", string.Empty), row.Cells[3].Value.ToString().Replace("'", string.Empty));
                        }
                    }
                    catch (Exception ex) {
                        ShowErrorBox("Saving Guards", ex.Message);
                    }
                }

                #endregion

                #region Updating

                else if (GEditDetailsBTN.Text.Equals("UPDATE")) {
                    try {
                        Guard.UpdateGuardBasicInfo(Gid, FirstNameBX.Text.Replace("'", string.Empty), MiddleNameBX.Text.Replace("'", string.Empty), LastNameBX.Text.Replace("'", string.Empty),
                            BirthdateBX.Value, _gender, HeightBX.Text.Replace(".", string.Empty), WeightBX.Text.Replace(".", string.Empty), ReligionBX.Text.Replace("'", string.Empty),
                            CVStatusBX.SelectedIndex, CellNoBX.Text.Replace(".", string.Empty), TellNoBX.Text.Replace(".", string.Empty), LicenseNoBX.Text, SSSNoBX.Text,
                            TINNoBX.Text, PhilHealthBX.Text, PrevAgencyBX.Text.Replace("'", string.Empty), PrevAssBX.Text.Replace("'", string.Empty), EdAttBX.SelectedIndex,
                            CourseBX.Text.Replace("'", string.Empty), MilTrainBX.Text.Replace("'", string.Empty), EmergBX.Text.Replace("'", string.Empty), EmergencyNoBX.Text.Replace("'", string.Empty));
                    }

                    catch (Exception ex) {
                        ShowErrorBox("Saving Guards", ex.Message);
                    }
                    try {
                        UpdateAdd(BirthplaceStreetNoBX.Text.Replace("'", string.Empty), BirthplaceStreetNameBX.Text.Replace("'", string.Empty), BirthplaceCityBX.Text.Replace("'", string.Empty),
                            BirthplaceBrgyBX.Text, 1);
                        UpdateAdd(PermStreetNoBX.Text.Replace("'", string.Empty), PermStreetNameBX.Text.Replace("'", string.Empty), PermCityBX.Text.Replace("'", string.Empty), PermBrgyBX.Text.Replace("'", string.Empty), 2);
                        UpdateAdd(TempStreetNoBX.Text.Replace("'", string.Empty), TempStreetNameBX.Text.Replace("'", string.Empty), TempCityBX.Text.Replace("'", string.Empty), TempBrgyBX.Text.Replace("'", string.Empty), 3);
                    }
                    catch (Exception ex) {
                        ShowErrorBox("Saving Guards", ex.Message);
                    }
                    try {
                        UpdateDependent(FatherFirstBX.Text.Replace("'", string.Empty), FatherMiddleBX.Text.Replace("'", string.Empty), FatherLastBX.Text.Replace("'", string.Empty), 4);
                        UpdateDependent(MotherFirstBX.Text.Replace("'", string.Empty), MotherMiddleBX.Text.Replace("'", string.Empty), MotherLastBX.Text.Replace("'", string.Empty), 5);
                        if (!CheckName(SpouseFirstBX, SpouseMiddleBX, SpouseLastBX))
                            UpdateDependent(SpouseFirstBX.Text.Replace("'", string.Empty), SpouseMiddleBX.Text.Replace("'", string.Empty), SpouseLastBX.Text.Replace("'", string.Empty), 6);


                        foreach (DataGridViewRow row in DepGRD.Rows) {
                            if (row.Cells[0].Value.ToString().Equals("-1"))
                                InsertDependent(GetRelationshipIndex(row.Cells[4].Value.ToString()), row.Cells[1].Value.ToString().Replace("'", string.Empty),
                                    row.Cells[2].Value.ToString().Replace("'", string.Empty), row.Cells[3].Value.ToString().Replace("'", string.Empty));
                            else if (row.Cells[0].Value.ToString().Contains("Del"))
                                Guard.RemoveDependent(int.Parse(row.Cells[0].Value.ToString().Replace("Del", string.Empty)));
                            else
                                UpdateDependent(row.Cells[1].Value.ToString().Replace("'", string.Empty), row.Cells[2].Value.ToString().Replace("'", string.Empty), row.Cells[3].Value.ToString().Replace("'", string.Empty),
                                    GetRelationshipIndex(row.Cells[4].Value.ToString()), int.Parse(row.Cells[0].Value.ToString()));
                        }
                        
                        ViewRef.RefreshData();
                    }
                    catch (Exception ex) {
                        ShowErrorBox("Saving Guards", ex.Message);
                    }
                }

                #endregion

                Reference.GuardsRefreshGuardsList();
                Close();
            }
        }

        private void InsertDependent(int rel, string first, string middle, string last) {
            Guard.AddGuardsDependent(Gid, rel, first, middle, last);
        }

        private void InsertAdd(int type, string streetNo, string street, string city, string brgy) {
            Guard.AddGuardAddress(Gid, type, streetNo, street, city, brgy);
        }

        private void UpdateAdd(string streetNo, string street, string city, string brgy, int type) {
            Guard.UpdateGuardAddress(Gid, streetNo, street, city, brgy, type);
        }

        private void UpdateDependent(string first, string middle, string last, int rel) {
            Guard.UpdateGuardsDependent(Gid, rel, first, middle, last);
        }

        private void UpdateDependent(string first, string middle, string last, int rel, int id) {
            Guard.UpdateGuardsDependent(Gid, first, middle, last, rel, id);
        }

        #endregion

        #region DataValidation

        private bool CheckInput() {
            var check = true;

            if (CheckName(LastNameBX, "Last")) {
                ShowToolTipOnBx(LastNameWarn, "Last Name", "Please enter last name", LastNameBX);
                check = false;
            }
            if (CheckName(MiddleNameBX, "Middle")) {
                ShowToolTipOnBx(MiddleNameWarn, "Middle Name", "Please enter middle name", MiddleNameBX);
                check = false;
            }
            if (CheckName(FirstNameBX, "First")) {
                ShowToolTipOnBx(FirstNameWarn, "First Name", "Please enter first name", FirstNameBX);
                check = false;
            }
            if (DateTime.Now.Year - BirthdateBX.Value.Year < 18) {
                ShowToolTipOnLbl(BirthWarn, "Birthdate", "Must be more than 18", BdayLBL);
                check = false;
            }
            if (!MaleRDBTN.Checked && !FemaleRDBTN.Checked) {
                ShowToolTipOnLbl(GenderWarn, "Gender", "Please specify gender", GenderLBL);
                check = false;
            }
            if (HeightBX.Text.Equals("    .")) {
                ShowToolTipOnMbx(HeightWarn, "Height", "Please specify height", HeightBX);
                check = false;
            }
            if (WeightBX.Text.Equals("    kg.")) {
                ShowToolTipOnMbx(WeightWarn, "Weight", "Please specify weight", WeightBX);
                check = false;
            }
            if (CVStatusBX.SelectedIndex == 0 || CVStatusBX.Text.Equals("")) {
                ShowToolTipOnLbl(CVWarn, "Civil Status", "Please specify civil status", CVLBL);
                check = false;
            }
            if (CheckAdd(BirthplaceBrgyBX, BirthplaceCityBX, BirthplaceStreetNameBX, BirthplaceStreetNoBX)) {
                ShowToolTipOnBx(BirthPlaceWarn, "Birthplace", "Please specify or complete the fields",
                    BirthplaceStreetNoBX);
                check = false;
            }
            if (CheckAdd(TempBrgyBX, TempCityBX, TempStreetNameBX, TempStreetNoBX)) {
                ShowToolTipOnBx(TempAddWarn, "Temporary Address", "Please specify or complete the fields",
                    TempStreetNoBX);
                check = false;
            }
            if (CheckAdd(PermBrgyBX, PermCityBX, PermStreetNameBX, PermStreetNoBX)) {
                ShowToolTipOnBx(PermAdWarn, "Permanent Address", "Please specify or complete the fields",
                    PermStreetNoBX);
                check = false;
            }
            if (ReligionBX.Text.Equals("")) {
                ShowToolTipOnBx(ReligionWarn, "Religion", "Please specify religion", ReligionBX);
                check = false;
            }
            if (CellNoBX.Text.Equals("+63             .") && TellNoBX.Text.Equals("   -    .")) {
                ShowToolTipOnLbl(ContactWarn, "Contact Details", "Please specify at least one contact information",
                    ContactLBL);
                check = false;
            }
            if (EmergBX.Text.Equals("") || EmergencyNoBX.Text.Equals("")) {
                ShowToolTipOnLbl(EmergencyWarn, "Emergency Contact Information", "Please complete the fields", EmerLBL);
                check = false;
            }
            if (check) {
                if (CheckName(MotherFirstBX, MotherMiddleBX, MotherLastBX)) {
                    ShowToolTipOnBx(MotherWarn, "Mother's Name", "Please specify or complete the fields",
                        MotherFirstBX);
                    check = false;
                }
                if (CheckName(FatherFirstBX, FatherMiddleBX, FatherLastBX)) {
                    ShowToolTipOnBx(FatherWarn, "Father's Name", "Please specify or complete the fields",
                        FatherFirstBX);
                    check = false;
                }
                if (CheckNameNotRequired(SpouseFirstBX, SpouseMiddleBX, SpouseLastBX) && CVStatusBX.SelectedIndex > 0) {
                    ShowToolTipOnBx(SpouseWarn, "Spouse's Name", "Please specify or complete the fields",
                        SpouseFirstBX);
                    check = false;
                }
                if (check) {
                    ChangePage(WorkPNL, WorkLBL);
                    if (LicenseNoBX.Text.Equals("           .")) {
                        ShowToolTipOnMbx(LicenseWarn, "License Details", "Please specify license number",
                            LicenseNoBX);
                        check = false;
                    }
                    if (SSSNoBX.Text.Equals("           .")) {
                        ShowToolTipOnMbx(SSSWarn, "SSS Details", "Please specify SSS number", SSSNoBX);
                        check = false;
                    }
                    if (TINNoBX.Text.Equals("           .")) {
                        ShowToolTipOnMbx(TINWarn, "TIN Details", "Please specify TIN number", TINNoBX);
                        check = false;
                    }
                    if (PhilHealthBX.Text.Equals("  -         - .")) {
                        ShowToolTipOnMbx(PhilHealthWarn, "Insurance Details", "Please specify PhilHealth number",
                            PhilHealthBX);
                        check = false;
                    }
                    if (EdAttBX.Text.Equals("")) {
                        ShowToolTipOnLbl(EdAtWarn, "Highest Educational Attainment",
                            "Please specify highest educational attainment", EdAtLBL);
                        check = false;
                    }
                    if (CourseBX.Text.Equals("") && EdAttBX.SelectedIndex == 4) {
                        ShowToolTipOnBx(CourseWarn, "Course Details", "Please specify the course in college",
                            CourseBX);
                        check = false;
                    }
                }
                else {
                    ChangePage(FamilyPNL, FamilyLBL);
                }
            }
            else {
                ChangePage(PersonalPNL, PersonalLBL);
            }
            return check;
        }

        private static void ShowToolTipOnLbl(ToolTip ttp, string title, string message, IWin32Window lb) {
            ttp.ToolTipTitle = title;
            ttp.Show(message, lb);
        }

        private static void ShowToolTipOnBx(ToolTip ttp, string title, string message, IWin32Window lb) {
            ttp.ToolTipTitle = title;
            ttp.Show(message, lb);
        }

        private static void ShowToolTipOnMbx(ToolTip ttp, string title, string message, IWin32Window lb) {
            ttp.ToolTipTitle = title;
            ttp.Show(message, lb);
        }

        private bool CheckName(Control tb, string arg1) {
            return tb.Text.Equals(arg1) || LastNameBX.Text.Trim(' ').Length == 0;
        }

        private static bool CheckAdd(Control brgyBx, Control cityBx, Control streetNameBx, Control streetNoBx) {
            return brgyBx.Text.Equals("Brgy") || cityBx.Text.Equals("City") ||
                   streetNameBx.Text.Equals("Street Name") || streetNoBx.Text.Equals("No.") ||
                   brgyBx.Text.Equals("") || cityBx.Text.Equals("") || streetNameBx.Text.Equals("") ||
                   streetNoBx.Text.Equals("");
        }

        private static bool CheckName(Control firstBx, Control middleBx, Control lastBx) {
            return firstBx.Text.Equals("First") || middleBx.Text.Equals("Middle") || lastBx.Text.Equals("Last") ||
                   firstBx.Text.Equals("") || middleBx.Text.Equals("") || lastBx.Text.Equals("");
        }

        private static bool CheckNameNotRequired(Control firstBx, Control middleBx, Control lastBx) {
            return CheckForInput(firstBx, middleBx, lastBx) && CheckName(firstBx, middleBx, lastBx);
        }

        private static bool CheckForInput(Control firstBx, Control middleBx, Control lastBx) {
            return !(firstBx.Text.Equals("First") || firstBx.Text.Equals("")) ||
                   !(middleBx.Text.Equals("Middle") || middleBx.Text.Equals("")) ||
                   !(lastBx.Text.Equals("Last") || lastBx.Text.Equals(""));
        }

        #endregion

        #region Tab Navigation Properties

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

        private void FamilyLBL_MouseLeave(object sender, EventArgs e) {
            if (_label != FamilyLBL) FamilyLBL.ForeColor = _light;
        }

        private void WorkLBL_MouseLeave(object sender, EventArgs e) {
            if (_label != WorkLBL) WorkLBL.ForeColor = _light;
        }


        private void PersonalLBL_MouseLeave(object sender, EventArgs e) {
            if (_label != PersonalLBL) PersonalLBL.ForeColor = _light;
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


        #endregion

        private void DelRowBTN_Click(object sender, EventArgs e) {
            try { 
                if (DepGRD.SelectedRows.Count > 0) {
                    DepGRD.SelectedRows[0].Cells[0].Value = DepGRD.SelectedRows[0].Cells[0].Value + "Del";
                    DepGRD.SelectedRows[0].Visible = false;
                }
            }
            catch (Exception ex) {
                ShowErrorBox("Removing Guards", ex.Message);
            }
        }

        private void AddRowBTN_Click(object sender, EventArgs e) {
            DepGRD.Rows.Add(-1, "First", "Middle", "Last", "");
        }

        private void TypeOfficer_CheckedChanged(object sender, EventArgs e) {
            _guardType = TypeGuard.Checked ? 1 : 0;
        }

        private void TypeGuard_CheckedChanged(object sender, EventArgs e) {
            _guardType = TypeGuard.Checked ? 1 : 0;
        }
    }
}