using ChatService.Models;

namespace ChatService.Repositories
{
    public interface IChatRepo
    {
        public Task<Chat> CreateChat(string innovatorId,string expertId);
        public Task<Chat> AddMessageToChat(Message message,string chatId);
        public Task<Chat> GetChat(string chatId);
        public Task<List<Chat>> GetInnovatorChats(string innovatorId);
        public Task<List<Chat>> GetExpertChats(string expertId);


    }
}
