using Demo63Assignment.CustomValidation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo63Assignment.Models.DataModel
{

    [Table("User")]
 
    public class User
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("FirstName")]
        [Required(ErrorMessage = "FirstName should not be blank")]
        [Unicode(false)]
        public string FirstName { get; set; }

        [Column("LastName")]
        [Required(ErrorMessage = "LastName should not be blank")]
        [Unicode(false)]
        public string LastName { get; set; }

        [Column("DateOfBirth")]
        [AgeValidation(ErrorMessage ="Age Should be More Than 18")]
        public DateTime DateOfBirth { get; set; }


        [Column("Pan")]
        [Unicode(false)]
        
        [Required(ErrorMessage = "Pan Number Should not be blank")]
        
        public string Pan { get; set; }

        [Column("Address")]
        [Unicode(false)]
        public string Address { get; set; }

        [Column("Gender", TypeName = "char(1)")]
        public char Gender { get; set; }

        [Column("MobileNumber")]
        [Unicode(false)]
        public string MobileNumber { get; set; }

        [Column("Email")]
        [Required(ErrorMessage = "Email should not be Black")]
        [Unicode(false)]
        public string Email { get; set; }
        [Column("Comment")]
        [Unicode(false)]
        public string Comment { get; set; }

        [Column("DepartmentRefId")]

        [Required(ErrorMessage = "Plese select Your Department")]
        public int DepartmentRefId { get; set; }
        [ForeignKey("DepartmentRefId")]

        public virtual Department DepartmentRef { get; set; }


    }
}
