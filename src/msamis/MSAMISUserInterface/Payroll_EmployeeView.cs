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
    public partial class Payroll_EmployeeView : Form {
        public int GID { get; set; }
        public MainForm reference;

        public Shadow refer;

        public Payroll_EmployeeView() {
            InitializeComponent();
            this.Opacity = 0;
        }

        Label currentLBL;
        Panel currentPNL;

        private void Payroll_EmployeeView_Load(object sender, EventArgs e) {
            FadeTMR.Start();
            currentLBL = OverviewLBL;
            currentPNL = OverviewPNL;
            OverviewPNL.Visible = true;
            AdjPNL.Visible = false;
            OverviewPNL.Visible =true;

            RefreshPayrollList();
        }
        public void RefreshPayrollList() {
            EmpListGRD.DataSource = Payroll.GetGuardsPayrollMinimal();
            EmpListGRD.Columns[0].Visible = false;
            EmpListGRD.Columns[1].Width = 320;
            EmpListGRD.Sort(EmpListGRD.Columns[1], ListSortDirection.Ascending);
            

            foreach (DataGridViewRow row in EmpListGRD.Rows) {
                if (row.Cells[1].Value.ToString().Equals("")) {
                    row.Visible = false;
                } else if (row.Cells[0].Value.ToString().Equals(GID.ToString())) {
                    row.Selected = true;
                    currentrow = row;
                    row.DefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                    if (row.Index > 4) EmpListGRD.FirstDisplayedScrollingRowIndex = (row.Index - 4);
                    else EmpListGRD.FirstDisplayedScrollingRowIndex = 0;
                    break;
                }
            }
        }

        private void ChangePanel(Label newL, Panel newP) {
            currentLBL.ForeColor = Color.Gray;
            currentPNL.Visible = false;
            newL.ForeColor = Color.FromArgb(53, 64, 82);
            newP.Visible = true;
            currentLBL = newL;
            currentPNL = newP;
        }

        private void FadeTMR_Tick(object sender, EventArgs e) {
            this.Opacity += 0.2;
            if (this.Opacity >= 1) { FadeTMR.Stop(); }
        }

        private void Payroll_EmployeeView_FormClosing(object sender, FormClosingEventArgs e) {
            refer.Hide();
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void BonusesLBL_Click(object sender, EventArgs e) {
            ChangePanel(AdjustmentsLBL, AdjPNL);
        }

        private void DeductionsLBL_Click(object sender, EventArgs e) {
        }

        private void AdjLBL_Click(object sender, EventArgs e) {
            ChangePanel(OverviewLBL, OverviewPNL);
        }

        private void BonusesLBL_MouseEnter(object sender, EventArgs e) {
            AdjustmentsLBL.ForeColor = Color.FromArgb(53, 64, 82);
        }

        private void AdjLBL_MouseEnter(object sender, EventArgs e) {
            OverviewLBL.ForeColor = Color.FromArgb(53, 64, 82);
        }

        private void BonusesLBL_MouseLeave(object sender, EventArgs e) {
            if(!AdjPNL.Visible) AdjustmentsLBL.ForeColor = Color.Gray;
        }

        private void AdjLBL_MouseLeave(object sender, EventArgs e) {
            if(!OverviewPNL.Visible) OverviewLBL.ForeColor = Color.Gray;
        }

        private void CloseBTN_MouseEnter(object sender, EventArgs e) {
            CloseBTN.ForeColor = Color.White;
        }

        private void CloseBTN_MouseLeave(object sender, EventArgs e) {
            CloseBTN.ForeColor = Color.FromArgb(53, 64, 82);
        }

        private void BonusAddBTN_Click_1(object sender, EventArgs e) {
            Payroll_AddAdjustments view = new Payroll_AddAdjustments();
            view.PID = this.GID;
            view.Location = new Point(this.Location.X + 350, this.Location.Y);
            view.ShowDialog();
        }
        DataGridViewRow currentrow;
        private void EmpListGRD_CellEnter(object sender, DataGridViewCellEventArgs e) {
            try {
                currentrow.DefaultCellStyle.Font = new Font("Segoe UI", 10);
                EmpListGRD.SelectedRows[0].DefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                currentrow = EmpListGRD.SelectedRows[0];
                GID = int.Parse(EmpListGRD.SelectedRows[0].Cells[0].Value.ToString());
                LoadDetails();
            }
            catch { }
        }

        private void LoadDetails() {

        }
        private void EmpListGRD_MouseEnter(object sender, EventArgs e) {
            int first = EmpListGRD.FirstDisplayedScrollingRowIndex;
            EmpListGRD.ScrollBars = ScrollBars.Vertical;
            EmpListGRD.FirstDisplayedScrollingRowIndex = first;
        }

        private void EmpListGRD_MouseLeave(object sender, EventArgs e) {
            int first = EmpListGRD.FirstDisplayedScrollingRowIndex;
            EmpListGRD.ScrollBars = ScrollBars.None;
            EmpListGRD.FirstDisplayedScrollingRowIndex = first;
        }
    }
}
