using System.ComponentModel.DataAnnotations;

namespace FirstWeb.Models
{
    public class UserModel
    {
        public int Id { get; set; }


        [Required]
        [DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "Name:")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(200)]
        [Display(Name = "E-mail:")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(15)]
        [Display(Name = "Phone number:")]
        public string Phone { get; set; }

        //public int Age
        //{
        //    get
        //    {
        //        return 5;
        //    }
        //}


        //private int Age;

        //public void SetAge(int age)
        //{
        //    Age = age;
        //}

        //public int GetAge()
        //{
        //    return Age;
        //}
    }


    public class Product
    {
        public int id;
        public string name;
        public int price;
        public Category category;
    }

    public class Category
    {
        public int id;
    }
}
