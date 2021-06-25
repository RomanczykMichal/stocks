using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stocks.Client.Models.DTOs
{
    public class SessionStorageProfileDTO
    {
        public string s_hash { get; set; }
        public string sid { get; set; }
        public string sub { get; set; }
        public int auth_time { get; set; }
        public string idp { get; set; }
        public List<string> amr { get; set; }
        public string preferred_username { get; set; }
        public string name { get; set; }
    }
}
