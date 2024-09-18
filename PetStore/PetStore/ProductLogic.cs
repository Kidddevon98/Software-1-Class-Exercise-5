using System.Collections.Generic;
using System.Linq;

namespace PetStore
{
    public class ProductLogic : IProductLogic
    {
        private List<Product> _products;

        public ProductLogic()
        {
            _products = new List<Product>
            {
                new DogLeash { Name = "Leather Leash", Quantity = 5 },
                new DogLeash { Name = "Nylon Leash", Quantity = 0 }, // Out of stock
                new CatFood { Name = "Whiskas Cat Food", Quantity = 10 }
            };
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public List<Product> GetOnlyInStockProducts()
        {
            // Filtering products that are in stock (Quantity > 0)
            return _products.Where(x => x.Quantity > 0).ToList();
        }

        public DogLeash? GetDogLeashByName(string name)
        {
            return _products.OfType<DogLeash>().FirstOrDefault(dl => dl.Name == name);
        }
    }
}
