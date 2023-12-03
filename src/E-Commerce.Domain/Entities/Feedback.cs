using E_Commerce.Domain.Common;

namespace E_Commerce.Domain.Entities
{
    public class Feedback : Auditable
    {
        public long Id { get; set; }
        public string Text { get; set; }

        public long UserTelegramId { get; set; }
    }
}
