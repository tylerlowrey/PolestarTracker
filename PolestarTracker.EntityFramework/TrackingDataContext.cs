using System;
using Microsoft.EntityFrameworkCore;
using PolestarTracker.Core.Models;

namespace PolestarTracker.EntityFramework
{
    public class TrackingDataContext : DbContext
    {
        public DbSet<TrackingRecord> TrackingRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlite("Data Source=tracking.db");
    }
}
