﻿namespace Orders.Application.Dtos
{
    public class ProductDto
    { 
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
