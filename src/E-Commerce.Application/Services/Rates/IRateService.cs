using E_Commerce.Application.DTOs;
using E_Commerce.Domain.Entities;

namespace E_Commerce.Application.Services.Rates
{
    public interface IRateService
    {
        ValueTask<Rate> AddRateAsync(RateCreationDTO rateCreationDTO);
        ValueTask<List<Rate>> GetRatesAsync();
    }
}
