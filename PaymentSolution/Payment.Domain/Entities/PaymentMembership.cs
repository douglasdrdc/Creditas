using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Domain.Entities
{
    public class PaymentMembership : Payment, IPayment
    {
        public Guid Process()
        {            
            this.Pay();
            Membership.ActivateSigning(this.Order.Customer);
            SendEmailNotification();

            return this.AuthorizationNumber;
        }

        private void SendEmailNotification()
        {            
            return;
        }

    }
}
