using UserService.Model;

namespace UserService.Service
{
    public interface IExpertService
    {
        Task<Expert> GetExpertByIdAsync(string expertId);
        Task<List<Expert>> GetAllExpertsAsync();
        Task CreateExpertAsync(Expert expert);
        Task UpdateExpertAsync(string expertId, Expert expert);
        Task DeleteExpertAsync(string expertId);
        Task UpdateExpertRatingAsync(string expertId, double newRating);

    }
}
