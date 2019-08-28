namespace _2.Data.Migrations
{
    using _1.Core.Domain.Business;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_2.Data.JinShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(_2.Data.JinShopContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            CreateProducts(context);
        }
        private void CreateProducts(JinShopContext context)
        {
            if (context.Products.Count() == 0)
            {
                var listProduct = new List<Product>()
                {
                    new Product()
                    {
                        Name = "A1",
                        Description = "aaa"
                    },
                    new Product()
                    {
                        Name = "1B",
                        Description = "aaa"
                    },
                    new Product()
                    {
                        Name = "C1",
                        Description = "aaa"
                    },
                };
                context.Products.AddRange(listProduct);
                context.SaveChanges();
            }
        }
    }
}
