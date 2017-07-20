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
        Payroll pay;
        public Shadow refer;
        DataGridViewRow currentrow;

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
            currentrow = EmpListGRD.Rows[0];

            foreach (DataGridViewRow row in EmpListGRD.Rows) {
                if (row.Cells[0].Value.ToString().Equals(GID.ToString())) {
                    row.Selected = true;
                    currentrow = row;
                    row.DefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                    if (row.Index > 4) EmpListGRD.FirstDisplayedScrollingRowIndex = (row.Index - 4);
                    else EmpListGRD.FirstDisplayedScrollingRowIndex = 0;
                    break;
                }
            }
        }


        #region Popups  

        private void ShowPopup(ContextMenuStrip CMS, Control cntrl) {
            CMS.Show(cntrl, new Point((int)((cntrl.Size.Width)*2 / 3), 0));
        }

        private void HidePop(ContextMenuStrip CMS) {
            CMS.Hide();
        }
        private void MondaysLBL_MouseEnter(object sender, EventArgs e) {
            ShowPopup(MondaySaturday, OMondaysLBL);
        }

        private void MondaysLBL_MouseLeave(object sender, EventArgs e) {
            HidePop(MondaySaturday);
        }


        private void OSundays_MouseEnter(object sender, EventArgs e) {
            ShowPopup(Sundays, OSundays);
        }

        private void OSundays_MouseLeave(object sender, EventArgs e) {
            HidePop(Sundays);
        }

        private void RMondays_MouseEnter(object sender, EventArgs e) {
            ShowPopup(RMond, RMondays);
        }

        private void RMondays_MouseLeave(object sender, EventArgs e) {
            HidePop(RMond);
        }

        private void RSundays_MouseEnter(object sender, EventArgs e) {
            ShowPopup(RSunds, RSundays);
        }

        private void RSundays_MouseLeave(object sender, EventArgs e) {
            HidePop(RSunds);
        }

        private void SMondays_MouseEnter(object sender, EventArgs e) {
            ShowPopup(SMond, SMondays);
        }

        private void SMondays_MouseLeave(object sender, EventArgs e) {
            HidePop(SMond);
        }

        private void SSundays_MouseEnter(object sender, EventArgs e) {
            ShowPopup(SSunds, SSundays);
        }

        private void SSundays_MouseLeave(object sender, EventArgs e) {
            HidePop(SSunds);
        }
        #endregion


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
        
        private void EmpListGRD_CellEnter(object sender, DataGridViewCellEventArgs e) {
            try {
                currentrow.DefaultCellStyle.Font = new Font("Segoe UI", 10);
                EmpListGRD.SelectedRows[0].DefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                currentrow = EmpListGRD.SelectedRows[0];
                GID = int.Parse(EmpListGRD.SelectedRows[0].Cells[0].Value.ToString());
            }
            catch { }
            LoadDetails();
        }

        private void LoadDetails() {
            pay = new Payroll(GID);
            pay.ComputeHours();
            pay.ComputeGrossPay();
            UpdatePopUp("nsu_proper_day_normal", "nsu_overtime_day_normal", "nsu_proper_night_normal", "nsu_overtime_night_normal", MondaySaturday);
            UpdatePopUp("sun_proper_day_normal", "sun_overtime_day_normal", "sun_proper_night_normal", "sun_overtime_night_normal", Sundays);
            UpdatePopUp("nsu_proper_day_special", "nsu_overtime_day_special", "nsu_proper_night_special", "nsu_overtime_night_special", RMond);
            UpdatePopUp("sun_proper_day_special", "sun_overtime_day_special", "sun_proper_night_special", "sun_overtime_night_special", RSunds);
            UpdatePopUp("nsu_proper_day_regular", "nsu_overtime_day_regular", "nsu_proper_night_regular", "nsu_overtime_night_regular", SMond);
            UpdatePopUp("sun_proper_day_regular", "sun_overtime_day_regular", "sun_proper_night_regular", "sun_overtime_night_regular", SSunds);
            UpdateLBL("normal_nsu", OMLBL);
            UpdateLBL("normal_sun", OSLBL);
            UpdateLBL("regular_nsu", RMLBL);
            UpdateLBL("regular_sun", RSLBL);
            UpdateLBL("special_nsu", SMLBL);
            UpdateLBL("special_sun", SSLBL);
            UpdateLBL("normal", OTLBL);
            UpdateLBL("regular", RTLBL);
            UpdateLBL("special", STLBL);
            UpdateLBL("total", WorkTotalLBL);
        }

        private void UpdatePopUp(String Day, String DayO, String Night, String NightO, ContextMenuStrip CMS) {
            HourCostPair e;
            e = pay.hc[Day];
            CMS.Items[1].Text = "₱ " + e.cost + " x " + e.hour + " hr(s)" + " = ₱ " + e.total;

            e = pay.hc[DayO];
            CMS.Items[3].Text = "₱ " + e.cost + " x " + e.hour + " hr(s)" + " = ₱ " + e.total;

            e = pay.hc[Night];
            CMS.Items[5].Text = "₱ " + e.cost + " x " + e.hour + " hr(s)" + " = ₱ " + e.total;

            e = pay.hc[NightO];
            CMS.Items[7].Text = "₱ " + e.cost + " x " + e.hour + " hr(s)" + " = ₱ " + e.total;
        }

        private void UpdateLBL(String key, Label lbl) {
            HourCostPair e;
            e = pay.TotalSummary[key];
            lbl.Text = "₱ " + e.total.ToString();
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
