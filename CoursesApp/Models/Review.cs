using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursesApp.Models
{
    public class Review
    {
        public long id { get; set; }
        public object Id { get; internal set; }
        public string Content { get; set; } 
        public long CourseId { get; set; }
        public Course Course { get; set; }
    }
}
