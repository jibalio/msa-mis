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
    public partial class Sched_RequestGuard : Form {
        public MainForm reference;
        public MySqlConnection conn;
        String FilterText = "Search or filter";
        String EmptyText = "";
        String ExtraQueryParams = "";
        String CID = "0";

        public Sched_RequestGuard() {
            InitializeComponent();
            this.Opacity = 0;
        }

        private void Sched_RequestGuard_Load(object sender, EventArgs e) {
            LoadClients();
            FadeTMR.Start();
            ContractStartDTPKR.MinDate = DateTime.Now;
        }

        private void LoadClients() {
            ClientGRD.DataSource = Scheduling.GetClients();

            ClientGRD.Columns[0].Visible = false;
            ClientGRD.Columns[1].Width = 410;
            ClientGRD.ColumnHeadersVisible = false;
            ClientGRD.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
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

        private void Sched_RequestGuard_FormClosing(object sender, FormClosingEventArgs e) {
            reference.Opacity = 1;
            reference.Show();
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void FadeTMR_Tick(object sender, EventArgs e) {
            this.Opacity += 0.2;
            if (reference.Opacity == 0.6 || this.Opacity >= 1) { FadeTMR.Stop(); }
            if (reference.Opacity > 0.7) { reference.Opacity -= 0.1; }
        }

        private void AddBTN_Click(object sender, EventArgs e) {
            if (DataValidation()) {
                Scheduling.AddAssignmentRequest(int.Parse(CID), AssStreetNoBX.Text, AssStreetNameBX.Text, AssBrgyBX.Text, AssCityBX.Text, ContractStartDTPKR.Value, ContractEndDTPKR.Value, int.Parse(NeededBX.Text));
                reference.SCHEDLoadPage();
                this.Close();
            }
        }

        private void ClientGRD_CellEnter(object sender, DataGridViewCellEventArgs e) {
            if (ClientGRD.SelectedRows.Count == 1) CID = ClientGRD.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void AssStreetNoBX_Enter(object sender, EventArgs e) {
            ClearAddressBox(AssStreetNoBX);
        }

        private void ClearAddressBox(TextBox TX) {
            if (TX.Text.Equals("No.")) TX.Clear();
            else if (TX.Text.Equals("Street Name")) TX.Clear();
            else if (TX.Text.Equals("Brgy")) TX.Clear();
            else if (TX.Text.Equals("City")) TX.Clear();
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

        private void AssStreetNoBX_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) {
                e.Handled = true;
                ToolTip.ToolTipTitle = "Street No.";
                ToolTip.Show("Can only accept numbers", AssStreetNoBX);
            }
        }

        private void NeededBX_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) {
                e.Handled = true;
                ToolTip.ToolTipTitle = "Guards Needed";
                ToolTip.Show("Can only accept numbers", NeededBX);
            }
        }

        private void ContractStartDTPKR_ValueChanged(object sender, EventArgs e) {
            ContractEndDTPKR.MinDate = ContractStartDTPKR.Value;
        }

        private bool DataValidation() {
            bool ret = true;
            if (NeededBX.Text.ToString().Equals("")) {
                NeededTLTP.ToolTipTitle = "Guards Needed";
                NeededTLTP.Show("Please specify how many guards the client needs", NeededBX);
                ret = false;
            } 
            if (CheckAdd(AssBrgyBX, AssCityBX, AssStreetNameBX, AssStreetNoBX)) {
                LocationTLTP.ToolTipTitle = "Location";
                LocationTLTP.Show( "Please specify or complete the fields", AssStreetNoBX);
                ret = false;
            }
            return ret;
        }
        private bool CheckAdd(TextBox BrgyBX, TextBox CityBX, TextBox StreetNameBX, TextBox StreetNoBX) {
            return (BrgyBX.Text.Equals("Brgy") || CityBX.Text.Equals("City") || StreetNameBX.Text.Equals("Street Name") || StreetNoBX.Text.Equals("No.") ||
                BrgyBX.Text.Equals("") || CityBX.Text.Equals("") || StreetNameBX.Text.Equals("") || StreetNoBX.Text.Equals(""));
        }
    }
}
