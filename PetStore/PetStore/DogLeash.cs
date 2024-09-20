using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore
{
    public class DogLeash : Product
    {
        public string Material { get; set; } = string.Empty;
        public int LengthInches { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
