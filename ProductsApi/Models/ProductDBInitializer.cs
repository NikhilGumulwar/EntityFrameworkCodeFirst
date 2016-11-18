using System.Data.Entity;


namespace ProductsApi.Models
{
    public class ProductDBInitializer : IDatabaseInitializer<ProductsApiContext>
    {
        //void IDatabaseInitializer<ProductsApiContext>.InitializeDatabase(ProductsApiContext context)
        //{
        //    throw new NotImplementedException();
        //}

        public void InitializeDatabase(ProductsApiContext context)
        {
          if(context.Database.Exists())
            {
                if(!context.Database.CompatibleWithModel(true))
                {
                    context.Database.Delete();
                }
            }
            context.Database.Create();

        }
    }
}