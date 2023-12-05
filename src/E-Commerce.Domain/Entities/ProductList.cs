namespace E_Commerce.Domain.Entities
{
    public class ProductList
    {
        public int Id { get; set; }
        public int? Count { get; set; }
        public int ProductId { get; set; }
        public long UserTelegramId { get; set; }
    }
}