using System;
using System.Windows.Forms;
using rylui;
using System.Data;

namespace MSAMISUserInterface {
    public partial class ClientsEdit : Form {
        public string Button = "ADD";
        public int Cid;

        public Shadow Refer;
        public MainForm Reference;
        public ClientsView ViewRef;

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
                try {
                    var dataTable = Client.GetCertifiers(Cid);
                    foreach (DataRow row in dataTable.Rows) {
                        CertifiersGRD.Rows.Add(int.Parse(row["ccid"].ToString()), row["fn"].ToString(), row["mn"].ToString(), row["ln"].ToString(), row["contactno"].ToString());
                    }
                }
                catch (Exception ex) {
                    ShowErrorBox("Loading Certifiers", ex.Message);
                }
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
            if (RylMessageBox.ShowDialog("Are you sure you want to stop editing? Unsaved changes will be lost.", "Stop Editing?",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Close();
        }

        private void Clients_Edit_Load(object sender, EventArgs e) {
            GEditDetailsBTN.Text = Button;
            if (Button.Equals("UPDATE")) {
                AddLBL.Text = "Edit details";
                PopulateEdit();
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

            if (CertifiersGRD.Rows.Count == 0) {
                CertifiersTLTP.ToolTipTitle = "Certifiers";
                CertifiersTLTP.Show("Please enter at least one certifier", CertifiersGRD);
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
        private void GEditDetailsBTN_Click(object sender, EventArgs e) {
            if (DataVal()) {
                try {
                    if (GEditDetailsBTN.Text.Equals("ADD")) {
                        Client.AddClient(NameBX.Text.Replace("'", string.Empty), LocationStreetNoBX.Text.Replace("'", string.Empty), LocationStreetNameBX.Text.Replace("'", string.Empty),
                            LocationBrgyBX.Text.Replace("'", string.Empty), LocationCityBX.Text.Replace("'", string.Empty), ContactBX.Text.Replace("'", string.Empty), ContactNoBX.Text.Replace("'", string.Empty), ManagerBX.Text.Replace("'", string.Empty), double.Parse(BasicPayBX.Value.ToString("N2")));
                        var dep = int.Parse(SQLTools.getLastInsertedId("Client", "cid"));
                        foreach (DataGridViewRow row in CertifiersGRD.Rows) {
                            InsertDependent(dep, row.Cells[4].Value.ToString().Replace("'", string.Empty), row.Cells[1].Value.ToString().Replace("'", string.Empty), row.Cells[2].Value.ToString().Replace("'", string.Empty), row.Cells[3].Value.ToString().Replace("'", string.Empty));
                        }
                    }
                    else {
                        Client.UpdateClient(Cid.ToString(), NameBX.Text.Replace("'", string.Empty), LocationStreetNoBX.Text.Replace("'", string.Empty),
                            LocationStreetNameBX.Text.Replace("'", string.Empty),
                            LocationBrgyBX.Text.Replace("'", string.Empty), LocationCityBX.Text.Replace("'", string.Empty), ContactBX.Text.Replace("'", string.Empty), ContactNoBX.Text.Replace("'", string.Empty), ManagerBX.Text.Replace("'", string.Empty), double.Parse(BasicPayBX.Value.ToString("N2")));

                        foreach (DataGridViewRow row in CertifiersGRD.Rows) {
                            if (row.Cells[0].Value.ToString().Equals("-1"))
                                InsertDependent(row.Cells[4].Value.ToString().Replace("'", string.Empty), row.Cells[1].Value.ToString().Replace("'", string.Empty), row.Cells[2].Value.ToString().Replace("'", string.Empty), row.Cells[3].Value.ToString().Replace("'", string.Empty));
                            else if (row.Cells[0].Value.ToString().Contains("Del"))
                                Client.RemoveCertifier(int.Parse(CertifiersGRD.SelectedRows[0].Cells[0].Value.ToString().Replace("Del", string.Empty)));
                            else
                                UpdateDependent(row.Cells[1].Value.ToString().Replace("'", string.Empty), row.Cells[2].Value.ToString().Replace("'", string.Empty), row.Cells[3].Value.ToString().Replace("'", string.Empty), row.Cells[1].Value.ToString().Replace("'", string.Empty), int.Parse(row.Cells[0].Value.ToString()));
                        }

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

        private void InsertDependent(int cid, string rel, string first, string middle, string last) {
            Client.AddCertifier(cid, first, middle, last, rel);
        }

        private void InsertDependent(string rel, string first, string middle, string last) {
            Client.AddCertifier(Cid, first, middle, last, rel);
        }

        private void UpdateDependent(string first, string middle, string last, string rel, int id) {
            Client.UpdateCertifier(id, first, middle, last, rel);
        }


        #endregion

        private void AddRowBTN_Click(object sender, EventArgs e) {
            CertifiersGRD.Rows.Add(-1, "First", "Middle", "Last", "Contact");
        }

        private void DelRowBTN_Click(object sender, EventArgs e) {
            if (CertifiersGRD.SelectedRows.Count > 0) {
                CertifiersGRD.SelectedRows[0].Cells[0].Value += "Del";
                CertifiersGRD.SelectedRows[0].Visible = false;
            }
        }

        private const int CsDropshadow = 0x20000;

        protected override CreateParams CreateParams {
            get {
                var cp = base.CreateParams;
                cp.ClassStyle |= CsDropshadow;
                return cp;
            }
        }
    }
}