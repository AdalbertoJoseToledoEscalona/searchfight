using searchfight.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace searchfight.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<SearchEngine> SearchEngines { get; set; }
        public DbSet<ParameterType> ParameterTypes { get; set; }
        public DbSet<Parameter> Parameters { get; set; }
    }
}
