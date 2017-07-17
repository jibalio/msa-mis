using ryldb.sqltools;
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
    public partial class Payroll_ConfHolidays : Form {
        public Shadow refer;

        #region Form Properties and Load
        public Payroll_ConfHolidays() {
            InitializeComponent();
            this.Opacity = 0;
        }

        private void Sched_ConfHolidays_Load(object sender, EventArgs e) {
            this.Location = new Point(this.Location.X + 150, this.Location.Y);
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

            List<DateTime> dts = new List<DateTime>();

            foreach (DataGridViewRow row in HolidaysGRD.Rows) {
                if (row.Cells[1].Value.ToString().Equals(row.Cells[2].Value.ToString())) {
                    dts.Add(new DateTime(int.Parse(row.Cells[1].Value.ToString().Split('/')[2]), int.Parse(row.Cells[1].Value.ToString().Split('/')[0]), int.Parse(row.Cells[1].Value.ToString().Split('/')[1])));
                } else {
                    int count = int.Parse(row.Cells[2].Value.ToString().Split('/')[1]) - int.Parse(row.Cells[1].Value.ToString().Split('/')[1]);
                    for (int i = 0; i < count+1; i++) dts.Add(new DateTime(int.Parse(row.Cells[1].Value.ToString().Split('/')[2]), int.Parse(row.Cells[1].Value.ToString().Split('/')[0]), int.Parse(row.Cells[1].Value.ToString().Split('/')[1])+i));
                }
            }
           HoldaysCLNDR.BoldedDates = dts.ToArray();

        }
        #endregion

        private void HoldaysCLNDR_DateSelected(object sender, DateRangeEventArgs e) {
            if (HoldaysCLNDR.SelectionRange.Start.Day - HoldaysCLNDR.SelectionRange.End.Day != 0) DateLBL.Text = HoldaysCLNDR.SelectionRange.Start.ToShortDateString() + " - " + HoldaysCLNDR.SelectionRange.End.ToShortDateString();
            else DateLBL.Text = HoldaysCLNDR.SelectionRange.Start.ToShortDateString();
        }

        private void AddBTN_Click(object sender, EventArgs e) {
            if (DataVal()) {
                if (AddBTN.Text.Equals("ADD")) Holiday.AddHoliday(HoldaysCLNDR.SelectionRange, DescBX.Text);
                else { Holiday.EditHoliday(int.Parse(HolidaysGRD.SelectedRows[0].Cells[0].Value.ToString()), DescBX.Text); CancelBTN.PerformClick(); }
                LoadPage();
            }
        }

        private bool DataVal() {
            bool ret = true;

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

        DateTime start, end;

        private void EditBTN_Click(object sender, EventArgs e) {
            if (HolidaysGRD.SelectedRows.Count > 0) {
                start = new DateTime(int.Parse(HolidaysGRD.SelectedRows[0].Cells[1].Value.ToString().Split('/')[2]), int.Parse(HolidaysGRD.SelectedRows[0].Cells[1].Value.ToString().Split('/')[0]), int.Parse(HolidaysGRD.SelectedRows[0].Cells[1].Value.ToString().Split('/')[1]));
                end = new DateTime(int.Parse(HolidaysGRD.SelectedRows[0].Cells[2].Value.ToString().Split('/')[2]), int.Parse(HolidaysGRD.SelectedRows[0].Cells[2].Value.ToString().Split('/')[0]), int.Parse(HolidaysGRD.SelectedRows[0].Cells[2].Value.ToString().Split('/')[1]));

                DateLBL.Text = start.ToShortDateString() + " - " + end.ToShortDateString();
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
            refer.Hide();
        }

        private void HolidaysGRD_CellClick(object sender, DataGridViewCellEventArgs e) {
            
        }
    }
}
