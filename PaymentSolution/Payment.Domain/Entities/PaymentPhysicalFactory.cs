namespace Payments.Domain.Entities
{
    public class PaymentPhysicalFactory : PaymentFactory
    {
        public IPayment Create()
        {
            return new PaymentPhysical();
        }
    }
}
