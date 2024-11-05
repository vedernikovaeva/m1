using System;
namespace ПР_МР
{
	public class Product
	{
        public string Name { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerUnit { get; set; }

        public Product(string name, string category, int quantity, decimal pricePerUnit)
        {
            Name = name;
            Category = category;
            Quantity = quantity;
            PricePerUnit = pricePerUnit;
        }
    }
}

