using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Payments.Domain.Entities;
using Payments.Domain.Services;
using System;

namespace Payment.Domain.Test
{
    [TestClass]
    public class OrderServiceTests
    {
        public Customer _customer { get; set; }
        public Order _order { get; set; }
        public OrderService _service { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            _customer = new Customer()
            {
                FirstName = "José",
                LastName = "da Silva",
                Email = "jose.silva@teste.com.br"
            };

            _order = null;
            _order = new Order()
            {
                Customer = _customer,
                Address = new Address() { ZipCode = "45678-979" }
            };

            _service = new OrderService();            
        }

        [TestMethod]        
        public void AllowsInclusionOfNewOrderBookSuccessfully()
        {
            _order.AddProduct(new Product() { Name = "Awesome book", Type = ProductType.Book });
            Guid paymentAuthorizationNumber = _service.ProcessOrder(_order);

            Assert.AreNotEqual(Guid.Empty, paymentAuthorizationNumber);
        }

        [TestMethod]
        public void AllowsInclusionOfNewOrderDigitalSuccessfully()
        {
            _order.AddProduct(new Product() { Name = "Pirates of valley silicon", Type = ProductType.Digital });
            Guid paymentAuthorizationNumber = _service.ProcessOrder(_order);

            Assert.AreNotEqual(Guid.Empty, paymentAuthorizationNumber);
        }

        [TestMethod]
        public void AllowsInclusionOfNewOrderMembershipSuccessfully()
        {
            _order.AddProduct(new Product() { Name = "Book Signing Club", Type = ProductType.Membership });
            Guid paymentAuthorizationNumber = _service.ProcessOrder(_order);

            Assert.AreNotEqual(Guid.Empty, paymentAuthorizationNumber);
        }

        [TestMethod]
        public void AllowsInclusionOfNewOrderPhysicalSuccessfully()
        {
            _order.AddProduct(new Product() { Name = "Johnnie Walker Honey Whiskey", Type = ProductType.Physical });
            Guid paymentAuthorizationNumber = _service.ProcessOrder(_order);

            Assert.AreNotEqual(Guid.Empty, paymentAuthorizationNumber);
        }

        [TestMethod]
        public void RefuseInclusionOfNewOrderWithoutProductType()
        {
            string messageExpected = "Can not include new order without product type.";
            try
            {
                _order.AddProduct(new Product() { Name = "Johnnie Walker Honey Whiskey" });
                Guid paymentAuthorizationNumber = _service.ProcessOrder(_order);
                Assert.Fail(string.Format("The following message was expected: {0}", messageExpected));
            }
            catch (ApplicationException ex)
            {
                Assert.AreEqual(ex.Message, messageExpected);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [TestMethod]
        public void RefuseInclusionOfNewOrderNull()
        {
            string messageExpected = "Can not include new order null.";
            try
            {                
                Guid paymentAuthorizationNumber = _service.ProcessOrder(null);
                Assert.Fail(string.Format("The following message was expected: {0}", messageExpected));
            }
            catch (ApplicationException ex)
            {
                Assert.AreEqual(ex.Message, messageExpected);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
