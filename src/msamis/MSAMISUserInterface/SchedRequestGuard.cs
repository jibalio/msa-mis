using System;
using System.Drawing;
using System.Windows.Forms;
using rylui;

namespace MSAMISUserInterface {
    public partial class SchedRequestGuard : Form {
        private const string FilterText = "Search or filter";
        private const string EmptyText = "";
        private string _cid = "-1";
        private string _extraQueryParams = "";

        public Shadow Refer;
        public MainForm Reference;

        #region Adding

        private void AddBTN_Click(object sender, EventArgs e) {
            if (DataValidation())
                if (_cid.Equals("-1")) {
                    RylMessageBox.ShowDialog("Please select a client", "Request a guard", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else {
                    Scheduling.AddAssignmentRequest(int.Parse(_cid), AssStreetNoBX.Text, AssStreetNameBX.Text,
                        AssBrgyBX.Text, AssCityBX.Text, ContractStartDTPKR.Value, ContractEndDTPKR.Value,
                        (int) NeededBX.Value);
                    Reference.SchedLoadPage();
                    Close();
                }
        }

        #endregion

        #region Form Initializtion and Load

        public SchedRequestGuard() {
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
            ClientGRD.DataSource = Client.GetAllClientDetails(_extraQueryParams);
            ClientGRD.Columns[0].Visible = false;
            ClientGRD.Columns[1].Width = 330;
            ClientGRD.ColumnHeadersVisible = false;
            ClientGRD.Columns[2].Visible = false;
            ClientGRD.Columns[3].Visible = false;
            ClientGRD.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ClientGRD.ClearSelection();
        }

        private void Sched_RequestGuard_FormClosing(object sender, FormClosingEventArgs e) {
            Refer.Close();
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            if (RylMessageBox.ShowDialog("Are you sure you want to stop editing?", "Stop Editing?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Close();
        }

        private void FadeTMR_Tick(object sender, EventArgs e) {
            Opacity += 0.2;
            if (Opacity >= 1) FadeTMR.Stop();
        }

        #endregion

        #region Pick Panel

        private void SViewAssSearchTXTBX_Enter(object sender, EventArgs e) {
            if (ClientSearchBX.Text == FilterText) {
                ClientSearchBX.Text = EmptyText;
                _extraQueryParams = EmptyText;
            }
            ClientSearchLine.Visible = true;
        }

        private void SViewAssSearchTXTBX_Leave(object sender, EventArgs e) {
            if (ClientSearchBX.Text == EmptyText) {
                ClientSearchBX.Text = FilterText;
                _extraQueryParams = EmptyText;
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

        private static void ClearAddressBox(TextBoxBase textBoxBase) {
            if (textBoxBase.Text.Equals("No.")) textBoxBase.Clear();
            else if (textBoxBase.Text.Equals("Street Name")) textBoxBase.Clear();
            else if (textBoxBase.Text.Equals("Brgy")) textBoxBase.Clear();
            else if (textBoxBase.Text.Equals("City")) textBoxBase.Clear();
        }

        private void AssStreetNoBX_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.') {
                e.Handled = true;
                ToolTip.ToolTipTitle = "Street No.";
                ToolTip.Show("Can only accept numbers", AssStreetNoBX);
            }
        }

        private void ClientGRD_CellEnter(object sender, DataGridViewCellEventArgs e) {
            if (ClientGRD.SelectedRows.Count == 1) _cid = ClientGRD.SelectedRows[0].Cells[0].Value.ToString();
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
                PickLBL.ForeColor = _light;
                RequestLBL.ForeColor = _dark;
            }
            return ret;
        }

        private static bool CheckAdd(Control brgyBx, Control cityBx, Control streetNameBx, Control streetNoBx) {
            return brgyBx.Text.Equals("Brgy") || cityBx.Text.Equals("City") ||
                   streetNameBx.Text.Equals("Street Name") || streetNoBx.Text.Equals("No.") ||
                   brgyBx.Text.Equals("") || cityBx.Text.Equals("") || streetNameBx.Text.Equals("") ||
                   streetNoBx.Text.Equals("");
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

        private readonly Color _dark = Color.FromArgb(53, 64, 82);
        private readonly Color _light = Color.DarkGray;

        private void PickLBL_Click(object sender, EventArgs e) {
            NextBTN.PerformClick();
        }

        private void RequestLBL_Click(object sender, EventArgs e) {
            NextBTN.PerformClick();
        }

        private void PickLBL_MouseEnter(object sender, EventArgs e) {
            PickLBL.ForeColor = _dark;
        }

        private void RequestLBL_MouseEnter(object sender, EventArgs e) {
            RequestLBL.ForeColor = _dark;
        }

        private void RequestLBL_MouseLeave(object sender, EventArgs e) {
            if (!RequestPNL.Visible) RequestLBL.ForeColor = _light;
        }

        private void PickLBL_MouseLeave(object sender, EventArgs e) {
            if (!PickPNL.Visible) PickLBL.ForeColor = _light;
        }

        private void NextBTN_Click(object sender, EventArgs e) {
            if (NextBTN.Text.Equals("BACK")) {
                RequestPNL.Visible = false;
                PickPNL.Visible = true;
                PickLBL.ForeColor = _dark;
                RequestLBL.ForeColor = _light;
                NextBTN.Text = "NEXT";
            }
            else {
                RequestPNL.Visible = true;
                PickPNL.Visible = false;
                PickLBL.ForeColor = _light;
                RequestLBL.ForeColor = _dark;
                NextBTN.Text = "BACK";
            }
        }

        #endregion

        private void ClientSearchBX_TextChanged(object sender, EventArgs e) {
            var temp = ClientSearchBX.Text;
            const string kazoo = "name";

            if (ClientSearchBX.Text.Contains("\\")) temp = temp + "?";
            _extraQueryParams = " where (" + kazoo + " like '" + temp + "%' OR " + kazoo + " like '%" + temp +
                                "%' OR " + kazoo + " LIKe '%" + temp + "')";
            LoadClients();
        }
    }
}