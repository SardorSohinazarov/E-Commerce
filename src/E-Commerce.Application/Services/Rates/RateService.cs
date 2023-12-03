using E_Commerce.Application.Abstruction;
using E_Commerce.Application.DTOs;
using E_Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Application.Services.Rates
{
    public class RateService : IRateService
    {
        private readonly IApplicationDbContext _context;

        public RateService(IApplicationDbContext context)
            => _context = context;

        public async ValueTask<Rate> AddRateAsync(RateCreationDTO rateCreationDTO)
        {
            int grade = rateCreationDTO.RateText switch
            {
                "Juda yomon 👎🏻" => 1,
                "Yomon ⭐️⭐️" => 2,
                "Yoqmadi ⭐️⭐️⭐️" => 3,
                "Yaxshi ⭐️⭐️⭐️⭐️" => 4,
                "Hammasi yoqdi ♥️" => 5,
                _ => 0
            };

            var rate = new Rate()
            {
                Grade = grade,
                UserTelegramId = rateCreationDTO.UserTelegramId,
            };

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
