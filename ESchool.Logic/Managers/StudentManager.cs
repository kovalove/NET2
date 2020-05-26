using ESchool.Logic.DB;
using System.Collections.Generic;
using System.Linq;

namespace ESchool.Logic.Managers
{
    public class StudentManager
    {
        public static List<Student> GetAllOrdered()
        {
            using (var db = new DBContext())
            {
                return db.Student.OrderBy(c => c.Surname).ThenBy(c => c.Name).ToList();
            }
        }

        public static Student Find(string name, string surname)
        {
            using (var db = new DBContext())
            {
                return db.Student.Where(s => s.Name == name && s.Surname == surname).FirstOrDefault();
            }

        }

        public static void Save(Student student)
        {
            using (var db = new DBContext())
            {
                db.Student.Add(student);
                db.SaveChanges();
            }
        }
    }
}
