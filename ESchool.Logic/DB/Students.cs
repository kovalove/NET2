using System;
using System.Collections.Generic;

namespace ESchool.Logic.DB
{
    public partial class Students
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public string StudyClass { get; set; }
    }
}
