using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoMapperExample.Models
{
    [Table("book")]
    public class Book
    {
        [Key]
        [Column("isbn")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }
        [Column("luanch-date")]
        public DateTime Date { get; set; }
        [Column("author_id")]
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }
    }
}
