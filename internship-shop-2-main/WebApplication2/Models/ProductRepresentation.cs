using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Domain;

namespace WebApplication2.Models
{
    public class ProductRepresentation
    {
        public ProductRepresentation(Product product)
        {
            this.ProductID = product.ProductID;
            this.Name = product.Name;
            this.Description = product.Description;
            this.Price = product.Price;
            this.BasePrice = product.BasePrice;
            this.CategoryID = product.CategoryID;
            this.FileName = product.FileName;
            
        }

        [JsonProperty(PropertyName = "productId")]
        public int ProductID { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "price")]
        public double Price { get; set; }

        [JsonProperty(PropertyName = "basePrice")]
        public double BasePrice { get; set; }

        [JsonProperty(PropertyName = "categoryId")]
        public int CategoryID { get; set; }

        [JsonProperty(PropertyName = "fileName")]
        public string FileName { get; set; }

        

    }
}

