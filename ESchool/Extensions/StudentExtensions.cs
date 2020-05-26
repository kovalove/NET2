using ESchool.Logic.DB;
using ESchool.Models;
using System.Collections.Generic;

namespace WebShop.Extensions
{
    public static class StudentExtensions
    {
        public static StudentModel ToModel(this Student student)
        {
            if (student == null)
                return null;

            return new StudentModel()
            {
                Name = student.Name,
                Surname = student.Surname,
                Birthdate = student.Birthdate,
                StudyClass = student.StudyClass,
                Marks = new List<MarkModel>(),
            };
        }

        public static Student ToData(this StudentModel student)
        {
            if (student == null)
                return null;

            return new Student()
            {
                Name = student.Name,
                Surname = student.Surname,
                Birthdate = student.Birthdate,
                StudyClass = student.StudyClass,
            };
        }
    }
}
