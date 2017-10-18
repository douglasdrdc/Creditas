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
            return;
        }
    }
}
