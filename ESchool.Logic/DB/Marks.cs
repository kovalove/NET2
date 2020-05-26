using System;
using System.Collections.Generic;

namespace ESchool.Logic.DB
{
    public partial class Marks
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal Mark { get; set; }
        public string Subject { get; set; }
        public int StudySubjectId { get; set; }
        public string Description { get; set; }

        public StudySubjects StudySubject { get; set; }
    }
}
