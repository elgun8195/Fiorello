﻿using System.Collections.Generic;

namespace Fiorello_Web_Application.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }

    }
}