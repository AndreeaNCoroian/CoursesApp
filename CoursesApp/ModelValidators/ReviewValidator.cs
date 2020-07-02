using CoursesApp.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursesApp.ModelValidators
{
	public class ReviewValidator : AbstractValidator<Review>
	{
		public ReviewValidator()
		{
			RuleFor(x => x.Id).NotNull();

			RuleFor(x => x.Content)
				.NotEmpty()
				.WithMessage("Review content cannot be empty.");

			RuleFor(x => x.Content)
				.Length(1, 500)
				.WithMessage("Text can't overpass 500 characters.");

		}
	}
}
