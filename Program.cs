using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;


namespace ПР_МР
{
    class Program
    {
        static void Main()
        {
            List<Product> products = new List<Product>
        {
            new Product("Яблуко", "Фрукти", 50, 1.2m),
            new Product("Банан", "Фрукти", 100, 0.8m),
            new Product("Морква", "Овочі", 75, 0.5m),
            new Product("Помідор", "Овочі", 60, 1.1m)
        };

            Console.WriteLine("Введіть назву категорії для підрахунку (фрукти або овочі):");
            string category = Console.ReadLine();

            var (totalQuantity, totalCost) = CalculateCategoryTotals(products, category);

            Console.WriteLine($"\nКатегорія: {category}");
            Console.WriteLine($"Загальна кількість: {totalQuantity}");
            Console.WriteLine($"Загальна вартість: {totalCost:C}");

            string filePath = "products.xml";
            SaveProductsToXml(products, filePath);
            Console.WriteLine($"\nДані збережено у файл {filePath}");
        }

        public static (int totalQuantity, decimal totalCost) CalculateCategoryTotals(List<Product> products, string category)
        {
            var filteredProducts = products.Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
            int totalQuantity = filteredProducts.Sum(p => p.Quantity);
            decimal totalCost = filteredProducts.Sum(p => p.Quantity * p.PricePerUnit);

            return (totalQuantity, totalCost);
        }

        public static void SaveProductsToXml(List<Product> products, string filePath)
        {
            XElement xml = new XElement("Products",
                products.Select(p =>
                    new XElement("Product",
                        new XElement("Name", p.Name),
                        new XElement("Category", p.Category),
                        new XElement("Quantity", p.Quantity),
                        new XElement("PricePerUnit", p.PricePerUnit)
                    )
                )
            );

            xml.Save(filePath);
        }

    }
}
