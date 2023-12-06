using E_Commerce.Domain.Common;

namespace E_Commerce.Domain.Entities
{
    public class Product : Auditable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public string? ImagePath { get; set; }
    }
}
