using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Domain.Entities          
{
    public class PaymentBook : Payment, IPayment
    {
        public Guid Process()
        {
            this.Pay();
            GenerateShippingLabel();

            return this.AuthorizationNumber;
        }  
        
        private void GenerateShippingLabel()
        {
            string message = "This is Tax-exempt item as provided in the Constitution Art. 150, VI, d.";  
            return;
        }
    }
}
