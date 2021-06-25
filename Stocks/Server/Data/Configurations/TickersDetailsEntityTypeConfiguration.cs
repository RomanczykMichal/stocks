using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stocks.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stocks.Server.Data.Configurations
{
    public class TickersDetailsEntityTypeConfiguration : IEntityTypeConfiguration<TickersDetails>
    {
        public void Configure(EntityTypeBuilder<TickersDetails> opt)
        {
            opt.HasKey(e => e.IdTickersDetails);
            opt.Property(e => e.IdTickersDetails).ValueGeneratedOnAdd();
        }
    }
}
