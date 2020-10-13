using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sales_and_Finance.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext():base("SandFdata")
        {
                
        }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<Finance> Finances { get; set; }
    }
}