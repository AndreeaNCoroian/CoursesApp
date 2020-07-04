using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoursesApp.Models;
using CoursesApp.ViewModels;

namespace CoursesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly CoursesDbContext _context;

        public CoursesController(CoursesDbContext context)
        {
            _context = context;
        }

        // GET: api/Courses
        /// <summary>
        /// Gets a list of all the courses.
        /// </summary>
        /// <param name="from">Filter courses added from this date time (inclusive). Leave empty for no upper limit.</param>
        /// <param name="to">Filter courses added up to this date time (inclusive). Leave empty for no lower limit.</param>
        /// <returns>A list of all courses.</returns>
        /// <response code="201">Returns the list of courses.</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseWithNumberOfReviews>>> GetCourses(DateTime? from = null, DateTime? to = null)
        {
            IQueryable<Course> result = _context.Courses;
            if (from != null)
            {
                result = result.Where(f => from <= f.DateAdded);
            }
            if (to != null)
            {
                result = result.Where(f => f.DateAdded <= to);
            }
            var resultList = await result
                .OrderBy(f => f.Name)
                .Include(f => f.Reviews) //similar with join -> if we want to use an entity wich is related we should include it
                .Select(f => CourseWithNumberOfReviews.FromCourse(f))
                .ToListAsync();
            return resultList;
        }

        // GET: api/Courses/5
        /// <summary>
        /// Returns all details for a specific course.
        /// </summary>
        /// <param name="id">Get course details for a specified course id.</param>
        /// <returns>Complete details of the course with specific id.</returns>
        /// <response code="201">Returns the course with specified id.</response>
        /// <response code="404">Not found, if there's no course with specified id.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CourseDetails>> GetCourse(long id)
        {
            var course = await _context
                .Courses
                .Include(f => f.Reviews)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (course == null)
            {
                return NotFound("Course does not exist!");
            }

            return CourseDetails.FromCourse(course);
        }

        // PUT: api/Courses/5
        /// <summary>
        /// Updates a specific course.
        /// </summary>
        /// <param name="id">The id of the course to be updated.</param>
        /// <param name="course">The course that will be updated.</param>
        /// <returns>The updated course.</returns>
        /// <response code = "201">When the course was updated succesfully.</response>
        /// <response code = "404">When there's no course with given id.</response>
        /// <response code = "400">When the given id is not equal with course id.</response>
        /// <response code = "204">Request has succeeded.</response>
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PutCourse(long id, Course course)
        {
            if (id != course.Id)
            {
                return BadRequest();
            }

            _context.Entry(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
                {
                    return NotFound("This course does not exist!");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Courses
        /// <summary>
        /// Creates a new entry for courses.
        /// </summary>
        /// <param name="course">The course to be added.</param>
        /// <returns>The new added course.</returns>
        ///<response code = "201"> Returns the newly created course.</response>
        ///<response code = "400"> If date added is greater than current date. or
        ///                        If course name is empty. or
        ///                        If start date for a course is greater than current date. or
        ///                        If duration in minutes for a course is lower than 0. </response>
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Course>> PostCourse(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourse", new { id = course.Id }, course);
        }

        // DELETE: api/Courses/5
        /// <summary>
        /// Deletes a specific course.
        /// </summary>
        /// <param name="id">The id of the course to be deleted.</param>
        /// <response code = "201">When the course was deleted succesfully.</response>
        /// <response code = "400">When the course was not deleted succesfully.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Course>> DeleteCourse(long id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound("This course does not exist!");
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return course;
        }

        private bool CourseExists(long id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }
    }
}
