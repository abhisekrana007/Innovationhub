using UserService.Model;

namespace UserService.Repository
{
    public interface IInnovatorRepository
    {
        Task<IEnumerable<Innovator>> GetAllAsync();
        Task<Innovator> GetByIdAsync(string id);
        Task CreateAsync(Innovator innovator);
        Task UpdateAsync(string id, Innovator innovator);
        Task DeleteAsync(string id);

    }
}
