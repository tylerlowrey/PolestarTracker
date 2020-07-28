using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolestarTracker.Core.Models;
using PolestarTracker.EntityFramework;

namespace PolestarTracker.Tests.EntityFramework
{
    [TestClass]
    public class TrackingDataContextTests
    {
        internal class TrackingDataTestContext : TrackingDataContext
        {

            protected override void OnConfiguring(DbContextOptionsBuilder options)
            {
                options.UseSqlite("Data Source=../../../tracking.db");
            }

        }

        [TestMethod]
        public void Can_Successfully_Add_TrackingRecord_To_Database()
        {
            using (var db = new TrackingDataTestContext())
            {
                TrackingRecord testRecord = new TrackingRecord { ProcessName = "example process", Timestamp = DateTime.Now};
                db.Add(testRecord);
                db.SaveChanges();

                var insertedRecord = db.TrackingRecords
                    .OrderByDescending(tr => tr.RecordId)
                    .FirstOrDefault();

                Assert.AreEqual(testRecord, insertedRecord);
            }
        }
    }
}
