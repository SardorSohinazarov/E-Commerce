﻿using E_Commerce.Application.Abstruction;
using E_Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Application.Services
{
    public class ClientsService:IClientService
    {
        private readonly IApplicationDbContext _context;

        public ClientsService(IApplicationDbContext context)
            => _context = context;

        public async ValueTask<Client> AddAsync(Client client)
        {
            var storageClient = await _context.Clients.FirstOrDefaultAsync(x => x.TelegramId == client.TelegramId);

            if(storageClient == null)
            {
                var entry = await _context.Clients.AddAsync(client);
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

        public async ValueTask<Client> UpdateClientLanguageCodeAsync(Client client, string languageCode)
        {
            var storageUser = await _context.Clients.FirstOrDefaultAsync(x => x.TelegramId == client.TelegramId);

            if (storageUser == null)
            {
                return storageUser;
            }
            else
            {
                storageUser.LanguageCode = languageCode;
                var entry = _context.Clients.Update(client);
                await _context.SaveChangesAsync();

                return entry.Entity;
            }
        }

        public async ValueTask<Client> UpdateClientPhoneNumberAsync(Client client, string phoneNumber)
        {
            var storageUser = await _context.Clients.FirstOrDefaultAsync(x => x.TelegramId == client.TelegramId);

            if(storageUser == null)
            {
                return storageUser;
            }
            else
            {
                storageUser.PhoneNumber = phoneNumber;
                var entry = _context.Clients.Update(client);
                await _context.SaveChangesAsync();

                return entry.Entity;
            }
        }

        public async ValueTask<Client> UpdateClientUserStatusAsync(Client client, Status status)
        {
            var storageUser = await _context.Clients.FirstOrDefaultAsync(x => x.TelegramId == client.TelegramId);

            if (storageUser == null)
            {
                return storageUser;
            }
            else
            {
                storageUser.Status = status;
                var entry = _context.Clients.Update(client);
                await _context.SaveChangesAsync();
               
                return entry.Entity;
            }
        }
    }
}