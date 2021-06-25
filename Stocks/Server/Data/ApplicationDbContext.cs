using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Stocks.Server.Data.Configurations;
using Stocks.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stocks.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<TickersDetails> TickersDetails { get; set; }
        public DbSet<TickersUsers> TickersUsers { get; set; }
        public DbSet<TickerOHLC> TickerOHLC { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TickersDetailsEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TickersUsersEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TickerOHLCEntityTypeConfiguration());
        }
    }
}
