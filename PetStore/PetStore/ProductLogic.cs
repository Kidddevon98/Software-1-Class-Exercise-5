using System.Collections.Generic;
using System.Linq;

namespace PetStore
{
    public class ProductLogic : IProductLogic
    {
        private Dictionary<string, DogLeash> _dogLeashes = new Dictionary<string, DogLeash>();
        private Dictionary<string, CatFood> _catFoods = new Dictionary<string, CatFood>();

        public void AddProduct(Product product)
        {
            if (product is DogLeash dogLeash)
            {
                _dogLeashes[dogLeash.Name] = dogLeash;
            }
            else if (product is CatFood catFood)
            {
                _catFoods[catFood.Name] = catFood;
            }
        }

        public DogLeash? GetDogLeashByName(string name)
        {
            _dogLeashes.TryGetValue(name, out var dogLeash);
            return dogLeash;
        }

        public CatFood? GetCatFoodByName(string name)
        {
            _catFoods.TryGetValue(name, out var catFood);
            return catFood;
        }

        public List<Product> GetOnlyInStockProducts()
        {
            var inStockProducts = new List<Product>();
            inStockProducts.AddRange(_dogLeashes.Values.Where(dl => dl.Quantity > 0));
            inStockProducts.AddRange(_catFoods.Values.Where(cf => cf.Quantity > 0));
            return inStockProducts;
        }

        public decimal GetTotalPriceOfInventory()
        {
            return GetOnlyInStockProducts()
                .Sum(p => p.Price * p.Quantity);
        }
    }
}
