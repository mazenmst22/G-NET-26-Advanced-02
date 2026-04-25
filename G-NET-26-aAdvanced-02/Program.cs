using G_NET_26_aAdvanced_02.ShopMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_NET_26_aAdvanced_02
{
    public class Program
    {
        public static List<Product> SearchProducts(List<Product> products, Func<Product, bool> filter)
        {
            List<Product> result = new List<Product>();
            foreach (var product in products)
            {
                if (filter(product))
                {
                    result.Add(product);
                }
            }
            return result;
        }
        public static void Main(string[] args)
        {

            List<Product> catalog= new()
            {
                new Product {Id = 1, Name = "Laptop", Category = "Electronics", Price = 1200, Stock = 10},
                new Product {Id = 2, Name = "Phone", Category = "Electronics", Price = 800, Stock = 25},
                new Product {Id = 3, Name = "T-Shirt", Category = "Clothing", Price = 30, Stock = 100},
                new Product {Id = 4, Name = "Jeans", Category = "Clothing", Price = 60, Stock = 50},
                new Product {Id = 5, Name = "Chocolate", Category = "Food", Price = 5, Stock = 200},
                new Product {Id = 6, Name = "Cofee Beans", Category = "Food", Price = 15, Stock = 80},
                new Product {Id = 7, Name = "C# Book", Category = "Books", Price = 45, Stock = 30},
                new Product {Id = 8, Name = "Novel", Category = "Books", Price = 20, Stock = 60},
                new Product {Id = 9, Name = "Headphones", Category = "Electronics", Price = 150, Stock = 15}

            };
            var electronics = SearchProducts(catalog, p => p.Category == "Electronics");
            var under50 = SearchProducts(catalog, p => p.Price < 50);
            var inStock = SearchProducts(catalog, p => p.Stock > 0);
            var clothingUnder100 = SearchProducts(catalog, p => p.Category == "Clothing" && p.Price < 100);

            PrintResults("--- Electronics ---", electronics);
            Console.WriteLine();
            PrintResults("--- Under $50 ---", under50);
            Console.WriteLine();
            PrintResults("--- In Stock ---", inStock);
            Console.WriteLine();
            PrintResults("--- Clothing Under $100 ---", clothingUnder100);
        }

        private static void PrintResults(string title, List<Product> products)
        {
            Console.WriteLine(title);
            foreach (var p in products)
            {
                Console.WriteLine($"{p.Name} : ${p.Price} (Stock: {p.Stock})");
            }
        }
    }
}

