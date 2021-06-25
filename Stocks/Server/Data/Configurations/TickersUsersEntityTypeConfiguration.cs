using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stocks.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stocks.Server.Data.Configurations
{
    public class TickersUsersEntityTypeConfiguration : IEntityTypeConfiguration<TickersUsers>
    {
        public void Configure(EntityTypeBuilder<TickersUsers> opt)
        {
            opt.HasKey(e => new { e.IdTickersDetails, e.IdApplicationUser });

            opt.HasOne(e => e.TickersDetails)
                .WithMany(tic => tic.TickersUsersList)
                .HasForeignKey(e => e.IdTickersDetails);

            opt.HasOne(e => e.ApplicationUser)
                .WithMany(app => app.TickersUsersList)
                .HasForeignKey(e => e.IdApplicationUser);
        }
    }
}
