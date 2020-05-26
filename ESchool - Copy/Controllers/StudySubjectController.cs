using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESchool.Models;
using Microsoft.AspNetCore.Mvc;

namespace ESchool.Controllers
{
    public class StudySubjectController : Controller
    {

        public static List<StudySubjectModel> StudySubjects = new List<StudySubjectModel>()
         {
            new StudySubjectModel() { Name = "Mathematics"},
            new StudySubjectModel() { Name = "History"},
            new StudySubjectModel() { Name = "English"},
            new StudySubjectModel() { Name = "Sports"},
            new StudySubjectModel() { Name = "Geography"},

        };


        public IActionResult Index()
        {
            var model = StudySubjects.OrderBy(c => c.Name).ToList();

            return View(model);
        }

        public IActionResult View(string name)
        {
            StudySubjectModel subject = StudySubjects.Find(s => s.Name == name);

            subject.Marks = MarkController.Marks.Where(m => m.Subject == name).ToList();

            return View(subject);
        }


        [HttpGet]
        public IActionResult Add()
        {
            var subject = new StudySubjectModel();
            return View(subject);
        }

        [HttpPost]
        public IActionResult Add(StudySubjectModel model)
        {
            if (ModelState.IsValid)
            {

                StudySubjects.Add(model);

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}