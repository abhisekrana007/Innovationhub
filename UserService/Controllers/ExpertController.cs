using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Model;
using UserService.Service;

namespace UserService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ExpertController : ControllerBase
    {
        private readonly IExpertService _expertService;

        public ExpertController(IExpertService expertService)
        {
            _expertService = expertService;
        }

        [HttpGet("{expertId}")]
        public async Task<IActionResult> GetExpert(string expertId)
        {
            try
            {
                var expert = await _expertService.GetExpertByIdAsync(expertId);
                if (expert == null)
                {
                    return NotFound();
                }
                return Ok(expert);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExperts()
        {
            try
            {
                var experts = await _expertService.GetAllExpertsAsync();
                return Ok(experts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateExpert([FromBody] Expert expert)
        {
            try
            {
                await _expertService.CreateExpertAsync(expert);
                return CreatedAtAction("GetExpert", new { expertId = expert.ExpertID }, expert);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{expertId}")]
        public async Task<IActionResult> UpdateExpert(string expertId, [FromBody] Expert expert)
        {
            try
            {
                await _expertService.UpdateExpertAsync(expertId, expert);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{expertId}")]
        public async Task<IActionResult> DeleteExpert(string expertId)
        {
            try
            {
                await _expertService.DeleteExpertAsync(expertId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("rating/{expertId}")]
        public async Task<IActionResult> UpdateExpertRating(string expertId, [FromBody] double newRating)
        {
            await _expertService.UpdateExpertRatingAsync(expertId, newRating);
            return NoContent();
        }
    }
}

