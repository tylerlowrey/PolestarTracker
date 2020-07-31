﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolestarTracker.Core.Models;
using PolestarTracker.EntityFramework;

namespace PolestarTracker.Tests.EntityFramework
{
    [TestClass]
    public class SettingsDbTests
    {
        internal class ApplicationTestsContext : ApplicationDataContext
        {

            protected override void OnConfiguring(DbContextOptionsBuilder options)
            {
                options.UseSqlite("Data Source=../../../tracking.db");
            }

        }

        [TestMethod]
        public void Can_Successfully_Add_ApplicationFilter_To_DB()
        {
            using var db = new ApplicationTestsContext();
            var newApplicationFilter = new ApplicationFilter
            {
                ProcessName = "Idle"
            };

            db.Add(newApplicationFilter);
            db.SaveChanges();

            var lastInsertedRecord = db.ApplicationFilters.OrderByDescending(filterRecord => filterRecord.Id)
                                       .FirstOrDefault();

            Assert.AreEqual(newApplicationFilter, lastInsertedRecord);

        }

        [TestMethod]
        public void Can_Successfully_Add_ApplicationAlias_To_DB()
        {
            using var db = new ApplicationTestsContext();
            var newApplicationAlias = new ApplicationAlias
            {
                Alias = "Visual Studio",
                ProcessName = "devenv",
            };

            db.Add(newApplicationAlias);
            db.SaveChanges();

            var lastInsertedRecord = db.ApplicationAliases.OrderByDescending(aliasRecord => aliasRecord.Id)
                                       .FirstOrDefault();

            Assert.AreEqual(newApplicationAlias, lastInsertedRecord);
        }
    }
}