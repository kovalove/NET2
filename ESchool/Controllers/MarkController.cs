using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESchool.Logic.Managers;
using ESchool.Models;
using Microsoft.AspNetCore.Mvc;
using WebShop.Extensions;

namespace ESchool.Controllers
{
    public class MarkController : Controller
    {

        public static List<MarkModel> Marks = new List<MarkModel>()
        {
            new MarkModel() { Name = "John", Surname = "Smith", Subject = "History", Mark = 9, Description = "Very good"},
            new MarkModel() { Name = "John", Surname = "Smith", Subject = "Mathematics", Mark = 10, Description = "Excelent"},
            new MarkModel() { Name = "John", Surname = "Smith", Subject = "Mathematics", Mark = 10, Description = "Excelent"},
            new MarkModel() { Name = "John", Surname = "Smith", Subject = "Mathematics", Mark = 9, Description = "Very good"},
            new MarkModel() { Name = "Ray", Surname = "Bishop", Subject = "Mathematics", Mark = 8, Description = "Good"},
            new MarkModel() { Name = "Ray", Surname = "Bishop", Subject = "Mathematics", Mark = 2, Description = "Very bad, no homework"},
            new MarkModel() { Name = "Ray", Surname = "Bishop", Subject = "Mathematics", Mark = 7, Description = "Good"},
            new MarkModel() { Name = "Ray", Surname = "Bishop", Subject = "Geography", Mark = 7, Description = "Good"},
            new MarkModel() { Name = "Ray", Surname = "Bishop", Subject = "Geography", Mark = 9, Description = "Very good"},
            new MarkModel() { Name = "Ray", Surname = "Bishop", Subject = "Sports", Mark = 7, Description = "Good"},
            new MarkModel() { Name = "Evan", Surname = "Hopkins", Subject = "Sports", Mark = 7, Description = "Good"},
            new MarkModel() { Name = "Evan", Surname = "Hopkins", Subject = "Sports", Mark = 8, Description = "Good"},
            new MarkModel() { Name = "Evan", Surname = "Hopkins", Subject = "English", Mark = 8, Description = "Good"},
            new MarkModel() { Name = "Evan", Surname = "Hopkins", Subject = "English", Mark = 10, Description = "Excelent"},
            new MarkModel() { Name = "Evan", Surname = "Hopkins", Subject = "English", Mark = 9, Description = "Very good"},
        };


        public static List<MarkModel> GetAllOrdered()
        {
            // from database
            // return MarkManager.GetAllOrdered().Select(x => x.ToModel()).ToList();

            // without database
            return Marks.OrderByDescending(c => c.Mark).ToList();
        }

        public static List<MarkModel> MarksByStudent(string name, string surname)
        {
            // from database
            // return MarkManager.MarksByStudent(name, surname).Select(x => x.ToModel()).ToList();

            // without database
            return Marks.Where(m => m.Name == name && m.Surname == surname).ToList();
        }

        public static List<MarkModel> MarksBySubject(string subject)
        {
            // from database
            // return MarkManager.MarksBySubject(subject).Select(x => x.ToModel()).ToList();

            // without database
            return Marks.Where(m => m.Subject == subject).ToList();
        }

        public static void Save(MarkModel mark)
        {
            // to database
            // MarkManager.Save(mark.ToData());

            // without database
            Marks.Add(mark);
        }

        public IActionResult Index()
        {
            var marks = GetAllOrdered();
            return View(marks);
        }

        public IActionResult View(string name, string surname)
        {
            var student = StudentController.Find(name, surname);
            return View(student);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var mark = new MarkModel();
            return View(mark);
        }

        [HttpPost]
        public IActionResult Add(MarkModel model)
        {
            StudentModel student = StudentController.Find(model.Name, model.Surname);
            StudySubjectModel subject = StudySubjectController.Find(model.Subject);

            if (student == null)
            {
                ModelState.AddModelError("stu", "Student does not exist");
            }

            if (subject == null)
            {
                ModelState.AddModelError("sub", "Subject does not exist");
            }

            if (model.Mark > 10 || model.Mark < 1)
            {
                ModelState.AddModelError("mark", "Mark is out of range");
            }

            if (ModelState.IsValid)
            {
                Save(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}