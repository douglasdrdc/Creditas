using System;

namespace Payments.Domain.Entities
{
    public interface IPayment
    {
        Order Order { get; set; }
        CreditCard PaymentMethod { get; set; }

        Guid Process();
    }
}