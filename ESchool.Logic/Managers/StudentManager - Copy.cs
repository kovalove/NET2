using System;
using System.Collections.Generic;
using System.Text;

namespace ESchool.Logic.Managers
{
    public class StudentManager
    {
        public static List<Users> GetAll()
        {
            using (var db = new DbContext())
            {
                return db.Users.OrderBy(u => u.Name).ToList();
            }
        }
    }
}
