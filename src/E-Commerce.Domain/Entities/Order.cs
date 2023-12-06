using E_Commerce.Domain.Common;

namespace E_Commerce.Domain.Entities
{
    public class Order:Auditable
    {
        public long Id { get; set; }
        public List<ProductList> ProductList { get; set; }
    }
}
