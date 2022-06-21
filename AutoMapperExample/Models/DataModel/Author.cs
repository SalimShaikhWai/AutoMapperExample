using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoMapperExample.Models
{
    [Table("id")]
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("mobile_number")]
        public string MobileNumber { get; set; }

        [Column("email")]
        public string Email { get; set; }
    }
}
