using Microsoft.EntityFrameworkCore;

namespace CoursesApp.Models
{
    public class CoursesDbContext : DbContext
    {
        public CoursesDbContext(DbContextOptions<CoursesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
