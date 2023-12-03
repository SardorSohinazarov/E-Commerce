namespace E_Commerce.Domain.Common
{
    public class Auditable
    {
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
