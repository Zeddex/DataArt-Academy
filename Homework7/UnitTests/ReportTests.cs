using System;
using NUnit.Framework;
using FluentAssertions;
using ReportGenerator;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    [TestFixture]
    public class ReportTests
    {
        [Test]
        public void SuccessTest()
        {
            // arrange
            List<string> data = new List<string>();
            data.Add("abby@void.com 2021-02-11 10:00 P01 1");
            data.Add("bobby@void.com 2021-02-11 15:00 P02b 2");
            data.Add("charley@void.com 2021-02-11 12:30");
            data.Add("P01");
            data.Add("P42 5");
            IData fileData = new DataStub(data);
            ITime time = new TimeStub(new DateTime(2021, 02, 11));

            // act
            ReportsGenerator.TodaysOrdersReport(fileData, time);
            bool isError = ReportsGenerator.isError;

            // assert
            isError.Should().BeFalse();
        }

        [Test]
        public void TestDate()
        {
            // arrange
            string dateTime = "2021-02-11 10:00";
            string format = "yyyy-MM-dd HH:mm";
            DateTime expectedDate = DateTime.Parse("2021-02-11 10:00");

            // act
            ReportsGenerator.TryParseDateTime(dateTime, format, out DateTime result);

            // assert
            result.Should().BeSameDateAs(expectedDate);
        }

        [Test]
        public void TestParseOrderCode()
        {
            // arrange
            string line = "abby@void.com 2021-03-27 12:12 P01 1";
            string[] words = line.Split(' ');
            string expectedCode = "P01";

            // act
            ReportsGenerator.TryParseOrder(words, out Order order);
            var item = order.Items;
            var pCode = item[0].ProductCode.ToString();

            // assert
            pCode.Should().Be(expectedCode);
        }

        [Test]
        public void TestParseOrderQuantity()
        {
            // arrange
            string line = "abby@void.com 2021-03-27 12:12 P01 1";
            string[] words = line.Split(' ');
            int expectedQnty = 1;

            // act
            ReportsGenerator.TryParseOrder(words, out Order order);
            var item = order.Items;
            var pQnty = item[0].Quantity;

            // assert
            Convert.ToInt32(pQnty).Should().Be(expectedQnty);
        }

        // test failed
        [Test]
        public void Test2Orders()
        {
            // arrange
            List<string> data = new List<string>();
            data.Add("abby@void.com 2021-02-11 10:00 P01 1");
            data.Add("bobby@void.com 11-02-2021 15:00");
            data.Add("P02b 2");
            int ordersQnty = 1;

            IData fileData = new DataStub(data);

            // act
            var orders = ReportsGenerator.ReadOrders(fileData);
            int items = orders.Sum(o => o.Items.Count);

            // assert
            ordersQnty.Should().Be(items);
        }

        [Test]
        public void TestErrorLineNumber()
        {
            // arrange
            List<string> data = new List<string>();
            data.Add("abby@void.com 2021-02-11 10:00 P01 1");
            data.Add("bobby@void.com 2021-02-11 15:00 P02b 2");
            data.Add("charley@void.com 21-02-2011 12:30");
            data.Add("P01");
            data.Add("P42 5");
            IData fileData = new DataStub(data);
            ITime time = new TimeStub(new DateTime(2021, 02, 11));
            int errorLine = 3;

            // act
            ReportsGenerator.TodaysOrdersReport(fileData, time);
            int line = ReportsGenerator.lineNumber;

            // assert
            errorLine.Should().Be(line);
        }
    }
}
