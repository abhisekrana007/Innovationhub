using UserService.Model;
using UserService.Repository;

namespace UserService.Service
{
    public class ExpertService : IExpertService
        {
            private readonly IExpertRepository _repository;

            public ExpertService(IExpertRepository repository)
            {
                _repository = repository;
            }

            public async Task<Expert> GetExpertByIdAsync(string expertId)
            {
                return await _repository.GetByIdAsync(expertId);
            }

            public async Task<List<Expert>> GetAllExpertsAsync()
            {
                return await _repository.GetAllAsync();
            }

           public async Task CreateExpertAsync(Expert expert)
{
            // Hash the password before storing it
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(expert.Password);

            // Replace the plain text password with the hashed password
            expert.Password = hashedPassword;

            await _repository.CreateAsync(expert);
        }
            public async Task UpdateExpertAsync(string expertId, Expert expert)
            {
                await _repository.UpdateAsync(expertId, expert);
            }

            public async Task DeleteExpertAsync(string expertId)
            {
                await _repository.DeleteAsync(expertId);
            }
        public async Task UpdateExpertRatingAsync(string expertId, double newRating)
        {
            // Assuming your repository has a method for updating the expert's rating
            await _repository.UpdateExpertRatingAsync(expertId, newRating);
        }
    }

    }

