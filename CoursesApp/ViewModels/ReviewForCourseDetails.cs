using CoursesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursesApp.ViewModels
{
    public class ReviewForCourseDetails
    {
        public string Content { get; set; }

        public static ReviewForCourseDetails FromReview(Review review)
        {
            return new ReviewForCourseDetails
            {
                Content = review.Content
            };
        }
    }
}
