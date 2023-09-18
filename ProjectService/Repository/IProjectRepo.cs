using ProjectService.Models;

namespace ProjectService.Repository
{
    public interface IProjectRepo
    {

        Task<IEnumerable<Project>> GetAllAsyc();
        Task<Project> GetById(string id);
        Task CreateAsync(Project project);
        Task UpdateAsync(string id, Project project);
        Task DeleteAysnc(string id);
        List<Project> GetByInnoId(string id);

        Proposal GetAcceptedProposal(List<Proposal> proposals, string proposalId);

        List<Project> GetByExpertID(string id);
    
    }
}
