using System;
using System.Xml.Serialization;

namespace CarDealer.Dto.Export
{
    [Serializable]
    [XmlType("sale")]
    public class SaleOutputModel
    {
        [XmlElement("car")]
        public CarOutputModelDiscount Car { get; set; }

        [XmlElement("discount")]
        public decimal Discount { get; set; }

        [XmlElement("customer-name")]
        public string CustomerName { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("price-with-discount")]
        public decimal PriceWithDiscount { get; set; }
    }

    [Serializable]
    [XmlType("car")]
    public class CarOutputModelDiscount
    {
        [XmlAttribute("make")]
        public string Make { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDistace { get; set; }
    }
}
