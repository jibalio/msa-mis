﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Windows.Forms;

/*TODO: 
    
*/
namespace MSAMISUserInterface {
    public class Payroll {
        #region Adjustement Operationen

        public void GetAdjustments() { }

        #endregion


        #region Fields Definition

        public double Bonuses => thirteen + cola + emerallowance + cashbond;

        // Deductions
        public double Deductions => Sss + PagIbig + PhilHealth + CashAdv + Withtax;

        public double GrossPay => TotalSummary["total"].total + Bonuses;

        public double NetPay {
            get { return GrossPay - Deductions; }
        }
        public int GID;
        // PayrollData Containers
        public HourProcessor TotalHours = new HourProcessor();

        public Dictionary<string, double> rates = new Dictionary<string, double>();
        public Attendance.Period period = Attendance.GetCurrentPayPeriod();
        public double BasicPay = 340.00 / 8;
        public double cashbond;
        public double TaxableIncome;
        public double Excess;
        public static Hours total_old;
        public double Sss, PagIbig, PhilHealth, Withtax, CashAdv;
        public WithTax wt = new WithTax();

        public Dictionary<string, HourCostPair> TotalSummary = new Dictionary<string, HourCostPair> {
            #region + Keys Definition

            {"normal_nsu", new HourCostPair()},
            {"normal_sun", new HourCostPair()},
            {"regular_nsu", new HourCostPair()},
            {"regular_sun", new HourCostPair()},
            {"special_nsu", new HourCostPair()},
            {"special_sun", new HourCostPair()},
            {"special", new HourCostPair()},
            {"normal", new HourCostPair()},
            {"regular", new HourCostPair()},
            {"total", new HourCostPair()}

            #endregion
        };

        public Dictionary<string, HourCostPair> hc = new Dictionary<string, HourCostPair> {
            #region + Keys Definition

            {"nsu_proper_day_normal", new HourCostPair()},
            {"nsu_proper_day_special", new HourCostPair()},
            {"nsu_proper_day_regular", new HourCostPair()},
            {"nsu_proper_night_normal", new HourCostPair()},
            {"nsu_proper_night_special", new HourCostPair()},
            {"nsu_proper_night_regular", new HourCostPair()},
            {"nsu_overtime_day_normal", new HourCostPair()},
            {"nsu_overtime_day_special", new HourCostPair()},
            {"nsu_overtime_day_regular", new HourCostPair()},
            {"nsu_overtime_night_normal", new HourCostPair()},
            {"nsu_overtime_night_special", new HourCostPair()},
            {"nsu_overtime_night_regular", new HourCostPair()},
            {"sun_proper_day_normal", new HourCostPair()},
            {"sun_proper_day_special", new HourCostPair()},
            {"sun_proper_day_regular", new HourCostPair()},
            {"sun_proper_night_normal", new HourCostPair()},
            {"sun_proper_night_special", new HourCostPair()},
            {"sun_proper_night_regular", new HourCostPair()},
            {"sun_overtime_day_normal", new HourCostPair()},
            {"sun_overtime_day_special", new HourCostPair()},
            {"sun_overtime_day_regular", new HourCostPair()},
            {"sun_overtime_night_normal", new HourCostPair()},
            {"sun_overtime_night_special", new HourCostPair()},
            {"sun_overtime_night_regular", new HourCostPair()},

            #endregion
        };

        #endregion Fields Definition

        #region Constructors

        /// <summary>
        /// Creates a payroll object for a specified guard during a specific
        /// date. Use this for manual creation / unapproved payrolls.
        /// </summary>
        /// <param name="GID">Guard ID</param>
        /// <param name="month">Month of payroll</param>
        /// <param name="period">Period of payroll [1/2]</param>
        /// <param name="year">Year of payroll</param>
        public Payroll(int GID, int month, int period, int year) {
            this.GID = GID;
            this.period.period = period;
            this.period.month = month;
            this.period.year = year;
            this._InitRates();
        }
        
        /// <summary>
        /// Creates a payroll object from a DataTable. Use this for already
        /// approved payrolls stored in the database.
        /// </summary>
        /// <param name="dt">DataTable object from payroll query (MySql)</param>
        public Payroll(DataTable dt) {
            
        }

        #endregion

        #region  Computationes

        public void Compute(bool checkthirteen) {
            foreach (var key in hc.Keys.ToList())
                hc[key] = new HourCostPair(TotalHours.GetHourDictionary()[key].TotalHours, BasicPay * rates[key]);
            ComputeTotalSummary();
            ComputeBonuses(checkthirteen);
            ComputeDeductions();
            //MessageBox.Show(SQLTools.SerializeMe(hc));
        }

        public void Compute() {
            Compute(true);
            string a = (_SerializeHours());
            MessageBox.Show(_DeserializeObject(a).ToString());
        }

        public void ComputeHours() {
            var HourIterationDataTable = SQLTools.ExecuteQuery(
                string.Format(@"
                    select dutydetails.did, atid, date, timein, timeout, 
                    ti_hh, ti_mm, ti_period, to_hh, to_mm, to_period
                    from attendance 
                    left join period on period.pid = attendance.pid
                    left join dutydetails on attendance.did = dutydetails.did
                    left join sduty_assignment on sduty_assignment.aid = dutydetails.aid
                    left join guards on guards.gid=sduty_assignment.gid 
                    where period.period = " + period.period + " and month=" + period.month + " and year=" +
                              period.year + @" and guards.gid=" + GID + @"
            ;", GID, period.period, period.year, period.month));
            var HourIterationTotal = new Hours();
            foreach (DataRow dr in HourIterationDataTable.Rows) {
                var ti = dr["date"].ToString().Substring(0, 11) + dr["TimeIn"];
                var to = dr["date"].ToString().Substring(0, 10) + " " + dr["TimeOut"];
                var TimeInDateTime = DateTime.Parse(ti);
                var TimeOutDateTime = DateTime.Parse(to);

                var StartDutyString = dr["date"].ToString().Substring(0, 11) + " " + dr["ti_hh"] + ":" + dr["ti_mm"] +
                                      " " + dr["ti_period"];
                var EndDutyString = dr["date"].ToString().Substring(0, 11) + " " + dr["to_hh"] + ":" + dr["to_mm"] +
                                    " " + dr["to_period"];
                var DutyStart = DateTime.Parse(StartDutyString);
                var DutyEnd = DateTime.Parse(EndDutyString);
                var hp = new HourProcessor(TimeInDateTime, TimeOutDateTime, DutyStart, DutyEnd);
                TotalHours.Add(hp);
            }
        }

        private void ComputeTotalSummary() {
            TotalSummary["normal_nsu"] =
                hc["nsu_proper_day_normal"] +
                hc["nsu_overtime_day_normal"] +
                hc["nsu_proper_night_normal"] +
                hc["nsu_overtime_night_normal"];
            TotalSummary["normal_sun"] =
                hc["sun_proper_day_normal"] +
                hc["sun_overtime_day_normal"] +
                hc["sun_proper_night_normal"] +
                hc["sun_overtime_night_normal"];
            TotalSummary["regular_nsu"] =
                hc["nsu_proper_day_regular"] +
                hc["nsu_overtime_day_regular"] +
                hc["nsu_proper_night_regular"] +
                hc["nsu_overtime_night_regular"];
            TotalSummary["regular_sun"] =
                hc["sun_proper_day_regular"] +
                hc["sun_overtime_day_regular"] +
                hc["sun_proper_night_regular"] +
                hc["sun_overtime_night_regular"];
            TotalSummary["special_sun"] =
                hc["sun_proper_day_special"] +
                hc["sun_overtime_day_special"] +
                hc["sun_proper_night_special"] +
                hc["sun_overtime_night_special"];
            TotalSummary["special_nsu"] =
                hc["nsu_proper_day_special"] +
                hc["nsu_overtime_day_special"] +
                hc["nsu_proper_night_special"] +
                hc["nsu_overtime_night_special"];
            TotalSummary["normal"] =
                hc["nsu_proper_day_normal"] +
                hc["nsu_overtime_day_normal"] +
                hc["nsu_proper_night_normal"] +
                hc["nsu_overtime_night_normal"] +
                hc["sun_proper_day_normal"] +
                hc["sun_overtime_day_normal"] +
                hc["sun_proper_night_normal"] +
                hc["sun_overtime_night_normal"];
            TotalSummary["regular"] =
                hc["nsu_proper_day_regular"] +
                hc["nsu_overtime_day_regular"] +
                hc["nsu_proper_night_regular"] +
                hc["nsu_overtime_night_regular"] +
                hc["sun_proper_day_regular"] +
                hc["sun_overtime_day_regular"] +
                hc["sun_proper_night_regular"] +
                hc["sun_overtime_night_regular"];
            TotalSummary["special"] =
                hc["nsu_proper_day_special"] +
                hc["nsu_overtime_day_special"] +
                hc["nsu_proper_night_special"] +
                hc["nsu_overtime_night_special"] +
                hc["sun_proper_day_special"] +
                hc["sun_overtime_day_special"] +
                hc["sun_proper_night_special"] +
                hc["sun_overtime_night_special"];
            TotalSummary["total"] =
                TotalSummary["special"] + TotalSummary["regular"] + TotalSummary["normal"];
        }

        public double ComputeNet() {
            var e = GrossPay;
            e -= Deductions;
            e += Bonuses;
            return e;
        }

        public double ComputeTaxableIncome() {
            /*  Status
                Do you have any dependents and how many?
                How much is your SSS/Philhealth and PagIbig contributions
                Allowances and other benefits if any
                Copy of the BIR Tax table 
             */
            return GrossPay - Sss - PagIbig - PhilHealth;
        }

        public int contid;

        #region In Genera Calculations

        public void ComputeDeductions() {
            contid = GetSssContribId(new DateTime(period.year, period.month, period.period == 1 ? 1 : 16));
            Sss = ComputeSSS(contid);
            if (period.period == 2) {
                PagIbig = ComputeHDMF();
                PhilHealth = ComputePHIC();
            }
            else {
                PagIbig = 0;
                PhilHealth = 0;
            }

            CashAdv = ComputeCashAdvance();
            TaxableIncome = ComputeTaxableIncome();
            Excess = GrossPay - TaxableIncome;
            Withtax = ComputeWithTax(TaxableIncome, Excess);
        }

        public double thirteen;
        public double cola;
        public double emerallowance;

        public void ComputeBonuses(bool ca) {
            if (ca)
                if (period.month == 12 && period.period == 2) thirteen = ComputeThirteen();
                else thirteen = 0;
            cola = ComputeCola();
            emerallowance = ComputeEmer();
            cashbond = ComputeCashBond();
        }

        public void ComputeBonuses() {
            ComputeBonuses(true);
        }

        #endregion


        public static double ComputeCashBond() {
            return 5000;
        }

        public static double ComputeCashAdvance() {
            return 20;
        }

        public double ComputeWithTax(double Taxable, double Excess) {
            var NumDependents = Guard.GetNumberOfDependents(GID);
            if (NumDependents > 4)
                NumDependents = 4;
            var sm = "s" + NumDependents + "me" + NumDependents;
            var w = new WithTax();
            // Start Paper code
            var prevbracket = 0;
            double prevtaxbracket = 0;
            var dt = SQLTools.ExecuteQuery("Select * from withtax_bracket where estatus='" + sm + "'");
            foreach (DataRow dr in dt.Rows)
                if (double.Parse(dr["bracket"].ToString()) > Taxable &&
                    Taxable > prevtaxbracket) {
                    var dt2 = SQLTools.ExecuteQuery("select * from withtax_value where wid=" +
                                                    (int.Parse(dr["taxid"].ToString()) - 1));

                    w.TaxbaseD = double.Parse(dt2.Rows[0]["value"].ToString());
                    w.excessfactor = int.Parse(dt2.Rows[0]["excessmult"].ToString());
                }
                else {
                    prevtaxbracket = double.Parse(dr["bracket"].ToString());
                    prevbracket++;
                }
            wt.TaxbaseD = w.TaxbaseD;
            wt.excessfactor = w.excessfactor;

            var ___ = Excess * ((double) w.excessfactor / 100);
            wt.total = w.TaxbaseD + Excess * ((double) w.excessfactor / 100);
            wt.ExcessTax = Excess * ((double) w.excessfactor / 100);

            return w.TaxbaseD + Excess * ((double) w.excessfactor / 100);
        }

        public WithTax GetWithholdingTax() {
            return wt;
        }

        public class WithTax {
            public int excessfactor;
            public double ExcessTax;
            public double TaxbaseD;
            public double total;
        }

        public double ComputeSSS(int contrib_id) {
            var ssscontrib = SQLTools.ExecuteQuery($"select * from ssscontrib where contrib_id='{contrib_id}'");
            foreach (DataRow dr in ssscontrib.Rows)
                if (double.Parse(dr["range_start"].ToString()) < GrossPay &&
                    GrossPay < double.Parse(dr["range_end"].ToString())) return double.Parse(dr["ec"].ToString());
            return 50.00;
        }

        public static double ComputeHDMF() {
            return 100;
        }

        public static double ComputePHIC() {
            return 100;
        }

        public double ComputeThirteen() {
            {
                // TODO: Run this code only on every January 1-4
                var py = new List<Payroll>();
                for (var mm = 1; mm <= 12; mm++) {
                    py.Add(new Payroll(GID, mm, 1, period.year));
                    py.Add(new Payroll(GID, mm, 2, period.year));
                }
                var hce = new HourProcessor();
                double qwe = 0;
                foreach (var pypy in py) pypy.ComputeHours();
                foreach (var pypy in py) qwe += pypy.TotalHours.GetTotalTS().TotalHours * BasicPay;
                return qwe / 12.00;
            }
        }

        public static double ComputeCola() {
            return 50;
        }

        public static double ComputeEmer() {
            return 2500;
        }

        #endregion

        #region Basic Pay Operations

        public static string GetCurrentBasicPay() {
            return SQLTools.ExecuteSingleResult("select amount from basicpay where status = 1");
        }


        /// <summary>
        ///     Gets the basic pay during a certain date.
        ///     Use for historical payroll viewing.
        /// </summary>
        /// <param name="dt">Date to search</param>
        /// <returns></returns>
        public static double GetBasicPay(DateTime dt) {
            var q =
                "select bpid, amount,start,end, case status when 1 then 'Active' when 2 then 'Pending' when 0 then 'Inactive' end as status from basicpay order by start desc";
            var d = SQLTools.ExecuteQuery(q);
            foreach (DataRow dr in d.Rows) {
                var dstart = DateTime.ParseExact(dr["start"].ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                var dend =
                    !dr["end"].ToString().Equals("-1")
                        ? DateTime.ParseExact(dr["end"].ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture)
                        : new DateTime(9999, 12, 28);
                if (dstart < dt && dt < dend) return double.Parse(dr["amount"].ToString());
            }
            return 0.00;
        }

        /// <summary>
        ///     Overrides the current basic pay. Sets previous basic pay to Inactive if Date Effective
        ///     has already elapsed.
        ///     <param name="start">Date Effective (can be in the future)</param>
        ///     <param name="pay"></param>
        /// </summary>
        public static void AddBasicPay(DateTime start, double pay) {
            var ss = start.ToString("yyyy-MM-dd");
            var spay = pay.ToString("#.##");
            var HasElapsed = DateTime.Now >= start;
            if (HasElapsed) {
                var q2 = $"select bpid from basicpay where status=1";
                var bpid = SQLTools.GetInt(q2);
                q2 = $"UPDATE `msadb`.`basicpay` SET `status`='0', `end`='{ss}' WHERE `BPID`='{bpid}'";
                SQLTools.ExecuteNonQuery(q2);
            }
            var q =
                $"INSERT INTO `msadb`.`basicpay` (`amount`, `start`, `end`, `status`) VALUES ('{spay}', '{ss}', '{-1}', '{(HasElapsed ? Enumeration.BasicPayStatus.Active : Enumeration.BasicPayStatus.Future)}');";
            SQLTools.ExecuteNonQuery(q);
        }

        /// <summary>
        ///     Adds a basic pay for some historic point.
        ///     This method simply inserts a
        ///     basic pay value with start and end dates.
        ///     This method does not override
        ///     the current basic pay, and its status is set to
        ///     default 0 (inactive).
        ///     Does not check for overlaps.
        /// </summary>
        /// <param name="start">Date Effective</param>
        /// <param name="end">Date Terminated</param>
        /// <param name="pay">Basic Pay Value (per shift)</param>
        public static void AddBasicPay(DateTime start, DateTime end, double pay) {
            var ss = start.ToString("yyyy-MM-dd");
            var es = end.ToString("yyyy-MM-dd");
            var q =
                $"INSERT INTO `msadb`.`basicpay` (`amount`, `start`, `end`, `status`) VALUES ('{pay:#.##}', '{ss}', '{es}', '0');";
            SQLTools.ExecuteNonQuery(q);
        }


        public static DataTable GetBasicPayHistory() {
            var q = @"select * from basicpay order by status desc";
            return SQLTools.ExecuteQuery(q);
        }

        #endregion

        #region Accessor Functions Operations

        #region + SSS Contribution CRUD Methods

        #region SSS: For DataTable CRUD

        public static DataTable GetSssContribTable() {
            return SQLTools.ExecuteQuery($@"select sssid, range_start, range_end, ec from ssscontrib
            right join contribdetails
            on ssscontrib.contrib_id=contribdetails.contrib_id
            where status={Enumeration.ContribStatus.Active}");
        }

        public static DataTable GetSssContribTable(int contrib_id) {
            return SQLTools.ExecuteQuery($@"select sssid, range_start, range_end, ec from ssscontrib
            right join contribdetails
            on contribdetails.contrib_id = ssscontrib.contrib_id
            where ssscontrib.contrib_id='{contrib_id}';");
        }

        public static DataTable GetSssContribList() {
            return SQLTools.ExecuteQuery(
                $@"select * from contribdetails where type='{
                        Enumeration.ContribType.Sss
                    }' order by date_effective desc");
        }


        #region SSS:old

        private static void EditSSSContrib(int SssId, double RangeStart, double RangeEnd, double Value) {
            var q =
                @"UPDATE `msadb`.`ssscontrib` SET `range_start`='{0}', `range_end`='{1}', `ec`='{2}' WHERE `sssid`='" +
                SssId + "';";
            q = string.Format(q, RangeStart, RangeEnd, Value);
            SQLTools.ExecuteNonQuery(q);
        }

        private static void RemoveSSSContrib(int SssId) {
            SQLTools.ExecuteNonQuery("delete from ssscontrib WHERE `sssid`='" + SssId + "';");
        }


        private static void AddSSSContrib(double RangeStart, double RangeEnd, double Value) {
            var q = string.Format(
                @"INSERT INTO `msadb`.`ssscontrib` (`range_start`, `range_end`, `ec`) VALUES ('{0}', '{1}','{2}');",
                RangeStart, RangeEnd, Value);
            SQLTools.ExecuteNonQuery(q);
        }

        #endregion

        #endregion For DataTable CRUD

        #region SSS: For Computation CRUD

        /*
         * TODO: Now na naa na ko'y Get Contrib IDs, replace generic sss function with `where contrib_id=x` gg ez 😂😂😂
         */
        public static int GetSssContribId(DateTime date) {
            return _GetContribId(date, Enumeration.ContribType.Sss.ToString());
        }

        public static int GetWithTaxContribId(DateTime date) {
            return _GetContribId(date, Enumeration.ContribType.WithTax.ToString());
        }

        /// <summary>
        ///     Gets the `contrib_id` of contribution of a specific date.
        ///     Use this Id for further queries and calculations.
        /// </summary>
        /// <param name="date">Date</param>
        /// <returns>Contrib Id.</returns>
        private static int _GetContribId(DateTime date, string val) {
            var q = $"select * from contribdetails where type={val}";
            var contrib_id = 0;
            var dt = SQLTools.ExecuteQuery(q);
            foreach (DataRow dr in dt.Rows) {
                var ss = DateTime.Parse(dr["date_effective"].ToString());
                var es = dr["date_dissolved"].ToString().Equals("-1")
                    ? SQLTools.GetDateTime("9999-12-28")
                    : DateTime.Parse(dr["date_dissolved"].ToString());
                if (ss < date && date < es) contrib_id = int.Parse(dr["contrib_id"].ToString());
            }
            return contrib_id;
        }

        #endregion

        #region SSS: DB Saving

        public static void SaveSssContrib(DataGridView dt, DateTime date_effective) {
            var date_effectives = date_effective.ToString("yyyy-MM-dd");
            var HasElapsed = DateTime.Now >= date_effective;

            // Create ContribDetails Table (main)

            // if date has already elapsed (adding historical data)
            if (HasElapsed) {
                var q2 = $@"
UPDATE `msadb`.`contribdetails` SET 
`date_dissolved`='{date_effectives}'
WHERE type ={Enumeration.ContribType.Sss} AND status={Enumeration.ContribStatus.Active}";
                SQLTools.ExecuteNonQuery(q2);
            }

            var q =
                $@"INSERT INTO `msadb`.`contribdetails` (`date_effective`, `date_dissolved`, `type`, `status`) VALUES ('{
                        date_effectives
                    }', '{-1}', '{Enumeration.ContribType.Sss}', '{
                        (HasElapsed ? Enumeration.ContribStatus.Past : Enumeration.ContribStatus.Future)
                    }');";
            SQLTools.ExecuteNonQuery(q);
            var contrib_id = SQLTools.GetInt("select LAST_INSERT_ID();");


            // Create Actual SSS connections
            foreach (DataGridViewRow dr in dt.Rows) {
                var from = _cleanstringmoney(dr.Cells[1].Value.ToString());
                var to = _cleanstringmoney(dr.Cells[3].Value.ToString());
                var value = _cleanstringmoney(dr.Cells[5].Value.ToString());
                var w =
                    $"INSERT INTO `msadb`.`ssscontrib` (`range_start`, `range_end`, `ec`, `contrib_id`) VALUES ('{from}', '{to}', '{value}', '{contrib_id}');";
                SQLTools.ExecuteNonQuery(w);
            }
        }

        private static string _cleanstringmoney(string s) {
            return Regex.Replace(s, @"[^0-9\-\.]", "");
        }

        #endregion

        #endregion


        #region + GetGuardsList Methods Min/Max

        public static DataTable GetGuardsPayrollMain() {
            return SQLTools.ExecuteQuery(@"     select guards.gid, concat(ln,', ',fn,' ',mn) as name, client.name, (
                                                        CASE 
                                                            WHEN (period.pid IS NOT NULL AND dutydetails.did IS NOT NULL)
                                                            THEN 'Yes'
                                                            ELSE 'No Attendance Details Found'
                                                        END
                                                      ) AS attendance, pstatus
                                                from request
                                                left join client on client.cid=request.cid
                                                left join request_assign on request_assign.rid=request.rid
                                                left join sduty_assignment on sduty_assignment.raid=request_assign.raid
                                                left join guards on guards.gid=sduty_assignment.gid
                                                left join period on guards.gid=period.gid
												left join dutydetails on dutydetails.aid=sduty_assignment.aid
												left join payroll on guards.gid=payroll.gid
                                                where RequestType = 1 
                                                group by guards.gid
                                                ");
        }

        public static DataTable GetGuardsPayrollMinimal() {
            return SQLTools.ExecuteQuery(@"     select guards.gid, concat(ln,', ',fn,' ',mn) as name
                                                from request
                                                left join client on client.cid=request.cid
                                                left join request_assign on request_assign.rid=request.rid
                                                left join sduty_assignment on sduty_assignment.raid=request_assign.raid
                                                left join guards on guards.gid=sduty_assignment.gid
                                                left join period on guards.gid=period.gid
                                                where RequestType = 1 
                                                
                                                group by guards.gid
                                                ");
        }

        #endregion


        #region DB Operations

        #region WithTax: DB Ops

        public static DataTable GetWithTaxHeaders(int contrib_id) {
            return SQLTools.ExecuteQuery(
                $@"SELECT wid, value, excessmult, contribdetails.contrib_id FROM msadb.withtax_value 
right join withtax_bracket on withtax_bracket.taxid=withtax_value.wid
left join contribdetails on contribdetails.contrib_id=withtax_bracket.contrib_id where contribdetails.contrib_id='{
                        contrib_id
                    }' group by wid;");
        }

        public static DataTable GetWithTaxBrackets(int contrib_id) {
            var q = $@"select * from withtax_bracket where contrib_id={contrib_id};";
            return SQLTools.ExecuteQuery(q);
        }

        public static DataTable GetWithTaxContribList() {
            return SQLTools.ExecuteQuery($@"    select contrib_id, date_effective, date_dissolved, case status 
                                                when 1 then 'Active'
                                                when 2 then 'Pending'
                                                when 0 then 'Inactive'
                                                end as `status`
                                                from contribdetails 
                                                where type='{
                    Enumeration.ContribType.WithTax
                }' order by date_effective desc");
        }

        #endregion

        #endregion DB Operations


        public HourProcessor GetTotalHours() {
            return TotalHours;
        }



        #endregion For DataTable CRUD

        #region Sub-classes

        #endregion


        private void _InitRates() {
            string q =
                #region + string q = {long query}
             $@"
            select
            ordinary_day as nsu_proper_day_normal,
            special_holiday as nsu_proper_day_special,
            regular_holiday as nsu_proper_day_regular,
            (ordinary_day * nightdifferential) as nsu_proper_night_normal,
            (regular_holiday * nightdifferential) as nsu_proper_night_regular,
            (ordinary_day * overtime) as nsu_overtime_day_normal,
            (special_holiday * overtime_holiday) as nsu_overtime_day_special,
            (regular_holiday * overtime_holiday) as nsu_overtime_day_regular,
            (ordinary_day * overtime * nightdifferential) as nsu_overtime_night_normal,
            (special_holiday * overtime_holiday * nightdifferential) as nsu_overtime_night_special,
            (regular_holiday * overtime_holiday * nightdifferential) as nsu_overtime_night_regular,
            sunday_ordinary_day as sun_proper_day_normal,
            sunday_special_holiday as sun_proper_day_special,
            sunday_regular_holiday as sun_proper_day_regular,
            (sunday_ordinary_day * nightdifferential) as sun_proper_night_normal,
            (sunday_special_holiday * nightdifferential) as sun_proper_night_special,
            (sunday_regular_holiday * nightdifferential) as sun_proper_night_regular,
            (sunday_ordinary_day * overtime) as sun_overtime_day_normal,
            (sunday_special_holiday * overtime_holiday) as sun_overtime_day_special,
            (sunday_regular_holiday * overtime_holiday) as sun_overtime_day_regular,
            (sunday_ordinary_day * overtime * nightdifferential) as sun_overtime_night_normal,
            (sunday_special_holiday * overtime_holiday * nightdifferential) as sun_overtime_night_special,
            (sunday_regular_holiday * overtime_holiday * nightdifferential) as sun_overtime_night_regular,
            (ordinary_day * nightdifferential) as nsu_proper_night_special
            from rates
            ";
            #endregion
            DataTable dt = SQLTools.ExecuteQuery(q);
            foreach (string key in _rateKeys) {
                this.rates.Add(key, double.Parse(dt.Rows[0][key].ToString())); 
            }
        }




        private static readonly string[] _rateKeys = new string[] {
            #region +keys definition
            "nsu_proper_day_normal", "nsu_proper_day_special", "nsu_proper_day_regular", "nsu_proper_night_normal",
            "nsu_proper_night_special", "nsu_proper_night_regular", "nsu_overtime_day_normal",
            "nsu_overtime_day_special", "nsu_overtime_day_regular", "nsu_overtime_night_normal",
            "nsu_overtime_night_special", "nsu_overtime_night_regular", "sun_proper_day_normal",
            "sun_proper_day_special", "sun_proper_day_regular", "sun_proper_night_normal", "sun_proper_night_special",
            "sun_proper_night_regular", "sun_overtime_day_normal", "sun_overtime_day_special",
            "sun_overtime_day_regular", "sun_overtime_night_normal", "sun_overtime_night_special",
            "sun_overtime_night_regular"
            #endregion
        };

        private string _SerializeHours() {
            using (MemoryStream stream = new MemoryStream()) {
                new BinaryFormatter().Serialize(stream, this.TotalHours);
                return Convert.ToBase64String(stream.ToArray());
            }
        }
        private static object _DeserializeObject(string str) {
            byte[] bytes = Convert.FromBase64String(str);
            using (MemoryStream stream = new MemoryStream(bytes)) {
                return new BinaryFormatter().Deserialize(stream);
            }
        }

    }
}