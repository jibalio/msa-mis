using System;
using System.Collections.Generic;
using System.Windows.Forms;
using rylui;

namespace MSAMISUserInterface {
    public partial class PayrollConfHolidays : Form {
        private DateTime _start, _end;
        public Shadow Refer;

        private void HoldaysCLNDR_DateSelected(object sender, DateRangeEventArgs e) {
            if (HoldaysCLNDR.SelectionRange.Start.Day - HoldaysCLNDR.SelectionRange.End.Day != 0)
                DateLBL.Text = HoldaysCLNDR.SelectionRange.Start.ToShortDateString() + " - " +
                               HoldaysCLNDR.SelectionRange.End.ToShortDateString();
            else DateLBL.Text = HoldaysCLNDR.SelectionRange.Start.ToShortDateString();
        }

        private const int CsDropshadow = 0x20000;

        protected override CreateParams CreateParams {
            get {
                var cp = base.CreateParams;
                cp.ClassStyle |= CsDropshadow;
                return cp;
            }
        }

        private void AddBTN_Click(object sender, EventArgs e) {
            if (DataVal()) {
                var type = Enumeration.HolidayType.Regular;
                if (SpecialBTN.Checked) type = Enumeration.HolidayType.Special;
                try {
                    if (AddBTN.Text.Equals("ADD")) {
                        Holiday.AddHoliday(HoldaysCLNDR.SelectionRange, DescBX.Text.Replace("'", string.Empty), type, TransBox.Checked ? 0: 1);
                        DateLBL.Text = "Select date(s)";
                        DescBX.Text = "";
                    }
                    else {
                        Holiday.EditHoliday(int.Parse(HolidaysGRD.SelectedRows[0].Cells[0].Value.ToString()), HoldaysCLNDR.SelectionRange.Start, HoldaysCLNDR.SelectionRange.End,
                            DescBX.Text.Replace("'", string.Empty),
                            type, TransBox.Checked ? 0 : 1);
                        CancelBTN.PerformClick();
                    }
                    LoadPage();
                }
                catch (Exception ex) {
                    ShowErrorBox("Holiday", ex.Message);
                }
            }
        }

        private bool DataVal() {
            var ret = true;

            if (DescBX.Text.Trim(' ').Equals("")) {
                DescTLTP.ToolTipTitle = "Description";
                DescTLTP.Show("Please enter a description", DescBX);
                ret = false;
            }

            if (DateLBL.Text.Equals("Please choose a date/dates")) {
                DateTLTP.ToolTipTitle = "Date";
                DateTLTP.Show("Please choose a date from the calendar", DateLBL);
                ret = false;
            }

            return ret;
        }

        private void EditBTN_Click(object sender, EventArgs e) {
            try {
                if (HolidaysGRD.SelectedRows.Count > 0) {
                    var date = HolidaysGRD.SelectedRows[0].Cells[1].Value.ToString().Split(' ')[0];
                    _start = new DateTime(
                        int.Parse(date.Split('/')[2]),
                        int.Parse(date.Split('/')[0]),
                        int.Parse(date.Split('/')[1]));
                    date = HolidaysGRD.SelectedRows[0].Cells[2].Value.ToString().Split(' ')[0];
                    _end = new DateTime(int.Parse(date.Split('/')[2]),
                        int.Parse(date.Split('/')[0]),
                        int.Parse(date.Split('/')[1]));
                    SpecialBTN.Checked = HolidaysGRD.SelectedRows[0].Cells[4].Value.ToString().Equals("Special");
                    RegularBTN.Checked = !HolidaysGRD.SelectedRows[0].Cells[4].Value.ToString().Equals("Special");
                    DateLBL.Text = _start.ToShortDateString() + " - " + _end.ToShortDateString();
                    DescBX.Text = HolidaysGRD.SelectedRows[0].Cells[3].Value.ToString();
                    TransBox.Checked = HolidaysGRD.SelectedRows[0].Cells[5].Value.ToString().Equals("Fixed");
                }
                HolidaysGRD.Enabled = false;
                AddBTN.Text = "SAVE";
                CloseBTN.Visible = false;
                RemoveBTN.Visible = false;
                EditBTN.Visible = false;
                CancelBTN.Visible = true;
            }
            catch (Exception ex) {
                ShowErrorBox("Holiday", ex.Message);
            }
        }

        private void CancelBTN_Click(object sender, EventArgs e) {
            AddBTN.Text = "ADD";
            DateLBL.Text = "Please choose a date/dates";
            DescBX.Text = "";
            TransBox.Checked = false;
            SpecialBTN.Checked = false;
            RegularBTN.Checked = false;
            HolidaysGRD.Enabled = true;
            RemoveBTN.Visible = true;
            CloseBTN.Visible = true;
            EditBTN.Visible = true;
        }

        private void RemoveBTN_Click(object sender, EventArgs e) {
            if (HolidaysGRD.SelectedRows.Count > 0) {
                Holiday.RemoveHoliday(int.Parse(HolidaysGRD.SelectedRows[0].Cells[0].Value.ToString()));
                LoadPage();
            }
        }

        private void Payroll_ConfHolidays_FormClosing(object sender, FormClosingEventArgs e) {
            if (!CloseBTN.Visible)
                if (RylMessageBox.ShowDialog("Are you sure you want to stop editing? Unsaved changes will be lost.", "Stop Editing?",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) Refer.Close();
                else e.Cancel = true;
            else
                Refer.Close();
        }

        #region Form Properties and Load

        private static void ShowErrorBox(string name, string error) {
            RylMessageBox.ShowDialog("Please try again.\nIf the problem still persist, please contact your administrator. \n\n\nError Message: \n=============================\n" + error + "\n=============================\n", "Error Configuring " + name,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public PayrollConfHolidays() {
            InitializeComponent();
            Opacity = 0;
        }

        private void Sched_ConfHolidays_Load(object sender, EventArgs e) { 
            LoadPage();
            FadeTMR.Start();
        }

        private void FadeTMR_Tick(object sender, EventArgs e) {
            Opacity += 0.2;
            if (Opacity >= 1) FadeTMR.Stop();
        }

        private void CloseBTN_Click(object sender, EventArgs e) {
            Close();
        }

        private void LoadPage() {
            try {
                HolidaysGRD.DataSource = Holiday.GetHolidays();
                HolidaysGRD.Columns[0].Visible = false;
                HolidaysGRD.Columns[1].HeaderText = "START DATE";
                HolidaysGRD.Columns[1].Width = 100;
                HolidaysGRD.Columns[2].HeaderText = "START END";
                HolidaysGRD.Columns[2].Width = 100;
                HolidaysGRD.Columns[3].HeaderText = "DESCRIPTION";
                HolidaysGRD.Columns[3].Width = 110;
                HolidaysGRD.Columns[4].HeaderText = "TYPE";
                HolidaysGRD.Columns[4].Width = 80;
                HolidaysGRD.Columns[5].HeaderText = "FIXED?";
                HolidaysGRD.Columns[5].Width = 70;

                var dts = new List<DateTime>();

                foreach (DataGridViewRow row in HolidaysGRD.Rows)
                    if (row.Cells[1].Value.ToString().Equals(row.Cells[2].Value.ToString())) {
                        var date = row.Cells[1].Value.ToString().Split(' ')[0];
                        dts.Add(DateTime.Parse(date));
                    }
                    else {
                        var count = int.Parse(row.Cells[2].Value.ToString().Split('/')[1]) -
                                    int.Parse(row.Cells[1].Value.ToString().Split('/')[1]);
                        for (var i = 0; i < count + 1; i++) {
                            var date = row.Cells[1].Value.ToString().Split(' ')[0];
                            dts.Add(DateTime.Parse(date).AddDays(i));
                        }
                    }
                HoldaysCLNDR.BoldedDates = dts.ToArray();
                RegularBTN.Checked = true;
            }
            catch (Exception ex) {
                ShowErrorBox("Holiday", ex.Message);
            }
        }

        #endregion
    }
}