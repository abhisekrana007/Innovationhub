using System.Security.Authentication;
using MongoDB.Driver;
using UserService.Model;
using UserService.MongoDBSettings;

namespace UserService.Repository
{
    public class ExpertRepository : IExpertRepository
        {
            private readonly IMongoCollection<Expert> _collection;
        public ExpertRepository(IUserDatabaseSettings settings)
        {
            string connectionString =
  @"mongodb://innovationaccount:nOw32mZu5c1N1AR8564qtpLTtKnRKAEmTB2Vf1iS2z1183HWZuz6T0mjUvaXZwBipXzXi2HdxWZaACDblyAUkw==@innovationaccount.mongo.cosmos.azure.com:10255/?ssl=true&retrywrites=false&replicaSet=globaldb&maxIdleTimeMS=120000&appName=@innovationaccount@";
            MongoClientSettings settings1 = MongoClientSettings.FromUrl(
              new MongoUrl(connectionString)
            );
            settings1.SslSettings =
              new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            var mongoClient = new MongoClient(settings1);
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<Expert>(settings.ExpertsCollectionName);
        }

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
            
            var filter = Builders<Expert>.Filter.Eq(e => e.ExpertID, expertId);
            var update = Builders<Expert>.Update
                .Set(e => e.Username, expert.Username)
                .Set(e => e.Password, expert.Password)
                .Set(e => e.Email, expert.Email)
                .Set(e => e.Firstname, expert.Firstname)
                .Set(e => e.Lastname, expert.Lastname)
                .Set(e => e.DateOfBirth, expert.DateOfBirth)
                .Set(e => e.Skills, expert.Skills)
                .Set(e => e.Rating, expert.Rating)
                .Set(e => e.Budget, expert.Budget)
                .Set(e => e.RegistrationDate, expert.RegistrationDate);

            var updateOptions = new UpdateOptions
            {
                IsUpsert = false 
            };

            await _collection.UpdateOneAsync(filter, update, updateOptions);
        }
        public async Task DeleteAsync(string expertId)
            {
                await _collection.DeleteOneAsync(e => e.ExpertID == expertId);
            }
        public async Task UpdateExpertRatingAsync(string expertId, double newRating)
        {
            var filter = Builders<Expert>.Filter.Eq(e => e.ExpertID, expertId);
            var update = Builders<Expert>.Update.Set(e => e.Rating, newRating);
            await _collection.UpdateOneAsync(filter, update);
        }
    }
    }




