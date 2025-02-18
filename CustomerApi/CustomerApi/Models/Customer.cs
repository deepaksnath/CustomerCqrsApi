namespace CustomerApi.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "Customer Name";
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public bool HasLoyaltyMembership { get; set; } = false;
    }
}
