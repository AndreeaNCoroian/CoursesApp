using CoursesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursesApp.ViewModels
{
    public class CourseDetails
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public Difficulty Difficulty { get; set; }
        public int DurationInMin { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<ReviewForCourseDetails> Reviews { get; set; }

        public static CourseDetails FromCourse(Course course)
        {
            return new CourseDetails
            {
                Id = course.Id,
                Name = course.Name,
                Category = course.Category,
                Difficulty = course.Difficulty,
                DurationInMin = course.DurationInMin,
                DateAdded = course.DateAdded,
                StartDate = course.StartDate,
                EndDate = course.EndDate,
                Reviews = course.Reviews.Select(c => ReviewForCourseDetails.FromReview(c)).ToList()
            };
        }
    }
}
