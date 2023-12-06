using E_Commerce.Domain.Common;

namespace E_Commerce.Domain.Entities
{
    public class Basket : Auditable
    {
        public long Id { get; set; }
        public long ClientTelegramId { get; set; }

        public List<ProductList>? Products { get; set; }
    }
}
