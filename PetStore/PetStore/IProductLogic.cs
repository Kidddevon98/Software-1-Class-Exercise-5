using System.Collections.Generic;

namespace PetStore
{
    public interface IProductLogic
    {
        void AddProduct(Product product);
        List<Product> GetAllProducts();
        List<Product> GetOnlyInStockProducts();  // This is the method for returning only in-stock products.
    }
}
