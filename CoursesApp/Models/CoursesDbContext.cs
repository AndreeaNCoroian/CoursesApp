using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoursesApp.Models
{
    public class CoursesDbContext : IdentityDbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Review> Reviews { get; set; }
    
        public CoursesDbContext(DbContextOptions<CoursesDbContext> options)
            : base(options)
        {
        }
        
       // public DbSet<User> Users { get; set; }
    }
}
