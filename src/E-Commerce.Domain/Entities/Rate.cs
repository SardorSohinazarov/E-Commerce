using E_Commerce.Domain.Common;

namespace E_Commerce.Domain.Entities
{
    public class Rate : Auditable
    {
        public long Id { get; set; }
        public int Grade { get; set; }

        public long UserTelegramId { get; set; }
    }
}
