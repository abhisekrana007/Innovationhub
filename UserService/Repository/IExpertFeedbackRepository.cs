using System.Collections.Generic;
using System.Threading.Tasks;
using UserService.Model;

namespace UserService.Repository
{
    public interface IExpertFeedbackRepository
    {
        Task<IEnumerable<ExpertFeedback>> GetAllAsync();
        Task<ExpertFeedback> GetByIdAsync(string id);
        Task AddAsync(ExpertFeedback feedback);
        Task UpdateAsync(string id, ExpertFeedback feedback);
        Task DeleteAsync(string id);
        Task<double> GetRating(string expertId);
    }
}
