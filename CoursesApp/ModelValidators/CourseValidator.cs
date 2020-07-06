using CoursesApp.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CoursesApp.Validators
{
    public class CourseValidator : AbstractValidator<Course>
	{
		public CourseValidator()
		{

			RuleFor(x => x.DateAdded)
				.LessThan(DateTime.Now)
				.WithMessage("Date added for a course can't be greater than current date.");

			RuleFor(x => x.Name)
				.NotEmpty()
				.WithMessage("Course name cannot be empty");

			RuleFor(x => x.DurationInMin)
				.GreaterThan(0)
				.WithMessage("Course duration in minutes can't be lower than 0.");
		}
	}
}
