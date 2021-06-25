using Stocks.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.Server.Models
{
    public class TickersUsers
    {
        public int IdTickersDetails { get; set; }
        public string IdApplicationUser { get; set; }

        public virtual TickersDetails TickersDetails { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
