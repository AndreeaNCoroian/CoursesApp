using CoursesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursesApp.ViewModels
{
    public class CourseWithNumberOfReviews
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public Difficulty Difficulty { get; set; }
        public int DurationInMin { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public long NumberOfReviews { get; set; }
        public static CourseWithNumberOfReviews FromCourse(Course course)
        {
            return new CourseWithNumberOfReviews
            {
                Id = course.Id,
                Name = course.Name,
                Category = course.Category,
                Difficulty = course.Difficulty,
                DurationInMin = course.DurationInMin,
                DateAdded = course.DateAdded,
                NumberOfReviews = course.Reviews.Count
            };
        }

    }
}
