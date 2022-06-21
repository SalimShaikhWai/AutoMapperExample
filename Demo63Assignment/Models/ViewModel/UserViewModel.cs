using Demo63Assignment.CustomValidation;
using System.ComponentModel.DataAnnotations;

namespace Demo63Assignment.Models.ViewModel
{
    public class UserViewModel
    {
        [Display(Name = "User ID")]
        public int Id { get; set; }
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }
        [Display(Name = "Date Of Birth")]
        [AgeValidation(ErrorMessage = "Age Should be More Than 18")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Pan { get; set; }

        public string Address { get; set; }
        public char Gender { get; set; }
        [Display(Name = "Mobile Number")]
        [Required]
        public string MobileNumber { get; set; }
        [Required]
        public string Email { get; set; }

        public string Comment { get; set; }
        [Required]
        public int DepartmentRefId { get; set; }

        [Display(Name = "Department")]
        public string DepartmentName { get; set; }

    }
}
