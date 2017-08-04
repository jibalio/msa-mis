using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MSAMISUserInterface;

/*TODO: 
 Perform tests on colliding holidays from multiple years.
 Pword hash
 13th.
     */
namespace MSAMISUserInterface {

    public class Payroll {


        #region Fields Definition
        public double bonuses;

        public double NetPay;
        public int GID;
        public double GrossPay;

        // Deductions
        public double deductions;
        // PayrollData Containers
        public HourProcessor totalhours = new HourProcessor();
        public static Dictionary<string, double> rates = new Dictionary<string, double>();
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
            {"normal_nsu", new HourCostPair () },
            {"normal_sun", new HourCostPair () },
            {"regular_nsu", new HourCostPair () },
            {"regular_sun", new HourCostPair () },
            {"special_nsu", new HourCostPair () },
            {"special_sun", new HourCostPair () },
            {"special", new HourCostPair () },
            {"normal", new HourCostPair() },
            {"regular", new HourCostPair() },
            {"total", new HourCostPair() }
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
        public Payroll(int GID) {
            this.GID = GID;
        }
        public Payroll(int GID, int month, int period, int year) {
            this.GID = GID;
            this.period.period = period;
            this.period.month = month;
            this.period.year = year;
        }
        #endregion
        #region  Computationes
        public void ComputeGrossPay(bool checkthirteen) {
            int gid = GID;
            foreach (string key in hc.Keys.ToList()) {
                this.hc[key] = new HourCostPair(totalhours.GetHourDictionary()[key].TotalHours, BasicPay * rates[key]);
            }
            ComputeTotalSummary();
            
            bonuses = ComputeBonuses(checkthirteen);
            GrossPay = TotalSummary["total"].total + bonuses;
            deductions = ComputeDeductions();
            NetPay = GrossPay - deductions;
        }
        public void ComputeGrossPay() {
            ComputeGrossPay(true);
        }
        public void ComputeHours() {
            DataTable HourIterationDataTable = SQLTools.ExecuteQuery(
                String.Format(@"
                    select dutydetails.did, atid, date, timein, timeout, 
                    ti_hh, ti_mm, ti_period, to_hh, to_mm, to_period
                    from attendance 
                    left join period on period.pid = attendance.pid
                    left join dutydetails on attendance.did = dutydetails.did
                    left join sduty_assignment on sduty_assignment.aid = dutydetails.aid
                    left join guards on guards.gid=sduty_assignment.gid 
                    where period.period = "+period.period+" and month="+period.month+" and year="+period.year+@" and guards.gid="+ GID +@"
            ;", GID, period.period, period.year, period.month));
            Hours HourIterationTotal = new Hours();
            foreach (DataRow dr in HourIterationDataTable.Rows) {
                string ti = dr["date"].ToString().Substring(0, 11) + dr["TimeIn"].ToString();
                string to = dr["date"].ToString().Substring(0, 10) + " " + dr["TimeOut"].ToString();
                DateTime TimeInDateTime = DateTime.Parse(ti);
                DateTime TimeOutDateTime = DateTime.Parse(to);

                string StartDutyString = dr["date"].ToString().Substring(0, 11) + " " + dr["ti_hh"] + ":" + dr["ti_mm"] + " " + dr["ti_period"];
                string EndDutyString = dr["date"].ToString().Substring(0, 11) + " " + dr["to_hh"] + ":" + dr["to_mm"] + " " + dr["to_period"];
                DateTime DutyStart = DateTime.Parse(StartDutyString);
                DateTime DutyEnd = DateTime.Parse(EndDutyString);
                HourProcessor hp = new HourProcessor(TimeInDateTime, TimeOutDateTime, DutyStart, DutyEnd);
                totalhours.Add(hp);
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
                        hc["nsu_overtime_night_normal"]+                
                        hc["sun_proper_day_normal"] +   
                        hc["sun_overtime_day_normal"] +  
                        hc["sun_proper_night_normal"] +  
                     hc["sun_overtime_night_normal"]; 
            TotalSummary["regular"]=
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
            double e = GrossPay;
            e -= deductions;
            e += bonuses;
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

        public int contid = 0;
        #region In Genera Calculations
        public double ComputeDeductions() {
            contid = GetSssContribId(new DateTime(period.year, period.month, period.period == 1 ? 1 : 16));
            this.Sss = ComputeSSS(contid);
            if (period.period==2) {
                this.PagIbig = ComputeHDMF();
                this.PhilHealth = ComputePHIC();
            } else {
                this.PagIbig = 0;
                this.PhilHealth = 0;
            }
            
            this.CashAdv = ComputeCashAdvance();
            this.TaxableIncome = ComputeTaxableIncome();
            this.Excess = GrossPay - TaxableIncome;
            this.Withtax = ComputeWithTax(TaxableIncome, Excess);
            double e =  Sss + PagIbig + PhilHealth + CashAdv + Withtax;
            return e;
        }

        public double thirteen;
        public double cola;
        public double emerallowance;
        public double ComputeBonuses(bool ca) {
            if (ca) {
                if (this.period.month == 12 && this.period.period == 2) { this.thirteen = ComputeThirteen(); }
            else { this.thirteen = 0; }}
            
            
            this.cola = ComputeCola();
            this.emerallowance = ComputeEmer();
            this.cashbond = ComputeCashBond();
            return thirteen + cola + emerallowance + cashbond;
        }

        public double ComputeBonuses() {
            return ComputeBonuses(true);
        }
        #endregion


        public static double ComputeCashBond() {
            return 5000;
        }
        public static double ComputeCashAdvance() {
            return 20;
        }
        public double ComputeWithTax(double Taxable, double Excess) {
            int NumDependents = Guard.GetNumberOfDependents(GID);
            if (NumDependents > 4)
                NumDependents = 4;
            string sm = "s" + NumDependents + "me" + NumDependents;
            WithTax w = new WithTax();
            // Start Paper code
            int prevbracket = 0;
            double prevtaxbracket = 0;
            DataTable dt = SQLTools.ExecuteQuery("Select * from withtax_bracket where estatus='" + sm + "'");
            foreach (DataRow dr in dt.Rows) {
                if (double.Parse(dr["bracket"].ToString()) > Taxable &&
                    Taxable > prevtaxbracket) {

                    DataTable dt2 = SQLTools.ExecuteQuery("select * from withtax_value where wid=" + (int.Parse(dr["taxid"].ToString())-1));
                    
                    w.TaxbaseD = double.Parse(dt2.Rows[0]["value"].ToString());
                    w.excessfactor = int.Parse(dt2.Rows[0]["excessmult"].ToString());
                } else {
                    prevtaxbracket = double.Parse(dr["bracket"].ToString());
                    prevbracket++;
                }
            }
            wt.TaxbaseD = w.TaxbaseD;
            wt.excessfactor = w.excessfactor;

            double ___ = Excess * ((double) w.excessfactor / 100);
            wt.total = w.TaxbaseD + Excess * ((double) w.excessfactor / 100);
            wt.ExcessTax = Excess * ((double) w.excessfactor / 100);
            
            return w.TaxbaseD + (Excess * ((double) w.excessfactor / 100));
        }

        public WithTax GetWithholdingTax() {
            return wt;
        } 

        public class WithTax {
            public double TaxbaseD = 0.0;
            public int excessfactor = 0;
            public double ExcessTax = 0.0;
            public double total = 0.0;
        }
        public double ComputeSSS(int contrib_id) {
            DataTable ssscontrib = SQLTools.ExecuteQuery($"select * from ssscontrib where contrib_id='{contrib_id}'");
            foreach (DataRow dr in ssscontrib.Rows) {
                if (double.Parse(dr["range_start"].ToString()) < GrossPay &&
                    GrossPay < double.Parse(dr["range_end"].ToString())) { return double.Parse(dr["ec"].ToString());}
            }
            return 50.00;
        }
        public static double ComputeHDMF () {
            return 100;
        }

        public static double ComputePHIC() {
            return 100;
        }

        public double ComputeThirteen() {
             { 
                // TODO: Run this code only on every January 1-4
                List<Payroll> py = new List<Payroll>();
                for (int mm = 1; mm <= 12; mm++) {
                    py.Add(new Payroll(this.GID, mm, 1, this.period.year));
                    py.Add(new Payroll(this.GID, mm, 2, this.period.year));
                }
                HourProcessor hce = new HourProcessor();
                 double qwe = 0;
                foreach (Payroll pypy in py) {
                    pypy.ComputeHours();
                }
                 foreach (Payroll pypy in py) {
                    qwe += pypy.totalhours.GetTotalTS().TotalHours * BasicPay;
                }
                return qwe / 12.00;
        }
    }

        public static double ComputeCola () {
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
        /// Gets the basic pay during a certain date.
        /// Use for historical payroll viewing.
        /// </summary>
        /// <param name="dt">Date to search</param>
        /// <returns></returns>
        public static double GetBasicPay(DateTime dt) {
            String q = "select bpid, amount,start,end, case status when 1 then 'Active' when 2 then 'Pending' when 0 then 'Inactive' end as status from basicpay order by start desc";
            DataTable d = SQLTools.ExecuteQuery((q));
            foreach (DataRow dr in d.Rows) {
                DateTime dstart = DateTime.ParseExact(dr["start"].ToString(),"yyyy-MM-dd", CultureInfo.InvariantCulture);
                DateTime dend = 
                    !dr["end"].ToString().Equals("-1")? 
                    DateTime.ParseExact(dr["end"].ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture): 
                    new DateTime(9999, 12, 28);
                if (dstart < dt && dt < dend) { return Double.Parse(dr["amount"].ToString()); }
            }
            return 0.00;
        }

        /// <summary>
        /// Overrides the current basic pay. Sets previous basic pay to Inactive if Date Effective
        /// has already elapsed.
        /// <param name="start">Date Effective (can be in the future)</param>
        /// <param name="pay"></param>
        /// </summary>
        public static void AddBasicPay(DateTime start, double pay) {
            string ss = start.ToString("yyyy-MM-dd");
            string spay = pay.ToString("#.##");
            bool HasElapsed = DateTime.Now >= start;
            if (HasElapsed) {
                var q2 = $"select bpid from basicpay where status=1";
                int bpid = SQLTools.GetInt(q2);
                q2 = $"UPDATE `msadb`.`basicpay` SET `status`='0', `end`='{ss}' WHERE `BPID`='{bpid}'";
                SQLTools.ExecuteNonQuery(q2);
            }
            var q = $"INSERT INTO `msadb`.`basicpay` (`amount`, `start`, `end`, `status`) VALUES ('{spay}', '{ss}', '{-1}', '{(HasElapsed ? Enumeration.BasicPayStatus.Active : Enumeration.BasicPayStatus.Future)}');";
            SQLTools.ExecuteNonQuery(q);
        }

        /// <summary>
        /// Adds a basic pay for some historic point. 
        /// This method simply inserts a
        ///     basic pay value with start and end dates. 
        /// This method does not override
        ///     the current basic pay, and its status is set to 
        ///     default 0 (inactive). 
        /// Does not check for overlaps.
        /// </summary>
        /// <param name="start">Date Effective</param>
        /// <param name="end">Date Terminated</param>
        /// <param name="pay">Basic Pay Value (per shift)</param>
        public static void AddBasicPay(DateTime start, DateTime end, double pay) {
            string ss = start.ToString("yyyy-MM-dd");
            string es = end.ToString("yyyy-MM-dd");
            var q =
                $"INSERT INTO `msadb`.`basicpay` (`amount`, `start`, `end`, `status`) VALUES ('{pay:#.##}', '{ss}', '{es}', '0');";
            SQLTools.ExecuteNonQuery(q);
        }


        public static DataTable GetBasicPayHistory () {
            String q = @"select * from basicpay order by status desc";
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

        public static DataTable GetSssContribTable (int contrib_id) {
            return SQLTools.ExecuteQuery($@"select sssid, range_start, range_end, ec from ssscontrib
            right join contribdetails
            on contribdetails.contrib_id = ssscontrib.contrib_id
            where ssscontrib.contrib_id='{contrib_id}';");
        }

        public static DataTable GetSssContribList() {
            return SQLTools.ExecuteQuery($@"select * from contribdetails where type='{Enumeration.ContribType.Sss}' order by date_effective desc");
        }

        
        
 

        



        #region SSS:old
        private static void EditSSSContrib(int SssId, double RangeStart, double RangeEnd, double Value) {
            string q = @"UPDATE `msadb`.`ssscontrib` SET `range_start`='{0}', `range_end`='{1}', `ec`='{2}' WHERE `sssid`='"+SssId+"';";
            q = String.Format(q, RangeStart, RangeEnd, Value);
            SQLTools.ExecuteNonQuery(q);
        }
        private static void RemoveSSSContrib(int SssId) {
            SQLTools.ExecuteNonQuery("delete from ssscontrib WHERE `sssid`='" + SssId + "';");
        }

        
        private static void AddSSSContrib(double RangeStart, double RangeEnd, double Value) {
            string q = String.Format(@"INSERT INTO `msadb`.`ssscontrib` (`range_start`, `range_end`, `ec`) VALUES ('{0}', '{1}','{2}');",
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
        /// Gets the `contrib_id` of contribution of a specific date.
        /// Use this Id for further queries and calculations.
        /// </summary>
        /// <param name="date">Date</param>
        /// <returns>Contrib Id.</returns>
        private static int _GetContribId(DateTime date, string val) {
            var q = $"select * from contribdetails where type={val}";
            int contrib_id = 0;
            DataTable dt = SQLTools.ExecuteQuery(q);
            foreach (DataRow dr in dt.Rows) {
                DateTime ss = DateTime.Parse(dr["date_effective"].ToString());
                DateTime es = dr["date_dissolved"].ToString().Equals("-1") ? 
                    SQLTools.GetDateTime("9999-12-28"):DateTime.Parse(dr["date_dissolved"].ToString());
                if (ss < date && date < es) { contrib_id = int.Parse(dr["contrib_id"].ToString()); }
            }
            return contrib_id;
        }


        #endregion
        #region SSS: DB Saving
        public static void SaveSssContrib(DataGridView dt, DateTime date_effective)
        {
            string date_effectives = date_effective.ToString("yyyy-MM-dd");
            bool HasElapsed = DateTime.Now >= date_effective;

            // Create ContribDetails Table (main)

            // if date has already elapsed (adding historical data)
            if (HasElapsed)
            {
                string q2 = $@"
UPDATE `msadb`.`contribdetails` SET 
`date_dissolved`='{date_effectives}'
WHERE type ={Enumeration.ContribType.Sss} AND status={Enumeration.ContribStatus.Active}";
                SQLTools.ExecuteNonQuery(q2);
            }

            string q =
                $@"INSERT INTO `msadb`.`contribdetails` (`date_effective`, `date_dissolved`, `type`, `status`) VALUES ('{date_effectives}', '{-1}', '{Enumeration.ContribType.Sss}', '{
                   (HasElapsed ? Enumeration.ContribStatus.Past : Enumeration.ContribStatus.Future)
                    }');";
            SQLTools.ExecuteNonQuery(q);
            int contrib_id = SQLTools.GetInt("select LAST_INSERT_ID();");


            // Create Actual SSS connections
            foreach (DataGridViewRow dr in dt.Rows)
            {
                string from = _cleanstringmoney(dr.Cells[1].Value.ToString());
                string to = _cleanstringmoney(dr.Cells[3].Value.ToString());
                string value = _cleanstringmoney(dr.Cells[5].Value.ToString());
                string w =
                    $"INSERT INTO `msadb`.`ssscontrib` (`range_start`, `range_end`, `ec`, `contrib_id`) VALUES ('{from}', '{to}', '{value}', '{contrib_id}');";
                SQLTools.ExecuteNonQuery(w);
            }
        }

        private static string _cleanstringmoney(string s)
        {
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
            return SQLTools.ExecuteQuery($@"SELECT * FROM msadb.withtax_value where wid='{contrib_id}';");
        }

        public static DataTable GetWithTaxBrackets(int contrib_id) {
            string q = $@"select * from withtax_bracket where contrib_id={contrib_id};";
            return SQLTools.ExecuteQuery(q);
        }
        
        public static DataTable GetWithTaxContribList() {
            return SQLTools.ExecuteQuery($@"    select contrib_id, date_effective, date_dissolved, case status 
                                                when 1 then 'Active'
                                                when 2 then 'Pending'
                                                when 0 then 'Inactive'
                                                end as `status`
                                                from contribdetails 
                                                where type='{Enumeration.ContribType.WithTax}' order by date_effective desc");
        }
        #endregion


        #endregion DB Operations








        public HourProcessor GetTotalHours() {
            return totalhours;
        }

        #endregion For DataTable CRUD
        #region Sub-classes

        #endregion



        #region Adjustement Operationen
        public void GetAdjustments () {
            
        }

        #endregion

    }

}
