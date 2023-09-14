using ChatService.Models;
using ChatService.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatRepo _repo;

        public ChatController(IChatRepo repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAChat(string innovatorId,string expertId)
        {
            Chat chat = await _repo.CreateChat(innovatorId, expertId);
            if (chat != null)
            {
                return Created("Created Chat Successfully", chat);
            }
            else
            {
                return Conflict("Chat Already Exists");
            }
        }
        [HttpPut("{chatId}")]
        public async Task<IActionResult> AddMessage(Message message,string chatId)
        {
            Chat chat = await _repo.AddMessageToChat(message, chatId);
            if (chat != null)
            {
                return Ok(chat);
            }
            else
            {
                return NotFound("Chat Doesn't Exist");
            }
        }

        [HttpGet("{chatId}")]
        public async Task<IActionResult> GetAChat(string chatId)
        {
            Chat chat = await _repo.GetChat(chatId);
            if (chat != null)
            {
                return Ok(chat);
            }
            else
            {
                return NotFound("Chat Doesn't Exist");
            }
        }

        [Route("innovator/{innovatorId}")]        
        [HttpGet]

        public async Task<IActionResult> GetInnovatorChats(string innovatorId)
        {
            return Ok(await _repo.GetInnovatorChats(innovatorId));
        }

        [Route("expert/{expertId}")]
        [HttpGet]

        public async Task<IActionResult> GetExpertChats(string expertId)
        {
            return Ok(await _repo.GetExpertChats(expertId));
        }

    }
}
