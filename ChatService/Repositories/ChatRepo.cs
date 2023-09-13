using ChatService.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ChatService.Repositories
{
    public class ChatRepo : IChatRepo
    {

        private readonly IMongoCollection<Chat> _chats;
        public ChatRepo(IOptions<ChatDbContext> settings)
        {
            /*var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
            var dbName = Environment.GetEnvironmentVariable("DB_NAME");
            var connectionString = $"mongodb://{dbHost}:27017/{dbName}";
            var mongoUrl = MongoUrl.Create(connectionString);
            var mongoClient = new MongoClient(mongoUrl);
            var databaseName = mongoClient.GetDatabase(mongoUrl.DatabaseName);
            _chats = databaseName.GetCollection<Chat>("Chats");*/

            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);

            _chats = database.GetCollection<Chat>(settings.Value.ChatsCollectionName);

        }
        public Chat AddMessageToChat(Message message,string chatId)
        {
            Chat chat = _chats.Find(x => x.ChatId.Equals(chatId)).FirstOrDefault();
            if (chat != null)
            {
                var filter = Builders<Chat>
                .Filter.Eq(e => e.ChatId, chatId);

                var update = Builders<Chat>.Update
                        .Push<Message>(e => e.Messages, message);
                _chats.UpdateOne(filter,update);
                return chat;
            }
            else
            {
                return null;
            }
        }

        public Chat CreateChat(string innovatorId, string expertId)
        {
            Chat chat = new Chat()
            {
                InnovatorId = innovatorId,
                ExpertId = expertId,
                Messages = new List<Message>()
            };
            _chats.InsertOne(chat);
            return chat;
        }

        public Chat GetChat(string chatId)
        {
            return _chats.Find(x => x.ChatId.Equals(chatId)).FirstOrDefault();
        }

        public List<Chat> GetExpertChats(string expertId)
        {
            throw new NotImplementedException();
        }

        public List<Chat> GetInnovatorChats(string innovatorId)
        {
            throw new NotImplementedException();
        }
    }
}
