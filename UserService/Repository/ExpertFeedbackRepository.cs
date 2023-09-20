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

        //public async Task GetRating(string expertId)
        //{
        //    //Store rating for the given expertid in list then find sum of all the ratings and size of list
        //    var sum = Builders<ExpertFeedback>.Filter.Eq(f => f.FeedbackID, feedbackId);
        //    var count = Builders<ExpertFeedback>.Update.Set(f => f.Rating, newRating);

        //    var avgRating = sum / count;
        //    return avgRating;
        //}
        public async Task<double> GetRating(string expertId)
        {
            var filter = Builders<ExpertFeedback>.Filter.Eq(f => f.ExpertID, expertId);
            var projection = Builders<ExpertFeedback>.Projection.Expression(feedback => feedback.Rating);

            var ratings = await _collection.Find(filter).Project(projection).ToListAsync();

            if (ratings.Count == 0)
            {
                // Handle the case when there are no ratings for the expert
                return 0.0; // You can choose to return a default value or handle this case differently.
            }

            var averageRating = ratings.Average();
            return averageRating;
        }

    }
}
