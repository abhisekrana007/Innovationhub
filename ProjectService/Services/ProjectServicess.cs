using System.Runtime.CompilerServices;
using ProjectService.Models;
using ProjectService.Repository;

namespace ProjectService.Services
{
    public class ProjectServicess:IProjectServices
    {
        private readonly IProjectRepo _repo;
        public ProjectServicess(IProjectRepo repo) 
        {
              _repo = repo;

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


    }
}
