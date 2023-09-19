using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserService.Model;

namespace UserService.Service
{
    public interface IExpertFeedbackService
    {
        Task<IEnumerable<ExpertFeedback>> GetAllFeedbackAsync();
        Task<ExpertFeedback> GetFeedbackByIdAsync(string id);
        Task CreateFeedbackAsync(ExpertFeedback feedback);
        Task UpdateFeedbackAsync(string id, ExpertFeedback feedback);
        Task DeleteFeedbackAsync(string id);
        Task UpdateRatingAsync(string feedbackId, int newRating);
    }
}
