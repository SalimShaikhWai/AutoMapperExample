using Demo63Assignment.Models.DataModel;
using Microsoft.EntityFrameworkCore;

namespace Demo63Assignment.Models
{
    public class UserMgtContext : DbContext
    {

        public UserMgtContext()
        {

        }
        public UserMgtContext(DbContextOptions<UserMgtContext> options)
             : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();
            modelBuilder.Entity<User>()
            .HasIndex(u => u.Pan)
            .IsUnique();



            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
    }
}
