using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Collections.Generic;
using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Models;

using AutoMapper;
using ProductShop.Dtos.Export;
using Microsoft.EntityFrameworkCore;
//using ProductShop.XmlFacade;

namespace ProductShop
{
    public class StartUp
    {
        public static IMapper mapper;

        public static void Main(string[] args)
        {
            var db = new ProductShopContext();
            // db.Database.EnsureDeleted();
            // db.Database.EnsureCreated();


            var usersXml = File.ReadAllText("./../../../Datasets/users.xml");
            var productsXml = File.ReadAllText("./Datasets/products.xml");
            var categoriesXml = File.ReadAllText("./Datasets/categories.xml");
            var categoryProductsXml = File.ReadAllText("./Datasets/categories-products.xml");

            var result = GetUsersWithProducts(db);


            Console.WriteLine(result);
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var serializer = new XmlSerializer(typeof(UserProductsResult), new XmlRootAttribute("Users"));

            var usersProducts = context.Users
                .Include(x => x.ProductsSold)
                .ToList()
                .Where(x => x.ProductsSold.Count > 0)
                .Select(x => new UserWithProductsOutputModel
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    Products = new ProductsInfo
                    {
                        Count = x.ProductsSold.Count,
                        Products = x.ProductsSold
                        .Select(p => new SoldProduct
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray()
                    }
                })
                .OrderByDescending(x => x.Products.Count)
                .Take(10)
                .ToArray();

            var countUsers = context.Users
                .Where(x => x.ProductsSold.Any(p => p.BuyerId != null))
                .Count();

            var userResults = new UserProductsResult
            {
                Count = countUsers,
                Users = usersProducts
            };

            var writer = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            
            serializer.Serialize(writer, userResults, ns);

            var result = writer.ToString();

            return result;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var serializer = new XmlSerializer(typeof(CategoryOutputModel[]), new XmlRootAttribute("Categories"));

            var categories = context.Categories
                .Select(x => new CategoryOutputModel
                {
                    Name = x.Name,
                    Count = x.CategoryProducts.Count,
                    Average = x.CategoryProducts.Average(p => p.Product.Price),
                    TotalRevenue = x.CategoryProducts.Sum(p => p.Product.Price)
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TotalRevenue)
                .ToArray();

            var writer = new StringWriter();
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            serializer.Serialize(writer, categories, ns);

            var result = writer.ToString();

            return result;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var serializer = new XmlSerializer(typeof(SoldProductsModel[]), new XmlRootAttribute("Users"));

            var productsByUser = context.Users
                .Where(x => x.ProductsSold.Count() > 0)
                .Select(x => new SoldProductsModel
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Products = x.ProductsSold.Select(p => new ProductShort
                    {
                        Name = p.Name,
                        Price = p.Price
                    }).ToArray()
                })
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Take(5)
                .ToArray();

            var users = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            serializer.Serialize(users, productsByUser, ns);

            var result = users.ToString();

            return result;
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var serializer = new XmlSerializer(typeof(ProductOutputModel[]), new XmlRootAttribute("Products"));

            var productModels = context.Products
                .Select(x => new ProductOutputModel
                {
                    Name = x.Name,
                    Price = x.Price,
                    FullNameBuyer = x.BuyerId != null ? x.Buyer.FirstName + " " + x.Buyer.LastName : null
                })
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .Take(10)
                .ToArray();

            var products = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            serializer.Serialize(products, productModels, ns);

            var result = products.ToString();

            return result;
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            InitializeMapper();

            var serializer = new XmlSerializer(typeof(CategoryProductInputModel[]), new XmlRootAttribute("CategoryProducts"));

            var categoryProductsDto = serializer.Deserialize(new StringReader(inputXml)) as CategoryProductInputModel[];

            var categIds = context.Categories.Select(x => x.Id).ToList();
            var prodIds = context.Products.Select(x => x.Id).ToList();

            var categoryProducts = mapper.Map<CategoryProduct[]>(categoryProductsDto)
                                            .Where(x => categIds.Contains(x.CategoryId) && prodIds.Contains(x.ProductId))
                                            .ToArray();

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Length}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            InitializeMapper();

            var serializer = new XmlSerializer(typeof(CategoryInputModel[]), new XmlRootAttribute("Categories"));
            CategoryInputModel[] categoriesDto;

            using (var reader = new StringReader(inputXml))
            {
                categoriesDto = serializer.Deserialize(reader) as CategoryInputModel[];
            }

            categoriesDto = categoriesDto.Where(x => x != null).ToArray();

            var categories = mapper.Map<Category[]>(categoriesDto);

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            InitializeMapper();

            var serializer = new XmlSerializer(typeof(ProductInputModel[]), new XmlRootAttribute("Products"));

            ProductInputModel[] productsDto;

            using (var reader = new StringReader(inputXml))
            {
                productsDto = (ProductInputModel[])serializer.Deserialize(reader);
            }

            var products = mapper.Map<Product[]>(productsDto);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            InitializeMapper();

            var serializer = new XmlSerializer(typeof(UserInputDto[]), new XmlRootAttribute("Users"));

            IEnumerable<UserInputDto> usersDto;// = (UserInputDto[])serializer.Deserialize(File.OpenRead(inputXml));

            using (var reader = new StringReader(inputXml))
            {
                usersDto = (IEnumerable<UserInputDto>)serializer.Deserialize(reader);
            }


            var users = mapper.Map<IEnumerable<User>>(usersDto);

            context.Users.AddRange(users);
            context.SaveChanges();


            return $"Successfully imported {users.Count()}";
        }

        private static void InitializeMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ProductShopProfile());
            });

            mapper = config.CreateMapper();
        }

    }
}