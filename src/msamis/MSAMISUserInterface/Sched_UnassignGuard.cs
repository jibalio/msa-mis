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
    public partial class Sched_UnassignGuard : Form {
        public MainForm reference;
        public MySqlConnection conn;
        public DataGridViewSelectedRowCollection guards { get; set; }
        public Sched_UnassignGuard() {
            InitializeComponent();
            this.Opacity = 0;
        }

        private void Sched_DismissGuard_Load(object sender, EventArgs e) {
            LoadPage();
            FadeTMR.Start();
        }

        private void LoadPage() {
            GuardsGRD.ColumnHeadersVisible = false;
            foreach (DataGridViewRow row in guards) {
                GuardsGRD.Rows.Add(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString());
            }
            GuardsGRD.Sort(GuardsGRD.Columns[3], ListSortDirection.Ascending);
        }

        private void FadeTMR_Tick(object sender, EventArgs e) {
            this.Opacity += 0.2;
            if (reference.Opacity == 0.6 || this.Opacity >= 1) { FadeTMR.Stop(); }
            if (reference.Opacity > 0.7) { reference.Opacity -= 0.1; }
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void Sched_DismissGuard_FormClosing(object sender, FormClosingEventArgs e) {
            reference.Opacity = 1;
            reference.Show();
        }

        private void RemoveBTN_Click(object sender, EventArgs e) {
            foreach (DataGridViewRow row in GuardsGRD.SelectedRows) {
                GuardsGRD.Rows.Remove(row);
            }
        }

        private void DismissBTN_Click(object sender, EventArgs e) {
           // Scheduling.A
        }
    }
}
