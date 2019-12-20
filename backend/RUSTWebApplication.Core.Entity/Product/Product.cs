﻿using System.Collections.Generic;

namespace RUSTWebApplication.Core.Entity.Product
{
	public class Product
	{
		public int Id { get; set; }
        public string Color { get; set; }
        public ProductModel ProductModel { get; set; }
		public List<ProductStock> ProductStocks { get; set; }
		public string ImagePath { get; set; }
		public string VideoPath { get; set; }
	}
}
