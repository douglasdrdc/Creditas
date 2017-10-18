
namespace Payments.Domain.Entities
{
    public class Invoice
    {
        public Address BillingAddress { get; set; }
        public Address ShippingAddress { get; set; }
        public Order Order { get; set; }
    }
}
