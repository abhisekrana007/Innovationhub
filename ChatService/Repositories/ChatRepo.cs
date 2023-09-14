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
        public async Task<Chat> AddMessageToChat(Message message,string chatId)
        {
            Chat chat = await _chats.Find(x => x.ChatId.Equals(chatId)).FirstOrDefaultAsync();
            if (chat != null)
            {
                var filter = Builders<Chat>
                .Filter.Eq(e => e.ChatId, chatId);

                var update = Builders<Chat>.Update
                        .Push<Message>(e => e.Messages, message);
                _chats.UpdateOneAsync(filter,update);
                return await _chats.Find(x => x.ChatId.Equals(chatId)).FirstOrDefaultAsync();
            }
            else
            {
                return null;
            }
        }

        public async Task<Chat> CreateChat(string innovatorId, string expertId)
        {
            Chat findchat = await _chats.Find(x => x.InnovatorId.Equals(innovatorId) && x.ExpertId.Equals(expertId)).FirstOrDefaultAsync();
            if (findchat == null)
            {
                Chat chat = new Chat()
                {
                    InnovatorId = innovatorId,
                    ExpertId = expertId,
                    Messages = new List<Message>()
                };
                await _chats.InsertOneAsync(chat);
                return chat;
            }
            else
            {
                return null;
            }
            
        }

        public async Task<Chat> GetChat(string chatId)
        {
            return await _chats.Find(x => x.ChatId.Equals(chatId)).FirstOrDefaultAsync();
        }

        public async Task<List<Chat>> GetExpertChats(string expertId)
        {
            return await _chats.Find(x => x.ExpertId == expertId).ToListAsync();
        }

        public async Task<List<Chat>> GetInnovatorChats(string innovatorId)
        {
            return await _chats.Find(x=>x.InnovatorId==innovatorId).ToListAsync();
        }
    }
}
