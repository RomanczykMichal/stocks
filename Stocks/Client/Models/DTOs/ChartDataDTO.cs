using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stocks.Client.Models.DTOs
{
    public class ChartDataDTO
    {
        public double V { get; set; }
        public double Vw { get; set; }
        public double O { get; set; }
        public double C { get; set; }
        public double H { get; set; }
        public double L { get; set; }
        public double T { get; set; }
        public int N { get; set; }
        public DateTime TimeConverted
        {
            get { return (new DateTime(1970, 1, 1) + TimeSpan.FromMilliseconds(T)); }
        }
    }
}
