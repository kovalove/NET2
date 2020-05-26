using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ESchool.Models
{
    public class StudySubjectModel
    {
        [Required]
        [DataType(DataType.Text)]
        [StringLength(100)]
        [Display(Name = "Name: *")]
        public string Name { get; set; }

        public List<MarkModel> Marks { get; set; }
        
    }
}
