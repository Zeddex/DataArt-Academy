﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ReportGenerator
{
    public class Product
    {
        public Product(string code, int priceInCents)
        {
            Code = code;
            PriceInCents = priceInCents;
        }

        public string Code { get; }
        public int PriceInCents { get; }
    }

    public static class ProductCatalog
    {
        private static readonly IReadOnlyList<Product> _products = new[]
        {
            new Product(code: "P01",  priceInCents: 1200),
            new Product(code: "P02b", priceInCents: 500),
            new Product(code: "P42",  priceInCents: 100)
        };

        public static Product FindProductByCode(string code)
        {
            return _products.FirstOrDefault(p => p.Code.Equals(code, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
