using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore
{
    public class CatFood : Product
    {
        public string Flavor { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
