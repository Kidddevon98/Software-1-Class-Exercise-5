using System.Collections.Generic;

namespace PetStore
{
    public interface IProductLogic
    {
        void AddProduct(Product product);
        List<Product> GetOnlyInStockProducts(); // Ensure the return type matches
    }
}
