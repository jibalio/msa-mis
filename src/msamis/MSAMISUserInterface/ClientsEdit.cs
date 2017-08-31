using System;
using System.Drawing;
using System.Windows.Forms;
using rylui;

namespace MSAMISUserInterface {
    public partial class ClientsEdit : Form {
        public string Button = "ADD";
        public int Cid;

        public Shadow Refer;
        public MainForm Reference;
        public ClientsView ViewRef;

        private int[] _dependents;

        public ClientsEdit() {
            InitializeComponent();
            Opacity = 0;
        }

        #region Populating 

        private void PopulateEdit() {
            try {
                var dt = Client.GetClientDetails(Cid);

                NameBX.Text = dt.Rows[0]["name"].ToString();

                LocationStreetNoBX.Text = dt.Rows[0]["ClientStreetNo"].ToString();
                LocationBrgyBX.Text = dt.Rows[0]["ClientBrgy"].ToString();
                LocationStreetNameBX.Text = dt.Rows[0]["ClientStreet"].ToString();
                LocationCityBX.Text = dt.Rows[0]["ClientCity"].ToString();
                ManagerBX.Text = dt.Rows[0]["Manager"].ToString();
                ContactBX.Text = dt.Rows[0]["ContactPerson"].ToString();
                ContactNoBX.Text = dt.Rows[0]["ContactNo"].ToString();
            }
            catch (Exception ex) {
                ShowErrorBox("Clients Editing", ex.Message);
            }
        }

        #endregion

        #region Form Props

        private void FadeTMR_Tick(object sender, EventArgs e) {
            Opacity += 0.2;
            if (Opacity.Equals(1)) FadeTMR.Stop();
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            if (RylMessageBox.ShowDialog("Are you sure you want to stop editing?", "Stop Editing?",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Close();
        }

        private void Clients_Edit_Load(object sender, EventArgs e) {
            GEditDetailsBTN.Text = Button;
            if (Button.Equals("UPDATE")) {
                AddLBL.Text = "Edit details";
                PopulateEdit();
            }
            else {
                Location = new Point(Location.X + 150, Location.Y);
            }
            FadeTMR.Start();
        }

        private static void ShowErrorBox(string name, string error) {
            RylMessageBox.ShowDialog("Please try again.\nIf the problem still persist, please contact your administrator. \n\n\nError Message: \n=============================\n" + error + "\n=============================\n", "Error Configuring " + name,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Clients_Edit_FormClosing(object sender, FormClosingEventArgs e) {
            if (Button.Equals("ADD")) Refer.Close();
        }

        #endregion

        #region Textbox Properties while editing

        private void NameBX_MouseEnter(object sender, EventArgs e) {
            if (NameBX.Text.Equals("Name")) {
                NameBX.Text = "";
                NameTLTP.Hide(NameBX);
            }
        }

        private void LocationStreetNameBX_MouseEnter(object sender, EventArgs e) {
            if (LocationStreetNameBX.Text.Equals("Street Name")) LocationStreetNameBX.Text = "";
        }

        private void LocationStreetNoBX_MouseEnter(object sender, EventArgs e) {
            if (LocationStreetNoBX.Text.Equals("No.")) LocationStreetNoBX.Text = "";
        }

        private void LocationBrgyBX_MouseEnter(object sender, EventArgs e) {
            if (LocationBrgyBX.Text.Equals("Brgy")) LocationBrgyBX.Text = "";
        }

        private void LocationCityBX_MouseEnter(object sender, EventArgs e) {
            if (LocationCityBX.Text.Equals("City")) LocationCityBX.Text = "";
        }

        private void NameBX_TextChanged(object sender, EventArgs e) {
            HideTooltips();
        }

        private void StreetNoBX_Leave(object sender, EventArgs e) {
            if (LocationStreetNoBX.Text.Trim(' ').Length == 0) LocationStreetNoBX.Text = "No.";
        }

        private void StreetNameBX_Leave(object sender, EventArgs e) {
            if (LocationStreetNameBX.Text.Trim(' ').Length == 0) LocationStreetNameBX.Text = "Street Name";
        }

        private void BrgyBX_Leave(object sender, EventArgs e) {
            if (LocationBrgyBX.Text.Trim(' ').Length == 0) LocationBrgyBX.Text = "Brgy";
        }

        private void CityBX_Leave(object sender, EventArgs e) {
            if (LocationCityBX.Text.Trim(' ').Length == 0) LocationCityBX.Text = "City";
        }

        private void NameBX_Leave(object sender, EventArgs e) {
            if (NameBX.Text.Trim(' ').Length == 0) NameBX.Text = "Name";
        }

        private void HideTooltips() {
            NameTLTP.Hide(NameBX);
            LocationTLTP.Hide(LocationStreetNoBX);
            ManagerTLTP.Hide(ManagerBX);
            ContactTLTP.Hide(ContactBX);
            ContactNoTLTP.Hide(ContactNoBX);
        }

        private void LocationStreetNoBX_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.') {
                e.Handled = true;
                ToolTip.ToolTipTitle = "Street No.";
                ToolTip.Show("Can only accept numbers", LocationStreetNoBX);
            }
        }

        private void Clients_Edit_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape)
                if (IsEmpty() == false) {
                    var rs = RylMessageBox.ShowDialog("Cancel Chnages? \nAny unsaved changes will be lost.",
                        "Stop Editing?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rs == DialogResult.Yes) Close();
                }
                else {
                    Close();
                }
        }

        #endregion

        #region Adding and Editign

        private bool DataVal() {
            var ret = true;
            if (NameBX.Text.Equals("") || NameBX.Text.Equals("Name")) {
                NameTLTP.ToolTipTitle = "Client Name";
                NameTLTP.Show("Please enter client name", NameBX);
                ret = false;
            }

            if (LocationStreetNoBX.Text.Equals("") || LocationStreetNoBX.Text.Equals("No.") ||
                LocationStreetNameBX.Text.Equals("") || LocationStreetNameBX.Text.Equals("Street Name") ||
                LocationCityBX.Text.Equals("") || LocationCityBX.Text.Equals("City") ||
                LocationBrgyBX.Text.Equals("") || LocationBrgyBX.Text.Equals("Brgy")) {
                LocationTLTP.ToolTipTitle = "Client Location";
                LocationTLTP.Show("Please complete all fields", LocationStreetNoBX);
                ret = false;
            }

            if (ManagerBX.Text.Equals("")) {
                ManagerTLTP.ToolTipTitle = "Client Manager";
                ManagerTLTP.Show("Please enter client's manager", ManagerBX);
                ret = false;
            }

            if (ContactBX.Text.Equals("")) {
                ContactTLTP.ToolTipTitle = "Client Contact Person";
                ContactTLTP.Show("Please enter contact person's name", ContactBX);
                ret = false;
            }

            if (ContactNoBX.Text.Equals("")) {
                ContactNoTLTP.ToolTipTitle = "Contact Person's No";
                ContactNoTLTP.Show("Please enter contact person's no", ContactNoBX);
                ret = false;
            }

            return ret;
        }

        private bool IsEmpty() {
            bool ret;
            if ((NameBX.Text.Equals("") || NameBX.Text.Equals("Name")) &&
                (LocationStreetNoBX.Text.Equals("") || LocationStreetNoBX.Text.Equals("No.")) &&
                (LocationStreetNameBX.Text.Equals("") || LocationStreetNameBX.Text.Equals("Street Name")) &&
                (LocationCityBX.Text.Equals("") || LocationCityBX.Text.Equals("City")) &&
                (LocationBrgyBX.Text.Equals("") || LocationBrgyBX.Text.Equals("Brgy"))
                && ManagerBX.Text.Equals("")
                && ContactBX.Text.Equals("")
                && ContactNoBX.Text.Equals("")) ret = true;
            else ret = false;

            return ret;
        }

        private static bool CheckName(Control firstBx, Control middleBx, Control lastBx) {
            return firstBx.Text.Equals("First") || middleBx.Text.Equals("Middle") || lastBx.Text.Equals("Last") ||
                   firstBx.Text.Equals("") || middleBx.Text.Equals("") || lastBx.Text.Equals("");
        }

        private void GEditDetailsBTN_Click(object sender, EventArgs e) {
            if (DataVal()) {
                try {
                    if (GEditDetailsBTN.Text.Equals("ADD")) {
                        Client.AddClient(NameBX.Text, LocationStreetNoBX.Text, LocationStreetNameBX.Text,
                            LocationBrgyBX.Text, LocationCityBX.Text, ContactBX.Text, ContactNoBX.Text, ManagerBX.Text);

                        if (!CheckName(Dependent1FirstBX, Dependent1MiddleBX, Dependent1LastBX))
                            InsertDependent(Dep1Contact.Text.Equals("Contact") ? "" : Dep1Contact.Text, Dependent1FirstBX.Text,
                                Dependent1MiddleBX.Text, Dependent1LastBX.Text);
                        if (!CheckName(Dependent2FirstBX, Dependent2MiddleBX, Dependent2LastBX))
                            InsertDependent(Dep2Contact.Text.Equals("Contact") ? "" : Dep2Contact.Text, Dependent2FirstBX.Text,
                                Dependent2MiddleBX.Text, Dependent2LastBX.Text);
                        if (!CheckName(Dependent3FirstBX, Dependent3MiddleBX, Dependent3LastBX))
                            InsertDependent(Dep3Contact.Text.Equals("Contact") ? "" : Dep3Contact.Text, Dependent3FirstBX.Text,
                                Dependent3MiddleBX.Text, Dependent3LastBX.Text);
                    }
                    else {
                        Client.UpdateClient(Cid.ToString(), NameBX.Text, LocationStreetNoBX.Text,
                            LocationStreetNameBX.Text,
                            LocationBrgyBX.Text, LocationCityBX.Text, ContactBX.Text, ContactNoBX.Text, ManagerBX.Text);

                        if (CheckName(Dependent1FirstBX, Dependent1MiddleBX, Dependent1LastBX))
                            if (_dependents.Length > 0)
                                UpdateDependent(Dependent1FirstBX.Text, Dependent1MiddleBX.Text, Dependent1LastBX.Text,
                                    Dep1Contact.Text.Equals("Contact") ? "" : Dep1Contact.Text, _dependents[0]);
                            else
                                InsertDependent(Dep1Contact.Text.Equals("Contact") ? "" : Dep1Contact.Text, Dependent1FirstBX.Text,
                                    Dependent1MiddleBX.Text, Dependent1LastBX.Text);
                        if (!CheckName(Dependent2FirstBX, Dependent2MiddleBX, Dependent2LastBX))
                            if (_dependents.Length > 1)
                                UpdateDependent(Dependent2FirstBX.Text, Dependent2MiddleBX.Text, Dependent2LastBX.Text,
                                    Dep2Contact.Text.Equals("Contact") ? "" : Dep2Contact.Text, _dependents[1]);
                            else
                                InsertDependent(Dep2Contact.Text.Equals("Contact") ? "" : Dep2Contact.Text, Dependent2FirstBX.Text,
                                    Dependent2MiddleBX.Text, Dependent2LastBX.Text);
                        if (!CheckName(Dependent3FirstBX, Dependent3MiddleBX, Dependent3LastBX))
                            if (_dependents.Length > 2)
                                UpdateDependent(Dependent3FirstBX.Text, Dependent3MiddleBX.Text, Dependent3LastBX.Text,
                                    Dep3Contact.Text.Equals("Contact") ? "" : Dep3Contact.Text, _dependents[2]);
                            else
                                InsertDependent(Dep3Contact.Text.Equals("Contact") ? "" : Dep3Contact.Text, Dependent3FirstBX.Text,
                                    Dependent3MiddleBX.Text, Dependent3LastBX.Text);

                        ViewRef.RefreshData();
                    }
                    Reference.ClientsRefreshClientsList();
                    Close();
                }
                catch (Exception ex) {
                    ShowErrorBox("Clients Editing", ex.Message);
                }
            }
        }

        private void InsertDependent(string rel, string first, string middle, string last) {
           // Guard.AddGuardsDependent(Gid, rel, first, middle, last);
        }

        private void UpdateDependent(string first, string middle, string last, string rel, int id) {
            //Guard.UpdateGuardsDependent(Gid, first, middle, last, rel, id);
        }

        #endregion
    }
}