using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2._2
{
    public class Sort
    {
        public int GetIndex(List<DateTime> dateList, DateTime currentDate)
        {
            int index = 0;

            for (int i = 0; i < dateList.Count; i++)
            {
                if (currentDate.Year > dateList[i].Year)
                {
                    index++;
                }
                else if (currentDate.Year == dateList[i].Year)
                {
                    if (currentDate.Month > dateList[i].Month)
                    {
                        index++;
                    }
                    else if (currentDate.Month == dateList[i].Month)
                    {
                        if (currentDate.Day > dateList[i].Day || currentDate.Day == dateList[i].Month)
                        {
                            index++;
                        }
                    }
                }
            }

            return index;
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
