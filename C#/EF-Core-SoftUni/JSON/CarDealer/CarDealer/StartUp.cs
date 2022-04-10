using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CarDealer
{
    public class StartUp
    {
        static IMapper mapper;

        public static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CarDealerContext>();
            optionsBuilder.UseSqlServer("Server = .; Database = CarDealer; Integrated Security = true");

            var db = new CarDealerContext(optionsBuilder.Options);
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();

            var jsonSuppliers = File.ReadAllText("../../../Datasets/suppliers.json");
            var jsonParts = File.ReadAllText("../../../Datasets/parts.json");
            var jsonCars = File.ReadAllText("../../../Datasets/cars.json");
            var jsonCustomers = File.ReadAllText("../../../Datasets/customers.json");
            var jsonSales = File.ReadAllText("../../../Datasets/sales.json");

            //ImportSuppliers(db, jsonSuppliers);
            //ImportParts(db, jsonParts);
            //ImportCars(db, jsonCars);
            //ImportCustomers(db, jsonCustomers);
            //ImportSales(db, jsonSales);

            //GetOrderedCustomers(db);
            //GetCarsFromMakeToyota(db);
            //GetLocalSuppliers(db);
            //GetCarsWithTheirListOfParts(db);
            //GetTotalSalesByCustomer(db);
            var result = GetSalesWithAppliedDiscount(db);

            Console.WriteLine(result);
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(x => new
                {
                    car = new
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance
                    },
                    customerName = x.Customer.Name,
                    Discount = $"{x.Discount:F2}",
                    price = $"{x.Car.PartCars.Sum(p => p.Part.Price):F2}",
                    priceWithDiscount = $"{x.Car.PartCars.Sum(p => p.Part.Price) * (1 - x.Discount / 100):F2}"
                })
                .Take(10)
                .ToList();

            var result = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return result;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Select(x => new
                {
                    fullName = x.Name,
                    boughtCars = x.Sales.Count,
                    spentMoney = x.Sales.Select(c => new
                    {
                        parts = c.Car.PartCars
                        .Sum(p => p.Part.Price)
                    })
                    .Sum(k => k.parts)
                })
                .OrderByDescending(x => x.spentMoney)
                .ThenByDescending(x => x.boughtCars)
                .ToList();

            var result = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return result;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(x => new
                {
                    car = new
                    {
                        x.Make,
                        x.Model,
                        x.TravelledDistance,
                    },
                    parts = x.PartCars.Select(y => new
                    {
                        Name = y.Part.Name,
                        Price = $"{y.Part.Price:F2}"
                    })
                })
                .ToList();

            var result = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return result;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    PartsCount = x.Parts.Count
                })
                .ToList();

            var result = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            return result;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(x => new
                {
                    x.Id,
                    x.Make,
                    x.Model,
                    x.TravelledDistance
                })
                .Where(x => x.Make == "Toyota")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ToList();

            var result = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return result;
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .Select(x => new
                {
                    Name = x.Name,
                    BirthDate = x.BirthDate.ToString("dd/MM/yyyy"),
                    IsYoungDriver = x.IsYoungDriver
                })
                .ToList();

            var result = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return result;
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            InitializeMapper();

            var salesDto = JsonConvert.DeserializeObject<IEnumerable<SaleInputModel>>(inputJson);

            var sales = mapper.Map<IEnumerable<Sale>>(salesDto);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            InitializeMapper();

            var customersDto = JsonConvert.DeserializeObject<IEnumerable<CustomerInputModel>>(inputJson);

            var customers = mapper.Map<IEnumerable<Customer>>(customersDto);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {

            var carsDto = JsonConvert.DeserializeObject<IEnumerable<CarInputModel>>(inputJson);

            var listOfCars = new List<Car>();

            foreach (var car in carsDto)
            {
                var currentCar = new Car
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance
                };

                foreach (var partId in car?.PartsId.Distinct())
                {
                    currentCar.PartCars.Add(new PartCar
                    {
                        PartId = partId
                    });
                }

                listOfCars.Add(currentCar);
            }

            context.Cars.AddRange(listOfCars);
            context.SaveChanges();


            return $"Successfully imported {listOfCars.Count()}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            InitializeMapper();

            var partsDto = JsonConvert.DeserializeObject<IEnumerable<PartInputModel>>(inputJson);
            var supplierIds = context.Suppliers.Select(x => x.Id).ToList();

            partsDto = partsDto.Where(p => supplierIds.Contains(p.SupplierId));

            var parts = mapper.Map<IEnumerable<Part>>(partsDto);

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}.";
        }


        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            InitializeMapper();

            var suppliersDto = JsonConvert.DeserializeObject<IEnumerable<SupplierInputModel>>(inputJson);

            var suppliers = mapper.Map<IEnumerable<Supplier>>(suppliersDto);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}.";
        }


        private static void InitializeMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            mapper = config.CreateMapper();
        }
    }
}