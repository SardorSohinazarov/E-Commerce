namespace E_Commerce.Data.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public long TelegramId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }
        public string? PhoneNumber { get; set; }
        public string? LanguageCode { get; set; }

        public UserStatus? UserStatus { get; set; }
    }
}
