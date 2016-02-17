using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace VM.Models
{
    public class DBContext : DbContext
    {
        public DbSet<Product> Product1 { get; set; }
        public DbSet<PurseVM> PurseVM1 { get; set; }
        public DbSet<PurseClient> PurseClient1 { get; set; }
        public DbSet<Amount> Amount1 { get; set; }
    }
}