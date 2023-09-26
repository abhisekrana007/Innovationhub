using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProjectService.Models;

namespace ProjectService.Repository
{
    public class ProjectRepo:IProjectRepo
    {
        private readonly IMongoCollection<Project> _projectCollection;
        private readonly IOptions<DatabaseSettings> _dbSettings;

        public ProjectRepo(IOptions<DatabaseSettings> dbSettings)
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


        public List<Project> GetByInnoId(string id)
        {
            var result = _projectCollection.Find(a => a.InnovatorID == id).ToList();
            if (result == null)
            {
                return null;
            }
            return result;

        }

        public Proposal GetAcceptedProposal(List<Proposal> proposals, string proposalId)
        {
            var obj=proposals.Find(x=>x.ProposalId == proposalId);
            obj.Status = "running";

            var result = _projectCollection.Find(x => x.ProjectID == obj.ProjectId).FirstOrDefault();
            result.ExpertId=obj.ExpertId;
            var filter = Builders<Project>.Filter.Eq(x => x.ProjectID, result.ProjectID);
            _projectCollection.ReplaceOne(filter, result);
            return obj;
           
        }

        public List<Project> GetByExpertID(string id)
        {
            var obj=_projectCollection.Find(x=>x.ExpertId == id).ToList();
            if(obj == null)
            {
                return null;
            }
            return obj;



        }

        public bool StatusUpdate(string id)
        {
            if (id != null)
            {
                var obj = _projectCollection.Find(x => x.ProjectID == id).FirstOrDefault();
                obj.Status = "running";
                // var obj = _proposals.Find(x => x.ProposalId == proposal.ProposalId);
                var filter = Builders<Project>.Filter.Eq(x => x.ProjectID,id);
                _projectCollection.ReplaceOne(filter, obj);
                //var result = _proposals.Find(x => x.ProposalId != proposal.ProposalId).ToList();
                //var filters = Builders<Proposal>.Filter.Eq(x => x.Status, proposal.Status);
                //_proposals.ReplaceOne(filters, proposal);
                return true;

            }
            return false;
        }








    }
}
