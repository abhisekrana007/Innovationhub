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

        public async Task<IEnumerable<ExpertFeedback>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<ExpertFeedback> GetByIdAsync(string id)
        {
            var filter = Builders<ExpertFeedback>.Filter.Eq(f => f.FeedbackID, id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task AddAsync(ExpertFeedback feedback)
        {
            await _collection.InsertOneAsync(feedback);
        }

        public async Task UpdateAsync(string id, ExpertFeedback feedback)
        {
            var filter = Builders<ExpertFeedback>.Filter.Eq(f => f.FeedbackID, id);
            await _collection.ReplaceOneAsync(filter, feedback);
        }

        public async Task DeleteAsync(string id)
        {
            var filter = Builders<ExpertFeedback>.Filter.Eq(f => f.FeedbackID, id);
            await _collection.DeleteOneAsync(filter);
        }

        public async Task GetRating(string expertId)
        {
            //Store rating for the given expertid in list then find sum of all the ratings and size of list
            var sum = Builders<ExpertFeedback>.Filter.Eq(f => f.FeedbackID, feedbackId);
            var count = Builders<ExpertFeedback>.Update.Set(f => f.Rating, newRating);

            var avgRating = sum / count;
            return avgRating;
        }
    }
}
