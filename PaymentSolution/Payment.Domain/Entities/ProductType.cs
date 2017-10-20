using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Domain.Entities
{
    public enum ProductType
    {
		None = 0,
        Physical = 1,
        Book = 2,
        Digital = 3,
        Membership = 4
    }
}
