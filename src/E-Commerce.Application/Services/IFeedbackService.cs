﻿using E_Commerce.Domain.Entities;

namespace E_Commerce.Application.Services
{
    public interface IFeedbackService
    {
        ValueTask<Feedback> AddFeedbackAsync(Feedback feedback);
        ValueTask<List<Feedback>> GetFeedbacksAsync();
    }
}
