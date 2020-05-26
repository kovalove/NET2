using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebEmployees.Models
{
    public class EmployeeModel
    {

        public int Id { get; set; }

        //●	Darbinieku raksturo vārds, uzvārds, dzimšanas gads, amats un nodaļa

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
        public DateTime? Birth { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(200)]
        [Display(Name = "Position: *")]
        public string Position { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(200)]
        [Display(Name = "Deparmtment: *")]
        public string Department { get; set; }

        [DataType(DataType.Text)]
        [StringLength(500)]
        [Display(Name = "Description: ")]
        public string Description { get; set; }

    }
}
