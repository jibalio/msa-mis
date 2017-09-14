using System.Collections.Generic;
using System.Data;

namespace MSAMISUserInterface {

    public class PayrollReport {

        

        public string FN;
        public string MN;
        public string LN;
        public int DaysOfWork;
        public double TotalRegularWage;

        public Overtime overtime = new Overtime();

        public class Overtime {
            public HourCostPair RegularDay;
            public HourCostPair SundayAndHoliday;
        }

        public double TotalAmount;
        public double Sss;
        public double PHIC;
        public double Withtax;
        public double HDMF;
        public double CashAdvance;
        public double ThirteenthMonthPay;
        public double Cola;
        public double CashBond;
        public double EmergencyAllowance;
        public double NetAmountPaid { get; set; }
        public Dictionary<string, HourCostPair> hc;


        public PayrollReport(int GID, int year, int month, int period) {
            
            // Set Days of Work.
            this.DaysOfWork = SQLTools.GetInt($@"
                    SELECT 
                        COUNT(*)
                    FROM
                        attendance
                    LEFT JOIN `msadb`.`period` ON period.pid = attendance.pid
                    WHERE
                        gid = {GID}
                    AND('{year}-{month.ToString().PadLeft(2,'0')}-{(period==1?1:15)}' <= `Date` AND `Date` <= '{year}-{month}-{(period == 1 ? 14 : 31)}'); 
            ");

            // Get Guard and Payroll data.
            var q = $@"
                SELECT 
	                *
                FROM
	                msadb.payroll
                    LEFT JOIN msadb.guards ON msadb.payroll.gid = msadb.guards.gid
                WHERE
	                guards.gid = {GID}
                    AND month = {month}
                    AND period = {period}
                    AND YEAR = {year};
                ";
            DataRow dt = SQLTools.ExecuteQuery(q).Rows[0];

            this.FN = dt["FN"].ToString();
            this.MN = dt["MN"].ToString();
            this.LN = dt["LN"].ToString();
            this.Rate = double.Parse(dt["basicpayhourly"].ToString())*8;
            // Set the derivables
            this.EmergencyAllowance = double.Parse(dt["emergencyallowance"].ToString());
            this.CashBond = double.Parse(dt["cashbond"].ToString());
            this.Cola = double.Parse(dt["cola"].ToString());
            this.ThirteenthMonthPay = double.Parse(dt["thirteenth"].ToString());
            this.CashAdvance = double.Parse(dt["cashadv"].ToString());
            // Set the primitives
            this.HDMF = double.Parse(dt["pagibig"].ToString());
            this.PHIC = double.Parse(dt["philhealth"].ToString());
            this.Sss = double.Parse(dt["sss"].ToString());
            this.Withtax = double.Parse(dt["withtax"].ToString());
            this.hc = (Dictionary<string, HourCostPair>)Payroll._DeserializeObject(
                System.Text.Encoding.Default.GetString((byte[])dt["hc_serializable"])
            );
            this.TotalSummary = (Dictionary<string, HourCostPair>)Payroll._DeserializeObject(
                System.Text.Encoding.Default.GetString((byte[])dt["totalsummary_serializable"])
            );
            this.TotalAmount = TotalSummary["total"].total;
            HourCostPair notOvertime =
                hc["nsu_proper_day_normal"] +
                hc["nsu_proper_day_special"] +
                hc["nsu_proper_day_regular"] +
                hc["nsu_proper_night_normal"] +
                hc["nsu_proper_night_special"] +
                hc["nsu_proper_night_regular"] +
                hc["sun_proper_day_normal"] +
                hc["sun_proper_day_special"] +
                hc["sun_proper_day_regular"] +
                hc["sun_proper_night_normal"] +
                hc["sun_proper_night_special"] +
                hc["sun_proper_night_regular"];
            this.TotalRegularWage = notOvertime.total;
            /*
            
            nsu_overtime_day_special
            nsu_overtime_day_regular
            nsu_overtime_night_special
            nsu_overtime_night_regular
            sun_overtime_day_normal
            sun_overtime_day_special
            sun_overtime_day_regular
            sun_overtime_night_normal
            sun_overtime_night_special
            sun_overtime_night_regular
            */
            this.overtime.RegularDay = hc["nsu_overtime_day_normal"]+ hc["nsu_overtime_night_normal"];
            this.overtime.SundayAndHoliday =
                hc["nsu_overtime_day_special"] +
                hc["nsu_overtime_day_regular"] +
                hc["nsu_overtime_night_special"] +
                hc["nsu_overtime_night_regular"] +
                hc["sun_overtime_day_normal"] +
                hc["sun_overtime_day_special"] +
                hc["sun_overtime_day_regular"] +
                hc["sun_overtime_night_normal"] +
                hc["sun_overtime_night_special"] +
                hc["sun_overtime_night_regular"];

            this.NetAmountPaid = TotalSummary["total"].total;
        }

        public double Rate { get; set; }


        public Dictionary<string, HourCostPair> TotalSummary;
    }
}
