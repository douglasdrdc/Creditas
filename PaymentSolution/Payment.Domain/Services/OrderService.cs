using Payments.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payments.Domain.Entities;

namespace Payments.Domain.Services
{
    public class OrderService : IOrderService
    {
        public Guid ProcessOrder(Order order)
        {            
            PaymentFactory paymentFactory = null;
            ProductType productType = order.items.Select(x => x.Product.Type).FirstOrDefault();
            switch (productType)
            {
                case ProductType.Book:
                    paymentFactory = new PaymentBookFactory();
                    break;
                case ProductType.Digital:
                    paymentFactory = new PaymentDigitalFactory();
                    break;
                case ProductType.Membership:
                    paymentFactory = new PaymentMembershipFactory();
                    break;
                case ProductType.Physical:
                    paymentFactory = new PaymentPhysicalFactory();
                    break;
            }

            IPayment newPayment = paymentFactory.Create();
            newPayment.Order = order;
            newPayment.PaymentMethod = CreditCard.FetchByHashed("43567890-987654367");
            return newPayment.Process();                        
        }
    }
}
