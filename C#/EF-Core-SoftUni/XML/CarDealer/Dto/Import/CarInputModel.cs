using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.Dto.Import
{
    [XmlType("Car")]
    [Serializable]
    public class CarInputModel
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("TraveledDistance")]
        public long TraveledDistance { get; set; }

        [XmlArray("parts")]
        public PartCarInputModel[] Parts { get; set; }

    }

    [XmlType("partId")]
    public class PartCarInputModel
    {
        [XmlAttribute("id")]
        public int PartId { get; set; }
    }
}
