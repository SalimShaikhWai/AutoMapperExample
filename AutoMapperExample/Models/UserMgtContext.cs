using Microsoft.EntityFrameworkCore;

namespace AutoMapperExample.Models
{
    public class UserMgtContext:DbContext
    {
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }

        public UserMgtContext(DbContextOptions<UserMgtContext> options)
           : base(options)
        {
        }
    }
}
