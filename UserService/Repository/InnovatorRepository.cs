using Microsoft.Extensions.Options;
using MongoDB.Driver;
using UserService.Model;
using UserService.MongoDBSettings;

namespace UserService.Repository
{
    public class InnovatorRepository : IInnovatorRepository
    {
        private readonly IMongoCollection<Innovator> _innovatorCollection;
        public InnovatorRepository(IMongoDatabase database, IOptions<InnovatorDBSettings> mongoDBSettings)
        {
            var settings = mongoDBSettings.Value;
            var client = new MongoClient(settings.ConnectionString);
            var db = client.GetDatabase(settings.DatabaseName);

            _innovatorCollection = db.GetCollection<Innovator>("Innovators");
        }

        public InnovatorRepository(IMongoDatabase database)
        {
            _innovatorCollection = database.GetCollection<Innovator>("Innovators");
        }

        public async Task<IEnumerable<Innovator>> GetAllAsync()
        {
            return await _innovatorCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Innovator> GetByIdAsync(string id)
        {
            return await _innovatorCollection.Find(i => i.InnovatorID == id).FirstOrDefaultAsync();
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
            await _innovatorCollection.DeleteOneAsync(i => i.InnovatorID == id);
        }
    }

}

