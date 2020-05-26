using System;
using System.Collections.Generic;

namespace ESchool.Logic.DB
{
    public partial class StudySubject
    {
        public StudySubject()
        {
            Mark = new HashSet<Mark>();
        }

        public int? Id { get; set; }
        public string Name { get; set; }

        public ICollection<Mark> Mark { get; set; }
    }
}
