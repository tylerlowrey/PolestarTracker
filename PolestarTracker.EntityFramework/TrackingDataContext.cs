using System;
using Microsoft.EntityFrameworkCore;
using PolestarTracker.Core.Models;

namespace PolestarTracker.EntityFramework
{
    public class TrackingDataContext
    {
        public DbSet<TrackingRecord> TrackingRecords { get; set; }

    }
}
