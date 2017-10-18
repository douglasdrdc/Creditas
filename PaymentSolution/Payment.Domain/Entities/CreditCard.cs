using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Domain.Entities
{
    public class CreditCard
    {
        public string Code { get; set; }

        public static CreditCard FetchByHashed(string code)
        {
            return new CreditCard() { Code = code };
        }
    }
}
