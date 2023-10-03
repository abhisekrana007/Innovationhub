using System.Runtime.CompilerServices;
using ProjectService.Exceptions;
using ProjectService.Models;
using ProjectService.Repository;

namespace ProjectService.Services
{
    public class ProjectServicess:IProjectServices
    {
        private readonly IProjectRepo _repo;
        private readonly MessageProducer _producer;
        public ProjectServicess(IProjectRepo repo, MessageProducer producer)
        {
            _repo = repo;
            _producer = producer;
        }

        // public async Task<Expert> GetExpertByIdAsync(string expertId)
        //{
        //  return await _repository.GetByIdAsync(expertId);

        public async Task<IEnumerable<Project>> GetAllAsyc()
        {
            return await _repo.GetAllAsyc();
        }

        public async Task<Project> GetById(string id)
        {
            return await _repo.GetById(id);
        }

        public async Task CreateAsync(Project project)
        {
             await _repo.CreateAsync(project);
            _producer.SendMessage();

        }

        public async Task UpdateAsync(string id, Project project)
        {
            await _repo.UpdateAsync(id, project);
        }

        public async Task DeleteAysnc(string id)
        {
            await _repo.DeleteAysnc(id);
        }

        public List<Project> GetByInnoId(string id)
        {
            var result=_repo.GetByInnoId(id);
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public Proposal GetAcceptedProposal(List<Proposal>proposals, string proposalId)
        {
            return _repo.GetAcceptedProposal(proposals, proposalId);
        }

        public List<Project> GetByExpertID(string id)
        {
            
            var result= _repo.GetByExpertID(id);
            if(result== null)
            {
                return null;
            }
            return result;
        }

        public bool StatusUpdate(string id, string expertid,string status)
        {

            var result = _repo.StatusUpdate(id,expertid,status);
            if (!result)
            {
                return false;


            }
            return true;

        }

    }
}
