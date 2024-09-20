using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;

namespace PetStore
{
    public interface IProductLogic
    {
        void AddProduct(Product product);
        DogLeash? GetDogLeashByName(string name);
        CatFood? GetCatFoodByName(string name);
        List<Product> GetOnlyInStockProducts();
        decimal GetTotalPriceOfInventory();
    }
}
