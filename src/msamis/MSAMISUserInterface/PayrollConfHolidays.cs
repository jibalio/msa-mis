using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

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

        private void AddBTN_Click(object sender, EventArgs e) {
            if (DataVal()) {
                var type = 1;
                if (SpecialBTN.Checked) type = 2;

                if (AddBTN.Text.Equals("ADD")) {
                    Holiday.AddHoliday(HoldaysCLNDR.SelectionRange, DescBX.Text, type);
                }
                else {
                    Holiday.EditHoliday(int.Parse(HolidaysGRD.SelectedRows[0].Cells[0].Value.ToString()), DescBX.Text,
                        type);
                    CancelBTN.PerformClick();
                }
                LoadPage();
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
            if (HolidaysGRD.SelectedRows.Count > 0) {
                _start = new DateTime(int.Parse(HolidaysGRD.SelectedRows[0].Cells[1].Value.ToString().Split('/')[2]),
                    int.Parse(HolidaysGRD.SelectedRows[0].Cells[1].Value.ToString().Split('/')[0]),
                    int.Parse(HolidaysGRD.SelectedRows[0].Cells[1].Value.ToString().Split('/')[1]));
                _end = new DateTime(int.Parse(HolidaysGRD.SelectedRows[0].Cells[2].Value.ToString().Split('/')[2]),
                    int.Parse(HolidaysGRD.SelectedRows[0].Cells[2].Value.ToString().Split('/')[0]),
                    int.Parse(HolidaysGRD.SelectedRows[0].Cells[2].Value.ToString().Split('/')[1]));
                SpecialBTN.Checked = HolidaysGRD.SelectedRows[0].Cells[2].Value.ToString().Equals("Special");
                DateLBL.Text = _start.ToShortDateString() + " - " + _end.ToShortDateString();
                DescBX.Text = HolidaysGRD.SelectedRows[0].Cells[3].Value.ToString();
            }
            HoldaysCLNDR.Enabled = false;
            AddBTN.Text = "SAVE";
            CloseBTN.Visible = false;
            RemoveBTN.Visible = false;
            EditBTN.Visible = false;
            CancelBTN.Visible = true;
        }

        private void CancelBTN_Click(object sender, EventArgs e) {
            AddBTN.Text = "ADD";
            DateLBL.Text = "Please choose a date/dates";
            DescBX.Text = "";
            SpecialBTN.Checked = false;
            RegularBTN.Checked = false;
            HoldaysCLNDR.Enabled = true;
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
            Refer.Hide();
        }

        #region Form Properties and Load

        public PayrollConfHolidays() {
            InitializeComponent();
            Opacity = 0;
        }

        private void Sched_ConfHolidays_Load(object sender, EventArgs e) {
            Location = new Point(Location.X + 150, Location.Y);
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
            HolidaysGRD.DataSource = Holiday.GetHolidays();
            HolidaysGRD.Columns[0].Visible = false;
            HolidaysGRD.Columns[1].HeaderText = "START DATE";
            HolidaysGRD.Columns[1].Width = 110;
            HolidaysGRD.Columns[2].HeaderText = "START END";
            HolidaysGRD.Columns[2].Width = 110;
            HolidaysGRD.Columns[3].HeaderText = "DESCRIPTION";
            HolidaysGRD.Columns[3].Width = 160;
            HolidaysGRD.Columns[4].HeaderText = "TYPE";
            HolidaysGRD.Columns[4].Width = 80;

            var dts = new List<DateTime>();

            foreach (DataGridViewRow row in HolidaysGRD.Rows)
                if (row.Cells[1].Value.ToString().Equals(row.Cells[2].Value.ToString())) {
                    dts.Add(new DateTime(int.Parse(row.Cells[1].Value.ToString().Split('/')[2]),
                        int.Parse(row.Cells[1].Value.ToString().Split('/')[0]),
                        int.Parse(row.Cells[1].Value.ToString().Split('/')[1])));
                }
                else {
                    var count = int.Parse(row.Cells[2].Value.ToString().Split('/')[1]) -
                                int.Parse(row.Cells[1].Value.ToString().Split('/')[1]);
                    for (var i = 0; i < count + 1; i++)
                        dts.Add(new DateTime(int.Parse(row.Cells[1].Value.ToString().Split('/')[2]),
                            int.Parse(row.Cells[1].Value.ToString().Split('/')[0]),
                            int.Parse(row.Cells[1].Value.ToString().Split('/')[1]) + i));
                }
            HoldaysCLNDR.BoldedDates = dts.ToArray();
        }

        #endregion
    }
}