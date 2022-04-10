using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.DataTransferObject;
using ProductShop.Models;
using ProductShop.ViewModels;

namespace ProductShop
{
    public class StartUp
    {
        static IMapper mapper;

        public static void Main(string[] args)
        {
            var db = new ProductShopContext();
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();

            var jsonUsers = File.ReadAllText("../../../Datasets/users.json");
            var jsonProducts = File.ReadAllText("../../../Datasets/products.json");
            var jsonCategories = File.ReadAllText("../../../Datasets/categories.json");
            var jsonCatProd = File.ReadAllText("../../../Datasets/categories-products.json");

            //ImportCategories(db, jsonCategories);
            //ImportUsers(db, jsonUsers);
            //ImportProducts(db, jsonProducts);
            //ImportCategoryProducts(db, jsonCatProd);
            //GetProductsInRange(db);
            //GetSoldProducts(db);
            //GetCategoriesByProductsCount(db);
            var result = GetUsersWithProducts(db);


            Console.WriteLine(result);
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {

            var usersC = context.Users
                .Include(x => x.ProductsSold)
                .ToList()
                .Where(x => x.ProductsSold.Any(p => p.BuyerId != null))
                .Select(x => new
                {
                        firstName = x.FirstName,
                        lastName = x.LastName,
                        age = x.Age,
                        soldProducts =  new
                        {
                            count = x.ProductsSold.Where(p => p.BuyerId != null).Count(),
                            products = x.ProductsSold.Where(p => p.BuyerId != null).Select(k => new
                            {
                                name = k.Name,
                                price = k.Price
                            })
                        }
                })
                .OrderByDescending(x => x.soldProducts.products.Count())
                .ToList();

            var result = new
            {
                usersCount = usersC.Count(),
                users = usersC
            };

            var jsonSerializeSett = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            var jsonUser = JsonConvert.SerializeObject(result, Formatting.Indented, jsonSerializeSett);

            return jsonUser;
        }


        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(x => new
                {
                    category = x.Name,
                    productsCount = x.CategoryProducts.Count,
                    averagePrice = $"{x.CategoryProducts.Average(p => p.Product.Price):F2}",
                    totalRevenue = $"{x.CategoryProducts.Sum(p => p.Product.Price):F2}"
                })
                .OrderByDescending(x => x.productsCount)
                .ToList();

            var jsonCateg = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return jsonCateg;
        }


        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Any(p => p.BuyerId != null))
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    soldProducts = x.ProductsSold
                    .Select(y => new
                    {
                        name = y.Name,
                        price = y.Price,
                        buyerFirstName = y.Buyer.FirstName,
                        buyerLastName = y.Buyer.LastName
                    })
                })
                .OrderBy(x => x.lastName)
                .ThenBy(x => x.lastName)
                .ToList();

            var jsonUsers = JsonConvert.SerializeObject(users, Formatting.Indented);

            return jsonUsers;
        }


        public static string GetProductsInRange(ProductShopContext context)
        {
            InitializeMapper();

            var prods = context.Products
                .Select(x => new ProductViewModel
                {
                    Price = x.Price,
                    Name = x.Name,
                    FullNameSeller = x.Seller.FirstName + " " + x.Seller.LastName
                })
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .ToList();

            //var products = mapper.Map<IEnumerable<ProductViewModel>>(prods);

            //var settings = new JsonSerializerSettings
            //{
            //    Formatting = Formatting.Indented,
            //    ContractResolver = new DefaultContractResolver
            //    {
            //        NamingStrategy = new CamelCaseNamingStrategy()
            //    }
            //};

            var jsonType = JsonConvert.SerializeObject(prods, Formatting.Indented);

            //File.WriteAllText("products-in-range.json", jsonType);

            return jsonType;
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            InitializeMapper();

            var categoryProducts = JsonConvert.DeserializeObject<IEnumerable<CategoryProductModel>>(inputJson);

            var cProducts = mapper.Map<IEnumerable<CategoryProduct>>(categoryProducts);

            context.CategoryProducts.AddRange(cProducts);
            ;
            context.SaveChanges();

            return $"Successfully imported {cProducts.Count()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            InitializeMapper();

            var categoriesDto = JsonConvert
                .DeserializeObject<IEnumerable<CategoryInputModel>>(inputJson)
                .Where(x => x.Name != null)
                .ToList();

            var categories = mapper.Map<IEnumerable<Category>>(categoriesDto);

            context.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            InitializeMapper();

            var productsDto = JsonConvert.DeserializeObject<IEnumerable<ProductInputModel>>(inputJson);

            var products = mapper.Map<IEnumerable<Product>>(productsDto);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            InitializeMapper();

            var usersDto = JsonConvert.DeserializeObject<IEnumerable<UserInputModel>>(inputJson);

            var users = mapper.Map<IEnumerable<User>>(usersDto);

            context.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }

        private static void InitializeMapper()
        {

            var config = new MapperConfiguration(c =>
            {
                c.AddProfile<ProductShopProfile>();
            });

            mapper = config.CreateMapper();
        }
    }
}