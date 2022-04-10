using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.ViewModels
{
    public class ProductViewModel
    {
        [JsonProperty(propertyName: "name")]
        public string Name { get; set; }

        [JsonProperty(propertyName: "price")]
        public decimal Price { get; set; }

        [JsonProperty(propertyName: "seller")]
        public string FullNameSeller { get; set; }
    }
}
