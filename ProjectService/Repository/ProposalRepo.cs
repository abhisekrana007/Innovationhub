﻿
using ProjectService.Models;
using MongoDB.Driver;
using ProjectService.services;
using Microsoft.Extensions.Options;
using ProjectService.Services;
using System.Security.Authentication;

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
            //_dbSettings = dbSettings;
            //var client = new MongoClient(dbSettings.Value.ConnectionString);
            //var database = client.GetDatabase(dbSettings.Value.DatabaseName);
            //string connectionString =
   //@"mongodb://innovationaccount:nOw32mZu5c1N1AR8564qtpLTtKnRKAEmTB2Vf1iS2z1183HWZuz6T0mjUvaXZwBipXzXi2HdxWZaACDblyAUkw==@innovationaccount.mongo.cosmos.azure.com:10255/?ssl=true&retrywrites=false&replicaSet=globaldb&maxIdleTimeMS=120000&appName=@innovationaccount@";
   //         MongoClientSettings settings1 = MongoClientSettings.FromUrl(
   //           new MongoUrl(connectionString)
            
            //settings1.SslSettings =
            //  new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            //var mongoClient = new MongoClient(settings1);
            //var database = mongoClient.GetDatabase(_dbSettings);
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

        public bool StatusUpdate(string proposalid,string status)
        {
            if (proposalid != null)
            {
                var obj = _proposals.Find(x => x.ProposalId == proposalid).FirstOrDefault();
                obj.Status = status;

                // var obj = _proposals.Find(x => x.ProposalId == proposal.ProposalId);
                var filter = Builders<Proposal>.Filter.Eq(x => x.ProposalId, proposalid);
                var obj2 = _proposals.ReplaceOne(filter, obj);
                
                //var result = _proposals.Find(x => x.ProposalId != proposal.ProposalId).ToList();
                //var filters = Builders<Proposal>.Filter.Eq(x => x.Status, proposal.Status);
                //_proposals.ReplaceOne(filters, proposal);
                if(status == "Running")
                {
                    var obj1 = _projectserv.StatusUpdate(obj.ProjectId, obj.ExpertId, status);
                    if (obj1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return true; 
                
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
        public List<Proposal> GetAllProposalByExpertId(string expertid)
        {
            var obj = _proposals.Find(x => x.ExpertId == expertid).ToList();
            if (obj == null)
            {
                return null;
            }
            return obj;
        }

    }
}
