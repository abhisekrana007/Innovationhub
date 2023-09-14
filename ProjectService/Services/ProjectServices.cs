using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProjectService.Models;

namespace ProjectService.Services
{
    public class ProjectServices : IProjectService

    {

        private readonly IMongoCollection<Project> _projectCollection;
        private readonly IOptions<DatabaseSettings> _dbSettings;

        public ProjectServices(IOptions<DatabaseSettings> dbSettings)
        {
            _dbSettings = dbSettings;
            var client = new MongoClient(dbSettings.Value.ConnectionString);
            var database = client.GetDatabase(dbSettings.Value.DatabaseName);
            _projectCollection = database.GetCollection<Project>
                (dbSettings.Value.ProjectsCollectionName);

        }

        public async Task<IEnumerable<Project>> GetAllAsyc() =>
            await _projectCollection.Find(_ => true).ToListAsync();

        public async Task<Project> GetById(string id) =>
            await _projectCollection.Find(a => a.ProjectID == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Project project) =>
            await _projectCollection.InsertOneAsync(project);

        public async Task UpdateAsync(string id, Project project) =>
            await _projectCollection
            .ReplaceOneAsync(a => a.ProjectID == id, project);


        public async Task DeleteAysnc(string id) =>
            await _projectCollection.DeleteOneAsync(a => a.ProjectID == id);

    }
}
