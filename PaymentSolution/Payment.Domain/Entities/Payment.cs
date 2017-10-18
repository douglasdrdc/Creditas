using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Domain.Entities
{
    public class Payment
    {
        private Guid _authorizationNumber;
        private decimal _amount;
        private Invoice _invoice;
        private DateTime _paidAt;
        public Order Order { get; set; }
        public CreditCard PaymentMethod { get; set; }

        public Guid AuthorizationNumber
        {
            get { return this._authorizationNumber; }
        }

        public void Pay()
        {
            this._amount = Order.TotalAmount();
            this._authorizationNumber = Guid.NewGuid();
            this._invoice = new Invoice() { BillingAddress = this.Order.Address, ShippingAddress = this.Order.Address, Order = this.Order };
            this._paidAt = DateTime.Now;
            this.Order.Close();
        }

        

    }
}
