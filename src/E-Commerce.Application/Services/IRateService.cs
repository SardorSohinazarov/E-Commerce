using E_Commerce.Domain.Entities;

namespace E_Commerce.Application.Services
{
    public interface IRateService
    {
        ValueTask<Rate> AddRateAsync(Rate rate);
        ValueTask<List<Rate>> GetRatesAsync();
    }
}
