using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stocks.Client.Models.DTOs
{
    public class SessionStorageUserDTO
    {
        public string id_token { get; set; }
        public string session_state { get; set; }
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string scope { get; set; }
        public SessionStorageProfileDTO profile { get; set; }
        public int expires_at { get; set; }
    }
}
