using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESchool.Models;
using Microsoft.AspNetCore.Mvc;

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


    public static List<MarkModel> MarksByStudent(string name, string surname)
        {
            return Marks.Where(m => m.Name == name && m.Surname == surname).ToList();
        }


        public IActionResult Index()
        {
            var model = Marks.OrderByDescending(c => c.Mark).ToList();
            return View(model);
        }

        public IActionResult View(string name, string surname)
        {
            StudentModel student = StudentController.Students.Find(s => s.Name == name && s.Surname == surname);


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

            StudentModel student = StudentController.Students.Find(s => s.Name == model.Name && s.Surname == model.Surname);
            StudySubjectModel subject = StudySubjectController.StudySubjects.Find(s => s.Name == model.Subject);

            if (student == null)
            {
                ModelState.AddModelError("stu", "Student does not exist");

                //return View(model);
            }

            if (subject == null)
            {
                ModelState.AddModelError("sub", "Subject does not exist");

                //return View(model);
            }

            if (model.Mark > 10 || model.Mark < 1)
            {
                ModelState.AddModelError("mark", "Mark is out of range");

                //return View(model);
            }

            if (ModelState.IsValid)
            {
                Marks.Add(model);

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}