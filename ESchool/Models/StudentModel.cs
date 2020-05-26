using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ESchool.Models
{
    public class StudentModel
    {
        [Required]
        [DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "Name: *")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "Surname: *")]
        public string Surname { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Birthday: *")]
        public DateTime? Birthdate { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(5)]
        [Display(Name = "Class: *")]
        public string StudyClass { get; set; }

        public List<MarkModel> Marks { get; set; }

        public decimal Average { get; set; }
    }
}
