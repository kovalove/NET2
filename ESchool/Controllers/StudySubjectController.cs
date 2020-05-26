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

        public static List<StudySubjectModel> GetAllOrdered()
        {
            // from database
            // return StudySubjectManager.GetAllOrdered().Select(s => s.ToModel()).ToList();

            // without database
            return StudySubjects.OrderBy(c => c.Name).ToList();
        }

        public static StudySubjectModel Find(string name)
        {
            // from database
            // return StudySubjectManager.Find(name).ToModel();

            // without database
            return StudySubjects.Find(s => s.Name == name);
        }

        public static void Save(StudySubjectModel subject)
        {
            // to database
            // StudySubjectManager.Save(subject.ToData());

            // without database
            StudySubjects.Add(subject);
        }

        public IActionResult Index()
        {
            var subjects = GetAllOrdered();
            return View(subjects);
        }

        public IActionResult View(string name)
        {
            StudySubjectModel subject = Find(name);
            subject.Marks = MarkController.MarksBySubject(name).ToList();
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
                Save(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}