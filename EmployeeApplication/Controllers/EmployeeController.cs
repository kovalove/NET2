using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApplication.Controllers
{
    public class EmployeeController : Controller
    {
        public static List<EmployeeModel> Employees = new List<EmployeeModel>();

        public IActionResult Index()
        {
            var model = Employees.OrderBy(c => c.Department).OrderBy(c => c.Surname).ToList();
            return View(model);
        }

        public IActionResult View(int id)
        {
            EmployeeModel employee = Employees.Find(u => u.Id == id);

            return View(employee);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var employee = new EmployeeModel();
            return View(employee);
        }

        [HttpPost]
        public IActionResult Add(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                model.Id = Employees.Count + 1;
                Employees.Add(model);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult ViewDepartments()
        {
            List<string> model = Employees.Select(e => e.Department).Distinct().OrderBy(d => d).ToList();
            return View(model);
        }
    }
}