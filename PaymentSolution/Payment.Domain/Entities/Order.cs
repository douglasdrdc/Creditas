using System;
using System.Collections.Generic;
using System.Linq;

namespace Payments.Domain.Entities
{
    public class Order
    {
        public Customer Customer { get; set; }
        public List<OrderItem> items { get; set; }
        public IPayment Payment { get; set; }
        public Address Address { get; set; }
        public DateTime ClosedAt { get; set; }


        public decimal TotalAmount()
        {
            decimal totalAmount = 0;
            if (this.items != null && this.items.Count > 0)
            {
                totalAmount = this.items.ToList().Sum(x => x.total());
            }

            return totalAmount;
        }

        public void AddProduct(Product product)
        {
            if (product != null)
            {
                if (this.items == null)
                    this.items = new List<OrderItem>();
                this.items.Add(new OrderItem() { Order = this, Product = product });
            }
        }

        public void Close()
        {
            this.ClosedAt = DateTime.Now;
        }
    }
}
