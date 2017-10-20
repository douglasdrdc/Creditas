using System;

namespace Payments.Domain.Entities
{
    public class PromoCode
    {
        public Customer Customer;
        public Guid AuthenticationCode;
        public bool AlreadyUsed;
        public DateTime InitialDate;
        public DateTime DueDate;
        public decimal DiscountValue;

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
