using E_Commerce.Domain.Common;

namespace E_Commerce.Domain.Entities
{
    public class Order:Auditable
    {
        public long Id { get; set; }

        public decimal Amount { get; set; }
        public long BasketId { get; set; }

        public int FromBranchId { get; set; }
        //Branchni locationini ham shunaqa qilish kerak

        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
    }
}
