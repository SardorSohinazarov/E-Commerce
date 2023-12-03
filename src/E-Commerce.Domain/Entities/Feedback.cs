namespace E_Commerce.Domain.Entities
{
    public class Feedback
    {
        public long Id { get; set; }
        public string Text { get; set; }

        public long UserTelegramId { get; set; }
    }
}
