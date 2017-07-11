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
    public partial class Sched_AddDutyDays : Form {
        public Sched_ViewDutyDetails reference;
        public MySqlConnection conn;
        public String button = "ADD";
        public int AID { get; set; }
        Attendance A;

        #region Form Properties and Load
        public Sched_AddDutyDays() {
            InitializeComponent();
            this.Opacity = 0;
        }
        private void SAddDutyDays_Load(object sender, EventArgs e) {
            LoadPage();
            FadeTMR.Start();
        }
        private void FadeTMR_Tick(object sender, EventArgs e) {
            this.Opacity += 0.2;
            if (this.Opacity >= 1) FadeTMR.Stop();
        }
        private void CloseBTN_Click(object sender, EventArgs e) {
            this.Close();
        }
        private void LoadPage() {
            Attendance.Period p = Attendance.GetCurrentPayPeriod(0);
            A = new Attendance(AID, p.month, p.period, p.year);
            RefreshData();
        }
        #endregion

        #region Form Props
        private void ConfirmBTN_Click(object sender, EventArgs e) {
            if (DataValidation()) {
                foreach (DataGridViewRow row in DaysGRD.Rows) {
                    A.SetAttendance(int.Parse(row.Cells[0].Value.ToString()), int.Parse(row.Cells[2].Value.ToString()), int.Parse(row.Cells[4].Value.ToString()), row.Cells[5].Value.ToString(), int.Parse(row.Cells[6].Value.ToString()), int.Parse(row.Cells[8].Value.ToString()), row.Cells[9].Value.ToString());
                }
                A.SetCertifiedBy(AID, CertifiedBX.Text);
                reference.RefreshAttendance();
                this.Close();
            }
        }
        private void DaysGRD_CellEnter(object sender, DataGridViewCellEventArgs e) {
            if (DaysGRD.Rows[DaysGRD.CurrentCell.RowIndex].Cells[DaysGRD.CurrentCell.ColumnIndex].ReadOnly == true) SendKeys.Send("{Tab}");
        }
        #endregion

        #region Data Refresh and Validation
        private bool DataValidation() {
            bool ret = true;
            if (CertifiedBX.Text.Equals("")) {
                CertifiedTLTP.ToolTipTitle = "Certification";
                CertifiedTLTP.Show("Who certified this attendanca?", CertifiedBX);
                ret = false;
            }
            return ret;
        }
        
        private void RefreshData() {
            if (A.GetAttendance().Rows.Count > 0) {
                foreach (DataRow row in A.GetAttendance().Rows) {
                    DaysGRD.Rows.Add(row[0], row[2], row[5].ToString().Split(':')[0], ":", row[5].ToString().Split(':')[1].Split(' ')[0], row[5].ToString().Split(':')[1].Split(' ')[1], row[6].ToString().Split(':')[0], ":", row[6].ToString().Split(':')[1].Split(' ')[0], row[6].ToString().Split(':')[1].Split(' ')[1], "0");
                }
                DaysGRD.CurrentCell = DaysGRD.Rows[0].Cells[1];
            }
        }
        #endregion

    }
}
