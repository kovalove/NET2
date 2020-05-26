using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatalogueWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatalogueWebApplication.Controllers
{
    public class CategoryController : Controller
    {
        public List<CategoryModel> Categories;
        public List<ItemModel> Items;

        public CategoryController()
        {
            Categories = new List<CategoryModel>();
            Categories.Add(new CategoryModel()
            {
                Id = 1,
                Name = "Shoes",
            });
            Categories.Add(new CategoryModel()
            {
                Id = 2,
                Name = "Clothes",
            });
            Categories.Add(new CategoryModel()
            {
                Id = 3,
                Name = "Accessories",
            });
        }


        public IActionResult Index()
        {
            return View(Categories);
        }

        public IActionResult View(int id)
        {
            var category = Categories.Find(u => u.Id == id);

            var items = new List<ItemModel>();
            items.Add(new ItemModel()
            {
                Name = "Tommy Jeans"
            });


            var model = new CategoryItemsModel();
            model.Category = category;
            model.Items = items;
            return View(model);
        }
    }
}
