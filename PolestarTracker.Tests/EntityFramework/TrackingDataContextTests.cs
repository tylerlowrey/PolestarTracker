using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolestarTracker.Core.Models;
using PolestarTracker.EntityFramework;

namespace PolestarTracker.Tests.EntityFramework
{
    [TestClass]
    public class TrackingDataContextTests
    {
        [TestMethod]
        public void Can_Successfully_Add_TrackingRecord_To_Database()
        {
            using (var db = new TrackingDataContext())
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
