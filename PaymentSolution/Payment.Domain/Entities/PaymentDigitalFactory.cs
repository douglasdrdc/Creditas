
namespace Payments.Domain.Entities
{
    public class PaymentDigitalFactory : PaymentFactory
    {
        public IPayment Create()
        {
            return new PaymentDigital();
        }
    }
}
