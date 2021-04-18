using Microsoft.EntityFrameworkCore;

namespace Homework10.Models
{
    public class CollegeContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }

        public CollegeContext(DbContextOptions<CollegeContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
