﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PumpedUpKicks.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string Image { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }
    }
}
