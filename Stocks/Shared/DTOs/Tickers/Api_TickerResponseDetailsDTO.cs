using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.Shared.DTOs.Tickers
{
    public class Api_TickerResponseDetailsDTO
    {
        public string logo { get; set; }
        public string listdate { get; set; }
        public string cik { get; set; }
        public string bloomberg { get; set; }
        public object figi { get; set; }
        public string lei { get; set; }
        public int sic { get; set; }
        public string country { get; set; }
        public string industry { get; set; }
        public string sector { get; set; }
        public long marketcap { get; set; }
        public object employees { get; set; }
        public string phone { get; set; }
        public string ceo { get; set; }
        public string url { get; set; }
        public string description { get; set; }
        public string exchange { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public string exchangeSymbol { get; set; }
        public string hq_address { get; set; }
        public string hq_state { get; set; }
        public string hq_country { get; set; }
        public string type { get; set; }
        public string updated { get; set; }
        public List<string> tags { get; set; }
        public List<string> similar { get; set; }
        public bool active { get; set; }
    }
}
