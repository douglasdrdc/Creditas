using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Domain.Entities
{
    public class Membership
    {
        public Customer Customer { get; set; }
        public bool Active { get; set; }
        public DateTime ActivationDate { get; set; }


        public static void ActivateSigning(Customer customer)
        {
            Membership newSigning = new Membership()
            {
                Customer = customer,
                Active = true,
                ActivationDate = DateTime.Now
            };
        }
    }
}
