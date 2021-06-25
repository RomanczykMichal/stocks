using Stocks.Shared.DTOs.Response;
using Stocks.Shared.DTOs.Tickers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.Shared.DTOs
{
    public class UserFavorites
    {
        public string Username { get; set; }
        public List<TickerDetailsResponse> TickersDetailsList { get; set; }

    }
}
