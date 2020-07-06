using CoursesApp.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace CoursesApp.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CoursesDbContext(serviceProvider.GetRequiredService<DbContextOptions<CoursesDbContext>>()))
            {
 
                //Looks for any Course
                if (context.Courses.Count() >= 200)
                {
                    return;   // DB table has been seeded
                }

                for (int i = 1; i <= 200; ++i)
                {
                    context.Courses.Add(
                       new Course
                           {
                               Name = $"Course-{i}",
                               Category = Category.Technology,
                               Difficulty = Difficulty.Beginner,
                               DurationInMin = i,
                               DateAdded = DateTime.Now
                           }
                       );
                }

                context.SaveChanges();
            }
        }
    }
}
