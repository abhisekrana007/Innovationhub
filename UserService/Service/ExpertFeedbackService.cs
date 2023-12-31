﻿using UserService.Model;
using UserService.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UserService.Service
{
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

        public async Task GetRating(string feedbackId )
        {
            await _repository.GetRating(feedbackId);
        }
    }
}
