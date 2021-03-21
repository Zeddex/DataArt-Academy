using Microsoft.EntityFrameworkCore;

namespace HomeWork6
{
    public class AppContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=facultydb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>().HasData(
                new Group[]
                {
                    new Group { Id = 1, Title = "радиофизика" },
                    new Group { Id = 2, Title = "микроэлектроника" },
                    new Group { Id = 3, Title = "общая физика" }
                });
        }
    }
}
