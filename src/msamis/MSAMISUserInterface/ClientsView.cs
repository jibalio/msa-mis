using System;
using System.Drawing;
using System.Windows.Forms;
using rylui;
using System.Data;

namespace MSAMISUserInterface {
    public partial class ClientsView : Form {
        public Shadow Refer;
        public MainForm Reference;

        public ClientsView() {
            InitializeComponent();
            Opacity = 0;
        }

        public int Cid { get; set; }

        private void Clients_View_Load(object sender, EventArgs e) {
            RefreshData();
            Location = new Point(Location.X + 150, Location.Y);
            FadeTMR.Start();
        }

        private void Clients_View_FormClosing(object sender, FormClosingEventArgs e) {
            Refer.Close();
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            Close();
        }

        private void FadeTMR_Tick(object sender, EventArgs e) {
            Opacity += 0.2;
            if (Opacity >= 1) FadeTMR.Stop();
        }

        private void CEditDetailsBTN_Click(object sender, EventArgs e) {
            var view = new ClientsEdit {
                Cid = Cid,
                Button = "UPDATE",
                ViewRef = this,
                Reference = Reference,
                Location = Location
            };
            view.ShowDialog();
        }

        private static void ShowErrorBox(string name, string error) {
            RylMessageBox.ShowDialog("Please try again.\nIf the problem still persist, please contact your administrator. \n\n\nError Message: \n=============================\n" + error + "\n=============================\n", "Error Configuring " + name,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void RefreshData() {
            try {


                var dt = Client.GetClientDetails(Cid);
                NameLBL.Text = dt.Rows[0]["name"].ToString();
                CIDLBL.Text = dt.Rows[0]["CID"].ToString();
                LocationLBL.Text = dt.Rows[0]["ClientStreetNo"] + " " + dt.Rows[0]["ClientStreet"] + ", " +
                                   dt.Rows[0]["ClientBrgy"] + ", " + dt.Rows[0]["ClientBrgy"] + ", " +
                                   dt.Rows[0]["ClientCity"];
                ManagerLBL.Text = dt.Rows[0]["Manager"].ToString();
                ContactLBL.Text = dt.Rows[0]["ContactPerson"].ToString();
                ContactNoLBL.Text = dt.Rows[0]["ContactNo"].ToString();
                try {
                    CertifiersGRD.DataSource = Client.GetCertifiersView(Cid);
                    CertifiersGRD.Columns[0].Visible = false;
                    CertifiersGRD.Columns[1].Visible = false;
                    CertifiersGRD.Columns[2].Width = 220;
                    CertifiersGRD.Columns[3].Width = 150;
                    CertifiersGRD.ColumnHeadersVisible = false;

                    if (CertifiersGRD.Rows.Count == 0) {
                        ErrorPNL.BringToFront();
                        ErrorPNL.Visible = true;
                    }
                    else {
                        ErrorPNL.Visible = false;
                    }
                }
                catch (Exception ex) {
                    Console.WriteLine(ex);
                }
            }
            catch (Exception ex) {
                ShowErrorBox("Loading Error", ex.Message);
            }
        }

        private static string BuildName(DataTable dt, int row) {
            return dt.Rows[row]["ln"] + ", " + dt.Rows[row]["fn"] + " " + dt.Rows[row]["mn"];
        }
    }
}