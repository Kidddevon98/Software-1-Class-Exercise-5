using System;
using System.Collections.Generic;

namespace StoreApp
{
    public class ProductLogic
    {
        private List<Product> _products;
        private Dictionary<string, DogLeash> _dogLeashes;
        private Dictionary<string, CatFood> _catFoods;

        public ProductLogic()
        {
            _products = new List<Product>();
            _dogLeashes = new Dictionary<string, DogLeash>();
            _catFoods = new Dictionary<string, CatFood>();
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);

            if (product is DogLeash dogLeash)
            {
                _dogLeashes[dogLeash.Name] = dogLeash;
            }
            else if (product is CatFood catFood)
            {
                _catFoods[catFood.Name] = catFood;
            }
        }

        public List<Product> GetAllProducts()
        {
            return _products;
        }

        public DogLeash GetDogLeashByName(string name)
        {
            try
            {
                return _dogLeashes[name];
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }
    }
}
