using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("User")]
    [Serializable]
    public class UserWithProductsOutputModel
    {
        //first and last name, age, count 
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")]
        public int? Age { get; set; }

        [XmlElement("SoldProducts")]
        public ProductsInfo Products { get; set; }
    }

    [XmlType("products")]
    [Serializable]
    public class ProductsInfo
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("products")]
        public SoldProduct[] Products { get; set; }
    }

    [XmlType("Product")]
    [Serializable]
    public class SoldProduct
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }
    }

    [XmlType("Users")]
    [Serializable]
    public class UserProductsResult
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public UserWithProductsOutputModel[] Users { get; set; }
    }
}
