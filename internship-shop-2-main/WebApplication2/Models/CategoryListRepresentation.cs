using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.Domain;

namespace WebApplication2.Models
{
    public class CategoryListRepresentation
    {
        private object dbCategories;

        public CategoryListRepresentation(List<Category> categories)
        {
            this.Categories = categories.Select(x => new CategoryRepresentation(x)).ToList();
        }

        public CategoryListRepresentation(object dbCategories)
        {
            this.dbCategories = dbCategories;
        }

        [JsonProperty(PropertyName = "categories")]
        public List<CategoryRepresentation> Categories { get; set; }
    }
}
