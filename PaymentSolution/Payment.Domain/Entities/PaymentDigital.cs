using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Domain.Entities
{
    public class PaymentDigital : Payment, IPayment
    {
        public Guid Process()
        {   
            this.Pay();
            PromoCode promoCode = PromoCode.Create(this.Order.Customer, 10);
            SendEmailPurchaseDescription(promoCode);

            return this.AuthorizationNumber;
        }

        private void SendEmailPurchaseDescription(PromoCode promoCode)
        {
            string message = string.Format("You won a discount of ${0} on your next purchase", 
                promoCode.DiscountValue.ToString("#0.00"));
            return;
        }
    }
}
