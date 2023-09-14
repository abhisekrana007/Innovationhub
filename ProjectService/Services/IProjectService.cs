using ProjectService.Models;

namespace ProjectService.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetAllAsyc();
        Task<Project> GetById(string id);
        Task CreateAsync(Project project);
        Task UpdateAsync(string id, Project project);
        Task DeleteAysnc(string id);
        List<Project> GetByInnoId(string id);



    }
}
