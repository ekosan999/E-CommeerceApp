﻿using System.ComponentModel.DataAnnotations;

namespace E_CommeerceApp.Dtos.Products
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }
}
