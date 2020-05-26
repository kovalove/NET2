using ESchool.Logic.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESchool.Logic.Managers
{
    public class StudySubjectManager
    {
        public static List<StudySubject> GetAllOrdered()
        {
            using (var db = new DBContext())
            {
                return db.StudySubject.OrderBy(c => c.Name).ToList();
            }
        }

        public static StudySubject Find(string name)
        {
            using (var db = new DBContext())
            {
                return db.StudySubject.Where(s => s.Name == name).FirstOrDefault();
            }
        }

        public static void Save(StudySubject subject)
        {
            using (var db = new DBContext())
            {
                db.StudySubject.Add(subject);
                db.SaveChanges();
            }
        }

    }
}
