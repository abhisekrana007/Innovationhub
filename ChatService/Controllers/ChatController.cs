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
        [HttpPut]
        public IActionResult AddMessage(Message message,string chatId)
        {
            Chat chat = _repo.AddMessageToChat(message, chatId);
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
        public IActionResult GetAChat(string chatId)
        {
            Chat chat = _repo.GetChat(chatId);
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

        public IActionResult GetInnovatorChats(string innovatorId)
        {
            return Ok(_repo.GetInnovatorChats(innovatorId));
        }

        [Route("expert/{expertId}")]
        [HttpGet]

        public IActionResult GetExpertChats(string expertId)
        {
            return Ok(_repo.GetExpertChats(expertId));
        }

    }
}
