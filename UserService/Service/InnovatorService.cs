using System.Security.Cryptography;
using System.Text;
using UserService.Model;
using UserService.Repository;
using BCrypt.Net;

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

            // Hash the password before storing it
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(innovator.Password);

            // Replace the plain text password with the hashed password
            innovator.Password = hashedPassword;

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

