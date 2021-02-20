using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork2._2
{
    class Program
    {
        #region HW 2.2
        // Часть 1. 
        // Реализуйте метод для вставки новой даты в упорядоченную коллекцию дат, с сохранением порядка сортировки:
        // дата должна быть добавлена в коллекцию так, чтобы после добавления элементы коллекции по прежнему шли в хронологическом порядке.
        // Метод должен возвращать либо новую коллекцию, либо существующую измененную коллекцию.
        //
        // Часть 2. 
        // Добавьте в метод проверку, что исходная коллекция действительно упорядочена по возрастанию.
        // Необходимо выбросить исключение, если это не так.
        #endregion

        static void Main(string[] args)
        {

            List<DateTime> datetime = new List<DateTime>
            {
                new DateTime(2020, 12, 23),
                new DateTime(2015, 03, 01),
                new DateTime(2018, 05, 15),
                new DateTime(2019, 07, 21),
                new DateTime(2017, 11, 15)
            };

            Date date = new Date();

            //date.CheckSort(datetime);
            Console.WriteLine("Unsorted dates:");
            date.ShowDates(datetime);

            var datetimeNew1 = date.SortDate(datetime);
            date.CheckSort(datetimeNew1);
            Console.WriteLine("\nSorted dates:");
            date.ShowDates(datetimeNew1);

            date.AddDate(datetime, new DateTime(2016, 05, 10));
            var datetimeNew2 = date.SortDate(datetime);
            date.CheckSort(datetimeNew2);
            Console.WriteLine("\nWith new date:");
            date.ShowDates(datetimeNew2);
            Console.ReadKey();

        }
    }

    public class Date
    {
        /// <summary>
        /// Add new date to list of dates
        /// </summary>
        /// <param name="datetime">List of dates</param>
        /// <param name="newDate">New date</param>
        /// <returns></returns>
        public List<DateTime> AddDate(List<DateTime> datetime, DateTime newDate)
        {
            datetime.Add(newDate);
            return datetime;
        }

        /// <summary>
        /// Sort dates by year, month and day
        /// </summary>
        /// <param name="datetime">List of dates</param>
        /// <returns></returns>
        public List<DateTime> SortDate(List<DateTime> datetime)
        {
            datetime = datetime.OrderBy(e => e.Year)
                .ThenBy(e => e.Month)
                .ThenBy(e => e.Day)
                .ToList();
            return datetime;
        }

        /// <summary>
        /// Print result list of dates
        /// </summary>
        /// <param name="datetime"></param>
        public void ShowDates(List<DateTime> datetime)
        {
            foreach (var element in datetime)
            {
                Console.WriteLine(element);
            }
        }

        public void CheckSort(List<DateTime> datetime)
        {
            for (int i = 1; i < datetime.Count; i++)
            {
                if (datetime[i - 1].Year > datetime[i].Year)
                    throw new Exception("List is not sorted!");
            }
        }
    }
}
