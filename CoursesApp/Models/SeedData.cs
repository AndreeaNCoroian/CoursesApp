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
                if (context.Courses.Any())
                {
                    return;   // DB table has been seeded
                }

                context.Courses.AddRange(
                    new Course
                    {
                        Name = "Commercial Photography: Still and Moving Image",
                        Category = Category.Photography,
                        Difficulty = Difficulty.Intermediate,
                        DurationInMin = 120,
                        DateAdded = DateTime.Parse("2020-1-01"),
                        StartDate = DateTime.Parse("2020-1-15"),
                        EndDate = DateTime.Parse("2020-5-20")
                    },

                    new Course
                    {
                        Name = "Cooking: Restaurant recipes at home",
                        Category = Category.Culinary,
                        Difficulty = Difficulty.Beginner,
                        DurationInMin = 150,
                        DateAdded = DateTime.Parse("2020-1-20"),
                        StartDate = DateTime.Parse("2020-4-10"),
                        EndDate = DateTime.Parse("2020-6-15")
                    },
                       new Course
                       {
                           Name = "Android fundamentals",
                           Category = Category.Technology,
                           Difficulty = Difficulty.Beginner,
                           DurationInMin = 1500,
                           DateAdded = DateTime.Parse("2020-1-17"),
                           StartDate = DateTime.Parse("2020-1-25"),
                           EndDate = DateTime.Parse("2020-6-30")
                       }


                ); ; ; ; ; ; ;
                context.SaveChanges();
            }
        }
    }
}
