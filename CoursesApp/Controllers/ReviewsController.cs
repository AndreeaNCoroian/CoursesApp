using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoursesApp.Models;

namespace CoursesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly CoursesDbContext _context;

        public ReviewsController(CoursesDbContext context)
        {
            _context = context;
        }

        // GET: api/Reviews
        /// <summary>
        /// Gets a list of all reviews.
        /// </summary>
        /// <returns>A list of reviews.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviews()
        {
            return await _context.Reviews.ToListAsync();
        }

        // GET: api/Reviews/5
        /// <summary>
        /// Gets the review with specified id.
        /// </summary>
        /// <param name="id">Review d.</param>
        /// <returns>Returns a specific review.</returns>
        ///<response code= "201">Returns specific review</response>
        ///<response code="404">Not found, if there's no review with specified id.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Review>> GetReview(long id)
        {
            var review = await _context.Reviews.FindAsync(id);

            if (review == null)
            {
                return NotFound();
            }

            return review;
        }

        // PUT: api/Reviews/5
        /// <summary>
        /// Updates the review with specified id.
        /// </summary>
        /// <param name="id">The id of the review to be updated.</param>
        /// <param name="review">Review that will be updated.</param>
        /// <returns>Updated review.</returns>
        /// <response code = "201">When the review was updated succesfully.</response>
        /// <response code = "404">When there's no review with given id.</response>
        /// <response code = "400">When the given id is not equal with review id.</response>
        /// <response code = "204">Request has succeeded.</response>
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PutReview(long id, Review review)
        {
            if (id != review.Id)
            {
                return BadRequest();
            }

            _context.Entry(review).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Reviews
        /// <summary>
        /// Creates a new review.
        /// </summary>
        /// <param name="review">The review that you want to add.</param>
        /// <returns>The review that was created.</returns>
        ///<response code = "201"> Returns the newly created review.</response>
        ///<response code = "400"> If review content is empty. or
        ///                        If review content is overpasses 500 characters.</response>
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Review>> PostReview(Review review)
        {
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReview", new { id = review.Id }, review);
        }

        // DELETE: api/Reviews/5
        /// <summary>
        /// Deletes a specific review.
        /// </summary>
        /// <param name="id">The id of the review that you want to delete.</param>
        /// <returns></returns>
        /// <response code = "201">When the review was deleted succesfully.</response>
        /// <response code = "400">When the review was not deleted succesfully.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Review>> DeleteReview(long id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();

            return review;
        }

        private bool ReviewExists(long id)
        {
            return _context.Reviews.Any(e => e.Id == id);
        }
    }
}
