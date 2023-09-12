using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Model;
using UserService.Service;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InnovatorController : ControllerBase
    {
   
        private readonly IInnovatorService _innovatorService;

        public InnovatorController(IInnovatorService innovatorService)
        {
            _innovatorService = innovatorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInnovators()
        {
            try
            {
                var innovators = await _innovatorService.GetAllInnovatorsAsync();
                return Ok(innovators);
            }
            catch (Exception ex)
            {
                // Handle exceptions and return an error response
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInnovatorById(string id)
        {
            try
            {
                var innovator = await _innovatorService.GetInnovatorByIdAsync(id);
                if (innovator == null)
                    return NotFound();

                return Ok(innovator);
            }
            catch (Exception ex)
            {
                // Handle exceptions and return an error response
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateInnovator(Innovator innovator)
        {
            try
            {
                await _innovatorService.CreateInnovatorAsync(innovator);
                return CreatedAtAction(nameof(GetInnovatorById), new { id = innovator.InnovatorID }, innovator);
            }
            catch (Exception ex)
            {
                // Handle exceptions and return an error response
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInnovator(string id, Innovator innovator)
        {
            try
            {
                await _innovatorService.UpdateInnovatorAsync(id, innovator);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Handle exceptions and return an error response
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInnovator(string id)
        {
            try
            {
                await _innovatorService.DeleteInnovatorAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Handle exceptions and return an error response
                return StatusCode(500, ex.Message);
            }
        }
    }

}

