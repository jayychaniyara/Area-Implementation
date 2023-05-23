using Assesment.DomainModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment.DataLayer
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext() : base("CompanyConnection")
        {
        }
        public DbSet<Brand> Brands { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}
