namespace ProductsApi.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProductsApi.Models.ProductsApiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            
        }

        protected override void Seed(ProductsApi.Models.ProductsApiContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Products.AddOrUpdate(p => p.ProductId,
                                        new Product { Name = "Moblie 1", Category = "SmartPhone",Price=5000},
                                        new Product { Name = "Mobile 2", Category = "QuertyPhone",Price=8000}
                                        );
            context.Reviews.AddOrUpdate(r => r.ReviewId,
                                       new Review { Title = "Review Title 1", Description = "Good", ProductId = 1 },
                                       new Review { Title = "Review Title 2", Description = "Okay", ProductId = 2 }
                                       );

        }
    }
}
