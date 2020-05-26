﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebShop.Logic;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class ItemController : Controller
    {
        public IActionResult Index(int id)
        {
            //id - kategorijas ID
            var model = new HomeModel();
            model.Categories = CategoryManager.GetAll().Select(c => c.ToModel()).ToList();
            // precu atlasi no DB, izmantojot ItemManager
            model.Items = ItemManager.GetByCategory(id).Select(c => c.ToModel()).ToList();

            foreach (var cat in model.Categories)
            {
                cat.ItemCount = CategoryManager.GetItemCount(cat.Id);
            }

            return View(model);
        }

        public IActionResult List()
        {
            if (!HttpContext.Session.GetIsAdmin())
            {
                return NotFound();
            }

            var items = ItemManager.GetAll().Select(c => c.ToModel()).ToList();
            return View(items);
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (!HttpContext.Session.GetIsAdmin())
            {
                return NotFound();
            }

            var model = new ItemModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(ItemModel model)
        {
            if (ModelState.IsValid)
            {
                var category = CategoryManager.Get(model.CategoryId);
                if (category == null)
                {
                    ModelState.AddModelError("cat", "Category not found!");
                }
                else
                {
                    ItemManager.Create(category.Id, model.Name, model.Description, model.Price);
                    return RedirectToAction(nameof(List));
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {

            if (!HttpContext.Session.GetIsAdmin())
            {
                return NotFound();
            }

            ItemManager.Delete(id);

            return RedirectToAction(nameof(List));
        }

        [HttpGet]
        public IActionResult Buy(int id)
        {
            //jasaglaba izveleta prece lietotaja groza.
            UserCartManager.Create(HttpContext.Session.GetUserId(), id);
            return RedirectToAction("MyCart", "Account");
        }

    }
}