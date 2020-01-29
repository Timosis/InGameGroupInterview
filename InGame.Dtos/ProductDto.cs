﻿using System;
using System.Collections.Generic;
using System.Text;

namespace InGame.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }        
    }
}
