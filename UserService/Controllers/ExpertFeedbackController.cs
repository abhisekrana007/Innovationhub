using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Model;
using UserService.Service;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
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
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeedbackByIdAsync(string id)
        {
            try
            {
                var feedback = await _service.GetFeedbackByIdAsync(id);
                if (feedback == null)
                    return NotFound();

                return Ok(feedback);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeedbackAsync([FromBody] ExpertFeedback feedback)
        {
            try
            {
                await _service.CreateFeedbackAsync(feedback);
                return CreatedAtAction(nameof(GetFeedbackByIdAsync), new { id = feedback.FeedbackID }, feedback);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFeedbackAsync(string id, [FromBody] ExpertFeedback feedback)
        {
            try
            {
                await _service.UpdateFeedbackAsync(id, feedback);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedbackAsync(string id)
        {
            try
            {
                await _service.DeleteFeedbackAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
