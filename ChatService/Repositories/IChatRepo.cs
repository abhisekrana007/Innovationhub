using ChatService.Models;

namespace ChatService.Repositories
{
    public interface IChatRepo
    {
        public Chat CreateChat(string innovatorId,string expertId);
        public Chat AddMessageToChat(Message message);
        public Chat GetChat(string chatId);
        public List<Chat> GetInnovatorChats(string innovatorId);
        public List<Chat> GetExpertChats(string expertId);


    }
}
