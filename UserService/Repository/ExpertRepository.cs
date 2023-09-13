using MongoDB.Driver;
using UserService.Model;

namespace UserService.Repository
{
    public class ExpertRepository : IExpertRepository
        {
            private readonly IMongoCollection<Expert> _collection;

            public ExpertRepository(IMongoDatabase database)
            {
                _collection = database.GetCollection<Expert>("Experts");
            }

            public async Task<Expert> GetByIdAsync(string expertId)
            {
                return await _collection.Find(e => e.ExpertID == expertId).FirstOrDefaultAsync();
            }

            public async Task<List<Expert>> GetAllAsync()
            {
                return await _collection.Find(_ => true).ToListAsync();
            }

            public async Task CreateAsync(Expert expert)
            {
                await _collection.InsertOneAsync(expert);
            }

            public async Task UpdateAsync(string expertId, Expert expert)
            {
                await _collection.ReplaceOneAsync(e => e.ExpertID == expertId, expert);
            }

            public async Task DeleteAsync(string expertId)
            {
                await _collection.DeleteOneAsync(e => e.ExpertID == expertId);
            }
        }
    }




