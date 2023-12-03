namespace E_Commerce.Domain.Entities
{
    public class Rate
    {
        public long Id { get; set; }
        public int Grade { get; set; }

        public long UserTelegramId { get; set; }
    }
}
