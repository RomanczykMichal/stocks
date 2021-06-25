using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stocks.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual IEnumerable<TickersUsers> TickersUsersList { get; set; }

    }
}
