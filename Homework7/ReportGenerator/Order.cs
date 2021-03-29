using System;
using System.Collections.Generic;
using System.Linq;

namespace ReportGenerator
{
    public class Order
    {
        public Order(string email, DateTime dateTime, string coupon, IReadOnlyList<OrderItem> items)
        {
            Email = email;
            DateTime = dateTime;
            Items = items;
            Coupon = coupon;
        }

        public string Email { get; }
        public DateTime DateTime { get; }
        public IReadOnlyList<OrderItem> Items { get; }
        public string Coupon { get; }

        public Order AppendItem(OrderItem item)
        {
            return new Order(Email, DateTime, Coupon, Items.Append(item).ToArray());
        }
    }

    public class OrderItem
    {
        public OrderItem(string productCode, int quantity, string couponCode)
        {
            ProductCode = productCode;
            Quantity = quantity;
            CouponCode = couponCode;
        }

        public string ProductCode { get; }
        public int Quantity { get; }
        public string CouponCode { get; set; }
    }
}
