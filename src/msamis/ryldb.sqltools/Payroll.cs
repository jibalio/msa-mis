using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

/*TODO: Fix: hourcost dictionary hours items have money value even with 0 hours. */
namespace MSAMISUserInterface {

    public class Payroll {

        #region Fields Definition
        public int GID;
        public static Dictionary<string, double> rates = new Dictionary<string, double> {
        };
        public HourProcessor totalhours = new HourProcessor();
        public static double BasicPay = 340.00;
        public Attendance.Period period = Attendance.GetCurrentPayPeriod();
        public static Hours total_old;
       
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
        int hml = 0;
        public void ComputeGrossPay() {
            int gid = GID;
            hml++;
            foreach (string key in hc.Keys.ToList()) {
                this.hc[key] = new HourCostPair(totalhours.GetHourDictionary()[key].TotalHours, BasicPay * rates[key]);
            }
            ComputeTotalSummary();
            bonuses = ComputeBonuses();
            deductions = ComputeDeductions();
            NetPay = ComputeNet();
            TaxableIncome = ComputeTaxableIncome();
            Excess = GrossPay - TaxableIncome;
            ComputeWithTax(TaxableIncome, Excess);

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
            GrossPay = NetPay = TotalSummary["total"].cost;
        }

        public double NetPay;
        
        public double sss;
        public double pagibig;
        public double philhealth;
        public double withtax;
        public double cashadv;
        public double cashbond;

        public double deductions;
        public double bonuses;

        public double GrossPay;
        public double TaxableIncome;
        public double Excess;


        public double ComputeNet() {
            double e = NetPay;
            e +=(ComputeDeductions());
            e += ComputeBonuses();
            return e;
        }

        public double ComputeTaxableIncome() {
            /*  Status
                Do you have any dependents and how many?
                How much is your SSS/Philhealth and PagIbig contributions
                Allowances and other benefits if any
                Copy of the BIR Tax table 
             */
            return GrossPay - sss - pagibig - philhealth;
        }

        #region In Genera Calculations
        public double ComputeDeductions() {
            this.sss = ComputeSSS();
            this.pagibig = ComputeHDMF();
            this.philhealth = ComputePHIC();
            this.cashadv = ComputeCashAdvance();
            double e =  sss + pagibig + philhealth + cashadv;
            return e;
        }

        public double thirteen;
        public double cola;
        public double emerallowance;
        public double ComputeBonuses() {
            this.thirteen = ComputeThirteen();
            this.cola = ComputeCola();
            this.emerallowance = ComputeEmer();
            this.cashbond = ComputeCashBond();
            return thirteen + cola + emerallowance + cashbond;
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
            wt.total = w.TaxbaseD + Excess * ((double) w.excessfactor / 100);
            wt.ExcessTax = ((double) w.excessfactor / 100);

            return w.TaxbaseD + Excess * ((double) w.excessfactor / 100);
        }

        public WithTax GetWithholdingTax() {
            return wt;
        } 

        public class WithTax {
            public double TaxbaseD = 0.0;
            public int excessfactor = 0;
            public double total = 0.0;
            public double ExcessTax = 0.0;
        }

        public WithTax wt = new WithTax();
             
        public double ComputeSSS() {
            DataTable ssscontrib = SQLTools.ExecuteQuery("select * from ssscontrib");
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
            List<Payroll> py = new List<Payroll>();
            for (int c = 1; c < 12; c++) { }
            throw new NotImplementedException();


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

        public static void AddBasicPay(DateTime start, double pay) {
            String paystring = pay.ToString("0000.##");
            String q;
            q = @"INSERT INTO `msadb`.`basicpay` (`amount`, `start`, `end`, `status`) VALUES ('{0}', '{1}', '{2}', '{3}');";
            string status;
            DateTime sta = new DateTime(start.Year, start.Month, start.Day);
            DateTime end = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            // Case 1: If karon gamiton
            if (sta < end) status = "0";
            else status = "1";
            q = String.Format(q, paystring, sta.ToString("yyyy-MM-dd"), "", status);
            SQLTools.ExecuteNonQuery(q);
        }

        public static DataTable GetBasicPayHistory () {
            String q = @"select * from basicpay order by status desc";
            return SQLTools.ExecuteQuery(q);
        }

        #endregion
        #region Accessor Functions Operations

            #region + SSS Contribution CRUD Methods
        public static DataTable GetSssContribTable() {
            return SQLTools.ExecuteQuery("select * from ssscontrib;");
        }
        public static void EditSSSContrib(int sssid, double rangeStart, double range_end, double ec) {
            string q = @"UPDATE `msadb`.`ssscontrib` SET `range_start`='{0}', `range_end`='{1}', `ec`='{2}' WHERE `sssid`='"+sssid+"';";
            q = String.Format(q, rangeStart, range_end, ec);
            SQLTools.ExecuteNonQuery(q);
        }
        public static void RemoveSSSContrib(int sssid) {
            SQLTools.ExecuteNonQuery("delete from ssscontrib WHERE `sssid`='" + sssid + "';");
        }

        
        public static void AddSSSContrib(double range_start, double range_end, double ec) {
            string q = String.Format(@"INSERT INTO `msadb`.`ssscontrib` (`range_start`, `range_end`, `ec`) VALUES ('{0}', '{1}','{2}');",
                range_start, range_end, ec);
            SQLTools.ExecuteNonQuery(q);
        }
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






        
            
        



        public HourProcessor GetTotalHours() {
            return totalhours;
        }

        #endregion New Region
        #region Sub-classes
        
        #endregion

    }

}
