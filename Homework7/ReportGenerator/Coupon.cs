using System;
using System.Collections.Generic;
using System.Linq;

namespace ReportGenerator
{
    public class Coupon
    {
        public string Code { get; }
        public DateTime ValidDate { get; }
        public int Discount { get; } = 0;

        public Coupon(string code, DateTime validDate, int discount)
        {
            Code = code;
            ValidDate = validDate;
            Discount = discount;
        }
    }

    public static class CouponsList
    {
        private static readonly IReadOnlyList<Coupon> _coupons = new[]
        {
            new Coupon(code: "SALE2903", validDate: DateTime.Parse("2021-03-29") , discount: 10),
            new Coupon(code: "SALE1102", validDate: DateTime.Parse("2021-02-11") , discount: 15),
            new Coupon(code: "", validDate: DateTime.Parse("2000-01-01") , discount: 0)
        };

        public static Coupon FindCouponByCode(string code)
        {
            return _coupons.FirstOrDefault(c => c.Code.Equals(code, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
