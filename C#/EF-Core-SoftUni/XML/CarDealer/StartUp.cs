using System;
using System.IO;
using System.Xml.Serialization;

using CarDealer.Data;
using CarDealer.Dto.Import;


using AutoMapper;
using CarDealer.Models;
using System.Linq;
using System.Collections.Generic;
using CarDealer.Dto.Export;
using Microsoft.EntityFrameworkCore;

namespace CarDealer
{
    public class StartUp
    {
        public static IMapper mapper;
        public static void Main(string[] args)
        {
            var db = new CarDealerContext();
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();

                var suppliersXml = File.ReadAllText("./../../../Datasets/suppliers.xml");
                var partsXml = File.ReadAllText("./../../../Datasets/parts.xml");
                var carsXml = File.ReadAllText("./../../../Datasets/cars.xml");
                var customersXml = File.ReadAllText("./../../../Datasets/customers.xml");
                var salesXml = File.ReadAllText("./../../../Datasets/sales.xml");


            var result = GetSalesWithAppliedDiscount(db);

            Console.WriteLine(result);
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var serializer = new XmlSerializer(typeof(SaleOutputModel[]), new XmlRootAttribute("sales"));

            var salesWithDiscount = context.Sales
                .Select(x => new SaleOutputModel
                {
                    Car = new CarOutputModelDiscount
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistace = x.Car.TravelledDistance
                    },
                    Discount = x.Discount,
                    CustomerName = x.Customer.Name,
                    Price = x.Car.PartCars.Sum(p => p.Part.Price),
                   // PriceWithDiscount = x.Car.PartCars.Sum(p => p.Part.Price) * (1 - (x.Discount/100))
                    PriceWithDiscount = x.Car.PartCars.Sum(p => p.Part.Price) - x.Car.PartCars.Sum(p => p.Part.Price) * x.Discount / 100
                })
                .ToArray();

            var writer = new StringWriter();
            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);
            serializer.Serialize(writer, salesWithDiscount, ns);

            var resultSales = writer.ToString();

            return resultSales;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var serializer = new XmlSerializer(typeof(List<CustomerSalesOutputModel>), new XmlRootAttribute("customers"));

            //var customerSales = context.Customers
            //    .Where(x => x.Sales.Count > 0)
            //    .Select(x => new CustomerSalesOutputModel
            //    {
            //        FullName = x.Name,
            //        BoughtCars = x.Sales.Count,
            //        SpentMoney = x.Sales
            //        .Select(y => y.Car.PartCars.Sum(p => p.Part.Price))
            //        .ToArray()
            //        .Sum()
            //    })
            //    .OrderByDescending(x => x.SpentMoney)
            //    .ToArray();

            var customerSales = new List<CustomerSalesOutputModel>();

            foreach (var customer in context.Customers.Include(x => x.Sales)
                .ThenInclude(x => x.Car)
                .ThenInclude(x => x.PartCars)
                .ThenInclude(x => x.Part)
                .Where(x => x.Sales.Count > 0))
            {
                var currentCustomer = new CustomerSalesOutputModel
                {
                    FullName = customer.Name,
                    BoughtCars = customer.Sales.Count
                };

                foreach (var sale in customer.Sales)
                {
                    currentCustomer.SpentMoney = sale.Car.PartCars.Sum(x => x.Part.Price);
                }

                customerSales.Add(currentCustomer);
            }

            customerSales = customerSales.OrderByDescending(x => x.SpentMoney).ToList();

            var writer = new StringWriter();
            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);
            serializer.Serialize(writer, customerSales, ns);

            var resultSales = writer.ToString();

            return resultSales;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var serializer = new XmlSerializer(typeof(CarPartsOutputModel[]), new XmlRootAttribute("cars"));

            var carsParts = context.Cars
                .Select(x => new CarPartsOutputModel
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance,
                    Parts = x.PartCars.Select(p => new PartOutput
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price
                    })
                    .OrderByDescending(p => p.Price)
                    .ToArray()
                })
                .OrderByDescending(x => x.TravelledDistance)
                .ThenBy(x => x.Model)
                .Take(5)
                .ToArray();

            var writer = new StringWriter();
            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);
            serializer.Serialize(writer, carsParts, ns);

            var result = writer.ToString();

            return result;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var serializer = new XmlSerializer(typeof(LocalSuppliersOutputModel[]), new XmlRootAttribute("suppliers"));

            var supplierDtos = context.Suppliers
                .Where(x => !x.IsImporter)
                .Select(x => new LocalSuppliersOutputModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count
                })
                .ToArray();

            var writer = new StringWriter();
            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);
            serializer.Serialize(writer, supplierDtos, ns);

            var resultSuppliers = writer.ToString();

            return resultSuppliers;
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var serializer = new XmlSerializer(typeof(CarOutputModel[]), new XmlRootAttribute("cars"));

            var carsOutput = context.Cars
                .Select(x => new CarOutputModel
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistace = x.TravelledDistance
                })
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Take(10)
                .ToArray();

            var writer = new StringWriter();
            var ws = new XmlSerializerNamespaces();
            ws.Add(string.Empty, string.Empty);

            serializer.Serialize(writer, carsOutput, ws);

            var result = writer.ToString();

            return result;
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var serializer = new XmlSerializer(typeof(BmwOutputModel[]), new XmlRootAttribute("cars"));

            var bmwOutput = context.Cars
                .Where(x => x.Make.Equals("BMW"))
                .Select(x => new BmwOutputModel
                {
                    Id = x.Id,
                    Model = x.Model,
                    TravelledDistace = x.TravelledDistance
                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistace)
                .ToArray();

            var writer = new StringWriter();
            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);
            serializer.Serialize(writer, bmwOutput, ns);

            var resultCars = writer.ToString();

            return resultCars;
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            InitializeMapper();

            var serializer = new XmlSerializer(typeof(SaleInputModel[]), new XmlRootAttribute("Sales"));
            var carIds = context.Cars.Select(x => x.Id).ToArray();

            SaleInputModel[] salesDto;

            using (var reader = new StringReader(inputXml))
            {
                salesDto = serializer.Deserialize(reader) as SaleInputModel[];
            }

            salesDto = salesDto.Where(x => carIds.Contains(x.CarId)).ToArray();
            var sales = mapper.Map<Sale[]>(salesDto);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            InitializeMapper();
            var serializer = new XmlSerializer(typeof(CustomerInputModel[]), new XmlRootAttribute("Customers"));
            CustomerInputModel[] customersDto;

            using (var reader = new StringReader(inputXml))
            {
                customersDto = serializer.Deserialize(reader) as CustomerInputModel[];
            }

            var customers = mapper.Map<Customer[]>(customersDto);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            InitializeMapper();

            var partIds = context.Parts.Select(x => x.Id).ToArray();

            var serializer = new XmlSerializer(typeof(CarInputModel[]), new XmlRootAttribute("Cars"));
            CarInputModel[] carsDto;

            using (var reader = new StringReader(inputXml))
            {
                carsDto = serializer.Deserialize(reader) as CarInputModel[];
            }

            var cars = new List<Car>();

            foreach (var car in carsDto)
            {
                var currentCar = new Car
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TraveledDistance,
                };

                foreach (var part in car.Parts.Select(x => x.PartId).Distinct())
                {
                    if (context.Parts.Select(x => x.Id).Contains(part))
                    {
                        currentCar.PartCars.Add(new PartCar
                        {
                            PartId = part
                        });
                    }

                }

                cars.Add(currentCar);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count()}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            InitializeMapper();

            var supplierIds = context.Suppliers
                .Select(x => x.Id)
                .ToArray();

            var serializer = new XmlSerializer(typeof(PartInputModel[]), new XmlRootAttribute("Parts"));

            PartInputModel[] partsDto;

            using (var reader = new StringReader(inputXml))
            {
                partsDto = serializer.Deserialize(reader) as PartInputModel[];
            }

            partsDto = partsDto.Where(x => supplierIds.Contains(x.SupplierId)).ToArray();

            var parts = mapper.Map<Part[]>(partsDto);

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}";
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            InitializeMapper();

            var serializer = new XmlSerializer(typeof(SupplierInputModel[]), new XmlRootAttribute("Suppliers"));

            SupplierInputModel[] suppliersDto;

            using (var reader = new StringReader(inputXml))
            {
                suppliersDto = serializer.Deserialize(reader) as SupplierInputModel[];
            }

            var suppliers = mapper.Map<Supplier[]>(suppliersDto);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}";
        }

        private static void InitializeMapper()
        {
            var configuration = new MapperConfiguration(config => config.AddProfile<CarDealerProfile>());

            mapper = configuration.CreateMapper();
        }
    }
}