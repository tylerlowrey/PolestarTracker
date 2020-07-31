using System;
using Microsoft.EntityFrameworkCore;
using PolestarTracker.Core.Models;

namespace PolestarTracker.EntityFramework
{
    public class ApplicationDataContext : DbContext
    {
        public DbSet<TrackingRecord> TrackingRecords { get; set; }
        public DbSet<ApplicationAlias> ApplicationAliases { get; set; }
        public DbSet<ApplicationFilter> ApplicationFilters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlite("Data Source=tracking.db");
    }
}
