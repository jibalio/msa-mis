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


        public static HourCostPair operator +(HourCostPair c1, HourCostPair c2) {
            HourCostPair f = new HourCostPair();
            f.cost = c1.cost + c2.cost;
            f.hour = c1.hour + c2.hour;
            f.total = c1.total + c2.total;
            return f;
        }

        // Override the ToString method to display an complex number in the suitable format:




        

        public void Add (HourCostPair e) {
            hour += e.hour;
            cost += e.hour;
            total += e.total;
        }
    }
}
