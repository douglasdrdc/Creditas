
namespace Payments.Domain.Entities
{
    public class PaymentBookFactory : PaymentFactory
    {
        public IPayment Create()
        {
            return new PaymentBook();
        }
    }
}
