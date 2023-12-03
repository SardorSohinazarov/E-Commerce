using E_Commerce.Domain.Common;

namespace E_Commerce.Domain.Entities
{
    public class Branch : Auditable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
    }
}
