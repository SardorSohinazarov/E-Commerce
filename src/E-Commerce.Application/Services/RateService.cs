using E_Commerce.Application.Abstruction;
using E_Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Application.Services
{
    public class RateService : IRateService
    {
        private readonly IApplicationDbContext _context;

        public RateService(IApplicationDbContext context)
            => _context = context;

        public async ValueTask<Rate> AddRateAsync(Rate rate)
        {
            var entry = await _context.Rates.AddAsync(rate);
            await _context.SaveChangesAsync();

            return entry.Entity;
        }

        public async ValueTask<List<Rate>> GetRatesAsync()
        {
            var rates = await _context.Rates.ToListAsync();

            return rates;
        }
    }
}
