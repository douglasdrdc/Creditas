using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payments.Domain.Entities;
using Payments.Domain.Services;
using System;

namespace Payment.Domain.Test
{
    [TestClass]
    public class OrderServiceTests
    {
        public Customer CustomerTest { get; set; }
        public Order OrderTest { get; set; }
        public OrderService Service { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            CustomerTest = new Customer()
            {
                FirstName = "José",
                LastName = "da Silva",
                Email = "jose.silva@teste.com.br"
            };

            OrderTest = new Order()
            {
                Customer = CustomerTest,
                Address = new Address() { ZipCode = "45678-979" }
            };

            Service = new OrderService();
        }

        [TestMethod]        
        public void AllowsInclusionOfNewOrderBookSuccessfully()
        {
            OrderTest.AddProduct(new Product() { Name = "Awesome book", Type = ProductType.Book });
            Guid paymentAuthorizationNumber = Service.ProcessOrder(OrderTest);

            Assert.AreNotEqual(Guid.Empty, paymentAuthorizationNumber);
        }

        [TestMethod]
        public void AllowsInclusionOfNewOrderDigitalSuccessfully()
        {
            OrderTest.AddProduct(new Product() { Name = "Pirates of valley silicon", Type = ProductType.Digital });
            Guid paymentAuthorizationNumber = Service.ProcessOrder(OrderTest);

            Assert.AreNotEqual(Guid.Empty, paymentAuthorizationNumber);
        }

        [TestMethod]
        public void AllowsInclusionOfNewOrderMembershipSuccessfully()
        {
            OrderTest.AddProduct(new Product() { Name = "Book Signing Club", Type = ProductType.Membership });
            Guid paymentAuthorizationNumber = Service.ProcessOrder(OrderTest);

            Assert.AreNotEqual(Guid.Empty, paymentAuthorizationNumber);
        }

        [TestMethod]
        public void AllowsInclusionOfNewOrderPhysicalSuccessfully()
        {
            OrderTest.AddProduct(new Product() { Name = "Johnnie Walker Honey Whiskey", Type = ProductType.Physical });
            Guid paymentAuthorizationNumber = Service.ProcessOrder(OrderTest);

            Assert.AreNotEqual(Guid.Empty, paymentAuthorizationNumber);
        }


    }
}
