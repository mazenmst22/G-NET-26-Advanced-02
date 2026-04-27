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
        #region Task 1
        //1
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
        //I have used this method to search for products based on different criteria in the Main method.
        //It takes a list of products and a filter function, and returns a new list of products that match the filter condition.
        //I used func to allow flexible and reusable code, so I can easily search for products based on various attributes like category,
        //price, and stock without having to write separate methods for each case (Hard coded). This ensures reusability and the ability to extend code later on.
        #endregion
        #region Task 3
        #region Task 3.1
        //3.1
        public static void PrintReport(List<Product> products, Action<Product> printAction)
        {
            foreach (var product in products)
            {
                printAction(product);
            }
        }

        //This method is designed to print a report of products using a provided print action in a loop.
        //It takes a list of products and an Action delegate that defines how each product should be printed.
        //This allows for flexible reporting, as you can easily change the print format by passing different actions without modifying the method itself.
        //This allows code reusability and removes the hard coding of this method making it reusable and accepting different scenarios
        //for the same piece of code, and allows extensibility.
        #endregion
        #region Task 3.2
        //3.2
        public static List<string> TransformProducts(List<Product> products, Func<Product, string> transformFunc)
        {
            List<string> result = new List<string>();
            foreach (var product in products)
            {
                result.Add(transformFunc(product));
            }
            return result;
        }
        //This method Transforms a list of products into a list of strings, it accepts a list of products and a func of type Func<Product, string>
        //that defines how to transform each product into a string representation.
        //using func allows for flexible transformations,
        //as you can easily change the output format by passing different transformation functions without modifying the method itself.
        #endregion
        #region Task 3.3
        //3.3
        public static List<Product> FilterProducts(List<Product> products, Predicate<Product> match)
        {
            List<Product> result = new List<Product>();
            foreach (var product in products)
            {
                if (match(product))
                {
                    result.Add(product);
                }
            }
            return result;
        }
        //This method filters a list based on a provided predicate, it takes a list of products and a Predicate delegate that defines the condition for filtering.
        //Using Predicate allows for flexible filtering,
        //as you can easily change the filtering criteria by passing different predicates without modifying the method itself.
        #endregion
        #endregion
        public static void Main(string[] args)
        {
            #region Product catalog
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
            #endregion
            #region Task 1 implementation
            var electronics = SearchProducts(catalog, p => p.Category == "Electronics");
            var under50 = SearchProducts(catalog, p => p.Price < 50);
            var inStock = SearchProducts(catalog, p => p.Stock > 0);
            var clothingUnder100 = SearchProducts(catalog, p => p.Category == "Clothing" && p.Price < 100);
            //This code demonstrates the use of the SearchProducts method to filter products based on different criteria such as category, price, and stock availability.
            #endregion
            #region Task 3 implementation
            #region 3.1 implementation
            //3.1
            Console.WriteLine("--- Short Report ---");
            PrintReport(catalog, p => Console.WriteLine($"{p.Name} - ${p.Price}"));
            //This code demonstrates the use of the PrintReport method to generate a short report of products,
            //displaying only the name and price of each product.

            Console.WriteLine("\n--- Detailed Report ---");
            PrintReport(catalog, p => Console.WriteLine($"[{p.Category}] {p.Name} | Price: ${p.Price} | Stock: {p.Stock}"));
            //This code demonstrates the use of the PrintReport method to generate a detailed report of products,
            //displaying the category, name, price, and stock of each product.
            #endregion
            #region 3.2 implementation
            //3.2
            Console.WriteLine("--- Summary List ---");
            var summaryList = TransformProducts(catalog, p => $"{p.Name} (${p.Price})");
            foreach (var item in summaryList)
            {
                Console.WriteLine(item);
            }
            //This code demonstrates the use of the TransformProducts method to create a summary list of products,
            //displaying the name and price of each product in a concise format.
            Console.WriteLine("\n--- Price Labels ---");
            List<Product> labelCatalog = new() { catalog[0], catalog[1], catalog[2], catalog[7] };
            var priceLabels = TransformProducts(labelCatalog, p => $"{p.Name}: {(p.Price > 100 ? "Expensive!" : "Affordable")}");
            foreach (var item in priceLabels)
            {
                Console.WriteLine(item);

            }
            //This code demonstrates the use of the TransformProducts method to create price labels for a subset of products,
            //indicating whether each product is "Expensive!" or "Affordable" based on its price.
            #endregion
            #region 3.3 implementation
            //3.3
            Console.WriteLine("--- Low-Stock Alert ---");
            var lowStockProducts = FilterProducts(catalog, p => p.Stock < 20);
            foreach (var p in lowStockProducts)
            {
                Console.WriteLine($"[LOW STOCK] {p.Name}: only {p.Stock} left!");
            }
            //This code demonstrates the use of the FilterProducts method to identify products with low stock,
            //and generates an alert message for each product that has less than 20 items in stock.
            #endregion
            #endregion
        }
    }
}

