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
        public IPayment IPayment { get; set; }        
        public PaymentFactory PaymentFactory { get; set; }
        
        public Guid ProcessOrder(Order order)
        {
            try
            {
                if (order == null)
                    throw new ApplicationException("Can not include new order null.");

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
                    case ProductType.None:
                        throw new ApplicationException("Can not include new order without product type.");
                }

                IPayment newPayment = paymentFactory.Create();
                newPayment.Order = order;
                newPayment.PaymentMethod = CreditCard.FetchByHashed("43567890-987654367");
                return newPayment.Process();
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while processing the order.", ex);
            }                     
        }
    }
}
