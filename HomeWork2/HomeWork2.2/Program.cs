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
                new DateTime(2015, 03, 01),
                new DateTime(2017, 11, 15),
                new DateTime(2018, 05, 15),
                new DateTime(2019, 07, 21),
                new DateTime(2020, 12, 23)
            };

            Sort sort = new Sort();

            var newDate = new DateTime(2019, 07, 22);

            int index = sort.GetIndex(datetime, newDate);

            datetime.Insert(index, newDate);
            sort.ShowDates(datetime);
            sort.CheckSort(datetime);

            Console.ReadKey();
        }
    }
}
