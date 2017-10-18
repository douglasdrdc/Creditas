using Payments.Domain.Entities;
using System;

namespace Payments.Domain.Interfaces.Services
{
    public interface IOrderService
    {
        Guid ProcessOrder(Order order);
    }
}
