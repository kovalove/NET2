using System;
using System.Collections.Generic;

namespace ESchool.Logic.DB
{
    public partial class Mark
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal Mark1 { get; set; }
        public string Subject { get; set; }
        public int StudySubjectId { get; set; }
        public string Description { get; set; }

        public StudySubject StudySubject { get; set; }
    }
}
