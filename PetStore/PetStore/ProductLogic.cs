using System;
using System.Collections.Generic;
using System.Linq;

namespace PetStore
{
    public class ProductLogic : IProductLogic
    {
        private List<Product> _products;  // List to store all products
        private Dictionary<string, DogLeash> _dogLeashes;  // Dictionary for DogLeash products
        private Dictionary<string, CatFood> _catFoods;  // Dictionary for CatFood products

        public ProductLogic()
        {
            _products = new List<Product>
            {
                // Adding sample products for testing
                new DogLeash { Name = "Durable Leash", Quantity = 5, Price = 12.99m },
                new DogLeash { Name = "Stylish Leash", Quantity = 0, Price = 15.99m }, // Out of stock
                new CatFood { Name = "Premium Cat Food", Quantity = 10, Price = 25.99m }
            };

            _dogLeashes = new Dictionary<string, DogLeash>();
            _catFoods = new Dictionary<string, CatFood>();
        }

        public void AddProduct(Product product)
        {
            if (product is DogLeash dogLeash)
            {
                if (!string.IsNullOrEmpty(dogLeash.Name)) // Check if Name is not null or empty
                {
                    _dogLeashes[dogLeash.Name] = dogLeash;
                }
            }
            else if (product is CatFood catFood)
            {
                if (!string.IsNullOrEmpty(catFood.Name)) // Check if Name is not null or empty
                {
                    _catFoods[catFood.Name] = catFood;
                }
            }

            _products.Add(product);
        }

        public List<Product> GetAllProducts()
        {
            return _products;
        }

        public DogLeash? GetDogLeashByName(string name)
        {
            if (string.IsNullOrEmpty(name)) // Ensure name is not null or empty
            {
                return null;
            }

            _dogLeashes.TryGetValue(name, out var dogLeash); // Safely try to get value
            return dogLeash;
        }

        public List<Product> GetOnlyInStockProducts()
        {
            return _products.Where(p => p.Quantity > 0).ToList();  // Filters in-stock products
        }
    }
}
