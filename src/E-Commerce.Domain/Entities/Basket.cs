using E_Commerce.Domain.Common;
using System.Diagnostics.SymbolStore;

namespace E_Commerce.Domain.Entities
{
    public class Basket:Auditable
    {
        public long Id { get; set; }
        public bool IsActive { get; set; }
        public long ClientTelegramId { get; set; }

        public List<Product> Products { get; set; }
    }
}
