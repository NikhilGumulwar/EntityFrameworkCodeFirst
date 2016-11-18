using System.Data.Entity;


namespace ProductsApi.Models
{
    public class ProductsApiContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ProductsApiContext() : base("name=Demo")
        {
            if (Configuration != null) Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ProductsApiContext>());
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Review> Reviews { get; set; }
    }
}
