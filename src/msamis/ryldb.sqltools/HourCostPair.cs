using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSAMISUserInterface {
    public class HourCostPair {
        public double hour;
        public double cost;
        public double total;
        public HourCostPair(double hours, double basicpay) {
            this.hour = hours;
            this.cost = basicpay;
            this.total = hours * basicpay;
        }
        public HourCostPair() {
            this.hour = 0;
            this.cost = 0;
            this.total = 0;
        }

        
        public static HourCostPair operator +(HourCostPair e) {
            HourCostPair x = new HourCostPair();
            x.hour += e.hour;
            x.cost += e.hour;
            x.total += e.total;
            return x;
        }
    }
}
