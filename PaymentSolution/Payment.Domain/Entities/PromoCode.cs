using System;

namespace Payments.Domain.Entities
{
    public class PromoCode
    {
        private Customer Customer;
        private Guid AuthenticationCode;
        private bool AlreadyUsed;
        private DateTime InitialDate;
        private DateTime DueDate;
        private decimal DiscountValue;

        public static PromoCode Create(Customer customer, decimal discountValue)
        {
            return new PromoCode()
            {
                Customer = customer,
                AuthenticationCode = Guid.NewGuid(),
                AlreadyUsed = false,
                InitialDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(30),
                DiscountValue = discountValue
            };
        }

    }
}
