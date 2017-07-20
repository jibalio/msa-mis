using System;
using System.Drawing;
using System.Windows.Forms;

namespace MSAMISUserInterface {
    public partial class Sched_RequestGuard : Form {
        public MainForm reference;
        private String FilterText = "Search or filter";
        private String EmptyText = "";
        private String ExtraQueryParams = "";
        private String CID = "-1";

        public Shadow refer;

        #region Form Initializtion and Load
        public Sched_RequestGuard() {
            InitializeComponent();
            Opacity = 0;
        }

        private void Sched_RequestGuard_Load(object sender, EventArgs e) {
            LoadClients();
            Location = new Point(Location.X + 175, Location.Y);
            RequestPNL.Hide();
            PickPNL.Show();
            FadeTMR.Start();
            ContractStartDTPKR.MinDate = DateTime.Now;
        }
        private void LoadClients() {
            ClientGRD.DataSource = Scheduling.GetClients();
            ClientGRD.Columns[0].Visible = false;
            ClientGRD.Columns[1].Width = 330;
            ClientGRD.ColumnHeadersVisible = false;
            ClientGRD.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ClientGRD.ClearSelection();
        }
        private void Sched_RequestGuard_FormClosing(object sender, FormClosingEventArgs e) {
            refer.Hide();
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            Close();
        }
        private void FadeTMR_Tick(object sender, EventArgs e) {
            Opacity += 0.2;
            if (Opacity >= 1) { FadeTMR.Stop(); }
        }
        #endregion

        #region Pick Panel
        private void SViewAssSearchTXTBX_Enter(object sender, EventArgs e) {
            if (ClientSearchBX.Text == FilterText) {
                ClientSearchBX.Text = EmptyText;
                ExtraQueryParams = EmptyText;
            }
            ClientSearchLine.Visible = true;
        }
        private void SViewAssSearchTXTBX_Leave(object sender, EventArgs e) {
            if (ClientSearchBX.Text == EmptyText) {
                ClientSearchBX.Text = FilterText;
                ExtraQueryParams = EmptyText;
            }
            LoadClients();
            ClientSearchLine.Visible = false;
        }
        #endregion

        #region Textbox Props and Data Validation
        private void AssStreetNoBX_Enter(object sender, EventArgs e) {
            ClearAddressBox(AssStreetNoBX);
        }
        private void AssStreetNameBX_Enter(object sender, EventArgs e) {
            ClearAddressBox(AssStreetNameBX);
        }

        private void AssBrgyBX_Enter(object sender, EventArgs e) {
            ClearAddressBox(AssBrgyBX);
        }

        private void AssCityBX_Enter(object sender, EventArgs e) {
            ClearAddressBox(AssCityBX);
        }
        private static void ClearAddressBox(TextBoxBase TX) {
            if (TX.Text.Equals("No.")) TX.Clear();
            else if (TX.Text.Equals("Street Name")) TX.Clear();
            else if (TX.Text.Equals("Brgy")) TX.Clear();
            else if (TX.Text.Equals("City")) TX.Clear();
        }
        
        private void AssStreetNoBX_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) {
                e.Handled = true;
                ToolTip.ToolTipTitle = "Street No.";
                ToolTip.Show("Can only accept numbers", AssStreetNoBX);
            }
        }
        private void ClientGRD_CellEnter(object sender, DataGridViewCellEventArgs e) {
            if (ClientGRD.SelectedRows.Count == 1) CID = ClientGRD.SelectedRows[0].Cells[0].Value.ToString();
        }
        private void ContractStartDTPKR_ValueChanged(object sender, EventArgs e) {
            ContractEndDTPKR.MinDate = ContractStartDTPKR.Value;
        }
        private bool DataValidation() {
            var ret = true;
            if (NeededBX.Value == 0) {
                NeededTLTP.ToolTipTitle = "Guards Needed";
                NeededTLTP.Show("Please specify how many guards the client needs", NeededBX);
                ret = false;
            }
            if (CheckAdd(AssBrgyBX, AssCityBX, AssStreetNameBX, AssStreetNoBX)) {
                LocationTLTP.ToolTipTitle = "Location";
                LocationTLTP.Show("Please specify or complete the fields", AssStreetNoBX);
                ret = false;
            }
            if (!ret) {
                RequestPNL.Show();
                PickPNL.Hide();
                PickLBL.ForeColor = light;
                RequestLBL.ForeColor = dark;
            }
            return ret;
        }
        private static bool CheckAdd(Control BrgyBX, Control CityBX, Control StreetNameBX, Control StreetNoBX) {
            return (BrgyBX.Text.Equals("Brgy") || CityBX.Text.Equals("City") || StreetNameBX.Text.Equals("Street Name") || StreetNoBX.Text.Equals("No.") ||
                BrgyBX.Text.Equals("") || CityBX.Text.Equals("") || StreetNameBX.Text.Equals("") || StreetNoBX.Text.Equals(""));
        }

        private void AssStreetNoBX_Leave(object sender, EventArgs e) {
            if (AssStreetNoBX.Text.Trim(' ').Length == 0) AssStreetNoBX.Text = "No.";
        }

        private void AssStreetNameBX_Leave(object sender, EventArgs e) {
            if (AssStreetNameBX.Text.Trim(' ').Length == 0) AssStreetNameBX.Text = "Street Name";
        }

        private void AssBrgyBX_Leave(object sender, EventArgs e) {
            if (AssBrgyBX.Text.Trim(' ').Length == 0) AssBrgyBX.Text = "Brgy";
        }

        private void AssCityBX_Leave(object sender, EventArgs e) {
            if (AssCityBX.Text.Trim(' ').Length == 0) AssCityBX.Text = "City";
        }
        #endregion

        #region Navigation
        private readonly Color dark = Color.FromArgb(53, 64, 82);
        private readonly Color light = Color.DarkGray;

        private void PickLBL_Click(object sender, EventArgs e) {
            NextBTN.PerformClick();
        }

        private void RequestLBL_Click(object sender, EventArgs e) {
            NextBTN.PerformClick();
        }

        private void PickLBL_MouseEnter(object sender, EventArgs e) {
            PickLBL.ForeColor = dark;
        }

        private void RequestLBL_MouseEnter(object sender, EventArgs e) {
            RequestLBL.ForeColor = dark;
        }

        private void RequestLBL_MouseLeave(object sender, EventArgs e) {
            if (!RequestPNL.Visible) RequestLBL.ForeColor = light;
        }

        private void PickLBL_MouseLeave(object sender, EventArgs e) {
            if (!PickPNL.Visible) PickLBL.ForeColor = light;
        }

        private void NextBTN_Click(object sender, EventArgs e) {
            if (NextBTN.Text.Equals("BACK")) {
                RequestPNL.Visible = false;
                PickPNL.Visible = true;
                PickLBL.ForeColor = dark;
                RequestLBL.ForeColor = light;
                NextBTN.Text = "NEXT";
            } else {
                RequestPNL.Visible = true;
                PickPNL.Visible = false;
                PickLBL.ForeColor = light;
                RequestLBL.ForeColor = dark;
                NextBTN.Text = "BACK";
            }
        }
        #endregion

        #region Adding
        private void AddBTN_Click(object sender, EventArgs e) {
            if (DataValidation()) {
                if (CID.Equals("-1")) {
                    rylui.RylMessageBox.ShowDialog("Please select a client", "Request a guard", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else {
                    Scheduling.AddAssignmentRequest(int.Parse(CID), AssStreetNoBX.Text, AssStreetNameBX.Text, AssBrgyBX.Text, AssCityBX.Text, ContractStartDTPKR.Value, ContractEndDTPKR.Value, (int)(NeededBX.Value));
                    reference.SCHEDLoadPage();
                    Close();
                }
            }
        }
        #endregion






    }
}
