using E_Commerce.Application.Abstruction;
using E_Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Application.Services.Feedbacks
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IApplicationDbContext _context;

        public FeedbackService(IApplicationDbContext context)
            => _context = context;

        public async ValueTask<Feedback> AddFeedbackAsync(Feedback feedback)
        {
            var entry = await _context.Feedbacks.AddAsync(feedback);
            await _context.SaveChangesAsync();

            return entry.Entity;
        }

        public async ValueTask<List<Feedback>> GetFeedbacksAsync()
        {
            var feedbacks = await _context.Feedbacks.ToListAsync();

            return feedbacks;
        }
    }
}
