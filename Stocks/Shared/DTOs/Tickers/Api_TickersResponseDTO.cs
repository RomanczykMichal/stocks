using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.Shared.DTOs
{
    public class Api_TickersResponseDTO
    {
        public string Ticker { get; set; }
        public string Name { get; set; }
        public string Market { get; set; }
        public string Locale { get; set; }
        public string primary_exchange { get; set; }
        public string Type { get; set; }
        public bool Active { get; set; }
        public string currency_name { get; set; }
        public string Cik { get; set; }
        public string composite_figi { get; set; }
        public string share_class_figi { get; set; }
        public DateTime last_updated_utc { get; set; }
    }
}
