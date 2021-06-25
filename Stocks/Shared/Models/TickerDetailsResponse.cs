using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.Shared.DTOs.Response
{
    public class TickerDetailsResponse
    {
        public int IdTickersDetails { get; set; }
        public string logo { get; set; }
        public string listdate { get; set; }
        public string cik { get; set; }
        public string bloomberg { get; set; }
        public string lei { get; set; }
        public int sic { get; set; }
        public string country { get; set; }
        public string industry { get; set; }
        public string sector { get; set; }
        public long marketcap { get; set; }
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
        public bool active { get; set; }
    }
}
