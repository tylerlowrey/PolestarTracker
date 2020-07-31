using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PolestarTracker.Core.Models;

namespace PolestarTracker.EntityFramework
{
    class SettingsDataContext : DbContext
    {
        public DbSet<ApplicationAlias> ApplicationAliases { get; set; }
        public DbSet<ApplicationFilter> ApplicationFilters { get; set; }

    }
}
