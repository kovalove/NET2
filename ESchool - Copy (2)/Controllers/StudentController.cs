using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESchool.Models;
using Microsoft.AspNetCore.Mvc;

namespace ESchool.Controllers
{
    public class StudentController : Controller
    {
        public static List<StudentModel> Students = new List<StudentModel>()
        {
            new StudentModel() { Name = "John", Surname = "Smith", Birthdate = new DateTime(2001, 10, 31), StudyClass = "12a"},
            new StudentModel() { Name = "Bob", Surname = "Dilan", Birthdate = new DateTime(2003, 9, 2), StudyClass = "10a"},
            new StudentModel() { Name = "Ray", Surname = "Bishop", Birthdate = new DateTime(2007, 5, 10), StudyClass = "6b"},
            new StudentModel() { Name = "Evan", Surname = "Hopkins", Birthdate = new DateTime(2006, 6, 17), StudyClass = "7c"},
            new StudentModel() { Name = "Peggy", Surname = "Gordon", Birthdate = new DateTime(2007, 8, 4), StudyClass = "6b"},
        };


        public IActionResult Index()
        {
            var students = Students.OrderBy(c => c.Surname).ThenBy(c => c.Name).ToList();
            foreach (var student in students)
            {
                student.Marks = MarkController.MarksByStudent(student.Name, student.Surname);
                student.Average = student.Marks.Select(m => m.Mark).DefaultIfEmpty().Average();
            }

            return View(students);
        }

        public IActionResult View(string name, string surname)
        {
            StudentModel student = Students.Find(s => s.Name == name && s.Surname == surname);
            if (student == null)
            {
                ModelState.AddModelError("student", "student does not exists");
            }
            else
            {
                student.Marks = MarkController.MarksByStudent(name, surname);
            }

            return View(student);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var student = new StudentModel();
            return View(student);
        }

        [HttpPost]
        public IActionResult Add(StudentModel model)
        {
            if (ModelState.IsValid)
            {

                Students.Add(model);

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}