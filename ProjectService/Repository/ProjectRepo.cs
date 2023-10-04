using System.Security.Authentication;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProjectService.Models;

namespace ProjectService.Repository
{
    public class ProjectRepo:IProjectRepo
    {
        private readonly IMongoCollection<Project> _projectCollection;
        private readonly IMongoCollection<Proposal> _proposalCollection;
        private readonly IOptions<DatabaseSettings> _dbSettings;
       
        public ProjectRepo(IOptions<DatabaseSettings> dbSettings)
        {

            string connectionString =
   @"mongodb://innovationaccount:nOw32mZu5c1N1AR8564qtpLTtKnRKAEmTB2Vf1iS2z1183HWZuz6T0mjUvaXZwBipXzXi2HdxWZaACDblyAUkw==@innovationaccount.mongo.cosmos.azure.com:10255/?ssl=true&retrywrites=false&replicaSet=globaldb&maxIdleTimeMS=120000&appName=@innovationaccount@";
            MongoClientSettings settings1 = MongoClientSettings.FromUrl(
              new MongoUrl(connectionString)
            );
            settings1.SslSettings =
              new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            var mongoClient = new MongoClient(settings1);
            _dbSettings = dbSettings;
            //var client = new MongoClient(dbSettings.Value.ConnectionString);
            var database = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _projectCollection = database.GetCollection<Project>
                (dbSettings.Value.ProjectsCollectionName);
            _proposalCollection = database.GetCollection<Proposal>
                (dbSettings.Value.ProposalsCollectionName);
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

        public bool StatusUpdate(string id, string expertid, string status)
        {
            if (id != null)
            {
                var obj = _projectCollection.Find(x => x.ProjectID == id).FirstOrDefault();
                obj.Status = status;
                obj.ExpertId = expertid;
                var objProposal = _proposalCollection.Find(x => x.ProjectId == id && x.ExpertId == expertid).FirstOrDefault();
                if(status == "Completed")
                {
                    objProposal.Status = "Completed";
                }
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
