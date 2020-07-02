using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursesApp.Models
{
    public enum Category
    {
        Writing,
        Music,
        Finance,
        Design,
        Photography,
        Culinary,
        Entertainment,
        Society,
        Technology
    }
    public enum Difficulty
    {
        Beginner,
        Intermediate,
        Advanced
    }
    public class Course
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public Difficulty Difficulty { get; set; }
        public int DurationInMin { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<Review> Reviews { get; set; }

    }
}
