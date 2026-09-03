using MaleFashion.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Domain.Entities
{
    public class Order : IAggregateRoot<Guid>
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public CustomerDto User { get; set; }

        public string OrderNumber { get; set; }
        public double SubTotal { get; set; }
        public double DiscountAmount { get; set; }
        public double ShippingAmount { get; set; }
        public double TotalAmount { get; set; }
        public string OrderStatus { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShippingName { get; set; }
        public string ShippingPhone { get; set; }
        public string ShippingAddress { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingPostalCode { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
            = new List<OrderItem>();
    }
}
