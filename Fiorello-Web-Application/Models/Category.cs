﻿using System.Collections;
using System.Collections.Generic;

namespace Fiorello_Web_Application.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string  Desc { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
