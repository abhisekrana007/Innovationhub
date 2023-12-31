﻿using System.Security.Authentication;
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
            string connectionString =
   @"mongodb://innovationaccount:nOw32mZu5c1N1AR8564qtpLTtKnRKAEmTB2Vf1iS2z1183HWZuz6T0mjUvaXZwBipXzXi2HdxWZaACDblyAUkw==@innovationaccount.mongo.cosmos.azure.com:10255/?ssl=true&retrywrites=false&replicaSet=globaldb&maxIdleTimeMS=120000&appName=@innovationaccount@";
            MongoClientSettings settings1 = MongoClientSettings.FromUrl(
              new MongoUrl(connectionString)
            );
            settings1.SslSettings =
              new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            var mongoClient = new MongoClient(settings1);
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _innovatorCollection = database.GetCollection<Innovator>(settings.InnovatorsCollectionName);
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

        public async Task UpdateAsync(string id, Innovator innovatorUpdate)
        {
            var filter = Builders<Innovator>.Filter.Eq(i => i.InnovatorID, id);

            string password = innovatorUpdate.Password;


            var update = Builders<Innovator>.Update
                .Set(i => i.Username, innovatorUpdate.Username)
                .Set(i => i.Password, innovatorUpdate.Password)
                .Set(i => i.Email, innovatorUpdate.Email)
                .Set(i => i.FirstName, innovatorUpdate.FirstName)
                .Set(i => i.LastName, innovatorUpdate.LastName)
                .Set(i => i.DateOfBirth, innovatorUpdate.DateOfBirth);



            await _innovatorCollection.UpdateOneAsync(filter, update);
        }

        public async Task DeleteAsync(string id)
        {
            var filter = Builders<Innovator>.Filter.Eq(i => i.InnovatorID, id);
            await _innovatorCollection.DeleteOneAsync(filter);
        }
    }
}
