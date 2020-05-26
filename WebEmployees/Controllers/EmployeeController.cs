using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using WebEmployees.Models;

namespace WebEmployees.Controllers
{
    public class EmployeeController : Controller
    {

        public static List<EmployeeModel> Employees = new List<EmployeeModel>()
        {
            new EmployeeModel {
                Id = 1,
                Name = "John",
                Surname = "Doe",
                Birth =  new DateTime(1995, 04, 01),
                Position = "QA Engineer",
                Department = "QA Department",
                Description = "1 year experience in QA Engineering."
            }
};

        public IActionResult Index()
        {
            var model = Employees.OrderBy(c => c.Surname).OrderBy(c => c.Department).ToList();
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