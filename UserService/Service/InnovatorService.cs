using UserService.Model;
using UserService.Repository;

namespace UserService.Service
{
   
public class InnovatorService : IInnovatorService
{
    private readonly IInnovatorRepository _repository;

    public InnovatorService(IInnovatorRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Innovator>> GetAllInnovatorsAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Innovator> GetInnovatorByIdAsync(string id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task CreateInnovatorAsync(Innovator innovator)
    {
        innovator.RegistrationDate = DateTime.UtcNow;
        // You can also add hashing logic for the password here
        await _repository.CreateAsync(innovator);
    }

    public async Task UpdateInnovatorAsync(string id, Innovator innovator)
    {
        await _repository.UpdateAsync(id, innovator);
    }

    public async Task DeleteInnovatorAsync(string id)
    {
        await _repository.DeleteAsync(id);
    }
}

    }

