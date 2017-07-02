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
    public partial class Clients_Edit : Form {
        public int CID;
        public MainForm reference;
        public Clients_View viewref;
        public String button = "ADD";
        public MySql.Data.MySqlClient.MySqlConnection conn;

        public Clients_Edit() {
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
            if (isEmpty() == false) {
                DialogResult rs = rylui.RylMessageBox.ShowDialog("Cancel Chnages? \nAny unsaved changes will be lost.", "Stop Editing?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes) this.Close();
            } else { this.Close(); }
        }
        private void Clients_Edit_Load(object sender, EventArgs e) {
            GEditDetailsBTN.Text = button;
            if (button.Equals("UPDATE")) {
                ActiveStatusRDBTN.Enabled = true;
                InactiveStatusRDBTN.Enabled = true;
                ActiveStatusRDBTN.Checked = false;
                InactiveStatusRDBTN.Checked = false;
                PopulateEdit();
            } else {
                ActiveStatusRDBTN.Enabled = false;
                InactiveStatusRDBTN.Enabled = false;
                InactiveStatusRDBTN.Checked = true;
            }
            FadeTMR.Start();
        }
        private void Clients_Edit_FormClosing(object sender, FormClosingEventArgs e) {
            if (button.Equals("ADD")) {
                Console.WriteLine("[Guard_Edit] Closing Event");
                reference.Opacity = 1;
                Console.WriteLine("[Guard_Edit] Setting Opacity to 100");
                reference.Enabled = true;
                Console.WriteLine("[Guard_Edit] Setting reference.Enable to true");
            }
        }
        #endregion

        #region Textbox Properties while editing
        private void NameBX_MouseEnter(object sender, EventArgs e) {
            if (NameBX.Text.Equals("Name")) { NameBX.Text = ""; NameTLTP.Hide(NameBX); }
        }

        private void LocationStreetNameBX_MouseEnter(object sender, EventArgs e) {
            if (LocationStreetNameBX.Text.Equals("Street Name")) { LocationStreetNameBX.Text = ""; }
        }

        private void LocationStreetNoBX_MouseEnter(object sender, EventArgs e) {
            if (LocationStreetNoBX.Text.Equals("No.")) { LocationStreetNoBX.Text = ""; }
        }

        private void LocationBrgyBX_MouseEnter(object sender, EventArgs e) {
            if (LocationBrgyBX.Text.Equals("Brgy")) { LocationBrgyBX.Text = ""; }
        }

        private void LocationCityBX_MouseEnter(object sender, EventArgs e) {
            if (LocationCityBX.Text.Equals("City")) { LocationCityBX.Text = ""; }
        }
        private void NameBX_TextChanged(object sender, EventArgs e) {
            HideTooltips();
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


        private void HideTooltips() {
            NameTLTP.Hide(NameBX);
            LocationTLTP.Hide(LocationStreetNoBX);
            ManagerTLTP.Hide(ManagerBX);
            ContactTLTP.Hide(ContactBX);
            ContactNoTLTP.Hide(ContactNoBX);
        }

        private void LocationStreetNoBX_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) {
                e.Handled = true;
                ToolTip.ToolTipTitle = "Street No.";
                ToolTip.Show("Can only accept numbers", LocationStreetNoBX);
            }
        }

        private void Clients_Edit_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape) {
                    if (isEmpty() == false) {
                        DialogResult rs = rylui.RylMessageBox.ShowDialog("Cancel Chnages? \nAny unsaved changes will be lost.", "Stop Editing?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rs == DialogResult.Yes) this.Close();
                    } else { this.Close(); }

                }
            }



        #endregion

        #region Adding and Editign
        private bool DataVal() {
            bool ret = true;
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

        private bool isEmpty()
        {
            bool ret = false;
            if ((NameBX.Text.Equals("") || NameBX.Text.Equals("Name")) &&
                (LocationStreetNoBX.Text.Equals("") || LocationStreetNoBX.Text.Equals("No.")) &&
                (LocationStreetNameBX.Text.Equals("") || LocationStreetNameBX.Text.Equals("Street Name")) &&
                (LocationCityBX.Text.Equals("") || LocationCityBX.Text.Equals("City")) &&
                (LocationBrgyBX.Text.Equals("") || LocationBrgyBX.Text.Equals("Brgy"))
                && ManagerBX.Text.Equals("")
                && ContactBX.Text.Equals("")
                && ContactNoBX.Text.Equals(""))
                ret = true;

            return ret;
        }

        


    private void GEditDetailsBTN_Click(object sender, EventArgs e) {
            if (DataVal()) {
                if (GEditDetailsBTN.Text.Equals("ADD")) {
                    try {
                        conn.Open();
                        MySqlCommand comm = new MySqlCommand("INSERT INTO Client(Name, ClientStreetNo, ClientStreet, ClientBrgy, ClientCity, ContactPerson, ContactNo, Manager, CStatus) VALUES ('" + NameBX.Text + "','" + LocationStreetNoBX.Text + "','" + LocationStreetNameBX.Text + "','" + LocationBrgyBX.Text + "','" + LocationCityBX.Text + "','" + ContactBX.Text + "','" + ContactNoBX.Text + "','" + ManagerBX.Text + "', '0')", conn);
                        comm.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch (Exception ee) {
                        conn.Close();
                        rylui.RylMessageBox.ShowDialog(ee.Message);
                    }
                } else {
                    try {
                        int status;
                        if (ActiveStatusRDBTN.Checked) status = 1; else status = 0;

                        conn.Open();
                        MySqlCommand comm = new MySqlCommand("UPDATE Client SET Name = '" + NameBX.Text + "', ClientStreetNo = '" + LocationStreetNoBX.Text + "', ClientStreet = '" + LocationStreetNameBX.Text + "', ClientBrgy = '" + LocationBrgyBX.Text + "', ClientCity = '" + LocationCityBX.Text + "', ContactPerson = '" + ContactBX.Text + "', ContactNo = '" + ContactNoBX.Text + "', Manager = '" + ManagerBX.Text + "', CStatus = '" + status + "' WHERE CID =" + CID, conn);
                        comm.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch (Exception ee) {
                        conn.Close();
                        rylui.RylMessageBox.ShowDialog(ee.Message);
                    }
                    viewref.RefreshData();
                }
                reference.CLIENTSRefreshClientsList();
                this.Close();
            }
        }
        #endregion

        #region Populating 
        private void PopulateEdit() {
            try {
                conn.Open();
                MySqlCommand comm = new MySqlCommand("SELECT * FROM client WHERE CID = " + CID, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                NameBX.Text = dt.Rows[0]["name"].ToString();

                if (dt.Rows[0]["cstatus"].ToString().Equals("1")) ActiveStatusRDBTN.Checked = true;
                else InactiveStatusRDBTN.Checked = true;

                LocationStreetNoBX.Text = dt.Rows[0]["ClientStreetNo"].ToString();
                LocationBrgyBX.Text = dt.Rows[0]["ClientBrgy"].ToString();
                LocationStreetNameBX.Text = dt.Rows[0]["ClientStreet"].ToString();
                LocationCityBX.Text = dt.Rows[0]["ClientCity"].ToString();
                ManagerBX.Text = dt.Rows[0]["Manager"].ToString();
                ContactBX.Text = dt.Rows[0]["ContactPerson"].ToString();
                ContactNoBX.Text = dt.Rows[0]["ContactNo"].ToString();

                conn.Close();
            }
            catch (Exception ee) {
                conn.Close();
                MessageBox.Show(ee.Message);
            }


        }







        #endregion
    }
}
