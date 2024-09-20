using System.Collections.Generic;
using System.Linq;

namespace PetStore
{
    public static class ListExtensions
    {
        // This is the extension method that will filter in-stock products
        public static List<T> InStock<T>(this List<T> list) where T : Product
        {
            // Filter to only products that have a quantity greater than 0
            return list.Where(x => x.Quantity > 0).ToList();
        }
    }
}
