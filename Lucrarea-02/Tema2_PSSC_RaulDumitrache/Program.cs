using Exemple.Domain;
using System;
using System.Collections.Generic;
using static Exemple.Domain.ShoppingCart;

namespace Exemple
{
    class Program
    {
        private static readonly Random random = new Random();

        static void Main(string[] args)
        {
            var listOfProducts = ReadListOfProducts().ToArray();
            UnvalidatedShoppingCart products = new(listOfProducts);
            IShoppingCart result = products;
            result.Match(
                whenUnvalidatedShoppingCart: unvalidatedResult => unvalidatedResult,
                whenEmptyShoppingCart: emptyResult => emptyResult,
                whenPayedShoppingCart: payedResult => payedResult,
                whenValidatedShoppingCart: validatedResult => PayShoppingCart(validatedResult)
            );

            Console.WriteLine("Hello World!");
        }

        private static List<Product> ReadListOfProducts()
        {
            List <Product> listOfProducts = new();
            do
            {
                //read product code and quantity and create a list of products
                var productCode = ReadValue("Product code: ");
                if (string.IsNullOrEmpty(productCode))
                {
                    break;
                }

                var quantity = ReadValue("Quantity: ");
                if (string.IsNullOrEmpty(quantity))
                {
                    break;
                }

                listOfProducts.Add(new (productCode, quantity));
            } while (true);
            return listOfProducts;
        }

        private static IShoppingCart PayShoppingCart(ValidatedShoppingCart validShoppingCart) =>
            new PayedShoppingCart(new List<Product>(), DateTime.Now);

        private static string? ReadValue(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}
