using E_Commerce.Data.Entities;

namespace E_Commerce.Application.Services
{
    public interface IClientService
    {
        ValueTask<Client> AddAsync(Client client);
        ValueTask<Client> UpdateClientPhoneNumberAsync(Client client,string phoneNumber);
        ValueTask<Client> UpdateClientLanguageCodeAsync(Client client,string languageCode);
        ValueTask<Client> UpdateClientUserStatusAsync(Client client,UserStatus status);
        ValueTask<bool> DeleteClientAsync(long id);
        ValueTask<Client> GetClientAsync(long id);
    }
}
