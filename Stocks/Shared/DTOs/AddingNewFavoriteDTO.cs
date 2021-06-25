using Stocks.Shared.DTOs.Tickers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.Shared.DTOs
{
    public class AddingNewFavoriteDTO
    {
        public Api_TickerResponseDetailsDTO Details { get; set; }
        public string Username { get; set; }
    }
}
