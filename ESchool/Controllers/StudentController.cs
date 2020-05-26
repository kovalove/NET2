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

        public static List<StudentModel> GetAllOrdered()
        {
            // from database
            // return StudentManager.GetAllOrdered().Select(s => s.ToModel()).ToList();

            // without database
            var students = Students.OrderBy(c => c.Surname).ThenBy(c => c.Name).ToList();
            foreach (var student in students)
                student.Marks = MarkController.MarksByStudent(student.Name, student.Surname);
            return students;
        }


        public static StudentModel Find(string name, string surname)
        {
            // from database
            // return StudentManager.Find(name, surname).ToModel();

            // without database
            return Students.Find(s => s.Name == name && s.Surname == surname);
        }

        public static void Save(StudentModel student)
        {
            // to database
            // StudentManager.Save(student.ToData());

            // without database
            Students.Add(student);
        }

        public IActionResult Index()
        {
            var students = GetAllOrdered();
            foreach (var student in students)
                student.Average = student.Marks.Select(m => m.Mark).DefaultIfEmpty().Average();

            return View(students);
        }

        public IActionResult View(string name, string surname)
        {
            StudentModel student = Find(name, surname);
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
                Save(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}