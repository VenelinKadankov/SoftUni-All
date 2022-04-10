using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Mail;

namespace ShoppingSpree
{
    class ShoppingSpree
    {
        static void Main(string[] args)
        {
            List<Person> people = CreatePeopleList();
            List<Product> products = CreateProductList();
            people = ShopProducts(people, products);
            PrintResult(people);
        }

        static List<Person> CreatePeopleList()
        {
            List<Person> people = new List<Person>();
            string[] input = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                string[] tokens = input[i].Split("=", StringSplitOptions.RemoveEmptyEntries).ToArray();
                Person current = new Person(tokens[0], int.Parse(tokens[1]));
                people.Add(current);
            }

            return people;
        }

        static List<Product> CreateProductList()
        {
            List<Product> products = new List<Product>();
            string[] input = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                string[] tokens = input[i].Split("=", StringSplitOptions.RemoveEmptyEntries).ToArray();
                Product current = new Product(tokens[0], int.Parse(tokens[1]));
                products.Add(current);
            }

            return products;
        }

        static List<Person> ShopProducts(List<Person> people, List<Product> products)
        {
            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string pers = tokens[0], product = tokens[1];

                Person searchedPerson = people.Find(a => a.Name == pers);
                Product searchedProduct = products.Find(a => a.Name == product);

                if (searchedPerson.Money >= searchedProduct.Price)
                {
                    searchedPerson.Money -= searchedProduct.Price;
                    Product bought = new Product(searchedProduct.Name, searchedProduct.Price);
                    searchedPerson.Products.Add(bought);
                    Console.WriteLine($"{pers} bought {product}");
                }
                else
                {
                    Console.WriteLine($"{searchedPerson.Name} can't afford {searchedProduct.Name}");
                }


                command = Console.ReadLine();
            }

            return people;
        }

        static void PrintResult(List<Person> people)
        {


            foreach (var item in people)
            {
                List<string> lineOfProducts = new List<string>();



                foreach (var product in item.Products)
                {
                    lineOfProducts.Add(product.Name);
                }

                if (lineOfProducts.Count > 0)
                {
                 Console.WriteLine($"{item.Name} - {string.Join(", ", lineOfProducts)}");
                }
                else
                {
                    Console.WriteLine($"{item.Name} - Nothing bought");
                }
            }
        }
    }

    class Person
    {
        public Person(string name, int money)
        {
            Name = name;
            Money = money;
            Products = new List<Product>();
        }

        public string Name { get; set; }
        public int Money { get; set; }
        public List<Product> Products { get; set; }// = new List<string>();
    }

    class Product
    {
        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }
        public int Price { get; set; }
    }
}
