using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Model;
using UserService.Service;
using System;
using System.Threading.Tasks;

namespace UserService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ExpertFeedbackController : ControllerBase
    {
        private readonly IExpertFeedbackService _service;

        public ExpertFeedbackController(IExpertFeedbackService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFeedbackAsync()
        {
            try
            {
                var feedbackList = await _service.GetAllFeedbackAsync();
                return Ok(feedbackList);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{FeedbackId}")]
        public async Task<IActionResult> GetFeedbackByIdAsync(string FeedbackId)
        {
            try
            {
                var feedback = await _service.GetFeedbackByIdAsync(FeedbackId);
                if (feedback == null)
                    return NotFound();

                return Ok(feedback);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeedbackAsync([FromBody] ExpertFeedback feedback)
        {
            try
            {
                if (feedback == null)
                {
                    return BadRequest("Invalid input. The feedback object is null.");
                }

                // Validate the feedback object here (e.g., using data annotations or custom validation).
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Assuming you have a route named "GetFeedbackByIdAsync" with a parameter "id".
                // Use the route name and route values to generate the location header.
                var routeValues = new { id = feedback.FeedbackID };
                var url = Url.RouteUrl("GetFeedbackByIdAsync", routeValues, Request.Scheme);

                await _service.CreateFeedbackAsync(feedback);

                // Return a 201 Created response with the location of the newly created resource.
                return Created(url, feedback);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it in a way that's appropriate for your application.
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while creating the feedback: {ex.Message}");
            }
        }



        [HttpPut("{FeedbackId}")]
        public async Task<IActionResult> UpdateFeedbackAsync(string FeedbackId, [FromBody] ExpertFeedback feedback)
        {
            try
            {
                await _service.UpdateFeedbackAsync(FeedbackId, feedback);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{FeedbackId}")]
        public async Task<IActionResult> DeleteFeedbackAsync(string FeedbackId)
        {
            try
            {
                await _service.DeleteFeedbackAsync(FeedbackId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("rating/{expertId}")]
        public async Task<IActionResult> GetRatingforExpert(string expertId)
        {
            try
            {
                await _service.GetRating(expertId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
    }

}
