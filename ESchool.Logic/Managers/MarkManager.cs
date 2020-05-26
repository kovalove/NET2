using ESchool.Logic.DB;
using System.Collections.Generic;
using System.Linq;

namespace ESchool.Logic.Managers
{
    public class MarkManager
    {
        public static List<Mark> GetAllOrdered()
        {
            using (var db = new DBContext())
            {
                return db.Mark.OrderByDescending(c => c.Mark1).ToList();
            }
        }

        public static List<Mark> MarksByStudent(string name, string surname)
        {
            using (var db = new DBContext())
            {
                return db.Mark.Where(m => m.Name == name && m.Surname == surname).ToList();
            }
        }

        public static List<Mark> MarksBySubject(string subject)
        {
            using (var db = new DBContext())
            {
                return db.Mark.Where(m => m.Subject == subject).ToList();
            }
        }

        public static void Save(Mark mark)
        {
            using (var db = new DBContext())
            {
                db.Mark.Add(mark);
                db.SaveChanges();
            }
        }

    }
}
