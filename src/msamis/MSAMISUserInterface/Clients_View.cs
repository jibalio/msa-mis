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
    public partial class Clients_View : Form {
        public int CID { get; set; }
        public MainForm reference;
        public MySqlConnection conn;

        public Clients_View() {
            InitializeComponent();
            this.Opacity = 0;
        }

        private void Clients_View_Load(object sender, EventArgs e) {
            RefreshData();
            FadeTMR.Start();
        }

        private void Clients_View_FormClosing(object sender, FormClosingEventArgs e) {
            reference.Opacity = 1;
            reference.Show();
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            this.Close();
            reference.GUARDSRefreshGuardsList();
        }

        private void FadeTMR_Tick(object sender, EventArgs e) {
            this.Opacity += 0.2;
            if (reference.Opacity == 0.6 || this.Opacity >= 1) { FadeTMR.Stop(); }
            if (reference.Opacity > 0.7) { reference.Opacity -= 0.1; }

        }

        private void CEditDetailsBTN_Click(object sender, EventArgs e) {
            Clients_Edit view = new Clients_Edit();
            view.CID = this.CID;
            view.button = "UPDATE";
            view.conn = this.conn;
            view.viewref = this;
            view.reference = this.reference;
            view.Location = this.Location;
            view.ShowDialog();
        }

        public void RefreshData() {
            try {
                conn.Open();
                MySqlCommand comm = new MySqlCommand("SELECT * FROM client WHERE CID = " + CID, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                NameLBL.Text = dt.Rows[0]["name"].ToString();
                CIDLBL.Text = dt.Rows[0]["CID"].ToString();

                if (dt.Rows[0]["cstatus"].ToString().Equals("1")) StatusLBL.Text = "Active";
                else StatusLBL.Text = "Inactive";

               LocationLBL.Text = dt.Rows[0]["ClientStreetNo"].ToString() + " " + dt.Rows[0]["ClientStreet"].ToString() + ", " + dt.Rows[0]["ClientBrgy"].ToString() + ", " + dt.Rows[0]["ClientBrgy"].ToString() + ", " + dt.Rows[0]["ClientCity"].ToString();
                ManagerLBL.Text = dt.Rows[0]["Manager"].ToString();
                ContactLBL.Text = dt.Rows[0]["ContactPerson"].ToString();
                ContactNoLBL.Text = dt.Rows[0]["ContactNo"].ToString();

                conn.Close();
            }
            catch (Exception ee) {
                conn.Close();
                MessageBox.Show(ee.Message);
            }
        }
    }
}
