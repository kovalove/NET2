using ESchool.Logic.DB;
using ESchool.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebShop.Extensions
{
    public static class StudySubjectExtensions
    {
        public static StudySubjectModel ToModel(this StudySubject subject)
        {
            if (subject == null)
                return null;

            var model = new StudySubjectModel()
            {
                Name = subject.Name,
                Marks = new List<MarkModel>(),
            };

            if (subject.Mark != null)
                model.Marks = subject.Mark.Select(m => m.ToModel()).ToList();

            return model;
        }

        public static StudySubject ToData(this StudySubjectModel subject)
        {
            if (subject == null)
                return null;

            var data = new StudySubject()
            {
                Name = subject.Name,
                Mark = new List<Mark>(),
            };

            if (subject.Marks != null)
                data.Mark = subject.Marks.Select(m => m.ToData()).ToList();

            return data;
        }
    }
}
