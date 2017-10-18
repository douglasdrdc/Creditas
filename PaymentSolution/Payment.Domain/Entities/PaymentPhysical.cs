using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Domain.Entities
{
    public class PaymentPhysical : Payment, IPayment
    {
        public Guid Process()
        {            
            this.Pay();
            GenerateShippingLabel();

            return this.AuthorizationNumber;
        }

        private void GenerateShippingLabel()
        {
            return;
        }

    }
}
