using E_Commerce.Domain.Common;
using E_Commerce.Domain.Enums;

namespace E_Commerce.Domain.Entities
{
    public class Client : Auditable
    {
        public int Id { get; set; }

        public long TelegramId { get; set; }
        public string FirstName { get; set; } = default!;
        public string? LastName { get; set; }
        public string? Username { get; set; }
        public string? PhoneNumber { get; set; }
        public string? LanguageCode { get; set; }

        public Status Status { get; set; }
    }
}
