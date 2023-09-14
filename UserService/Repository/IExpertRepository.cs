using UserService.Model;

namespace UserService.Repository
{
    public interface IExpertRepository
    {
        Task<Expert> GetByIdAsync(string expertId);
        Task<List<Expert>> GetAllAsync();
        Task CreateAsync(Expert expert);
        Task UpdateAsync(string expertId, Expert expert);
        Task DeleteAsync(string expertId);
    }
}

    