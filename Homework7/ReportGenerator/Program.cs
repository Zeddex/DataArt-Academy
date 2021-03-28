using System;
using System.Collections.Generic;

namespace ReportGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            ReportsGenerator.TodaysOrdersReport(ordersFilePath: "orders-sample2.txt");
            Console.ReadLine();
        }
    }
}
