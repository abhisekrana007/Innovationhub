using ChatService.Models;
using ChatService.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatRepo _repo;

        public ChatController(IChatRepo repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public IActionResult CreateAChat(string innovatorId,string expertId)
        {
            Chat chat = _repo.CreateChat(innovatorId, expertId);
            return Created("Created Chat Successfully", chat);
        }
    }
}
