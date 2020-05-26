using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebShop;
using WebShop.Logic;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult SignUp()
        {
            var model = new UserModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult SignUp(UserModel model)
        {
            if(ModelState.IsValid)
            {
                // parbaudit - vai paroles sakrit?
                // vai lietotajs ar epastu jau neeksiste?
                if(model.Password != model.PasswordRepeat)
                {
                    ModelState.AddModelError("pass", "Passwords do not match");
                }
                else
                {
                    // lietotaja atlase no DB pec e-pasta. Izmantojot UserManager.
                    UserModel user = UserManager.GetByEmail(model.Email).ToModel();


                    if(user != null)
                    {
                        ModelState.AddModelError("mail", "User with this e-mail already exists!");
                    }
                    else
                    {
                        // saglabat ievaditos datus DB. uzmantojot UserManager.
                        UserManager.Create(model.Email, model.Name, model.Password);

                        return RedirectToAction(nameof(SignIn));
                    }
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            var model = new LoginModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult SignIn(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                
                UserModel user = UserManager.GetByEmailAndPassword(model.Email, model.Password).ToModel();

                if (user == null)
                {
                    ModelState.AddModelError("user", "Invalid e-mail/password!");
                }
                else
                {
                    //HttpContext.Session.Set("username", "Kristaps");
                    //HttpContext.Session.TryGetValue("username");

                    // saglaba lietotaja datus sesija

                    HttpContext.Session.SetUserName(user.Name);
                    HttpContext.Session.SetUserId(user.Id);
                    HttpContext.Session.SetIsAdmin(user.IsAdmin);


                    return RedirectToAction("Index", "Home");
                }
            }

            return View(model);
        }

        public IActionResult SignOut()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }


        public IActionResult MyCart()
        {

            // veikt lietotaja groza atlasi no DB, izmantojot UserCartManager.
            // attelot lietotaja groza saturu
            var userCart = UserCartManager.GetByUser(HttpContext.Session.GetUserId());
            // attēlošanai nepieciešamas tikai preces
            var items = userCart.Select(c => c.Item.ToModel()).ToList();
            return View(items);
        }


        [HttpPost]
        public IActionResult MyCartDelete(int id)
        {
            // TODO: delete
            return View(nameof(MyCart));
        }

        public IActionResult Confirm()
        {
            return View();
        }
    }
}