using ESchool.Logic.DB;
using ESchool.Models;

namespace WebShop.Extensions
{
    public static class MarkExtensions
    {
        public static MarkModel ToModel(this Mark mark)
        {
            if (mark == null)
                return null;

            return new MarkModel()
            {
                Name = mark.Name,
                Surname = mark.Surname,
                Mark = mark.Mark1,
                Subject = mark.Subject,
                Description = mark.Description,
                StudySubject = mark.StudySubject.ToModel(),
            };
        }

        public static Mark ToData(this MarkModel mark)
        {
            if (mark == null)
                return null;

            return new Mark()
            {
                Name = mark.Name,
                Surname = mark.Surname,
                Mark1 = mark.Mark,
                Subject = mark.Subject,
                Description = mark.Description,
                StudySubject = mark.StudySubject.ToData(),
            };
        }
    }
}
