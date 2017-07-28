using System;
using System.Drawing;
using System.Windows.Forms;

namespace MSAMISUserInterface {
    public partial class ClientsView : Form {
        public int Cid { get; set; }
        public MainForm Reference;
        public Shadow Refer;
        public ClientsView() {
            InitializeComponent();
            Opacity = 0;
        }

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
            if (Opacity >= 1) { FadeTMR.Stop(); }

        }

        private void CEditDetailsBTN_Click(object sender, EventArgs e) {
            var view = new ClientsEdit
            {
                Cid = Cid,
                Button = "UPDATE",
                ViewRef = this,
                Reference = Reference,
                Location = Location

            };
            view.ShowDialog();
        }

        public void RefreshData() {
            var dt = Client.GetClientDetails(Cid);
            NameLBL.Text = dt.Rows[0]["name"].ToString();
            CIDLBL.Text = dt.Rows[0]["CID"].ToString();

            LocationLBL.Text = dt.Rows[0]["ClientStreetNo"] + " " + dt.Rows[0]["ClientStreet"] + ", " + dt.Rows[0]["ClientBrgy"] + ", " + dt.Rows[0]["ClientBrgy"] + ", " + dt.Rows[0]["ClientCity"];
            ManagerLBL.Text = "Manager: " + dt.Rows[0]["Manager"];
            ContactLBL.Text = "Contact Person: " + dt.Rows[0]["ContactPerson"];
            ContactNoLBL.Text = "Contact No: " + dt.Rows[0]["ContactNo"];
        }
    }
}
