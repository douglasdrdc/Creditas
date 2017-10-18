using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Domain.Entities
{
    public class OrderItem
    {
        public Order Order { get; set; }
        public Product Product { get; set; }


        public decimal total()
        {
            return 10;
        }
    }
}
