using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stocks.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stocks.Server.Data.Configurations
{
    public class TickerOHLCEntityTypeConfiguration : IEntityTypeConfiguration<TickerOHLC>
    {
        public void Configure(EntityTypeBuilder<TickerOHLC> opt)
        {
            opt.HasKey(e => e.Id);
            opt.Property(e => e.Id).ValueGeneratedOnAdd();

            opt.HasIndex(e => e.TickerName);
            opt.HasIndex(e => e.T);
        }
    }
}
