using MongoDB.Driver;
using UserService.Model;
using UserService.MongoDBSettings;

namespace UserService.Repository
{
    public class ExpertFeedbackRepository : IExpertFeedbackRepository
    {
        private readonly IMongoCollection<ExpertFeedback> _collection;
        public ExpertFeedbackRepository(IUserDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<ExpertFeedback>(settings.ExpertFeedbacksCollectionName);
        }


        public ExpertFeedbackRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<ExpertFeedback>("ExpertFeedback");
        }

        public async Task<IEnumerable<ExpertFeedback>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<ExpertFeedback> GetByIdAsync(string id)
        {
            return await _collection.Find(f => f.FeedbackID == id).FirstOrDefaultAsync();
        }

        public async Task AddAsync(ExpertFeedback feedback)
        {
            await _collection.InsertOneAsync(feedback);
        }

        public async Task UpdateAsync(string id, ExpertFeedback feedback)
        {
            await _collection.ReplaceOneAsync(f => f.FeedbackID == id, feedback);
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(f => f.FeedbackID == id);
        }
    }
}
