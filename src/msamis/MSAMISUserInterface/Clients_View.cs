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
        public Shadow refer;
        public Clients_View() {
            InitializeComponent();
            this.Opacity = 0;
        }

        private void Clients_View_Load(object sender, EventArgs e) {
            RefreshData();
            this.Location = new Point(this.Location.X + 150, this.Location.Y);
            FadeTMR.Start();
        }

        private void Clients_View_FormClosing(object sender, FormClosingEventArgs e) {
            refer.Hide();
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void FadeTMR_Tick(object sender, EventArgs e) {
            this.Opacity += 0.2;
            if (this.Opacity >= 1) { FadeTMR.Stop(); }

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

               LocationLBL.Text = dt.Rows[0]["ClientStreetNo"].ToString() + " " + dt.Rows[0]["ClientStreet"].ToString() + ", " + dt.Rows[0]["ClientBrgy"].ToString() + ", " + dt.Rows[0]["ClientBrgy"].ToString() + ", " + dt.Rows[0]["ClientCity"].ToString();
                ManagerLBL.Text = "Manager: " + dt.Rows[0]["Manager"].ToString();
                ContactLBL.Text = "Contact Person: " + dt.Rows[0]["ContactPerson"].ToString();
                ContactNoLBL.Text = "Contact No: " + dt.Rows[0]["ContactNo"].ToString();

                conn.Close();
            }
            catch (Exception ee) {
                conn.Close();
                MessageBox.Show(ee.Message);
            }
        }
    }
}
