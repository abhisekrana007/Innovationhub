using Microsoft.Extensions.Options;
using MongoDB.Driver;
using UserService.Model;
using UserService.MongoDBSettings;

namespace UserService.Repository
{
    public class InnovatorRepository : IInnovatorRepository
    {
        private readonly IMongoCollection<Innovator> _innovatorCollection;

        public InnovatorRepository(IUserDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _innovatorCollection = database.GetCollection<Innovator>(settings.UsersCollectionName);
        }

        public async Task<IEnumerable<Innovator>> GetAllAsync()
        {
            var innovators = await _innovatorCollection.Find(_ => true).ToListAsync();
            return innovators;
        }

        public async Task<Innovator> GetByIdAsync(string id)
        {
            var filter = Builders<Innovator>.Filter.Eq(i => i.InnovatorID, id);
            var innovator = await _innovatorCollection.Find(filter).FirstOrDefaultAsync();
            return innovator;
        }

        public async Task CreateAsync(Innovator innovator)
        {
            await _innovatorCollection.InsertOneAsync(innovator);
        }

        public async Task UpdateAsync(string id, Innovator innovator)
        {
            await _innovatorCollection.ReplaceOneAsync(i => i.InnovatorID == id, innovator);
        }

        public async Task DeleteAsync(string id)
        {
            var filter = Builders<Innovator>.Filter.Eq(i => i.InnovatorID, id);
            await _innovatorCollection.DeleteOneAsync(filter);
        }
    }
}
