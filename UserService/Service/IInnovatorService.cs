using UserService.Model;

namespace UserService.Service
{
    public interface IInnovatorService
    {
        Task<IEnumerable<Innovator>> GetAllInnovatorsAsync();
        Task<Innovator> GetInnovatorByIdAsync(string id);
        Task CreateInnovatorAsync(Innovator innovator);
        Task UpdateInnovatorAsync(string id, Innovator innovator);
        Task DeleteInnovatorAsync(string id);
      
    }
}
