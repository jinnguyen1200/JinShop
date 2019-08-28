using _1.Core.Domain.Business;
using _2.Data.Mappings.Business;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Data
{
    public class JinShopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public JinShopContext() : base("JinShopContext")
        {
            Configuration.LazyLoadingEnabled = false;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductMapping());
            modelBuilder.Configurations.Add(new CategoryMapping());
            base.OnModelCreating(modelBuilder);
        }
        
    }
}
