using _1.Core.Domain.Business;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Data.Mappings.Business
{
    public class ProductMapping : EntityTypeConfiguration<Product>
    {
        public ProductMapping()
        {
            ToTable("Product");
            HasRequired(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryID);
            
        }
    }
}
