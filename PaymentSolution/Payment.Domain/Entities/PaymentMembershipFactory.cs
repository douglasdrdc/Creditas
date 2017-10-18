namespace Payments.Domain.Entities
{
    public class PaymentMembershipFactory : PaymentFactory
    {
        public IPayment Create()
        {
            return new PaymentMembership();
        }
    }
}
