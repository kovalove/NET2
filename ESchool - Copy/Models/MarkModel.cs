using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ESchool.Models
{
    public class MarkModel
    {

        [Required]
        [Display(Name = "Student name: *")]
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Student surname: *")]
        [DataType(DataType.Text)]
        [StringLength(100)]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Mark: *")]
        public decimal Mark { get; set; }

        [Required]
        [Display(Name = "Study subject: *")]
        [DataType(DataType.Text)]
        [StringLength(20)]
        public string Subject { get; set; }

        public StudySubjectModel StudySubject { get; set; }

        
        [Display(Name = "Description: ")]
        [DataType(DataType.Text)]
        [StringLength(500)]
        public string Description { get; set; }


    }
}
