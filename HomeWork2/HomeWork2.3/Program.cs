using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork2._3
{
    class Program
    {
        #region HW 2.3
        // Часть 3. 
        // Измените ваш метод таким образом, чтобы он мог работать со коллекциями любых других типов данных, для которых можно определить отношение порядка следования 
        // (т.е. не только с коллекциями дат, но и например, коллекциями строк, чисел или интервалов времени). 
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
