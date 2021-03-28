using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace ReportGenerator
{
    public static class ReportsGenerator
    {
        private static IData fileData;

        public static int lineNumber = 0;
        public static bool isError;

        public static void TodaysOrdersReport(string ordersFilePath)
        {
            fileData = new Input();

            var orders = ReadOrders(ordersFilePath)
                .Where(o => o.DateTime.Date == DateTime.Now.Date);

            var reportLines = CalculateTotalCostByCustomer(orders);

            PrintReport(reportLines);
        }

        public static void TodaysOrdersReport(IData file, ITime time)
        {
            fileData = file;

            var orders = ReadOrders(file)
                .Where(o => o.DateTime.Date == time.Now.Date);

            var reportLines = CalculateTotalCostByCustomer(orders);

            PrintReport(reportLines);
        }

        public static IReadOnlyList<Order> ReadOrders(IData file)
        {
            fileData = file;
            string ordersFilePath = "";

            var result = ReadOrders(ordersFilePath);
            return result;
        }

        public static IReadOnlyList<Order> ReadOrders(string ordersFilePath)
        {
            // Format: 
            // 
            // email1 yyyy-mm-dd hh:mm 
            // product-code1
            // product-code2 qty
            // email2 yyyy-mm-dd hh:mm 
            // product-code3
            // ...

            List<string> lines = fileData.GetFile(ordersFilePath);

            var orders = new List<Order>();
            Order currentOrder = null;

            for (int i = 0; i < lines.Count; i++)
            {
                lineNumber++;
                var words = lines[i].Split(' ');
                if (3 <= words.Length && words.Length <= 5)
                {
                    if (!TryParseOrder(words, out var order))
                    {
                        continue;
                    }

                    if (currentOrder != null)
                    {
                        orders.Add(currentOrder);
                    }
                    currentOrder = order;
                }
                else if (words.Length == 2 || words.Length == 1)
                {
                    if (!TryParseOrderItem(words, out var item))
                    {
                        continue;
                    }

                    currentOrder = currentOrder.AppendItem(item);
                }

                if (isError)
                    break;

            }

            orders.Add(currentOrder);

            return orders;
        }

        public static bool TryParseOrder(string[] words, out Order order)
        {
            var email = words[0];
            if (!email.Contains('@'))
            {
                order = null;
                Console.WriteLine($"Ошибка во входных данных на строке {lineNumber}");
                isError = true;
            }

            if (!TryParseDateTime(words[1] + " " + words[2], "yyyy-MM-dd HH:mm", out var dateTime))
            {
                order = null;
                Console.WriteLine($"Ошибка во входных данных на строке {lineNumber}");
                isError = true;
            }

            var items = Array.Empty<OrderItem>();
            if (words.Length > 3)
            {
                if (!TryParseOrderItem(words.Skip(3).ToArray(), out var item))
                {
                    order = null;
                    Console.WriteLine($"Ошибка во входных данных на строке {lineNumber}");
                    isError = true;
                }

                items = new[] { item };
            }

            order = new Order(email, dateTime, items);
            return true;
        }

        public static bool TryParseOrderItem(string[] words, out OrderItem item)
        {
            var productCode = words[0];

            if (!int.TryParse(ElementAtOrDefault(words, at: 1, defaultsTo: "1"), out var quantity))
            {
                item = null;
                return false;
            }
            if (quantity <= 0)
            {
                item = null;
                return false;
            }

            item = new OrderItem(productCode, quantity);
            return true;
        }

        public static bool TryParseDateTime(string dateTimeText, string format, out DateTime parsed)
        {
            var culture = Thread.CurrentThread.CurrentCulture;
            var style = DateTimeStyles.AssumeLocal | DateTimeStyles.AllowWhiteSpaces;
            return DateTime.TryParseExact(dateTimeText, format, culture, style, out parsed);
        }

        private static T ElementAtOrDefault<T>(T[] array, int at, T defaultsTo)
        {
            return at < array.Length ? array[at] : defaultsTo;
        }

        public static IEnumerable<(string email, double totalCost)> CalculateTotalCostByCustomer(IEnumerable<Order> orders)
        {
            return orders
                .GroupBy(o => o.Email, StringComparer.CurrentCultureIgnoreCase)
                .OrderBy(g => g.Key, StringComparer.CurrentCultureIgnoreCase)
                .Select(orderGroup =>
                {
                    var totalCostInCents = orderGroup
                        .SelectMany(o => o.Items)
                        .Select(i => i.Quantity * ProductCatalog.FindProductByCode(i.ProductCode).PriceInCents)
                        .Sum();

                    return (orderGroup.Key, (double)(totalCostInCents / 100));
                });
        }

        public static void PrintReport(IEnumerable<(string email, double totalCost)> reportLines)
        {
            if (isError)
                return;

            Console.WriteLine("Email, Price");
            foreach (var reportLine in reportLines)
            {
                Console.WriteLine($"{reportLine.email}, ${reportLine.totalCost.ToString("F2", CultureInfo.InvariantCulture)}");
            }
        }
    }
}
