using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.Dto
{
    [XmlType("Purchase")]
    public class PurchaseImportDto
    {
        [Required]
        [XmlAttribute("title")]
        public string Title { get; set; }

        [Required]
        [EnumDataType(typeof(PurchaseType))]
        [XmlElement("Type")]
        public string Type { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z\d]{4}-[A-Z\d]{4}-[A-Z\d]{4}$")]
        [XmlElement("Key")]
        public string Key { get; set; }

        [Required]
        [RegularExpression(@"^\d{4} \d{4} \d{4} \d{4}$")]
        [XmlElement("Card")]
        public string Card { get; set; }

        [Required]
        [XmlElement("Date")]
        public string Date { get; set; }
    }
}

//•	Id – integer, Primary Key
//•	Type – enumeration of type PurchaseType, with possible values (“Retail”, “Digital”) (required)
//•	ProductKey – text, which consists of 3 pairs of 4 uppercase Latin letters and digits, separated by dashes (ex. “ABCD-EFGH-1J3L”) (required)
//•	Date – Date(required)
//•	CardId – integer, foreign key(required)
//•	Card – the purchase’s card (required)
//•	GameId – integer, foreign key(required)
//•	Game – the purchase’s game (required)

//•	Name – text (required)
//•	Price – decimal(non - negative, minimum value: 0)(required)
//•	ReleaseDate – Date(required)
//•	DeveloperId – integer, foreign key(required)
//•	Developer – the game’s developer (required)
//•	GenreId – integer, foreign key(required)
//•	Genre – the game’s genre (required)
//•	Purchases - collection of type Purchase
//•	GameTags - collection of type GameTag. Each game must have at least one tag.

//< Purchase title = "Dungeon Warfare 2" >

//   < Type > Digital </ Type >

//   < Key > ZTZ3 - 0D2S - G4TJ </ Key >

//        < Card > 1833 5024 0553 6211 </ Card >

//           < Date > 07 / 12 / 2016 05:49 </ Date >

//                </ Purchase >

