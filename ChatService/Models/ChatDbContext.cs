namespace ChatService.Models
{
    public class ChatDbContext
    {
        public string ChatsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
