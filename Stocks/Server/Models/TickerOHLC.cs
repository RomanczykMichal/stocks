using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stocks.Server.Models
{
    public class TickerOHLC
    {
        public int Id { get; set; }
        public string TickerName { get; set; }
        public double V { get; set; }
        public double Vw { get; set; }
        public double O { get; set; }
        public double C { get; set; }
        public double H { get; set; }
        public double L { get; set; }
        public double T { get; set; }
        public int N { get; set; }
    }
}
