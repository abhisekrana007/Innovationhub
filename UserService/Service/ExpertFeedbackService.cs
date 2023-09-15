using UserService.Model;
using UserService.Repository;

namespace UserService.Service
{
<<<<<<< HEAD
   
        public class ExpertFeedbackService : IExpertFeedbackService
        {
            private readonly IExpertFeedbackRepository _repository;



            public ExpertFeedbackService(IExpertFeedbackRepository repository)
            {
                _repository = repository;
            }



            public async Task<IEnumerable<ExpertFeedback>> GetAllFeedbackAsync()
            {
                return await _repository.GetAllAsync();
            }



            public async Task<ExpertFeedback> GetFeedbackByIdAsync(string id)
            {
                return await _repository.GetByIdAsync(id);
            }



            public async Task CreateFeedbackAsync(ExpertFeedback feedback)
            {
                await _repository.AddAsync(feedback);
            }



            public async Task UpdateFeedbackAsync(string id, ExpertFeedback feedback)
            {
                await _repository.UpdateAsync(id, feedback);
            }



            public async Task DeleteFeedbackAsync(string id)
            {
                await _repository.DeleteAsync(id);
            }



        }
=======
    public class ExpertFeedbackService : IExpertFeedbackService
    {
        private readonly IExpertFeedbackRepository _repository;

        public ExpertFeedbackService(IExpertFeedbackRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ExpertFeedback>> GetAllFeedbackAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<ExpertFeedback> GetFeedbackByIdAsync(string id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task CreateFeedbackAsync(ExpertFeedback feedback)
        {
            await _repository.AddAsync(feedback);
        }

        public async Task UpdateFeedbackAsync(string id, ExpertFeedback feedback)
        {
            await _repository.UpdateAsync(id, feedback);
        }

        public async Task DeleteFeedbackAsync(string id)
        {
            await _repository.DeleteAsync(id);
        }

>>>>>>> 0c357d446679c541018b6f090e5914287434bf7f
    }
