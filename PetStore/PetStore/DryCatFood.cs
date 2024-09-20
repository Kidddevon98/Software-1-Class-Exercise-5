﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore
{
    public class DryCatFood : CatFood
    {
        public string Brand { get; set; } = string.Empty;
        public new string Description { get; set; } = string.Empty;
    }
}
