﻿using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace MSAMISUserInterface {
    public partial class PayrollConfigRates : Form {
        private Label _curLabelCon;
        private Label _currentLabel;

        private Panel _currentPanel;
        private Panel _currentSubPanel;
        public Shadow Refer;

        #region Form Load and Intialization

        public PayrollConfigRates() {
            InitializeComponent();
            Opacity = 0;
        }

        private void Payroll_ConfigSSS_Load(object sender, EventArgs e) {
            FadeTMR.Start();
            _currentPanel = BasicPagePNL;
            _currentSubPanel = BasicPNL;
            _currentLabel = BasicLbl;
            _curLabelCon = BasicCon;
            LoadBasicPayPage();
        }

        private void FadeTMR_Tick(object sender, EventArgs e) {
            Opacity += 0.2;
            if (Opacity >= 1) FadeTMR.Stop();
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            Close();
        }


        private void CloseBTN_MouseEnter(object sender, EventArgs e) {
            CloseBTN.ForeColor = Color.White;
        }

        private void CloseBTN_MouseLeave(object sender, EventArgs e) {
            CloseBTN.ForeColor = RatesPNL.BackColor;
        }

        private void Payroll_ConfigSSS_FormClosing(object sender, FormClosingEventArgs e) {
            if ((!CloseBTN.Visible && rylui.RylMessageBox.ShowDialog("You are still editing. Any unsaved changes will be lost.\nAre you sure you want to close this page?", "Cancel Changes?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) || CloseBTN.Visible)
            Refer.Close();
        }

        #endregion

        #region Form Navigation

        private void SSSPnl_Enter(object sender, EventArgs e) {
            SelectedColor(SSSPnl, SSSlbl, SSScon);
        }

        private void SSSPnl_Leave(object sender, EventArgs e) {
            if (!SSSPagePNL.Visible) DefaultColor(SSSPnl, SSSlbl, SSScon);
        }

        private void TaxPnl_MouseEnter(object sender, EventArgs e) {
            SelectedColor(TaxPnl, TaxLbl, TaxConLbl);
        }

        private void TaxPnl_MouseLeave(object sender, EventArgs e) {
            if (!WithPagePNL.Visible) DefaultColor(TaxPnl, TaxLbl, TaxConLbl);
        }


        private void BasicPNL_MouseEnter(object sender, EventArgs e) {
            SelectedColor(BasicPNL, BasicLbl, BasicCon);
        }

        private void BasicPNL_MouseLeave(object sender, EventArgs e) {
            if (!BasicPagePNL.Visible) DefaultColor(BasicPNL, BasicLbl, BasicCon);
        }

        private void DefaultColor(Control pnl, Control lbl, Control con) {
            pnl.BackColor = RatesPNL.BackColor;
            lbl.ForeColor = Color.White;
            con.ForeColor = Color.White;
        }

        private void SelectedColor(Control pnl, Control lbl, Control con) {
            pnl.BackColor = Color.White;
            lbl.ForeColor = RatesPNL.BackColor;
            con.ForeColor = RatesPNL.BackColor;
        }

        private void ChangePage(Panel newP, Panel npnl, Label nlbl, Label ncon) {
            _currentPanel.Hide();
            newP.Show();

            DefaultColor(_currentSubPanel, _currentLabel, _curLabelCon);
            SelectedColor(npnl, nlbl, ncon);


            _currentPanel = newP;
            _currentSubPanel = npnl;
            _currentLabel = nlbl;
            _curLabelCon = ncon;
        }

        private void BasicPNL_Click(object sender, EventArgs e) {
            ChangePage(BasicPagePNL, BasicPNL, BasicLbl, BasicCon);
            LoadBasicPayPage();
        }

        private void SSSPnl_Click(object sender, EventArgs e) {
            ChangePage(SSSPagePNL, SSSPnl, SSSlbl, SSScon);
            LoadSssPage();
        }

        private void TaxPnl_Click(object sender, EventArgs e) {
            ChangePage(WithPagePNL, TaxPnl, TaxLbl, TaxConLbl);
            LoadTaxPage();
        }

        #endregion

        #region Basic Pay rates

        private void LoadBasicPayPage() {
            BasicPayGRD.DataSource = Payroll.GetBasicPayHistory();
            BasicPayGRD.Columns[0].Visible = false;
            BasicPayGRD.Columns[1].HeaderText = "AMOUNT";
            BasicPayGRD.Columns[1].Width = 100;
            BasicPayGRD.Columns[2].HeaderText = "STARTING DATE";
            BasicPayGRD.Columns[2].Width = 130;
            BasicPayGRD.Columns[3].HeaderText = "ENDING DATE";
            BasicPayGRD.Columns[3].Width = 130;
            BasicPayGRD.Columns[4].HeaderText = "STATUS";
            BasicPayGRD.Columns[4].Width = 100;

            BasicPayGRD.Sort(BasicPayGRD.Columns[2], ListSortDirection.Descending);

            if (Payroll.GetCurrentBasicPay().Length == 7)
                CBasicPay.Text = "₱ " + Payroll.GetCurrentBasicPay().Insert(1, " ");
            else CBasicPay.Text = "₱ " + Payroll.GetCurrentBasicPay();
        }

        private void AdjustBTN_Click(object sender, EventArgs e) {
            AdjustPNL.Visible = true;
            CurrentPNL.Visible = false;
            BasicPayGRD.Size = new Size(475, 260);
            AdjustMBX.Text = "0 000.00";
            CloseBTN.Visible = false;
            SSSPnl.Visible = false;
            TaxPnl.Visible = false;
        }

        private void CancelBTN_Click(object sender, EventArgs e) {
            AdjustPNL.Visible = false;
            CurrentPNL.Visible = true;
            BasicPayGRD.Size = new Size(475, 310);

            CloseBTN.Visible = true;
            SSSPnl.Visible = true;
            TaxPnl.Visible = true;
        }

        private void SaveBTN_Click(object sender, EventArgs e) {
            if (DataVal()) {
                Payroll.AddBasicPay(StartDate.Value,
                    float.Parse(AdjustMBX.Text.Substring(2).Replace(" ", string.Empty)));
                LoadBasicPayPage();
                CancelBTN.PerformClick();
            }
        }

        private bool DataVal() {
            var ret = true;

            if (double.Parse(AdjustMBX.Text.Substring(2).Replace(" ", string.Empty)).Equals(0.0)) {
                InputTLTP.ToolTipTitle = "Adjustment Value";
                InputTLTP.Show("Please specify a valid value", AdjustMBX, 2000);
                ret = false;
            }
            return ret;
        }

        private void AdjustMBX_TextChanged(object sender, EventArgs e) {
            InputTLTP.Hide(AdjustMBX);
        }

        #endregion

        #region SSS Rates

        private void LoadSssPage() {
            SSSDateCMBX.Items.Clear();
            foreach (DataRow row in Payroll.GetSssContribList().Rows) { 
                var effective = DateTime.Parse(row["date_effective"].ToString()).ToString("MMMM dd, yyyy");
                var dissolved = row["date_dissolved"].Equals("-1") ? "Current" : DateTime.Parse(row["date_dissolved"].ToString()).ToString("MMMM dd, yyyy") ;
                SSSDateCMBX.Items.Add(new ComboBoxSss(int.Parse(row["contrib_id"].ToString()), effective  , dissolved));
            }
            if (SSSDateCMBX.Items.Count > 0) SSSDateCMBX.SelectedIndex = 0;
            SssLoadTable();
        }

        private void SssLoadTable() {
            if (SSSDateCMBX.Items.Count > 0) {
                SSSGRD.Rows.Clear();
                if (Payroll.GetSssContribTable(((ComboBoxSss) SSSDateCMBX.SelectedItem).Id).Rows.Count > 0){
                foreach (DataRow row in Payroll.GetSssContribTable(((ComboBoxSss)SSSDateCMBX.SelectedItem).Id).Rows)
                    SSSGRD.Rows.Add(double.Parse(row[0].ToString()).ToString("N2"),
                        double.Parse(row[1].ToString()).ToString("N2"), "-",
                        double.Parse(row[2].ToString()).ToString("N2"),
                        "", double.Parse(row[3].ToString()).ToString("N2"));
                }
                SSSGRD.CurrentCell = SSSGRD.Rows[0].Cells[1];
            }
        }

        private string _currentval;

        private void SSSGRD_CellEnter(object sender, DataGridViewCellEventArgs e) {
            if (SSSGRD.Rows[SSSGRD.CurrentCell.RowIndex].Cells[SSSGRD.CurrentCell.ColumnIndex].ReadOnly)
                SendKeys.Send("{Tab}");
            _currentval = SSSGRD.CurrentCell.Value.ToString();
        }

        private void SssDataVal() {
            SSSPopup.Hide(SSSGRD);
            if (!_currentval.Equals(SSSGRD.CurrentCell.Value.ToString())) {
                double value;
                if (!double.TryParse(SSSGRD.CurrentCell.Value.ToString(), out value)) {
                    SssShowToolTip("Enter a valid number");
                } else {
                    SSSGRD.CurrentCell.Value = value.ToString("N2");
                    if ( 
                        SSSGRD.CurrentCell.ColumnIndex == 3 &&
                        double.Parse(SSSGRD.CurrentCell.Value.ToString()) <=
                        double.Parse(SSSGRD.Rows[SSSGRD.CurrentCell.RowIndex].Cells[1].Value.ToString())) {
                        SssShowToolTip("Please enter a value higher than the starting range");

                    } else if (
                          SSSGRD.CurrentCell.RowIndex != SSSGRD.Rows.Count - 1 &&
                          SSSGRD.CurrentCell.ColumnIndex == 3 &&
                          double.Parse(SSSGRD.CurrentCell.Value.ToString()) >= double.Parse(SSSGRD
                              .Rows[SSSGRD.CurrentCell.RowIndex + 1].Cells[1].Value.ToString())) {
                        SssShowToolTip("Please enter a value lower than the next range");
                    } else if (
                          SSSGRD.CurrentCell.RowIndex != 0 &&
                          !_currentval.Equals("00.00") &&
                          SSSGRD.CurrentCell.ColumnIndex == 1 &&
                          double.Parse(SSSGRD.CurrentCell.Value.ToString()) <= double.Parse(SSSGRD
                              .Rows[SSSGRD.CurrentCell.RowIndex - 1].Cells[3].Value.ToString())) {
                        SssShowToolTip("Please enter a value higher than the previous range");
                    } else if (
                          SSSGRD.CurrentCell.ColumnIndex == 1 && !SSSGRD.Rows[SSSGRD.CurrentCell.RowIndex].Cells[3].Value
                              .ToString().Equals("00.00") &&
                          double.Parse(SSSGRD.CurrentCell.Value.ToString()) >=
                          double.Parse(SSSGRD.Rows[SSSGRD.CurrentCell.RowIndex].Cells[3].Value.ToString())) {
                        SssShowToolTip("Please enter a value lower than the ending range");
                    } else if (
                        SSSGRD.CurrentCell.ColumnIndex == 5 && SSSGRD.CurrentCell.RowIndex != 0 &&
                            double.Parse(SSSGRD.CurrentCell.Value.ToString()) <=
                            double.Parse(SSSGRD.Rows[SSSGRD.CurrentCell.RowIndex - 1].Cells[5].Value.ToString())) {
                        SssShowToolTip("Please enter a value higher than the previous amount");
                    } else if (
                    SSSGRD.CurrentCell.ColumnIndex == 5 && SSSGRD.CurrentCell.RowIndex != SSSGRD.Rows.Count - 1 &&
                        double.Parse(SSSGRD.CurrentCell.Value.ToString()) >=
                        double.Parse(SSSGRD.Rows[SSSGRD.CurrentCell.RowIndex + 1].Cells[5].Value.ToString())) {
                        SssShowToolTip("Please enter a value lower than the next amount");
                    } else {
                        if (!InRange())
                        EditingMode(true);
                    }
                }
            }
        }

        private bool InRange() {
            var ret = false;

            if (SSSGRD.CurrentCell.ColumnIndex != 5) 
            foreach (DataGridViewRow row in SSSGRD.Rows) 
                if (row.Index != SSSGRD.CurrentCell.RowIndex) { 
                    var start = double.Parse(row.Cells[1].Value.ToString());
                    var end = double.Parse(row.Cells[3].Value.ToString());
                        if (double.Parse(SSSGRD.CurrentCell.Value.ToString()) >= start &&
                            double.Parse(SSSGRD.CurrentCell.Value.ToString()) <= end) ret = true;
                        }
            if (ret) SssShowToolTip("The value entered is already included in a range \nPlease adjust other ranges to continue");
            return ret;
        }
        
        private void SssShowToolTip(string text) {
            SSSPopup.Show(text,
                SSSGRD,
                new Point(
                    SSSGRD.GetCellDisplayRectangle(SSSGRD.CurrentCell.ColumnIndex,
                        SSSGRD.CurrentCell.RowIndex,
                        true).X + 30,
                    SSSGRD.GetCellDisplayRectangle(SSSGRD.CurrentCell.ColumnIndex,
                        SSSGRD.CurrentCell.RowIndex,
                        true).Y + 20));
            SSSGRD.CurrentCell.Value = _currentval;
        }

        private void SSSGRD_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            SssDataVal();
        }

        private void SSSAddRange_Click(object sender, EventArgs e) {
            SSSGRD.Rows.Add("-1", "00.00", "-", "00.00", "", "00.00");
            EditingMode(true);
        }

        private void SSSRemoveBTN_Click(object sender, EventArgs e) {
            SSSGRD.Rows.Remove(SSSGRD.SelectedRows[0]);
            EditingMode(true);
        }

        private void SSSReset_Click(object sender, EventArgs e) {
            LoadSssPage();
            EditingMode(false);
        }

        private void EditingMode(bool mode) {
            BasicPNL.Visible = !mode;
            TaxPnl.Visible = !mode;
            CloseBTN.Visible = !mode;

            SSSEditPNL.Visible = mode;
            SSSEffectivePNL.Visible = !mode;
            SSSMainPNL.Size = mode ? new Size(478, 430): new Size(478, 470);
        }

        private void SSSSaveBTN_Click(object sender, EventArgs e) {
            Payroll.SaveSssContrib(SSSGRD, SSSDateTimePKR.Value);
            CancelBTN.PerformClick();
        }
        private void SSSGRD_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e) {
            EditingMode(true);
        }

        private void SSSDateCMBX_SelectedIndexChanged(object sender, EventArgs e) {
            SssLoadTable();
        }
        private void SSSEditBTN_Click(object sender, EventArgs e) {
            EditingMode(true);
        }

        #endregion

        #region Withholding Tax

        private void LoadTaxPage() {
            TaxDateCMBX.Items.Clear();
            foreach (DataRow row in Payroll.GetWithTaxContribList().Rows) {
                var effective = DateTime.Parse(row["date_effective"].ToString()).ToString("MMMM dd, yyyy");
                var dissolved = row["date_dissolved"].Equals("-1") ? "Current" : DateTime.Parse(row["date_dissolved"].ToString()).ToString("MMMM dd, yyyy");
                TaxDateCMBX.Items.Add(new ComboBoxSss(int.Parse(row["contrib_id"].ToString()), effective, dissolved));
            }
            if (TaxDateCMBX.Items.Count > 0) TaxDateCMBX.SelectedIndex = 0;
            LoadTaxTables();
        }

        private void LoadTaxTables() {
            TaxExemptionGRD.Rows.Clear();
            TaxExemptionGRD.ColumnCount = 2;
            foreach (DataRow row in Payroll.GetWithTaxHeaders(((ComboBoxSss) TaxDateCMBX.SelectedItem).Id).Rows) {
                TaxExemptionGRD.Rows.Add(row["wid"], row["value"] + "\n  +" + row["excessmult"] + "% over");
            }
            
            var withTaxBrackets = Payroll.GetWithTaxBrackets(((ComboBoxSss) TaxDateCMBX.SelectedItem).Id);
            TaxExemptionGRD.ColumnCount += withTaxBrackets.Rows.Count / TaxExemptionGRD.Rows.Count;

            var j = 0;
            for (var i = 0;
                i < withTaxBrackets.Rows.Count / TaxExemptionGRD.Rows.Count;
                i++) {
                TaxExemptionGRD.Columns[i+2].HeaderText = withTaxBrackets.Rows[j][1].ToString().ToUpper();
                TaxExemptionGRD.Columns[i + 2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                j += TaxExemptionGRD.Rows.Count;
            }
            
            j = 0;
            for (var i = 0; i < TaxExemptionGRD.ColumnCount-2; i++) {
                for (var k = 0; k < TaxExemptionGRD.Rows.Count; k++) {
                    TaxExemptionGRD.Rows[k].Cells[i+2].Value = withTaxBrackets.Rows[j][2].ToString();
                    j++;
                }
            }
        }

        private void TaxExemptionGRD_CellEnter(object sender, DataGridViewCellEventArgs e) {
            _currentval = TaxExemptionGRD.CurrentCell.Value.ToString();
        }

        private void TaxDataVal() {
            if (!_currentval.Equals(TaxExemptionGRD.CurrentCell.Value.ToString())) {
                double value;
                if (!double.TryParse(TaxExemptionGRD.CurrentCell.Value.ToString(), out value)) {
                    TaxShowToolTip("Enter a valid number");
                } else {
                    TaxExemptionGRD.CurrentCell.Value = value.ToString("N2");
                    TaxEditingMode(true);
                }
            }
        }

        private void TaxShowToolTip(string text) {
            SSSPopup.Show(text,
                TaxExemptionGRD,
                new Point(
                    TaxExemptionGRD.GetCellDisplayRectangle(TaxExemptionGRD.CurrentCell.ColumnIndex,
                        TaxExemptionGRD.CurrentCell.RowIndex,
                        true).X + 50,
                    TaxExemptionGRD.GetCellDisplayRectangle(TaxExemptionGRD.CurrentCell.ColumnIndex,
                        TaxExemptionGRD.CurrentCell.RowIndex,
                        true).Y + 40), 1500);
            TaxExemptionGRD.CurrentCell.Value = _currentval;
        }

        private void TaxEditingMode(bool mode) {
            TaxDatePNL.Visible = !mode;
            CloseBTN.Visible = !mode;
            SSSPnl.Visible = !mode;
            BasicPNL.Visible = !mode;
            TaxMainPNL.Size = mode ? new Size(487, 385 + 50) : new Size(487, 475);
        }

        private void TaxCancelBTN_Click(object sender, EventArgs e) {
            TaxEditingMode(false);
            LoadTaxPage();
        }

        private void TaxRemoveExBTN_Click(object sender, EventArgs e) {
            TaxExemptionGRD.Rows.RemoveAt(TaxExemptionGRD.SelectedRows[0].Index);
            TaxExemptionGRD.ClearSelection();
        }

        private void TaxExemptionGRD_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            TaxDataVal();
        }

        private void TaxEditBTN_Click(object sender, EventArgs e) {
            TaxEditingMode(true);
        }



        #endregion

        private void TaxAddExBTN_Click(object sender, EventArgs e) {
            TaxMainPNL.Visible = false;
            TaxEditingPNL.Visible = false;
            TaxExcemptPNL.Visible = true;
        }

        private void TaxExCancelBTN_Click(object sender, EventArgs e) {
            TaxMainPNL.Visible = true;
            TaxEditingPNL.Visible = true;
            TaxExcemptPNL.Visible = false;
        }

        private void TaxExSaveBTN_Click(object sender, EventArgs e) {
            TaxExemptionGRD.Rows.Add(0, TaxNewExemptBX.Value + "\n  " + TaxBracketMSTXTBX.Text);
            for (var k = 0; k < TaxExemptionGRD.ColumnCount-2; k++) {
                TaxExemptionGRD.Rows[TaxExemptionGRD.RowCount-1].Cells[k+2].Value = "00.00";
            }
            TaxExCancelBTN.PerformClick();
        }
    }
}