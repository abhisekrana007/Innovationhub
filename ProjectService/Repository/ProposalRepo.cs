
using ProjectService.Models;
using MongoDB.Driver;
using ProjectService.services;
using Microsoft.Extensions.Options;
using ProjectService.Services;

namespace ProjectService.Repository
{

    public class ProposalRepo:IProposalRepo
    {
        private readonly IMongoCollection<Proposal> _proposals;
        private readonly IOptions<DatabaseSettings> _dbSettings;
        private readonly IProjectServices _projectserv;
        public ProposalRepo(IOptions<DatabaseSettings> dbSettings, IProjectServices projectService)
        {
            //var dbHost = "localhost";
            //var dbName = "Proposal_DB";
            //var connectionString = $"mongodb://{dbHost}:27017/{dbName}";
            //var mongoUrl = MongoUrl.Create(connectionString);
            //var mongoClient = new MongoClient(mongoUrl);
            //var databaseName = mongoClient.GetDatabase(mongoUrl.DatabaseName);
            //_proposals = databaseName.GetCollection<Proposal>("Proposal");

            _dbSettings = dbSettings;
            var client = new MongoClient(dbSettings.Value.ConnectionString);
            var database = client.GetDatabase(dbSettings.Value.DatabaseName);
            _proposals = database.GetCollection<Proposal>
                (dbSettings.Value.ProposalsCollectionName);
            _projectserv = projectService;


        }

        public bool CreateProposal(Proposal proposal)
        {
           //var obj = _proposals.Find(x => x.ExpertId == proposal.ExpertId).FirstOrDefaultAsync();
            //if (obj == null)
            //{
                _proposals.InsertOneAsync(proposal);
                return true;
            //}
            //return false;
        }

       public List<Proposal> GetAllProposalByProjectId(string projectid)
        {
            var obj = _proposals.Find(x => x.ProjectId == projectid).ToList();
            if (obj == null)
            {
                return null;
            }
            return obj;
        }

       public bool DeleteProposal(string proposalId)
        {
            var obj = _proposals.Find(x => x.ProposalId == proposalId).FirstOrDefaultAsync();
            if (obj == null)
            {
                return false;
            }

            var filter = Builders<Proposal>.Filter.Eq(x => x.ProposalId, proposalId);
            _proposals.DeleteOneAsync(filter);
            return true;

        }

       public bool UpdateProposal(string id, Proposal proposal)
        {
            var bookings = _proposals.Find(x => x.ProposalId == id);
            if (bookings == null)
            {
                return false;
            }
            var filter = Builders<Proposal>.Filter.Eq(x => x.ProposalId, proposal.ProposalId);
            _proposals.ReplaceOne(filter, proposal);
            return true;
        }

        public bool StatusUpdate(string proposalid)
        {
            if (proposalid != null)
            {
                var obj = _proposals.Find(x => x.ProposalId == proposalid).FirstOrDefault();
                obj.Status = "running";

                // var obj = _proposals.Find(x => x.ProposalId == proposal.ProposalId);
                var filter = Builders<Proposal>.Filter.Eq(x => x.ProposalId, proposalid);
                _proposals.ReplaceOne(filter, obj);
                
                //var result = _proposals.Find(x => x.ProposalId != proposal.ProposalId).ToList();
                //var filters = Builders<Proposal>.Filter.Eq(x => x.Status, proposal.Status);
                //_proposals.ReplaceOne(filters, proposal);
                var obj1 = _projectserv.StatusUpdate(obj.ProjectId);
                if (obj1)
                {
                    return true;
                }
                
            }
            return false;
        }

        public List<Proposal> GetAllProposal()
        {
            var obj = _proposals.Find(x => true).ToList();
            if (obj == null)
            {
                return null;
            }
            return obj;

        }
    }
}
