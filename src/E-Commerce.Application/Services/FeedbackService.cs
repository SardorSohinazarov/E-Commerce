using E_Commerce.Application.Abstruction;
using E_Commerce.Domain.Entities;

namespace E_Commerce.Application.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IApplicationDbContext _context;

        public FeedbackService(IApplicationDbContext context)
            => _context = context;

        public ValueTask<Feedback> AddFeedbackAsync(Feedback feedback)
        {
            throw new NotImplementedException();
        }

        public ValueTask<List<Feedback>> GetFeedbacksAsync()
        {
            throw new NotImplementedException();
        }
    }
}
