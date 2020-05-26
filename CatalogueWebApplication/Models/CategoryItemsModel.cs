using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogueWebApplication.Models
{
    public class CategoryItemsModel
    {
        public CategoryModel Category { get; set; }

        public List<ItemModel> Items { get; set; }
    }
}
