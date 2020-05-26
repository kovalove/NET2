using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstWeb.Logic;
using FirstWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstWeb.Controllers
{
    public class UserController : Controller
    { 

        // https://localhost:44300//User/Index
        // https://localhost:44300///User
        public IActionResult Index()
        {
            var users = UserManager.GetAll().Select(u => u.ToModel()).ToList();
            return View(users);
        }

        // https://localhost:44300///User/View/2
        public IActionResult View(int id)
        {
            var user = UserManager.Get(id).ToModel();

            return View(user);
        }

        //https://localhost:44300/User/Add
        [HttpGet]
        public IActionResult Add()
        {
            var user = new UserModel();
            return View(user);
        }

        [HttpPost]
        public IActionResult Add(UserModel model)
        {

            if(ModelState.IsValid)
            {

                // VISS OK - modelis ir valids, var veikt datu saglabasanu
                UserManager.Create(model.Name, model.Email, model.Phone);

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}