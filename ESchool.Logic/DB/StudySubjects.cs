using System;
using System.Collections.Generic;

namespace ESchool.Logic.DB
{
    public partial class StudySubjects
    {
        public StudySubjects()
        {
            Marks = new HashSet<Marks>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Marks> Marks { get; set; }
    }
}
