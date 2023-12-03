using E_Commerce.Domain.Entities;
using E_Commerce.Domain.Enums;

namespace E_Commerce.Application.Services.Clients
{
    public interface IClientService
    {
        ValueTask<Client> AddAsync(Client client);
        ValueTask<Client> UpdateClientPhoneNumberAsync(long telegramId, string phoneNumber);
        ValueTask<Client> UpdateClientNameAsync(long telegramId, string name);
        ValueTask<Client> UpdateClientLanguageCodeAsync(long telegramId, string languageCode);
        ValueTask<Client> UpdateClientUserStatusAsync(long telegramId, Status status);
        ValueTask<bool> DeleteClientAsync(long id);
        ValueTask<Client> GetClientAsync(long id);
    }
}
