using E_Commerce.Application.Abstruction;
using E_Commerce.Domain.Entities;
using E_Commerce.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Application.Services.Clients
{
    public class ClientsService : IClientService
    {
        private readonly IApplicationDbContext _context;

        public ClientsService(IApplicationDbContext context)
            => _context = context;

        public async ValueTask<Client> AddAsync(Client client)
        {
            var storageClient = await _context.Clients.FirstOrDefaultAsync(x => x.TelegramId == client.TelegramId);

            if (storageClient == null)
            {
                var entry = await _context.Clients.AddAsync(client);

                var basket = new Basket()
                {
                    ClientTelegramId = client.TelegramId,
                };

                var basketEnry = await _context.Baskets.AddAsync(basket);

                await _context.SaveChangesAsync();
                return entry.Entity;
            }
            else
            {
                return storageClient;
            }
        }

        public async ValueTask<bool> DeleteClientAsync(long id)
        {
            var storageClient = await _context.Clients.FirstOrDefaultAsync(x => x.TelegramId == id);

            if (storageClient == null)
            {
                return false;
            }
            else
            {
                _context.Clients.Remove(storageClient);
                await _context.SaveChangesAsync();

                return true;
            }
        }

        public async ValueTask<Client> GetClientAsync(long id)
        {
            var storageUser = await _context.Clients.FirstOrDefaultAsync(x => x.TelegramId == id);

            return storageUser;
        }

        public async ValueTask<Client> UpdateClientLanguageCodeAsync(long telegramId, string languageCode)
        {
            var storageUser = await _context.Clients.FirstOrDefaultAsync(x => x.TelegramId == telegramId);

            if (storageUser == null)
            {
                return storageUser;
            }
            else
            {
                storageUser.LanguageCode = languageCode;
                var entry = _context.Clients.Update(storageUser);
                await _context.SaveChangesAsync();

                return entry.Entity;
            }
        }

        public async ValueTask<Client> UpdateClientNameAsync(long telegramId, string name)
        {
            var storageUser = await _context.Clients.FirstOrDefaultAsync(x => x.TelegramId == telegramId);

            if (storageUser == null)
            {
                return storageUser;
            }
            else
            {
                storageUser.FirstName = name;
                storageUser.Status = Status.Active;

                var entry = _context.Clients.Update(storageUser);
                await _context.SaveChangesAsync();

                return entry.Entity;
            }
        }

        public async ValueTask<Client> UpdateClientPhoneNumberAsync(long telegramId, string phoneNumber)
        {
            var storageUser = await _context.Clients.FirstOrDefaultAsync(x => x.TelegramId == telegramId);

            if (storageUser == null)
            {
                return storageUser;
            }
            else
            {
                storageUser.PhoneNumber = phoneNumber;
                storageUser.Status = Status.Active;

                var entry = _context.Clients.Update(storageUser);
                await _context.SaveChangesAsync();

                return entry.Entity;
            }
        }

        public async ValueTask<Client> UpdateClientUserStatusAsync(long telegramId, Status status)
        {
            var storageUser = await _context.Clients.FirstOrDefaultAsync(x => x.TelegramId == telegramId);

            if (storageUser == null)
            {
                return storageUser;
            }
            else
            {
                storageUser.Status = status;
                var entry = _context.Clients.Update(storageUser);
                await _context.SaveChangesAsync();

                return entry.Entity;
            }
        }

        public async ValueTask<Client> UpdateClientUserStatusesAsync(long telegramId, string lastBasketProduct, Status status)
        {
            var storageUser = await _context.Clients.FirstOrDefaultAsync(x => x.TelegramId == telegramId);

            if (storageUser == null)
            {
                return storageUser;
            }
            else
            {
                storageUser.Status = status;
                storageUser.LastBasketProduct = lastBasketProduct;
                var entry = _context.Clients.Update(storageUser);
                await _context.SaveChangesAsync();

                return entry.Entity;
            }
        }
    }
}
