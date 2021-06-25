using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.Shared.DTOs.Tickers
{
    public class Api_TickersResponseRootDTO
    {
        public List<Api_TickersResponseDTO> Results { get; set; }
        public string Status { get; set; }
        public string request_id { get; set; }
        public int Count { get; set; }
        public string next_url { get; set; }
    }
}
